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
using static UnityEditor.Progress;

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
            Debug.Log($"开始读取xml数据,位置:{path}");
            XmlDocument xml = new XmlDocument();
            xml.Load($"{Application.streamingAssetsPath}/{path}.xml");

            XmlNode root = xml.SelectSingleNode("items");
            XmlNodeList itemsList = root.SelectNodes("item");
            foreach (XmlNode item in itemsList)
            {
                var typeName = item.SelectSingleNode("itemType").InnerText;
                var itemName = item.SelectSingleNode("itemName").InnerText;
                if (string.IsNullOrEmpty(typeName))
                {
                    Debug.LogError($"类型名称为空:{typeName}");
                }
                Type nodeType = Type.GetType($"LittleWorld.Item.{typeName}Info");

                try
                {
                    object instance = Activator.CreateInstance(nodeType);
                    var fieldDic = new Dictionary<string, FieldInfo>();
                    var fields = nodeType.GetFields();
                    foreach (FieldInfo field in fields)
                    {
                        if (!fieldDic.TryAdd(field.Name, field))
                        {
                            Debug.LogError($"fieldName:{nodeType}.{field.Name}已存在！请检查");
                        }

                    }

                    foreach (XmlNode attribute in item.ChildNodes)
                    {
                        if (string.IsNullOrEmpty(attribute.InnerText))
                        {
                            continue;
                        }
                        try
                        {
                            if (fieldDic.TryGetValue(attribute.Name, out var curFieldInfo))
                            {
                                MethodInfo mi = typeof(Convert).GetMethod("To" + curFieldInfo.FieldType.Name, new[] { typeof(string) });
                                object value = mi.Invoke(null, new object[] { attribute.InnerText });
                                curFieldInfo.SetValue(instance, value);

                            }
                        }
                        catch (Exception e)
                        {
                            Debug.LogError($"执行文本转换时出现问题,文本内容:{attribute.InnerText},具体问题：{e}");
                        }
                    }

                    ObjectConfig.ObjectInfoDic.Add(((BaseInfo)instance).itemCode, (BaseInfo)instance);

                }
                catch (Exception e)
                {
                    Debug.LogError($"生成物体信息出现问题,类型名称:{typeName},物体名称:{itemName},具体问题：{e}");
                }

            }
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
                    writer.WriteAttributeString("infoType", xmlFileName);

                    // Write some child elements
                    //writer.WriteStartElement("item");
                    //writer.WriteAttributeString("name", "child1");
                    //writer.WriteString("some text");
                    //writer.WriteEndElement();
                    var elementNames = xmlContentArray[0];
                    var elementTypes = xmlContentArray[1];
                    xmlContentArray.RemoveAt(1);
                    xmlContentArray.RemoveAt(0);

                    int index = elementNames.IndexOf("");
                    if (index != -1)
                    {
                        Debug.Log($"名称行中第一个为空的元素位置为{index},已调整遍历结束位置");
                    }
                    else
                    {
                        index = elementNames.Count;
                    }

                    for (int i = 0; i < xmlContentArray.Count; i++)
                    {
                        List<string> item = xmlContentArray[i];
                        writer.WriteStartElement("item");

                        for (int j = 0; j < index; j++)
                        {
                            string element = item[j];

                            if (string.IsNullOrEmpty(elementNames[j]))
                            {
                                Debug.LogError($"第{j}个元素为空,不能作为名称");
                                return;
                            }
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
                Debug.Log($"已结束生成，位置:{xmlFileFullPath}");
            }
        }
    }
}
