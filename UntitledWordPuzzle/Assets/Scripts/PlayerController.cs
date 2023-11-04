using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float CamSpeed;
    private Camera _cam;
    private PlayerInput _playerInput;
    private MouseController _mouseController;
    private void Awake()
    {
        _cam = Camera.main;
        _mouseController = FindObjectOfType<MouseController>();
        
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        
        _playerInput.Input.PickupLetter.started += OnPointerDown;
        _playerInput.Input.PickupLetter.canceled += OnPointerUp;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = _playerInput.Input.Pan.ReadValue<float>();
        if (mouseX < 20f)
        {
            transform.position -= new Vector3(Time.deltaTime * CamSpeed, 0);
        } else if(mouseX > Screen.width-20f){
            transform.position += new Vector3(Time.deltaTime * CamSpeed, 0);
        }
    }

    private void OnPointerDown(InputAction.CallbackContext context)
    {
        
    }

    private void OnPointerUp(InputAction.CallbackContext context)
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(_cam.ScreenPointToRay(Mouse.current.position.value));
        if (hit && hit.rigidbody.gameObject.CompareTag("Letter"))
        {
            _mouseController.PickUpLetter(hit.rigidbody.gameObject.GetComponent<Letter>());
        }
    }
}
