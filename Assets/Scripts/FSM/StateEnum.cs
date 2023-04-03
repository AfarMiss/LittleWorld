using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    /// <summary>
    /// 未初始化
    /// </summary>
    UNINIT,
    /// <summary>
    /// 准备
    /// </summary>
    PREPARING,
    /// <summary>
    /// 正在游戏,有殖民者
    /// </summary>
    PLAYING,
    /// <summary>
    /// 仍在游戏中，但无殖民者
    /// </summary>
    NOPAWN,
}
