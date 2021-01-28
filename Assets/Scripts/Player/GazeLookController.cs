using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GazeLookController : MonoBehaviour
{
    public GameObject gazeLook;
    public GameObject pauseText;
    public GameObject welcomeText;
    public GvrReticlePointer pointer;

    public void changeGazeLookFunc()
    {
        bool isActive = gazeLook.activeSelf;
        if(isActive)
        {
            //更改欢迎界面的自动注释文字
            //更改暂停界面的自动注释文字
            pauseText.GetComponent<Text>().text = "Enable Auto Look";
            welcomeText.GetComponent<Text>().text = "Enable Auto Look";
            gazeLook.SetActive(false);
        } else if (!isActive)
        {

            pauseText.GetComponent<Text>().text = "Disabel Auto Look";
            welcomeText.GetComponent<Text>().text = "Disabel Auto Look";
            gazeLook.SetActive(true);
        }
    }
    // 为了修复 取消自动凝视功能以后指针变成透明颜色的问题
    public void fixPointerColor()
    {
        pointer.GetComponent<Renderer>().material.SetColor("_Color",Color.white);
    }

}
