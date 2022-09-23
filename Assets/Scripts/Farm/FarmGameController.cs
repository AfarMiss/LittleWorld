using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class FarmGameController : MonoBehaviour
{
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

    //public float inputX;
    //public float inputY;
    //public bool isWalking;
    //public bool isRunning;
    //public bool isIdle;
    //public bool isCarrying;
    //public ToolEffect toolEffect;
    //public bool isUsingToolRight;
    //public bool isUsingToolLeft;
    //public bool isUsingToolUp;
    //public bool isUsingToolDown;
    //public bool isLiftingToolRight;
    //public bool isLiftingToolLeft;
    //public bool isLiftingToolUp;
    //public bool isLiftingToolDown;
    //public bool isPickingRight;
    //public bool isPickingLeft;
    //public bool isPickingUp;
    //public bool isPickingDown;
    //public bool isSwingingToolRight;
    //public bool isSwingingToolLeft;
    //public bool isSwingingToolUp;
    //public bool isSwingingToolDown;
    //public bool idleRight;
    //public bool idleLeft;
    //public bool idleUp;
    //public bool idleDown;

    private bool isPressWalking;

    [Range(1, 2)] public float walkSpeed = 2f;
    [Range(4, 8)] public float runSpeed = 4f;

    private Vector2 input;

    public void OnMove(CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
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
        #region ²ÎÊýÐÞ¸Ä
        var localPlayer = GameObject.FindObjectOfType<FarmPlayer>();
        var rigidgBody = localPlayer.GetComponent<Rigidbody2D>();

        inputX = input.x;
        inputY = input.y;

        isIdle = !(input.x != 0 || input.y != 0);
        isWalking = (input.x != 0 || input.y != 0) && isPressWalking;
        isRunning = (input.x != 0 || input.y != 0) && !isPressWalking;

        if (isWalking)
        {
            rigidgBody.MovePosition(rigidgBody.position + walkSpeed * Time.fixedDeltaTime * input);
        }
        if (isRunning)
        {
            rigidgBody.MovePosition(rigidgBody.position + runSpeed * Time.fixedDeltaTime * input);
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
}
