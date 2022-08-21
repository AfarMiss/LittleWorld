
using System.Collections.Generic;
using UnityEngine;

public class PanelManager 
{
    private Stack<BasePanel> stackPanel;
    private UIManager uiManager;
    private BasePanel panel;

    public PanelManager()
    {
        stackPanel = new Stack<BasePanel>();
        uiManager= new UIManager();
    }

    public void Push(BasePanel panel)
    {
        if (stackPanel.Count > 0)
        {
            panel = stackPanel.Peek();
            panel.OnPause();
        }
        stackPanel.Push(panel);
        GameObject panelObject = uiManager.GetSingleUI(panel.UIType);
        panel.Initialize(new UITool(panelObject));
        panel.OnEnter();
    }

    public void Pop()
    {
        if (stackPanel.Count > 0)
        {
            panel = stackPanel.Peek();
            panel.OnExit();
            stackPanel.Pop();
        }
        if (stackPanel.Count > 0)
        {
            panel = stackPanel.Peek();
            panel.OnResume();
        }

    }
}
