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
    public bool CursorIsEnable { get => cursorIsEnable; set => cursorIsEnable = value; }

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
        var inventoryItem = InventoryManager.Instance.GetItemDetailOfHighlight(InventoryLocation.player);
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
            DisableCursor();
            SelectedItemType = ItemType.none;
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

        ItemDetails details = InventoryManager.Instance.GetItemDetailOfHighlight(InventoryLocation.player);
        if (details == null)
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

        switch (details.itemType)
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
            default:
                break;
        }
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

    private Vector3Int GetGridPositionForCursor()
    {
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(UniBase.InputUtils.GetMousePosition());
        return grid.WorldToCell(worldPos);
    }

    private Vector3Int GetGridPositionForPlayer()
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
        var pixelPos = RectTransformUtility.PixelAdjustPoint(gridSceenPos, cursorRectTransform, canvas);
        Debug.Log($"gridSceenPos:{gridSceenPos},pixelPos:{pixelPos}");
        //获取基于画布canvas的像素点坐标
        return pixelPos;
    }

}
