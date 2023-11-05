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
        letter.DisableGravity();
        letter.IsInHand = true;
        _letter = letter;
    }

    public void DropLetter()
    {
        if (_letter)
        {
            _letter.transform.SetParent(null);
            _letter.IsInHand = false;
            if (!_letter.HasSnapPosition)
            {
                _letter.EnableGravity();
            }
        }
        _letter = null;
    }
}
