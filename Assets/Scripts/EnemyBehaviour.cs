using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Image fillImage;
    [SerializeField] private GameObject spaceCoinPrefab;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject backgroundParent;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        fillImage.fillAmount = 1f;
    }

    public void TakeDamage(int bulletDamage)
    {

        currentHealth = currentHealth - bulletDamage;

        fillImage.fillAmount = currentHealth / maxHealth;


        if (currentHealth <= 0f)
        {
            if (deathEffect != null)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
            }

            CreateSpaceCoins();

            Destroy(gameObject);
        }
    }
    private void CreateSpaceCoins()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f);

            GameObject coin = Instantiate(spaceCoinPrefab, randomPosition, Quaternion.identity, backgroundParent.transform);

            float scaleX = coin.transform.localScale.x / backgroundParent.transform.localScale.x;
            float scaleY = coin.transform.localScale.y / backgroundParent.transform.localScale.y;

            Vector3 targetScale = new Vector3(scaleX, scaleY, 1);
            coin.transform.localScale = targetScale;

           // coin.transform.localScale = new Vector3(coin.transform.localScale.x / backgroundParent.transform.localScale.x, coin.transform.localScale.y / backgroundParent.transform.localScale.y, 1);

            coin.transform.position = new Vector3(coin.transform.position.x, coin.transform.position.y, 0f);
        }
    }
}
