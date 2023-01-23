using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class Game
    {
        public GameState state;
        public GlobalPathManager pathManager;

        public Game()
        {
            pathManager = GlobalPathManager.Instance;
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
