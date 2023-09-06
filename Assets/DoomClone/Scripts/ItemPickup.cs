using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    [System.Flags]
    public enum CollectibleType
    {
        Health,
        Ammo,
        Armor
    }
    public CollectibleType collectibleType;
    
    public int amount;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            switch (collectibleType)
            {
                case CollectibleType.Health:
                    other.GetComponent<PlayerHealth>().GiveHealth(amount, this.gameObject);
                    break;
                case CollectibleType.Armor:
                    other.GetComponent<PlayerHealth>().GiveArmor(amount, this.gameObject);
                    break;
                case CollectibleType.Ammo:
                    other.GetComponentInChildren<Gun>().GiveAmmo(amount, this.gameObject);
                    break;
            }
        }
    }
}
