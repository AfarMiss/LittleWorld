using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Item
{
    public class ObjectConfig
    {
        public static Dictionary<int, BaseInfo> ObjectInfoDic = new Dictionary<int, BaseInfo>();

        public static int GetPlantCode(int seedCode)
        {
            if (ObjectInfoDic.TryGetValue(seedCode, out var seed))
            {
                if (seed as SeedInfo != null)
                {
                    return (seed as SeedInfo).plantItem;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                Debug.LogError("No seed has been checked.");
                return 0;
            }

        }

        public static int GetRawMaterialCode(string materialName)
        {
            var result = ObjectInfoDic.Values.ToList().Find(x => x.itemName == materialName);
            if (result != null)
            {
                return result.itemCode;
            }
            else
            {
                Debug.LogError($"No raw material for {materialName}");
                return default;
            }
        }

        public static string GetPlantName(int seedCode)
        {
            var plant = ObjectInfoDic.Values.ToList().Find(x => x is PlantInfo curPlant && curPlant.seedItem == seedCode);
            if (plant != null)
            {
                return plant.itemName;
            }
            else
            {
                return null;
            }
        }

        public static string GetOreName(int seedCode)
        {
            var ore = ObjectInfoDic.Values.ToList().Find(x => x.itemCode == seedCode);
            if (ore != null)
            {
                return ore.itemName;
            }
            else
            {
                return null;
            }
        }

        public static Sprite GetPlantSprite(int seedCode)
        {
            var plant = ObjectInfoDic.Values.ToList().Find(x => x is PlantInfo curPlant && curPlant.seedItem == seedCode);
            if (plant != null)
            {
                return (ObjectInfoDic[(plant as PlantInfo).fruitItemCode] as RawFoodInfo).ItemSprites[0];
            }
            else
            {
                return null;
            }
        }

        public static Sprite GetBuildingSprite(int buildingCode)
        {
            var buildingInfo = ObjectConfig.ObjectInfoDic.Values.ToList().Find(x => x.itemCode == buildingCode);
            if (buildingInfo != null && buildingInfo is BuildingInfo building)
            {
                return building.ItemSprites[0];
            }
            else
            {
                return null;
            }
        }

        public static T GetInfo<T>(int itemCode) where T : BaseInfo
        {
            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var info))
            {
                return info as T;
            }
            else
            {
                return null;
            }
        }

        public static BaseInfo GetInfo(int itemCode)
        {
            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var info))
            {
                return info;
            }
            else
            {
                return null;
            }
        }
    }
}
