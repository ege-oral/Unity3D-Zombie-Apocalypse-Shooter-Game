using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPinCode : MonoBehaviour
{
    const string CORRECT_PASSWORD = "1458";

    TextMeshProUGUI pinCode;
    public string passwordText = "";
    [SerializeField] Canvas enterPinCanvas;

    [SerializeField] Animator doorAnimator;
    [SerializeField] BoxCollider enterPinCollider;
    Weapon playerWeapon;


    void Awake()
    {
        pinCode = GetComponentInChildren<TextMeshProUGUI>();
        playerWeapon = FindObjectOfType<Weapon>();
    }

    void Update()
    {
        pinCode.text = passwordText;
    }

    public void AddDigitToPassword(string digit)
    {
        if(passwordText == "TRY AGIN!")
            passwordText = "";

        if(passwordText.Length < 4)
            passwordText += digit;   
    }

    public void ResetPassword()
    {
        passwordText = "";
    }

    public void CheckIfPasswordValid()
    {
        if(pinCode.text == CORRECT_PASSWORD)
        {
            passwordText = "CORRECT!";
            StartCoroutine(OpenDoor());
        }
        else
        {
            passwordText = "TRY AGIN!";
        }
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(1f);
        Cursor.lockState = CursorLockMode.Locked;
        enterPinCanvas.enabled = false;
        enterPinCollider.enabled = false;
        playerWeapon.enabled = true;
        doorAnimator.SetBool("Open", true);
    }

}
