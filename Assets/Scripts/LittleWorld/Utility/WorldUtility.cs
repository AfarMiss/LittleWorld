using LittleWorld.Object;
using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

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

        public static WorldObject[] GetWorldObjectsInRect(Rect screenRect)
        {
            var allItemsInfo = SceneItemsManager.Instance.worldItems;
            if (allItemsInfo == null)
            {
                return null;
            }
            var itemsAtPos = allItemsInfo.FindAll(x => screenRect.ScreenContainsWorldPos(x.GridPos));
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
