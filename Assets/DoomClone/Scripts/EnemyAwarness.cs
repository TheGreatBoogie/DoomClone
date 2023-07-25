using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyAwarness : MonoBehaviour
{
    public Material aggroMat;
    public Material baseMat;
    private Material enemyMaterial;
    private Transform playerTransform;
    public float awarnessRadius = 20;
    public bool isAware = false;
    
    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        // Check player proximity
        var dist = Vector3.Distance(transform.position, playerTransform.position);

        if (dist <= awarnessRadius)
        {
            Aware(true);
        }
        else if (dist > awarnessRadius && isAware)
        {
            StartCoroutine(ReleaseAggroSound());
        }
        else if (dist > awarnessRadius)
        {
            Aware(false);
        }
    }

    public void AggroSound()
    {
        Aware(true);
        awarnessRadius = 50f;
        StartCoroutine(ReleaseAggroSound());
    }

    private IEnumerator ReleaseAggroSound()
    {
        yield return new WaitForSeconds(3f);
        Aware(false);
    }

    private void Aware(bool awareness)
    {
        if (awareness)
        {
            isAware = true;
            GetComponent<MeshRenderer>().material = aggroMat;
        }
        else
        {
            isAware = false;
            GetComponent<MeshRenderer>().material = baseMat;
        }
    }

    
}
