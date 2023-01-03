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

    #region 时间相关事件
    YEAR_CHANGE,
    QUAD_CHANGE,
    DAY_CHANGE,
    HOUR_CHANGE,
    MINUTE_CHANGE,
    SECOND_CHANGE,

    GAME_TICK,
    #endregion

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

    /// <summary>
    /// 采摘果实
    /// </summary>
    PICK_FRUIT,
}
