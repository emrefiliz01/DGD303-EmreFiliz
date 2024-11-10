using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletContainer;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private float bulletDelay;

    private bool canShoot = true;

    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(FireBulletCoroutine());
        }
    }
    private IEnumerator FireBulletCoroutine()
    {
        canShoot = false;

        GameObject bullet = Instantiate(bulletPrefab, bulletContainer.transform);
        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.SetPosition(bulletSpawnPoint.transform.position);
        bulletBehaviour.SetDirection(transform.up * -1f);

        yield return new WaitForSeconds(bulletDelay);

        canShoot = true;

        yield return null;
    }
}
