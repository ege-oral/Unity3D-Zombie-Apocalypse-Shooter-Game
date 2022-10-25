using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTheGame : MonoBehaviour
{
    [SerializeField] Canvas winTheGameCanvas;

    private void Start() {
        winTheGameCanvas.enabled = false;
    }

    private void OnTriggerStay(Collider other) 
    {
        // If the canvas not enable.
        if(!winTheGameCanvas.isActiveAndEnabled) {
            winTheGameCanvas.enabled = true;
        }
        
        if(Input.GetKey(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("End Screen");
        }
    }

    private void OnTriggerExit(Collider other) {
        winTheGameCanvas.enabled = false;
    }
}
