using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;

    private Vector3 direction;
    void Start()
    {

    }

    void Update()
    {
        if (direction != null)
        {
            transform.position += direction * Time.deltaTime * bulletSpeed;
        }
    }

    public void SetPosition(Vector3 bulletSpawnPoint)
    {
        transform.position = bulletSpawnPoint;
    }

    public void SetDirection(Vector3 directionMove)
    {
        direction = directionMove;
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

        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(bulletDamage);

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BulletDestroyer")
        {
            Destroy(gameObject);
        }
    }

    
}

