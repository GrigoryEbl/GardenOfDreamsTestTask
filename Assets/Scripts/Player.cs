using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _hand;
    [SerializeField] private Detector _detector;

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
        if(_target != null)
        Aiming(_target);

        if (Input.GetKeyUp(KeyCode.Space)) //////////////////////////////////////////////////
            Shoot();
    }

    private void Shoot()
    {
        _weapon.Shoot();
    }

    private void SetTarget(Transform target)
    {
        _target = target;

        if(_target == null)
            _hand.transform.rotation = _basePositionHande;
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out Enemy enemy))
    //    {
    //        _target = null;
    //        _hand.transform.rotation = _basePositionHande;
    //    }
    //}

    private void Aiming(Transform target)
    {
        _hand.transform.up = target.position * -1 + _hand.transform.position;
    }
}
