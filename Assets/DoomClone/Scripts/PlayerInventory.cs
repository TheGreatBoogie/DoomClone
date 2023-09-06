using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInventory : MonoBehaviour
{
    public List<DoorItemSO> myDoorItems;

    private void Awake()
    {
        foreach (var key in myDoorItems)
        {
            key.remainingUse = 7;
            Debug.Log("Remaining use initialized");
        }
    }

    public void CheckRemainingUse(DoorItemSO doorItemSo)
    {
        if (doorItemSo.remainingUse <= 0)
        {
            myDoorItems.Remove(doorItemSo);
            Debug.Log("Key is destroyed");
        }
    }
}