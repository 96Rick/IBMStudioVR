using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButtonControl : MonoBehaviour
{
    // player 目前只是用来更改 PlayerCollision脚本中的 isAlreadyInTatami/isAlreadyInWatson bool值
    public GameObject player;
    // 需要隐藏的 video button （播放/暂停）
    public GameObject videoBtnNeedToHide;
    // 需要显示的 video button （播放/暂停）
    public GameObject videoBtnNeedToShow;

    public void changeShownBtn()
    {
        videoBtnNeedToHide.SetActive(false);
        videoBtnNeedToShow.SetActive(true);
    }

    public void closeVideoBtnPressed()
    {
        (player.GetComponent("PlayerCollision") as PlayerCollision).isAlreadyInTatami = false;
        (player.GetComponent("PlayerCollision") as PlayerCollision).isAlreadyInWatson = false;
        player.GetComponent<AudioSource>().Play();
        //playerCollision.isAlreadyInTatami = false;

    }
}
