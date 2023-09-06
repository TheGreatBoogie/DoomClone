using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _doorAnim;
    private bool _isOpened = false;

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
        var playerInventory = other.GetComponent<PlayerInventory>();
        if (other.CompareTag("Player") && playerInventory.myDoorItems.Contains(doorItem))
        {
            _doorAnim.SetTrigger("OpenDoor");
            _isOpened = true;
            doorItem.remainingUse--;
            Debug.Log("Remaining use: " + doorItem.remainingUse);
            playerInventory.CheckRemainingUse(doorItem);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var playerInventory = other.GetComponent<PlayerInventory>();

        if (other.CompareTag("Player") && _isOpened)
        {
            _doorAnim.SetTrigger("OpenDoor");
            _isOpened = false;
            Debug.Log("Closing door");
        }
    }
}