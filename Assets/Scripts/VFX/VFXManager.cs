using System;
using System.Collections;
using UnityEngine;

public class VFXManager : MonoSingleton<VFXManager>
{
    [SerializeField] private GameObject reapingEffect;
    [SerializeField] private GameObject deciduousEffect;
    [SerializeField] private GameObject choppingStump;
    [SerializeField] private GameObject pinecone;
    [SerializeField] private GameObject breakingStone;
    private void OnEnable()
    {
        this.EventRegister<Vector3, HarvestActionEffect>(EventEnum.VFX_HARVEST_ACTION_EFFECT.ToString(), OnHarvestActionEffect);
    }

    private void Start()
    {
    }

    private void OnHarvestActionEffect(Vector3 arg0, HarvestActionEffect arg1)
    {
        CreateVFX(arg1, arg0);
    }

    private void CreateVFX(HarvestActionEffect effect, Vector3 arg0)
    {
        var reap = ObjectPoolManager.Instance.GetNextObject(effect.ToString());
        reap.transform.position = arg0;
        StartCoroutine(StartReapVFX(reap, effect));
    }

    private IEnumerator StartReapVFX(GameObject obj, HarvestActionEffect effectType)
    {
        yield return new WaitForSeconds(2f);
        ObjectPoolManager.Instance.Putback(effectType.ToString(), obj);
    }
}
