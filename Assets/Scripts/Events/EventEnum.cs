using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventEnum
{
    /// <summary>
    /// 用户改变可见仓库中选中的内容
    /// </summary>
    CLIENT_CHANGE_BAR_SELECTED,
    /// <summary>
    /// 管理器改变选中内容对应UI
    /// </summary>
    UPDATE_INVENTORY,
    /// <summary>
    /// 丢弃选中物品
    /// </summary>
    DROP_SELECTED_ITEM,

    #region 场景相关事件
    BEFORE_FADE_OUT,
    BEFORE_SCENE_UNLOAD,
    AFTER_NEXT_SCENE_LOAD,
    AFTER_FADE_IN,
    #endregion

    #region VFX
    VFX_HARVEST_ACTION_EFFECT,
    REMOVE_SELECTED_ITEM_FROM_INVENTORY,
    #endregion
    GRID_MODIFY,
    INSTANTIATE_CROP_PREFAB,

    REACH_WORK_POINT,

    #region 工作相关
    WORK_GOTO_WORK_POS,
    WORK_WORKING,
    WORK_SUSPEND,
    WORK_DONE,
    FORCE_ABORT,
    #endregion

    #region 游戏流程相关
    START_NEW_GAME,
    #endregion

    #region UI相关
    UI_UPDATE_PLANT_CODE,
    #endregion
}

public class EventName
{
    internal static readonly string CHANGE_SCENE = "CHANGE_SCENE";
    #region 时间相关事件
    public static string YEAR_CHANGE = "YEAR_CHANGE";
    public static string QUAD_CHANGE = "QUAD_CHANGE";
    public static string DAY_CHANGE = "DAY_CHANGE";
    public static string HOUR_CHANGE = "HOUR_CHANGE";
    public static string MINUTE_CHANGE = "MINUTE_CHANGE";
    public static string GAME_TICK = "GAME_TICK";
    public static string REAL_TIME_TICK = "REAL_TIME_TICK";

    public static string LIVING_AGE_YEAR_CHANGE = "ANIMAL_AGE_YEAR_CHANGE";
    public static string LIVING_AGE_DAY_CHANGE = "ANIMAL_AGE_DAY_CHANGE";
    public static string LIVING_BE_HURT = "LIVING_BE_HURT";
    #endregion

    #region 物体注册
    public static string WORLD_OBJECT_DROP = "WORLD_OBJECT_DROP";
    public static string WORLD_OBJECT_DELETE = "WORLD_OBJECT_DELETE";
    public static string WORLD_OBJECT_PICK = "WORLD_OBJECT_PICK";
    #endregion

    public static string OBJECT_GRID_CHANGE = "OBJECT_GRID_CHANGE";

    #region 显示更新
    public static string UPDATE_WEAPON = "UPDATE_WEAPON";
    public static string UPDATE_LIVING_STATE = "UPDATE_LIVING_STATE";
    #endregion

}
