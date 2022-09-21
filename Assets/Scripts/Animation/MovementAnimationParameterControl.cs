using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationParameterControl : MonoBehaviour
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

    public Animator animator;
    private void AnimationEventPlayFootstepSound()
    {
    }

    private void OnEnable()
    {
        EventHandler.MovementEevent += SetAnimationParameter;
    }

    private void OnDisable()
    {
        EventHandler.MovementEevent -= SetAnimationParameter;
    }

    private void SetAnimationParameter(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying,
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

        animator.SetInteger(FarmSetting.toolEffectIndex,(int)toolEffect);
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
        animator = GetComponent<Animator>();
    }
}
