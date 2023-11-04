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
        if (_letter)
        {
            DropLetter();
        }
        letter.transform.SetParent(transform);
        _letter = letter;
    }

    public void DropLetter()
    {
        _letter.transform.SetParent(null);
        _letter = null;
    }
}
