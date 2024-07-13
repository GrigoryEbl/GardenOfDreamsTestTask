using UnityEngine;

public class EnemyMover :  AbstarctMover
{
    //[SerializeField] private float _speed;
    [SerializeField] private float _minContactDistance;

    private Transform _transform;
    private Transform _target;

    //public event UnityAction TargetReached;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (_target != null)
        {
            Move();

            if (Vector2.Distance(_transform.position, _target.position) <= _minContactDistance)
            {
                // TargetReached?.Invoke();
            }
        }
    }

    public override void Move()
    {
        _transform.position = Vector2.MoveTowards(_transform.position, _target.position, _speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _target = target;       
    }
}