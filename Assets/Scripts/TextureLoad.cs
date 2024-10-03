using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextureLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string filepath = Path.Combine(Application.streamingAssetsPath, "Aang.png");

        if (File.Exists(filepath))
        {
            byte[] imageData = File.ReadAllBytes(filepath);

            #region Texture
            Texture2D newTexture = new Texture2D(2, 2);
            newTexture.LoadImage(imageData);

            GetComponent<Renderer>().material.mainTexture = newTexture;
            #endregion
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
