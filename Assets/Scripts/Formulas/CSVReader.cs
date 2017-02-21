using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;

public class CSVReader : MonoBehaviour
{
    void Start()
    {
        FileStream fileOut = new FileStream(Application.dataPath + "\\Scripts\\Formulas\\test.xlsx", FileMode.Open);
        IWorkbook workbook = WorkbookFactory.Create(fileOut);

        //workbook.GetNameAt(0);
        ISheet testSheet = workbook.GetSheetAt(0);
        Debug.Log(testSheet.SheetName);
        IRow row = testSheet.GetRow(0);
        ICell first = row.GetCell(0);
        ICell second = row.GetCell(1);

        Debug.Log(first.StringCellValue);
        Debug.Log(second.StringCellValue);

        fileOut.Close();
    }
}