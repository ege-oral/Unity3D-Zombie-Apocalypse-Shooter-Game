using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] GameObject hitEffect;

    [SerializeField] ParticleSystem fireVFX;
 
    private void Update() 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }    
    }

    private void Shoot()
    {
        PlayFireVFX();
        ProcessRaycast();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            if(hit.transform.tag.Equals("Enemy"))
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                target.TakeDamage(damage);
            }
            CreateHitImpact(hit);
                
        }
        else
        {
            return;
        }
    }
    
    private void PlayFireVFX()
    {
        fireVFX.Play();
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
