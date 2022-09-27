using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoSingleton<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;

    [SerializeField] private SO_ItemList itemList = null;

    protected override void Awake()
    {
        base.Awake();
        CreateItemDetailsDictionary();
    }

    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();
        foreach (var item in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(item.itemCode, item);
        }
    }

    public ItemDetails GetItemDetail(int itemCode)
    {
        if (itemDetailsDictionary==null) return null;
        if(itemDetailsDictionary.TryGetValue(itemCode,out ItemDetails value))
        {
            return value;
        }
        else
        {
            return null;
        }
    }
}
