using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 0.8f;
    [SerializeField] float minimumAngle = 30f;

    Light myLight;


    private void Start() 
    {
        myLight = GetComponent<Light>();
    }

    private void Update() 
    {
        // Is light on ?
        if(myLight.isActiveAndEnabled)
        {
            DecreaseLightIntensity();
            DecreaseLightAngle();
        }
        ToggleFlashLight();
    }

    public void RestoreLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    public void RestoreLightAngle(float angleAmount)
    {
        myLight.spotAngle = angleAmount;
    }

    private void DecreaseLightAngle()
    {
        if(myLight.spotAngle <= minimumAngle) 
        { 
            myLight.spotAngle = minimumAngle;
            return; 
        }
        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }

    private void ToggleFlashLight()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            myLight.enabled = !myLight.isActiveAndEnabled; 
        }
    }
}
