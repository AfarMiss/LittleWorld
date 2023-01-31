using LittleWorld;
using LittleWorld.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using UnityEngine;

public class ProgressPanel : BaseUI
{
    private void Start()
    {
        PoolManager.Instance.CreatePool(10, progressPrefab, PoolEnum.Progress.ToString(), transform);
    }
    private void OnEnable()
    {
        EventCenter.Instance.Register<WorkMessage>(EventEnum.WORK_WORKING.ToString(), OnWorking);
        EventCenter.Instance.Register<WorkMessage>(EventEnum.WORK_DONE.ToString(), OnWorkDone);
        EventCenter.Instance.Register<WorkMessage>(EventEnum.FORCE_ABORT.ToString(), OnWorkForceAbort);
    }

    private void OnWorking(WorkMessage message)
    {
        var poolItem = PoolManager.Instance.Find<GameObject>(x =>
        x.poolInstance.GetComponent<GeneralSlider>() != null &&
        x.poolInstance.GetComponent<GeneralSlider>().uniqueID == message.worker.GetHashCode());

        if (message.showPercent)
        {
            var go = poolItem?.poolInstance;
            var screenPos = InputUtils.GetScreenPosition(message.workPos.To3());
            if (go == null)
            {
                go = PoolManager.Instance.GetNextObject(PoolEnum.Progress.ToString());
                go.transform.position = screenPos;
                go.GetComponent<GeneralSlider>().uniqueID = message.worker.GetHashCode();
                go.GetComponent<GeneralSlider>().sliderFollowPos = message.workPos.To3();
            }
            ChangeSlider(go, message);
        }
    }

    private void ChangeSlider(GameObject go, WorkMessage message)
    {
        var gs = go.GetComponent<GeneralSlider>();
        gs.progress = message.workPercent;
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<WorkMessage>(EventEnum.WORK_WORKING.ToString(), OnWorking);
        EventCenter.Instance?.Unregister<WorkMessage>(EventEnum.WORK_DONE.ToString(), OnWorkDone);
        EventCenter.Instance?.Unregister<WorkMessage>(EventEnum.FORCE_ABORT.ToString(), OnWorkForceAbort);
    }

    private void OnWorkDone(WorkMessage arg0)
    {
        Putback(arg0);
    }

    private void OnWorkForceAbort(WorkMessage arg0)
    {
        Putback(arg0);
    }

    private static void Putback(WorkMessage arg0)
    {
        var needPutbackSlider = FindObjectsOfType<GeneralSlider>().ToList()
            .Find(x => x.uniqueID == arg0.worker.GetHashCode());
        if (needPutbackSlider != null)
        {
            PoolManager.Instance.Putback(PoolEnum.Progress.ToString(), needPutbackSlider.gameObject);
        }
    }

    [SerializeField]
    private GameObject progressPrefab;
    public override string Path => UIPath.Panel_ProgressPanel;

}
