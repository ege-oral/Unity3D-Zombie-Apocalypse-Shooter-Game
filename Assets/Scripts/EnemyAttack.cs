using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smackInAHead = 40f;

    PlayerHealth playerHealth;

    private void Awake() 
    {
        playerHealth = FindObjectOfType<PlayerHealth>();    
    }

    public void AttackHitEvent()
    {
        if(target == null) { return; }
        target.GetComponent<PlayerHealth>().TakeDamage(smackInAHead);
    }
}
