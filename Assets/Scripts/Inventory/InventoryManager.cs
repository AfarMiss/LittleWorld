using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoSingleton<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
    private List<List<InventoryItem>> inventoryItemsList;
    private List<int> inventorySelectedList;
    public List<List<InventoryItem>> InventoryDictionary { get => inventoryItemsList; }
    public UnityAction<int> OnUpdateBarSelected { get; private set; }

    [SerializeField] private SO_ItemList itemList = null;


    protected override void Awake()
    {
        base.Awake();
        CreateItemDetailsDictionary();
        CreateInventoryList();
        CreateSelectedList();
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
        inventoryItemsList = new List<List<InventoryItem>>();
        for (int i = 0; i < (int)InventoryLocation.account; i++)
        {
            inventoryItemsList.Add(new List<InventoryItem>());
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

    private void AddItem(InventoryLocation location, Item item)
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

    private void AddItemInFirstNull(InventoryLocation localtion, Item item)
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

    public void AddItem(InventoryLocation location, Item item, GameObject gameObjectToDestroy)
    {
        AddItem(location, item);
        EventHandler.CallUpdateInventoryEvent();
        Destroy(gameObjectToDestroy);
    }

    private int FindItemInInventory(InventoryLocation location, Item item)
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

        EventHandler.CallUpdateInventoryEvent();
    }

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

    internal void RemoveItem(InventoryLocation location, Item item)
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
            }
            else
            {
                inventoryItem.itemCode = -1;
                inventoryItemsList[localIndex][itemPosition] = inventoryItem;
            }

        }
        else
        {
            Debug.LogError($"No Item:{item.ItemCode}");
        }
        EventHandler.CallUpdateInventoryEvent();
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
                itemTypeDescription = FarmSetting.HoeingTool;
                break;
            case ItemType.chopping_tool:
                itemTypeDescription = FarmSetting.ChoppingTool;
                break;
            case ItemType.breaking_tool:
                itemTypeDescription = FarmSetting.BreakingTool;
                break;
            case ItemType.collection_tool:
                itemTypeDescription = FarmSetting.CollectingTool;
                break;
            case ItemType.watering_tool:
                itemTypeDescription = FarmSetting.WateringTool;
                break;
            case ItemType.reaping_tool:
                itemTypeDescription = FarmSetting.ReapingTool;
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
        EventCenter.Instance.Register(nameof(EventEnum.UPDATE_BAR_SELECTED), OnUpdateBarSelected);
    }

    private void OnDisable()
    {
        EventCenter.Instance.Unregister(nameof(EventEnum.UPDATE_BAR_SELECTED), OnUpdateBarSelected);
    }
}
