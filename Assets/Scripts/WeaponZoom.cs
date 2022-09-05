using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera followCamera;
    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomedInFOV = 20f;

    bool zoom = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            zoom = !zoom;
            if(zoom)
                followCamera.m_Lens.FieldOfView = zoomedInFOV;
            else
                followCamera.m_Lens.FieldOfView = zoomedOutFOV;
        }
    }
}
