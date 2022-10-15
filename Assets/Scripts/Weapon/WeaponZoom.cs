using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera followCamera;
    [SerializeField] Camera weaponCamera;

    [SerializeField] FirstPersonController firstPersonController;
    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomedInFOV = 20f;


    [SerializeField] float zoomedOutSensitivity = 1f;
    [SerializeField] float zoomedInSensitivity = 0.4f;


    bool zoom = false;
    
    private void OnDisable() 
    {
        ZoomOut();
        zoom = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            zoom = !zoom;
            if(zoom)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        followCamera.m_Lens.FieldOfView = zoomedInFOV;
        weaponCamera.fieldOfView = zoomedInFOV;
        firstPersonController.RotationSpeed = zoomedInSensitivity;
    }

    private void ZoomOut()
    {
        followCamera.m_Lens.FieldOfView = zoomedOutFOV;
        weaponCamera.fieldOfView = zoomedOutFOV;
        firstPersonController.RotationSpeed = zoomedOutSensitivity;
    }
}
