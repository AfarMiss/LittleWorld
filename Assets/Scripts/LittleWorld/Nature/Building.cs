using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Building : WorldObject, ISleepable
    {
        public BuildingInfo buildingInfo;
        public BuildingStatus buildingStatus;
        public int curHitPoint;
        public int curBuildingPoint;
        public int maxBuildingPoint = 5;
        public HashSet<Vector2Int> buildingGrids;
        public Dictionary<int, int> curBuildingContain;
        public bool canStartBuild => GetRawMaterialNeedYet()?.Count == 0;

        public bool finishBuilding => buildingStatus == BuildingStatus.BluePrint && curBuildingPoint == maxBuildingPoint;

        public bool isSleepable => this.buildingInfo.canSleep && buildingStatus == BuildingStatus.Done;

        public string itemName => ItemName;

        public void AddBuildingRawMaterials(WorldObject[] rawMaterials)
        {
            for (int i = 0; i < rawMaterials.Length; i++)
            {
                rawMaterials[i].OnBeBluePrint();
                if (LackRawMaterial(rawMaterials[i].itemCode))
                {
                    if (curBuildingContain.ContainsKey(rawMaterials[i].itemCode))
                    {
                        curBuildingContain[rawMaterials[i].itemCode]++;
                    }
                    else
                    {
                        curBuildingContain.Add(rawMaterials[i].itemCode, 1);
                    }
                }
            }
        }

        public bool LackRawMaterial(int itemCode)
        {
            return GetRawMaterialNeedYet().ContainsKey(itemCode);
        }

        public bool RemoveBuildingRawMaterials()
        {
            return true;
        }

        public Building(int itemCode, Vector2Int gridPos, BuildingStatus buildingStatus = BuildingStatus.BluePrint, Map map = null) : base(itemCode, gridPos, map)
        {
            buildingInfo = ObjectConfig.GetInfo<BuildingInfo>(itemCode);
            this.buildingStatus = buildingStatus;
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
            curBuildingContain = new Dictionary<int, int>();
        }

        public bool hasRawMaterialNeeded()
        {
            Vector2Int curpos;
            foreach (var item in GetRawMaterialNeedYet())
            {

                if (SceneObjectManager.Instance.SearchForRawMaterials(item.Key, out curpos))
                {
                    return true;
                }
                continue;
            }
            return false;
        }

        public Dictionary<int, int> GetRawMaterialNeedYet()
        {
            var all = buildingInfo.BuildingCost;
            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach (var item in all)
            {
                if (curBuildingContain.ContainsKey(item.Key))
                {
                    if (item.Value - curBuildingContain[item.Key] <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        result.Add(item.Key, item.Value - curBuildingContain[item.Key]);
                    }
                }
                else
                {
                    result.Add(item.Key, item.Value);
                }
            }
            return result;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            SceneObjectManager.Instance.UnregisterBuildingGrids(this);
        }


        public override Sprite GetCurrentSprite()
        {
            return buildingInfo.ItemSprites[0];
        }
        public void Finish()
        {
            this.buildingStatus = BuildingStatus.Done;
            this.mapBelongTo.GetGrid(gridPos, out var grid);
            grid.ClearBuildingMaterials();
            var objects = WorldUtility.GetWorldObjectsAt(gridPos);
            var buildingMaterials = objects.ToList().FindAll(x => x is WorldObject wo && wo.inBuildingConstruction);
            for (int i = buildingMaterials.Count - 1; i >= 0; i--)
            {
                (buildingMaterials[i] as WorldObject).Destroy();
            }
        }
    }

    public enum BuildingStatus
    {
        Done,
        BluePrint,
    }

    public enum BuildingLayer
    {
        /// <summary>
        /// 地板
        /// </summary>
        Floor = 0,
        /// <summary>
        /// 普通，会形成阻挡
        /// </summary>
        Normal_Block = 1,
    }

}
