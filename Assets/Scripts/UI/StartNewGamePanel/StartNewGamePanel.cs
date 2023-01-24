using LittleWorld.Command;
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
            CommandCenter.Instance.Enqueue(new GenerateWorldCommand(seedField.text, dropdown.captionText.text));
        }
    }
}
