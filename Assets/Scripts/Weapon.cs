using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;

    private void Update() 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }    
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thig: " + hit.transform.name);
            if(hit.transform.tag.Equals("Enemy"))
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                target.TakeDamage(damage);
            }
                
        }
        else
        {
            return;
        }
    }
}
