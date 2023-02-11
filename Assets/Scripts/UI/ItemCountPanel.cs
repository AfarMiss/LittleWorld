using LittleWorld;
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

        private static void Putback(WorkMessage arg0)
        {
            var needPutbackSlider = FindObjectsOfType<GeneralSlider>().ToList()
                .Find(x => x.uniqueID == arg0.workID.GetHashCode());
            if (needPutbackSlider != null)
            {
                PoolManager.Instance.Putback(PoolEnum.Progress.ToString(), needPutbackSlider.gameObject);
            }
        }

        private void LateUpdate()
        {
            foreach (var item in Current.CurMap.mapGrids)
            {
                if (item.HasPiledThing)
                {
                    if (!itemCountDic.ContainsKey(item.pos))
                    {
                        var go = PoolManager.Instance.GetNextObject(PoolEnum.ItemCount.ToString());
                        go.GetComponent<ItemCount>().BindData(item.PiledThingLength, item.pos.To3());
                        go.transform.SetPositionAndRotation(item.pos.ToCellBottom().ToScreenPos(), transform.rotation);
                        itemCountDic.Add(item.pos, go);
                    }
                    else
                    {
                        var go = itemCountDic[item.pos];
                        go.GetComponent<ItemCount>().BindData(item.PiledThingLength, item.pos.To3());
                        go.transform.SetPositionAndRotation(item.pos.ToCellBottom().ToScreenPos(), transform.rotation);
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

}
