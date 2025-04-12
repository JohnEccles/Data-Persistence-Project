using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
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
