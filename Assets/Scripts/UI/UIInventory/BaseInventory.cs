using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInventory : BaseUI
{
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    protected UIInventorySlot[] uIInventorySlots;
    [HideInInspector]
    public GameObject inventoryTextBoxGameobject = null;
    public GameObject inventoryBarDraggedItem;
    private bool isInBottom = true;

    public bool IsInBottom { get => isInBottom; }

    public override string path => "";

    private void OnEnable()
    {
        BindData();
        EventCenter.Instance.Register(nameof(EventEnum.INVENTORY_MANAGER_CHANGE_BAR_SELECTED), BindData);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister(nameof(EventEnum.INVENTORY_MANAGER_CHANGE_BAR_SELECTED), BindData);
    }

    private void BindData()
    {
        var hightLightIndex = InventoryManager.Instance.inventorySelectedList[(int)InventoryLocation.player];
        BindDataWith(InventoryManager.Instance.InventoryDictionary[(int)InventoryLocation.player], hightLightIndex);
    }

    protected virtual void BindDataWith(List<InventoryItem> itemsList, int hightLightIndex)
    {

    }

    private void FixedUpdate()
    {
        //CheckUIPos();
    }

    private void CheckUIPos()
    {
        if (FarmPlayer.Instance != null)
        {
            var playerViewPortPos = Camera.main.WorldToViewportPoint(FarmPlayer.Instance.transform.position);
            if (playerViewPortPos.y > 0.3f && !isInBottom)
            {
                rectTransform.pivot = new Vector2(0.5f, 0f);
                rectTransform.anchorMin = new Vector2(0.5f, 0f);
                rectTransform.anchorMax = new Vector2(0.5f, 0f);
                rectTransform.anchoredPosition = new Vector2(0f, 2.5f);

                isInBottom = true;
            }
            if (playerViewPortPos.y <= 0.3f && isInBottom)
            {
                rectTransform.pivot = new Vector2(0.5f, 1f);
                rectTransform.anchorMin = new Vector2(0.5f, 1f);
                rectTransform.anchorMax = new Vector2(0.5f, 1f);
                rectTransform.anchoredPosition = new Vector2(0f, -2.5f);

                isInBottom = false;
            }
        }
    }

    public void ClearPlayerSelected()
    {
        foreach (var item in uIInventorySlots)
        {
            item.IsSelected = false;
        }
    }
}
