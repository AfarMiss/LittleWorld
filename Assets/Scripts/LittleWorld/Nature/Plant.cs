using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Plant : Living
    {
        private PlantInfo plantInfo;
        public int PlantYieldCount => plantInfo.yieldCount;
        public int FruitCode => plantInfo.fruitItemCode;
        public int WoodCount => plantInfo.woodCount;
        private float curGrowTime = 0;
        public bool IsRipe => curGrowTime >= plantInfo.growingTime * 0.95f;
        public PlantInfo PlantInfo => plantInfo;

        public Plant(int itemCode, Vector2Int gridPos, float curGrowthTime = 0) : base(itemCode, gridPos)
        {
            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var plantInfo))
            {
                this.plantInfo = plantInfo as PlantInfo;
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
            if (plantInfo.ItemSprites == null || plantInfo.ItemSprites.Length == 0)
            {
                Debug.LogWarning("plant sprite is null");
            }
            var spriteIndex = (int)(curGrowTime / plantInfo.growingTime * plantInfo.ItemSprites.Length);
            spriteIndex = Mathf.Clamp(spriteIndex, 0, plantInfo.ItemSprites.Length - 1);
            return plantInfo.ItemSprites[spriteIndex];
        }

        public override void Tick()
        {
            base.Tick();
            curGrowTime += 1 / 86400.0f;
        }
    }
}

