using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    
    private InputManager _inputManager;
    private CharacterController _myCc;
    public Animator camAnim;
    private bool _isWalking;
    private Vector3 _inputVector;
    private Vector3 _movementVector;
    
    private float _myGravity = -10f;
    public float momentumDamping = 5f;
    public float playerSpeed = 10f;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
    }

    void Start()
    {
        _myCc = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
        MovePlayer();
        camAnim.SetBool("isWalking", _isWalking);
    }
    

    // ReSharper disable Unity.PerformanceAnalysis
    void GetInput()
    {
        if (_inputManager.move.ReadValue<Vector2>().x != 0f || _inputManager.move.ReadValue<Vector2>().y != 0f)
        {
            _isWalking = true;
            _inputVector = new Vector3(_inputManager.move.ReadValue<Vector2>().x, 0f, _inputManager.move.ReadValue<Vector2>().y);
            _inputVector.Normalize();
            _inputVector = transform.TransformDirection(_inputVector);
        }
        else
        {
            _isWalking = false; 
            _inputVector = Vector3.Lerp(_inputVector, Vector3.zero, momentumDamping * Time.deltaTime);
        }
        
        _movementVector = (_inputVector * playerSpeed) + (Vector3.up * _myGravity );
    }

    void MovePlayer()
    {
        _myCc.Move(_movementVector * Time.deltaTime);
    }


    
}
