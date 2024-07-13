using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    private Transform _transform;
    private MagazineCartridges _magazineCartridges;

    private void Awake()
    {
        _transform = transform;
        _magazineCartridges = GetComponent<MagazineCartridges>();
    }

    public void Shoot()
    {
        if (_magazineCartridges.TryGetCartridge() == true)
            Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity, _transform).Init(_transform.right, _damage);
        else
            print("Нет патронов");
    }
}
