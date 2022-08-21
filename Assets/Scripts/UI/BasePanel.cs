public abstract class BasePanel
{
    public UIType UIType { get; private set; }
    public UITool UITool { get; private set; }

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

    public BasePanel(UIType type)
    {
        UIType = type;
    }

    public void Initialize(UITool tool)
    {
        this.UITool = tool;
    }
}
