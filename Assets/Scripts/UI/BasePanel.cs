public abstract class BasePanel
{
    public UIType UIType { get; private set; }
    public UITool UITool { get; private set; }

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

    public BasePanel(UIType type)
    {
        UIType = type;
    }

    public void Initialize(UITool tool)
    {
        this.UITool = tool;
    }
}
