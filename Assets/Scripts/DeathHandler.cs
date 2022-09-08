using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start() 
    {
        gameOverCanvas.enabled = false;    
        // Lock the cursor at the start of the game.
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;

        // Free the cursor if player dies.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
