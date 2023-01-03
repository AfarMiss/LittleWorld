using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏基类，总开关
/// </summary>
public class Director : MonoSingleton<Director>
{
    private void Start()
    {
        UIManager.Instance.Show<MainInfoPanel>(UIType.PANEL, UIPath.Main_UI_Panel);
        UIManager.Instance.Show<ProgressPanel>(UIType.PANEL, UIPath.Panel_ProgressPanel);
        //UIManager.Instance.Show<UIInventoryBar>(UIType.PANEL, UIPath.Panel_ConciseInventoryPanel);
        TimeManager.Instance.Init();
    }
}
