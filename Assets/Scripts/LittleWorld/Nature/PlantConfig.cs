using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class PlantConfig
    {
        public static Dictionary<int, PlantInfo> plantInfoDic = new Dictionary<int, PlantInfo>();
        public static Dictionary<int, SeedInfo> seedInfo = new Dictionary<int, SeedInfo>();
        public static Dictionary<int, RawFoodInfo> rawFoodInfo = new Dictionary<int, RawFoodInfo>();
    }
}
