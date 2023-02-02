using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Plant : WorldObject
    {
        private PlantInfo plantInfo;
        private float curGrowTime = 0;
        private bool IsRipe => curGrowTime >= plantInfo.growingTime * 0.95f;
        public PlantInfo PlantInfo => plantInfo;

        public Plant(int itemCode, Vector2Int gridPos) : base(gridPos)
        {
            if (ObjectConfig.plantInfoDic.TryGetValue(itemCode, out plantInfo))
            {
                plantInfo = ObjectConfig.plantInfoDic[itemCode];
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
            curGrowTime += Time.deltaTime;
        }
    }
}

