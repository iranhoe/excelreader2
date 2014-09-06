using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReporteExcel
{
    class ExcelReader
    {
        private List<string> listaAsientos = new List<string>();

        public List<string> ReadFile(string xlsFilePath, Form1 f1)
        {
            if (!File.Exists(xlsFilePath))
                return listaAsientos ;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            var misValue = Type.Missing;//System.Reflection.Missing.Value;

            // abrir el documento
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(xlsFilePath, misValue, misValue,
                misValue, misValue, misValue, misValue, misValue, misValue,
                misValue, misValue, misValue, misValue, misValue, misValue);


                // seleccion de la hoja de calculo
                // get_item() devuelve object y numera las hojas a partir de 1
             xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
             
             
             f1.SetText("Extrayendo lista de asientos...");             

                // seleccion rango activo
                range = xlWorkSheet.UsedRange;

                // leer las celdas
                int rows = range.Rows.Count;
                int cols = range.Columns.Count;

                for (int col = 1; col <= cols; col++)
                {
                    System.Threading.Thread.Sleep(10);
                    f1.Progress((col * 100) / cols);
                    for (int row = 1; row <= rows; row++)
                    {
                        

                        if ((range.Cells[row, col] as Excel.Range).Value2 != null)
                        {
                            if ((range.Cells[row, col] as Excel.Range).Value2.ToString().Length == 7)
                                listaAsientos.Add((range.Cells[row, col] as Excel.Range).Value2.ToString());
                        }
                    }


                }
            
                // cerrar
                xlWorkBook.Close(false, misValue, misValue);
                xlApp.Quit();
                // liberar
                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);
            

            return listaAsientos;
        }

        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to release the object(object:{0})", obj.ToString());
            }
            finally
            {
                obj = null;
                GC.Collect();
            }
        }


    }
}
