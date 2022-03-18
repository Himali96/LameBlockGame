using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPlatform : MonoBehaviour
{
    public Sprite bounce1, bounce2, bounce3;
    public SpriteRenderer bouncingTile;

    private float timer;
    private bool isPlayerTouched, isBouncedLittle, isBouncedFully;

    private void Update()
    {
        if (isPlayerTouched)
        {
            if (timer < 6)
            {
                timer += 0.02f;
                if (timer > 4 && !isBouncedLittle)
                {
                    bouncingTile.sprite = bounce1;
                    isBouncedLittle = true;
                }
                else if (timer > 2 && !isBouncedFully)
                {
                    bouncingTile.sprite = bounce2;
                    isBouncedFully = true;
                }
            }
            if (timer >= 6) {
                timer = 0; 
                bouncingTile.sprite = bounce3;
                isBouncedLittle = false;
                isBouncedFully = false;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isPlayerTouched = true;
        }
    }
}
