using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Plant : WorldObject
    {
        /// <summary>
        ///修剪工作量
        /// </summary>
        public int cutWorkAmount;
        public static int sowWorkAmount = 200;

        public int fruitCount = 5;
        public int woodCount;
        public int fruitItemCode = 10024;
        public float pickTime = 3;

        public Plant(string name, int itemCode, int cutWorkAmount, Vector2Int gridPos) : base(gridPos)
        {
            ItemName = name;
            this.itemCode = itemCode;
            this.cutWorkAmount = cutWorkAmount;
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

