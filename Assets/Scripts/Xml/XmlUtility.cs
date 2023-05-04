using ExcelDataReader;
using LittleWorld.Item;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEditor.VersionControl;
using UnityEditor;
using UnityEngine;
using System.Security.Cryptography;
using DG.Tweening.Plugins.Core.PathCore;

namespace Xml
{
    public class XmlUtility
    {
        public static void ReadAllConfigXmlIn(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*", SearchOption.TopDirectoryOnly);
            DirectoryInfo[] folders = directory.GetDirectories("*", SearchOption.TopDirectoryOnly);
            foreach (var item in files)
            {
                if (item.Name.EndsWith(".xml"))
                {
                    ReadConfigXml(TrimXmlName(item.Name));
                }
            }
        }

        public static string TrimXmlName(string fullPath)
        {
            return fullPath.Substring(fullPath.LastIndexOf("\\") + 1, (fullPath.LastIndexOf(".") - fullPath.LastIndexOf("\\") - 1));
        }
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
                var typeName = item.SelectSingleNode("itemType").InnerText;
                Type nodeType = Type.GetType(typeName);
                object instance = Activator.CreateInstance(nodeType);

                var fieldDic = new Dictionary<string, FieldInfo>();
                var fields = nodeType.GetFields();
                foreach (FieldInfo field in fields)
                {
                    fieldDic.Add(field.Name, field);
                }

                foreach (XmlNode attribute in item.ChildNodes)
                {
                    if (fieldDic.TryGetValue(attribute.Name, out var curFieldInfo))
                    {
                        Type convertType = curFieldInfo.FieldType;
                        MethodInfo mi = typeof(Convert).GetMethod("To" + convertType, new[] { typeof(string) });
                        object value = mi.Invoke(null, new object[] { attribute.InnerText });
                        curFieldInfo.SetValue(instance, value);
                    }
                }
            }
            //foreach (XmlNode item in itemsList)
            //{
            //    if (item.SelectSingleNode("itemType").InnerText == "Plant")
            //    {
            //        var plant = new PlantInfo();
            //        SetCommonProperty(item, ref plant);
            //        plant.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
            //        plant.cutWorkAmount = int.Parse(item.SelectSingleNode("cutWorkAmount").InnerText);
            //        plant.yieldCount = int.Parse(item.SelectSingleNode("yieldCount").InnerText);
            //        plant.woodCount = int.Parse(item.SelectSingleNode("woodCount").InnerText);
            //        plant.fruitItemCode = int.Parse(item.SelectSingleNode("fruitItemCode").InnerText);
            //        plant.maxHealth = int.Parse(item.SelectSingleNode("maxHealth").InnerText);
            //        int.TryParse(item.SelectSingleNode("seedItem").InnerText, out plant.seedItem);
            //        plant.nutrition = float.Parse(item.SelectSingleNode("nutrition").InnerText);
            //        plant.growingTime = float.Parse(item.SelectSingleNode("growingTime").InnerText);
            //        plant.itemSprites = CreateItemSpritesList(item, 6);
            //        ObjectConfig.ObjectInfoDic.Add(plant.itemCode, plant);
            //    }

            //    if (item.SelectSingleNode("itemType").InnerText == "Seed")
            //    {
            //        var seed = new SeedInfo();
            //        SetCommonProperty(item, ref seed);
            //        seed.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
            //        seed.sowWorkAmount = int.Parse(item.SelectSingleNode("sowWorkAmount").InnerText);
            //        seed.maxHealth = int.Parse(item.SelectSingleNode("maxHealth").InnerText);
            //        seed.plantItem = int.Parse(item.SelectSingleNode("plantItem").InnerText);
            //        seed.nutrition = float.Parse(item.SelectSingleNode("nutrition").InnerText);
            //        seed.itemSprites = CreateItemSpritesList(item, 6);
            //        ObjectConfig.ObjectInfoDic.Add(seed.itemCode, seed);
            //    }

            //    if (item.SelectSingleNode("itemType").InnerText == "Crop")
            //    {
            //        var food = new RawFoodInfo();
            //        SetCommonProperty(item, ref food);
            //        food.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
            //        food.maxHealth = int.Parse(item.SelectSingleNode("maxHealth").InnerText);
            //        food.nutrition = float.Parse(item.SelectSingleNode("nutrition").InnerText);
            //        food.itemSprites = CreateItemSpritesList(item, 6);
            //        ObjectConfig.ObjectInfoDic.Add(food.itemCode, food);
            //    }


            //    if (item.SelectSingleNode("itemType").InnerText == "Animal")
            //    {
            //        var animal = new AnimalInfo();
            //        SetCommonProperty(item, ref animal);
            //        animal.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
            //        animal.maxHealth = int.Parse(item.SelectSingleNode("maxHealth").InnerText);
            //        animal.moveSpeed = float.Parse(item.SelectSingleNode("moveSpeed").InnerText);
            //        animal.itemSprites = CreateItemSpritesList(item, 6);
            //        ObjectConfig.ObjectInfoDic.Add(animal.itemCode, animal);
            //    }

            //    if (item.SelectSingleNode("itemType").InnerText == "Thing")
            //    {
            //        var thing = new ThingInfo();
            //        SetCommonProperty(item, ref thing);
            //        thing.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
            //        thing.itemSprites = CreateItemSpritesList(item, 3);
            //        ObjectConfig.ObjectInfoDic.Add(thing.itemCode, thing);
            //    }
            //    if (item.SelectSingleNode("itemType").InnerText == "Building")
            //    {
            //        var thing = new BuildingInfo();
            //        SetCommonProperty(item, ref thing);
            //        thing.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
            //        thing.buildingWorkAmount = int.Parse(item.SelectSingleNode("buildingWorkAmount").InnerText);
            //        thing.marketValue = float.Parse(item.SelectSingleNode("marketValue").InnerText);
            //        thing.maxHitPoint = int.Parse(item.SelectSingleNode("maxHitPoint").InnerText);
            //        thing.buildingCost = item.SelectSingleNode("buildingCost").InnerText;
            //        thing.itemSprites = CreateItemSpritesList(item, 1);
            //        thing.buildingLength = int.Parse(item.SelectSingleNode("buildingLength").InnerText);
            //        thing.buildingWidth = int.Parse(item.SelectSingleNode("buildingWidth").InnerText);
            //        thing.layer = int.Parse(item.SelectSingleNode("layer").InnerText);
            //        thing.buildingWorkAmount = int.Parse(item.SelectSingleNode("buildingWorkAmount").InnerText);
            //        ObjectConfig.ObjectInfoDic.Add(thing.itemCode, thing);
            //    }
            //    if (item.SelectSingleNode("itemType").InnerText == "Ore")
            //    {
            //        var ore = new OreInfo();
            //        SetCommonProperty(item, ref ore);
            //        ore.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
            //        ore.maxHitPoint = int.Parse(item.SelectSingleNode("maxHitPoint").InnerText);
            //        ore.marketValue = float.Parse(item.SelectSingleNode("marketValue").InnerText);
            //        ore.productionCode = int.Parse(item.SelectSingleNode("productionCode").InnerText);
            //        ore.productionAmount = int.Parse(item.SelectSingleNode("productionAmount").InnerText);
            //        ore.MiningWorkAmount = int.Parse(item.SelectSingleNode("miningWorkAmount").InnerText);
            //        ore.itemSprites = CreateItemSpritesList(item, 1);
            //        ObjectConfig.ObjectInfoDic.Add(ore.itemCode, ore);
            //    }
            //    if (item.SelectSingleNode("itemType").InnerText == "Weapon")
            //    {
            //        var weapon = new WeaponInfo();
            //        SetCommonProperty(item, ref weapon);
            //        weapon.mass = float.Parse(item.SelectSingleNode("mass").InnerText);
            //        weapon.maxHitPoint = int.Parse(item.SelectSingleNode("maxHitPoint").InnerText);
            //        weapon.marketValue = float.Parse(item.SelectSingleNode("marketValue").InnerText);
            //        weapon.createAt = int.Parse(item.SelectSingleNode("createAt").InnerText);
            //        weapon.workToMake = int.Parse(item.SelectSingleNode("workToMake").InnerText);
            //        weapon.burstShotCount = int.Parse(item.SelectSingleNode("burstShotCount").InnerText);
            //        weapon.caliber = item.SelectSingleNode("caliber").InnerText;
            //        weapon.fireRate = float.Parse(item.SelectSingleNode("fireRate").InnerText);
            //        weapon.magazineCapacity = int.Parse(item.SelectSingleNode("magazineCapacity").InnerText);
            //        weapon.reloadTime = float.Parse(item.SelectSingleNode("reloadTime").InnerText);
            //        weapon.spread = float.Parse(item.SelectSingleNode("spread").InnerText);
            //        weapon.weaponSway = float.Parse(item.SelectSingleNode("weaponSway").InnerText);
            //        weapon.meleeDamage = float.Parse(item.SelectSingleNode("meleeDamage").InnerText);
            //        weapon.range = float.Parse(item.SelectSingleNode("range").InnerText);
            //        weapon.rangedCooldown = float.Parse(item.SelectSingleNode("rangedCooldown").InnerText);
            //        weapon.aimingTime = float.Parse(item.SelectSingleNode("aimingTime").InnerText);
            //        weapon.buildingDamageFactor = float.Parse(item.SelectSingleNode("buildingDamageFactor").InnerText);
            //        weapon.itemSprites = CreateItemSpritesList(item, 1);
            //        weapon.isMelee = item.SelectSingleNode("isMelee").InnerText == "True";
            //        ObjectConfig.ObjectInfoDic.Add(weapon.itemCode, weapon);
            //    }
            //}
        }

        private static void SetCommonProperty<T>(XmlNode item, ref T info) where T : BaseInfo
        {
            if (item == null)
            {
                return;
            }
            if (item.SelectSingleNode("maxPileCount") == null
                || string.IsNullOrEmpty(item.SelectSingleNode("maxPileCount").InnerText))
            {
                info.maxPileCount = 0;
            }
            if (item.SelectSingleNode("isBlock") == null)
            {
                info.isBlock = false;
            }
            else
            {
                if (!bool.TryParse(item.SelectSingleNode("isBlock").InnerText, out info.isBlock))
                {
                    info.isBlock = false;
                }
            }

            info.itemCode = int.Parse(item.SelectSingleNode("itemCode").InnerText);
            info.itemName = item.SelectSingleNode("itemName").InnerText;
        }

        public static Dictionary<int, int> GetBuildingCost(string item)
        {
            var buildingCost = new Dictionary<int, int>();
            var innerText = item;
            if (!string.IsNullOrEmpty(innerText))
            {
                string[] buildingMaterialsText = innerText.Split(",");
                foreach (var text in buildingMaterialsText)
                {
                    string[] materialInfo = text.Split("x");
                    string materialName = materialInfo[0];
                    string materialCount = materialInfo[1];
                    buildingCost.Add(
                        ObjectConfig.GetRawMaterialCode(materialName),
                        int.Parse(materialCount));
                }
            }
            return buildingCost;
        }

        public static void ExcelPathToXml(string excelRootPath, string xmlRootPath)
        {
            string[] files = Directory.GetFiles(excelRootPath, "*.xlsx", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                Debug.Log($"准备更新:{file}");
                SingleExcelToXml(file, xmlRootPath);
            }
        }

        /// <summary>
        /// 表格第一行对应xml元素名称，第二行对应xml元素类型，根节点是items，列表中每一个元素是item
        /// </summary>
        /// <param name="excelPath"></param>
        /// <param name="xmlRootPath">存放生成xml文件的根目录，具体文件名根据excelPath中的名称确定</param>
        public static void SingleExcelToXml(string excelPath, string xmlRootPath)
        {
            //string fileMD5 = null;
            //MD5CryptoServiceProvider md5Calc = null;
            //try
            //{
            //    using (FileStream fs = File.OpenRead(xmlPath))
            //    {
            //        fileMD5 = System.BitConverter.ToString(md5Calc.ComputeHash(fs));
            //    }
            //}
            //catch (System.Exception e) { Debug.LogException(e); }
            //if (File.Exists(xmlPath))
            //{
            //    md5Calc = new MD5CryptoServiceProvider();
            //    StringBuilder content = new StringBuilder();
            //    content.AppendLine("TEST!");
            //    byte[] bytes = Encoding.UTF8.GetBytes(content.ToString());
            //    bool toWrite = true;
            //    if (!string.IsNullOrEmpty(fileMD5))
            //    {
            //        if (System.BitConverter.ToString(md5Calc.ComputeHash(bytes)) == fileMD5)
            //        {
            //            toWrite = false;
            //        }
            //    }
            //    EditorUtility.ClearProgressBar();
            //    if (toWrite) { File.WriteAllBytes(xmlPath, bytes); }
            //}

            var xmlLength = excelPath.LastIndexOf(".") - excelPath.LastIndexOf("\\") - 1;
            var xmlFileName = excelPath.Substring(excelPath.LastIndexOf("\\") + 1, xmlLength);
            var xmlFileFullPath = $"{xmlRootPath}\\{xmlFileName}.xml";
            List<List<string>> xmlContentArray = new List<List<string>>();
            if (!File.Exists(xmlFileFullPath))
            {
                File.Create(xmlFileFullPath);
                Debug.LogWarning($"不存在文件:{xmlFileFullPath},已自动生成！");
            }
            using (var stream = File.Open(excelPath, System.IO.FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet result = reader.AsDataSet();

                DataTable table = result.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    var curList = new List<string>();
                    xmlContentArray.Add(curList);
                    foreach (DataColumn col in table.Columns)
                    {
                        object cellValue = row[col];
                        curList.Add(cellValue.ToString());
                    }
                }

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(xmlFileFullPath, settings))
                {
                    // Write the root element
                    writer.WriteStartElement("items");

                    // Write some child elements
                    //writer.WriteStartElement("item");
                    //writer.WriteAttributeString("name", "child1");
                    //writer.WriteString("some text");
                    //writer.WriteEndElement();
                    var elementNames = xmlContentArray[0];
                    var elementTypes = xmlContentArray[1];
                    xmlContentArray.RemoveAt(1);
                    xmlContentArray.RemoveAt(0);

                    for (int i = 0; i < xmlContentArray.Count; i++)
                    {
                        List<string> item = xmlContentArray[i];
                        writer.WriteStartElement("item");
                        for (int j = 0; j < item.Count; j++)
                        {
                            string element = item[j];
                            writer.WriteStartElement(elementNames[j]);
                            writer.WriteAttributeString("type", elementTypes[j]);
                            writer.WriteString(element.ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    // Close the root element
                    writer.WriteEndElement();
                }
                Debug.Log($"已生成，位置:{xmlFileFullPath}");
            }
        }
    }
}
