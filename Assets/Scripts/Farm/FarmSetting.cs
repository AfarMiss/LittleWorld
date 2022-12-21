using UnityEngine;

public static class FarmSetting
{
    public const float walkSpeed = 2f;
    public const float runSpeed = 4f;

    public static int playerCurrentRepositoryCapacity = 24;
    public static int playerMaxRepositoryCapacity = 48;

    public const float targetAlpha = 0.45f;
    public const float fadeInSeconds = 0.25f;
    public const float fadeOutSeconds = 0.25f;

    public const float gridCellSize = 1f;
    public static Vector2 cursorSize = Vector2.one;

    public static float playerCentreYOffset = 0.875f;

    //reaping
    public static int multipleReap = 2;
    public static int reapDetectCount = 5;

    public static float useToolAnimationPause = 0.25f;
    public static float afterUseToolAnimationPause = 0.2f;
    public static float liftToolAnimationPause = 0.4f;
    public static float afterLiftToolAnimationPause = 0.4f;

    public const float gameTick = 0.001f;

    private static string inputXString = "xInput";
    private static string inputYString = "yInput";
    private static string isWalkingString = "isWalking";
    private static string isRunningString = "isRunning";

    public const string HoeingTool = "Hoe";
    public const string Axe = "Axe";
    public const string Pickaxe = "Pickaxe";
    public const string ReapingTool = "ReapingTool";
    public const string WateringTool = "WateringTool";
    public const string CollectingTool = "CollectingTool";
    public const string BreakingTool = "BreakingTool";
    public const string ChoppingTool = "ChoppingTool";

    private static string toolEffectString = "toolEffect";
    private static string isUsingToolRightString = "isUsingToolRight";
    private static string isUsingToolLeftString = "isUsingToolLeft";
    private static string isUsingToolUpString = "isUsingToolUp";
    private static string isUsingToolDownString = "isUsingToolDown";
    private static string isLiftingToolRightString = "isLiftingToolRight";
    private static string isLiftingToolLeftString = "isLiftingToolLeft";
    private static string isLiftingToolUpString = "isLiftingToolUp";
    private static string isLiftingToolDownString = "isLiftingToolDown";
    private static string isPickingRightString = "isPickingRight";
    private static string isPickingLeftString = "isPickingLeft";
    private static string isPickingUpString = "isPickingUp";
    private static string isPickingDownString = "isPickingDown";
    private static string isSwingingToolRightString = "isSwingingToolRight";
    private static string isSwingingToolLeftString = "isSwingingToolLeft";
    private static string isSwingingToolUpString = "isSwingingToolUp";
    private static string isSwingingToolDownString = "isSwingingToolDown";
    private static string idleRightString = "idleRight";
    private static string idleLeftString = "idleLeft";
    private static string idleUpString = "idleUp";
    private static string idleDownString = "idleDown";

    public static int inputXIndex;
    public static int inputYIndex;
    public static int isWalkingIndex;
    public static int isRunningIndex;

    public static int toolEffectIndex;
    public static int isUsingToolRightIndex;
    public static int isUsingToolLeftIndex;
    public static int isUsingToolUpIndex;
    public static int isUsingToolDownIndex;
    public static int isLiftingToolRightIndex;
    public static int isLiftingToolLeftIndex;
    public static int isLiftingToolUpIndex;
    public static int isLiftingToolDownIndex;
    public static int isPickingRightIndex;
    public static int isPickingLeftIndex;
    public static int isPickingUpIndex;
    public static int isPickingDownIndex;
    public static int isSwingingToolRightIndex;
    public static int isSwingingToolLeftIndex;
    public static int isSwingingToolUpIndex;
    public static int isSwingingToolDownIndex;
    public static int idleRightIndex;
    public static int idleLeftIndex;
    public static int idleUpIndex;
    public static int idleDownIndex;

    static FarmSetting()
    {
        inputXIndex = Animator.StringToHash(inputXString);
        inputYIndex = Animator.StringToHash(inputYString);
        isWalkingIndex = Animator.StringToHash(isWalkingString);
        isRunningIndex = Animator.StringToHash(isRunningString);

        toolEffectIndex = Animator.StringToHash(toolEffectString);
        isUsingToolRightIndex = Animator.StringToHash(isUsingToolRightString);
        isUsingToolLeftIndex = Animator.StringToHash(isUsingToolLeftString);
        isUsingToolUpIndex = Animator.StringToHash(isUsingToolUpString);
        isUsingToolDownIndex = Animator.StringToHash(isUsingToolDownString);
        isLiftingToolRightIndex = Animator.StringToHash(isLiftingToolRightString);
        isLiftingToolLeftIndex = Animator.StringToHash(isLiftingToolLeftString);
        isLiftingToolUpIndex = Animator.StringToHash(isLiftingToolUpString);
        isLiftingToolDownIndex = Animator.StringToHash(isLiftingToolDownString);
        isPickingRightIndex = Animator.StringToHash(isPickingRightString);
        isPickingLeftIndex = Animator.StringToHash(isPickingLeftString);
        isPickingUpIndex = Animator.StringToHash(isPickingUpString);
        isPickingDownIndex = Animator.StringToHash(isPickingDownString);
        isSwingingToolRightIndex = Animator.StringToHash(isSwingingToolRightString);
        isSwingingToolLeftIndex = Animator.StringToHash(isSwingingToolLeftString);
        isSwingingToolUpIndex = Animator.StringToHash(isSwingingToolUpString);
        isSwingingToolDownIndex = Animator.StringToHash(isSwingingToolDownString);
        idleRightIndex = Animator.StringToHash(idleRightString);
        idleLeftIndex = Animator.StringToHash(idleLeftString);
        idleUpIndex = Animator.StringToHash(idleUpString);
        idleDownIndex = Animator.StringToHash(idleDownString);
    }


}