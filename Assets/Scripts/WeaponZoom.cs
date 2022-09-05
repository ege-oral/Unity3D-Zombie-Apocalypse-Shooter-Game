using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera followCamera;
    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomedInFOV = 20f;

    FirstPersonController firstPersonController;

    [SerializeField] float zoomedOutSensitivity = 1f;
    [SerializeField] float zoomedInSensitivity = 0.4f;


    bool zoom = false;
    
    private void Start() 
    {
        firstPersonController = GetComponent<FirstPersonController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            zoom = !zoom;
            if(zoom)
            {
                followCamera.m_Lens.FieldOfView = zoomedInFOV;
                firstPersonController.RotationSpeed = zoomedInSensitivity;
            }
            else
            {
                followCamera.m_Lens.FieldOfView = zoomedOutFOV;
                firstPersonController.RotationSpeed = zoomedOutSensitivity;
            }
                
        }
    }
}
