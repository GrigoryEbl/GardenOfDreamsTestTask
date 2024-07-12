using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _hand;

    private Quaternion _basePositionHande;

    private void Awake()
    {
        _basePositionHande = _hand.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            Shoot();
    }

    private void Shoot()
    {
        _weapon.Shoot();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            Aiming(enemy.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _hand.transform.rotation = _basePositionHande;
        }
    }

    private void Aiming(Transform enemy)
    {
        _hand.transform.up = enemy.position * -1 + _hand.transform.position;
    }
}
