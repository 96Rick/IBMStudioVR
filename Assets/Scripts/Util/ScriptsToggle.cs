using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsToggle : MonoBehaviour
{
    // 脚本所在的 game object
    public GameObject obj;
    // 脚本名称
    public string scr;

    public void activeScripts()
    {
        (obj.GetComponent(scr) as MonoBehaviour).enabled = true;
    }
    public void deactiveScripts()
    {
        (obj.GetComponent(scr) as MonoBehaviour).enabled = false;
    }
}
