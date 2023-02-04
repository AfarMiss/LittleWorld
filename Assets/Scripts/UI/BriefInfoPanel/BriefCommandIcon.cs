using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LittleWorld.UI
{
    public class BriefCommandIcon : MonoBehaviour
    {
        [SerializeField] private Text commandName;
        [SerializeField] private Button btn;
        public void BindData(string commandName, UnityAction commandAction)
        {
            this.commandName.text = commandName;
            this.btn.onClick.AddListener(() => commandAction());
        }
    }
}
