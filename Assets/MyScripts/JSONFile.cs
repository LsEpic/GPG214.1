using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class JSONFile : MonoBehaviour
{
    public PlayerStats playerStats = new PlayerStats();
    public string playerJsonFileName = "PlayerStats.json";
    public string folderPath;
    private string fullFilePath;

    // Start is called before the first frame update
    void Start()
    {
        folderPath = Application.streamingAssetsPath;
        fullFilePath = Path.Combine(folderPath, playerJsonFileName);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.B))
        {
            SaveJSON();
        }
       
        if (Input.GetKeyUp(KeyCode.N))
        {
            LoadJSON();
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            playerStats.AddShotsFired();
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerStats.ResetStats(); 
        }
        
    }

    void SaveJSON()
    {
        playerStats.SetPlayerPosition(transform.position);

        string jsonData = JsonUtility.ToJson(playerStats);

        File.WriteAllText(fullFilePath, jsonData);
    }

    void LoadJSON()
    {
        if(File.Exists(fullFilePath))
        {
            string jsonData = File.ReadAllText(fullFilePath);

            playerStats = JsonUtility.FromJson<PlayerStats>(jsonData);

            if(playerStats != null )
            {
                Debug.Log("Player Save position was: " + playerStats.ReturnPlayerPosition());
                Debug.Log("Distance Traveled: " + playerStats.distanceTravelled);
                Debug.Log("Shots Fired: " + playerStats.shotsFired);
                
                transform.position = playerStats.ReturnPlayerPosition();

            }
            else
            {
                Debug.LogError("Json Found, cant convert to class");
            }
        }
        else
        {
            Debug.LogError("No Player Found");
        }
    }
}
