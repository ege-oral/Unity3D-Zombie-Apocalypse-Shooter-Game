using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHitPoint = 100f;

    public void TakeDamage(float damage)
    {
        playerHitPoint -= damage;
        print(playerHitPoint);
        if(playerHitPoint <= Mathf.Epsilon)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player is DEAD");
    }

}
