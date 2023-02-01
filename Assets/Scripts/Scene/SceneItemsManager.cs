
using LittleWorld.Item;
using LittleWorld.Extension;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public HashSet<WorldObject> worldItems = new HashSet<WorldObject>();
    public Dictionary<LittleWorld.Item.Object, GameObject> worldItemsRenderer = new Dictionary<LittleWorld.Item.Object, GameObject>();

    public void RegisterItem(WorldObject worldObject)
    {
        worldItems.Add(worldObject);
    }

    public void UnregisterItem(WorldObject worldObject)
    {
        if (worldItems.Contains(worldObject))
        {
            DisRenderItem(worldObject);
            worldItems.Remove(worldObject);
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
        var brush1 = new Plant(10023, new Vector2Int(2, 3));
        var brush2 = new Plant(10023, Vector2Int.one);
        RenderItem(brush1);
        RenderItem(brush2);

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

    public void RenderItem(int itemCode, Vector3 itemPosition)
    {
        GameObject itemGameObject = Instantiate(itemPrefab, itemPosition, Quaternion.identity, parentItem);
        ItemRender itemComponent = itemGameObject.GetComponent<ItemRender>();
        itemComponent.Init(itemCode);
    }

    public void RenderItem(WorldObject wo)
    {
        GameObject itemGameObject = Instantiate(itemPrefab, wo.GridPos.To3(), Quaternion.identity, parentItem);
        ItemRender itemComponent = itemGameObject.GetComponent<ItemRender>();
        itemComponent.Init(wo.itemCode);
        worldItemsRenderer.Add(wo, itemGameObject);
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
        return worldItems.ToList().Find(x => x.instanceID == instanceID);
    }

    private void Update()
    {
        pawnManager.Tick();
    }
}
