using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private static readonly string path = "Prefabs/UI/Panel/StartPanel";
    public StartPanel() : base(new UIType(path))
    {
    }

    public override void OnEnter()
    {
        UITool.GetOrAddCompnentInChildren<Button>("Start").onClick.AddListener(() =>
        {
            Debug.Log("click!!!");
        });
    }
}
