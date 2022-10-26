using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] GameObject weapons;
    Flashlight flashlight;
    PauseMenu pauseMenu;

    private void Start() 
    {
        gameOverCanvas.enabled = false;
        flashlight = GetComponentInChildren<Flashlight>();
        pauseMenu = FindObjectOfType<PauseMenu>();

        // Lock the cursor at the start of the game.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // TO DO fix bug that remove light when player dies.
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        weapons.SetActive(false);
        flashlight.enabled = false;
        pauseMenu.enabled = false;
        AudioListener.pause = true;
        
        // Free the cursor if player dies.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
