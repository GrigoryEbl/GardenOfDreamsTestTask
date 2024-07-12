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

    public void Move(Vector2 direction)
    {
        _transform.Translate(direction * _speed);
        IsMoving = true;
    }

    public void Stop()
    {
        IsMoving = false;
    }
}
