using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _transform;
    private Rigidbody2D _rigidbody2D;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    public void Move(Vector2 direction)
    {
        _rigidbody2D.velocity = direction * _speed;

        Flip();

        IsMoving = true;
    }

    public void Stop()
    {
        if (_rigidbody2D != null)
            _rigidbody2D.velocity = Vector3.zero;

        IsMoving = false;
    }

    private void Flip()
    {
        if (_rigidbody2D.velocity.x < 0)
        {
            _transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_rigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
