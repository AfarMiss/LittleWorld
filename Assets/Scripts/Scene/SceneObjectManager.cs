
using LittleWorld.Item;
using LittleWorld.Extension;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SceneObjectManager : Singleton<SceneObjectManager>
{
    public static int ItemInstanceID;
    private GameObject itemPrefab;
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
    public Dictionary<LittleWorld.Item.Object, ItemRender> WorldItemsRenderer = new Dictionary<LittleWorld.Item.Object, ItemRender>();

    public void RegisterItem(WorldObject worldObject)
    {
        WorldObjects.Add(worldObject.instanceID, worldObject);
        AddRenderComponent(worldObject);
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

    public override void OnCreateInstance()
    {
        base.OnCreateInstance();
        EventCenter.Instance.Register<GameTime>((nameof(EventEnum.GAME_TICK)), Tick);

        ItemInstanceID = 0;
        pawnManager = PawnManager.Instance;
        itemPrefab = Resources.Load<GameObject>("Prefabs/Object/Item");
        ghostPrefab = Resources.Load<GameObject>("Prefabs/Object/Ghost");
        pawnRes = Resources.Load<GameObject>("Prefabs/Character/Pawn");

        renderParent = new GameObject("RenderParent");
        GameObject.DontDestroyOnLoad(renderParent);

        //测试代码
        new Humanbeing(ObjectCode.humanbeing.ToInt(), new Vector2Int(25, 25));
    }

    private SceneObjectManager()
    {

    }

    private void RenderPawn(Humanbeing human)
    {
        GameObject curPawn = GameObject.Instantiate<GameObject>(pawnRes, renderParent.transform);
        curPawn.GetComponent<Transform>().transform.position = human.GridPos.To3();
        curPawn.GetComponent<PathNavigation>().Initialize(human.instanceID);
        human.SetNavi(curPawn.GetComponent<PathNavigation>());
        human.rendererObject = curPawn;
        WorldItemsRenderer.Add(human, curPawn.GetComponent<ItemRender>());
    }

    private void AddRenderComponent(WorldObject wo)
    {
        if (!(wo is Humanbeing))
        {
            GameObject itemGameObject = GameObject.Instantiate(itemPrefab, wo.GridPos.To3(), Quaternion.identity, renderParent.transform);
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
            GameObject.Destroy(renderer.gameObject);
            wo.rendererObject = null;
        }
        WorldItemsRenderer.Remove(wo);
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
