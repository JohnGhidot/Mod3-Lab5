using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRange;
    [SerializeField] private Transform firePoint;
    [SerializeField] Bullet _bulletPrefab;
    private float fireTime = 0.25f;


    void Start()
    {
        
    }

    private void Shoot()
    {
        Bullet b = Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private Transform FindNearestEnemy(GameObject[] enemies)
    {
        Transform nearestEnemy = null;
        float distance = 0;
        Vector2 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue;
            float distance2 = Vector2.Distance(currentPosition, enemy.transform.position);
            if (distance < distance2)
        }
    }



    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= fireTime)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Transform nearestEnemy = FindNearestEnemy(enemies);

            if (nearestEnemy != null)
            {
                Vector2 dir = (nearestEnemy.position - firePoint.position).normalized;
                firePoint.right = dir;

                Shoot();
                fireTime = Time.time + fireRate;
            }           
        }
    }



}
