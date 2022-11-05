using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventEnum
{
    /// <summary>
    /// 清理可见仓库中选中的内容
    /// </summary>
    CLEAR_BAR_SELECTED,
    /// <summary>
    /// 改变可见仓库中选中的内容
    /// </summary>
    CLIENT_CHANGE_BAR_SELECTED,
    /// <summary>
    /// 管理器改变选中内容对应UI
    /// </summary>
    UI_CHANGE_BAR_SELECTED,
}
