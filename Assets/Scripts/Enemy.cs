using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Timer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;

    private EnemyMover _mover;
    private Transform _target;
    private Timer _timer;
    private float _attackDelay = 1;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _timer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
        _mover.TargetReached += Attack;
        _timer.TimeEmpty += Strike;
    }

    private void OnDisable()
    {
        _mover.TargetReached -= Attack;
        _timer.TimeEmpty -= Strike;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _target = player.transform;
            _mover.SetTarget(_target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _target = null;
            _mover.SetTarget(_target);
        }
    }

    private void Attack()
    {
        _timer.StartWork(_attackDelay);
    }

    private void Strike()
    {
        if (Vector2.Distance(transform.position, _target.position) <= _attackDistance && _target.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(_damage);
    }
}
