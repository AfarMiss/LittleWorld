using AI;
using LittleWorld.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class GoToLocWork : WorkBT, IToil
    {
        private bool _canStart;
        public bool isDone
        {
            get
            {
                return _humanbeing == null || (_humanbeing != null && _humanbeing.GridPos == _des);
            }
        }

        public string toilName => $"正在前往:{this._des}";

        public bool canStart => _canStart;

        private Humanbeing _humanbeing;
        private Vector2Int _des;
        private bool _isDone = false;

        public GoToLocWork(Humanbeing humanbeing, Vector2Int destination)
        {
            this._canStart = Current.CurMap.GetGrid(destination).isLand;
            if (!Current.CurMap.GetGrid(destination).isLand)
            {
                return;
            }
            MoveLeaf moveLeaf = new MoveLeaf("Go To Loc", destination, humanbeing);
            tree.AddChild(moveLeaf);
            this._humanbeing = humanbeing;
            this._des = destination;
        }

        public void ToilTick()
        {
        }

        public void ToilStart()
        {
        }

        public void ToilCancel()
        {

        }

        public void ToilOnDone()
        {
        }
    }

}
