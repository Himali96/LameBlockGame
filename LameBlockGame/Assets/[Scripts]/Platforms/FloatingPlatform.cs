using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        if (transform.localPosition.y < player.position.y)
            transform.GetComponent<BoxCollider2D>().enabled = true;
        else    
            transform.GetComponent<BoxCollider2D>().enabled = false;
    }
}
