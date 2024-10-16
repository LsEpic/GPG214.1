using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerPosition
{
    public float[] playerPositionArray = new float[3] { 0, 0, 0 };

    public void SetPlayerPosition(Vector3 playerPos)
    {
        playerPositionArray[0] = playerPos.x;
        playerPositionArray[1] = playerPos.y;
        playerPositionArray[2] = playerPos.z;
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
}
