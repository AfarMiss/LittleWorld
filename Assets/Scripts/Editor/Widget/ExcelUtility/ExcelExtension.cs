using System.IO;
using UnityEditor;
using ExcelDataReader;
using UnityEngine;
using System.Data;
using System;

namespace ExcelUtil
{
    public class ExcelUtility
    {
        public static void ConvertExcelToXml(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet result = reader.AsDataSet();

                DataTable table = result.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        object cellValue = row[col];
                        Debug.Log($"[{row.Table.Rows.IndexOf(row)},{col.Ordinal}] = {cellValue}");
                    }
                }
                do
                {
                    while (reader.Read())
                    {
                    }
                } while (reader.NextResult());

                string xmlFileName = "excel_data.xml";
                result.WriteXml(xmlFileName);
                Debug.Log("配置结束！位置:" + System.Environment.CurrentDirectory + "\\" + xmlFileName);
            }

        }

        [MenuItem("Tools/快速Excel->Ores")]
        public static void AutoExcelToXML()
        {
            ConvertExcelToXml("Assets\\Excels\\Ores.xlsx");
        }
    }
}
