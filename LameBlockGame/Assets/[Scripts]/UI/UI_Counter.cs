using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class UI_Counter : MonoBehaviour
{
    public static UI_Counter _instance;
    public int coinCount, diamondValue, keyValue, lifesLeft = 3, score;
    public TMP_Text txt_CoinCount, txt_DiamondCount;
    public List<RawImage> lifeSprites;
    public Texture life, death;
    public Vector2 respawnPosition;
    public bool isDead, isLifeOver;
    public AudioSource deathSound;
    public GameObject diamondParticle, keyParticle, keySprite;
    public List<GameObject> collapsingPlatforms, tiltingPlatforms;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void Coin ()
    {
        coinCount++;
        if (coinCount == 50 || coinCount == 100 || coinCount == 150) GainLife();
        txt_CoinCount.text = "x " + coinCount.ToString();
    }

    void GainLife ()
    {
        if(lifesLeft < 5)
        {
            lifeSprites[lifesLeft].texture = life;
            lifesLeft++;
        }
    }

    public void Diamond()
    {
        diamondValue++;
        txt_DiamondCount.text = diamondValue.ToString();
    }

    public void Key()
    {
        keyValue++;
        keySprite.SetActive(true);
    }

    public void LifeCounter (GameObject player)
    {
        lifesLeft--;
        for (int i = 0; i < collapsingPlatforms.Count; i++)
        {
            collapsingPlatforms[i].GetComponent<CollapsingPlatform>().ResetValues();
            collapsingPlatforms[i].SetActive(true);
        }
        for (int i = 0; i < tiltingPlatforms.Count; i++)
        {
            tiltingPlatforms[i].transform.localEulerAngles = Vector3.zero;
        }

        if (lifesLeft < 1)
        {
            UI_Controller._instance.popUp.SetActive(true);
            //PlayerBehaviour._instance.isGameOver = true;
            isLifeOver = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        lifeSprites[lifesLeft].texture = death;
        deathSound.Play();
    }
}
