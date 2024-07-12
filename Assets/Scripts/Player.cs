using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            Shoot();
    }

    private void Shoot()
    {
        _weapon.Shoot();
    }
}
