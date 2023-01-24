using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LittleWorld.Command
{
    public class GenerateWorldCommand : ICommand
    {
        private string seed;
        private string mapSize;

        public GenerateWorldCommand(string seed, string mapSize)
        {
            this.seed = seed;
            this.mapSize = mapSize;
        }

        public void Execute()
        {
            SceneControllerManager.Instance.TryChangeScene(SceneEnum.FarmScene.ToString());
            EventCenter.Instance.Trigger(EventEnum.START_NEW_GAME.ToString(), new MainMapInfo(seed, mapSize));
            Root.Instance.GameState = GameState.PLAYING;
        }
    }
}
