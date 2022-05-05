using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    //load data
    public string topPlayerName;
    public int topScore;

    //new data
    public string playerName;
    public int playerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int topScore;
    }

    public void SaveScore()
    {
        
        SaveData data = new SaveData();
        data.playerName = topPlayerName;
        data.topScore = topScore;

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

            topPlayerName = data.playerName;
            topScore = data.topScore;
        }
        else
        {
            topPlayerName = "none";
            topScore = 0;
        }
    }

    public void UpdateTopScore()
    {
        if (topScore < playerScore)
        {
            topScore = playerScore;
            topPlayerName = playerName;
        }
    }
}
