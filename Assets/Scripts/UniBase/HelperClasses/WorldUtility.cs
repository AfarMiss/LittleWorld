using LittleWorldObject;
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
            var itemsAtPos = allItemsInfo.FindAll(x => screenRect.ScreenContainsWorldPos(x.gridPos));
            return itemsAtPos.ToArray();
        }

        public static Vector3Int WorldToCell(this Vector3 worldPos)
        {
            Grid grid = GameObject.FindObjectOfType<Grid>();
            return grid.WorldToCell(worldPos);
        }
    }
}
