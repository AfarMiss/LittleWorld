using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoSingleton<SaveLoadManager>
{
    public List<ISaveable> iSaveableObjectList;

    protected override void Awake()
    {
        base.Awake();

        iSaveableObjectList = new List<ISaveable>();
    }

    public void StoreCurrentSceneData()
    {
        foreach (ISaveable saveable in iSaveableObjectList)
        {
            saveable.ISaveableStoreScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestoreCurrentSceneData()
    {
        foreach (ISaveable saveable in iSaveableObjectList)
        {
            saveable.ISaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }
}
