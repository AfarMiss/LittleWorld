
using LittleWorld.Object;
using LittleWorld.Extension;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class SceneItemsManager : MonoSingleton<SceneItemsManager>, ISaveable
{
    public static int ItemInstanceID;
    private Transform parentItem;
    [SerializeField]
    private GameObject itemPrefab = null;
    public List<SceneItem> sceneItemList;
    public List<WorldObject> worldItems;

    public PawnManager pawnManager;

    private string iSaveableUniqueID;
    public string ISaveableUniqueID { get => iSaveableUniqueID; set => iSaveableUniqueID = value; }
    private GameObjectSave gameObjectSave;
    public GameObjectSave GameObjectSave { get => gameObjectSave; set => gameObjectSave = value; }

    protected override void Awake()
    {
        base.Awake();

        ItemInstanceID = 0;
        ISaveableUniqueID = gameObject.GetOrAddComponent<GenerateGUID>().GUID;
        GameObjectSave = new GameObjectSave();
        pawnManager = PawnManager.Instance;

        //测试代码
        var curHuman = new Humanbeing(Vector3Int.zero);
        pawnManager.AddPawn(curHuman);
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
        parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParentTransform.ToString())?.transform;
        sceneItemList = CreateNewItemList();
        worldItems = CreateNewWorldItemsList(sceneItemList);
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
        ItemRender itemComponent = itemGameObject.GetComponent<ItemRender>();
        itemComponent.ItemCode = item.itemCode;
        itemComponent.name = item.itemName;
        return itemGameObject;
    }

    public void InstantiateSingleSceneItem(int itemCode, Vector3 itemPosition)
    {
        GameObject itemGameObject = Instantiate(itemPrefab, itemPosition, Quaternion.identity, parentItem);
        ItemRender itemComponent = itemGameObject.GetComponent<ItemRender>();
        itemComponent.Init(itemCode);
    }

    private void DestroySceneItems()
    {
        ItemRender[] itemsInScene = GameObject.FindObjectsOfType<ItemRender>();
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
        sceneItemList = CreateNewItemList();

        SceneSave sceneSave = new SceneSave();
        sceneSave.sceneItemList = sceneItemList;

        GameObjectSave.sceneData.Add(sceneName, sceneSave);
    }

    private List<SceneItem> CreateNewItemList()
    {
        List<SceneItem> sceneItemList = new List<SceneItem>();
        ItemRender[] itemsInScene = FindObjectsOfType<ItemRender>();

        foreach (var item in itemsInScene)
        {
            SceneItem sceneItem = new SceneItem();
            sceneItem.itemCode = item.ItemCode;
            sceneItem.position = new Vector3Serializable(item.transform.position);
            sceneItem.itemName = item.name;

            sceneItemList.Add(sceneItem);
        }

        return sceneItemList;
    }

    private List<WorldObject> CreateNewWorldItemsList(List<SceneItem> sceneItems)
    {
        List<WorldObject> worldItems = new List<WorldObject>();
        foreach (var item in sceneItems)
        {
            switch (item.itemCode)
            {
                case 10025:
                    worldItems.Add(new Brush((Vector3Int)item.position));
                    break;
                default:
                    break;
            }
        }

        foreach (var pawn in pawnManager.Pawns)
        {
            worldItems.Add(pawn);
        }

        return worldItems;
    }

    public GameObjectSave ISaveableSave()
    {
        ISaveableStoreScene(SceneManager.GetActiveScene().name);
        return GameObjectSave;
    }

    public void ISaveableLoad(GameSave gameSave)
    {
        if (gameSave.gameObjectData.TryGetValue(ISaveableUniqueID, out GameObjectSave gameObjectSave))
        {
            GameObjectSave = gameObjectSave;
            ISaveableRestoreScene(SceneManager.GetActiveScene().name);
        }
    }

    public WorldObject GetWorldObjectById(int instanceID)
    {
        return worldItems.Find(x => x.instanceID == instanceID);
    }

    private void Update()
    {
        pawnManager.Tick();
    }
}
