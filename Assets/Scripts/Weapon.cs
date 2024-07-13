using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Shoot()
    {
        Instantiate(_bulletPrefab, _shootPoint.position,Quaternion.identity, _transform).Init(_transform.right, _damage);
    }
}
