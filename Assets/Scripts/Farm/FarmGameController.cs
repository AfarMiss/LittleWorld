using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class FarmGameController : MonoSingleton<FarmGameController>
{
    private WaitForSeconds afterUseToolAnimationPause;
    private WaitForSeconds useToolAnimationPause;
    private WaitForSeconds afterLiftToolAnimationPause;
    private WaitForSeconds liftToolAnimationPause;

    /// <summary>
    /// 玩家是否处于禁用物品状态
    /// </summary>
    private bool playerToolUseDisabled = false;

    private AnimationOverrides animationOverrides;
    private List<CharacterAttribute> characterAttributeCustomisationList;

    private CharacterAttribute armsCharacterAttribute;
    private CharacterAttribute toolCharacterAttribute;

    [Tooltip("Should be populated in the prefab with the equipped item sprite renderer")]
    private SpriteRenderer equippedItemSpriteRenderer = null;

    private float inputX;
    private float inputY;
    private bool isWalking;
    private bool isRunning;
    private bool isIdle;
    private bool isCarrying;
    private ToolEffect toolEffect;
    private bool isUsingToolRight;
    private bool isUsingToolLeft;
    private bool isUsingToolUp;
    private bool isUsingToolDown;
    private bool isLiftingToolRight;
    private bool isLiftingToolLeft;
    private bool isLiftingToolUp;
    private bool isPickingRight;
    private bool isPickingLeft;
    private bool isLiftingToolDown;
    private bool isPickingUp;
    private bool isPickingDown;
    private bool isSwingingToolRight;
    private bool isSwingingToolLeft;
    private bool isSwingingToolUp;
    private bool isSwingingToolDown;
    private bool idleRight;
    private bool idleLeft;
    private bool idleUp;
    private bool idleDown;

    private bool isPressWalking;
    /// <summary>
    /// 玩家输入是否开启
    /// </summary>
    private bool playerInputIsEnable = true;

    //后期剥离出来，最后用事件
    private GridCursor gridCursor;
    private Cursor cursor;

    private Vector2 input;

    public bool PlayerInputIsEnable => playerInputIsEnable;

    public void EnablePlayerInput()
    {
        playerInputIsEnable = true;
    }

    private FarmPlayer localPlayer;
    private Rigidbody2D rigidgBody;

    public void DisablePlayerInput()
    {
        playerInputIsEnable = false;
    }

    private void Start()
    {
        localPlayer = GameObject.FindObjectOfType<FarmPlayer>();
        rigidgBody = localPlayer.GetComponent<Rigidbody2D>();

        equippedItemSpriteRenderer = localPlayer.EquipRenderer;
        animationOverrides = localPlayer.GetComponent<AnimationOverrides>();

        useToolAnimationPause = new WaitForSeconds(FarmSetting.useToolAnimationPause);
        afterUseToolAnimationPause = new WaitForSeconds(FarmSetting.afterUseToolAnimationPause);
        liftToolAnimationPause = new WaitForSeconds(FarmSetting.liftToolAnimationPause);
        afterLiftToolAnimationPause = new WaitForSeconds(FarmSetting.afterLiftToolAnimationPause);

        gridCursor = GameObject.FindObjectOfType<GridCursor>();
        cursor = GameObject.FindObjectOfType<Cursor>();
    }

    public void DisablePlayerInputAndResetMovement()
    {
        DisablePlayerInput();

        ResetMovement();

        UpdateAnimation();
    }

    private void ResetMovement()
    {
        //Reset Movement
        inputX = 0f;
        inputY = 0f;
        isRunning = false;
        isWalking = false;
        isIdle = true;
    }

    public void OnMove(CallbackContext context)
    {
        if (PlayerInputIsEnable)
        {
            input = context.ReadValue<Vector2>();
        }
    }

    public void OnWalking(CallbackContext context)
    {
        if (context.started)
        {
            isPressWalking = true;
        }
        if (context.canceled)
        {
            isPressWalking = false;
        }
    }

    public void OnClickLeft(CallbackContext context)
    {
        if (!playerToolUseDisabled)
        {
            if (context.canceled)
            {
                if (gridCursor.CursorIsEnabled || cursor.CursorIsEnabled)
                {
                    Vector3Int cursorGridPosition = gridCursor.GetGridPositionForCursor();
                    Vector3Int playerGridPosition = gridCursor.GetGridPositionForPlayer();
                    ProcessPlayerClickInput(cursorGridPosition, playerGridPosition);
                }
            }
        }
    }

    private void ProcessPlayerClickInput(Vector3Int cursorGridPosition, Vector3Int playerGridPosition)
    {
        ResetMovement();

        Vector3Int playerDirection = GetPlayerClickDirection(cursorGridPosition, playerGridPosition);
        GridPropertyDetails gridPropertyDetails = GridPropertiesManager.Instance.GetGridPropertyDetails(cursorGridPosition.x, cursorGridPosition.y);



        ItemDetails itemDetails = InventoryManager.Instance.GetSelectedItemDetail(InventoryLocation.player);

        if (itemDetails != null)
        {
            switch (itemDetails.itemType)
            {
                case ItemType.seed:
                    if (itemDetails.canBeDropped && gridCursor.CursorPositionIsValid)
                    {
                        EventCenter.Instance.Trigger(EventEnum.DROP_SELECTED_ITEM.ToString());
                    }
                    break;
                case ItemType.commodity:
                    if (itemDetails.canBeDropped && gridCursor.CursorPositionIsValid)
                    {
                        EventCenter.Instance.Trigger(EventEnum.DROP_SELECTED_ITEM.ToString());
                    }
                    break;
                case ItemType.watering_tool:
                case ItemType.hoeing_tool:
                    ProcessPlayerClickInputTool(gridPropertyDetails, itemDetails, playerDirection);
                    break;
                case ItemType.reaping_tool:
                    ReapGrooundAtCursor(cursorGridPosition, itemDetails);
                    break;
                default:
                    break;
            }
        }
    }

    private void ProcessPlayerClickInputTool(GridPropertyDetails gridPropertyDetails, ItemDetails itemDetails, Vector3Int playerDirection)
    {
        switch (itemDetails.itemType)
        {
            case ItemType.hoeing_tool:
                if (gridCursor.CursorPositionIsValid)
                {
                    HoeGrooundAtCursor(gridPropertyDetails, playerDirection);
                }
                break;
            case ItemType.chopping_tool:
                break;
            case ItemType.breaking_tool:
                break;
            case ItemType.collection_tool:
                break;
            case ItemType.watering_tool:
                if (gridCursor.CursorPositionIsValid)
                {
                    WaterGrooundAtCursor(gridPropertyDetails, playerDirection);
                }
                break;
            case ItemType.none:
                break;
            case ItemType.count:
                break;
            case ItemType.furniture:
                break;
            case ItemType.reapable_scenery:
                break;
            default:
                break;
        }
    }

    private void ReapGrooundAtCursor(Vector3Int cursorPosition, ItemDetails itemDetails)
    {
        StartCoroutine(ReapGroundAtCursorRoutine(cursorPosition, itemDetails));
    }

    private IEnumerator ReapGroundAtCursorRoutine(Vector3Int cursorPosition, ItemDetails itemDetails)
    {
        playerInputIsEnable = false;
        playerToolUseDisabled = true;

        toolCharacterAttribute.partVariantType = PartVariantType.scythe;
        characterAttributeCustomisationList.Clear();
        characterAttributeCustomisationList.Add(toolCharacterAttribute);
        animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

        toolEffect = ToolEffect.none;

        var playerCentre = Director.Instance.MainPlayer.GetPlayrCentrePosition();

        if (cursorPosition.x > playerCentre.x
            && cursorPosition.y < playerCentre.y + itemDetails.itemUseRadius
            && cursorPosition.y > playerCentre.y - itemDetails.itemUseGridRadius)
        {
            isSwingingToolRight = true;
        }
        else if (cursorPosition.x < playerCentre.x
            && cursorPosition.y < playerCentre.y + itemDetails.itemUseRadius
            && cursorPosition.y > playerCentre.y - itemDetails.itemUseGridRadius)
        {
            isSwingingToolLeft = true;
        }
        else if (cursorPosition.y > playerCentre.y)
        {
            isSwingingToolUp = true;
        }
        else
        {
            isSwingingToolDown = true;
        }

        yield return useToolAnimationPause;

        //对场景的修改
        var dir = GetSwingDir(cursorPosition, itemDetails);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(UniBase.InputUtils.GetMousePosition());
        Debug.Log($"dirReal:{dir},cursorGridPosition:{cursorPosition},worldPos:{worldPos}");
        var detectResult = UniBase.OverlapHelper.GetComponentsAtBoxLocationNonAlloc<Item>(FarmSetting.reapDetectCount,
            playerCentre + (new Vector3(dir.x * itemDetails.itemUseRadius / 2, dir.y * itemDetails.itemUseRadius / 2)),
            itemDetails.itemUseRadius * Vector2.one, 0);
        var targetDestroyNum = Math.Min(detectResult.Length, FarmSetting.multipleReap);
        var curDestroyNum = 0;
        for (int i = detectResult.Length - 1; i >= 0; i--)
        {
            if (detectResult[i] != null)
            {
                Destroy(detectResult[i].gameObject);
                curDestroyNum++;
                if (targetDestroyNum == curDestroyNum)
                {
                    break;
                }
            }
        }

        yield return afterUseToolAnimationPause;

        ResetDir();

        playerInputIsEnable = true;
        playerToolUseDisabled = false;
    }

    private void OnDrawGizmos()
    {
        ItemDetails itemDetails = InventoryManager.Instance.GetSelectedItemDetail(InventoryLocation.player);
        if (gridCursor == null || itemDetails == null) return;
        Vector3Int cursorGridPosition = gridCursor.GetGridPositionForCursor();

        var playerCentre = Director.Instance.MainPlayer.GetPlayrCentrePosition();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(UniBase.InputUtils.GetMousePosition());
        var dir = GetSwingDir(cursorGridPosition, itemDetails);
        Debug.Log($"dir:{dir},cursorGridPosition:{cursorGridPosition},worldPos:{worldPos}");
        var detectResult = UniBase.OverlapHelper.GetComponentsAtBoxLocationNonAlloc<Item>(FarmSetting.reapDetectCount,
            playerCentre + (new Vector3(dir.x * itemDetails.itemUseRadius / 2, dir.y * itemDetails.itemUseRadius / 2)),
            itemDetails.itemUseRadius * Vector2.one, 0);

        var rectCenter = playerCentre + (new Vector3(dir.x * itemDetails.itemUseRadius / 2, dir.y * itemDetails.itemUseRadius / 2));
        var width = itemDetails.itemUseRadius;
        var height = itemDetails.itemUseRadius;
        var p1 = rectCenter + new Vector3(-width, -height) * 0.5f;
        var p2 = rectCenter + new Vector3(-width, height) * 0.5f;
        var p3 = rectCenter + new Vector3(width, height) * 0.5f;
        var p4 = rectCenter + new Vector3(width, -height) * 0.5f;
        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p3, p4);
        Gizmos.DrawLine(p4, p1);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(rectCenter, dir);
    }

    private Vector3Int GetSwingDir(Vector3Int cursorPosition, ItemDetails itemDetails)
    {
        var playerCentre = Director.Instance.MainPlayer.GetPlayrCentrePosition();

        if (cursorPosition.x > playerCentre.x
            && cursorPosition.y < playerCentre.y + itemDetails.itemUseRadius
            && cursorPosition.y > playerCentre.y - itemDetails.itemUseRadius)
        {
            return Vector3Int.right;
        }
        else if (cursorPosition.x < playerCentre.x
            && cursorPosition.y < playerCentre.y + itemDetails.itemUseRadius
            && cursorPosition.y > playerCentre.y - itemDetails.itemUseRadius)
        {
            return Vector3Int.left;

        }
        else if (cursorPosition.y > playerCentre.y)
        {
            return Vector3Int.up;

        }
        else
        {
            return Vector3Int.down;
        }
    }

    private void WaterGrooundAtCursor(GridPropertyDetails gridPropertyDetails, Vector3Int playerDirection)
    {
        StartCoroutine(WaterGroundAtCursorRoutine(playerDirection, gridPropertyDetails));
    }

    private IEnumerator WaterGroundAtCursorRoutine(Vector3Int playerDirection, GridPropertyDetails gridPropertyDetails)
    {
        playerInputIsEnable = false;
        playerToolUseDisabled = true;

        toolCharacterAttribute.partVariantType = PartVariantType.wateringCan;
        characterAttributeCustomisationList.Clear();
        characterAttributeCustomisationList.Add(toolCharacterAttribute);
        animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

        toolEffect = ToolEffect.watering;

        if (playerDirection == Vector3Int.right)
        {
            isLiftingToolRight = true;
        }
        else if (playerDirection == Vector3Int.left)
        {
            isLiftingToolLeft = true;
        }
        else if (playerDirection == Vector3Int.up)
        {
            isLiftingToolUp = true;
        }
        else if (playerDirection == Vector3Int.down)
        {
            isLiftingToolDown = true;
        }

        yield return useToolAnimationPause;

        if (gridPropertyDetails.daysSinceWatered == -1)
        {
            gridPropertyDetails.daysSinceWatered = 0;
        }

        GridPropertiesManager.Instance.SetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY, gridPropertyDetails);

        GridPropertiesManager.Instance.DisplayWaterGroud(gridPropertyDetails);

        yield return afterUseToolAnimationPause;

        ResetDir();

        playerInputIsEnable = true;
        playerToolUseDisabled = false;
    }

    private void HoeGrooundAtCursor(GridPropertyDetails gridPropertyDetails, Vector3Int playerDirection)
    {
        StartCoroutine(HoeGroundAtCursorRoutine(playerDirection, gridPropertyDetails));
    }

    private void ResetDir()
    {
        isUsingToolRight = false;
        isUsingToolLeft = false;
        isUsingToolUp = false;
        isUsingToolDown = false;

        isLiftingToolRight = false;
        isLiftingToolLeft = false;
        isLiftingToolUp = false;
        isLiftingToolDown = false;

        isSwingingToolLeft = false;
        isSwingingToolDown = false;
        isSwingingToolRight = false;
        isSwingingToolUp = false;
    }

    private IEnumerator HoeGroundAtCursorRoutine(Vector3Int playerDirection, GridPropertyDetails gridPropertyDetails)
    {
        playerInputIsEnable = false;
        playerToolUseDisabled = true;

        toolCharacterAttribute.partVariantType = PartVariantType.hoe;
        characterAttributeCustomisationList.Clear();
        characterAttributeCustomisationList.Add(toolCharacterAttribute);
        animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

        if (playerDirection == Vector3Int.right)
        {
            isUsingToolRight = true;
        }
        else if (playerDirection == Vector3Int.left)
        {
            isUsingToolLeft = true;
        }
        else if (playerDirection == Vector3Int.up)
        {
            isUsingToolUp = true;
        }
        else if (playerDirection == Vector3Int.down)
        {
            isUsingToolDown = true;
        }

        yield return useToolAnimationPause;

        if (gridPropertyDetails.daysSinceDug == -1)
        {
            gridPropertyDetails.daysSinceDug = 0;
        }

        GridPropertiesManager.Instance.SetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY, gridPropertyDetails);

        GridPropertiesManager.Instance.DisplayDugGroud(gridPropertyDetails);

        yield return afterUseToolAnimationPause;

        ResetDir();

        playerInputIsEnable = true;
        playerToolUseDisabled = false;
    }

    private Vector3Int GetPlayerClickDirection(Vector3Int cursorGridPosition, Vector3Int playerGridPosition)
    {
        if (cursorGridPosition.x > playerGridPosition.x)
        {
            return Vector3Int.right;
        }
        else if (cursorGridPosition.x < playerGridPosition.x)
        {
            return Vector3Int.left;
        }
        else if (cursorGridPosition.y > playerGridPosition.y)
        {
            return Vector3Int.up;
        }
        else
        {
            return Vector3Int.down;
        }
    }

    private void FixedUpdate()
    {
        #region 参数修改


        inputX = input.x;
        inputY = input.y;

        isIdle = !(input.x != 0 || input.y != 0);
        isWalking = (input.x != 0 || input.y != 0) && isPressWalking;
        isRunning = (input.x != 0 || input.y != 0) && !isPressWalking;

        if (isWalking)
        {
            rigidgBody.MovePosition(rigidgBody.position + FarmSetting.walkSpeed * Time.fixedDeltaTime * input);
        }
        if (isRunning)
        {
            rigidgBody.MovePosition(rigidgBody.position + FarmSetting.runSpeed * Time.fixedDeltaTime * input);
        }
        if (isIdle)
        {
        }
        #endregion

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        EventHandler.CallMovementEvent(inputX, inputY, isWalking, isRunning, isIdle, isCarrying, toolEffect,
    isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
   isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
   isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
   isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
   idleRight, idleLeft, idleUp, idleDown);
    }

    protected override void Awake()
    {
        base.Awake();

        armsCharacterAttribute = new CharacterAttribute(CharacterPartAnimator.arms, PartVariantColour.none, PartVariantType.none);
        characterAttributeCustomisationList = new List<CharacterAttribute>();
    }

    public void ShowCarriedItem(int itemCode)
    {
        ItemDetails itemDetails = InventoryManager.Instance.GetItemDetail(itemCode);
        if (itemDetails != null)
        {
            equippedItemSpriteRenderer.sprite = itemDetails.itemSprite;
            equippedItemSpriteRenderer.color = new Color(1, 1, 1, 1);

            armsCharacterAttribute.partVariantType = PartVariantType.carry;
            characterAttributeCustomisationList.Clear();
            characterAttributeCustomisationList.Add(armsCharacterAttribute);
            animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

            isCarrying = true;
        }
    }

    public void ClearCarriedItem()
    {
        equippedItemSpriteRenderer.sprite = null;
        equippedItemSpriteRenderer.color = new Color(1, 1, 1, 0);

        armsCharacterAttribute.partVariantType = PartVariantType.none;
        characterAttributeCustomisationList.Clear();
        characterAttributeCustomisationList.Add(armsCharacterAttribute);
        animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

        isCarrying = false;
    }
}
