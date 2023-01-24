using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class Game
    {
        public GameState state;
        public GlobalPathManager pathManager;
        public TimeManager timeManager;

        public Game()
        {
            pathManager = GlobalPathManager.Instance;
            timeManager = TimeManager.Instance;
            state = GameState.PREPARING;
        }
    }

    public enum GameState
    {
        UNINIT,
        PREPARING,
        PLAYING
    }
}
