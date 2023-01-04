using System;
using System.Collections;
using System.Collections.Generic;
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
        EventCenter.Instance.Register<PickFruitMessage>(EventEnum.PICK_FRUIT.ToString(), OnPickFruit);
        EventCenter.Instance.Register<UnpickFruitMessage>(EventEnum.UNPICK_FRUIT.ToString(), OnUnpickFruit);
    }

    private void OnPickFruit(PickFruitMessage message)
    {
        var screenPos = InputUtils.GetScreenPosition(message.pickFruitPos);
        var go = PoolManager.Instance.GetNextObject(PoolEnum.Progress.ToString());
        go.transform.position = screenPos;
        StartCoroutine(ChangeSlider(go, message));
    }

    private IEnumerator ChangeSlider(GameObject go, PickFruitMessage message)
    {
        float curProgress = 0;
        var gs = go.GetComponent<GeneralSlider>();
        gs.instanceID = message.fruitID;
        while (gs.progress < 1)
        {
            yield return null;
            gs.progress = (curProgress += Time.deltaTime) / message.totalPickTime;
        }

        PoolManager.Instance.Putback(PoolEnum.Progress.ToString(), gs.gameObject);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<PickFruitMessage>(EventEnum.PICK_FRUIT.ToString(), OnPickFruit);
        EventCenter.Instance?.Unregister<UnpickFruitMessage>(EventEnum.UNPICK_FRUIT.ToString(), OnUnpickFruit);
    }

    private void OnUnpickFruit(UnpickFruitMessage arg0)
    {
        var sliders = GameObject.FindObjectsOfType<GeneralSlider>();
        foreach (var item in sliders)
        {
            if (item.instanceID == arg0.fruitID)
            {
                PoolManager.Instance.Putback(PoolEnum.Progress.ToString(), item.gameObject);
            }
        }
    }

    [SerializeField]
    private GameObject progressPrefab;
    public override string path => UIPath.Panel_ProgressPanel;

}
