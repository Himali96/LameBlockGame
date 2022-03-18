using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public AudioSource coinCollectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UI_Counter._instance.Coin();
            Destroy(transform.gameObject);
            coinCollectSound.Play();
        }
    }
}
