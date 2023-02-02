using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
                    plant.growingTime = float.Parse(item.SelectSingleNode("growingTime").InnerText);
                    plant.itemSprites = CreateItemSpritesList(item, 6);
                    ObjectConfig.plantInfoDic.Add(plant.itemCode, plant);
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
                    ObjectConfig.seedInfo.Add(seed.itemCode, seed);
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
                    ObjectConfig.rawFoodInfo.Add(food.itemCode, food);
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
                    ObjectConfig.animalInfo.Add(animal.itemCode, animal);
                }
            }

            Debug.Log("plantInfoDic:" + ObjectConfig.plantInfoDic);
        }

        private static List<Sprite> CreateItemSpritesList(XmlNode item, int spritesCount)
        {
            var sprites = new List<Sprite>();
            for (int i = 0; i < spritesCount; i++)
            {
                if (!string.IsNullOrEmpty(item.SelectSingleNode($"image{i}")?.InnerText))
                {
                    var curSprite = Resources.Load<Sprite>(item.SelectSingleNode($"image{i}").InnerText);
                    sprites.Add(curSprite);
                }
            }
            return sprites;
        }
    }


}
