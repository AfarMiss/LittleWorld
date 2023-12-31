﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LittleWorld.UI
{
    public class PausePanel : BaseUI
    {
        public override string Path => UIPath.Panel_PausePanel;
        [SerializeField] private List<SettingPanelBtn> pausePagesBtns;

        private void Start()
        {
            foreach (var btn in pausePagesBtns)
            {
                btn.PageBtn.onClick.AddListener(() =>
                {
                    SwitchTo(btn);
                });
            }

            SwitchTo(pausePagesBtns[0]);
        }

        private void SwitchTo(SettingPanelBtn btn)
        {
            foreach (var otherBtn in pausePagesBtns)
            {
                otherBtn.SwitchToInactive();
            }
            btn.SwitchToActive();
        }

        public override void OnClickClose()
        {
            UIManager.Instance.Hide<PausePanel>(UIType.PANEL);
        }

        public void OnClickQuit()
        {
            Application.Quit();
        }

        public void OnClickBackToMain()
        {
            BackToMain();
        }

        public void BackToMain()
        {
            Current.CurGame.Unload();
            SceneControllerManager.Instance.TryChangeScene(SceneEnum.Entry.ToString());
        }

        public void LoadDataFromFile()
        {
            SaveLoadManager.Instance.LoadDataFromFile();
        }

        public void SaveDataToFile()
        {
            SaveLoadManager.Instance.SaveDataToFile();
        }
    }

}
