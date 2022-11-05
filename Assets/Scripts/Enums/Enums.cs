public enum ToolEffect
{
    none,
    watering
}

public enum InventoryLocation
{
    /// <summary>
    /// 玩家自身
    /// </summary>
    player,
    /// <summary>
    /// 箱子中
    /// </summary>
    chest,
    /// <summary>
    /// 账户中
    /// </summary>
    account,
}

public enum Direction
{
    up,
    down,
    left,
    right
}

public enum ItemType
{
    seed,
    commodity,
    hoeing_tool,
    chopping_tool,
    breaking_tool,
    collection_tool,
    watering_tool,
    reaping_tool,
    none,
    count,
    furniture,
    reapable_scenery,
}

public enum AnimationName
{
    idleDown,
    idleUp,
    idleLeft,
    idleRight,
    walkUp,
    walkRight,
    walkDown,
    walkLeft,
    runUp,
    runRight,
    runLeft,
    runDown,
    useToolUp,
    useToolRight,
    useToolLeft,
    useToolDown,
    swingToolUp,
    swingToolRight,
    swingToolLeft,
    swingToolDown,
    liftToolUp,
    liftToolRight,
    liftToolLeft,
    liftToolDown,
    holdToolUp,
    holdToolRight,
    holdToolLeft,
    holdToolDown,
    pickDown,
    pickLeft,
    pickRight,
    pickUp,
    count
}

public enum CharacterPartAnimator
{
    body,
    arms,
    hair,
    tool,
    hat,
    count
}

public enum PartVariantColour
{
    none,
    count
}

public enum PartVariantType
{
    none,
    carry,
    hoe,
    pickaxe,
    axe,
    scythe,
    wateringCan,
    count
}