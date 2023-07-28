using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Key : MonoBehaviour
{
    public DoorItemSO key;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerInventory = other.GetComponent<PlayerInventory>().myDoorItems;
            playerInventory.Add(key);
            Debug.Log("Key Added");
            Destroy(gameObject);
        }
    }
}
