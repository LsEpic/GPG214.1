using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public float[] playerPositionArray = new float[3] { 0, 0, 0 };
    public float distanceTravelled = 0;
    public int shotsFired = 0;

    public Vector3 lastPosition = Vector3.zero;

    public void SetPlayerPosition(Vector3 playerPos)
    {
        playerPositionArray[0] = playerPos.x;
        playerPositionArray[1] = playerPos.y;
        playerPositionArray[2] = playerPos.z;

        if (lastPosition != Vector3.zero)
        {
            distanceTravelled += Vector3.Distance(lastPosition, playerPos);
        }
        lastPosition = playerPos;
    }

    public Vector3 ReturnPlayerPosition()
    {
        if (playerPositionArray.Length < 3)
        {
            Debug.Log("Not enough elements in Array");
            return Vector3.zero;
        }
        return new Vector3(playerPositionArray[0], playerPositionArray[1], playerPositionArray[2]);
    }

    public void AddShotsFired()
    {
        shotsFired++;
    }

    public void ResetStats()
    {
        lastPosition = Vector3.zero;
        shotsFired = 0;
    }
}
