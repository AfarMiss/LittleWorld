using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LittleWorld.UI
{
    public class DynamicCommandIcon : MonoBehaviour
    {
        public delegate void ChangeSprite(DynamicCommandIcon dynamicCommandIcon);
        ChangeSprite OnChangeCommand;

        private string commandNameString
        {
            set
            {
                if (value != null)
                {
                    commandName.text = value;
                    if (OnChangeCommand != null)
                    {
                        img.enabled = true;
                    }
                }
                else
                {
                    img.enabled = false;
                }
            }
        }
        [SerializeField] private Text commandName;
        [SerializeField] private Button btn;
        [SerializeField] private Image img;
        public void BindData(string commandName, Sprite sprite)
        {
            this.commandNameString = commandName;
            if (sprite != null)
            {
                this.img.enabled = true;
                this.img.sprite = sprite;
            }
            else
            {
                this.img.enabled = false;
            }
        }

        public void BindCommand(UnityAction commandAction)
        {
            this.btn.onClick.AddListener(() =>
            {
                commandAction();
            });
        }
    }
}
