using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Timer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private Detector _detector;

    private EnemyMover _mover;
    private Transform _target;
    private Timer _attackTimer;
    private float _attackDelay = 1;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _attackTimer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
        _mover.TargetReached += Attack;
        _attackTimer.TimeEmpty += Strike;
        _detector.EnemyFinded += SetTarget;
    }

    private void OnDisable()
    {
        _mover.TargetReached -= Attack;
        _attackTimer.TimeEmpty -= Strike;
        _detector.EnemyFinded -= SetTarget;
    }

    private void SetTarget(Transform target)
    {
        _target = target;
        _mover.SetTarget(_target);
    }

    private void Attack()
    {
        _attackTimer.StartWork(_attackDelay);
    }

    private void Strike()
    {
        if (Vector2.Distance(transform.position, _target.position) <= _attackDistance && _target.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(_damage);
    }
}
