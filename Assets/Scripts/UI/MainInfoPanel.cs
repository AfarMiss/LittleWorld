using LittleWorld;
using LittleWorld.Command;
using LittleWorld.Item;
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
        public List<Image> speedBg;

        public override string Path => UIPath.Main_UI_Panel;

        private void Start()
        {
            UpdateDisplay(Current.CurGame.timeSpeed);
        }

        private void OnEnable()
        {
            EventCenter.Instance.Register<GameTime>(EventName.YEAR_CHANGE, BindData);
            EventCenter.Instance.Register<GameTime>(EventName.QUAD_CHANGE, BindData);
            EventCenter.Instance.Register<GameTime>(EventName.DAY_CHANGE, BindData);
            EventCenter.Instance.Register<GameTime>(EventName.HOUR_CHANGE, BindData);
            EventCenter.Instance.Register<GameTime>(EventName.MINUTE_CHANGE, BindData);
            EventCenter.Instance.Register<GameTime>(EventName.SECOND_CHANGE, BindData);
            EventCenter.Instance.Register<GameTime>(EventName.GAME_TICK, BindData);
        }

        private void OnDisable()
        {
            EventCenter.Instance?.Unregister<GameTime>(EventName.YEAR_CHANGE, BindData);
            EventCenter.Instance?.Unregister<GameTime>(EventName.QUAD_CHANGE, BindData);
            EventCenter.Instance?.Unregister<GameTime>(EventName.DAY_CHANGE, BindData);
            EventCenter.Instance?.Unregister<GameTime>(EventName.HOUR_CHANGE, BindData);
            EventCenter.Instance?.Unregister<GameTime>(EventName.MINUTE_CHANGE, BindData);
            EventCenter.Instance?.Unregister<GameTime>(EventName.SECOND_CHANGE, BindData);
            EventCenter.Instance?.Unregister<GameTime>(EventName.GAME_TICK, BindData);
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

        public void AddSection()
        {
            CommandCenter.Instance.Enqueue(new ChangeMouseStateCommand(MouseState.AddSection));
        }

        public void BuildStove()
        {
            CommandCenter.Instance.Enqueue(new ChangeMouseStateCommand(MouseState.BuildingGhost));
            CommandCenter.Instance.Enqueue(new ChangeGhostBuildingCommand(ObjectCode.stove.GetHashCode()));
        }

        public void BuildSmithy()
        {
            CommandCenter.Instance.Enqueue(new ChangeMouseStateCommand(MouseState.BuildingGhost));
            CommandCenter.Instance.Enqueue(new ChangeGhostBuildingCommand(ObjectCode.smithy.GetHashCode()));
        }

        public void AddStorageSection()
        {
            CommandCenter.Instance.Enqueue(new ChangeMouseStateCommand(MouseState.AddStorageSection));
        }

        private void UpdateDisplay(int index)
        {
            foreach (var item in speedBg)
            {
                item.enabled = false;
            }
            speedBg[index].enabled = true;
        }

        public void OnClickPause()
        {
            CommandCenter.Instance.Enqueue(new ChangeGameSpeedCommand(0));
        }

        public void OnClickSpeed1()
        {
            CommandCenter.Instance.Enqueue(new ChangeGameSpeedCommand(1));
        }

        public void OnClickSpeed2()
        {
            CommandCenter.Instance.Enqueue(new ChangeGameSpeedCommand(2));
        }

        public void OnClickSpeed3()
        {
            CommandCenter.Instance.Enqueue(new ChangeGameSpeedCommand(3));
        }

        private void Update()
        {
            UpdateDisplay(Current.CurGame.timeSpeed);
        }
    }

}

