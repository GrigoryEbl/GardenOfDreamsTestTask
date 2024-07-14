using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private int _damage;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 direction, int damage)
    {
        _rigidbody2D.velocity = direction * _speed;
        transform.right = direction;
        
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

}
