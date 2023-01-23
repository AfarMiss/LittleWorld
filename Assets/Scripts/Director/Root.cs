using LittleWorld.Interface;
using MultipleTxture;
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
        private PoolManager poolManager;
        private TextureManager textureManager;
        private Game curGame;
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
            poolManager = PoolManager.Instance;
            textureManager = TextureManager.Instance;

            uIManager.Initialize();
        }

        private void Update()
        {
        }
    }
}

