using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTracker: MonoBehaviour
{
    private Vector2 previousPosition;
    private float distanceTravelled;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = transform.position;
        float distanceThisFrame = Vector2.Distance(currentPosition, previousPosition);

        distanceTravelled += distanceThisFrame;

        previousPosition = currentPosition;

        //Debug.Log(distanceTravelled);
    }

    public float GetDistanceTravelled()
    {
        return distanceTravelled;
    }
}
