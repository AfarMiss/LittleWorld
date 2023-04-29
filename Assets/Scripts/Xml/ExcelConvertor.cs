using ExcelDataReader;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ExcelTool
{
    public class ExcelConvertor
    {
        public static void ConvertExcelToXml(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
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
                }
                //reader.Close();
            }
            Debug.Log("已完成转换!");
        }

        public static void AutoExcelToXML()
        {
            ConvertExcelToXml("Assets\\Excels\\Ores.xlsx");
        }
    }
}
