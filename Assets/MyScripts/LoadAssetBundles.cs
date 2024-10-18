using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    string folderPath = "AssetBundles";
    string fileName = "hazards";
    string combinedPath;
    private AssetBundle enemiesBundle;


    // Start is called before the first frame update
    void Start()
    {
        LoadAssetBundle();
        LoadHazard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadHazard()
    {
        if (enemiesBundle == null)
        {
            return;
        }

        GameObject enemyPrefab = enemiesBundle.LoadAsset<GameObject>("Acid");
        if(enemyPrefab == null)
        {
            Instantiate(enemyPrefab);
        }
        else
        {
            Debug.Log("No Hazard Loaded");
        }
    }

    void LoadAssetBundle()
    {
        combinedPath = Path.Combine(Application.streamingAssetsPath, folderPath, fileName);

        if (File.Exists(combinedPath))
        {
            enemiesBundle = AssetBundle.LoadFromFile(combinedPath);
            Debug.Log("Asset Bundle Loaded");
        }
        else
        {
            Debug.Log("File does not exist " + combinedPath);
        }
    }
}
