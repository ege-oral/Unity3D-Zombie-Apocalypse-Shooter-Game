using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    Problems: 
    1- AdjustEnemyHeadBoxCollider function may not be 
    the best approach here.
*/

public class EnemyAI : MonoBehaviour
{
    
    Transform target;
    NavMeshAgent navMeshAgent;
    Animator animator;
    BoxCollider head;

    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    float distaneToTarget = Mathf.Infinity;
    bool isProvoked = false;

    AudioSource enemyAudioSource;
    [SerializeField] AudioClip zombieAttackAudioClip;
    bool isZombieInIdleMode = true;

    private void Awake() 
    {
        head = GetComponent<BoxCollider>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAudioSource = GetComponent<AudioSource>();
    }


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
        }
    }

    private void EngageTarget()
    {
        FaceTarget();
        // Changin zombies auido clip to attack mode.
        if(isZombieInIdleMode)
        {
            ChangeAuidoToAttack();
            isZombieInIdleMode = false;
        }

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
        AdjustEnemyHeadBoxCollider();
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

    // In order the headshot the zombie we adjust the box collider position.
    // We can't do it in animtaion window because the value keeps reset itself.
    // I don't know why but most probably because of the zombie built-in animation.
    // So we do it in here manually.
    public void AdjustEnemyHeadBoxCollider()
    {
        head.center = new Vector3(0.0003457f, 1.571465f, 0.26019f);
        head.size = new Vector3(0.1778f, 0.2930298f, 0.22023f);
    }

    private void ChangeAuidoToAttack()
    {
        enemyAudioSource.clip = zombieAttackAudioClip;
        enemyAudioSource.volume = 0.6f;
        enemyAudioSource.pitch = 1.1f;
        enemyAudioSource.Play();
    }
}
