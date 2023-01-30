using LittleWorld.MapUtility;
using LittleWorld.Object;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using Unity.Mathematics;
using UnityEngine;

namespace LittleWorld
{
    public static class WorldUtility
    {
        public static WorldObject[] GetWorldObjectsAt(Vector3 pos)
        {
            var allItemsInfo = SceneItemsManager.Instance.worldItems;
            var itemsAtPos = allItemsInfo.FindAll(x => x.GridPos == pos.WorldToCell());
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
