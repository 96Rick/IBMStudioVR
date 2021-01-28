using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjToggle : MonoBehaviour
{
    public GameObject obj;


    public void activeObj()
    {
        obj.SetActive(true);
    }
    public void deactiveObj()
    {
        obj.SetActive(false);
    }
}
