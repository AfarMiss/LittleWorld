using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public bool IsShowing { get; private set; }
    public string UiName => GetType().Name;
    public virtual string Path
    {
        get
        {
            var enumName = System.Enum.GetName(typeof(UIType), UiType);
            var folderName = enumName.Substring(0, 1) + enumName.Substring(1).ToLower();
            return $"Prefabs/UI/{folderName}/{GetType().Name}";
        }
    }

    public virtual UIType UiType => UIType.PANEL;

    /// <summary>
    /// 进入时
    /// </summary>
    public virtual void OnEnter()
    {
        IsShowing = true;
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
        IsShowing = false;
    }

    public void Initialize()
    {
    }

    public virtual void OnClickClose()
    {
        UIManager.Instance.Hide(this.GetType(), UiType);
    }
}
