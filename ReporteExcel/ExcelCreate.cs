using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReporteExcel
{
    class ExcelCreate
    {
        Excel.Application excel;
        Excel.Workbook excelworkBook;
        Excel.Worksheet excelSheet;
        Excel.Range excelCellrange;
        private int rowcount, colums = 0;

        public void WriteDataTableToExcel(List<DataTable> listDT, string worksheetName, string saveAsLocation, string ReporType, Form1 f1)
        {
            
                // Start Excel and get Application object.
                excel = new Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;


                excelSheet.Cells[1, 1] = ReporType;
                excelSheet.Cells[1, 2] = "Date : " + DateTime.Now.ToShortDateString();
                int inicio = 3;
                int fin = 0;
                Task[] wait = new Task[listDT.Count];
                int ia = 0;

                foreach (DataTable dataTable in listDT)
                {

                    fin = dataTable.Rows.Count;
                    wait[ia] = Task.Factory.StartNew(() => GenerateSheet(dataTable, inicio));
                    ia++;
                    inicio += fin+10;
                    colums = dataTable.Columns.Count;
                }
                Task.WaitAll(wait);
                f1.SetText("Guardando archivo excel en: \n" + saveAsLocation + " .");

                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[inicio, colums]];
                excelCellrange.EntireColumn.AutoFit();
                //Excel.Borders border = excelCellrange.Borders;
                //border.LineStyle = Excel.XlLineStyle.xlContinuous;
                //border.Weight = 2d;


                //excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[1, colums]];
                //FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);


                //now save the workbook and exit Excel
                excelworkBook.Saved = true;
                excelworkBook.SaveAs(saveAsLocation, Excel.XlFileFormat.xlOpenXMLWorkbook, Missing.Value,
                                        Missing.Value, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                                        Excel.XlSaveConflictResolution.xlUserResolution, true,
                                        Missing.Value, Missing.Value, Missing.Value);
                excelworkBook.Close();
                excel.Quit();
                System.Threading.Thread.Sleep(500);

        }

        private void GenerateSheet(DataTable dataTable, int inicial)
        {
            int  inicio= inicial;
            for (int i = 1; i <= dataTable.Columns.Count; i++)
            {
                excelSheet.Cells[inicio, i] = dataTable.Columns[i - 1].ColumnName;
            }

            excelCellrange = excelSheet.Range[excelSheet.Cells[inicio, 1], excelSheet.Cells[inicio, dataTable.Columns.Count]];
            FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);

            foreach (DataRow datarow in dataTable.Rows)
            {
                inicio += 1;
                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    excelSheet.Cells[inicio, i] = datarow[i - 1].ToString();
                }
            }

        }

        /// <summary>
        /// FUNCTION FOR FORMATTING EXCEL CELLS
        /// </summary>
        /// <param name="range"></param>
        /// <param name="HTMLcolorCode"></param>
        /// <param name="fontColor"></param>
        /// <param name="IsFontbool"></param>
        public void FormattingExcelCells(Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }


    }


}
