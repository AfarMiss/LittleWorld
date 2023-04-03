
using LittleWorld.Item;
using LittleWorld.Extension;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using LittleWorld.MapUtility;
using LittleWorld.Message;
using static LittleWorld.HealthTracer;
using NodeCanvas.Tasks.Actions;
using LittleWorld;
using FlowCanvas.Nodes;

public class SceneObjectManager : Singleton<SceneObjectManager>
{
    public static int ItemInstanceID;
    private GameObject renderParent;

    #region 预设
    private GameObject pfItem;
    private GameObject pfPile;
    public GameObject pfGhost;
    private GameObject pfAnimal;
    private GameObject pfBullet;
    private GameObject pfBulletEffect;
    #endregion

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
    private Dictionary<WorldObject, IRenderer> WorldItemsRenderer = new Dictionary<WorldObject, IRenderer>();
    private Dictionary<Vector2Int, PileRenderer> WorldPileRenderer = new Dictionary<Vector2Int, PileRenderer>();
    private Dictionary<Vector2Int, HashSet<int>> buildingGrids = new Dictionary<Vector2Int, HashSet<int>>();

    public IEnumerable<T> FindObjectsOfType<T>() where T : WorldObject
    {
        foreach (var item in WorldObjects)
        {
            if (item.Value is T)
            {
                yield return item.Value as T;
            }
        }
    }

    public bool CanBuilding(Vector2Int targetGrid, BuildingInfo buildingInfo)
    {
        for (int i = 0; i < buildingInfo.buildingLength; i++)
        {
            for (int j = 0; j < buildingInfo.buildingWidth; j++)
            {
                if (buildingGrids.ContainsKey(new Vector2Int(targetGrid.x + j, targetGrid.y + i))
                    && buildingGrids[new Vector2Int(targetGrid.x + j, targetGrid.y + i)].Contains(buildingInfo.layer))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void RegisterObject(WorldObject worldObject)
    {
        try
        {
            RequestAdd.Add(worldObject);
            AddRenderComponent(worldObject);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"{worldObject.ItemName}_{worldObject.itemCode}注册错误");
            Debug.LogError(e);
            throw;
        }
    }

    public void RegisterBuildingGrids(WorldObject worldObject)
    {
        if (worldObject is Building building)
        {
            foreach (var item in building.buildingGrids)
            {
                if (buildingGrids.ContainsKey(item))
                {
                    buildingGrids[item].Add(building.buildingInfo.layer);
                }
            }
        }
    }

    public void UnregisterObject(WorldObject worldObject)
    {
        if (WorldObjects.Values.Contains(worldObject))
        {
            DisRenderItem(worldObject);
            RequestDelete.Add(worldObject);
            UnregisterBuildingGrids(worldObject);
        }
    }

    public void UnregisterBuildingGrids(WorldObject worldObject)
    {
        if (worldObject is Building building)
        {
            foreach (var item in building.buildingGrids)
            {
                if (buildingGrids.ContainsKey(item))
                {
                    buildingGrids[item].Remove(building.buildingInfo.layer);
                }
            }
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
        pfItem = Resources.Load<GameObject>("Prefabs/Object/Item");
        pfPile = Resources.Load<GameObject>("Prefabs/Object/Pile");
        pfGhost = Resources.Load<GameObject>("Prefabs/Object/Ghost");
        pfAnimal = Resources.Load<GameObject>("Prefabs/Character/Animal");
        pfBullet = Resources.Load<GameObject>("Prefabs/Weapon/Bullet");
        pfBulletEffect = Resources.Load<GameObject>("Prefabs/Weapon/WeaponShootEffectSmokePuff");

        renderParent = new GameObject("RenderParent");
        ObjectPoolManager.Instance.CreatePool(30, pfBullet, PoolEnum.Bullet.ToString(), renderParent.transform);
        ObjectPoolManager.Instance.CreatePool(30, pfBulletEffect, PoolEnum.BulletBoomEffect.ToString(), renderParent.transform);

        GameObject.DontDestroyOnLoad(renderParent);
    }

    private void RealTimeTick(GameTime gameTime)
    {
        foreach (var item in WorldObjects)
        {
            item.Value.RealTimeTick();
        }
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
        if (wo is Animal animal)
        {
            GameObject curPawn = UnityEngine.Object.Instantiate(pfAnimal, renderParent.transform);
            curPawn.GetComponent<Transform>().transform.position = animal.GridPos.To3();
            WorldItemsRenderer.Add(animal, curPawn.GetComponent<ItemRender>());
            curPawn.GetComponent<ItemRender>().Init(animal);
            curPawn.GetComponent<PathTracerRender>().Init(animal);
            animal.RenderTracer = curPawn.GetComponent<PathTracerRender>();
        }
        else
        {
            if (!wo.canPile)
            {
                GameObject itemGameObject = GameObject.Instantiate(pfItem, wo.GridPos.To3(), Quaternion.identity, renderParent.transform);
                ItemRender itemComponent = itemGameObject.GetComponent<ItemRender>();
                WorldItemsRenderer.Add(wo, itemComponent);
                itemComponent.GetComponent<ItemRender>().Init(wo);
            }
            else
            {
                if (!WorldPileRenderer.ContainsKey(wo.GridPos))
                {
                    GameObject itemGameObject = GameObject.Instantiate(pfPile, wo.GridPos.To3(), Quaternion.identity, renderParent.transform);
                    PileRenderer itemComponent = itemGameObject.GetComponent<PileRenderer>();
                    itemGameObject.GetComponent<PileRenderer>().Init(wo.itemCode, wo.mapBelongTo);
                    WorldPileRenderer.Add(wo.GridPos, itemComponent);
                }
            }
        }
    }

    public void DisRenderItem(WorldObject wo)
    {
        if (wo.canPile)
        {
            WorldPileRenderer.TryGetValue(wo.GridPos, out var renderer);
            if (renderer != null)
            {
                if (wo.mapBelongTo.GetGrid(wo.GridPos, out var gridDetail)
                    && !gridDetail.HasPiledThing)
                {
                    GameObject.Destroy(renderer.gameObject);
                    WorldPileRenderer.Remove(wo.GridPos);
                }
            }
        }
        else
        {
            WorldItemsRenderer.TryGetValue(wo, out IRenderer renderer);
            if (renderer != null)
            {
                (renderer as ItemRender).OnDisRender();
                GameObject.Destroy((renderer as ItemRender).gameObject);
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

    public ItemRender GetRenderer(int instanceID)
    {
        WorldItemsRenderer.TryGetValue(GetWorldObjectById(instanceID), out var renderer);
        return renderer as ItemRender;
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
            item.Value.OnRender();
        }

        foreach (var item in WorldPileRenderer)
        {
            item.Value.Render(item.Value.pileCode, item.Key, item.Value.belongTo);
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

        if (pawnManager.AlivePawnsCount == 0)
        {
            Current.CurGame.Hint("没有存活的殖民者，这个故事暂时结束了。");
            Current.CurGame.state = GameState.NOPAWN;
            Debug.LogWarning("没有存活的殖民者，这个故事暂时结束了。");
        }
    }

    public void Init()
    {
        new Humanbeing(ObjectCode.humanbeing.ToInt(), new Age(25), new Vector2Int(25, 25));
        new Animal(13002, new Age(4), new Vector2Int(23, 25));
        new Animal(13002, new Age(4), new Vector2Int(22, 25));
        new Weapon(17001, new Vector2Int(24, 25));
    }

    public Vector2Int SearchForRawMaterials(int objectCode)
    {
        var result = WorldObjects.Values.ToList().Find(x => x.itemCode == objectCode && !x.inBuildingConstruction);
        if (result != null)
        {
            return result.GridPos;
        }
        else
        {
            return VectorExtension.undefinedV2Int;
        }
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
