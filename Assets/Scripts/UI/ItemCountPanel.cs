using LittleWorld;
using LittleWorld.MapUtility;
using LittleWorld.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using UnityEngine;

namespace LittleWorld.UI
{
    public class ItemCountPanel : BaseUI
    {
        public override string Path => UIPath.Panel_ProgressPanel;
        [SerializeField]
        private GameObject itemCountPrefab;
        private Dictionary<Vector2Int, GameObject> itemCountDic;
        private void Start()
        {
            itemCountDic = new Dictionary<Vector2Int, GameObject>();
            ObjectPoolManager.Instance.CreatePool(50, itemCountPrefab, PoolEnum.ItemCount.ToString(), transform);
        }

        private void LateUpdate()
        {
            if (Current.CurMap != null)
            {
                foreach (var item in Current.CurMap.mapGrids)
                {
                    SingleUpdate(item);
                }
            }
        }

        private void SingleUpdate(MapGridDetails item)
        {
            if (item.HasPiledThing)
            {
                if (!itemCountDic.ContainsKey(item.pos))
                {
                    var go = ObjectPoolManager.Instance.GetNextObject(PoolEnum.ItemCount.ToString());
                    go.GetComponent<ItemCount>().BindData(item.PiledAmount, item.pos);
                    go.transform.SetPositionAndRotation(item.pos.ToCellBottom().ToScreenPos(), transform.rotation);
                    itemCountDic.Add(item.pos, go);
                }
                else
                {
                    itemCountDic[item.pos].GetComponent<ItemCount>().BindData(item.PiledAmount, item.pos);
                    itemCountDic[item.pos].transform.SetPositionAndRotation(item.pos.ToCellBottom().ToScreenPos(), transform.rotation);
                    itemCountDic[item.pos].SetActive(true);
                }

            }
            else
            {
                if (itemCountDic.ContainsKey(item.pos))
                {
                    ObjectPoolManager.Instance.Putback(PoolEnum.ItemCount.ToString(), itemCountDic[item.pos]);
                    itemCountDic.Remove(item.pos);
                }
            }
        }
    }

}
