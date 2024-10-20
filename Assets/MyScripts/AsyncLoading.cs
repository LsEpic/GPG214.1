using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;

public class AsyncLoading : MonoBehaviour
{
    public Sprite spriteImage;

    public string imageFileName;

    public string streamingAssetsFolderPath = Application.streamingAssetsPath;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return StartCoroutine(LoadTextureFromFile());
    }

    private void Update()
    {
        
    }

    IEnumerator LoadTextureFromFile()
    {
        UnityWebRequest imageRequest = UnityWebRequest.Get(Path.Combine(streamingAssetsFolderPath, imageFileName));

        AsyncOperation downloadOperation = imageRequest.SendWebRequest();

        while (!downloadOperation.isDone)
        {
            Debug.Log("download progress " + ((downloadOperation.progress / 1f) * 100) + "%");
            yield return null;
        }
        if (imageRequest.result == UnityWebRequest.Result.ConnectionError || imageRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("error with downloading file");
            yield break;
        }

        Debug.Log("Download Complete");

        byte[] allDataDownloaded = imageRequest.downloadHandler.data;
        
        Texture2D myTexture = new Texture2D(2, 2);

        myTexture.LoadImage(allDataDownloaded);

        spriteImage = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));

        imageRequest.Dispose();

        yield return null;
    }
}
