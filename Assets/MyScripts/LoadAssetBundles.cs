using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    string folderPath = "AssetBundles";
    string fileName = "enemies";
    string combinedPath;
    private AssetBundle enemiesBundle;


    // Start is called before the first frame update
    void Start()
    {
        LoadAssetBundle();
        LoadChomperEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadChomperEnemy()
    {
        if (enemiesBundle == null)
        {
            return;
        }

        GameObject enemyPrefab = enemiesBundle.LoadAsset<GameObject>("Spitter");
        if(enemyPrefab == null)
        {
            Instantiate(enemyPrefab);
        }
        else
        {
            Debug.Log("No Enemy Loaded");
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
