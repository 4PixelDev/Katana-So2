using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject[] projectilePrefabs; // Array of projectile prefabs
    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireRate = 2f;
    private float lastShotTime = 0f;

    private void Start()
    {
        lastShotTime = Time.time;

    }

    private void Update()
    {
        if (Time.time - lastShotTime >= fireRate)
        {
            ShootRandomProjectile();
            lastShotTime = Time.time;
        }
    }

    private void ShootRandomProjectile()
    {
        // Choose a random projectile from the array
        int randomIndex = Random.Range(0, projectilePrefabs.Length);
        GameObject selectedPrefab = projectilePrefabs[randomIndex];

        Instantiate(selectedPrefab, firePoint.position, Quaternion.identity);
    }
}
