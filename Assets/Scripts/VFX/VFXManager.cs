using System;
using System.Collections;
using UnityEngine;

public class VFXManager : MonoSingleton<VFXManager>
{
    [SerializeField] private GameObject reapingEffect;
    private void OnEnable()
    {
        EventCenter.Instance?.Register<Vector3, HarvestActionEffect>(EventEnum.VFX_HARVEST_ACTION_EFFECT.ToString(), OnHarvestActionEffect);
    }

    private void Start()
    {
        PoolManager.Instance.CreatePool(20, reapingEffect, HarvestActionEffect.reaping.ToString());
    }

    private void OnHarvestActionEffect(Vector3 arg0, HarvestActionEffect arg1)
    {
        switch (arg1)
        {
            case HarvestActionEffect.deciduousLeavesFalling:
                break;
            case HarvestActionEffect.pineConesFalling:
                break;
            case HarvestActionEffect.choppingTreeTrunk:
                break;
            case HarvestActionEffect.breakingStone:
                break;
            case HarvestActionEffect.reaping:
                var reap = PoolManager.Instance.GetNextObject(HarvestActionEffect.reaping.ToString());
                reap.transform.position = arg0;
                StartCoroutine(StartReapVFX(reap));
                break;
            case HarvestActionEffect.none:
                break;
            default:
                break;
        }
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Register<Vector3, HarvestActionEffect>(EventEnum.VFX_HARVEST_ACTION_EFFECT.ToString(), OnHarvestActionEffect);
    }

    private IEnumerator StartReapVFX(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        PoolManager.Instance.Putback(HarvestActionEffect.reaping.ToString(), obj);
    }
}
