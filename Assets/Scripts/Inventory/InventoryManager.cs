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
        if (FindItemInInventory(location, item))
        {
            int localIndex = (int)location;
            for (int i = 0; i < inventoryDictionary[localIndex].Count; i++)
            {
                InventoryItem inventoryItem = inventoryDictionary[localIndex][i];
                if (inventoryItem.itemCode == item.ItemCode)
                {
                    inventoryItem.itemQuantity += 1;
                    inventoryDictionary[localIndex][i] = inventoryItem;
                    break;
                }
            }
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

    private bool FindItemInInventory(InventoryLocation location, Item item)
    {
        int localIndex = (int)location;
        foreach (var inventoryItem in inventoryDictionary[localIndex])
        {
            if (inventoryItem.itemCode == item.ItemCode)
            {
                return true;
            }
        }
        return false;
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
}
