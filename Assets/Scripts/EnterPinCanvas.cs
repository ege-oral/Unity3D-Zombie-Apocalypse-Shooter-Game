using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPinCanvas : MonoBehaviour
{
    [SerializeField] Canvas enterPinCanvas;
    GameObject weaponSwitcher;

    private void Start() 
    {
        weaponSwitcher = GameObject.FindGameObjectWithTag("Weapons");
        enterPinCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        weaponSwitcher.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        enterPinCanvas.enabled = true;
    }

    private void OnTriggerExit(Collider other) {
        
        weaponSwitcher.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        enterPinCanvas.enabled = false;
    }
}
