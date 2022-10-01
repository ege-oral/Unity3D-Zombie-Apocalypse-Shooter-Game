using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            print("1");
        }
        
        if(Input.GetKey(KeyCode.E))
        {
            print("e was pressed");
        }
    }

    private void OnTriggerExit(Collider other) {
        winTheGameCanvas.enabled = false;
    }
}
