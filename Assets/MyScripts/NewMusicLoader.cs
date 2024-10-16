using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class NewMusicLoader : MonoBehaviour
{
    public string fileName = "RetroMusic.wav";
    public string folderName = "NewMusic";
    private string combinedFilePath;

    [SerializeField] private AudioSource audioSource;
    private AudioClip retroMusic;

    // Start is called before the first frame update
    void Start()
    {
        combinedFilePath = Path.Combine(Application.streamingAssetsPath, folderName, fileName);
        audioSource = GetComponent<AudioSource>();

        if(audioSource == null)
        {
            Debug.Log("Error, No audio source component");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            LoadNewMusic();
            ChangeMusic();
        }
    }

    void LoadNewMusic()
    {
        if(File.Exists(combinedFilePath))
        {
            byte[] audioData = File.ReadAllBytes(combinedFilePath);

            //convert byte array into float array, divide by 2 for two bits
            float[] floatArray = new float[audioData.Length / 2];

            //loop over the array
            for(int i = 0; i<floatArray.Length; i++)
            {
                //convert the data to 16 bit
                short bitValue = System.BitConverter.ToInt16(audioData, i * 2);

                //normalise current value (32768 being max)
                floatArray[i] = bitValue / 32768.0f;
            }

            //create function
            retroMusic = AudioClip.Create("RetroMusic", floatArray.Length, 1, 44100, false);

            //set data
            retroMusic.SetData(floatArray, 0);
        }
        else
        {
            Debug.Log("No file found at path " +  combinedFilePath);
        }
    }

    void ChangeMusic()
    {
        if (audioSource == null || retroMusic == null)
        {
            return;
        }

        //assigns and calls new music to play
        audioSource.clip = retroMusic;
        audioSource.Play();
    }
}
