using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHitPoint = 100f;


    private void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                Debug.Log(mousePos.x);
                Debug.Log(mousePos.y);
            }
        }    
    }
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
