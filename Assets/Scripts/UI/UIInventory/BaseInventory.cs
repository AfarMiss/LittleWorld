using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInventory : BaseUI
{
    [SerializeField]
    protected RectTransform rectTransform;
    [SerializeField]
    protected UIInventorySlot[] uIInventorySlots;
    [HideInInspector]
    public GameObject inventoryTextBoxGameobject = null;
    public GameObject inventoryBarDraggedItem;
    protected bool isInBottom = true;

    public bool IsInBottom { get => isInBottom; }

    public override string path => "";

    protected virtual void CheckUIPos() { }

    private void OnEnable()
    {
        BindData();
        EventCenter.Instance.Register(nameof(EventEnum.UPDATE_INVENTORY), BindData);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister(nameof(EventEnum.UPDATE_INVENTORY), BindData);
        Destroy(inventoryTextBoxGameobject);
    }

    private void BindData()
    {
        var hightLightIndex = InventoryManager.Instance.inventorySelectedList[(int)InventoryLocation.player];
        BindDataWith(InventoryManager.Instance.InventoryDictionary[(int)InventoryLocation.player], hightLightIndex);
    }

    protected virtual void BindDataWith(List<InventoryItem> itemsList, int hightLightIndex)
    {

    }

    public void ClearPlayerSelected()
    {
        foreach (var item in uIInventorySlots)
        {
            item.IsSelected = false;
        }
    }
}
