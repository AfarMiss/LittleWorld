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
            PoolManager.Instance.CreatePool(50, itemCountPrefab, PoolEnum.ItemCount.ToString(), transform);
        }
        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void LateUpdate()
        {
            foreach (var item in Current.CurMap.mapGrids)
            {
                SingleUpdate(item);
            }
            //Current.CurMap.GetGrid(new Vector2Int(25, 25), out var testItem);
            //SingleUpdate(testItem);
        }

        private void SingleUpdate(MapGridDetails item)
        {
            if (item.HasPiledThing)
            {
                if (!itemCountDic.ContainsKey(item.pos))
                {
                    var go = PoolManager.Instance.GetNextObject(PoolEnum.ItemCount.ToString());
                    go.GetComponent<ItemCount>().BindData(item.PiledThingLength);
                    go.transform.SetPositionAndRotation(item.pos.ToCellBottom().ToScreenPos(), transform.rotation);
                    itemCountDic.Add(item.pos, go);
                }
                else
                {
                    itemCountDic[item.pos].GetComponent<ItemCount>().BindData(item.PiledThingLength);
                    itemCountDic[item.pos].transform.SetPositionAndRotation(item.pos.ToCellBottom().ToScreenPos(), transform.rotation);
                    //Debug.Log($"screenPos:{item.pos.ToCellBottom().ToScreenPos()}");
                }

            }
            else
            {
                if (itemCountDic.ContainsKey(item.pos))
                {
                    PoolManager.Instance.Putback(PoolEnum.ItemCount.ToString(), itemCountDic[item.pos]);
                }
            }
        }
    }

}
