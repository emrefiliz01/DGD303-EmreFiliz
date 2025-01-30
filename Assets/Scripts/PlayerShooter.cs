using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletContainer;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private float bulletDelay;

    [SerializeField] private AudioClip laserSound;
    private AudioSource audioSource;

    private bool canShoot = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) && canShoot)
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
        bulletBehaviour.SetDirection(transform.up);

        if (audioSource != null && laserSound != null)
        {
            audioSource.PlayOneShot(laserSound);
        }

        yield return new WaitForSeconds(bulletDelay);

        canShoot = true;

        yield return null;
    }
}
