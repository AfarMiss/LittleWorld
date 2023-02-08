
using LittleWorld.Item;
using LittleWorld.Extension;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using LittleWorld;

public class SceneObjectManager : MonoSingleton<SceneObjectManager>, ISaveable
{
    public static int ItemInstanceID;
    private Transform parentItem;
    [SerializeField]
    private GameObject itemPrefab;
    [SerializeField]
    public GameObject ghostPrefab;

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
    public Dictionary<int, WorldObject> WorldObjects = new Dictionary<int, WorldObject>();
    public Dictionary<LittleWorld.Item.Object, ItemRender> WorldItemsRenderer = new Dictionary<LittleWorld.Item.Object, ItemRender>();

    public void RegisterItem(WorldObject worldObject)
    {
        WorldObjects.Add(worldObject.instanceID, worldObject);
        RenderItem(worldObject);
    }

    public void UnregisterItem(WorldObject worldObject)
    {
        if (WorldObjects.Values.Contains(worldObject))
        {
            DisRenderItem(worldObject);
            WorldObjects.Remove(worldObject.instanceID);
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
        new Humanbeing(ObjectCode.humanbeing.ToInt(), new Vector2Int(25, 25));
        new Plant(10001, new Vector2Int(2, 3));
        new Plant(10001, Vector2Int.one);
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
                //InstantiateSceneItems(sceneSave.sceneItemList);
            }
        }
    }

    private void RenderPawn(Humanbeing human)
    {
        GameObject pawnRes = Resources.Load<GameObject>("Prefabs/Character/Pawn");
        GameObject curPawn = GameObject.Instantiate<GameObject>(pawnRes);
        curPawn.GetComponent<Transform>().transform.position = human.GridPos.To3();
        curPawn.GetComponent<PathNavigation>().Initialize(human.instanceID);
        human.SetNavi(curPawn.GetComponent<PathNavigation>());
        human.rendererObject = curPawn;
        WorldItemsRenderer.Add(human, curPawn.GetComponent<ItemRender>());
    }

    private void RenderItem(WorldObject wo)
    {
        if (!(wo is Humanbeing))
        {
            GameObject itemGameObject = Instantiate(itemPrefab, wo.GridPos.To3(), Quaternion.identity, parentItem);
            ItemRender itemComponent = itemGameObject.GetComponent<ItemRender>();
            wo.rendererObject = itemGameObject;
            WorldItemsRenderer.Add(wo, itemComponent);
        }
        else
        {
            RenderPawn(wo as Humanbeing);
        }
    }

    public void DisRenderItem(WorldObject wo)
    {
        WorldItemsRenderer.TryGetValue(wo, out var renderer);
        if (renderer != null)
        {
            Destroy(renderer.gameObject);
            wo.rendererObject = null;
        }
        WorldItemsRenderer.Remove(wo);
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
        WorldObjects.TryGetValue(instanceID, out var go);
        return go;
    }

    public void InitBuildingGhost()
    {

    }

    public void AddBuildingGhostToManager(int buildingCode)
    {

    }

    public void Tick(GameTime gameTime)
    {
        pawnManager.Tick();
        foreach (var item in WorldObjects.ToList())
        {
            item.Value.Tick();
            if (WorldItemsRenderer.TryGetValue(item.Value, out var renderer))
            {
                renderer.Render(item.Value);
            }
        }
    }
}
