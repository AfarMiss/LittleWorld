using LittleWorld.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoSingleton<InventoryManager>, ISaveable
{
    private int[] inventoryListCapacityIntArray = { 12, 48 };
    private UIInventoryBar inventoryBar;
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
    private List<InventoryItem>[] inventoryItemsList;
    public List<int> inventorySelectedList;
    public List<InventoryItem>[] InventoryDictionary { get => inventoryItemsList; }
    private string iSaveableUniqueID;
    public string ISaveableUniqueID { get => iSaveableUniqueID; set => iSaveableUniqueID = value; }
    public GameObjectSave gameObjectSave;
    public GameObjectSave GameObjectSave { get => gameObjectSave; set => gameObjectSave = value; }

    [SerializeField] private SO_ItemList itemList = null;

    private void Start()
    {
        inventoryBar = FindObjectOfType<UIInventoryBar>();
    }

    protected override void Awake()
    {
        base.Awake();
        CreateItemDetailsDictionary();
        CreateInventoryList();
        CreateSelectedList();

        ISaveableUniqueID = GetComponent<GenerateGUID>().GUID;
        GameObjectSave = new GameObjectSave();
    }

    public ItemDetails GetSelectedItemDetail(InventoryLocation inventoryLocation)
    {
        var hightLightIndex = inventorySelectedList[(int)InventoryLocation.player];
        if (hightLightIndex >= 0 && hightLightIndex < inventoryItemsList[(int)inventoryLocation].Count)
        {
            return GetItemDetail(inventoryItemsList[(int)inventoryLocation][hightLightIndex].itemCode);
        }
        else
        {
            return null;
        }
    }

    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();
        foreach (var item in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(item.itemCode, item);
        }
    }

    private void CreateInventoryList()
    {
        inventoryItemsList = new List<InventoryItem>[3];
        for (int i = 0; i <= (int)InventoryLocation.account; i++)
        {
            inventoryItemsList[i] = (new List<InventoryItem>());
        }
    }

    private void CreateSelectedList()
    {
        inventorySelectedList = new List<int>();
        for (int i = 0; i < (int)InventoryLocation.account; i++)
        {
            inventorySelectedList.Add(-1);
        }
    }

    private void AddItem(InventoryLocation location, ItemRender item)
    {
        var itemPosition = FindItemInInventory(location, item);
        if (itemPosition != -1)
        {
            int localIndex = (int)location;
            var inventoryItem = inventoryItemsList[localIndex][itemPosition];
            inventoryItem.itemQuantity += 1;
            inventoryItemsList[localIndex][itemPosition] = inventoryItem;
        }
        else
        {
            AddItemInFirstNull(location, item);
        }
        PrintInventoryInfo(location);
    }

    private void AddItemInFirstNull(InventoryLocation localtion, ItemRender item)
    {
        for (int i = 0; i < inventoryItemsList[(int)localtion].Count; i++)
        {
            if (inventoryItemsList[(int)localtion][i].itemCode == -1)
            {
                var newSlotItem = new InventoryItem(item.ItemCode, 1);
                inventoryItemsList[(int)localtion][i] = newSlotItem;
                return;
            }
        }
        inventoryItemsList[(int)localtion].Add(new InventoryItem(item.ItemCode, 1));
    }

    private void PrintInventoryInfo(InventoryLocation location)
    {
        Debug.Log($"=======================");
        var inventory = inventoryItemsList[(int)location];
        foreach (var item in inventory)
        {
            Debug.Log($"itemCode:{item.itemCode},itemQuantity:{item.itemQuantity}");
        }
        Debug.Log($"=======================");
    }

    public void AddItem(InventoryLocation location, ItemRender item, GameObject gameObjectToDestroy)
    {
        AddItem(location, item);
        EventCenter.Instance.Trigger(EventEnum.UPDATE_INVENTORY.ToString());
        Destroy(gameObjectToDestroy);
    }

    private int FindItemInInventory(InventoryLocation location, ItemRender item)
    {
        int localIndex = (int)location;
        for (int i = 0; i < inventoryItemsList[localIndex].Count; i++)
        {
            InventoryItem inventoryItem = inventoryItemsList[localIndex][i];
            if (inventoryItem.itemCode == item.ItemCode)
            {
                return i;
            }
        }
        return -1;
    }

    internal void SwapItem(InventoryLocation location, int itemFromIndex, int itemToIndex)
    {
        var maxIndex = Mathf.Max(itemToIndex, itemFromIndex);
        if (maxIndex > inventoryItemsList[(int)location].Count - 1)
        {
            for (int i = inventoryItemsList[(int)location].Count - 1; i < maxIndex; i++)
            {
                inventoryItemsList[(int)location].Add(new InventoryItem(-1, 0));
            }
        }
        var itemFrom = inventoryItemsList[(int)location][itemFromIndex];
        var itemTo = inventoryItemsList[(int)location][itemToIndex];

        inventoryItemsList[(int)location][itemFromIndex] = itemTo;
        inventoryItemsList[(int)location][itemToIndex] = itemFrom;
        inventorySelectedList[(int)InventoryLocation.player] = itemToIndex;
        EventCenter.Instance.Trigger(nameof(EventEnum.CLIENT_CHANGE_BAR_SELECTED), itemToIndex);

        EventCenter.Instance.Trigger(EventEnum.UPDATE_INVENTORY.ToString());
    }

    /// <summary>
    /// 获取物品信息
    /// </summary>
    /// <param name="itemCode"></param>
    /// <returns></returns>
    public ItemDetails GetItemDetail(int itemCode)
    {
        if (itemDetailsDictionary == null) return null;
        if (itemDetailsDictionary.TryGetValue(itemCode, out ItemDetails value))
        {
            return value;
        }
        else
        {
            return null;
        }
    }

    public void RemoveItem(InventoryLocation location, ItemRender item)
    {
        var itemPosition = FindItemInInventory(location, item);
        if (itemPosition != -1)
        {
            int localIndex = (int)location;
            var inventoryItem = inventoryItemsList[localIndex][itemPosition];
            inventoryItem.itemQuantity -= 1;
            if (inventoryItem.itemQuantity > 0)
            {
                inventoryItemsList[localIndex][itemPosition] = inventoryItem;
                EventCenter.Instance.Trigger(nameof(EventEnum.CLIENT_CHANGE_BAR_SELECTED), itemPosition);
            }
            else
            {
                inventoryItem.itemCode = -1;
                inventoryItemsList[localIndex][itemPosition] = inventoryItem;
                EventCenter.Instance.Trigger(nameof(EventEnum.CLIENT_CHANGE_BAR_SELECTED), -1);
            }
        }
        else
        {
            Debug.LogError($"No Item:{item.ItemCode}");
        }
        EventCenter.Instance.Trigger(EventEnum.UPDATE_INVENTORY.ToString());
        PrintInventoryInfo(location);
    }

    public void RemoveItem(InventoryLocation location, int itemIndex)
    {
        var itemPosition = itemIndex;
        if (itemPosition != -1)
        {
            int localIndex = (int)location;
            var inventoryItem = inventoryItemsList[localIndex][itemPosition];
            inventoryItem.itemQuantity -= 1;
            if (inventoryItem.itemQuantity > 0)
            {
                inventoryItemsList[localIndex][itemPosition] = inventoryItem;
                EventCenter.Instance.Trigger(nameof(EventEnum.CLIENT_CHANGE_BAR_SELECTED), itemPosition);
            }
            else
            {
                inventoryItem.itemCode = -1;
                inventoryItemsList[localIndex][itemPosition] = inventoryItem;
                EventCenter.Instance.Trigger(nameof(EventEnum.CLIENT_CHANGE_BAR_SELECTED), -1);
            }
        }
        else
        {
            Debug.LogError($"No Item at {itemPosition} in player inventory");
        }
        EventCenter.Instance.Trigger(EventEnum.UPDATE_INVENTORY.ToString());
        PrintInventoryInfo(location);
    }

    public string GetItemTypeDescription(ItemType itemType)
    {
        string itemTypeDescription = null;
        switch (itemType)
        {
            //case ItemType.seed:
            //    break;
            //case ItemType.commodity:
            //    break;
            case ItemType.hoeing_tool:
                itemTypeDescription = GameSetting.HoeingTool;
                break;
            case ItemType.chopping_tool:
                itemTypeDescription = GameSetting.ChoppingTool;
                break;
            case ItemType.breaking_tool:
                itemTypeDescription = GameSetting.BreakingTool;
                break;
            case ItemType.collection_tool:
                itemTypeDescription = GameSetting.CollectingTool;
                break;
            case ItemType.watering_tool:
                itemTypeDescription = GameSetting.WateringTool;
                break;
            case ItemType.reaping_tool:
                itemTypeDescription = GameSetting.ReapingTool;
                break;
            //case ItemType.none:
            //    break;
            //case ItemType.count:
            //    break;
            //case ItemType.furniture:
            //    break;
            //case ItemType.reapable_scenery:
            //    break;
            default:
                itemTypeDescription = itemType.ToString();
                break;
        }

        return itemTypeDescription;
    }

    private void OnEnable()
    {
        EventCenter.Instance?.Register<int>(nameof(EventEnum.CLIENT_CHANGE_BAR_SELECTED), OnUpdateBarSelected, this);
        EventCenter.Instance?.Register(nameof(EventEnum.REMOVE_SELECTED_ITEM_FROM_INVENTORY), RemoveSelectedItem, this);
        ISaveableRegister();
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<int>(nameof(EventEnum.CLIENT_CHANGE_BAR_SELECTED), OnUpdateBarSelected);
        EventCenter.Instance?.Unregister(nameof(EventEnum.REMOVE_SELECTED_ITEM_FROM_INVENTORY), RemoveSelectedItem);
        ISaveableDeregister();
    }

    private void RemoveSelectedItem()
    {
        RemoveItem(InventoryLocation.player, GetSelectedInventoryItem(InventoryLocation.player));
    }

    private void OnUpdateBarSelected(int arg0)
    {
        inventorySelectedList[(int)InventoryLocation.player] = arg0;
        Debug.Log($"inventorySelectedList[(int)InventoryLocation.player]:{inventorySelectedList[(int)InventoryLocation.player]}");
        //当操作是选中物体时，同步更新动画状态
        if (arg0 >= 0 && arg0 < inventoryItemsList[(int)InventoryLocation.player].Count)
        {
            InventoryItem curItem = inventoryItemsList[(int)InventoryLocation.player][arg0];
            //如果物体标记为可携带，则举起该物体。
            if (GetItemDetail(curItem.itemCode) != null && GetItemDetail(curItem.itemCode).canBeCarried)
            {
                FarmGameController.Instance.ShowCarriedItem(curItem.itemCode);
            }
            else
            {
                FarmGameController.Instance.ClearCarriedItem();
            }
        }
        else
        {
            FarmGameController.Instance.ClearCarriedItem();
        }

        EventCenter.Instance.Trigger(nameof(EventEnum.UPDATE_INVENTORY));
    }

    private int GetSelectedInventoryItem(InventoryLocation inventoryLocation)
    {
        return inventorySelectedList[(int)inventoryLocation];
    }

    public void ISaveableRegister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Add(this);
    }

    public void ISaveableDeregister()
    {
        SaveLoadManager.Instance?.iSaveableObjectList.Remove(this);
    }

    public void ISaveableStoreScene(string sceneName)
    {
    }

    public void ISaveableRestoreScene(string sceneName)
    {
    }

    public GameObjectSave ISaveableSave()
    {
        SceneSave sceneSave = new SceneSave();
        GameObjectSave.sceneData.Remove(GameSetting.PersistentScene);
        sceneSave.listInvItemArray = inventoryItemsList;
        sceneSave.intArrayDictionary = new Dictionary<string, int[]>
        {
            { "inventoryListCapacityArray", inventoryListCapacityIntArray }
        };

        GameObjectSave.sceneData.Add(GameSetting.PersistentScene, sceneSave);
        return GameObjectSave;
    }

    public void ISaveableLoad(GameSave gameSave)
    {
        if (gameSave.gameObjectData.TryGetValue(ISaveableUniqueID, out GameObjectSave gameObjectSave))
        {
            GameObjectSave = gameObjectSave;
            if (gameObjectSave.sceneData.TryGetValue(GameSetting.PersistentScene, out SceneSave sceneSave))
            {
                if (sceneSave.listInvItemArray != null)
                {
                    inventoryItemsList = sceneSave.listInvItemArray;

                    //清除选中物品
                    EventCenter.Instance.Trigger(EventEnum.UPDATE_INVENTORY.ToString());
                    FarmGameController.Instance.ClearCarriedItem();
                }

                if (sceneSave.intArrayDictionary != null && sceneSave.intArrayDictionary.TryGetValue("inventoryListCapacityArray",
                    out int[] inventoryCapacityArray))
                {
                    inventoryListCapacityIntArray = inventoryCapacityArray;
                }
            }
        }
    }
}
