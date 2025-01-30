using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private AudioClip coinCollectSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            coinManager.AddCoin(1);

            if (audioSource != null && coinCollectSound != null)
            {
                audioSource.PlayOneShot(coinCollectSound);
            }

            Destroy(collision.gameObject);
        }
    }
}
