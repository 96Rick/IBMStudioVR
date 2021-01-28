using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveToPosition : MonoBehaviour
{
    public GameObject player;
    public float moveToX;
    public float moveToY;
    public float moveToZ;
    public float targetFaceToEulerAngleY;
    Vector3 targetFaceToDirection;



    public void moveToPosition()
    {
        targetFaceToDirection = new Vector3(0.0f, targetFaceToEulerAngleY - Camera.main.transform.localEulerAngles.y, 0.0f);
        player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(moveToX, moveToY, moveToZ), 1000);
        player.transform.rotation = Quaternion.Euler(targetFaceToDirection);
    }
}
