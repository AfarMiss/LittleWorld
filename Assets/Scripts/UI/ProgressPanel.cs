using LittleWorld;
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
        EventCenter.Instance.Register<SingleWork>(EventEnum.WORK_WORKING.ToString(), OnWorking);
        EventCenter.Instance.Register<SingleWork>(EventEnum.WORK_DONE.ToString(), OnWorkDone);
    }

    private void OnWorking(SingleWork message)
    {
        var poolItem = PoolManager.Instance.Find<GameObject>(x =>
        x.poolInstance.GetComponent<GeneralSlider>() != null &&
        x.poolInstance.GetComponent<GeneralSlider>().uniqueID == message.uniqueKey);

        if (message.showPercent)
        {
            var go = poolItem?.poolInstance;
            var screenPos = InputUtils.GetScreenPosition(message.WorkPos);
            if (go == null)
            {
                go = PoolManager.Instance.GetNextObject(PoolEnum.Progress.ToString());
                go.transform.position = screenPos;
                go.GetComponent<GeneralSlider>().uniqueID = message.uniqueKey;
            }
            ChangeSlider(go, message);
        }
    }

    private void ChangeSlider(GameObject go, SingleWork message)
    {
        var gs = go.GetComponent<GeneralSlider>();
        if (message.workTotalAmount > 0)
        {
            gs.progress = (float)message.curFinishedAmount / message.workTotalAmount;
        }
        else
        {
            gs.progress = 1;
        }

    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<SingleWork>(EventEnum.WORK_WORKING.ToString(), OnWorking);
        EventCenter.Instance?.Unregister<SingleWork>(EventEnum.WORK_DONE.ToString(), OnWorkDone);
    }

    private void OnWorkDone(SingleWork arg0)
    {
        var activeObjects = FindObjectsOfType<GeneralSlider>();
        var needPutbackSlider = activeObjects.ToList<GeneralSlider>().Find(x => x.uniqueID == arg0.uniqueKey);
        if (needPutbackSlider != null)
        {
            PoolManager.Instance.Putback(PoolEnum.Progress.ToString(), needPutbackSlider.gameObject);
        }
    }

    [SerializeField]
    private GameObject progressPrefab;
    public override string path => UIPath.Panel_ProgressPanel;

}
