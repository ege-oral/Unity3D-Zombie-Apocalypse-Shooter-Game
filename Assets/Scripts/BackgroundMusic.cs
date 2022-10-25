using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private void Awake() 
    {
        GameObject[] backgroundMusicObjects = GameObject.FindGameObjectsWithTag("Background Music");
        if(backgroundMusicObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        if(SceneManager.GetActiveScene().name == "Game")
        {
            // First background music object.
            backgroundMusicObjects[0].GetComponent<AudioSource>().volume = 0.3f;
        }
    }
}
