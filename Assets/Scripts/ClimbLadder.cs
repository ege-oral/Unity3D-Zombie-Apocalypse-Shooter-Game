using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    public bool canClimb = false;
   
    private void OnTriggerEnter(Collider other) {
 
        if(other.gameObject.tag == "Player Foot")
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        
        canClimb = false;
    }
}
