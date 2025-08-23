using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string playerName = "";
    public string bestPlayerName = "";
    public int highScore = 0;
    public static DataManager Instance;
    string path;

    private void Start()
    {
        LoadData();
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        path = Application.persistentDataPath + "/savedata.json";
    }

    [System.Serializable]
    class DataToSave
    {
        public string bestPlayerName;
        public int highScore;
    }

    public void SaveData()
    {
        DataToSave data = new DataToSave();
        data.bestPlayerName = bestPlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public void LoadData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataToSave data = JsonUtility.FromJson<DataToSave>(json);

            bestPlayerName = data.bestPlayerName;
            highScore = data.highScore;
        }
        else
        {
            bestPlayerName = "unknown";
        }
    }


}
