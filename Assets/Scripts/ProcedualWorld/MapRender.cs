using LittleWorld;
using LittleWorld.Graphics;
using LittleWorld.MapUtility;
using LittleWorld.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

namespace ProcedualWorld
{
    public class MapRender : MonoBehaviour
    {
        private static Dictionary<int, Tile> tileset;
        private Map map;
        public Tilemap altitudeLayer;
        public Tilemap terrainLayer;

        public void Init(Map map)
        {
            this.map = map;
            altitudeLayer = GameObject.FindGameObjectWithTag(Tags.Altitude.ToString())?.GetComponent<Tilemap>();
            terrainLayer = GameObject.FindGameObjectWithTag(Tags.Terrain.ToString())?.GetComponent<Tilemap>();
            CreateTileset();
        }

        private void CreateTileset()
        {
            tileset = new Dictionary<int, Tile>();
            tileset.Add(0, Current.TileManager.GetTerrain("TEX_water_4"));
            tileset.Add(1, Current.TileManager.GetTerrain("TEX_water_3"));
            tileset.Add(2, Current.TileManager.GetTerrain("TEX_water_2"));
            tileset.Add(3, Current.TileManager.GetTerrain("TEX_water_1"));
            tileset.Add(4, Current.TileManager.GetTerrain("TEX_shore"));
            tileset.Add(5, Current.TileManager.GetTerrain("TEX_plain"));
        }

        public void RenderMap(Map map)
        {
            for (int x = 0; x < map.MapSize.x; x++)
            {
                for (int y = 0; y < map.MapSize.y; y++)
                {
                    if (map.GetGrid(x, y, out var result))
                    {
                        RenderTile(map.MapLeftBottomPoint, result.gridAltitudeLayer, x, y);
                    };
                }
            }
        }

        private void RenderTile(Vector2Int bottomLeft, int tile_id, int x, int y)
        {
            if (tile_id >= 0 && tile_id < 20)
            {
                altitudeLayer.SetTile(new Vector3(x + bottomLeft.x, y + bottomLeft.y, 0).ToCell(), tileset[tile_id / 5]);
            }
            else if (tile_id >= 20 && tile_id < 30)
            {
                altitudeLayer.SetTile(new Vector3(x + bottomLeft.x, y + bottomLeft.y, 0).ToCell(), tileset[4]);
            }
            else
            {
                altitudeLayer.SetTile(new Vector3(x + bottomLeft.x, y + bottomLeft.y, 0).ToCell(), tileset[5]);
            }
        }

        private void Update()
        {
            //绘制种植区，种植区现在绘制的Mesh在没有变化的情况下依然会每帧都重新计算
            //应该存储种植区的mesh，没有变化时就使用旧的，减少运算量
            foreach (var item in map.sectionDic)
            {
                GraphicsUtiliy.DrawPlantZoom(item.Value.GridPosList.ToArray(), item.Value.sectionColorIndex);
            }
        }
    }
}
