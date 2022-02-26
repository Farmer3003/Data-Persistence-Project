using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data : MonoBehaviour
{
    public static Data Instance;
    public int point;
    public string playerName;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPoint();
        LoadName();
    }
    
    
    class SaveData
    {
        public int point;
        public string playerName;
    }
    public void SavePoint()
    {
        SaveData data = new SaveData();
        data.point = point;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savepoint.json", json);
    }
    
    public void SaveplayerName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savename.json", json);
    }
    public void LoadPoint()
    {
        string path = Application.persistentDataPath + "/savepoint.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            point = data.point;
        }
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savename.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
        }
    }
}

