using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float bodyDamage = 30f;
    [SerializeField] float headDamage = 100f;
    [SerializeField] GameObject hitEffect;
    [SerializeField] ParticleSystem fireVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;

    AudioSource rifleAudioSource;

    bool canShoot = true;

    private void Start() 
    {
        rifleAudioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() 
    {
        canShoot = true;
    }

    private void Update() 
    {
        DisplayAmmo();
        if(Input.GetMouseButtonDown(0) && ammoSlot.GetCurrentAmmo(ammoType) > 0 && canShoot)
        {
            StartCoroutine(Shoot());
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }    
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        PlayFireVFX();
        ProcessRaycast();
        RifleFireSound();
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            if(hit.collider is CapsuleCollider && hit.transform.gameObject.tag == "Enemy")
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                target.TakeDamage(bodyDamage);
                print("Body Shot");
            }
            else if(hit.collider is BoxCollider && hit.transform.gameObject.tag == "Enemy")
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                target.TakeDamage(headDamage);
                print("Head Shot");
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

    private void DisplayAmmo()
    {
        ammoText.text = "Ammo:  " + ammoSlot.GetCurrentAmmo(ammoType).ToString();  
    }

    private void RifleFireSound()
    {
        rifleAudioSource.Play();
    }
}
