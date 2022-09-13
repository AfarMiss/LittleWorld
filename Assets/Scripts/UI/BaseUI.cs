using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public string uiName => path.Substring(path.LastIndexOf('/') + 1);
    public abstract string path { get; }

    public UIType UIType { get; private set; }

    /// <summary>
    /// ����ʱ
    /// </summary>
    public virtual void OnEnter() { }

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
    public virtual void OnExit() { }

    public void Initialize()
    {
    }

    public abstract void OnClickClose();
}
