using LittleWorld.MapUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
            Root.Instance.GameState = GameState.PLAYING;
            MapSize size = MapSize.MEDIUM;
            if (Enum.TryParse(typeof(MapSize), mapSize, out var result))
            {
                size = (MapSize)result;
            }
            EventCenter.Instance.Trigger(EventEnum.START_NEW_GAME.ToString(), new MainMapInfo(seed, size));
            var mapsize = Map.GetMapSize(size);
            Camera.main.transform.SetPositionAndRotation(new Vector3(mapsize.x / 2, mapsize.y / 2, Camera.main.transform.position.z), Quaternion.identity);
        }
    }
}
