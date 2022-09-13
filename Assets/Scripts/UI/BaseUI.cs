using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public string uiName => path.Substring(path.LastIndexOf('/') + 1);
    public abstract string path { get; }

    public UIType UIType { get; private set; }

    /// <summary>
    /// 进入时
    /// </summary>
    public virtual void OnEnter() { }

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
    public virtual void OnExit() { }

    public void Initialize()
    {
    }

    public abstract void OnClickClose();
}
