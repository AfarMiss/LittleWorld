using System;
using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;

public class ProgressPanel : BaseUI
{
    private void OnEnable()
    {
        EventCenter.Instance.Register<PickFruitMessage>(EventEnum.PICK_FRUIT.ToString(), OnPickFruit);
    }

    private void OnPickFruit(PickFruitMessage message)
    {
        var screenPos = InputUtils.GetScreenPosition(message.pickFruitPos);
        var go = Instantiate(progressPrefab, screenPos, Quaternion.identity, transform);
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
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<PickFruitMessage>(EventEnum.PICK_FRUIT.ToString(), OnPickFruit);
    }

    [SerializeField]
    private GameObject progressPrefab;
    public override string path => UIPath.Panel_ProgressPanel;

}
