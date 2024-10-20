using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KeySpriteLoader : MonoBehaviour
{
    public AsyncLoading AsyncLoading;
    public string fileName = "RetroKey.png";
    public string folderPath = Application.streamingAssetsPath;
    private string combinedFilePathLocation;

    public Sprite keySprite;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // coimbine the path
        combinedFilePathLocation = Path.Combine(folderPath, fileName);
    }

    private void Update()
    {
        //loads new key sprite on input
        if(Input.GetKeyDown(KeyCode.V))
        {
            LoadSprite();
        }
    }

    private void LoadSprite()
    {
        if (Directory.Exists(folderPath))
        {
            if (File.Exists(combinedFilePathLocation))
            {
                //reads in all bytes of data (1s and 0s)
                byte[] spriteBytes = File.ReadAllBytes(combinedFilePathLocation);

                //creates temporary to load new texture into
                Texture2D texture = new Texture2D(2, 2);
                //converts bytes to image
                texture.LoadImage(spriteBytes);

                keySprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

                if (spriteRenderer != null)
                {
                    spriteRenderer.sprite = keySprite;
                }
                else
                {
                    Debug.Log("No Sprite Renderer!");
                }
            }
            else
            {
                Debug.Log("Texture File not found at " + combinedFilePathLocation);
            }
        }
        else
        {
            Debug.Log("No Directory Found");
        }
    }
}
