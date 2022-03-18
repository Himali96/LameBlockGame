using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float maxY;
    public float minY;

    [Header("Moving Direction")]
    public bool isX;
    public bool isY;

    bool movingForward = true;

    float elapsedTime, move;
    public float duration = 2f;

    public void Update()
    {
        elapsedTime += Time.deltaTime;
        if (movingForward)
        {
            move = Mathf.Lerp(maxY, minY, elapsedTime / duration);
            if (isX) 
                transform.localPosition = new Vector2(move, transform.localPosition.y);
            else
                transform.localPosition = new Vector2(transform.localPosition.x, move);

            if (elapsedTime >= duration)
            {
                elapsedTime = 0f;
                movingForward = false;
            }
        }
        else
        {
            move = Mathf.Lerp(minY, maxY, elapsedTime / duration);
            if (isX)
                transform.localPosition = new Vector2(move, transform.localPosition.y);
            else
                transform.localPosition = new Vector2(transform.localPosition.x, move);
            
            if (elapsedTime >= duration)
            {
                elapsedTime = 0f;
                movingForward = true;
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(this.transform);
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
