using UnityEngine;
using System.Collections;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float playerSpeed;
    public float minPulpitDestroyTime;
    public float maxPulpitDestroyTime;
    public float pulpitSpawnTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("Instance is NULL");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Instance is NOT NULL");
            Destroy(gameObject);
        }

        LoadGameData();
    }

    void LoadGameData()
    {
        Debug.Log("Manager In");
        Debug.Log("JSON file path: " + Application.streamingAssetsPath + "/doofus_diary.json");
        string jsonPath = Application.streamingAssetsPath + "/doofus_diary.json";
        Debug.Log("JSON file path: " + jsonPath);

        if (File.Exists(jsonPath))
        {
            try
            {
                string jsonString = File.ReadAllText(jsonPath);
                GameData gameData = JsonUtility.FromJson<GameData>(jsonString);

                if (gameData != null)
                {
                    playerSpeed = gameData.player_data.speed;
                    minPulpitDestroyTime = gameData.pulpit_data.min_pulpit_destroy_time;
                    maxPulpitDestroyTime = gameData.pulpit_data.max_pulpit_destroy_time;
                    pulpitSpawnTime = gameData.pulpit_data.pulpit_spawn_time;
                }
                else
                {
                    Debug.LogError("Failed to parse JSON into GameData.");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error reading or parsing JSON file: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("JSON file not found at path: " + jsonPath);
        }
    }
}


[System.Serializable]
public class GameData
{
    public PlayerData player_data;
    public PulpitData pulpit_data;
}

[System.Serializable]
public class PlayerData
{
    public float speed;
}

[System.Serializable]
public class PulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}


