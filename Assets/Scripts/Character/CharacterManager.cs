using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoSingleton<CharacterManager>, ISaveable
{
    [SerializeField]
    private GameObject characterPrefab = null;
    private string iSaveableUniqueID;
    public string ISaveableUniqueID { get => iSaveableUniqueID; set => iSaveableUniqueID = value; }

    private GameObjectSave gameObjectSave;
    public GameObjectSave GameObjectSave { get => gameObjectSave; set => gameObjectSave = value; }

    public void ISaveableDeregister()
    {
        SaveLoadManager.Instance?.iSaveableObjectList.Remove(this);
    }



    public void ISaveableRegister()
    {
        SaveLoadManager.Instance?.iSaveableObjectList.Add(this);
    }

    public void ISaveableLoad(GameSave gameSave)
    {
        if (gameSave.gameObjectData.TryGetValue(ISaveableUniqueID, out GameObjectSave gameObjectSave))
        {
            GameObjectSave = gameObjectSave;
            ISaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }

    public GameObjectSave ISaveableSave()
    {
        ISaveableStoreScene(SceneManager.GetActiveScene().name);
        return gameObjectSave;
    }

    public void ISaveableRestoreScene(string sceneName)
    {
        if (GameObjectSave.sceneData.TryGetValue(sceneName, out SceneSave sceneSave))
        {
            if (sceneSave.sceneItemList != null)
            {
                DestroySceneItems();
                InstantiateSceneItems(sceneSave.characters);
            }
        }
    }

    private void InstantiateSceneItems(PathNavigationOnly[] characters)
    {
        foreach (var character in characters)
        {
            //TODO
            Instantiate(characterPrefab);
        }
    }

    public void ISaveableStoreScene(string sceneName)
    {
        GameObjectSave.sceneData.Remove(sceneName);

        SceneSave sceneSave = new SceneSave();
        sceneSave.characters = FindObjectsOfType<PathNavigationOnly>();
        GameObjectSave.sceneData.Add(sceneName, sceneSave);
    }

    private void DestroySceneItems()
    {
        PathNavigationOnly[] itemsInScene = GameObject.FindObjectsOfType<PathNavigationOnly>();
        for (int i = itemsInScene.Length - 1; i >= 0; i--)
        {
            Destroy(itemsInScene[i].gameObject);
        }
    }
}
