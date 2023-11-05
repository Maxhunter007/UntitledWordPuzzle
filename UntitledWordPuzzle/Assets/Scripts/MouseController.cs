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
        DropLetter();
        letter.PickUp();
        _letter = letter;
    }

    public void DropLetter()
    {
        if (_letter)
        {
            _letter.Drop();
        }
        _letter = null;
    }
}
