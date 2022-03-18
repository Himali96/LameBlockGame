using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpikes : MonoBehaviour
{
    public Transform player;
    public float count;

    private void Update()
    {
        if (Mathf.Abs(transform.localPosition.x - player.localPosition.x) < 10)
        {
            if (transform.localPosition.y < -5.2f)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + count);
            }
        }
        else 
        {
            if (transform.localPosition.y > -6f)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - count);
            }
        }
    }
}
