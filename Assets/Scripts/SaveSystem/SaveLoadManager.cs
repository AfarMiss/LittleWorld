using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using LittleWorld.UI;

public class SaveLoadManager : MonoSingleton<SaveLoadManager>
{
    public List<ISaveable> iSaveableObjectList;
    private string saveName = "WildHopeCreek";

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

    /// <summary>
    /// 加载存档
    /// </summary>
    public void LoadDataFromFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (System.IO.File.Exists($"{Application.persistentDataPath}/{saveName}.dat"))
        {
            var gameSave = new GameSave();
            FileStream file = System.IO.File.Open($"{Application.persistentDataPath}/{saveName}.dat", FileMode.Open);
            gameSave = (GameSave)bf.Deserialize(file);

            for (int i = 0; i < iSaveableObjectList.Count; i++)
            {
                if (gameSave.gameObjectData.ContainsKey(iSaveableObjectList[i].ISaveableUniqueID))
                {
                    iSaveableObjectList[i].ISaveableLoad(gameSave);
                }
                else
                {
                    Component component = (Component)iSaveableObjectList[i];
                    Destroy(component.gameObject);
                }
            }

            file.Close();
        }

        UIManager.Instance.Hide<PausePanel>(UIType.PANEL);
    }

    /// <summary>
    /// 存储存档
    /// </summary>
    public void SaveDataToFile()
    {
        var gameSave = new GameSave();
        foreach (ISaveable saveable in iSaveableObjectList)
        {
            gameSave.gameObjectData.Add(saveable.ISaveableUniqueID, saveable.ISaveableSave());
        }

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = System.IO.File.Open($"{Application.persistentDataPath}/{saveName}.dat", FileMode.Create);

        bf.Serialize(file, gameSave);
        file.Close();

        UIManager.Instance.Hide<PausePanel>(UIType.PANEL);
    }
}
