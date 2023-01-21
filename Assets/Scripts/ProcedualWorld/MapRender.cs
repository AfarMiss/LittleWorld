using LittleWorld.MapUtility;
using MultipleTxture;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProcedualWorld
{
    public class MapRender : MonoBehaviour
    {
        Dictionary<int, Sprite> tileset;
        TextureManager textureManager => TextureManager.Instance;

        private void Start()
        {
            CreateTileset();
        }

        private void CreateTileset()
        {
            tileset = new Dictionary<int, Sprite>();
            tileset.Add(0, textureManager.GetTerrain("TEX_water"));
            tileset.Add(1, textureManager.GetTerrain("TEX_plain"));
            tileset.Add(2, textureManager.GetTerrain("TEX_mountain"));
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
            var curTile = GridPropertiesManager.Instance.GetBasicTerrainTile(tile_id);
            switch (tile_id)
            {
                case 0:
                    GridPropertiesManager.Instance.SetTile("Water", new Vector3(x + bottomLeft.x, y + bottomLeft.y, 0), curTile);
                    break;
                case 1:
                case 2:
                    GridPropertiesManager.Instance.SetTile("Plain", new Vector3(x + bottomLeft.x, y + bottomLeft.y, 0), curTile);
                    break;
                default:
                    break;
            }
        }
    }
}
