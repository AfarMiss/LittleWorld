using LittleWorld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LittleWorld
{
    [CreateAssetMenu(fileName = "TileDatabase", menuName = "ScriptableObject/TileDatabase")]
    public class TileDatabase : ScriptableObject
    {
        public List<TileDetail> textureDetailList;

        public List<Tile> waterPlainDetailList;

        public Tile Get(string terrainName)
        {
            var item = textureDetailList.Find(x => x.spriteName == terrainName);
            if (item == null)
            {
                return null;
            }
            var itemTile = item.tile;
            if (itemTile == null)
            {
                return null;
            }
            return itemTile;
        }
    }
}
