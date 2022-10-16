using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Animator animator;
    NavMeshAgent navMeshAgent;
    EnemyAI enemyAI;
    CapsuleCollider capsuleCollider;
    BoxCollider boxCollider;
    AudioSource enemyAudioSource;
    

    private void Start() 
    {
        animator = GetComponent<Animator>(); 
        navMeshAgent = GetComponent<NavMeshAgent>();   
        enemyAI = GetComponent<EnemyAI>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        boxCollider = GetComponent<BoxCollider>();
        enemyAudioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        // Switch enemy idle audio to attack audio.
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
        enemyAI.enabled = false;
        navMeshAgent.enabled = false;
        capsuleCollider.enabled = false;
        boxCollider.enabled = false;
        enemyAudioSource.enabled = false;
    }
}