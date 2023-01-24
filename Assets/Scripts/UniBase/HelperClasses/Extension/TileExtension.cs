using MultipleTxture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LittleWorld.Extension
{
    public static class TileExtension
    {
        public static void SetTileLayer(this Tile tile, string layerName)
        {
            tile.sprite = TextureManager.Instance.GetTerrain(layerName);
            tile.name = layerName;
        }
    }
}
