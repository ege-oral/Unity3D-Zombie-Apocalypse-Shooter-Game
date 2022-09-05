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
        isPlayerDead();
    

    }
    private void isPlayerDead()
    {
        if(playerHitPoint <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }



}
