using AStarUtility;
using LittleWorld.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
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
        public Dictionary<int, MapSection> sectionDic;
        private HashSet<Vector2Int> plantHash;
        public Color[] sectionColor;
        private int selectedSectionID;
        public int sectionColorSeed = 0;
        public int SelectedSectionID { get => selectedSectionID; }

        public void ChangeCurrentSection(MapSection section)
        {
            if (sectionDic.Values.Contains(section))
            {
                selectedSectionID = section.sectionID;
                Debug.Log("selectedSectionID:" + Current.CurMap.SelectedSectionID);
                Debug.Log("sectionCount:" + Current.CurMap.sectionDic.Count);
            }
        }

        public bool DropDownWorldObjectAt(Vector2Int posReference, WorldObject wo)
        {
            var targetGrid = GetGrid(posReference);
            if (!targetGrid.AddSinglePiledWorldObject(wo))
            {
                TryGetGrid(new Vector2Int(posReference.x + 1, posReference.y), out var neighbour1);
                if (neighbour1 != null && DropDownWorldObjectAt(new Vector2Int(posReference.x + 1, posReference.y), wo))
                {
                    return true;
                }
                TryGetGrid(new Vector2Int(posReference.x, posReference.y + 1), out var neighbour2);
                if (neighbour2 != null && DropDownWorldObjectAt(new Vector2Int(posReference.x, posReference.y + 1), wo))
                {
                    return true;
                }
                TryGetGrid(new Vector2Int(posReference.x - 1, posReference.y), out var neighbour3);
                if (neighbour3 != null && DropDownWorldObjectAt(new Vector2Int(posReference.x - 1, posReference.y), wo))
                {
                    return true;
                }
                TryGetGrid(new Vector2Int(posReference.x, posReference.y - 1), out var neighbour4);
                if (neighbour4 != null && DropDownWorldObjectAt(new Vector2Int(posReference.x, posReference.y - 1), wo))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool AddBlueprintObjectAt(Vector2Int pos, WorldObject wo)
        {
            var targetGrid = GetGrid(pos);
            return targetGrid.AddSingleBlueprintWorldObject(wo);
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
            var section = sectionDic[SelectedSectionID];
            foreach (var item in gridIndexs)
            {
                var result = section.grids.Find(x => x == item);
                if (result == null && !plantHash.Contains(item.pos) && item.isLand)
                {
                    section.grids.Add(item);
                    plantHash.Add(item.pos);
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
            foreach (var section in sectionDic)
            {
                foreach (var item in gridIndexs)
                {
                    var result = section.Value.grids.Find(x => x == item);
                    if (result != null)
                    {
                        section.Value.grids.Remove(result);
                        plantHash.Remove(result.pos);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return true;
        }

        public void DeleteSection(MapSection section)
        {
            foreach (var item in section.grids)
            {
                plantHash.Remove(item.pos);
            }
            sectionDic.Remove(section.sectionID);
        }

        public bool DeleteSection()
        {
            try
            {
                if (selectedSectionID < 0)
                {
                    Debug.LogWarning("Has no section!");
                    return false;
                }
                var mapSection = sectionDic[SelectedSectionID];
                DeleteSection(mapSection);
                selectedSectionID = -1;
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
            var mapGridDetails = new List<MapGridDetails>();
            foreach (var item in gridIndexs)
            {
                if (plantHash.Contains(item.pos) || !item.isLand)
                {
                    continue;
                }
                else
                {
                    mapGridDetails.Add(item);
                    plantHash.Add(item.pos);
                }
            }
            if (mapGridDetails.Count == 0)
            {
                return false;
            }
            sectionColorSeed = (++sectionColorSeed) % MaterialDatabase.Instance.PlantZoomMaterials.Length;
            MapSection newSection;
            switch (type)
            {
                case SectionType.PLANT:
                    newSection = new PlantMapSection(mapGridDetails, sectionColorSeed);
                    sectionDic.Add(newSection.sectionID, newSection);
                    ChangeCurrentSection(newSection);
                    break;
                case SectionType.STORE:
                    newSection = new StorageMapSection(mapGridDetails, sectionColorSeed);
                    sectionDic.Add(newSection.sectionID, newSection);
                    ChangeCurrentSection(newSection);
                    break;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 总海拔为0-100
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
            this.sectionDic = new Dictionary<int, MapSection>();
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
            plantHash = new HashSet<Vector2Int>();
        }

        public void GenerateInitObjects()
        {
            GenerateInitObjects(this.MapSize);
        }

        private void GenerateInitObjects(Vector2Int MapSize)
        {
            for (int x = 0; x < MapSize.x; x++)
            {
                for (int y = 0; y < MapSize.y; y++)
                {
                    //5%的概率随机生成陆地中的树木
                    if (mapGrids[x * MapSize.y + y].isPlane)
                    {
                        if ((UnityEngine.Random.Range(0, 99) < 5))
                        {
                            new Plant(
                                   UnityEngine.Random.Range(0, 1f) < 0.5f ? 10027 : 10028,
                                   new Vector2Int(x, y),
                                   UnityEngine.Random.Range(0, 16)
                                   );
                        }
                    }
                    //以1%的概率随机生成高山中的矿石
                    if (mapGrids[x * MapSize.y + y].isMountain)
                    {
                        if ((UnityEngine.Random.Range(0, 99) < 20))
                        {
                            new Ore(
                                   UnityEngine.Random.Range(0, 1f) < 0.5f ? 16001 : 16002,
                                   new Vector2Int(x, y)
                                   );
                        }
                        //剩余部分全部生成花岗岩石
                        else
                        {
                            new Ore(
                                    16003,
                                    new Vector2Int(x, y)
                                    );
                        }
                    }
                }
            }

        }

        public bool GetGrid(int x, int y, out MapGridDetails result)
        {
            result = mapGrids.ToList().Find(grid => grid.pos.x == x && grid.pos.y == y);
            return result != null;
        }

        public MapGridDetails TryGetGrid(int x, int y)
        {
            var result = mapGrids.ToList().Find(grid => grid.pos.x == x && grid.pos.y == y);
            return result;
        }

        public bool TryGetGrid(Vector2Int pos, out MapGridDetails result)
        {
            result = mapGrids.ToList().Find(grid => grid.pos == pos);
            return result != null;
        }

        public IEnumerable<Vector2Int> GetLandGridsAroundSquareIEnumerable(Vector2Int center, int radius)
        {
            for (int i = center.x - radius; i < center.x + radius; i++)
            {
                for (int j = center.y; j < center.y + radius; j++)
                {
                    if (GetGrid(i, j, out MapGridDetails result))
                    {
                        yield return result.pos;
                    }
                }
            }
        }

        public List<Vector2Int> GetLandGridsAroundSquare(Vector2Int center, int radius)
        {
            var list = new List<Vector2Int>();
            for (int i = center.x - radius; i < center.x + radius; i++)
            {
                for (int j = center.y; j < center.y + radius; j++)
                {
                    if (GetGrid(i, j, out MapGridDetails result) && result.isLand)
                    {
                        list.Add(result.pos);
                    }
                }
            }
            return list;
        }

        public MapGridDetails GetGrid(Vector2Int pos)
        {
            return mapGrids[pos.x * MapSize.y + pos.y];
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
