﻿using LittleWorld;
using LittleWorld.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using UnityEngine;

namespace LittleWorld.UI
{
    public class ProgressPanel : BaseUI
    {
        private void Start()
        {
            ObjectPoolManager.Instance.CreatePool(10, progressPrefab, PoolEnum.Progress.ToString(), transform);
        }
        private void OnEnable()
        {
            this.EventRegister<WorkMessage>(EventEnum.WORK_WORKING.ToString(), OnWorking);
            this.EventRegister<WorkMessage>(EventEnum.WORK_DONE.ToString(), OnWorkDone);
            this.EventRegister<WorkAbortMessage>(EventEnum.FORCE_ABORT.ToString(), OnWorkForceAbort);
        }

        private void OnWorking(WorkMessage message)
        {
            var poolItem = ObjectPoolManager.Instance.Find<GameObject>(x =>
            x.poolInstance.GetComponent<GeneralSlider>() != null &&
            x.poolInstance.GetComponent<GeneralSlider>().uniqueID == message.workID.GetHashCode());

            if (message.showPercent)
            {
                var go = poolItem?.poolInstance;
                var screenPos = InputUtils.GetScreenPosition(message.workPos.To3());
                if (go == null)
                {
                    go = ObjectPoolManager.Instance.GetNextObject(PoolEnum.Progress.ToString());
                    go.transform.position = screenPos;
                    go.GetComponent<GeneralSlider>().uniqueID = message.workID.GetHashCode();
                    go.GetComponent<GeneralSlider>().sliderFollowPos = message.workPos.To3();
                }
                else
                {
                    if (!go.activeInHierarchy)
                    {
                        go.SetActive(true);
                        go.transform.position = screenPos;
                        go.GetComponent<GeneralSlider>().sliderFollowPos = message.workPos.To3();
                    }
                }
                ChangeSlider(go, message);
            }
        }

        private void ChangeSlider(GameObject go, WorkMessage message)
        {
            var gs = go.GetComponent<GeneralSlider>();
            gs.progress = message.workPercent;
        }

        private void OnWorkDone(WorkMessage arg0)
        {
            Putback(arg0);
        }

        private void OnWorkForceAbort(WorkAbortMessage arg0)
        {
            Putback(arg0);
        }

        private static void Putback(WorkMessage arg0)
        {
            var needPutbackSlider = FindObjectsOfType<GeneralSlider>().ToList()
                .Find(x => x.uniqueID == arg0.workID.GetHashCode());
            if (needPutbackSlider != null)
            {
                ObjectPoolManager.Instance.Putback(PoolEnum.Progress.ToString(), needPutbackSlider.gameObject);
            }
        }

        private static void Putback(WorkAbortMessage arg0)
        {
            var needPutbackSlider = FindObjectsOfType<GeneralSlider>().ToList()
                .Find(x => x.uniqueID == arg0.work.workID.GetHashCode());
            if (needPutbackSlider != null)
            {
                ObjectPoolManager.Instance.Putback(PoolEnum.Progress.ToString(), needPutbackSlider.gameObject);
            }
        }

        [SerializeField]
        private GameObject progressPrefab;
        public override string Path => UIPath.Panel_ProgressPanel;

    }

}
