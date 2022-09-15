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
        DecreaseLightIntensity();
        DecreaseLightAngle();
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
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
}
