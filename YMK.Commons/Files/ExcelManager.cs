using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data;
using YMK.Commons.Consts;

namespace YMK.Commons.Files
{
    /// <summary>
    /// エクセルの読み取り、書き込み
    /// コメント：他のエクセル操作ツール
    /// 　　　　　　①NPOI.dll(select,update,insert,delete)　　　　　　　無料
    /// 　　　　　　②EPPlus.dll(select,update,insert,delete)　　　　　　無料
    /// 　　　　　　　　(制限：伺服器端產生Office Open XML Excel檔(Excel 2007/2010的xlsx，不包含Excel 2003 xls)）
    ///           　②LinqToExcel.dll(select　処理が速い)                無料
    /// </summary>
    public class ExcelManager
    {
        /// <summary>
        /// エクセルの読み取り
        /// </summary>
        /// <param name="xlsName">エクセルのパス</param>
        /// <param name="startRow">読み取り開始行「１～MAX」</param>
        /// <returns></returns>
         public static List<Array> Excel2List(String xlsName, int startRow)
        {
            List<System.Array> lstDatas = new List<Array>() ;
            Excel.Application excelApp = new Excel.Application();  // Creates a new Excel Application
            excelApp.Visible = false;  // Makes Excel visible to the user.
            excelApp.DisplayAlerts = false;

            Excel.Workbook excelWorkbook = null;
            Excel.Worksheet excelWorksheet = null;
            excelWorkbook = excelApp.Workbooks.Open(
      xlsName,  // オープンするExcelファイル名
      Type.Missing, // （省略可能）UpdateLinks (0 / 1 / 2 / 3)
      true, // （省略可能）ReadOnly (True / False )
      Type.Missing, // （省略可能）Format
                // 1:タブ / 2:カンマ (,) / 3:スペース / 4:セミコロン (;)
                // 5:なし / 6:引数 Delimiterで指定された文字
      Type.Missing, // （省略可能）Password
      Type.Missing, // （省略可能）WriteResPassword
      Type.Missing, // （省略可能）IgnoreReadOnlyRecommended
      Type.Missing, // （省略可能）Origin
      Type.Missing, // （省略可能）Delimiter
      Type.Missing, // （省略可能）Editable
      Type.Missing, // （省略可能）Notify
      Type.Missing, // （省略可能）Converter
      Type.Missing, // （省略可能）AddToMru
      Type.Missing, // （省略可能）Local
      Type.Missing);// （省略可能）CorruptLoad


            try
            {

                // The following gets the Worksheets collection
                Excel.Sheets excelSheets = excelWorkbook.Worksheets;
                for (int i = 0; i < excelSheets.Count; i++)
                {
                    excelWorksheet = (Excel.Worksheet)excelSheets[i + 1];
                    Excel.Range range;

                    range = excelWorksheet.get_Range(excelWorksheet.Cells[startRow, 1], excelWorksheet.Cells[excelWorksheet.UsedRange.Rows.Count, excelWorksheet.UsedRange.Columns.Count]);
                    
                    lstDatas.Add((Object[,])(range.Cells.Value2));
                }
            }
            finally
            {
                // 開放処理
                // [Worksheet] -> [Worksheets] -> [Workbook] -> [Workbooks] -> [Excel Application]
                // の順に開放すること

                if (excelWorksheet != null)
                {
                    Marshal.ReleaseComObject(excelWorksheet);
                }
                if (excelWorkbook != null)
                {
                    excelWorkbook.Close(true, Type.Missing, Type.Missing);
                    Marshal.ReleaseComObject(excelWorkbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
            }

            return lstDatas;
        }


         /// <summary>
         /// Exporta la informaci de un DataTable a Excel
         /// </summary>
         /// <param name="pDataTable">DataTable de origen</param>
         /// <param name="dgv">DataGridView de origen (solo para tomar los titulos de las columnas y determinar las columnas a mostrar)</param>
         /// <param name="pFullPath_toExport">Ruta a exportar</param>
         /// <param name="nameSheet">Nombre de la hoja</param>
         /// <param name="showExcel">Mostrar excel?</param>
         public static void DataTable2Excel(System.Data.DataTable pDataTable, string pFullPath_toExport, string nameSheet)
         {
             string vFileName = Path.GetTempFileName();
             FileInfo file = new FileInfo(vFileName);
             string sb = string.Empty;
             // The using statement also closes the Stream.
             using (StreamWriter writer = new StreamWriter(file.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite), Encoding.UTF8))
             {
                 foreach (DataColumn dc in pDataTable.Columns)
                 {

                     string title = string.Empty;

                     title = dc.Caption;
                     sb += title + ControlChars.Tab;

                 }

                 writer.WriteLine(sb);
                 int i = 0;
                 //para cada fila de datos
                 foreach (DataRow dr in pDataTable.Rows)
                 {
                     sb = string.Empty;
                     //para cada columna de datos
                     foreach (DataColumn dc in pDataTable.Columns)
                     {
                         sb = sb + ((dr[i] == DBNull.Value) ? string.Empty : FormatCell(dr[i])) + ControlChars.Tab;
                         
                     }
                     writer.WriteLine(sb);
                 }
             }
             
             Text2Excel(vFileName, pFullPath_toExport, nameSheet);
         }

         /// <summary>
         /// Exporta un determinado texto en cadena a excel
         /// </summary>
         /// <param name="pFileName">Filename del archivo exportado</param>
         /// <param name="pFullPath_toExport">Ruta del archivo exportado</param>
         /// <param name="nameSheet">nombre de la hoja</param>
         /// <param name="showExcel">Mostrar excel?</param>
         public static void Text2Excel(string pFileName, string pFullPath_toExport, string nameSheet)
         {
             System.Globalization.CultureInfo vCultura = System.Threading.Thread.CurrentThread.CurrentCulture;
             System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
             Microsoft.Office.Interop.Excel.Application Exc = new Microsoft.Office.Interop.Excel.Application();
             Exc.Workbooks.OpenText(pFileName, Missing.Value, 1,
                 XlTextParsingType.xlDelimited,
                 XlTextQualifier.xlTextQualifierNone,
                 Missing.Value, Missing.Value,
                 Missing.Value, true,
                 Missing.Value, Missing.Value,
                 Missing.Value, Missing.Value,
                 Missing.Value, Missing.Value,
                 Missing.Value, Missing.Value, Missing.Value);

             Workbook Wb = Exc.ActiveWorkbook;
             Worksheet Ws = (Worksheet)Wb.ActiveSheet;
             Ws.Name = nameSheet;

             try
             {
                 //Formato de cabecera
                 Ws.get_Range(Ws.Cells[1, 1], Ws.Cells[Ws.UsedRange.Rows.Count, Ws.UsedRange.Columns.Count]).AutoFormat(XlRangeAutoFormat.xlRangeAutoFormatClassic1, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                 //改善　： 件数 > WorkSheet.Rows.Countの場合　複数シートに表示する start
                 //WorkSheet.Rows.Count:ワークシートのサイズは2003までのExcelの場合65,536行×256列でしたが、
                 //Excel 2007からは1,048,576行×16,384列となっています。


                 //改善　：　Ws.Rows.Countの場合　複数シートに表示する end


                 string tempPath = Path.GetTempFileName();

                 //pFileName = tempPath.Replace("tmp", "xls");
                 //File.Delete(pFileName);

                 if (File.Exists(pFullPath_toExport))
                 {
                     File.Delete(pFullPath_toExport);
                 }
                 //udpate by I.TYOU 20141030 start
                 //Exc.ActiveWorkbook.SaveAs(pFullPath_toExport, 1, null, null, null, null, XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
                 String kts = Path.GetExtension(pFullPath_toExport).ToLower();
                 Excel.XlFileFormat fm;
                 switch (kts)
                 {
                     case ".csv":        //CSV (カンマ区切り) 形式
                         fm = Excel.XlFileFormat.xlCSV;
                         break;
                     case ".xls":       //Excel 97～2003 ブック形式
                         fm = Excel.XlFileFormat.xlExcel8;
                         break;
                     case ".xlsx":       //Excel 2007～ブック形式
                         fm = Excel.XlFileFormat.xlOpenXMLWorkbook;
                         break;
                     case ".xlsm":       //Excel 2007～マクロ有効ブック形式
                         fm = Excel.XlFileFormat.xlOpenXMLWorkbookMacroEnabled;
                         break;
                     default:            //必要なものは、追加して下さい。
                         fm = Excel.XlFileFormat.xlWorkbookDefault;
                         //MessageBox.Show("ファイルの保存形式を確認して下さい。");
                         break;
                 }
                 Exc.ActiveWorkbook.SaveAs(pFullPath_toExport, fm, null, null, null, null, XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);

                 //udpate by I.TYOU 20141030 end
             }
             catch (Exception ex)
             {
                 //Ws.get_Range(Ws.Cells[1, 1], Ws.Cells[Ws.UsedRange.Rows.Count, Ws.UsedRange.Columns.Count]);
                 throw ex;
             }
             finally
             {

                 // 開放処理
                 // [Worksheet] -> [Worksheets] -> [Workbook] -> [Workbooks] -> [Excel Application]
                 // の順に開放すること

                 if (Ws != null)
                 {
                     Marshal.ReleaseComObject(Ws);
                     Ws = null;
                 }
                 if (Exc.Workbooks != null)
                 {
                     Exc.Workbooks.Close();
                     Marshal.ReleaseComObject(Wb);
                     Wb = null;
                 }
                 if (Exc != null)
                 {
                     Exc.Quit();
                     Marshal.ReleaseComObject(Exc);
                     Exc = null;
                 }

                 GC.Collect();
                 GC.WaitForPendingFinalizers();
                 GC.Collect();
                 System.Threading.Thread.CurrentThread.CurrentCulture = vCultura;

                 File.Delete(pFileName);//add by I.TYOU 20141030
             }

             //Exc.Workbooks.Close();
             //System.Runtime.InteropServices.Marshal.ReleaseComObject(Ws);
             //Ws = null;

             //System.Runtime.InteropServices.Marshal.ReleaseComObject(Wb);
             //Wb = null;

             //Exc.Quit();

             //System.Runtime.InteropServices.Marshal.ReleaseComObject(Exc);
             //Exc = null;
             //GC.Collect();
             //GC.WaitForPendingFinalizers();
             //GC.Collect();
             //System.Threading.Thread.CurrentThread.CurrentCulture = vCultura;

             //File.Delete(pFileName);//add by I.TYOU 20141030

         }

         /// <summary>
         /// Limpieza de caracteres de la celda a exportar
         /// </summary>
         /// <param name="cell">Celda del datarow a formatear</param>
         /// <returns>cadena formateada</returns>
         private static string FormatCell(Object cell)
         {
             string TextToParse = Convert.ToString(cell);
             return TextToParse.Replace(",", string.Empty);
         }
    }
}
