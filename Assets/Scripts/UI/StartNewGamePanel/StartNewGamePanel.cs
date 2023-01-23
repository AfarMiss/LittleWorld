using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.UI
{
    public class StartNewGamePanel : BaseUI
    {
        public void OnClickBackBtn()
        {
            UIManager.Instance.ShowPanel<WelcomePanel>();
        }

        public void OnClickGenerate()
        {
            SceneControllerManager.Instance.TryChangeScene(SceneEnum.FarmScene.ToString());
        }
    }
}
