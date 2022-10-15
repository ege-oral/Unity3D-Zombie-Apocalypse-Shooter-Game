using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] GameObject weapons;
    AudioSource[] allAudioListeners;

    private void Start() 
    {
        gameOverCanvas.enabled = false;    
        // Lock the cursor at the start of the game.
        Cursor.lockState = CursorLockMode.Locked;
        allAudioListeners = FindObjectsOfType<AudioSource>();
    }

    // TO DO fix bug that remove light when player dies.
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        weapons.SetActive(false);
        DisableAllAudio();
        
        // Free the cursor if player dies.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void DisableAllAudio()
    {
        foreach(AudioSource audio in allAudioListeners)
        {
            audio.enabled = false;
        }
    }
}
