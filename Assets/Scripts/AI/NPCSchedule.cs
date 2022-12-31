using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCSchedule
{
    public Vector2Int targetPos;
    public WorkType workType;
    /// <summary>
    /// 持续时间(单位/小时)
    /// </summary>
    public float lastTime;
}
