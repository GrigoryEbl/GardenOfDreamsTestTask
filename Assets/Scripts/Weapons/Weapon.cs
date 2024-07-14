using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _ammoCount;

    private Transform _transform;

    public Action AmmoSpended;

    public int AmmoCount => _ammoCount; 

    private void Awake()
    {
        _transform = transform;
    }

    public void Shoot()
    {
        if (TryGetAmmo() == true)
        {
            Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity, _transform).Init(_transform.right, _damage);
        }

        print("Нет патронов");
    }

    public void AddAmmo(int value)
    {
        _ammoCount += value;
    }

    public bool TryGetAmmo()
    {
        if (_ammoCount > 0)
        {
            _ammoCount -= 1;
            return true;
        }

        AmmoSpended?.Invoke();

        return false;
    }
}
