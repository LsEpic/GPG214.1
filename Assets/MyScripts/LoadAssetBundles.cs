using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    string folderPath = "AssetBundles";
    string fileName = "hazards";
    string combinedPath;
    private AssetBundle hazardBundle;


    // Start is called before the first frame update
    void Start()
    {
        LoadAssetBundle();
        LoadSpikeHazard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadSpikeHazard()
    {
        if (hazardBundle == null)
        {
            return;
        }

        GameObject hazardPrefab = hazardBundle.LoadAsset<GameObject>("Spikes");
        if(hazardPrefab != null)
        {
            Instantiate(hazardPrefab);
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
            hazardBundle = AssetBundle.LoadFromFile(combinedPath);
            Debug.Log("Asset Bundle Loaded");
        }
        else
        {
            Debug.Log("File does not exist " + combinedPath);
        }
    }
}
