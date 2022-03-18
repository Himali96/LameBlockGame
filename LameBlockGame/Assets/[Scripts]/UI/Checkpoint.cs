using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpointText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkpointText.SetActive(true);
            transform.GetComponent<BoxCollider2D>().enabled = false;
            UI_Counter._instance.respawnPosition = transform.position;
        }
    }
}
