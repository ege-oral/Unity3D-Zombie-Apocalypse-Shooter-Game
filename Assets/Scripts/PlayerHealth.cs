using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHitPoint = 100f;
    [SerializeField] TextMeshProUGUI playerHealthText;

    private void Update() 
    {
        playerHealthText.text = "Player Health:  " + playerHitPoint.ToString();    
    }


    public void TakeDamage(float damage)
    {
        playerHitPoint -= damage;
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
