using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _doorAnim;

    public DoorItemSO doorItem;

    private void Awake()
    {
        _doorAnim = GetComponentInChildren<Animator>();
        Debug.Log("Door type: " + doorItem.myString);
    }

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerInventory>().myDoorItems.Contains(doorItem))
        {
            _doorAnim.SetTrigger("OpenDoor");
            Debug.Log("Opening Door");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerInventory>().myDoorItems.Contains(doorItem))
        {
            _doorAnim.SetTrigger("OpenDoor");
            Debug.Log("Closing door");
        }
    }
}