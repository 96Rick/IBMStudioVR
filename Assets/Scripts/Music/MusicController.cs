using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject objWithMusic;
    public GameObject enableBtn;
    public GameObject disableBtn;

    public void enableMusic()
    {
        enableBtn.SetActive(false);
        disableBtn.SetActive(true);
        objWithMusic.GetComponent<AudioSource>().Play();
    }
    public void disableMusic()
    {
        enableBtn.SetActive(true);
        disableBtn.SetActive(false);
        objWithMusic.GetComponent<AudioSource>().Stop();
    }
}
