using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInfoPanel : BaseUI
{
    public Text houtText;
    public Text YearQuadDayText;

    public override string path => UIPath.Main_UI_Panel;

    private void OnEnable()
    {
        EventCenter.Instance.Register<GameTime>((nameof(EventEnum.YEAR_CHANGE)), BindData);
        EventCenter.Instance.Register<GameTime>((nameof(EventEnum.QUAD_CHANGE)), BindData);
        EventCenter.Instance.Register<GameTime>((nameof(EventEnum.DAY_CHANGE)), BindData);
        EventCenter.Instance.Register<GameTime>((nameof(EventEnum.HOUR_CHANGE)), BindData);
        EventCenter.Instance.Register<GameTime>((nameof(EventEnum.MINUTE_CHANGE)), BindData);
        EventCenter.Instance.Register<GameTime>((nameof(EventEnum.SECOND_CHANGE)), BindData);
        EventCenter.Instance.Register<GameTime>((nameof(EventEnum.GAME_TICK)), BindData);
    }

    private void OnDisable()
    {
        EventCenter.Instance?.Unregister<GameTime>((nameof(EventEnum.YEAR_CHANGE)), BindData);
        EventCenter.Instance?.Unregister<GameTime>((nameof(EventEnum.QUAD_CHANGE)), BindData);
        EventCenter.Instance?.Unregister<GameTime>((nameof(EventEnum.DAY_CHANGE)), BindData);
        EventCenter.Instance?.Unregister<GameTime>((nameof(EventEnum.HOUR_CHANGE)), BindData);
        EventCenter.Instance?.Unregister<GameTime>((nameof(EventEnum.MINUTE_CHANGE)), BindData);
        EventCenter.Instance?.Unregister<GameTime>((nameof(EventEnum.SECOND_CHANGE)), BindData);
        EventCenter.Instance?.Unregister<GameTime>((nameof(EventEnum.GAME_TICK)), BindData);
    }

    public void BindData(GameTime time)
    {
        houtText.text = $"{time.hour}时";
        YearQuadDayText.text = $"{time.year}年 {time.quad}象 {time.day}日";
    }

    public override void OnClickClose()
    {
        UIManager.Instance.Hide<MainInfoPanel>(UIType.PANEL);
    }
}
