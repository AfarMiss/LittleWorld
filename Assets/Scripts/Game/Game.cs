using LittleWorld.GameStateSpace;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleWorld
{
    public class Game
    {
        public GameState state;
        public MapManager pathManager;
        public TimeManager timeManager;
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
            pathManager = MapManager.Instance;
            timeManager = TimeManager.Instance;
            ticks = new List<ITick>();
            state = GameState.PREPARING;

            Current.CurGame = this;
        }

        public void Tick()
        {
            if (state == GameState.PLAYING)
            {
                pathManager.Tick();
                timeManager.Tick();

                foreach (var item in ticks.ToList())
                {
                    item.Tick();
                }
            }
        }
    }
}
