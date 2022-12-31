using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public bool isShowing { get; private set; }
    public string uiName => path.Substring(path.LastIndexOf('/') + 1);
    public abstract string path { get; }

    public UIType UIType { get; private set; }

    /// <summary>
    /// 进入时
    /// </summary>
    public virtual void OnEnter()
    {
        isShowing = true;
    }

    /// <summary>
    /// 暂停时
    /// </summary>
    public virtual void OnPause() { }

    /// <summary>
    /// 继续时
    /// </summary>
    public virtual void OnResume() { }

    /// <summary>
    /// 退出时
    /// </summary>
    public virtual void OnExit()
    {
        isShowing = false;
    }

    public void Initialize()
    {
    }

    public virtual void OnClickClose() { }
}
