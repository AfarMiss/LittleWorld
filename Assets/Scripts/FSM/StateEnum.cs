using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateEnum
{
    /// <summary>
    /// 等待
    /// </summary>
    WAITING,
    /// <summary>
    /// 弹射流程
    /// </summary>
    SHOOT,
    /// <summary>
    /// 停止/结算流程
    /// </summary>
    CALCULATION,
    /// <summary>
    /// 三选一升级流程
    /// </summary>
    LEVEL_UP,
    /// <summary>
    /// 敌人回合
    /// </summary>
    ENEMY,
    /// <summary>
    /// 胜利
    /// </summary>
    VICTORY
}
