using System;
using UnityEngine;

public class EnemyMover : AbstarctMover
{
    [SerializeField] private float _minContactDistance;

    private Transform _transform;
    private Transform _target;

    public event Action TargetReached;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (_target != null)
        {
            if (Vector2.Distance(_transform.position, _target.position) <= _minContactDistance)
                TargetReached?.Invoke();
            else
                Move();
        }
    }

    public override void Move()
    {
        _transform.position = Vector2.MoveTowards(_transform.position, _target.position, _speed * Time.deltaTime);

        if (_transform.position.x - _target.position.x < 0)
            Flip(true);
        else if (_transform.position.x - _target.position.x > 0)
            Flip(false);

    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}