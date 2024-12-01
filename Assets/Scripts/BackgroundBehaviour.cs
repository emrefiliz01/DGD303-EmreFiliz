using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;

    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
    }
}
