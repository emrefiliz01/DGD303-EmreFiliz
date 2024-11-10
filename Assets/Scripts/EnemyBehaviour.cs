using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Image fillImage;
    [SerializeField] private GameObject spaceCoinPrefab;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        fillImage.fillAmount = 1f;
    }

    public void Test(int bulletDamage)
    {

        currentHealth = currentHealth - bulletDamage;

        fillImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0f)
        {
            GameObject collectible = Instantiate(spaceCoinPrefab);
            collectible.transform.position = gameObject.transform.position;


            Destroy(gameObject);
        }
    }
}
