 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITips : MonoBehaviour {

    public static Vector3 vec3, pos;
    public GameObject tips;
    public GameObject needtohide;
    public GameObject back;
    
    // Use this for initialization
    void Start () {

//        gameObject.SetActive(false);
    }
    
    public void PointerDown()
    {
        vec3 = Input.mousePosition;//获取当前鼠标的位置
        pos = transform.GetComponent<RectTransform>().position;//获取自己所在的位置
    }

    public void onShow()
    {
        tips.SetActive(true);
        needtohide.SetActive(false);
    }


    public void onOK()
    {

        tips.SetActive(true);
        back.SetActive(false);
    }
    void Update () {
        
    }
}





