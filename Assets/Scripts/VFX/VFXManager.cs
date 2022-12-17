using System;
using System.Collections;
using UnityEngine;

public class VFXManager : MonoSingleton<VFXManager>
{
    [SerializeField] private GameObject reapingEffect;
    [SerializeField] private GameObject deciduousEffect;
    [SerializeField] private GameObject choppingStump;
    [SerializeField] private GameObject pinecone;
    private void OnEnable()
    {
        EventCenter.Instance?.Register<Vector3, HarvestActionEffect>(EventEnum.VFX_HARVEST_ACTION_EFFECT.ToString(), OnHarvestActionEffect);
    }

    private void Start()
    {
        PoolManager.Instance.CreatePool(5, reapingEffect, HarvestActionEffect.reaping.ToString());
        PoolManager.Instance.CreatePool(5, deciduousEffect, HarvestActionEffect.deciduousLeavesFalling.ToString());
        PoolManager.Instance.CreatePool(5, choppingStump, HarvestActionEffect.choppingTreeTrunk.ToString());
        PoolManager.Instance.CreatePool(5, pinecone, HarvestActionEffect.pineConesFalling.ToString());
    }

    private void OnHarvestActionEffect(Vector3 arg0, HarvestActionEffect arg1)
    {
        CreateVFX(arg1, arg0);
    }

    private void CreateVFX(HarvestActionEffect effect, Vector3 arg0)
    {
        var reap = PoolManager.Instance.GetNextObject(effect.ToString());
        reap.transform.position = arg0;
        StartCoroutine(StartReapVFX(reap, effect));
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Register<Vector3, HarvestActionEffect>(EventEnum.VFX_HARVEST_ACTION_EFFECT.ToString(), OnHarvestActionEffect);
    }

    private IEnumerator StartReapVFX(GameObject obj, HarvestActionEffect effectType)
    {
        yield return new WaitForSeconds(2f);
        PoolManager.Instance.Putback(effectType.ToString(), obj);
    }
}
