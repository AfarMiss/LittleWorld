
using System.Collections.Generic;
using UnityEngine;
namespace LittleWorld.UI
{
    public class PanelManager
    {
        private Stack<BaseUI> stackPanel;
        private BaseUI panel;

        public PanelManager()
        {
            stackPanel = new Stack<BaseUI>();
        }

        public void Push(BaseUI panel)
        {
            if (stackPanel.Count > 0)
            {
                panel = stackPanel.Peek();
                panel.OnPause();
            }
            stackPanel.Push(panel);
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

}
