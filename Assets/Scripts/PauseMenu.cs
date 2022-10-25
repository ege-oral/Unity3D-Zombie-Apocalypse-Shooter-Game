using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool pause = true;

    [SerializeField] GameObject pauseMenuUI;
    Weapon[] weapons;
    Flashlight flashlight;
    Camera mainCamera;
    StarterAssetsInputs starterAssetsInputs;

    private void Start() 
    {
        weapons = FindObjectsOfType<Weapon>();
        mainCamera = Camera.main;
        starterAssetsInputs = FindObjectOfType<StarterAssetsInputs>();
        flashlight = FindObjectOfType<Flashlight>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        starterAssetsInputs.cursorInputForLook = true;
        flashlight.enabled = true;
        EnableAllWeapons();
        pause = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        starterAssetsInputs.look = new Vector2(0f,0f);  // Prevent spin the camera.
        starterAssetsInputs.cursorInputForLook = false;
        flashlight.enabled = false;
        DisableAllWeapons();
        pause = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Prevent Fire in Pause Menu.
    private void DisableAllWeapons()
    {
        foreach(Weapon weapon in weapons)
        {
            weapon.enabled = false;
        }
    }

    private void EnableAllWeapons()
    {
        foreach(Weapon weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
