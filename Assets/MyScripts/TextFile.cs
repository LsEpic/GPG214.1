using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextFile : MonoBehaviour
{
    public DistanceTracker distanceTracker;

    public string fileName = "DistanceTravelled.txt";

    [SerializeField] private float newDistance;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        string parseDistance = distanceTracker.GetDistanceTravelled().ToString();
        UpdateDistanceTotal(parseDistance);
    }

    public void UpdateDistanceTotal(string newDistance)
    {
        WriteData(newDistance);
    }

    void WriteData(string dataToWrite)
    {
        string filePath = Path.Combine(Application.dataPath, fileName);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(dataToWrite);
        }
    }
}
