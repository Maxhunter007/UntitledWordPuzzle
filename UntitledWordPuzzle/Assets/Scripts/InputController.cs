using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private float CamSpeed;
    private Camera _cam;
    private PlayerInput _playerInput;
    private MouseController _mouseController;
    private LetterManager _letterManager;

    private void Awake()
    {
        _cam = Camera.main;
        _mouseController = FindObjectOfType<MouseController>();
        _letterManager = FindObjectOfType<LetterManager>();
        
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
        RaycastHit2D hit = Physics2D.GetRayIntersection(_cam.ScreenPointToRay(Mouse.current.position.value));
        if (hit.collider && hit.collider.gameObject.CompareTag("Letter"))
        {
            _mouseController.PickUpLetter(hit.rigidbody.gameObject.GetComponent<Letter>());
        }
        if (hit.collider && hit.collider.gameObject.CompareTag("Puzzle"))
        {
            _letterManager.Disable();
            _letterManager.Enable(hit.transform.gameObject.GetComponent<Puzzle>());
        }
    }

    private void OnPointerUp(InputAction.CallbackContext context)
    {
        _mouseController.DropLetter();
    }
}
