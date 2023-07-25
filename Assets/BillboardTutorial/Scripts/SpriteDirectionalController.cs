using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirectionalController : MonoBehaviour
{
    [SerializeField] private float backAngle = 0f;
    [SerializeField] private float sideAngle = 155f; 
    [SerializeField] private Transform mainTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void LateUpdate()
    {
        Vector3 cam = Camera.main.transform.forward;
        Vector3 camForwardVector = new Vector3(cam.x, 0f, cam.z); 
        Debug.DrawRay(Camera.main.transform.position, camForwardVector * 5f, Color.magenta);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);
        Vector2 animationDirection = new Vector2(0f, -1f);
        float angle = Mathf.Abs(signedAngle);

        if (signedAngle < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (signedAngle > 0)
        {
            spriteRenderer.flipX = false;
        }
        

    }
}
