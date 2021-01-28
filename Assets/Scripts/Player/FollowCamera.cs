using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Camera.main.transform.eulerAngles.y);
        player.transform.localEulerAngles = new Vector3(0.0f, Camera.main.transform.localEulerAngles.y, 0.0f);
    }
}
