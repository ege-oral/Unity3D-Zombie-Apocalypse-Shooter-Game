using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    Transform target;
    NavMeshAgent navMeshAgent;
    float distaneToTarget = Mathf.Infinity;

    bool isProvoked = false;

    Animator animator;

    private void Awake() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        distaneToTarget = Vector3.Distance(transform.position, target.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distaneToTarget <= chaseRange)
        {
            isProvoked = true;
            //navMeshAgent.SetDestination(target.position);
        }
    }

    private void EngageTarget()
    {
        FaceTarget();
        if(distaneToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if(distaneToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        
    }

    private void ChaseTarget()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        animator.SetBool("attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRoation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRoation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    

}
