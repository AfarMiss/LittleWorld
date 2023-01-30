using System;
using System.Collections;
using System.Collections.Generic;
using UniBase;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Brush : Plant
    {
        public int fruitCount = 5;
        public int woodCount;
        public int fruitItemCode = 10024;
        public float pickTime = 3;

        public Brush(Vector2Int gridPos) : base(gridPos)
        {
            ItemName = "灌木丛";
            this.gridPos = gridPos;
        }

        public override List<FloatOption> AddFloatMenu()
        {
            List<FloatOption> contentList = new List<FloatOption>();
            contentList.Add(new FloatOption()
            {
                content = "砍树",
                OnClickOption = () =>
                {
                    Debug.Log("正在砍树！");
                }
            });
            contentList.Add(new FloatOption()
            {
                content = "摘取果实",
                OnClickOption = () =>
                {
                    Debug.Log("摘取果实！");
                }
            });

            return contentList;
        }

    }
}
