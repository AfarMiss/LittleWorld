using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace LittleWorld.UI
{
    public class StartNewGamePanel : BaseUI
    {
        public InputField seedField;
        public Dropdown dropdown;
        public void OnClickBackBtn()
        {
            UIManager.Instance.ShowPanel<WelcomePanel>();
        }

        public void OnClickGenerate()
        {
            SceneControllerManager.Instance.TryChangeScene(SceneEnum.FarmScene.ToString());
            EventCenter.Instance.Trigger(EventEnum.START_NEW_GAME.ToString(), new MainMapInfo(seedField.text, dropdown.captionText.text));
        }
    }
}
