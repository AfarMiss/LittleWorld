using LittleWorld.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

namespace Xml
{
    public class XmlUtility
    {
        /// <summary>
        /// itemType和itemCode一定要存在
        /// </summary>
        /// <param name="path"></param>
        public static void ReadConfigXml(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load($"{Application.streamingAssetsPath}/{path}.xml");

            XmlNode root = xml.SelectSingleNode("items");
            XmlNodeList itemsList = root.SelectNodes("item");
            foreach (XmlNode item in itemsList)
            {
                if (item.SelectSingleNode("itemType").InnerText == "Plant")
                {
                    var plant = new PlantInfo();
                    plant.itemCode = int.Parse(item.SelectSingleNode("itemCode").InnerText);
                    plant.itemName = item.SelectSingleNode("itemName").InnerText;
                    plant.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
                    plant.cutWorkAmount = int.Parse(item.SelectSingleNode("cutWorkAmount").InnerText);
                    plant.yieldCount = int.Parse(item.SelectSingleNode("yieldCount").InnerText);
                    plant.woodCount = int.Parse(item.SelectSingleNode("woodCount").InnerText);
                    plant.fruitItemCode = int.Parse(item.SelectSingleNode("fruitItemCode").InnerText);
                    plant.maxHealth = int.Parse(item.SelectSingleNode("maxHealth").InnerText);
                    int.TryParse(item.SelectSingleNode("seedItem").InnerText, out plant.seedItem);
                    plant.nutrition = float.Parse(item.SelectSingleNode("nutrition").InnerText);
                    plant.growingTime = float.Parse(item.SelectSingleNode("growingTime").InnerText);
                    plant.itemSprites = CreateItemSpritesList(item, 6);
                    ObjectConfig.ObjectInfoDic.Add(plant.itemCode, plant);
                    SetCommonProperty(item, ref plant);
                }

                if (item.SelectSingleNode("itemType").InnerText == "Seed")
                {
                    var seed = new SeedInfo();
                    seed.itemCode = int.Parse(item.SelectSingleNode("itemCode").InnerText);
                    seed.itemName = item.SelectSingleNode("itemName").InnerText;
                    seed.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
                    seed.sowWorkAmount = int.Parse(item.SelectSingleNode("sowWorkAmount").InnerText);
                    seed.maxHealth = int.Parse(item.SelectSingleNode("maxHealth").InnerText);
                    seed.plantItem = int.Parse(item.SelectSingleNode("plantItem").InnerText);
                    seed.nutrition = float.Parse(item.SelectSingleNode("nutrition").InnerText);
                    seed.itemSprites = CreateItemSpritesList(item, 6);
                    ObjectConfig.ObjectInfoDic.Add(seed.itemCode, seed);
                    SetCommonProperty(item, ref seed);
                }

                if (item.SelectSingleNode("itemType").InnerText == "Crop")
                {
                    var food = new RawFoodInfo();
                    food.itemCode = int.Parse(item.SelectSingleNode("itemCode").InnerText);
                    food.itemName = item.SelectSingleNode("itemName").InnerText;
                    food.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
                    food.maxHealth = int.Parse(item.SelectSingleNode("maxHealth").InnerText);
                    food.nutrition = float.Parse(item.SelectSingleNode("nutrition").InnerText);
                    food.itemSprites = CreateItemSpritesList(item, 6);
                    ObjectConfig.ObjectInfoDic.Add(food.itemCode, food);
                    SetCommonProperty(item, ref food);
                }


                if (item.SelectSingleNode("itemType").InnerText == "Animal")
                {
                    var animal = new AnimalInfo();
                    animal.itemCode = int.Parse(item.SelectSingleNode("itemCode").InnerText);
                    animal.itemName = item.SelectSingleNode("itemName").InnerText;
                    animal.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
                    animal.maxHealth = int.Parse(item.SelectSingleNode("maxHealth").InnerText);
                    animal.moveSpeed = float.Parse(item.SelectSingleNode("moveSpeed").InnerText);
                    animal.itemSprites = CreateItemSpritesList(item, 6);
                    ObjectConfig.ObjectInfoDic.Add(animal.itemCode, animal);
                    SetCommonProperty(item, ref animal);
                }

                if (item.SelectSingleNode("itemType").InnerText == "Thing")
                {
                    var thing = new ThingInfo();
                    thing.itemCode = int.Parse(item.SelectSingleNode("itemCode").InnerText);
                    thing.itemName = item.SelectSingleNode("itemName").InnerText;
                    thing.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
                    thing.itemSprites = CreateItemSpritesList(item, 3);
                    ObjectConfig.ObjectInfoDic.Add(thing.itemCode, thing);
                    SetCommonProperty(item, ref thing);
                }
                if (item.SelectSingleNode("itemType").InnerText == "Building")
                {
                    var thing = new BuildingInfo();
                    thing.itemCode = int.Parse(item.SelectSingleNode("itemCode").InnerText);
                    thing.itemName = item.SelectSingleNode("itemName").InnerText;
                    thing.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
                    thing.buildingWorkAmount = int.Parse(item.SelectSingleNode("buildingWorkAmount").InnerText);
                    thing.marketValue = float.Parse(item.SelectSingleNode("marketValue").InnerText);
                    thing.maxHitPoint = int.Parse(item.SelectSingleNode("maxHitPoint").InnerText);
                    thing.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
                    thing.buildingCost = GetBuildingCost(item);
                    thing.itemSprites = CreateItemSpritesList(item, 1);
                    ObjectConfig.ObjectInfoDic.Add(thing.itemCode, thing);
                    SetCommonProperty(item, ref thing);
                }
                if (item.SelectSingleNode("itemType").InnerText == "Ore")
                {
                    var ore = new OreInfo();
                    ore.itemCode = int.Parse(item.SelectSingleNode("itemCode").InnerText);
                    ore.itemName = item.SelectSingleNode("itemName").InnerText;
                    ore.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
                    ore.maxHitPoint = int.Parse(item.SelectSingleNode("maxHitPoint").InnerText);
                    ore.marketValue = float.Parse(item.SelectSingleNode("marketValue").InnerText);
                    ore.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
                    ore.productionCode = int.Parse(item.SelectSingleNode("productionCode").InnerText);
                    ore.productionAmount = int.Parse(item.SelectSingleNode("productionAmount").InnerText);
                    ore.MiningWorkAmount = int.Parse(item.SelectSingleNode("miningWorkAmount").InnerText);
                    ore.itemSprites = CreateItemSpritesList(item, 1);
                    ObjectConfig.ObjectInfoDic.Add(ore.itemCode, ore);
                    SetCommonProperty(item, ref ore);
                }
            }
        }

        private static void SetCommonProperty<T>(XmlNode item, ref T info) where T : BaseInfo
        {
            if (item == null || item.SelectSingleNode("maxPileCount") == null
                || string.IsNullOrEmpty(item.SelectSingleNode("maxPileCount").InnerText))
            {
                return;
            }
            info.canPile = int.TryParse(item.SelectSingleNode("maxPileCount").InnerText, out info.maxPileCount);
            if (!bool.TryParse(item.SelectSingleNode("maxPileCount").InnerText, out info.isBlock))
            {
                info.isBlock = false;
            }
        }

        private static List<Sprite> CreateItemSpritesList(XmlNode item, int spritesCount)
        {
            var sprites = new List<Sprite>();
            for (int i = 0; i < spritesCount; i++)
            {
                if (!string.IsNullOrEmpty(item.SelectSingleNode($"image{i}")?.InnerText))
                {
                    var loadPath = item.SelectSingleNode($"image{i}").InnerText;
                    if (string.IsNullOrEmpty(loadPath))
                    {
                        continue;
                    }
                    var prefix = "Assets/Resources/";
                    if (loadPath.StartsWith(prefix))
                    {
                        loadPath = loadPath.Substring(prefix.Length);
                    }
                    string selectionExt = System.IO.Path.GetExtension(loadPath);
                    if (selectionExt.Length != 0)
                    {
                        loadPath = loadPath.Remove(loadPath.Length - selectionExt.Length);
                    }
                    var curSprite = Resources.Load<Sprite>(loadPath);
                    if (curSprite != null)
                    {
                        sprites.Add(curSprite);
                    }
                    else
                    {
                        Debug.LogError($"{loadPath} is null of sprite");
                    }
                }
            }
            return sprites;
        }
        private static List<BuildingCost> GetBuildingCost(XmlNode item)
        {
            var buildingCost = new List<BuildingCost>();
            var innerText = item.SelectSingleNode($"buildingCost")?.InnerText;
            if (!string.IsNullOrEmpty(innerText))
            {
                string[] buildingMaterialsText = innerText.Split(",");
                foreach (var text in buildingMaterialsText)
                {
                    string[] materialInfo = text.Split("x");
                    string materialName = materialInfo[0];
                    string materialCount = materialInfo[1];
                    buildingCost.Add(new BuildingCost(
                        ObjectConfig.GetRawMaterialCode(materialName),
                        int.Parse(materialCount)));
                }
            }
            return buildingCost;
        }
    }


}
