using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BaseUI
{
    public override string path => UIPath.Panel_SettingPanel;

    public override void OnClickClose()
    {
        UIManager.Instance.Hide<SettingPanel>(UIType.PANEL);
    }
}
