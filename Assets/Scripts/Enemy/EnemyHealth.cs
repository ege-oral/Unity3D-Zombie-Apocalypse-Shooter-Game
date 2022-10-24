using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Animator animator;

    private void Start() 
    {
        animator = GetComponent<Animator>(); 
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        // Switch enemy idle audio to attack audio.
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");

        Component[] components = gameObject.GetComponents(typeof(Component));
        foreach(Component c in components)
        {
            if(c is Transform || c is Animator || c is MeshRenderer || c is MeshFilter)
            {
                // Don't Destroy.
            }
            else
            {
                MonoBehaviour.DestroyImmediate(c);
            }
        }
    }
}
