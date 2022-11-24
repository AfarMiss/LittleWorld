using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏基类，总开关
/// </summary>
public class Director : MonoSingleton<Director>
{
    public FarmPlayer MainPlayer
    {
        get
        {
            return GameObject.FindObjectOfType<FarmPlayer>();
        }
    }

    private void Start()
    {
        UIManager.Instance.Show<MainInfoPanel>(UIType.PANEL, UIPath.Main_UI_Panel);
        TimeManager.Instance.Init();
    }
}
