using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float intensityAmount = 5f;
    [SerializeField] float angleAmount = 40f;

    Flashlight flashlight;

    private void Start() 
    {
        flashlight = FindObjectOfType<Flashlight>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            flashlight.RestoreLightIntensity(intensityAmount);
            flashlight.RestoreLightAngle(angleAmount);
            Destroy(this.gameObject);
        }
    }
}
