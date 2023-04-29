using System.IO;
using UnityEditor;
using ExcelDataReader;
using System.Data;

namespace ExcelUtility
{
    public class ExcelUtility
    {
        public static DataSet ConvertExcelToXml(string filePath)
        {
            DataSet result = null;
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    result = reader.AsDataSet();

                    // The result of each spreadsheet is in result.Tables
                }
            }
            return result;
        }

        [MenuItem("Tools/快速Excel->Ores")]
        public static void AutoExcelToXML()
        {
            var filePath = "Assets\\Excels\\Ores.xlsx";
            ConvertExcelToXml(filePath);
        }
    }
}
