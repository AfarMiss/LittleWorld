using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LittleWorld
{
    public class TileManager : MonoSingleton<TileManager>
    {
        [SerializeField]
        private TileDatabase database;


        public Tile GetTerrain(string terrainName)
        {
            return database.Get(terrainName);
        }

        public Tile[] GetBasicTerrain()
        {
            return database.waterPlainDetailList.ToArray();
        }


    }
}
