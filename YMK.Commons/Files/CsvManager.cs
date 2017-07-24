using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;

namespace YMK.Commons.Files
{


    /// <summary>
    /// エクセルの書き込み
    /// コメント：他のエクセル操作ツール
    ///           　①LinqToCSV.dll   読み取り、書き込みと(select　処理が速い)                  無料
    ///           　①LinqToExcel.dll 読み取り、書き込み(select　処理が速い)                    無料
    ///           　   CSVをエクセルとして操作する
    /// </summary>
    public class CsvManager
    {
        /// <summary>
        /// テキストデータファイル作成
        /// </summary>
        /// <param name="dtData">出力対象のDataTable</param>
        /// <param name="sDustFilePath">出力ファイルパス</param>
        /// <param name="opt">
        /// オプション(DataTable2TextFile.Optionクラス)
        /// enc                 : 文字コード            既定:Shift-JIS
        /// sFiledSeparator     : フィールド区切り      既定:カンマ(,)
        /// sLineBreak          : 行区切り              既定:CRLF
        /// enFieldEnclosed     : フィールド囲み        既定:特殊文字列を含む文字列フィールドだけ囲む
        /// bOutputHeader       : ヘッダ行の出力有無    既定:false
        /// bBooleanTypeFormat  : DateTime型の出力書式  既定:true(yyyyMMdd HH:mm:ss)
        /// sDateTimeTypeFormat : DateTime型の出力書式  既定:true(yyyyMMdd HH:mm:ss)
        /// </param>
        public static void DataTable2Csv(DataTable dtData, string sDustFilePath, CsvConfig opt)
        {
            StringBuilder sbContents = new StringBuilder(1024); // ファイルコンテンツ
            string sFieldEnclosed;                              // フィールド囲み文字
            //-----------------------------------------------------------------------------------------
            // データ型チェック
            //-----------------------------------------------------------------------------------------
            foreach (DataColumn col in dtData.Columns)
            {
                // データ型取得
                Type type = col.DataType;
                // 配列型チェック(Byte[]向け)
                // ※バイト配列型は印字不可能な文字になるかもしれないので削除
                if (type.IsArray)
                {
                    throw new ApplicationException("配列はフィールドに設定できません");
                }
                // バイト型(Byte/SByte)チェック
                // ※バイト型は印字不可能な文字になるかもしれないので削除
                if (type == typeof(Byte) || type == typeof(SByte))
                {
                    throw new ApplicationException("バイト型はフィールドに設定できません");
                }
            }
            //-----------------------------------------------------------------------------------------
            // フィールド囲み文字
            //-----------------------------------------------------------------------------------------
            // 「全フィールドを囲む」の場合
            if (opt.EnFieldEnclosed == EnumFieldEnclosed.AllField)
            {
                sFieldEnclosed = "\"";
            }
            // 「フィールドを囲まない」
            // 「文字列フィールドだけ囲む」
            // 「特殊文字列を含む文字列フィールドだけ囲む」の場合
            else
            {
                sFieldEnclosed = "";
            }
            //-----------------------------------------------------------------------------------------
            // ヘッダ行作成
            //-----------------------------------------------------------------------------------------
            if (opt.IsOutputHeader)
            {
                // 列名作成
                foreach (DataColumn col in dtData.Columns)
                {
                    sbContents.Append(col.ColumnName);
                    sbContents.Append(opt.Separator);
                }
                // 最後のフィールド区切りを削除
                if (sbContents.Length > 0)
                {
                    sbContents.Remove(sbContents.Length - opt.Separator.Length, opt.Separator.Length);
                }
                // 行区切り挿入
                sbContents.Append(opt.LineBreak);
            }
            //-----------------------------------------------------------------------------------------
            // コンテンツ行作成
            //-----------------------------------------------------------------------------------------
            for (int iRow = 0; iRow < dtData.Rows.Count; iRow++)
            {
                // 列データ作成
                for (int iCol = 0; iCol < dtData.Columns.Count; iCol++)
                {
                    // フィールドデータ取得
                    object objField = dtData.Rows[iRow][iCol];
                    // NULLの場合
                    if (objField is DBNull)
                    {
                        sbContents.Append(opt.Separator);
                    }
                    // 文字(String/Char)の場合
                    else if (objField is String || objField is Char)
                    {
                        string sField = objField.ToString();
                        switch (opt.EnFieldEnclosed)
                        {
                            //「フィールドを囲まない」
                            case EnumFieldEnclosed.None:
                                sbContents.Append(sField);
                                break;
                            //「全フィールドを囲む」の場合
                            case EnumFieldEnclosed.AllField:
                                sField = sField.Replace("\"", "\"\"");
                                sbContents.AppendFormat("\"{0}\"", sField);
                                break;
                            //「文字列フィールドだけ囲む」の場合
                            case EnumFieldEnclosed.StringField:
                                sField = sField.Replace("\"", "\"\"");
                                sbContents.AppendFormat("\"{0}\"", sField);
                                break;
                            //「特殊文字列を含む文字列フィールドだけ囲む」の場合
                            case EnumFieldEnclosed.ContainingSpecialCharactersField:
                                sField = sField.Replace("\"", "\"\"");
                                if (sField.IndexOf(opt.Separator) != -1)
                                {
                                    sbContents.AppendFormat("\"{0}\"", sField);
                                }
                                else if (sField.IndexOf(opt.LineBreak) != -1)
                                {
                                    sbContents.AppendFormat("\"{0}\"", sField);
                                }
                                else if (sField.IndexOf("\"") != -1)
                                {
                                    sbContents.AppendFormat("\"{0}\"", sField);
                                }
                                else
                                {
                                    sbContents.AppendFormat("{0}", sField);
                                }
                                break;
                        }
                        sbContents.Append(opt.Separator);
                    }
                    // 真偽型(Boolean)の場合
                    else if (objField is Boolean)
                    {
                        string sValue;
                        // True/Falseで出力
                        if (opt.IsBooleanTypeFormat)
                        {
                            sValue = ((bool)objField).ToString();
                        }
                        // 1/0で出力
                        else
                        {
                            sValue = ((bool)objField) ? "1" : "0";
                        }
                        sbContents.AppendFormat("{1}{0}{1}", sValue, sFieldEnclosed);
                        sbContents.Append(opt.Separator);
                    }
                    // 日時(DateTime)
                    else if (objField is DateTime)
                    {
                        string sFormat = "{1}{0:" + opt.DateTimeTypeFormat + "}{1}";
                        sbContents.AppendFormat(sFormat, objField, sFieldEnclosed);
                        sbContents.Append(opt.Separator);
                    }
                    // 数値型(Decimal/Double/Int16/Int32/Int64/Single/UInt16/UInt32/UInt64)
                    // 日時(TimeSpan)
                    else
                    {
                        sbContents.AppendFormat("{1}{0}{1}", objField, sFieldEnclosed);
                        sbContents.Append(opt.Separator);
                    }
                }
                // 最後のフィールド区切りを削除
                sbContents.Remove(sbContents.Length - opt.Separator.Length, opt.Separator.Length);
                // 行区切り挿入
                sbContents.Append(opt.LineBreak);
            }
            // 最終レコードの行区切り文字を削除
            if (!opt.IsLastRecordLineBreak && sbContents.Length > 0)
            {
                sbContents.Remove(sbContents.Length - opt.LineBreak.Length, opt.LineBreak.Length);
            }
            //-----------------------------------------------------------------------------------------
            // ファイル書込
            //-----------------------------------------------------------------------------------------
            using (StreamWriter sw = new StreamWriter(sDustFilePath, false, opt.Enc))
            {
                sw.Write(sbContents.ToString());
                sw.Close();
            }
        }

        public static void List2Csv<T>(IList<T> lst, string sDustFilePath, CsvConfig opt)
        {
            StringBuilder sbContents = new StringBuilder(1024); // ファイルコンテンツ
            string sFieldEnclosed; // フィールド囲み文字

            // Get the type T and the properties 
            Type tType = typeof(T);
            PropertyInfo[] piProperties = tType.GetProperties();

            foreach (T tCurObj in lst)
            {
                //プロパティのset
                //T oCurrentObject = T(Activator::CreateInstance(tType));
                //piProperty->SetValue(oCurrentObject, oValue->GetType() == DBNull::typeid ? nullptr : oValue, nullptr);

                foreach (PropertyInfo piProperty in piProperties)
                {
                    //piProperty->Name]
                    object objtest = piProperty.GetValue(tCurObj, null);

                    //tCurObj->GetFieldInfo(
                }

            }

            //-----------------------------------------------------------------------------------------
            // データ型チェック
            //-----------------------------------------------------------------------------------------
            foreach (PropertyInfo piProperty in piProperties)
            {
                Type type = piProperty.PropertyType;

                // 配列型チェック(Byte[]向け)
                // ※バイト配列型は印字不可能な文字になるかもしれないので削除
                if (type.IsArray)
                {
                    throw new Exception("配列はフィールドに設定できません");
                }
                // バイト型(Byte/SByte)チェック
                // ※バイト型は印字不可能な文字になるかもしれないので削除
                if (type == typeof(Byte) || type == typeof(SByte))
                {
                    throw new Exception("バイト型はフィールドに設定できません");
                }
            }

            //-----------------------------------------------------------------------------------------
            // フィールド囲み文字
            //-----------------------------------------------------------------------------------------
            // 「全フィールドを囲む」の場合
            if (opt.EnFieldEnclosed == EnumFieldEnclosed.AllField)
            {
                sFieldEnclosed = "\"";
            }
            // 「フィールドを囲まない」
            // 「文字列フィールドだけ囲む」
            // 「特殊文字列を含む文字列フィールドだけ囲む」の場合
            else
            {
                sFieldEnclosed = "";
            }
            //-----------------------------------------------------------------------------------------
            // ヘッダ行作成
            //-----------------------------------------------------------------------------------------
            if (opt.IsOutputHeader)
            {
                // 列名作成
                foreach (PropertyInfo piProperty in piProperties)
                {
                    sbContents.Append(piProperty.Name);
                    sbContents.Append(opt.Separator);
                }
                // 最後のフィールド区切りを削除
                if (sbContents.Length > 0)
                {
                    sbContents.Remove(sbContents.Length - opt.Separator.Length, opt.Separator.Length);
                }
                // 行区切り挿入
                sbContents.Append(opt.LineBreak);
            }


            //-----------------------------------------------------------------------------------------
            // コンテンツ行作成
            //-----------------------------------------------------------------------------------------
            foreach (T tCurObj in lst)
            {
                foreach (PropertyInfo piProperty in piProperties)
                {
                    // フィールドデータ取得
                    object objField = piProperty.GetValue(tCurObj, null);
                    //	System::Reflection::PropertyAttributes Myattributes = piProperty->Attributes;

                    if (objField == null)
                    {
                        continue;
                    }

                    // NULLの場合
                    if (DBNull.Value.Equals(objField) == true)
                    {
                        sbContents.Append(opt.Separator);
                    }
                    // 文字(String/Char)の場合
                    //else if(objField->GetType() == String::typeid || objField->GetType() == Char::typeid)
                    else if (piProperty.PropertyType == typeof(string) || piProperty.PropertyType == typeof(char))
                    {
                        string sField = objField.ToString();
                        switch (opt.EnFieldEnclosed)
                        {
                            //「フィールドを囲まない」
                            case EnumFieldEnclosed.None:
                                sbContents.Append(sField);
                                break;
                            //「全フィールドを囲む」の場合
                            case EnumFieldEnclosed.AllField:
                                sField = sField.Replace("\"", "\"\"");
                                sbContents.AppendFormat("\"{0}\"", sField);
                                break;
                            //「文字列フィールドだけ囲む」の場合
                            case EnumFieldEnclosed.StringField:
                                sField = sField.Replace("\"", "\"\"");
                                sbContents.AppendFormat("\"{0}\"", sField);
                                break;
                            //「特殊文字列を含む文字列フィールドだけ囲む」の場合
                            case EnumFieldEnclosed.ContainingSpecialCharactersField:
                                sField = sField.Replace("\"", "\"\"");
                                if (sField.IndexOf(opt.Separator) != -1)
                                {
                                    sbContents.AppendFormat("\"{0}\"", sField);
                                }
                                else if (sField.IndexOf(opt.LineBreak) != -1)
                                {
                                    sbContents.AppendFormat("\"{0}\"", sField);
                                }
                                else if (sField.IndexOf("\"") != -1)
                                {
                                    sbContents.AppendFormat("\"{0}\"", sField);
                                }
                                else
                                {
                                    sbContents.AppendFormat("{0}", sField);
                                }
                                break;
                        }
                        sbContents.Append(opt.Separator);
                    }
                    // 真偽型(Boolean)の場合
                    //else if(objField->GetType() == Boolean::typeid)
                    else if (piProperty.PropertyType == typeof(Boolean))
                    {
                        string sValue;
                        // True/Falseで出力
                        if (opt.IsBooleanTypeFormat)
                        {
                            sValue = ((bool)objField).ToString();
                        }
                        // 1/0で出力
                        else
                        {
                            sValue = ((bool)objField) ? "1" : "0";
                        }
                        sbContents.AppendFormat("{1}{0}{1}", sValue, sFieldEnclosed);
                        sbContents.Append(opt.Separator);
                    }
                    // 日時(DateTime)
                    //else if(objField->GetType() == DateTime::typeid)
                    else if (piProperty.PropertyType == typeof(DateTime))
                    {
                        string sFormat = "{1}{0:" + opt.DateTimeTypeFormat + "}{1}";
                        sbContents.AppendFormat(sFormat, objField, sFieldEnclosed);
                        sbContents.Append(opt.Separator);
                    }
                    // 数値型(Decimal/Double/Int16/Int32/Int64/Single/UInt16/UInt32/UInt64)
                    // 日時(TimeSpan)
                    else
                    {
                        sbContents.AppendFormat("{1}{0}{1}", objField, sFieldEnclosed);
                        sbContents.Append(opt.Separator);
                    }
                }

                // 最後のフィールド区切りを削除
                sbContents.Remove(sbContents.Length - opt.Separator.Length, opt.Separator.Length);
                // 行区切り挿入
                sbContents.Append(opt.LineBreak);

            }

            // 最終レコードの行区切り文字を削除
            if (!opt.IsLastRecordLineBreak && sbContents.Length > 0)
            {
                sbContents.Remove(sbContents.Length - opt.LineBreak.Length, opt.LineBreak.Length);
            }
            //-----------------------------------------------------------------------------------------
            // ファイル書込
            //-----------------------------------------------------------------------------------------
            StreamWriter sw = new StreamWriter(sDustFilePath, false, opt.Enc);
            try
            {
                sw.Write(sbContents.ToString());
                
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }

        }
    }
}
