using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _value;

    public Action<int> HealthChange;

    private void Start()
    {
        HealthChange?.Invoke(_value);
    }

    public void TakeDamage(int damage)
    {
        _value -= damage;
        HealthChange?.Invoke(_value);

        print("Take damage: " + damage);
    }
}
