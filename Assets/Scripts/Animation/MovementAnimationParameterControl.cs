using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationParameterControl : MonoBehaviour
{
    private string inputXString = "xInput";
    private string inputYString = "yInput";
    private string isWalkingString = "isWalking";
    private string isRunningString = "isRunning";
    private string isIdleString = "isIdle";
    private string isCarryingString = "isCarrying";
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
        animator.SetFloat(Animator.StringToHash(inputXString), inputX);
        animator.SetFloat(Animator.StringToHash(inputYString), inputY);
        animator.SetBool(Animator.StringToHash(isWalkingString), isWalking);
        animator.SetBool(Animator.StringToHash(isRunningString), isRunning);
        animator.SetBool(Animator.StringToHash(isIdleString), isIdle);
        animator.SetBool(Animator.StringToHash(isCarryingString), isCarrying);
        animator.SetInteger(Animator.StringToHash(toolEffectString),(int)toolEffect);
        animator.SetBool(Animator.StringToHash(isUsingToolRightString), isUsingToolRight);
        animator.SetBool(Animator.StringToHash(isUsingToolLeftString), isUsingToolLeft);
        animator.SetBool(Animator.StringToHash(isUsingToolUpString), isUsingToolUp);
        animator.SetBool(Animator.StringToHash(isUsingToolDownString), isUsingToolDown);
        animator.SetBool(Animator.StringToHash(isLiftingToolRightString), isLiftingToolRight);
        animator.SetBool(Animator.StringToHash(isLiftingToolLeftString), isLiftingToolLeft);
        animator.SetBool(Animator.StringToHash(isLiftingToolUpString), isLiftingToolUp);
        animator.SetBool(Animator.StringToHash(isLiftingToolDownString), isLiftingToolDown);
        animator.SetBool(Animator.StringToHash(isPickingRightString), isPickingRight);
        animator.SetBool(Animator.StringToHash(isPickingLeftString), isPickingLeft);
        animator.SetBool(Animator.StringToHash(isPickingUpString), isPickingUp);
        animator.SetBool(Animator.StringToHash(isPickingDownString), isPickingDown);
        animator.SetBool(Animator.StringToHash(isSwingingToolRightString), isSwingingToolRight);
        animator.SetBool(Animator.StringToHash(isSwingingToolLeftString), isSwingingToolLeft);
        animator.SetBool(Animator.StringToHash(isSwingingToolUpString), isSwingingToolUp);
        animator.SetBool(Animator.StringToHash(isSwingingToolDownString), isSwingingToolDown);
        animator.SetBool(Animator.StringToHash(idleRightString), idleRight);
        animator.SetBool(Animator.StringToHash(idleLeftString), idleLeft);
        animator.SetBool(Animator.StringToHash(idleUpString), idleUp);
        animator.SetBool(Animator.StringToHash(idleDownString), idleDown);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
