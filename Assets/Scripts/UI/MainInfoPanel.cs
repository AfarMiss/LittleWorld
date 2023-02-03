﻿using LittleWorld;
using LittleWorld.Command;
using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LittleWorld.UI
{
    public class MainInfoPanel : BaseUI
    {
        public Text houtText;
        public Text YearQuadDayText;

        public override string Path => UIPath.Main_UI_Panel;

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


        public void ExpandZone()
        {
            CommandCenter.Instance.Enqueue(new ChangeMouseStateCommand(MouseState.ExpandZone));
        }

        public void ShrinkZone()
        {
            CommandCenter.Instance.Enqueue(new ChangeMouseStateCommand(MouseState.ShrinkZone));
        }

        public void DeleteSection()
        {
            CommandCenter.Instance.Enqueue(new ChangeMouseStateCommand(MouseState.DeleteSection));
        }

        public void AddSection()
        {
            CommandCenter.Instance.Enqueue(new ChangeMouseStateCommand(MouseState.AddSection));
        }
    }

}

