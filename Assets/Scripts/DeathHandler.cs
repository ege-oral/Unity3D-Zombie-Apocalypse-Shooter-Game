using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    PlayerHealth playerHealth;

    private void Start() 
    {
        gameOverCanvas.enabled = false;    
        playerHealth = GetComponent<PlayerHealth>();
        // Lock the cursor at the start of the game.
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() 
    {
        HandleDeath();
    }

    public void HandleDeath()
    {
        if(playerHealth.isPlayerDead())
        {
            gameOverCanvas.enabled = true;
            // Free the cursor if player dies.
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
