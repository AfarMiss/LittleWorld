using LittleWorld.GameStateSpace;
using LittleWorld.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace LittleWorld
{
    public class Game : IListener
    {
        public GameState state;
        public MapManager mapManager;
        public TimeManager timeManager;
        public SceneObjectManager SceneObjectManager;
        private List<ITick> ticks;
        public event Action<string> OnHint;
        public bool IsInited = false;
        public int timeSpeed
        {
            get
            {
                return (int)Time.timeScale;
            }
            set
            {
                Time.timeScale = value;
            }
        }

        public void RegisterTick(ITick tick)
        {
            ticks.Add(tick);
        }

        public void UnregisterTick(ITick tick)
        {
            if (ticks.Contains(tick))
            {
                ticks.Remove(tick);
            }
        }

        public void Hint(string hintContent)
        {
            OnHint?.Invoke(hintContent);
        }


        public Game()
        {
            this.EventRegister<MainMapInfo>(EventEnum.START_NEW_GAME.ToString(), InitGame);
            state = GameState.PREPARING;
            Current.CurGame = this;
        }

        private void InitGame(MainMapInfo mapInfo)
        {
            StartGame(mapInfo);
        }

        public async Task CheckInputControllerIsNull()
        {
            while (InputController.Instance == null)
            {
                await Task.Delay(1000);
                Debug.LogWarning("等待InputController.Instance加载！");
            }
        }

        private async void StartGame(MainMapInfo mapInfo)
        {
            SceneObjectManager = SceneObjectManager.Instance;
            mapManager = MapManager.Instance;
            timeManager = TimeManager.Instance;
            ticks = new List<ITick>();

            Debug.LogWarning("开始等待InputController.Instance加载！");
            await CheckInputControllerIsNull();
            Debug.LogWarning("结束等待InputController.Instance加载！");

            if (CheckInputControllerIsNull().IsCompleted)
            {
                mapManager.InitMainMaps(mapInfo);
                SceneObjectManager.Instance.Init();
            }
            IsInited = true;
        }

        public void Tick()
        {
            if (state == GameState.PLAYING)
            {
                mapManager.Tick();
                timeManager.Tick();
            }
        }

        public void Unload()
        {
            GameObject.Destroy(VFXManager.Instance.gameObject);
            InputController.Instance.SelectedObjects = null;

            SceneObjectManager.Dispose();
            mapManager.Dispose();
            timeManager.Dispose();

            SceneObjectManager = null;
            timeManager = null;
            mapManager = null;

            IsInited = false;
            state = GameState.UNINIT;

            OnHint = null;
            GameObject.Destroy(GameObject.Find("RenderParent"));
            this.EventUnregister();

            Current.CurGame = null;
        }
    }
}
