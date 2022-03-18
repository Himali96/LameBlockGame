using UnityEngine;

public class KeyCount : MonoBehaviour
{
    public AudioSource keySound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UI_Counter._instance.Key();
            Destroy(transform.gameObject);
            Instantiate(UI_Counter._instance.keyParticle, transform.position, Quaternion.identity);
            keySound.Play();
        }
    }
}
