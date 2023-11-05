using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Letter : MonoBehaviour
{
    public bool HasSnapPosition;
    public bool IsInHand;
    private Vector3 _snapPosition;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (HasSnapPosition)
        {
            _rigidbody.velocity = (_snapPosition - transform.position) * 3;
            if (_rigidbody.velocity.magnitude < math.EPSILON)
            {
                HasSnapPosition = false;
            }
        }

        if (IsInHand)
        {
            transform.localPosition = Vector3.zero;
        }
    }
    
    public void SnapToContainer(Vector3 position)
    {
        HasSnapPosition = true;
        DisableGravity();
        _snapPosition = position;
    }

    public void ReleaseSnap()
    {
        HasSnapPosition = false;
        EnableGravity();
    }

    public void EnableGravity()
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
