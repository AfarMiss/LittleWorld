using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryBar : BaseUI
{
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private UIInventorySlot[] uIInventorySlots;
    [HideInInspector]
    public GameObject inventoryTextBoxGameobject = null;

    public GameObject inventoryBarDraggedItem;

    private Camera mainCamera;
    private bool isInBottom = true;

    public bool IsInBottom { get => isInBottom; }

    public override string path => UIPath.Panel_ConciseInventoryPanel;

    private void Start()
    {
        BindData();
    }
    private void OnEnable()
    {
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

    private void BindDataWith(List<InventoryItem> itemsList, int hightLightIndex)
    {
        for (int i = 0; i < uIInventorySlots.Length; i++)
        {
            if (i < itemsList.Count)
            {
                uIInventorySlots[i].BindData(itemsList[i], i, hightLightIndex);
            }
            else
            {
                uIInventorySlots[i].BindData(new InventoryItem(-1, -1), i, hightLightIndex);
            }
        }
    }

    private void FixedUpdate()
    {
        CheckUIPos();
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

    public override void OnClickClose()
    {
        throw new System.NotImplementedException();
    }
}
