using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller _instance;

    public TMP_Text txt_PopUp;
    public Transform player;
    public GameObject popUp;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
   
    public void NewGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
