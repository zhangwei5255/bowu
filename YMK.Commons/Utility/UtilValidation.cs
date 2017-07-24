using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

//******************************************************************************
//  クラス名 ：ValidationUtil
//  作成者　 ：張威
//  作成日　 ：2007-04-07
//  処理内容 ：文字列を有効にチェック
//  更新履歴 ：
//******************************************************************************

namespace YMK.Commons.Utility
{
    public  class ValidationUtil
    {
        //delete by I.TYOU 20141117 以下のメソッドの代わりに、String.IsNullOrEmptyを使う start
        ///// <summary>
        ///// 受け取った文字列が空白かNullだった場合true、それ以外だった場合はfalseを返す
        ///// </summary>
        ///// <param name="str">チェックする文字列</param>
        ///// <returns>空白かNull:true それ以外:false</returns>
        //public static bool IsCheckNull(object str)
        //{
        //    if (str == null) return true;
        //    string strVal = str.ToString().Trim();
        //    return (strVal == "");
        //}
        //delete by I.TYOU 20141117 以下のメソッドの代わりに、String.IsNullOrEmptyを使う end

        /// <summary>
        /// 文字列の半角仮名チェックを行う。
        /// </summary>
        /// <param name="strVal">チェックする文字列</param>
        /// <returns>ture：半角片仮名　false：半角片仮名以外</returns>
        public static bool IsHankana(string strVal)
        {
            bool blHankana;

            // 半角片仮名
            Regex regex = new Regex(@"^[ｱ-ﾝｦﾞﾟ｡｢｣､･ｧ-ｫｬｭｮｯｰ]*$");
            blHankana = regex.IsMatch(strVal);

            return blHankana;
        }

        ///// <summary>
        ///// 文字列の全角仮名チェックを行う。
        ///// </summary>
        ///// <param name="strVal">チェックする文字列</param>
        ///// <returns>ture：全角片仮名　false：全角片仮名以外</returns>
        //public static bool IsZenKana(string strVal)
        //{
        //    //bool blKana;

        //    strVal = StringConvert(strVal, "N");

        //    //if (IsCheckNull(strVal) == false)
        //    //{
        //    //    // 全角片仮名アケ
        //    //    Regex regex = new Regex(@"「^[ァ-ヶ]+$");
        //    //    blKana = regex.IsMatch(strVal);
        //    //}
        //    //else
        //    //{
        //    //    blKana = true;
        //    //}

        //    return IsHankana(strVal);
        //}

        /// <summary>
        /// 文字列のメールチェックを行う。
        /// </summary>
        /// <param name="strVal">チェックする文字列</param>
        /// <returns>メールかどうか</returns>
        public static bool IsEmail(string strVal)
        {
            bool blEmail;

            // 半角片仮名
            Regex regex = new Regex(@"^[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\.[A-Za-z]{2,4}$");
            blEmail = regex.IsMatch(strVal);

            return blEmail;
        }

        /// <summary>
        /// 文字列の電話番号チェックを行う
        /// </summary>
        /// <param name="strVal">チェックする文字列</param>
        /// <returns>電話番号かどうか</returns>
        public static bool IsTelPhone(string strVal)
        {
            bool blTelPhone;

            //if (IsCheckNull(strVal) == true)
            if (String.IsNullOrEmpty(strVal) == true)
            {
                return true;
            }

            string strRegex1 = @"^\d{3}-\d{8}$";
            string strRegx2 = @"^\d{4}-\d{7}$";

            //半角片仮名
            Regex regex = new Regex(strRegex1);

            if ((blTelPhone = regex.IsMatch(strVal)) == false)
            {
                regex = new Regex(strRegx2);
                blTelPhone = regex.IsMatch(strVal);
            }

            return blTelPhone;
        }

        /// <summary>
        /// 文字列が日本語の単語チェックを行う
        /// </summary>
        /// <param name="strVal">チェックする文字列</param>
        /// <returns>日本語の単語かどうか</returns>
        public static bool IsJPWord(string strVal)
        {
            bool blJPWord;

            // 正規表現　全角カナ　漢字 
            Regex regex = new Regex(@"^[ァ-ヶ亜-黑]+$"); 
            blJPWord = regex.IsMatch(strVal);

            return blJPWord;
        }

        /// <summary>
        /// 引数で文字列変換することを行う
        /// </summary>
        /// <param name="strString">変換前の文字列</param>
        /// <param name="type">事務のtype   "K" '平仮名文字列→片仮名変換を行う
        ///　　　　　　　　                 "H" '片仮名文字列→平仮名変換を行う
        ///　　　　　　　　                 "W" '半角キャラクタ→全角キャラクタ変換を行う
        ///　　　　　　　　                 "N" '全角キャラクタ→半角キャラクタ変換を行う
        ///　　　　　　　　                 "KW" '半角片仮名文字列→全角片仮名変換を行う
        ///　　　　　　　　                 "KN" '全角片仮名文字列→半角片仮名変換を行う
        ///　　　　　　　　                 "HW" '半角平仮名文字列→全角平仮名変換を行う
        ///　　　　　　　　                 "HN" '全角平仮名文字列→半角平仮名変換を行う</param>
        /// 
        /// <returns>変換後の文字列</returns>
        //private static string StringConvert(string strString, string type)
        //{

        //    string strResult = "";
        //    if ((strString != null))
        //    {
        //        switch (type)
        //        {
        //            case "K":
        //                //文字列→片仮名変換を行う
        //                strResult = Strings.StrConv(strString, VbStrConv.Katakana , 111);
        //                break;
        //            case "H":
        //                //文字列→平仮名変換を行う
        //                strResult = Strings.StrConv(strString, VbStrConv.Hiragana , 111);
        //                break;
        //            case "W":
        //                //半角キャラクタ→全角キャラクタ変換を行う
        //                strResult = Strings.StrConv(strString, VbStrConv.Wide , 111);
        //                break;
        //            case "N":
        //                //全角キャラクタ→半角キャラクタ変換を行う
        //                strResult = Strings.StrConv(strString, VbStrConv.Narrow, 0);
        //                break;
        //            case "KW":
        //                //文字列→全角片仮名変換を行う
        //                strResult = Strings.StrConv(strString, VbStrConv.Katakana , 111);
        //                strResult = Strings.StrConv(strResult, VbStrConv.Wide, 111);
        //                break;

        //            case "KN":
        //                //文字列→半角片仮名変換を行う
        //                strResult = Strings.StrConv(strString, VbStrConv.Katakana , 111);
        //                strResult = Strings.StrConv(strString, VbStrConv.Narrow, 111);
        //                break;

        //            case "HW":
        //                //文字列→全角平仮名変換を行う
        //                strResult = Strings.StrConv(strString, VbStrConv.Hiragana , 111);
        //                strResult = Strings.StrConv(strResult, VbStrConv.Wide, 111);
        //                break;
        //            case "HN":
        //                //文字列→半角平仮名変換を行う
        //                strResult = Strings.StrConv(strString, VbStrConv.Hiragana  , 111);
        //                strResult = Strings.StrConv(strResult, VbStrConv.Narrow, 111);
        //                break;

        //        }
        //    }
        //    return strResult;
        //}


    }
}

