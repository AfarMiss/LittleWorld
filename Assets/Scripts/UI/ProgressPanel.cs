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
    }

    private void OnPickFruit(PickFruitMessage message)
    {
        var screenPos = InputUtils.GetScreenPosition(message.pickFruitPos);
        var go = PoolManager.Instance.GetNextObject(PoolEnum.Progress.ToString());
        go.transform.position = screenPos;
        StartCoroutine(ChangeSlider(go));
    }

    private IEnumerator ChangeSlider(GameObject go)
    {
        float curProgress = 0;
        var gs = go.GetComponent<GeneralSlider>();
        while (gs.progress < 1)
        {
            yield return null;
            gs.progress = curProgress += 0.01f;
        }

        PoolManager.Instance.Putback(PoolEnum.Progress.ToString(), gs.gameObject);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<PickFruitMessage>(EventEnum.PICK_FRUIT.ToString(), OnPickFruit);
    }

    [SerializeField]
    private GameObject progressPrefab;
    public override string path => UIPath.Panel_ProgressPanel;

}
