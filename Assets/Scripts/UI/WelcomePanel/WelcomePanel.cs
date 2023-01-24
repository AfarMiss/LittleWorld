using LittleWorld.Command;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld.UI
{
    public class WelcomePanel : BaseUI
    {
        public override string Path => base.Path;

        public override UIType UiType => UIType.PANEL;

        public void OnClickStartNewGame()
        {
            CommandCenter.Instance.Enqueue(new StartNewGameCommand());
        }

        public void OnClickLoadGame()
        {

        }
    }
}
