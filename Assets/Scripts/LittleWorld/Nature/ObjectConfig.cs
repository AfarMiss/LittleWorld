using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Item
{
    public class ObjectConfig
    {
        public static Dictionary<int, PlantInfo> plantInfoDic = new Dictionary<int, PlantInfo>();
        public static Dictionary<int, SeedInfo> seedInfo = new Dictionary<int, SeedInfo>();
        public static Dictionary<int, RawFoodInfo> rawFoodInfo = new Dictionary<int, RawFoodInfo>();
        public static Dictionary<int, AnimalInfo> animalInfo = new Dictionary<int, AnimalInfo>();

        public static int GetPlantCode(int seedCode)
        {
            if (seedInfo.TryGetValue(seedCode, out var seed))
            {
                return seed.plantItem;
            }
            else
            {
                Debug.LogError("No seed has been checked.");
                return 0;
            }

        }

        public static string GetPlantName(int seedCode)
        {
            var plant = plantInfoDic.Values.ToList().Find(x => x.seedItem == seedCode);
            if (plant != null)
            {
                return plant.itemName;
            }
            else
            {
                return null;
            }
        }
    }
}
