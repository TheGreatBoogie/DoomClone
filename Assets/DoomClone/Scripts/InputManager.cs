using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject().AddComponent<InputManager>();
                _instance.name = "InputManagerInstance";
            }
            return _instance;
        }
    }

    private PlayerInputAction _playerInputAction;
    public InputAction look;
    public InputAction move;
    public InputAction fire;
    
    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();
    }

    private void OnEnable()
    {
        _playerInputAction.Player.Enable();
        look = _playerInputAction.Player.Look;
        move = _playerInputAction.Player.Move;
        fire = _playerInputAction.Player.Fire;
    }

    private void OnDisable()
    {
        _playerInputAction.Player.Disable();
    }
}
