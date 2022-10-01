using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPinCode : MonoBehaviour
{
    Text buttonText;
    CheckPinCode checkPinCode;

    private void Awake() 
    {
        checkPinCode = FindObjectOfType<CheckPinCode>();
        buttonText = GetComponentInChildren<Text>();
    }

    public void ButtonClick()
    {
        checkPinCode.AddDigitToPassword(buttonText.text);
    }

    public void ResetPassword()
    {
        checkPinCode.ResetPassword();
    }

    public void EnterPassword()
    {
        checkPinCode.CheckIfPasswordValid();
    }
    
}
