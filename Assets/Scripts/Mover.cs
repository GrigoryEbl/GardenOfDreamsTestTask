using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _transform;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _transform = transform;
    }

    public void Move(Vector3 direction)
    {
        _transform.LookAt(_transform.position + direction);

        IsMoving = true;
    }

    //public void Stop()
    //{
    //    if (_rigidbody != null)
    //        _rigidbody.velocity = Vector3.zero;

    //    IsMoving = false;
    //}
}
