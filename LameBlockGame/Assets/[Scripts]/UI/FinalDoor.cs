using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalDoor : MonoBehaviour
{  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UI_Controller._instance.popUp.SetActive(true);
            PlayerBehaviour._instance.isGameOver = true;
            //other.transform.GetComponent<Animator>().speed = 0;

            if (UI_Counter._instance.keyValue == 1)
            {
                UI_Controller._instance.txt_PopUp.text = "You Win...\nScore = " + (UI_Counter._instance.coinCount * UI_Counter._instance.diamondValue).ToString();
            } else
            {
                if(UI_Counter._instance.lifesLeft != 0)
                {
                    UI_Controller._instance.txt_PopUp.text = "Oops! You forgot to collect a key...";
                } else
                {
                    UI_Controller._instance.txt_PopUp.text = "You Lose:( \nTry Again...";
                }
            }
        }
    }
}
