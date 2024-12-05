using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletContainer;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private float bulletDelay;
    [SerializeField] private float range;
    [SerializeField] private Transform player;

    private bool canShoot = true;

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= range && canShoot)
            {
                StartCoroutine(FireBulletCoroutine());
            }
        }
    }
    private IEnumerator FireBulletCoroutine()
    {
        canShoot = false;

        GameObject bullet = Instantiate(bulletPrefab, bulletContainer.transform);
        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.SetPosition(bulletSpawnPoint.transform.position);
        bulletBehaviour.SetDirection(Vector3.down);

        yield return new WaitForSeconds(bulletDelay);

        canShoot = true;

        yield return null;
    }
}
