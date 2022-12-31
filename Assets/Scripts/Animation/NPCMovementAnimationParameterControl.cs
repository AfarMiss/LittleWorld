using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;

public class NPCMovementAnimationParameterControl : MonoBehaviour
{
    private string inputXString = "xInput";
    private string inputYString = "yInput";
    private string isWalkingString = "isWalking";
    private string isRunningString = "isRunning";

    private string toolEffectString = "toolEffect";
    private string isUsingToolRightString = "isUsingToolRight";
    private string isUsingToolLeftString = "isUsingToolLeft";
    private string isUsingToolUpString = "isUsingToolUp";
    private string isUsingToolDownString = "isUsingToolDown";
    private string isLiftingToolRightString = "isLiftingToolRight";
    private string isLiftingToolLeftString = "isLiftingToolLeft";
    private string isLiftingToolUpString = "isLiftingToolUp";
    private string isLiftingToolDownString = "isLiftingToolDown";
    private string isPickingRightString = "isPickingRight";
    private string isPickingLeftString = "isPickingLeft";
    private string isPickingUpString = "isPickingUp";
    private string isPickingDownString = "isPickingDown";
    private string isSwingingToolRightString = "isSwingingToolRight";
    private string isSwingingToolLeftString = "isSwingingToolLeft";
    private string isSwingingToolUpString = "isSwingingToolUp";
    private string isSwingingToolDownString = "isSwingingToolDown";
    private string idleRightString = "idleRight";
    private string idleLeftString = "idleLeft";
    private string idleUpString = "idleUp";
    private string idleDownString = "idleDown";

    public Animator[] animators;

    public float inputX;
    public float inputY;
    public bool isWalking;
    public bool isRunning;
    public bool isIdle;
    public bool isCarrying;
    public ToolEffect toolEffect;
    public bool isUsingToolRight;
    public bool isUsingToolLeft;
    public bool isUsingToolUp;
    public bool isUsingToolDown;
    public bool isLiftingToolRight;
    public bool isLiftingToolLeft;
    public bool isLiftingToolUp;
    public bool isPickingRight;
    public bool isPickingLeft;
    public bool isLiftingToolDown;
    public bool isPickingUp;
    public bool isPickingDown;
    public bool isSwingingToolRight;
    public bool isSwingingToolLeft;
    public bool isSwingingToolUp;
    public bool isSwingingToolDown;
    public bool idleRight;
    public bool idleLeft;
    public bool idleUp;
    public bool idleDown;

    private void Init()
    {
        animators = GetComponentsInChildren<Animator>();
    }

    public void SetParam(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying,
    ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
    bool idleRight, bool idleLeft, bool idleUp, bool idleDown)
    {

    }

    public void ResetMovement()
    {
        //Reset Movement
        inputX = 0f;
        inputY = 0f;
        isRunning = false;
        isWalking = false;
        isIdle = true;
    }

    private void Update()
    {
        var curDir = GetComponent<PathNavigation>().Speed;
        if (curDir.magnitude > 0)
        {
            isWalking = true;
        }

        inputX = curDir.x;
        inputY = curDir.y;

        foreach (var item in animators)
        {
            SetAnimationParameter(item, inputX, inputY, isWalking, isRunning, isIdle,
                isCarrying, toolEffect, isUsingToolRight, isUsingToolLeft, isUsingToolUp,
                isUsingToolDown, isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp,
                isLiftingToolDown, isPickingRight, isPickingLeft, isPickingUp, isPickingDown, isSwingingToolRight,
                isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown, idleRight, idleLeft, idleUp, idleDown);
        }
    }

    private void SetAnimationParameter(Animator animator, float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying,
    ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
    bool idleRight, bool idleLeft, bool idleUp, bool idleDown)
    {
        animator.SetFloat(FarmSetting.inputXIndex, inputX);
        animator.SetFloat(FarmSetting.inputYIndex, inputY);
        animator.SetBool(FarmSetting.isWalkingIndex, isWalking);
        animator.SetBool(FarmSetting.isRunningIndex, isRunning);

        animator.SetInteger(FarmSetting.toolEffectIndex, (int)toolEffect);
        animator.SetBool(FarmSetting.isUsingToolRightIndex, isUsingToolRight);
        animator.SetBool(FarmSetting.isUsingToolLeftIndex, isUsingToolLeft);
        animator.SetBool(FarmSetting.isUsingToolUpIndex, isUsingToolUp);
        animator.SetBool(FarmSetting.isUsingToolDownIndex, isUsingToolDown);
        animator.SetBool(FarmSetting.isLiftingToolRightIndex, isLiftingToolRight);
        animator.SetBool(FarmSetting.isLiftingToolLeftIndex, isLiftingToolLeft);
        animator.SetBool(FarmSetting.isLiftingToolUpIndex, isLiftingToolUp);
        animator.SetBool(FarmSetting.isLiftingToolDownIndex, isLiftingToolDown);
        animator.SetBool(FarmSetting.isPickingRightIndex, isPickingRight);
        animator.SetBool(FarmSetting.isPickingLeftIndex, isPickingLeft);
        animator.SetBool(FarmSetting.isPickingUpIndex, isPickingUp);
        animator.SetBool(FarmSetting.isPickingDownIndex, isPickingDown);
        animator.SetBool(FarmSetting.isSwingingToolRightIndex, isSwingingToolRight);
        animator.SetBool(FarmSetting.isSwingingToolLeftIndex, isSwingingToolLeft);
        animator.SetBool(FarmSetting.isSwingingToolUpIndex, isSwingingToolUp);
        animator.SetBool(FarmSetting.isSwingingToolDownIndex, isSwingingToolDown);
        animator.SetBool(FarmSetting.idleRightIndex, idleRight);
        animator.SetBool(FarmSetting.idleLeftIndex, idleLeft);
        animator.SetBool(FarmSetting.idleUpIndex, idleUp);
        animator.SetBool(FarmSetting.idleDownIndex, idleDown);
    }

    private void Start()
    {
        Init();
    }
}
