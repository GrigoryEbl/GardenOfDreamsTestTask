using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Timer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private Detector _detector;
    [SerializeField] private Item[] _dropItems;

    private Health _health;
    private EnemyMover _mover;
    private Transform _target;
    private Timer _attackTimer;
    private float _attackDelay = 1;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _attackTimer = GetComponent<Timer>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _mover.TargetReached += Attack;
        _attackTimer.TimeEmpty += Strike;
        _detector.EnemyFinded += SetTarget;
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _mover.TargetReached -= Attack;
        _attackTimer.TimeEmpty -= Strike;
        _detector.EnemyFinded -= SetTarget;
    }

    private void OnDied()
    {
        Instantiate(_dropItems[Random.Range(0, _dropItems.Length)], transform.position, Quaternion.identity, null);
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
