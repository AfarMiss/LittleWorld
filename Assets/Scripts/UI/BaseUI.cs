using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public bool isShowing { get; private set; }
    public string uiName => path.Substring(path.LastIndexOf('/') + 1);
    public abstract string path { get; }

    public UIType UIType { get; private set; }

    /// <summary>
    /// ����ʱ
    /// </summary>
    public virtual void OnEnter()
    {
        isShowing = true;
    }

    /// <summary>
    /// ��ͣʱ
    /// </summary>
    public virtual void OnPause() { }

    /// <summary>
    /// ����ʱ
    /// </summary>
    public virtual void OnResume() { }

    /// <summary>
    /// �˳�ʱ
    /// </summary>
    public virtual void OnExit()
    {
        isShowing = false;
    }

    public void Initialize()
    {
    }

    public abstract void OnClickClose();
}
