using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


namespace attendance
{
    class Export
    {
        public bool IsExportedToExcel(List<Record> list)
        {
            try
            {
                Excel.Application xla = new Excel.Application();
                Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet ws = (Worksheet)xla.ActiveSheet;

                xla.Visible = true; //open

                //cosmetics
                ws.Cells[1, 1].EntireRow.Font.Bold = true;
                ws.Cells[2, 1].EntireRow.Font.Bold = true;

                for (int i = 1; i < 7; i++)
                {
                    ws.Columns[i].ColumnWidth = 12;
                }

                ws.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


                //záhlaví
                if (list.Any())
                {
                    ws.Cells[1, 1] = new Connection().GetMonth(list[0].Month);
                }

                //hlavička
                ws.Cells[2, 1] = "Jméno";
                ws.Cells[2, 2] = "Příjmení";
                ws.Cells[2, 3] = "Den";
                ws.Cells[2, 4] = "Začátek";
                ws.Cells[2, 5] = "Konec";
                ws.Cells[2, 6] = "Celkový čas";

                //data
                for (int i = 3; i < list.Count + 3; i++)
                {
                    ws.Cells[i, 1] = list[i - 3].FirstName;
                    ws.Cells[i, 2] = list[i - 3].LastName;
                    ws.Cells[i, 3] = $"{list[i - 3].ConcatDay}"; 
                    ws.Cells[i, 4] = list[i - 3].Beginning;
                    ws.Cells[i, 5] = list[i - 3].Ending;
                    ws.Cells[i, 6] = list[i - 3].Time;

                    if (list[i - 3].Ending == "Neukončeno")
                        ws.Cells[i, 5].Interior.ColorIndex = 41;

                    if (list[i - 3].Time == "Mimo limit")
                        ws.Cells[i, 6].Interior.ColorIndex = 41;
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
