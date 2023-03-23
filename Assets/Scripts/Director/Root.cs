using LittleWorld.Command;
using LittleWorld.Interface;
using LittleWorld.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld
{
    /// <summary>
    /// 总开关
    /// </summary>
    public class Root : MonoSingleton<Root>
    {
        private UIManager uIManager;
        private ObjectPoolManager poolManager;
        private TileManager tileManager;
        private CommandCenter commandCenter;
        private Game curGame;
        private EventCenter eventCenter;
        public GameState GameState
        {
            get
            {
                if (CurGame != null)
                {
                    return CurGame.state;
                }
                else
                {
                    return GameState.UNINIT;
                }
            }
            set
            {
                if (CurGame != null)
                {
                    CurGame.state = value;
                }
            }
        }

        public Game CurGame { get => curGame; set => curGame = value; }

        public List<IObserveSceneChange> ObserveSceneChanges;

        private void OnEnable()
        {
            EventCenter.Instance.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnSceneLoaded);
            EventCenter.Instance.Register(EventEnum.BEFORE_SCENE_UNLOAD.ToString(), OnSceneUnloaded);
        }

        private void OnSceneUnloaded()
        {
            foreach (var item in ObserveSceneChanges)
            {
                item.BeforeSceneUnload();
            }
        }

        private void OnSceneLoaded()
        {
            foreach (var item in ObserveSceneChanges)
            {
                item.AfterSceneLoad();
            }
        }

        private void OnDisable()
        {
            EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnSceneLoaded);
            EventCenter.Instance?.Unregister(EventEnum.BEFORE_SCENE_UNLOAD.ToString(), OnSceneUnloaded);

        }

        protected override void Awake()
        {
            base.Awake();

            ObserveSceneChanges = new List<IObserveSceneChange>();

            uIManager = UIManager.Instance;
            poolManager = ObjectPoolManager.Instance;
            tileManager = TileManager.Instance;
            commandCenter = CommandCenter.Instance;
            eventCenter = EventCenter.Instance;

            uIManager.Initialize();

            //读取配置文件
            Xml.XmlUtility.ReadAllConfigXmlIn(Application.streamingAssetsPath);
        }

        private void FixedUpdate()
        {
            CurGame?.Tick();
        }

        private void Update()
        {
            commandCenter?.Tick();
        }
    }
}

