using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    private Camera _cam;
    private Letter _letter; 
    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        transform.position = _cam.ScreenToWorldPoint( Mouse.current.position.value) + new Vector3(0,0,10);
    }
    
    public void PickUpLetter(Letter letter)
    {
        letter.transform.SetParent(transform);
        _letter = letter;
    }
}
