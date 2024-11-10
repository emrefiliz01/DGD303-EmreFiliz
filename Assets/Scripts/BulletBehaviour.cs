using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    void Start()
    {

    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * bulletSpeed;

    }

    public void SetPosition(Vector3 bulletSpawnPoint)
    {
        transform.position = bulletSpawnPoint;
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

