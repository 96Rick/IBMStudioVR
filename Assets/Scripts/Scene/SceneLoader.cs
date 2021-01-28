using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    // 实例
    public static SceneLoader _instance;
    // 当前过场预设
    public SceneTransition currentSceneTransition;
    // 当前是否可以转场
    public bool LoadAble { get; private set;}
    // 转场时需要隐藏的组件
    // gvr指针
    public GameObject pointer;
    // player模型
    public GameObject player;

    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadAble = true;
    }
    /// <summary>
    /// 使用转场加载场景
    /// </summary> 
    /// <param name="SceneName">场景名称</param>
    /// <param name="SceneTransition">转场方式</param>
    public void LoadScene(string SceneName, SceneTransition transition = null)
    {
        // 如果现在不能转换，直接返回
        if (!LoadAble) return;
        //如果有设置过转场动画就设置过场
        if (transition != null)
            currentSceneTransition = transition;

        //开始转换场景
        StartCoroutine(LoadScene(SceneName));
    }


    /// <summary>
    /// 转换场景并使用过渡动画
    /// </summary>
    /// <param name="sceneName">场景名称</param>
    private IEnumerator LoadScene(string sceneName)
    {
        // 异步加载场景
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);
        // 不允许加载完场景之后直接转换
        loading.allowSceneActivation = false;
        // 不允许再次转换防止二次输入
        LoadAble = false;
        // loading期间禁止指针显示、人物模型
        pointer.SetActive(false);
        if (player != null)
            player.SetActive(false);
        // 开始转场动画
        currentSceneTransition.StratTrans();
        // 等待一帧
        // 检查动画前还夹着一个检查加载的过程。基本不会在一帧内就加载完
        yield return null;
        // 等待直道动画播放完
        while (!currentSceneTransition.IsAnimationDone())
            yield return null;
        // 判断开始动画是否播放完
        if (currentSceneTransition.IsAnimationDone())
        {
        // 开始等待动画（IBM闪烁）
            currentSceneTransition.InTrans();
        }
        // 等待直到场景快加载完成
        while (loading.progress < 0.899)
            yield return null;
        // 再等待一秒
        yield return new WaitForSeconds(1);
        // 等待动画播放完成
        while (!currentSceneTransition.IsAnimationDone())
            yield return null;
        // 允许场景显示
        loading.allowSceneActivation = true;
        // 等待场景加载彻底完成
        while (loading.progress != 1)
            yield return null;
        // 播放结束动画
        currentSceneTransition.EndTrans();
        // 再等待一帧
        yield return null;
        // 等待动画播放完成
        while (!currentSceneTransition.IsAnimationDone())
            yield return null;
        // 可以再次转场
        LoadAble = true;
        // loading完成显示指针、人物模型
        pointer.SetActive(true);
        if (player != null)
            player.SetActive(true);
    }
}
