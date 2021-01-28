using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GvrAutoClick : MonoBehaviour
{
    public Image gaze;
    public UnityEvent GvrClick;
    public float totalTime = 2f;
    private bool gvrStatus;
    public float gvrTimer;

    void Update()
    {
        if(gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            gaze.fillAmount = gvrTimer / totalTime;
        }
        if (gvrTimer > totalTime)
        {
            GvrClick.Invoke();
            gvrTimer = totalTime;
        }
    }

    public void GvrPointerEnter()
    {
        gvrStatus = true;
    }

    public void GvrPointerExit()
    {
        gvrStatus = false;
        gvrTimer = 0f;
        gaze.fillAmount = 0;
    }

    public void DebugPrint()
    {
        Debug.Log("succeed!");
    }
}
