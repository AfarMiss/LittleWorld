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
        private void Start()
        {
            PoolManager.Instance.CreatePool(10, itemCountPrefab, PoolEnum.Progress.ToString(), transform);
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

        private void Update()
        {
            PoolManager.Instance.PutbackAll(PoolEnum.Progress.ToString());
            foreach (var item in Current.CurMap.mapGrids)
            {
                if (item.HasPiledThing)
                {
                    PoolManager.Instance.GetNextObject(PoolEnum.Progress.ToString());
                }
            }
        }


    }

}
