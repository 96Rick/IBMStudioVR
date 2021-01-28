using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToggle : MonoBehaviour
{
    // 需要处理的画布
    public GameObject canvas;
   
    public void showCanvas()
    {
        canvas.SetActive(true);
    }
    public void hideCanvas()
    {
        canvas.SetActive(false);
    }
}
