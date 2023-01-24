using LittleWorld.GameStateSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class Game
    {
        public GameState state;
        public MapManager pathManager;
        public TimeManager timeManager;

        public Game()
        {
            pathManager = MapManager.Instance;
            timeManager = TimeManager.Instance;
            state = GameState.PREPARING;

            //gameStateFSM = new FiniteStateMachine();
            //var preparingState = new PreparingState(GameState.PREPARING);
            //var playingState = new PlayingState(GameState.PLAYING);
            //gameStateFSM.AddState(preparingState);
            //gameStateFSM.AddState(playingState);

            //gameStateFSM.SetDefaultState(preparingState);
            //gameStateFSM.Start();
        }

        public void Tick()
        {
            pathManager.Tick();
            timeManager.Tick();
        }
    }
}
