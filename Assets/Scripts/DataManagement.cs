using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManagement : MonoBehaviour
{
    public static DataManagement instance;
    public string playerName;
    public string bestPlayer;
    public int highScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        highScore = 0;
        bestPlayer = "";
        LoadData();
    }

    [System.Serializable]

    public class SavedData
    {
        public string bestPlayer;
        public int highScore;
    }

    public void SaveData()
    {
        SavedData data = new SavedData();
        data.bestPlayer = bestPlayer;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);

            bestPlayer = data.bestPlayer;
            highScore = data.highScore;
        }
    }
}
