using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    // Players Current Ammo Function
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }
    // Reduce Current Ammo
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount -= 1;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int increaseAmmoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += increaseAmmoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(ammoType == slot.ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
