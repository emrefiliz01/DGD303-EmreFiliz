using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    private bool isBossLevel = false;

    void Update()
    {
        if (!isBossLevel)
        {
            transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
        }
    }

    public void SetBossLevel(bool isBoss)
    {
        isBossLevel = isBoss;

        if (isBossLevel)
        {
            scrollSpeed = 0f;
        }
        else
        {
            scrollSpeed = 2f;
        }
    }
}
