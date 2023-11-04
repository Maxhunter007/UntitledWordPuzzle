using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Letter : MonoBehaviour
{
    [FormerlySerializedAs("_hasSnapPosition")] public bool HasSnapPosition;
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
    }
    
    public void SnapToContainer(Vector3 position)
    {
        HasSnapPosition = true;
        _rigidbody.gravityScale = 0;
        _snapPosition = position;
    }

    public void ReleaseSnap()
    {
        HasSnapPosition = false;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.gravityScale = 3;
    }
}
