using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float smackInAHead = 20f;
    [SerializeField] Canvas canvas;

    PlayerHealth playerHealth;

    private void Awake() 
    {
        target = FindObjectOfType<PlayerHealth>();    
        canvas.enabled = false;
    }

    public void AttackHitEvent()
    {
        if(target == null) { return; }
        target.TakeDamage(smackInAHead);
        StartCoroutine(DisplayTakeDamageCanvas());
    }

    IEnumerator DisplayTakeDamageCanvas()
    {
        canvas.enabled = true;
        yield return new WaitForSeconds(.3f);
        canvas.enabled = false;
    }
}
