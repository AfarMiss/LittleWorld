
using LittleWorld.Item;
using LittleWorld.Extension;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using LittleWorld.MapUtility;
using LittleWorld.Message;
using static LittleWorld.HealthTracer;

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
    private Dictionary<WorldObject, ItemRender> WorldItemsRenderer = new Dictionary<WorldObject, ItemRender>();
    private Dictionary<Vector2Int, PileInfo> WorldPileRenderer = new Dictionary<Vector2Int, PileInfo>();
    private HashSet<Vector2Int> buildingGrids = new HashSet<Vector2Int>();

    public bool CanBuilding(Vector2Int targetGrid, BuildingInfo buildingInfo)
    {
        for (int i = 0; i < buildingInfo.buildingLength; i++)
        {
            for (int j = 0; j < buildingInfo.buildingWidth; j++)
            {
                if (buildingGrids.Contains(new Vector2Int(targetGrid.x + j, targetGrid.y + i)))
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
            Debug.LogError($"{worldObject.ItemName}_{worldObject.itemCode}");
            Debug.LogError(e);
            throw;
        }
    }

    public void RegisterBuildingGrids(WorldObject worldObject)
    {
        if (worldObject is Building building)
        {
            buildingGrids.AddRange(building.buildingGrids);
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
                buildingGrids.Remove(item);
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
            GameObject curPawn = GameObject.Instantiate<GameObject>(pfAnimal, renderParent.transform);
            curPawn.GetComponent<Transform>().transform.position = animal.GridPos.To3();
            curPawn.GetComponent<PathNavigation>().Initialize(animal.instanceID);
            animal.SetNavi(curPawn.GetComponent<PathNavigation>());
            WorldItemsRenderer.Add(animal, curPawn.GetComponent<ItemRender>());
            curPawn.GetComponent<ItemRender>().Init(animal);
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
                    WorldPileRenderer.Add(wo.GridPos, new PileInfo(wo.itemCode, itemComponent, wo.mapBelongTo));
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
            WorldItemsRenderer.TryGetValue(wo, out ItemRender renderer);
            if (renderer != null)
            {
                renderer.OnDisRender();
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
            item.Value.OnRender(item.Key);
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
