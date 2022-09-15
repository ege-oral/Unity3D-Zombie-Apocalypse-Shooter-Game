using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float smackInAHead = 20f;
    [SerializeField] GameObject takeDamageCanvas;

    PlayerHealth playerHealth;

    private void Awake() 
    {
        target = FindObjectOfType<PlayerHealth>();    
        takeDamageCanvas.SetActive(false);
    }

    public void AttackHitEvent()
    {
        if(target == null) { return; }
        target.TakeDamage(smackInAHead);
        StartCoroutine(DisplayTakeDamageCanvas());
    }

    IEnumerator DisplayTakeDamageCanvas()
    {
        takeDamageCanvas.SetActive(true);
        yield return new WaitForSeconds(.3f);
        takeDamageCanvas.SetActive(false);
    }
}
