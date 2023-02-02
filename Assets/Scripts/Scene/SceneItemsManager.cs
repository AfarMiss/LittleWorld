
using LittleWorld.Item;
using LittleWorld.Extension;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using LittleWorld;

public class SceneItemsManager : MonoSingleton<SceneItemsManager>, ISaveable
{
    public static int ItemInstanceID;
    private Transform parentItem;
    [SerializeField]
    private GameObject itemPrefab;
    public List<SceneItem> sceneItemList
    {
        get
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
    }
    public Dictionary<int, WorldObject> worldItems = new Dictionary<int, WorldObject>();
    public Dictionary<LittleWorld.Item.Object, ItemRender> worldItemsRenderer = new Dictionary<LittleWorld.Item.Object, ItemRender>();

    public void RegisterItem(WorldObject worldObject)
    {
        worldItems.Add(worldObject.instanceID, worldObject);
        RenderItem(worldObject);
    }

    public void UnregisterItem(WorldObject worldObject)
    {
        if (worldItems.Values.Contains(worldObject))
        {
            DisRenderItem(worldObject);
            worldItems.Remove(worldObject.instanceID);
        }
    }

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
        var curHuman = new Humanbeing(Vector2Int.zero);
        var brush1 = new Plant(10001, new Vector2Int(2, 3));
        var brush2 = new Plant(10001, Vector2Int.one);

        pawnManager.AddPawn(curHuman);

    }

    private void OnDestroy()
    {
    }

    private void OnEnable()
    {
        ISaveableRegister();
        EventCenter.Instance?.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), AfterSceneLoad);
        EventCenter.Instance.Register<GameTime>((nameof(EventEnum.GAME_TICK)), Tick);
    }

    private void OnDisable()
    {
        ISaveableDeregister();
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), AfterSceneLoad);
    }

    private void AfterSceneLoad()
    {
        parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParentTransform.ToString())?.transform;
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

    private void RenderItem(WorldObject wo)
    {
        GameObject itemGameObject = Instantiate(itemPrefab, wo.GridPos.To3(), Quaternion.identity, parentItem);
        ItemRender itemComponent = itemGameObject.GetComponent<ItemRender>();
        worldItemsRenderer.Add(wo, itemComponent);
    }

    public void DisRenderItem(WorldObject wo)
    {
        worldItemsRenderer.TryGetValue(wo, out var go);
        if (go != null)
        {
            Destroy(go);
        }
        worldItemsRenderer.Remove(wo);
    }

    public void ISaveableStoreScene(string sceneName)
    {
        //删除旧数据
        GameObjectSave.sceneData.Remove(sceneName);

        SceneSave sceneSave = new SceneSave();
        sceneSave.sceneItemList = sceneItemList;

        GameObjectSave.sceneData.Add(sceneName, sceneSave);
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
        worldItems.TryGetValue(instanceID, out var go);
        return go;
    }

    public void Tick(GameTime gameTime)
    {
        pawnManager.Tick();
        foreach (var item in worldItems.ToList())
        {
            item.Value.Tick();
            worldItemsRenderer[item.Value].Render(item.Value);
        }
    }
}
