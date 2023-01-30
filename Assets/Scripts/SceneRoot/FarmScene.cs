using LittleWorld.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class FarmScene : MonoBehaviour
    {
        private void Start()
        {
            //暂时注释
            //UIManager.Instance.ShowPanel<ProgressPanel>();
            UIManager.Instance.ShowPanel<MainInfoPanel>();
        }
    }
}
