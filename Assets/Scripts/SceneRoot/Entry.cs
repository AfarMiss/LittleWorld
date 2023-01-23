using LittleWorld.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class Entry : MonoBehaviour
    {
        private void Start()
        {
            UIManager.Instance.Show<WelcomePanel>(UIType.PANEL, UIPath.Panel_WelcomePanel);
        }
    }
}
