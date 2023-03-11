using LittleWorld.MapUtility;
using LittleWorld.Item;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.VisualScripting;
using UniBase;

namespace LittleWorld
{
    public static class WorldUtility
    {
        public static IEnumerable<Item.Object> GetObjectsAtCell(Vector3 worldPos)
        {
            var worldGridPos = worldPos.ToCell();
            var objectsSet = SceneObjectManager.Instance.WorldObjects.ToList().FindAll(x => x.Value.GridPos == worldPos.ToCell().To2());
            foreach (var item in objectsSet)
            {
                yield return item.Value;
            }

            var allSection = Current.CurMap.sectionDic.Values.ToList();
            if (allSection.Count > 0)
            {
                MapSection atSection = allSection.Find(x => x.GridPosList.Contains(worldGridPos.To2()));
                yield return atSection;
            }
        }

        /// <summary>
        /// 获取当前世界位置的物体(以渲染Rect为基准)
        /// </summary>
        /// <param name="worldPos"></param>
        /// <returns></returns>
        public static IEnumerable<Item.WorldObject> GetWorldObjectRenderersAt(Vector3 worldPos)
        {
            foreach (var item in SceneObjectManager.Instance.WorldObjects)
            {
                if (!item.Value.isDestroyed && item.Value.EntityRect.Contains(worldPos))
                {
                    //Debug.Log($"MousePos:{worldPos},WorldObjectRect{item.Value.EntityRect},WorldPos:{item.Value.GridPos}");
                    yield return item.Value;
                }
            }
        }

        public static IEnumerable<Item.Object> GetWorldObjectsAtMouse()
        {
            var currentWorldPos = Camera.main.ScreenToWorldPoint(Current.MousePos);
            var worldGridPos = currentWorldPos.ToCell();
            var allItemsInfo = SceneObjectManager.Instance.WorldObjects;
            var objectsSet = allItemsInfo.ToList().FindAll(x => x.Value.GridPos == worldGridPos.To2());
            foreach (var item in objectsSet)
            {
                yield return item.Value;
            }

            var allSection = Current.CurMap.sectionDic.Values.ToList();
            if (allSection.Count > 0)
            {
                MapSection atSection = allSection.Find(x => x.GridPosList.Contains(worldGridPos.To2()));
                yield return atSection;
            }
        }

        public static bool CheckOtherAnimalsAtMouse()
        {
            //检测是否在开火预备下悬停到了某一目标上
            var currentWorldPos = Camera.main.ScreenToWorldPoint(Current.MousePos);
            foreach (var item in GetWorldObjectRenderersAt(currentWorldPos))
            {
                if (item is Animal)
                {
                    return true;
                }
            }
            return false;
        }

        public static IEnumerable<Item.Object> GetWorldObjectsAt(Vector2Int pos)
        {
            return GetObjectsAtCell(pos.To3());
        }

        public static WorldObject[] GetWorldObjectsInRect(Rect worldRect)
        {
            var mapGrids = Current.CurMap.mapGrids.ToList().FindAll(x => x.gridRect.Overlaps(worldRect));
            var allItemsInfo = SceneObjectManager.Instance.WorldObjects;
            if (allItemsInfo == null)
            {
                return null;
            }
            HashSet<Vector2Int> poses = new HashSet<Vector2Int>();
            foreach (var item in mapGrids)
            {
                poses.Add(item.pos);
            }
            var itemsAtPos = allItemsInfo.ToList().FindAll(x => poses.Contains(x.Value.GridPos));
            var result = new List<WorldObject>();
            foreach (var item in itemsAtPos)
            {
                result.Add(item.Value);
            }
            return result.ToArray();
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
