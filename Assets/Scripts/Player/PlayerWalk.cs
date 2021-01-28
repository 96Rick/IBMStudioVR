using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 1.0f;
    float footstepPitch = 0.8f;
    new AudioSource audio;
    bool audioPlay = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        float camRotationX = Camera.main.transform.localEulerAngles.x;
        if (camRotationX >= 70 && camRotationX <= 90)
        {
            audio.Stop();
            audioPlay = false;
            player.GetComponent<Animator>().SetFloat("Velocity Z", 0.0f);
        }
        else if (camRotationX < 70 && camRotationX >= 1)
        {
            
            if (audioPlay == false)
            { 
                audio.Play();
                audioPlay = true;
            }
            float temp = Mathf.Floor(camRotationX / 10) * -0.1f;
            //footstepPitch = moveSpeed + temp - 0.2f;
             
            audio.pitch = footstepPitch + temp;
            if(audio.pitch < 0.2f)
            {
                audio.pitch = 0.2f;
            }
            float x = Camera.main.transform.forward.x * (moveSpeed + temp) * 2 * Time.deltaTime;
            float z = Camera.main.transform.forward.z * (moveSpeed + temp) * 2 * Time.deltaTime;
            //transform.Translate(x, 0, z);
            transform.position = transform.position + new Vector3(Camera.main.transform.forward.x, 0.0f, Camera.main.transform.forward.z) * (moveSpeed + temp) * 2 * Time.deltaTime;
            player.GetComponent<Animator>().SetFloat("Velocity Z", moveSpeed + temp);
        }
        else
        {
            if (audioPlay == false)
            {
                audio.Play();
                audioPlay = true;
            }
            footstepPitch = 0.8f;
            audio.pitch = footstepPitch;
            float x = Camera.main.transform.forward.x * moveSpeed * 2 * Time.deltaTime;
            float z = Camera.main.transform.forward.z * moveSpeed * 2 * Time.deltaTime;
            //transform.Translate(x, 0, z);
            transform.position = transform.position + new Vector3(Camera.main.transform.forward.x, 0.0f, Camera.main.transform.forward.z) * moveSpeed * 2 * Time.deltaTime;
            player.GetComponent<Animator>().SetFloat("Velocity Z", moveSpeed);
        }
    }
}
