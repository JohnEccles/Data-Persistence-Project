using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    // Player Data
    public string playerName = "Name";
    public int playerScore = 0;

    // For data from previous session(s) of game
    public string highName;
    public int highScore;

    private void Awake()
    {
        // If object already exists destroy itself and exit Awake()
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }


     
     // Save & Load Data between sessions
    [System.Serializable] // Makes the class Serializable and allows use to save as JSON
    class SaveData
    {
        public string playerName;
        public int playerScore;
    }


    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.playerScore = playerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highName = data.playerName;
            highScore = data.playerScore;
        }
    }


     

}
