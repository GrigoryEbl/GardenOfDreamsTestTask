using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _bulletPrefab;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, _transform.right);

        if (hit.collider.TryGetComponent(out Enemy enemy) && enemy.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            Debug.Log("Hit " + hit.collider.gameObject);
        }
    }
}
