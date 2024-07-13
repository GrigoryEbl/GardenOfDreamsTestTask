using System;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class Detector : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _enemyLayer;

    private Transform _transform;
    private Timer _timer;
    private float _scanDelay = 1f;

    public Action<Transform> EnemyFinded;

    private void Awake()
    {
        _transform = transform;
        _timer = GetComponent<Timer>();
        _timer.StartWork(_scanDelay);
    }

    private void OnEnable()
    {
        _timer.TimeEmpty += FindEnemy;
    }

    private void OnDisable()
    {
        _timer.TimeEmpty -= FindEnemy;
    }

    private void FindEnemy()
    {
        Collider2D collider = Physics2D.OverlapCircle(_transform.position, _radius, _enemyLayer);

        if (collider != null)
            EnemyFinded?.Invoke(collider.transform);
        else
            EnemyFinded?.Invoke(null);

        _timer.StartWork(_scanDelay);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
