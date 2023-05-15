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
    public class Game
    {
        public GameState state;
        public MapManager mapManager;
        public TimeManager timeManager;
        public SceneObjectManager SceneObjectManager;
        private List<ITick> ticks;
        public event Action<string> OnHint;
        private bool noPawn = false;
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
            EventCenter.Instance.Register<MainMapInfo>(EventEnum.START_NEW_GAME.ToString(), InitGame);
            state = GameState.PREPARING;
            Current.CurGame = this;
        }

        private async void InitGame(MainMapInfo mapInfo)
        {
            await StartGame(mapInfo);
        }

        private async Task<bool> StartGame(MainMapInfo mapInfo)
        {
            mapManager = MapManager.Instance;
            timeManager = TimeManager.Instance;
            SceneObjectManager = SceneObjectManager.Instance;
            ticks = new List<ITick>();

            await InputController.Instance != null;

            mapManager.InitMainMaps(mapInfo);
            SceneObjectManager.Instance.Init();
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
        }
    }
}
