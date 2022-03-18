using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    public Sprite break0, break1, break2;
    public List<SpriteRenderer> platformTiles;

    private float timer;
    private bool isPlayerTouched, isBreakedLittle, isFullyBreaked;

    private void Update()
    {
        if (isPlayerTouched)
        {
            if (timer < 6)
            {
                timer += 0.005f;
                if (timer > 4 && !isBreakedLittle)
                {
                    for (int i = 0; i < platformTiles.Count; i++)
                    {
                        platformTiles[i].sprite = break1;
                    }
                    isBreakedLittle = true;
                }
                else if (timer > 2 && !isFullyBreaked)
                {
                    for (int i = 0; i < platformTiles.Count; i++)
                    {
                        platformTiles[i].sprite = break2;
                    }
                    isFullyBreaked = true;
                }
            }
            if (timer >= 6)
            {
                gameObject.SetActive(false);
                ResetValues();
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

    public void ResetValues ()
    {
        timer = 0;
        for (int i = 0; i < platformTiles.Count; i++)
        {
            platformTiles[i].sprite = break0;
        }
        isPlayerTouched = false; 
        isBreakedLittle = false; 
        isFullyBreaked = false;
    }
}
