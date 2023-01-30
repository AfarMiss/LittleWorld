using LittleWorld.MapUtility;
using LittleWorld.Item;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using Unity.Mathematics;
using UnityEngine;
using Unity.VisualScripting;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

namespace LittleWorld
{
    public static class WorldUtility
    {
        public static Item.Object[] GetWorldObjectsAt(Vector3 pos)
        {
            List<Item.Object> itemsAtPos = new List<Item.Object>();

            var worldGridPos = pos.WorldToCell();
            var allItemsInfo = SceneItemsManager.Instance.worldItems;
            itemsAtPos.AddRange(allItemsInfo.FindAll(x => x.GridPos == worldGridPos));

            var allSection = Current.CurMap.sectionDic.Values.ToList();
            MapSection atSection = allSection.Find(x => x.GridPosList.Contains(worldGridPos.To2()));
            itemsAtPos.Add(atSection);

            return itemsAtPos.ToArray();
        }

        public static WorldObject[] GetWorldObjectsInRect(Rect worldRect)
        {
            var mapGrids = Current.CurMap.mapGrids.ToList().FindAll(x => x.gridRect.Overlaps(worldRect));
            var allItemsInfo = SceneItemsManager.Instance.worldItems;
            if (allItemsInfo == null)
            {
                return null;
            }
            HashSet<Vector2Int> poses = new HashSet<Vector2Int>();
            foreach (var item in mapGrids)
            {
                poses.Add(item.pos);
            }
            var itemsAtPos = allItemsInfo.FindAll(x => poses.Contains(x.GridPos.To2()));
            return itemsAtPos.ToArray();
        }

        public static MapSection GetSectionsInRect(Rect worldRect)
        {
            //先判断是否是单击
            var mapGrids = Current.CurMap.mapGrids.ToList().FindAll(x => x.gridRect.Overlaps(worldRect));
            if (mapGrids.Count != 1)
            {
                return null;
            }
            var sectionDic = Current.CurMap.sectionDic;
            if (sectionDic == null)
            {
                return null;
            }

            foreach (var item in sectionDic)
            {
                if (item.Value.GridPosList.Contains(mapGrids[0].pos))
                {
                    return item.Value;
                }
            }
            return null;

        }

        public static Vector3Int WorldToCell(this Vector3 worldPos)
        {
            Grid grid = GameObject.FindObjectOfType<Grid>();
            return grid.WorldToCell(worldPos);
        }

        public static Vector2Int WorldToCellXY(this Vector3 worldPos)
        {
            Grid grid = GameObject.FindObjectOfType<Grid>();
            var cellPos = grid.WorldToCell(worldPos);

            return new Vector2Int(cellPos.x, cellPos.y);
        }

        public static Vector3 CellToWorld(this Vector3Int cellPos)
        {
            Grid grid = GameObject.FindObjectOfType<Grid>();
            return grid.CellToWorld(cellPos);
        }
    }
}
