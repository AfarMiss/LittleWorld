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
            UIManager.Instance.ShowPanel<ProgressPanel>();
            UIManager.Instance.ShowPanel<MainInfoPanel>();
            UIManager.Instance.ShowPanel<ItemCountPanel>();
        }
    }
}
