using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class Game
    {
        public GameState state;
    }

    public enum GameState
    {
        UNINIT,
        PREPARING,
        PLAYING
    }
}
