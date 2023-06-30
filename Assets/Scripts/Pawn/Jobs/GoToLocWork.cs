using AI;
using LittleWorld.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LittleWorld.Jobs
{
    public class GoToLocWork : WorkBT, IToil
    {
        private bool _canStart;
        public bool isDone
        {
            get
            {
                return animal == null || (animal != null && animal.GridPos == des);
            }
        }
        private UnityAction onFinish;

        public string toilName => $"正在前往:{this.des}";

        public bool canStart => _canStart;

        private Animal animal;
        private Vector2Int des;
        private bool _isDone = false;

        public GoToLocWork(Animal humanbeing, Vector2Int destination, UnityAction OnToilEnd)
        {
            this._canStart = Current.CurMap.GetGrid(destination).isLand;
            MoveLeaf moveLeaf = new MoveLeaf("Go To Loc", destination, humanbeing);
            tree.AddChild(moveLeaf);
            this.animal = humanbeing;
            this.des = destination;
            this.onFinish = OnToilEnd;
        }

        public void Tick()
        {
        }

        public void OnStart()
        {
            animal.GoToLoc(des, MoveLeaf.MoveType.walk);
        }

        public void OnCancel()
        {

        }

        public void OnDone()
        {
            onFinish?.Invoke();
        }
    }

}
