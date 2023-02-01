using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Xml
{
    public class XmlUtility
    {
        public static void ReadXml(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load($"{Application.streamingAssetsPath}/{path}.xml");
            Debug.Log("xml.InnerText:" + xml.InnerText);

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
                    plant.seedItem = int.Parse(item.SelectSingleNode("seedItem").InnerText);
                    plant.nutrition = float.Parse(item.SelectSingleNode("nutrition").InnerText);
                    plant.growingTime = int.Parse(item.SelectSingleNode("growingTime").InnerText);
                    PlantConfig.plantInfoDic.Add(plant.itemCode, plant);
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
                    PlantConfig.seedInfo.Add(seed.itemCode, seed);
                }

                if (item.SelectSingleNode("itemType").InnerText == "Crop")
                {
                    var food = new RawFoodInfo();
                    food.itemCode = int.Parse(item.SelectSingleNode("itemCode").InnerText);
                    food.itemName = item.SelectSingleNode("itemName").InnerText;
                    food.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
                    food.maxHealth = int.Parse(item.SelectSingleNode("maxHealth").InnerText);
                    food.nutrition = float.Parse(item.SelectSingleNode("nutrition").InnerText);
                    PlantConfig.rawFoodInfo.Add(food.itemCode, food);
                }
            }

            Debug.Log("plantInfoDic:" + PlantConfig.plantInfoDic);
        }
    }


}
