using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Plant : WorldObject
    {
        private PlantInfo plantInfo;
        public PlantInfo PlantInfo => plantInfo;

        public Plant(int itemCode, Vector2Int gridPos) : base(gridPos)
        {
            if (PlantConfig.plantInfoDic.TryGetValue(itemCode, out plantInfo))
            {
                plantInfo = PlantConfig.plantInfoDic[itemCode];
                this.itemCode = itemCode;
                ItemName = plantInfo.itemName;
            }
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

