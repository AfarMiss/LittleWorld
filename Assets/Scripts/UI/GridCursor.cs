using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCursor : MonoSingleton<GridCursor>
{
    private Canvas canvas;
    private Grid grid;
    private Camera mainCamera;

    [SerializeField] private Image cursorImage = null;
    [SerializeField] private RectTransform cursorRectTransform = null;

    [SerializeField] private Sprite greenCursorSprite = null;
    [SerializeField] private Sprite redCursorSprite = null;

    /// <summary>
    /// 物品提示标记Grid对应是否可操作[红/绿]
    /// </summary>
    private bool cursorPositionIsValid = false;
    public bool CursorPositionIsValid { get { return cursorPositionIsValid; } set { cursorPositionIsValid = value; } }

    /// <summary>
    /// 当前物品使用半径
    /// </summary>
    private int itemUseGridRadius = 0;
    public int ItemUseGridRadius
    {
        get { return itemUseGridRadius; }
        set { itemUseGridRadius = value; }
    }

    private ItemType selectedItemType;
    public ItemType SelectedItemType { get => selectedItemType; set => selectedItemType = value; }

    /// <summary>
    /// 是否启用物品提示指针[显/隐]
    /// </summary>
    private bool cursorIsEnable;
    public bool CursorIsEnabled { get => cursorIsEnable; set => cursorIsEnable = value; }

    private void OnEnable()
    {
        EventCenter.Instance?.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), SceneLoad);
        EventCenter.Instance?.Register(nameof(EventEnum.INVENTORY_MANAGER_CHANGE_BAR_SELECTED), OnUpdateBarSelected);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), SceneLoad);
        EventCenter.Instance?.Unregister(nameof(EventEnum.INVENTORY_MANAGER_CHANGE_BAR_SELECTED), OnUpdateBarSelected);
    }

    private void OnUpdateBarSelected()
    {
        var inventoryItem = InventoryManager.Instance.GetSelectedItemDetail(InventoryLocation.player);
        if (inventoryItem != null)
        {
            if (inventoryItem.itemUseGridRadius > 0)
            {
                EnableCursor();
            }
            else
            {
                DisableCursor();
            }
            SelectedItemType = inventoryItem.itemType;
            ItemUseGridRadius = inventoryItem.itemUseGridRadius;
        }
        else
        {
            SelectedItemType = ItemType.none;
            DisableCursor();
        }
    }

    private void SceneLoad()
    {
        grid = GameObject.FindObjectOfType<Grid>();
    }

    private void Start()
    {
        mainCamera = Camera.main;
        canvas = GetComponentInParent<Canvas>();
    }

    private void Update()
    {
        if (cursorIsEnable)
        {
            DisplayCursor();
        }
    }

    private Vector3 DisplayCursor()
    {
        if (grid != null)
        {
            Vector3Int gridPos = GetGridPositionForCursor();
            Vector3Int playerPos = GetGridPositionForPlayer();
            SetCursorValidity(gridPos, playerPos);
            cursorRectTransform.position = GetRectTransformPositionForCursor(gridPos);

            return gridPos;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private void SetCursorValidity(Vector3Int cursorPos, Vector3Int playerPos)
    {
        SetCursorToValid();
        Debug.Log($"cursorPos:{cursorPos},playerPos:{playerPos}");
        if (Mathf.Abs(cursorPos.x - playerPos.x) > ItemUseGridRadius || Mathf.Abs(cursorPos.y - playerPos.y) > ItemUseGridRadius)
        {
            SetCursorToInvalid();
            return;
        }

        ItemDetails itemDetails = InventoryManager.Instance.GetSelectedItemDetail(InventoryLocation.player);
        if (itemDetails == null)
        {
            SetCursorToInvalid();
            return;
        }

        GridPropertyDetails gridPropertyDetails = GridPropertiesManager.Instance.GetGridPropertyDetails(cursorPos.x, cursorPos.y);
        if (gridPropertyDetails == null)
        {
            SetCursorToInvalid();
            return;
        }

        switch (itemDetails.itemType)
        {
            case ItemType.seed:
                if (!IsCursorValidForSeed(gridPropertyDetails))
                {
                    SetCursorToInvalid();
                    return;
                }
                break;
            case ItemType.commodity:
                if (!IsCursorValidForCommodity(gridPropertyDetails))
                {
                    SetCursorToInvalid();
                    return;
                }
                break;
            case ItemType.hoeing_tool:
            case ItemType.chopping_tool:
            case ItemType.breaking_tool:
            case ItemType.collection_tool:
            case ItemType.watering_tool:
            case ItemType.reaping_tool:
                if (!IsCursorValidForTool(gridPropertyDetails, itemDetails))
                {
                    SetCursorToInvalid();
                    return;
                }
                break;
            default:
                break;
        }
    }

    private bool IsCursorValidForTool(GridPropertyDetails gridPropertyDetails, ItemDetails itemDetails)
    {
        switch (itemDetails.itemType)
        {
            case ItemType.hoeing_tool:
                if (gridPropertyDetails.isDiggable == true && gridPropertyDetails.daysSinceDug == -1)
                {
                    Vector3 cursorWorldPos = new Vector3(GetWorldPositionForCursor().x + 0.5f, GetWorldPositionForCursor().y + 0.5f, 0f);
                    List<Item> itemList = new List<Item>();

                    UniBase.OverlapHelper.GetComponentsAtBoxLocation(out itemList, cursorWorldPos, FarmSetting.cursorSize, 0f);

                    bool foundReapable = false;

                    foreach (var item in itemList)
                    {
                        if (InventoryManager.Instance.GetItemDetail(item.ItemCode).itemType == ItemType.reapable_scenery)
                        {
                            foundReapable = true;
                            break;
                        }
                    }

                    return !foundReapable;
                }
                else
                {
                    return false; ;
                }
            case ItemType.watering_tool:
                return gridPropertyDetails.daysSinceDug > -1 && gridPropertyDetails.daysSinceWatered == -1;
            case ItemType.collection_tool:
                CropDetails cropDetails = GridPropertiesManager.Instance.GetCropDetails(gridPropertyDetails);
                return gridPropertyDetails.seedItemCode > -1 && cropDetails != null && cropDetails.totalGrowthDays <= gridPropertyDetails.growthDays;
            default:
                return false;
        }
    }

    /// <summary>
    /// 获取当前grid位置[左下角]
    /// </summary>
    /// <returns></returns>
    private Vector3 GetWorldPositionForCursor()
    {
        return grid.CellToWorld(GetGridPositionForCursor());
    }

    private bool IsCursorValidForCommodity(GridPropertyDetails gridPropertyDetails)
    {
        return gridPropertyDetails.canDropItem;
    }

    private bool IsCursorValidForSeed(GridPropertyDetails gridPropertyDetails)
    {
        return gridPropertyDetails.canDropItem;
    }

    private void SetCursorToInvalid()
    {
        cursorImage.sprite = redCursorSprite;
        CursorPositionIsValid = false;

    }

    private void SetCursorToValid()
    {
        cursorImage.sprite = greenCursorSprite;
        CursorPositionIsValid = true;
    }

    public Vector3Int GetGridPositionForCursor()
    {
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(UniBase.InputUtils.GetMousePosition());
        return grid.WorldToCell(worldPos);
    }

    public Vector3Int GetGridPositionForPlayer()
    {
        return grid.WorldToCell(Director.Instance.MainPlayer.transform.position);
    }

    public void DisableCursor()
    {
        cursorImage.color = Color.clear;
        cursorIsEnable = false;
    }

    public void EnableCursor()
    {
        cursorImage.color = Color.white;
        cursorIsEnable = true;
    }

    public Vector2 GetRectTransformPositionForCursor(Vector3Int gridPos)
    {
        //从grid坐标转换到屏幕坐标
        Vector3 gridWorldPos = grid.CellToWorld(gridPos);
        Vector2 gridSceenPos = mainCamera.WorldToScreenPoint(gridWorldPos);
        //目前没看出RectTransformUtility.PixelAdjustPoint和gridSceenPos得出的坐标差别是什么
        var pixelPos = RectTransformUtility.PixelAdjustPoint(gridSceenPos, cursorRectTransform, canvas);
        //Debug.Log($"gridSceenPos:{gridSceenPos},pixelPos:{pixelPos}");
        //获取基于画布canvas的像素点坐标
        return pixelPos;
    }

}
