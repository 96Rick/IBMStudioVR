using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    // animation
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;
    // increase performance
    int VelocityZHash;
    int VelocityXHash;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        VelocityZHash = Animator.StringToHash("Velocity Z");
        VelocityXHash = Animator.StringToHash("Velocity X");
    }
    

    void changeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {
        // player move to forward or backword
        // if player presses forward, increase velocity in z direction
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
            //animator.transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }
        // decrease velocity z (forward)
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
        // if player presses backward, decrease velocity in z direction
        if (backPressed && velocityZ > -maximumWalkVelocity)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }
        // decrease velocity z (backward)
        if (!backPressed && velocityZ < 0.0f)
        {
            velocityZ += Time.deltaTime * deceleration;
        }

        // player move to right or left
        // increase velocity in right direction
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }
        // decreate volicaty x if right btn not pressed and vX > 0
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }
        // decrease velocity in left direction
        if (leftPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        // increase volicaty x if left btn not pressed and vX < 0
        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }
    }

    void lockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {
        // lock forward
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.09f))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.09f))
        {
            velocityZ = currentMaxVelocity;
        }



        if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
        }
        else if (rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * deceleration;
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.09f))
            {
                velocityX = currentMaxVelocity;
            }
        }
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.09f))
        {
            velocityX = currentMaxVelocity;
        }




        if (leftPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
        }
        else if (leftPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * deceleration;
            if (velocityX > -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.09f))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity - 0.09f))
        {
            velocityX = -currentMaxVelocity;
        }


        if (backPressed && velocityZ < -currentMaxVelocity && velocityZ > (-currentMaxVelocity + 0.09f))
        {
            velocityZ = -currentMaxVelocity;
        }


        // reset velocity Z
        if (!backPressed && !forwardPressed && velocityZ != 0.0f && (velocityZ > -0.09f && velocityZ < 0.09f))
        {
            velocityZ = 0.0f;
        }

        // reset velocity X
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.09f && velocityX < 0.09f))
        {
            velocityX = 0.0f;
        }
    }

    void playerMove(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {

        if (forwardPressed)
            {
            transform.position = transform.position + Camera.main.transform.forward * 10 * Time.deltaTime;
            Debug.Log("this is movement" + Camera.main.transform.rotation);

            }
    }
    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool backPressed = Input.GetKey(KeyCode.S);

        // current maxVelocity
        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;

        changeVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);
        lockOrResetVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);
        //playerMove(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);

        // set the parameters to our local variable values
        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);
    }
}
