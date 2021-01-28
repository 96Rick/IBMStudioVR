using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player 与其他物体碰撞时触发
public class PlayerCollision : MonoBehaviour
{
    // tatami video 组件
    public GameObject tatamiVideo;
    // watson video 组件
    public GameObject watsonVideo;
    // 多个变量用来判断是否处于蓝色区域中，还可继续添加
    public bool isAlreadyInWatson = false;
    public bool isAlreadyInTatami = false;
    private GameObject playerModel;
    private GameObject studioModel;

    private void Start()
    {
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
        studioModel = GameObject.FindGameObjectWithTag("StudioModel");
    }
    // 系统函数 当两个具有 collider（MeshCollider/ BoxCollider）的物体碰撞时就会触发
    private void OnCollisionEnter(Collision collision)
    {

       
        //用来判断 挂载该脚本的物体（player）所碰撞的物体名称是否叫 tatami 或者说当 player 走进 tatami 蓝色地面标识时：
        if (collision.collider.name == "tatami")
        {
            if (!isAlreadyInTatami)
            {
                // 1.disable playerwalk 脚本
                // 2.暂停脚步声。
                // 3.暂停背景音乐.
                // 4.将tatamiVideo展示出来
                // 5.使镜头对准video，并将player移动到指定地点。
                // 6.更改状态
                (GetComponent("PlayerWalk") as MonoBehaviour).enabled = false;
                GetComponent<AudioSource>().Pause();
                studioModel.GetComponent<AudioSource>().Pause();
                tatamiVideo.SetActive(true);
                Vector3 targetFaceToDirection = new Vector3(0.0f, 90 - Camera.main.transform.localEulerAngles.y, 0.0f);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(29.3f, 1.27f, -30.64f), 1000);
                transform.rotation = Quaternion.Euler(targetFaceToDirection);
                playerModel.GetComponent<Animator>().SetFloat("Velocity Z", 0.0f);
                isAlreadyInTatami = true;
            }
        }

        if (collision.collider.name == "Ws")
        {
            if (!isAlreadyInWatson)
            {
                (GetComponent("PlayerWalk") as MonoBehaviour).enabled = false;
                GetComponent<AudioSource>().Pause();
                studioModel.GetComponent<AudioSource>().Pause();
                watsonVideo.SetActive(true);
                Vector3 targetFaceToDirection = new Vector3(0.0f, 0 - Camera.main.transform.localEulerAngles.y, 0.0f);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.358f, 0.3f, -80.02f), 1000);
                transform.rotation = Quaternion.Euler(targetFaceToDirection);
                playerModel.GetComponent<Animator>().SetFloat("Velocity Z", 0.0f);
                isAlreadyInWatson = true;
            }
        }
    }
}
