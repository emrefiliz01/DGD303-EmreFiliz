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
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyBehaviour>().Test(bulletDamage);

            

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BulletDestroyer")
        {
            Destroy(gameObject);
        }
    }

    
}

