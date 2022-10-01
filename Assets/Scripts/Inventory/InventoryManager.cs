using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoSingleton<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
    private List<List<InventoryItem>> inventoryDictionary;
    public List<List<InventoryItem>> InventoryDictionary { get => inventoryDictionary; }

    [SerializeField] private SO_ItemList itemList = null;


    protected override void Awake()
    {
        base.Awake();
        CreateItemDetailsDictionary();
        CreateInventoryDictionary();
    }

    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();
        foreach (var item in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(item.itemCode, item);
        }
    }

    private void CreateInventoryDictionary()
    {
        inventoryDictionary = new List<List<InventoryItem>>();
        for (int i = 0; i < (int)InventoryLocation.account; i++)
        {
            inventoryDictionary.Add(new List<InventoryItem>());
        }
    }

    private void AddItem(InventoryLocation location, Item item)
    {
        var itemPosition = FindItemInInventory(location, item);
        if (itemPosition != -1)
        {
            int localIndex = (int)location;
            var inventoryItem = inventoryDictionary[localIndex][itemPosition];
            inventoryItem.itemQuantity += 1;
            inventoryDictionary[localIndex][itemPosition] = inventoryItem;
        }
        else
        {
            AddItemInFirstNull(location, item);
        }
        PrintInventoryInfo(location);
    }

    private void AddItemInFirstNull(InventoryLocation localtion, Item item)
    {
        for (int i = 0; i < inventoryDictionary[(int)localtion].Count; i++)
        {
            if (inventoryDictionary[(int)localtion][i].itemCode == -1)
            {
                var newSlotItem = new InventoryItem(item.ItemCode, 1);
                inventoryDictionary[(int)localtion][i] = newSlotItem;
                return;
            }
        }
        inventoryDictionary[(int)localtion].Add(new InventoryItem(item.ItemCode, 1));
    }

    private void PrintInventoryInfo(InventoryLocation location)
    {
        Debug.Log($"=======================");
        var inventory = inventoryDictionary[(int)location];
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
        for (int i = 0; i < inventoryDictionary[localIndex].Count; i++)
        {
            InventoryItem inventoryItem = inventoryDictionary[localIndex][i];
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
        if (maxIndex > inventoryDictionary[(int)location].Count - 1)
        {
            for (int i = inventoryDictionary[(int)location].Count - 1; i < maxIndex; i++)
            {
                inventoryDictionary[(int)location].Add(new InventoryItem(-1, 0));
            }
        }
        var itemFrom = inventoryDictionary[(int)location][itemFromIndex];
        var itemTo = inventoryDictionary[(int)location][itemToIndex];

        inventoryDictionary[(int)location][itemFromIndex] = itemTo;
        inventoryDictionary[(int)location][itemToIndex] = itemFrom;

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
            var inventoryItem = inventoryDictionary[localIndex][itemPosition];
            inventoryItem.itemQuantity -= 1;
            if (inventoryItem.itemQuantity > 0)
            {
                inventoryDictionary[localIndex][itemPosition] = inventoryItem;
            }
            else
            {
                inventoryItem.itemCode = -1;
                inventoryDictionary[localIndex][itemPosition] = inventoryItem;
            }

        }
        else
        {
            Debug.LogError($"No Item:{item.ItemCode}");
        }
        EventHandler.CallUpdateInventoryEvent();
        PrintInventoryInfo(location);
    }
}
