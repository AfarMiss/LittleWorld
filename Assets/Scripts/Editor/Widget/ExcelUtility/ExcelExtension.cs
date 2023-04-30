using System.IO;
using UnityEditor;
using ExcelDataReader;
using UnityEngine;

namespace ExcelUtil
{
    public class ExcelUtility
    {
        public static void ConvertExcelToXml(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                {
                    do
                    {
                        while (reader.Read())
                        {
                        }
                    } while (reader.NextResult());

                    var result = reader.AsDataSet();
                    string xmlFileName = "excel_data.xml";
                    result.WriteXml(xmlFileName);
                    Debug.Log("配置结束！位置:" + System.Environment.CurrentDirectory + "\\" + xmlFileName);
                }
                reader.Close();
            }
        }

        [MenuItem("Tools/快速Excel->Ores")]
        public static void AutoExcelToXML()
        {
            ConvertExcelToXml("Assets\\Excels\\Ores.xlsx");
        }
    }
}
