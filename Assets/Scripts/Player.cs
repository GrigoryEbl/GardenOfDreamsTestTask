using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _hand;
    [SerializeField] private Detector _detector;
    [SerializeField] private Inventory _inventory;

    private Quaternion _basePositionHande;
    private Transform _target;

    private void Awake()
    {
        _basePositionHande = _hand.transform.rotation;
    }

    private void OnEnable()
    {
        _detector.EnemyFinded += SetTarget;
    }

    private void OnDisable()
    {
        _detector.EnemyFinded -= SetTarget;
    }

    private void Update()
    {
        if (_target != null)
            Aiming(_target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            var addedItem = item;
            _inventory.Add(addedItem);

            item.gameObject.SetActive(false);
        }
    }

    public void Shoot()
    {
        if (_target != null)
        {
            if (_weapon.AmmoCount > 0)
            {
                _weapon.Shoot();
            }
            else
            {
                var items = _inventory.Items;

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Name == "Ammo")
                    {
                        int AddedAmmo = 7;

                        if (items[i].Count >= AddedAmmo)
                        {
                            _weapon.AddAmmo(AddedAmmo);
                            items[i].StackCount(items[i].Count - AddedAmmo);
                        }
                        else
                        {
                            _weapon.AddAmmo(items[i].Count);
                            Item item = items[i];
                            _inventory.Remove(ref item);
                        }
                    }
                }
            }

        }
        else
            print("Нет цели");
    }

    private void SetTarget(Transform target)
    {
        _target = target;

        if (_target == null)
            _hand.transform.rotation = _basePositionHande;
    }

    private void Aiming(Transform target)
    {
        _hand.transform.up = target.position * -1 + _hand.transform.position;
    }
}
