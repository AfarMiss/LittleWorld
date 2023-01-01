using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoSingleton<Cursor>
{
    private Canvas canvas;
    private Camera mainCamera;
    [SerializeField] private Image cursorImage = null;
    [SerializeField] private RectTransform cursorRectTransform = null;
    [SerializeField] private Sprite greenCursorSprite = null;
    [SerializeField] private Sprite transparentCursorSprite = null;
    [SerializeField] private GridCursor gridCursor = null;

    private bool _cursorIsEnabled = false;
    public bool CursorIsEnabled { get => _cursorIsEnabled; set { _cursorIsEnabled = value; } }

    private bool _cursorPositionIsValid = false;
    public bool CursorPositionIsValid { get => _cursorPositionIsValid; set { _cursorPositionIsValid = value; } }

    private ItemType _selectedItemType;
    public ItemType SelectedItemType { get => _selectedItemType; set { _selectedItemType = value; } }

    private float _itemUseRadius = 0f;
    public float ItemUseGridRadius { get => _itemUseRadius; set { _itemUseRadius = value; } }

    private void Start()
    {
        mainCamera = Camera.main;
        canvas = GetComponentInParent<Canvas>();
    }

    private void Update()
    {
        if (CursorIsEnabled)
        {
            DisplayCursor();
        }
    }

    private void DisplayCursor()
    {
        Vector3 cursorWorldPosition = GetWorldPositionForCursor();

        //SetCursorValidity(cursorWorldPosition, Director.Instance.MainPlayer.GetPlayrCentrePosition());

        cursorRectTransform.position = GetRectTransformPositionForCursor();
    }

    private void SetCursorValidity(Vector3 cursorPosition, Vector3 playerPosition)
    {
        SetCursorToValid();

        if (
            cursorPosition.x > (playerPosition.x + ItemUseGridRadius / 2f) && cursorPosition.y > (playerPosition.y + ItemUseGridRadius / 2f)
            ||
            cursorPosition.x < (playerPosition.x - ItemUseGridRadius / 2f) && cursorPosition.y > (playerPosition.y + ItemUseGridRadius / 2f)
            ||
            cursorPosition.x < (playerPosition.x - ItemUseGridRadius / 2f) && cursorPosition.y < (playerPosition.y - ItemUseGridRadius / 2f)
            ||
            cursorPosition.x > (playerPosition.x + ItemUseGridRadius / 2f) && cursorPosition.y < (playerPosition.y - ItemUseGridRadius / 2f)
            )
        {
            SetCursorToInValid();
            return;
        }

        if (MathF.Abs(cursorPosition.x - playerPosition.x) > ItemUseGridRadius
            || MathF.Abs(cursorPosition.y - playerPosition.y) > ItemUseGridRadius)
        {
            SetCursorToInValid();
            return;
        }

        ItemDetails itemDetails = InventoryManager.Instance.GetSelectedItemDetail(InventoryLocation.player);
        if (itemDetails == null)
        {
            SetCursorToInValid();
            return;
        }

        switch (itemDetails.itemType)
        {
            case ItemType.hoeing_tool:
            case ItemType.chopping_tool:
            case ItemType.breaking_tool:
            case ItemType.collection_tool:
            case ItemType.watering_tool:
            case ItemType.reaping_tool:
                if (!SetCursorValidityTool(cursorPosition, playerPosition, itemDetails))
                {
                    SetCursorToInValid();
                    return;
                }
                break;
            case ItemType.none:
                break;
            case ItemType.count:
                break;
            default:
                break;
        }
    }

    private bool SetCursorValidityTool(Vector3 cursorPosition, Vector3 playerPosition, ItemDetails itemDetails)
    {
        switch (itemDetails.itemType)
        {
            case ItemType.reaping_tool:
                return SetCursorValidityReapingTool(cursorPosition, playerPosition, itemDetails);
            default:
                return false;
        }
    }

    private bool SetCursorValidityReapingTool(Vector3 cursorPosition, Vector3 playerPosition, ItemDetails equippedItemDetails)
    {

        if (UniBase.OverlapHelper.GetComponentsAtCursorLocation(out List<Item> items, cursorPosition))
        {
            if (items.Count != 0)
            {
                foreach (Item item in items)
                {
                    if (InventoryManager.Instance.GetItemDetail(item.ItemCode).itemType == ItemType.reapable_scenery)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private void SetCursorToInValid()
    {
        cursorImage.sprite = transparentCursorSprite;
        CursorPositionIsValid = false;

        gridCursor.EnableCursor();
    }

    private void SetCursorToValid()
    {
        cursorImage.sprite = greenCursorSprite;
        CursorPositionIsValid = true;

        gridCursor.DisableCursor();
    }

    private Vector3 GetWorldPositionForCursor()
    {
        return UniBase.InputUtils.GetMouseWorldPosition();
    }

    public void DisableCursor()
    {
        cursorImage.color = new Color(1f, 1f, 1f, 0f);
        CursorIsEnabled = false;
    }

    public void EnableCursor()
    {
        cursorImage.color = new Color(1f, 1f, 1f, 1f);
        CursorIsEnabled = true;
    }

    private Vector3 GetRectTransformPositionForCursor()
    {
        Vector2 screenPosition = UniBase.InputUtils.GetMousePosition();

        return RectTransformUtility.PixelAdjustPoint(screenPosition, cursorRectTransform, canvas);
    }

    private void OnEnable()
    {
        EventCenter.Instance?.Register(nameof(EventEnum.UPDATE_INVENTORY), OnUpdateBarSelected);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister(nameof(EventEnum.UPDATE_INVENTORY), OnUpdateBarSelected);
    }

    private void OnUpdateBarSelected()
    {
        var inventoryItem = InventoryManager.Instance.GetSelectedItemDetail(InventoryLocation.player);
        if (inventoryItem != null)
        {
            if (inventoryItem.itemUseRadius > 0)
            {
                EnableCursor();
            }
            else
            {
                DisableCursor();
            }
            SelectedItemType = inventoryItem.itemType;
            ItemUseGridRadius = inventoryItem.itemUseRadius;
        }
        else
        {
            SelectedItemType = ItemType.none;
            DisableCursor();
        }
    }
}
