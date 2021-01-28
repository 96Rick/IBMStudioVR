using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject welcomeMenu;
    public Animator player;
    private bool canPause;
    private bool isPlayerWalking;
    public bool isPaused = false;
    new AudioSource audio;

    void Start()
    {
        isPlayerWalking = (GetComponent("PlayerWalk") as MonoBehaviour).enabled;
        audio = GetComponent<AudioSource>();
        canPause = isPlayerWalking && !welcomeMenu.activeSelf;
    }

    void Update()
    {
        isPlayerWalking = (GetComponent("PlayerWalk") as MonoBehaviour).enabled;
        canPause = !welcomeMenu.activeSelf;
        isPaused = !isPlayerWalking;
#if UNITY_EDITOR
        if (canPause)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!isPaused)
                {
                    (GetComponent("PlayerWalk") as MonoBehaviour).enabled = false;
                    player.GetComponent<Animator>().SetFloat("Velocity Z", 0f);
                    isPaused = true;
                    audio.Stop();
                    pauseMenu.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0.0f, 0.0f, 0.3f);
                    pauseMenu.GetComponent<RectTransform>().localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                    pauseMenu.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    pauseMenu.transform.SetParent(transform, true);
                    pauseMenu.SetActive(true);
                }
            }
        }
#endif
        if (canPause)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (!isPaused)
                    {
                        (GetComponent("PlayerWalk") as MonoBehaviour).enabled = false;
                        player.GetComponent<Animator>().SetFloat("Velocity Z", 0f);
                        isPaused = true;
                        audio.Stop();
                        pauseMenu.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0.0f, 0.0f, 0.3f);
                        pauseMenu.GetComponent<RectTransform>().localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                        pauseMenu.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                        pauseMenu.transform.SetParent(transform, true);
                        pauseMenu.SetActive(true);
                    }
                }
            }
        } 
    }
}
