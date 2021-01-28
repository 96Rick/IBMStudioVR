using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControllerForGVR : MonoBehaviour
{
    public float velocityZ;
    public float velocityX = 0.0f;
    public bool isStop = false;
    public float currentMaxVelocityZ;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    // Update is called once per frame
    void Update()
    {
        if (isStop && currentMaxVelocityZ != velocityZ)
        {
            velocityZ -= Time.deltaTime * 2.0f;
        } else
        {
            velocityZ = currentMaxVelocityZ;
        }
    }
}
