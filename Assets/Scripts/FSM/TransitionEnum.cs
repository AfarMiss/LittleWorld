//Author：GuoYiBo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TransitionEnum
{
    /// <summary>
    /// 无条件
    /// </summary>
    NONE,
    /// <summary>
    /// 结束弹射阶段
    /// </summary>
    END_SHOOTING,
    /// <summary>
    /// 结束结算阶段
    /// </summary>
    END_CALCULATE,
    /// <summary>
    /// 结束升级阶段
    /// </summary>
    END_LEVEL_UP,
    /// <summary>
    /// 结束敌人回合
    /// </summary>
    END_ENEMY_ROUND,
    /// <summary>
    /// 胜利
    /// </summary>
    VICTORY,
    END_VICTORY,
    END_START_STATE
}
