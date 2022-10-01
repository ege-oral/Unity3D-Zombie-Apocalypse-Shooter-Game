using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPinCanvas : MonoBehaviour
{
    [SerializeField] Canvas enterPinCanvas;
    Weapon playerWeapon;

    private void Start() 
    {
        playerWeapon = FindObjectOfType<Weapon>();
        enterPinCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        playerWeapon.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        enterPinCanvas.enabled = true;
    }

    private void OnTriggerExit(Collider other) {
        playerWeapon.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        enterPinCanvas.enabled = false;
    }
}
