using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Plant : WorldObject
    {
        private PlantInfo plantInfo;
        public int PlantYieldCount => plantInfo.yieldCount;
        public int FruitCode => plantInfo.fruitItemCode;
        private float curGrowTime = 0;
        public bool IsRipe => curGrowTime >= plantInfo.growingTime * 0.95f;
        public PlantInfo PlantInfo => plantInfo;

        public Plant(int itemCode, Vector2Int gridPos, float curGrowthTime = 0) : base(itemCode, gridPos)
        {
            if (ObjectConfig.plantInfoDic.TryGetValue(itemCode, out plantInfo))
            {
                plantInfo = ObjectConfig.plantInfoDic[itemCode];
                this.itemCode = itemCode;
                ItemName = plantInfo.itemName;
                this.curGrowTime = curGrowthTime;
            }
        }

        public override List<FloatOption> AddFloatMenu()
        {
            List<FloatOption> contentList = new List<FloatOption>();
            //contentList.Add(new FloatOption()
            //{
            //    content = "砍树",
            //    OnClickOption = () =>
            //    {
            //        Debug.Log("正在砍树！");
            //    }
            //});
            //contentList.Add(new FloatOption()
            //{
            //    content = "摘取果实",
            //    OnClickOption = () =>
            //    {
            //        Debug.Log("摘取果实！");
            //    }
            //});

            return contentList;
        }

        public override Sprite GetSprite()
        {
            if (plantInfo.itemSprites == null || plantInfo.itemSprites.Count == 0)
            {
                Debug.LogWarning("plant sprite is null");
            }
            var spriteIndex = (int)(curGrowTime / plantInfo.growingTime * plantInfo.itemSprites.Count);
            spriteIndex = Mathf.Clamp(spriteIndex, 0, plantInfo.itemSprites.Count - 1);
            return plantInfo.itemSprites[spriteIndex];
        }

        public override void Tick()
        {
            base.Tick();
            curGrowTime += 1 / 86400.0f;
        }
    }
}

