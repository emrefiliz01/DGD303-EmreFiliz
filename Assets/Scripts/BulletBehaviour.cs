using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private int bulletDamage;

    private Vector3 direction;

    void Start()
    {
        UpdateBulletDamage();
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime * bulletSpeed;
    }

    public void SetPosition(Vector3 bulletSpawnPoint)
    {
        transform.position = bulletSpawnPoint;
    }

    public void SetDirection(Vector3 directionMove)
    {
        direction = directionMove;
    }

    public void UpdateBulletDamage()
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats != null)
        {
            bulletDamage = playerStats.damage;
            Debug.Log("Bullet Damage Set to: " + bulletDamage);
        }
        else
        {
            Debug.LogWarning("PlayerStats not found! Using default damage.");
            bulletDamage = 20;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = collision.GetComponent<EnemyBehaviour>();

            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(bulletDamage);
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("BulletDestroyer"))
        {
            Destroy(gameObject);
        }
    }
}
