using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletContainer;
    [SerializeField] private GameObject bulletSpawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletContainer.transform);
        bullet.GetComponent<BulletBehaviour>().SetPosition(bulletSpawnPoint.transform.position);


    }
}
