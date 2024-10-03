using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class JSONFiles : MonoBehaviour
{
    public PlayerPosition position = new PlayerPosition();
    public string playerJsonFileName = "Player.json";
    public string folderPath = Application.streamingAssetsPath;
    private string fullFilePath = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        fullFilePath = Path.Combine(folderPath, playerJsonFileName);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            SaveJSON();
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            LoadJSON();
        }
    }

    void SaveJSON()
    {
        position.SetPlayerPosition(transform.position);

        string jsonData = JsonUtility.ToJson(position);

        File.WriteAllText(fullFilePath, jsonData);
    }

    void LoadJSON()
    {
        if(File.Exists(fullFilePath))
        {
            string jsonData = File.ReadAllText(fullFilePath);

            position = JsonUtility.FromJson<PlayerPosition>(jsonData);

            if(position != null )
            {
                Debug.Log("Player Save position was: " + position.ReturnPlayerPosition());
                transform.position = position.ReturnPlayerPosition();
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
