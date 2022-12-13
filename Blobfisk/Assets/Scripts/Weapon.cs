using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField] int bulletsLeft = 30;
    public KeyCode shootKey = KeyCode.None;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (bulletsLeft >= 0)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletsLeft--;
    }

}
