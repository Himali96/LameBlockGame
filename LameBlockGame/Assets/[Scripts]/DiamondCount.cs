using UnityEngine;

public class DiamondCount : MonoBehaviour
{
    public AudioSource diamondSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UI_Counter._instance.Diamond();
            Destroy(transform.gameObject);
            diamondSound.Play();
            Instantiate(UI_Counter._instance.diamondParticle, transform.position, Quaternion.identity);
        }
    }
}
