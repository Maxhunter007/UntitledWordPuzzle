using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Letter : MonoBehaviour
{
    public bool HasSnapPosition;
    public bool IsInHand;

    private LetterContainer _snapContainer;
    private Vector3 SnapPosition => _snapContainer.transform.position;

    //Components
    private Rigidbody2D _rigidbody;
    private TextMeshPro _textMesh;
    
    //Singletons
    private MouseController _mouseController;

    public string TextContent{
        get => _textMesh.text;
        set => _textMesh.text = value;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _textMesh = GetComponent<TextMeshPro>();
        
        _mouseController = FindObjectOfType<MouseController>();
        
    }

    private void Update()
    {
        if (HasSnapPosition)
        {
            _rigidbody.velocity = (SnapPosition - transform.position) * 3;
            if (_rigidbody.velocity.magnitude < math.EPSILON)
            {
                HasSnapPosition = false;
            }
        }

        if (IsInHand)
        {
            _rigidbody.velocity = 10f * (transform.parent.position - transform.position);
        }
    }
    
    public void SnapToContainer(LetterContainer container)
    {
        HasSnapPosition = true;
        DisableGravity();
        _snapContainer = container;
    }

    public void ReleaseSnap(LetterContainer container)
    {
        if (_snapContainer.Equals(container))
        {
            HasSnapPosition = false;
            EnableGravity();
        }
    }

    public void ReleaseAll()
    {
        HasSnapPosition = false;
        EnableGravity();
    }

    public void PickUp()
    {
        transform.SetParent(_mouseController.transform);
        DisableGravity();
        IsInHand = true;
    }

    public void Drop()
    {
        transform.SetParent(null);
        IsInHand = false;
        if (!HasSnapPosition)
        {
            EnableGravity();
        }
    }

    private void EnableGravity()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.gravityScale = 3;
    }

    public void DisableGravity()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.gravityScale = 0;
    }
}
