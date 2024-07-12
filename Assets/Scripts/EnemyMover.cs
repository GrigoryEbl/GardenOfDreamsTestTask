using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMover : Mover
{
    [SerializeField] private float _minContactDistance;

    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private Transform _target;

    public event UnityAction TargetReached;

    private void Awake()
    {
        _transform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (true)
        {
            _rigidbody2D.velocity = _target.position * _speed;

            if (Vector2.Distance(_transform.position, _target.position) <= _minContactDistance)
            {
                TargetReached?.Invoke();
                Stop();
                StopCoroutine(MoveToTarget() );
                break;
            }

            yield return null;
        }
    }
}