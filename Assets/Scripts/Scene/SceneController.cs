﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneLoader._instance.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
