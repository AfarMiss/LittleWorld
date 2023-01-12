using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld
{
    /// <summary>
    /// 总开关
    /// </summary>
    public class Root : MonoSingleton<Root>
    {
        private SceneItemsManager sceneItemsManager;
        private UIManager uIManager;
        private TimeManager timeManager;
        private GlobalPathManager globalPathManager;
        private PoolManager poolManager;

        private void Start()
        {
            uIManager = UIManager.Instance;
            timeManager = TimeManager.Instance;

            sceneItemsManager = SceneItemsManager.Instance;
            globalPathManager = GlobalPathManager.Instance;
            poolManager = PoolManager.Instance;

            uIManager.Initialize();
            timeManager.Initialize();
        }

        private void Update()
        {
        }
    }
}

