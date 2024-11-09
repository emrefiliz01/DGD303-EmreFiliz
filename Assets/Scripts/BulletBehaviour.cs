using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
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
}

