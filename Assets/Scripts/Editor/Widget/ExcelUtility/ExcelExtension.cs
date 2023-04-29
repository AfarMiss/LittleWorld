using System.IO;
using UnityEditor;
using ExcelDataReader;

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
                    //do
                    //{
                    //    while (reader.Read())
                    //    {
                    //    }
                    //} while (reader.NextResult());

                    //var result = reader.AsDataSet();
                    //string xmlFileName = "excel_data.xml";
                    //result.WriteXml(xmlFileName);
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
