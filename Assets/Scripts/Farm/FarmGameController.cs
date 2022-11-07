using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class FarmGameController : MonoSingleton<FarmGameController>
{
    private AnimationOverrides animationOverrides;
    private List<CharacterAttribute> characterAttributeCustomisationList;

    private CharacterAttribute armsCharacterAttribute;
    private CharacterAttribute toolCharacterAttribute;

    [Tooltip("Should be populated in the prefab with the equipped item sprite renderer")]
    [SerializeField] private SpriteRenderer equippedItemSpriteRenderer = null;

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
    private bool isLiftingToolDown;
    private bool isPickingRight;
    private bool isPickingLeft;
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
    private bool playerInputIsEnable = true;

    private Vector2 input;

    public bool PlayerInputIsEnable => playerInputIsEnable;

    public void EnablePlayerInput()
    {
        playerInputIsEnable = true;
    }

    public void DisablePlayerInput()
    {
        playerInputIsEnable = false;
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

    private void FixedUpdate()
    {
        #region 参数修改
        var localPlayer = GameObject.FindObjectOfType<FarmPlayer>();
        var rigidgBody = localPlayer.GetComponent<Rigidbody2D>();

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

        animationOverrides = GetComponentInChildren<AnimationOverrides>();
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
