using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Building : WorldObject
    {
        public BuildingInfo buildingInfo;
        public BuildingStatus buildingStatus;
        public int curHitPoint;
        public HashSet<Vector2Int> buildingGrids;

        public Building(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            buildingInfo = ObjectConfig.GetInfo<BuildingInfo>(itemCode);
            buildingStatus = BuildingStatus.BluePrint;
            ItemName = buildingInfo.itemName;
            buildingGrids = new HashSet<Vector2Int>();
            for (int i = 0; i < buildingInfo.buildingLength; i++)
            {
                for (int j = 0; j < buildingInfo.buildingWidth; j++)
                {
                    buildingGrids.Add(new Vector2Int(gridPos.x + j, gridPos.y + i));
                }
            }

            SceneObjectManager.Instance.RegisterBuildingGrids(this);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            SceneObjectManager.Instance.UnregisterBuildingGrids(this);
        }


        public override Sprite GetSprite()
        {
            return buildingInfo.itemSprites[0];
        }
        public void Finish()
        {
            this.buildingStatus = BuildingStatus.Done;
        }
    }

    public enum BuildingStatus
    {
        Done,
        BluePrint,
    }

}
