using AStarUtility;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

namespace LittleWorld.MapUtility
{
    /// <summary>
    /// 所有地图的左下角坐标均为(0,0)
    /// </summary>
    public class Map
    {
        public Vector2Int MapSize;
        public Vector2Int MapLeftBottomPoint = Vector2Int.zero;
        public MapGridDetails[] mapGrids;
        public List<MapSection> sectionList;
        private HashSet<Vector2Int> plantGridPos;
        public Color[] sectionColor;
        public MapSection CurSelectedSection;
        public int sectionColorSeed = 0;


        public int nextPlantSectionIndex
        {
            get
            {
                sectionList.FindAll(x => x.sectionType == SectionType.PLANT);
                return sectionList.Count + 1;
            }
        }
        private AStar aStar;
        [SerializeField]
        private string seed;

        public Vector2Int[] GetAllPlantGridsPos
        {
            get
            {
                var result = new List<Vector2Int>();
                foreach (var item in mapGrids)
                {
                    if (item.isPlantZone)
                    {
                        result.Add(item.pos);
                    }
                }

                return result.ToArray();
            }
        }

        public bool ExpandZone(MapGridDetails[] gridIndexs)
        {
            var section = CurSelectedSection;
            foreach (var item in gridIndexs)
            {
                var result = section.gridIndexs.Find(x => x == item.pos);
                if (result == null)
                {
                    section.gridIndexs.Add(result);
                }
                else
                {
                    continue;
                }
            }
            return true;
        }

        public bool ShrinkZone(MapGridDetails[] gridIndexs)
        {
            var section = CurSelectedSection;
            foreach (var item in gridIndexs)
            {
                var result = section.gridIndexs.Find(x => x == item.pos);
                if (result != null)
                {
                    section.gridIndexs.Remove(result);
                }
                else
                {
                    continue;
                }
            }
            return true;
        }

        public bool DeleteSection()
        {
            var mapSection = CurSelectedSection;
            try
            {
                sectionList.Remove(mapSection);
                return true;
            }
            catch (System.Exception e)
            {
                Debug.LogError($"delete error:{e}");
                return false;
                throw;
            }
        }

        public bool AddSection(MapGridDetails[] gridIndexs, SectionType type)
        {
            var vec2 = new List<Vector2Int>();
            foreach (var item in gridIndexs)
            {
                if (plantGridPos.Contains(item.pos))
                {
                    continue;
                }
                else
                {
                    vec2.Add(item.pos);
                    plantGridPos.Add(item.pos);
                }
            }
            sectionColorSeed = (++sectionColorSeed) % MaterialDatabase.Instance.PlantZoomMaterials.Length;
            var newSection = new MapSection(vec2, $"{type.ToString()} nextPlantSectionIndex", type, sectionColorSeed);
            sectionList.Add(newSection);
            CurSelectedSection = newSection;
            return true;
        }

        /// <summary>
        /// water-plain-mountain
        /// </summary>
        private int layerCount = 100;

        private int SeedToInt()
        {
            return seed.GetHashCode() % 50000;
        }

        public float lacunarity = 2;

        public static Vector2Int GetMapSize(MapSize mapSize)
        {
            switch (mapSize)
            {
                case global::MapSize.SMALL:
                    return new Vector2Int(50, 50);
                case global::MapSize.MEDIUM:
                    return new Vector2Int(100, 100);
                case global::MapSize.LARGE:
                    return new Vector2Int(150, 150);
                default:
                    return new Vector2Int(100, 100);
            }
        }

        public Map(Vector2Int MapSize, string seed)
        {
            this.MapSize = MapSize;
            this.seed = seed;
            this.sectionList = new List<MapSection>();
            mapGrids = new MapGridDetails[MapSize.x * MapSize.y];


            var index = 0;
            for (int x = 0; x < MapSize.x; x++)
            {
                for (int y = 0; y < MapSize.y; y++)
                {
                    mapGrids[index++] = new MapGridDetails(new Vector2Int(x, y), GetIdUsingPerlin(x, y));
                }
            }
            aStar = new AStar(MapSize.x, MapSize.y, MapLeftBottomPoint.x, MapLeftBottomPoint.y, mapGrids);

            //区域颜色
            sectionColor = new Color[4]
    {
                new Color(0,0,1,0.09f),
                new Color(0,1,0,0.09f),
                new Color(1,0,0,0.09f),
                new Color(0.5f,0,0.5f,0.09f),
    };
            plantGridPos = new HashSet<Vector2Int>();
        }

        public bool GetGrid(int x, int y, out MapGridDetails result)
        {
            result = mapGrids.ToList().Find(grid => grid.pos.x == x && grid.pos.y == y);
            return result != null;
        }

        private int GetIdUsingPerlin(int x, int y)
        {
            float rawPerlin = Mathf.PerlinNoise((float)x / MapSize.x * lacunarity + SeedToInt(), (float)y / MapSize.y * lacunarity + SeedToInt());
            float clamp_perlin = Mathf.Clamp(rawPerlin, 0, 1);
            float scale_perlin = clamp_perlin * layerCount;
            if (scale_perlin == layerCount)
            {
                scale_perlin = layerCount - 1;
            }
            return Mathf.FloorToInt(scale_perlin);
        }


        public Queue<Vector2Int> CalculatePath(Vector3 startPos, Vector3 endPos)
        {
            aStar.SetStartPos(startPos.WorldToCellXY().ClampInMap(this));
            aStar.SetEndPos(endPos.WorldToCellXY().ClampInMap(this));
            var path = aStar.CalculatePath(out var findPath);
            var outputPath = OutputPath(path, findPath);
            outputPath.TryDequeue(out var result);

            return outputPath;
        }

        private Queue<Vector2Int> OutputPath(Stack<Node> nodes, bool found)
        {
            Queue<Vector2Int> result = new Queue<Vector2Int>();
            while (nodes != null && nodes.Count > 0)
            {
                Node curNode = nodes.Pop();
                result.Enqueue(curNode.pos + new Vector2Int(aStar.originalX, aStar.originalY));
            }
            return result;
        }
    }

}
