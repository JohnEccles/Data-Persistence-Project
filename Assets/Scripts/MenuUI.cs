using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{


    public Text HighScoreText;


    private void Start()    
    {
        GameManager.Instance.LoadScore();
        HighScoreText.text = $"High Score : " + GameManager.Instance.highName + " : " + GameManager.Instance.highScore;

    }

    // Added from tutorial
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    // Added from tutorial
    public void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                        Application.Quit(); // original code to quit Unity player
        #endif

    }

    public void GetPlayerName(string input) 
    {
        GameManager.Instance.playerName = input;

        //print("User input is: " + input);
    }


}
