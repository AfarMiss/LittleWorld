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
    right,
    none
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
    animal,
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

/// <summary>
/// 身体部位
/// </summary>
public enum CharacterPartAnimator
{
    body,
    arms,
    hair,
    tool,
    hat,
    count
}

/// <summary>
/// 部位颜色
/// </summary>
public enum PartVariantColour
{
    none,
    count
}

/// <summary>
/// 动画类型
/// </summary>
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

public enum SceneEnum
{
    PersistentScene,
    FarmScene,
    Entry,
}

public enum GridBoolProperty
{
    diggable,
    canDropItem,
    canPlaceFurniture,
    isPath,
    isNPCObstacle
}

public enum HarvestActionEffect
{

    deciduousLeavesFalling,
    pineConesFalling,
    choppingTreeTrunk,
    breakingStone,
    reaping,
    none,
}

public enum Facing
{
    none,
    front,
    back,
    right,
}

public enum WorkTypeEnum
{
    dug,
    water,
    gotoLoc,
    cut,
    harvest,
    sow,
    carry,
}

public enum SoundName
{
    none = 0,
    effectFootstepSoftGround = 10,
    effectFootstepHardGround = 20,
    effectAxe = 30,
    effectPickaxe = 40,
    effectScythe = 50,
    effectHoe = 60,
    effectWateringCan = 70,
    effectBasket = 80,
    effectPickupSound = 90,
    effectRustle = 100,
    effectTreeFalling = 110,
    effectPlantingSound = 120,
    effectPluck = 130,
    effectStoneShatter = 140,
    effectWoodSplinters = 150,
    ambientCountryside1 = 1000,
    ambientCountryside2 = 1010,
    ambientIndoors1 = 1020,
    musicCalm3 = 2000,
    musicCalm1 = 2010,
}

public enum PoolEnum
{
    Sounds,
    Progress,
}

public enum ActionEnum
{
    PICK,
}

public enum MapSize
{
    SMALL,
    MEDIUM,
    LARGE,
}

public enum TerrainLayer
{
    Altitude,
    Terrain,
    Item
}

public enum MouseState
{
    Normal,
    ExpandZone,
    ShrinkZone,
    AddSection,
    DeleteSection,
    ExpandStorageZone,
    ShrinkStorageZone,
    AddStorageSection,
    DeleteStorageSection,
}