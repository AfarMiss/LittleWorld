
using LittleWorld.Item;
using LittleWorld.Extension;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using LittleWorld.MapUtility;
using LittleWorld.Message;

public class SceneObjectManager : Singleton<SceneObjectManager>
{
    public static int ItemInstanceID;
    private GameObject itemPrefab;
    private GameObject pilePrefab;
    public GameObject ghostPrefab;
    private GameObject pawnRes;
    private GameObject renderParent;

    public List<SceneItem> sceneItemList
    {
        get
        {
            List<SceneItem> sceneItemList = new List<SceneItem>();
            ItemRender[] itemsInScene = GameObject.FindObjectsOfType<ItemRender>();

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
    public List<WorldObject> RequestAdd = new List<WorldObject>();
    public List<WorldObject> RequestDelete = new List<WorldObject>();
    private Dictionary<WorldObject, ItemRender> WorldItemsRenderer = new Dictionary<WorldObject, ItemRender>();
    private Dictionary<Vector2Int, PileInfo> WorldPileRenderer = new Dictionary<Vector2Int, PileInfo>();

    public void RegisterItem(WorldObject worldObject)
    {
        try
        {
            RequestAdd.Add(worldObject);
            AddRenderComponent(worldObject);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"{worldObject.ItemName}_{worldObject.itemCode}");
            Debug.LogError(e);
            throw;
        }
    }

    public void UnregisterItem(WorldObject worldObject)
    {
        if (WorldObjects.Values.Contains(worldObject))
        {
            DisRenderItem(worldObject);
            RequestDelete.Add(worldObject);
        }
    }

    public PawnManager pawnManager;

    public override void OnCreateInstance()
    {
        base.OnCreateInstance();
        EventCenter.Instance.Register<GameTime>(EventName.GAME_TICK, Tick);
        EventCenter.Instance.Register<ChangeGridMessage>(EventName.OBJECT_GRID_CHANGE, OnWorldObjectGridChange);

        ItemInstanceID = 0;
        pawnManager = PawnManager.Instance;
        itemPrefab = Resources.Load<GameObject>("Prefabs/Object/Item");
        pilePrefab = Resources.Load<GameObject>("Prefabs/Object/Pile");
        ghostPrefab = Resources.Load<GameObject>("Prefabs/Object/Ghost");
        pawnRes = Resources.Load<GameObject>("Prefabs/Character/Pawn");

        renderParent = new GameObject("RenderParent");
        GameObject.DontDestroyOnLoad(renderParent);
    }

    private void OnWorldObjectGridChange(ChangeGridMessage message)
    {
        if (message.wo.canPile)
        {
            AddRenderComponent(message.wo);
        }
    }

    private SceneObjectManager()
    {

    }

    private void AddRenderComponent(WorldObject wo)
    {
        if (wo is not Humanbeing)
        {
            if (!wo.canPile)
            {
                GameObject itemGameObject = GameObject.Instantiate(itemPrefab, wo.GridPos.To3(), Quaternion.identity, renderParent.transform);
                ItemRender itemComponent = itemGameObject.GetComponent<ItemRender>();
                WorldItemsRenderer.Add(wo, itemComponent);
            }
            else
            {
                if (!WorldPileRenderer.ContainsKey(wo.GridPos))
                {
                    GameObject itemGameObject = GameObject.Instantiate(pilePrefab, wo.GridPos.To3(), Quaternion.identity, renderParent.transform);
                    PileRenderer itemComponent = itemGameObject.GetComponent<PileRenderer>();
                    WorldPileRenderer.Add(wo.GridPos, new PileInfo(wo.itemCode, itemComponent, wo.mapBelongTo));
                }
            }
        }
        else
        {
            var human = wo as Humanbeing;
            GameObject curPawn = GameObject.Instantiate<GameObject>(pawnRes, renderParent.transform);
            curPawn.GetComponent<Transform>().transform.position = human.GridPos.To3();
            curPawn.GetComponent<PathNavigation>().Initialize(human.instanceID);
            human.SetNavi(curPawn.GetComponent<PathNavigation>());
            WorldItemsRenderer.Add(human, curPawn.GetComponent<ItemRender>());
        }
    }

    public void DisRenderItem(WorldObject wo)
    {
        if (wo.canPile)
        {
            WorldPileRenderer.TryGetValue(wo.GridPos, out var renderer);
            if (renderer != null)
            {
                if (wo.mapBelongTo.TryGetGrid(wo.GridPos, out var gridDetail)
                    && !gridDetail.HasPiledThing)
                {
                    GameObject.Destroy(renderer.pileRenderer.gameObject);
                    WorldPileRenderer.Remove(wo.GridPos);
                }
            }
        }
        else
        {
            WorldItemsRenderer.TryGetValue(wo, out var renderer);
            if (renderer != null)
            {
                GameObject.Destroy(renderer.gameObject);
            }
            WorldItemsRenderer.Remove(wo);
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
        foreach (var item in WorldObjects)
        {
            item.Value.Tick();
        }

        foreach (var item in WorldItemsRenderer)
        {
            item.Value.Render(item.Key);
        }

        foreach (var item in WorldPileRenderer)
        {
            item.Value.pileRenderer.Render(item.Value.pileCode, item.Key, item.Value.belongTo);
        }


        foreach (var item in RequestDelete)
        {
            WorldObjects.Remove(item.instanceID);
        }
        RequestDelete.Clear();

        foreach (var item in RequestAdd)
        {
            WorldObjects.Add(item.instanceID, item);
        }
        RequestAdd.Clear();
    }

    public void Init()
    {
        new Humanbeing(ObjectCode.humanbeing.ToInt(), new Vector2Int(25, 25));
    }
}

public class PileInfo
{
    public int pileCode;
    public PileRenderer pileRenderer;
    public Map belongTo;

    public PileInfo(int pileCode, PileRenderer pileRenderer, Map belongTo)
    {
        this.pileCode = pileCode;
        this.pileRenderer = pileRenderer;
        this.belongTo = belongTo;
    }
}
