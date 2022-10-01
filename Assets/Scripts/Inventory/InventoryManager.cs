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
            int localIndex = (int)location;
            inventoryDictionary[localIndex].Add(new InventoryItem
            {
                itemCode = item.ItemCode,
                itemQuantity = 1
            });
        }
        PrintInventoryInfo(location);
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
                inventoryDictionary[localIndex].RemoveAt(itemPosition);
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
