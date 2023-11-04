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
        var rigidbody = letter.GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        rigidbody.velocity = Vector2.zero;
        _letter = letter;
    }

    public void DropLetter()
    {
        if (_letter)
        {
            _letter.transform.SetParent(null);
            _letter.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        _letter = null;
    }
}
