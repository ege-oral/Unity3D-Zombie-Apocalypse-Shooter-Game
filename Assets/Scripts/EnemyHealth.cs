using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;


    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        print(hitPoints);
        if(hitPoints <= Mathf.Epsilon)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}