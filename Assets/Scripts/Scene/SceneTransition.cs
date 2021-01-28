using UnityEngine;

[RequireComponent(typeof(Animator))]

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// 播放专场前的动画
    /// </summary>
    public void StratTrans()
    {
        animator.SetTrigger("Start");
    }

    /// <summary>
    /// 播放专场中的动画
    /// </summary>
    public void InTrans()
    {
        animator.SetTrigger("Idle");
    }

    /// <summary>
    /// 播放专场后的动画
    /// </summary>
    public void EndTrans()
    {
        animator.SetTrigger("End");
    }

    /// 判断当前动画是否播放完成
    public bool IsAnimationDone()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            return true;
        else
            return false;
    }

}
