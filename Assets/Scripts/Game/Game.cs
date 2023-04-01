using LittleWorld.GameStateSpace;
using LittleWorld.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private void InitGame(MainMapInfo mapInfo)
        {
            mapManager = MapManager.Instance;
            timeManager = TimeManager.Instance;
            SceneObjectManager = SceneObjectManager.Instance;
            ticks = new List<ITick>();

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
    }
}
