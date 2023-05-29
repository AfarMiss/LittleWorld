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
        public bool isDone => _isDone;

        public string toilName => $"正在前往:{this._des}";

        private Humanbeing _humanbeing;
        private Vector2Int _des;
        private bool _isDone = false;

        public GoToLocWork(Humanbeing humanbeing, Vector2Int destination)
        {
            if (!Current.CurMap.GetGrid(destination).isLand)
            {
                return;
            }
            MoveLeaf moveLeaf = new MoveLeaf("Go To Loc", destination, humanbeing);
            tree.AddChild(moveLeaf);
            this._humanbeing = humanbeing;
            this._des = destination;
        }

        public bool ToilTick()
        {
            return (_humanbeing.GridPos == _des);
        }

        public void ToilStart()
        {
        }

        public void ToilCancel()
        {

        }
    }

}
