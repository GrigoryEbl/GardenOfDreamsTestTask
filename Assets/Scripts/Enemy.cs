using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyMover _mover;
    private Transform _target;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
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
}
