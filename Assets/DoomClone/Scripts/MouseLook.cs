using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private bool _horizontalCamera;

    private InputManager _inputManager;
    private Camera _camera;
    private float _currentLookingPosX;
    private float _currentLookingPosY;
    private float _xMousePos;
    private float _yMousePos;
    private float _smoothedMousePosX;
    private float _smoothedMousePosY;
    
    public float sensitivity = 1.5f;
    public float smoothing = 1.5f;


    private void Awake()
    {
        _inputManager = InputManager.Instance;
    }
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _camera = Camera.main;

    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void GetInput()
    {
        _xMousePos = _inputManager.look.ReadValue<Vector2>().x;
        _yMousePos = _inputManager.look.ReadValue<Vector2>().y;
    }

    void ModifyInput()
    {
        _xMousePos *= sensitivity;
        _yMousePos *= sensitivity;
        _smoothedMousePosX = Mathf.Lerp(_smoothedMousePosX, _xMousePos, 1f / smoothing);
        _smoothedMousePosY = Mathf.Lerp(_smoothedMousePosY, _yMousePos, 1f / smoothing);
    }

    void MovePlayer()
    {
        _currentLookingPosX += _smoothedMousePosX;
        _currentLookingPosY += _smoothedMousePosY;
        transform.rotation = Quaternion.Euler(0f, _currentLookingPosX, 0f);
        if (_horizontalCamera) _camera.transform.localRotation = Quaternion.Euler(-_currentLookingPosY, 0f, 0f);
    }
    

}
