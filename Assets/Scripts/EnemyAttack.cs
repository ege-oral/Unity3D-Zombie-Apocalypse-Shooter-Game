using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float smackInAHead = 40f;

    PlayerHealth playerHealth;

    private void Awake() 
    {
        target = FindObjectOfType<PlayerHealth>();    
    }

    public void AttackHitEvent()
    {
        if(target == null) { return; }
        target.TakeDamage(smackInAHead);
    }
}
