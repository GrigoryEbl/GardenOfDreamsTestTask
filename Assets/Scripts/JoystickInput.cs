using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Joystick _joystick;

    public event Action Moved;

    public bool Moving => _joystick.Direction != Vector2.zero;

    private void Update()
    {
        if (Moving == false)
        {
            _mover.Stop();
            return;
        }

        Vector2 direction = new Vector2(_joystick.Direction.x, _joystick.Direction.y).normalized;

        _mover.Move(direction);
        Moved?.Invoke();
    }

    private void OnDisable()
    {
        _mover?.Stop();
    }
}
