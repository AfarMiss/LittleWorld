
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenerateGUID))]
public class SceneItemsManager : MonoSingleton<SceneItemsManager>, ISaveable
{
    private Transform parentItem;
    [SerializeField]
    private GameObject itemPrefab = null;

    private string iSaveableUniqueID;
    public string ISaveableUniqueID { get => iSaveableUniqueID; set => iSaveableUniqueID = value; }
    private GameObjectSave gameObjectSave;
    public GameObjectSave GameObjectSave { get => gameObjectSave; set => gameObjectSave = value; }

    protected override void Awake()
    {
        base.Awake();

        ISaveableUniqueID = GetComponent<GenerateGUID>().GUID;
        GameObjectSave = new GameObjectSave();
    }

    private void OnEnable()
    {
        ISaveableRegister();
        EventCenter.Instance?.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), AfterSceneLoad);
    }

    private void OnDisable()
    {
        ISaveableDeregister();
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), AfterSceneLoad);
    }

    private void AfterSceneLoad()
    {
        parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParentTransform).transform;
    }

    public void ISaveableDeregister()
    {
        SaveLoadManager.Instance?.iSaveableObjectList.Remove(this);
    }

    public void ISaveableRegister()
    {
        SaveLoadManager.Instance?.iSaveableObjectList.Add(this);
    }

    public void ISaveableRestoreScene(string sceneName)
    {
        if (GameObjectSave.sceneData.TryGetValue(sceneName, out SceneSave sceneSave))
        {
            if (sceneSave.sceneItemList != null)
            {
                DestroySceneItems();
                InstantiateSceneItems(sceneSave.sceneItemList);
            }
        }
    }

    private void InstantiateSceneItems(List<SceneItem> sceneItemList)
    {
        GameObject itemGameObject;

        foreach (var item in sceneItemList)
        {
            itemGameObject = InstantiateSingleSceneItem(item);
        }
    }

    private GameObject InstantiateSingleSceneItem(SceneItem item)
    {
        GameObject itemGameObject = Instantiate(itemPrefab, new Vector3(item.position.x, item.position.y, item.position.z), Quaternion.identity, parentItem);
        Item itemComponent = itemGameObject.GetComponent<Item>();
        itemComponent.ItemCode = item.itemCode;
        itemComponent.name = item.itemName;
        return itemGameObject;
    }

    public void InstantiateSingleSceneItem(int itemCode, Vector3 itemPosition)
    {
        GameObject itemGameObject = Instantiate(itemPrefab, itemPosition, Quaternion.identity, parentItem);
        Item itemComponent = itemGameObject.GetComponent<Item>();
        itemComponent.Init(itemCode);
    }

    private void DestroySceneItems()
    {
        Item[] itemsInScene = GameObject.FindObjectsOfType<Item>();
        for (int i = itemsInScene.Length - 1; i >= 0; i--)
        {
            Destroy(itemsInScene[i].gameObject);
        }
    }

    public void ISaveableStoreScene(string sceneName)
    {
        //删除旧数据
        GameObjectSave.sceneData.Remove(sceneName);

        //保存新数据
        List<SceneItem> sceneItemList = new List<SceneItem>();
        Item[] itemsInScene = FindObjectsOfType<Item>();

        foreach (var item in itemsInScene)
        {
            SceneItem sceneItem = new SceneItem();
            sceneItem.itemCode = item.ItemCode;
            sceneItem.position = new Vector3Serializable(item.transform.position);
            sceneItem.itemName = item.name;

            sceneItemList.Add(sceneItem);
        }

        SceneSave sceneSave = new SceneSave();
        sceneSave.sceneItemList = sceneItemList;

        GameObjectSave.sceneData.Add(sceneName, sceneSave);
    }
}
