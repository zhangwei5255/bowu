using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Microsoft.VisualBasic;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using YMK.Commons.Files;
using YMK.Commons.Utility;
//using Opcion.Util;


namespace Win.YMK.Controls.Grids.Exports
{
    public class ExportToExcel
    {

        /// <summary>
        /// Exporta la informaci de un dataGridView a Excel
        /// </summary>
        /// <param name="dataGridView">DataGridView de origen</param>
        /// <param name="pFullPath_toExport">Ruta del archivo exportado</param>
        /// <param name="nameSheet">Nombre de la hoja</param>
        /// <param name="showExcel">Mostrar excel?</param>
        public void dataGridView2Excel(DataGridView dataGridView, string pFullPath_toExport, string nameSheet)
        {
            Object obj = dataGridView.DataSource;
            System.Data.DataTable dt = new System.Data.DataTable();

            //update by I.TYOU 20141031 カスタム改ページグリッド「GridViewExt」の対応 start
            ////Obtener un datatable del datagridview
            //if(dataGridView.DataSource is DataSet) 
            //{
            //    if (((System.Data.DataSet)dataGridView.DataSource).Tables.Count > 0)
            //        dt = ((System.Data.DataSet)dataGridView.DataSource).Tables[0];
            //    else
            //        dt = new System.Data.DataTable();
            //}
            //else if(dataGridView.DataSource is System.Data.DataTable)
            //{
            //    dt = (System.Data.DataTable)dataGridView.DataSource;
            //}
            //else if (dataGridView.DataSource is ArrayList)
            //{
            //    ArrayList arr = (ArrayList)dataGridView.DataSource;
            //    dt = ArrayListToDataTable(arr);
                
            //}

            if (dataGridView is GridViewExt)
            {
                GridViewExt gve = dataGridView as GridViewExt;
                dt = getDataSource(gve.DreamDataSoure);

            }
            else
            {
                dt = getDataSource(dataGridView.DataSource);
            }
            //update by I.TYOU 20141031 カスタム改ページグリッド「GridViewExt」の対応 end
            //DataTable2Excel(dt, dataGridView, pFullPath_toExport, nameSheet);
            ExcelManager.DataTable2Excel(dt, pFullPath_toExport, nameSheet);
        }

        //add by I.TYOU 20141031 カスタム改ページグリッド「GridViewExt」の対応 start
        private System.Data.DataTable getDataSource(Object obj)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            if (obj is DataSet)
            {
                if (((System.Data.DataSet)obj).Tables.Count > 0)
                    dt = ((System.Data.DataSet)obj).Tables[0];
                else
                    dt = new System.Data.DataTable();
            }
            else if (obj is System.Data.DataTable)
            {
                dt = (System.Data.DataTable)obj;
            }
            else if (obj is ArrayList)
            {
                ArrayList arr = (ArrayList)obj;
                dt = UtilConvert.ArrayList2DataTable(arr);

            }
            else if (obj is BindingSource)
            {
                BindingSource bs = (BindingSource)obj;
                if (bs.DataSource is DataSet)
                {
                    if (((System.Data.DataSet)bs.DataSource).Tables.Count > 0)
                        dt = ((System.Data.DataSet)bs.DataSource).Tables[0];
                    else
                        dt = new System.Data.DataTable();
                }
                else if (bs.DataSource is System.Data.DataTable)
                {
                    dt = (System.Data.DataTable)bs.DataSource;
                }
                else if (bs.DataSource is ArrayList)
                {
                    ArrayList arr = (ArrayList)bs.DataSource;
                    dt = UtilConvert.ArrayList2DataTable(arr);

                }
            }

            return dt;
        }
        //add by I.TYOU 20141031 カスタム改ページグリッド「GridViewExt」の対応 end

        ///// <summary>
        ///// Exporta la informaci de un DataTable a Excel
        ///// </summary>
        ///// <param name="pDataTable">DataTable de origen</param>
        ///// <param name="dgv">DataGridView de origen (solo para tomar los titulos de las columnas y determinar las columnas a mostrar)</param>
        ///// <param name="pFullPath_toExport">Ruta a exportar</param>
        ///// <param name="nameSheet">Nombre de la hoja</param>
        ///// <param name="showExcel">Mostrar excel?</param>
        //public void dataTable2Excel(System.Data.DataTable pDataTable, DataGridView dgv, string pFullPath_toExport, string nameSheet) 
        //{
        //    string vFileName = Path.GetTempFileName();
        //    FileSystem.FileOpen(1, vFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

        //    string sb = string.Empty;
        //    //si existe datagridview, tomar de 駘 los nombres de columnas y la visibilidad de las mismas
        //    if (dgv != null)
        //    {
        //        foreach (DataColumn dc in pDataTable.Columns)
        //        {
        //            System.Windows.Forms.Application.DoEvents();
        //            string title = string.Empty;

        //            //recuperar el t咜ulo que aparece en la grilla
        //            //Notar que debe haber sincron僘 con las columnas del detalle
        //            //一時修正 start
        //            //if (dgv.Columns[dc.Caption] != null)
        //            //{
        //            //    //Obtener el texto de cabecera de la grilla
        //            //    title = dgv.Columns[dc.Caption].HeaderText;
        //            //    sb += title + ControlChars.Tab;
        //            //}

        //            title = dc.Caption;
        //            sb += title + ControlChars.Tab;
        //            //一時修正 end
        //        }
        //    }
        //    else 
        //    {
        //        //si no existe datagridview tomar el nombre de la columna del datatable
        //        foreach (DataColumn dc in pDataTable.Columns)
        //        {
        //            System.Windows.Forms.Application.DoEvents();
        //            string title = string.Empty;

        //            title = dc.Caption;
        //            sb += title + ControlChars.Tab;

        //        }
        //    }
            
        //    FileSystem.PrintLine(1, sb);

        //    int i = 0;
        //    //para cada fila de datos
        //    foreach (DataRow dr in pDataTable.Rows) 
        //    {
        //        System.Windows.Forms.Application.DoEvents();
        //        i = 0;
        //        sb = string.Empty;
        //        //para cada columna de datos
        //        foreach (DataColumn dc in pDataTable.Columns)
        //        {
        //            ////solo mostrar aquellas columnas q pertenezcan a la grilla
        //            ////notar que debe haber sincronia con las columnas del la cabecera
        //            ////一時修正　start
        //            //if (dgv != null && dgv.Columns[dc.Caption] != null)
        //            //{
        //            //    System.Windows.Forms.Application.DoEvents();
        //            //    //Linea q genera la impresi del registro
        //            //    sb = sb + (Information.IsDBNull(dr[i]) ? string.Empty : FormatCell(dr[i])) + ControlChars.Tab;

        //            //}
        //            //else if (dgv == null)
        //            //{
        //            //    System.Windows.Forms.Application.DoEvents();
        //            //    //Linea q genera la impresi del registro
        //            //    sb = sb + (Information.IsDBNull(dr[i]) ? string.Empty : FormatCell(dr[i])) + ControlChars.Tab;
        //            //}

        //            System.Windows.Forms.Application.DoEvents();
        //            //Linea q genera la impresi del registro
        //            sb = sb + (Information.IsDBNull(dr[i]) ? string.Empty : FormatCell(dr[i])) + ControlChars.Tab;
        //            //一時修正　end
        //            i++;
        //        }
        //        FileSystem.PrintLine(1, sb);
        //    }
        //    FileSystem.FileClose(1);
        //    TextToExcel(vFileName, pFullPath_toExport, nameSheet);
        //}

        ///// <summary>
        ///// Limpieza de caracteres de la celda a exportar
        ///// </summary>
        ///// <param name="cell">Celda del datarow a formatear</param>
        ///// <returns>cadena formateada</returns>
        //private string FormatCell(Object cell)
        //{
        //    string TextToParse = Convert.ToString(cell);
        //    return TextToParse.Replace(",",string.Empty);
        //}

        ///// <summary>
        ///// Exporta un determinado texto en cadena a excel
        ///// </summary>
        ///// <param name="pFileName">Filename del archivo exportado</param>
        ///// <param name="pFullPath_toExport">Ruta del archivo exportado</param>
        ///// <param name="nameSheet">nombre de la hoja</param>
        ///// <param name="showExcel">Mostrar excel?</param>
        //private void TextToExcel(string pFileName, string pFullPath_toExport, string nameSheet)
        //{            
        //    System.Globalization.CultureInfo vCultura = System.Threading.Thread.CurrentThread.CurrentCulture;
        //    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
        //    Microsoft.Office.Interop.Excel.Application Exc = new Microsoft.Office.Interop.Excel.Application();
        //    Exc.Workbooks.OpenText(pFileName, Missing.Value, 1,
        //        XlTextParsingType.xlDelimited,
        //        XlTextQualifier.xlTextQualifierNone,
        //        Missing.Value, Missing.Value, 
        //        Missing.Value, true, 
        //        Missing.Value, Missing.Value, 
        //        Missing.Value, Missing.Value, 
        //        Missing.Value, Missing.Value, 
        //        Missing.Value, Missing.Value, Missing.Value);

        //    Workbook Wb = Exc.ActiveWorkbook;
        //    Worksheet Ws = (Worksheet)Wb.ActiveSheet;
        //    Ws.Name = nameSheet;

        //    try
        //    {
        //        //Formato de cabecera
        //        Ws.get_Range(Ws.Cells[1, 1], Ws.Cells[Ws.UsedRange.Rows.Count, Ws.UsedRange.Columns.Count]).AutoFormat(XlRangeAutoFormat.xlRangeAutoFormatClassic1, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
        //        //改善　： 件数 > WorkSheet.Rows.Countの場合　複数シートに表示する start
        //        //WorkSheet.Rows.Count:ワークシートのサイズは2003までのExcelの場合65,536行×256列でしたが、
        //        //Excel 2007からは1,048,576行×16,384列となっています。


        //        //改善　：　Ws.Rows.Countの場合　複数シートに表示する end


        //        string tempPath = Path.GetTempFileName();

        //        //pFileName = tempPath.Replace("tmp", "xls");
        //        //File.Delete(pFileName);

        //        if (File.Exists(pFullPath_toExport))
        //        {
        //            File.Delete(pFullPath_toExport);
        //        }
        //        //udpate by I.TYOU 20141030 start
        //        //Exc.ActiveWorkbook.SaveAs(pFullPath_toExport, 1, null, null, null, null, XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
        //        String kts = Path.GetExtension(pFullPath_toExport).ToLower();
        //        Excel.XlFileFormat fm;
        //        switch (kts)
        //        {
        //            case ".csv":        //CSV (カンマ区切り) 形式
        //                fm = Excel.XlFileFormat.xlCSV;
        //                break;
        //            case ".xls":       //Excel 97～2003 ブック形式
        //                fm = Excel.XlFileFormat.xlExcel8;
        //                break;
        //            case ".xlsx":       //Excel 2007～ブック形式
        //                fm = Excel.XlFileFormat.xlOpenXMLWorkbook;
        //                break;
        //            case ".xlsm":       //Excel 2007～マクロ有効ブック形式
        //                fm = Excel.XlFileFormat.xlOpenXMLWorkbookMacroEnabled;
        //                break;
        //            default:            //必要なものは、追加して下さい。
        //                fm = Excel.XlFileFormat.xlWorkbookDefault;
        //                //MessageBox.Show("ファイルの保存形式を確認して下さい。");
        //                break;
        //        }
        //        Exc.ActiveWorkbook.SaveAs(pFullPath_toExport, fm, null, null, null, null, XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
                 
        //        //udpate by I.TYOU 20141030 end
        //    }
        //    catch (Exception ex)
        //    {
        //        //Ws.get_Range(Ws.Cells[1, 1], Ws.Cells[Ws.UsedRange.Rows.Count, Ws.UsedRange.Columns.Count]);
        //        throw ex;
        //    }
        //    finally
        //    {

        //        // 開放処理
        //        // [Worksheet] -> [Worksheets] -> [Workbook] -> [Workbooks] -> [Excel Application]
        //        // の順に開放すること

        //        if (Ws != null)
        //        {
        //            Marshal.ReleaseComObject(Ws);
        //            Ws = null;
        //        }
        //        if (Exc.Workbooks != null)
        //        {
        //            Exc.Workbooks.Close();
        //            Marshal.ReleaseComObject(Wb);
        //            Wb = null;
        //        }
        //        if (Exc != null)
        //        {
        //            Exc.Quit();
        //            Marshal.ReleaseComObject(Exc);
        //            Exc = null;
        //        }

        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //        GC.Collect();
        //        System.Threading.Thread.CurrentThread.CurrentCulture = vCultura;

        //        File.Delete(pFileName);//add by I.TYOU 20141030
        //    }

        //    //Exc.Workbooks.Close();
        //    //System.Runtime.InteropServices.Marshal.ReleaseComObject(Ws);
        //    //Ws = null;

        //    //System.Runtime.InteropServices.Marshal.ReleaseComObject(Wb);
        //    //Wb = null;

        //    //Exc.Quit();

        //    //System.Runtime.InteropServices.Marshal.ReleaseComObject(Exc);
        //    //Exc = null;
        //    //GC.Collect();
        //    //GC.WaitForPendingFinalizers();
        //    //GC.Collect();
        //    //System.Threading.Thread.CurrentThread.CurrentCulture = vCultura;

        //    //File.Delete(pFileName);//add by I.TYOU 20141030

        //}

        ///// <summary>
        ///// Convierte un arraylist de objetos en un datatable a partir de las 'propiedades' del arraylist
        ///// </summary>
        ///// <param name="array">Arraylist de objetos</param>
        ///// <returns>DataTable de salida</returns>
        //public static System.Data.DataTable ArrayListToDataTable(ArrayList array) 
        //{
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    if (array.Count > 0) 
        //    {
        //        object obj = array[0];
        //        //Convertir las propiedades del objeto en columnas del datarow
        //        foreach (PropertyInfo info in obj.GetType().GetProperties()) 
        //        {
        //            dt.Columns.Add(info.Name, info.PropertyType);
        //        }
        //    }
        //    foreach (object obj in array)
        //    {
        //        DataRow dr = dt.NewRow();
        //        foreach (DataColumn col in dt.Columns) 
        //        {
        //            Type type = obj.GetType();
                    
        //            MemberInfo[] members = type.GetMember(col.ColumnName);

        //            object valor;
        //            if (members.Length != 0)
        //            {
        //                switch (members[0].MemberType)
        //                {
        //                    case MemberTypes.Property:
        //                        //leer las propiedades del objeto
        //                        PropertyInfo prop = (PropertyInfo)members[0];
        //                        try 
        //                        {
        //                            valor = prop.GetValue(obj, new object[0]);
        //                        }
        //                        catch
        //                        {
        //                            valor = prop.GetValue(obj, null);
        //                        }
                                
        //                        break;
        //                    case MemberTypes.Field:
        //                        //leer los campos del objeto (no se usa 
        //                        //dado q hemos poblado el dt con las propiedades del arraylist)
        //                        FieldInfo field = (FieldInfo)members[0];
        //                        valor = field.GetValue(obj);
        //                        break;
        //                    default:
        //                        throw new NotImplementedException();
        //                }
        //                dr[col] = valor;
        //            } 
        //        }
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}
        
        

        public static string readcell(Range oRange)
        {
            String result = string.Empty;
            if (oRange != null)
            {
                if (oRange.Text != null)
                {
                    result = oRange.Text.ToString();
                }
            }
            return result;
        }

    }
}

