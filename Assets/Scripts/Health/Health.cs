using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _value;

    public Action<int> HealthChange;
    public Action Died;

    private void Start()
    {
        HealthChange?.Invoke(_value);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            return;

        _value -= damage;

        if (_value <= 0)
        {
            _value = 0;
            Die();
        }

        HealthChange?.Invoke(_value);

        print(name + "Take damage: " + damage);
    }

    public virtual void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}
