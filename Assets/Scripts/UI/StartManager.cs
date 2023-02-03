using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LittleWorld.UI
{
    public class StartManager : MonoBehaviour
    {
        PanelManager panelManager;

        void Awake()
        {
            panelManager = new PanelManager();
        }

        void Start()
        {
            panelManager.Push(new StartPanel());
        }
    }

}
