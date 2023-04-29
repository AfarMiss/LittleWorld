using ExcelTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAStar : MonoBehaviour
{

    private void Start()
    {
        ExcelConvertor.ConvertExcelToXml("Assets\\Excels\\Ores.xlsx");
    }
}
