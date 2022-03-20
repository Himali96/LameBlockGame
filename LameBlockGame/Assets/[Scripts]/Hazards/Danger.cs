using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !UI_Counter._instance.isDead)
        {
            UI_Counter._instance.LifeCounter(other.gameObject);
            PlayerBehaviour._instance.isGameOver = true;
            if (UI_Counter._instance.isLifeOver)
            {
                Debug.Log("Dead!");
                other.transform.position = Vector2.zero;
            }
            else
            {
                other.transform.position = UI_Counter._instance.respawnPosition;
            }
            UI_Controller._instance.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}