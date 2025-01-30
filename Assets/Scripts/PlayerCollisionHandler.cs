using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            coinManager.AddCoin(1);
            Destroy(collision.gameObject);
        }
    }
}
