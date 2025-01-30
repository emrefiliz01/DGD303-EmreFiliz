using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletContainer;
    [SerializeField] private List<Transform> bulletSpawnPoints;
    [SerializeField] private float bulletDelay = 0.5f;
    [SerializeField] private float range;
    [SerializeField] private Transform player;

    private bool canShoot = true;

    void Start()
    {
        if (bulletSpawnPoints.Count != 5)
        {
            Debug.LogError("Please assign 5 bullet spawn points to the BossShooter.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= range && canShoot)
            {
                StartCoroutine(FireBulletsCoroutine());
            }
        }
    }

    private IEnumerator FireBulletsCoroutine()
    {
        canShoot = false;

        foreach (Transform spawnPoint in bulletSpawnPoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletContainer.transform);
            BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
            bulletBehaviour.SetPosition(spawnPoint.position);
            bulletBehaviour.SetDirection(Vector3.down);

            yield return new WaitForSeconds(bulletDelay);
        }

        canShoot = true;

        yield return null;
    }
}
