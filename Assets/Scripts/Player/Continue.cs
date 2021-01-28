using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseMenu;
    new AudioSource audio;
    private void Start()
    {
        audio = player.GetComponent<AudioSource>();
    }
    public void ContinueGame()
    {
        (player.GetComponent("PlayerWalk") as MonoBehaviour).enabled = true;
        audio.Play();
        pauseMenu.SetActive(false);
        pauseMenu.transform.SetParent(Camera.main.transform, false);
    }

}
