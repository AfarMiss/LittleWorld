using LittleWorld.GameStateSpace;
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

                foreach (var item in ticks.ToList())
                {
                    item.Tick();
                }
            }
        }
    }
}
