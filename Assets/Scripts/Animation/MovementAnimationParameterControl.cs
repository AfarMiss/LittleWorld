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
        AudioManager.Instance.PlaySound(SoundName.effectFootstepHardGround);
    }

    private void OnEnable()
    {
        EventHandler.MovementEvent += SetAnimationParameter;
    }

    private void OnDisable()
    {
        EventHandler.MovementEvent -= SetAnimationParameter;
    }

    private void SetAnimationParameter(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying,
    ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
    bool idleRight, bool idleLeft, bool idleUp, bool idleDown)
    {
        animator.SetFloat(GameSetting.inputXIndex, inputX);
        animator.SetFloat(GameSetting.inputYIndex, inputY);
        animator.SetBool(GameSetting.isWalkingIndex, isWalking);
        animator.SetBool(GameSetting.isRunningIndex, isRunning);

        animator.SetInteger(GameSetting.toolEffectIndex, (int)toolEffect);
        animator.SetBool(GameSetting.isUsingToolRightIndex, isUsingToolRight);
        animator.SetBool(GameSetting.isUsingToolLeftIndex, isUsingToolLeft);
        animator.SetBool(GameSetting.isUsingToolUpIndex, isUsingToolUp);
        animator.SetBool(GameSetting.isUsingToolDownIndex, isUsingToolDown);
        animator.SetBool(GameSetting.isLiftingToolRightIndex, isLiftingToolRight);
        animator.SetBool(GameSetting.isLiftingToolLeftIndex, isLiftingToolLeft);
        animator.SetBool(GameSetting.isLiftingToolUpIndex, isLiftingToolUp);
        animator.SetBool(GameSetting.isLiftingToolDownIndex, isLiftingToolDown);
        animator.SetBool(GameSetting.isPickingRightIndex, isPickingRight);
        animator.SetBool(GameSetting.isPickingLeftIndex, isPickingLeft);
        animator.SetBool(GameSetting.isPickingUpIndex, isPickingUp);
        animator.SetBool(GameSetting.isPickingDownIndex, isPickingDown);
        animator.SetBool(GameSetting.isSwingingToolRightIndex, isSwingingToolRight);
        animator.SetBool(GameSetting.isSwingingToolLeftIndex, isSwingingToolLeft);
        animator.SetBool(GameSetting.isSwingingToolUpIndex, isSwingingToolUp);
        animator.SetBool(GameSetting.isSwingingToolDownIndex, isSwingingToolDown);
        animator.SetBool(GameSetting.idleRightIndex, idleRight);
        animator.SetBool(GameSetting.idleLeftIndex, idleLeft);
        animator.SetBool(GameSetting.idleUpIndex, idleUp);
        animator.SetBool(GameSetting.idleDownIndex, idleDown);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
