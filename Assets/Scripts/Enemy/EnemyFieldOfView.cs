using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class EnemyFieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;
    public GameObject enemyEyes;

    [SerializeField] public LayerMask targetMask;
    public LayerMask obstaclesMask;

    public bool canSeePlayer = false;

    private void Start() 
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.2f);

        while(true)
        {
            yield return waitTime;
            FiledOfViewCheck();
        }
    }

    private void FiledOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(enemyEyes.transform.position, radius, targetMask);
        
        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - enemyEyes.transform.position).normalized;
            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(enemyEyes.transform.position, target.position);

                if(!Physics.Raycast(enemyEyes.transform.position, directionToTarget, distanceToTarget, obstaclesMask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if(canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}
