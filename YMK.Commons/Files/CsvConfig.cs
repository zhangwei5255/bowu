using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YMK.Commons.Files
{
    /// <summary>
    /// フィールド囲み
    /// </summary>
    public enum EnumFieldEnclosed
    {
        None,                               // フィールドを囲まない
        AllField,                           // 全フィールドを囲む
        StringField,                        // 文字列フィールドだけ囲む
        ContainingSpecialCharactersField    // 特殊文字列を含む文字列フィールドだけ囲む
    }

    public class CsvConfig
    {

        private Encoding _enc;                       //文字コード
        private string _separator;                   //フィールド区切り文字
        private string _lineBreak;                   //行区切り文字
        private EnumFieldEnclosed _enFieldEnclosed;  //フィールド囲み
        private bool _isOutputHeader;                //ヘッダ行の出力有無
        private bool _isLastRecordLineBreak;         //最終レコードに行区切り文字挿入
        private bool _isBooleanTypeFormat;           //Boolean型の出力書式(trueでTrue/False、falseで'1'/'0'と出力)
        private string _dateTimeTypeFormat;          //DateTime型の出力書式

        public CsvConfig()
        {
            //enc = Encoding::GetEncoding("Shift-JIS");
			//update by I.TYOU 20131219 start ＢＯＭ付きのＵＴＦ8ファイルから読み込み時、文字化けになるため
			//enc =Encoding::UTF8;
            _enc = new UTF8Encoding(false);
			//update by I.TYOU 20131219 END ＢＯＭ付きのＵＴＦ8ファイルから読み込み時、文字化けになるため
            _separator = ",";
            _lineBreak = "\r\n";
            _enFieldEnclosed = EnumFieldEnclosed.ContainingSpecialCharactersField;
            _isOutputHeader = true;
            _isLastRecordLineBreak = true;
            _isBooleanTypeFormat = true;
            _dateTimeTypeFormat = "yyyy/MM/dd HH:mm:ss";
        }

        /// <summary>
        /// 文字コード
        /// </summary>
        public Encoding Enc
        {
            get
            {
                return _enc;
            }
            set
            {
                _enc = value;
            }
        }

        /// <summary>
        /// フィールド区切り文字
        /// </summary>
        public string Separator
        {
            get
            {
                return _separator;
            }
            set
            {
                _separator = value;
            }
        }

        /// <summary>
        /// 行区切り文字
        /// </summary>
        public string LineBreak
        {
            get
            {
                return _lineBreak;
            }
            set
            {
                _lineBreak = value;
            }
        }

        /// <summary>
        /// フィールド囲み
        /// </summary>
        public EnumFieldEnclosed EnFieldEnclosed
        {
            get
            {
                return _enFieldEnclosed;
            }
            set
            {
                _enFieldEnclosed = value;
            }
        }

        /// <summary>
        /// ヘッダ行の出力有無
        /// </summary>
        public bool IsOutputHeader
        {
            get
            {
                return _isOutputHeader;
            }
            set
            {
                _isOutputHeader = value;
            }
        }

        /// <summary>
        /// 最終レコードに行区切り文字挿入
        /// </summary>
        public bool IsLastRecordLineBreak
        {
            get
            {
                return _isLastRecordLineBreak;
            }
            set
            {
                _isLastRecordLineBreak = value;
            }
        }

        /// <summary>
        /// Boolean型の出力書式(trueでTrue/False、falseで'1'/'0'と出力)
        /// </summary>
        public bool IsBooleanTypeFormat
        {
            get
            {
                return _isBooleanTypeFormat;
            }
            set
            {
                _isBooleanTypeFormat = value;
            }
        }

        /// <summary>
        /// DateTime型の出力書式
        /// </summary>
        public string DateTimeTypeFormat
        {
            get
            {
                return _dateTimeTypeFormat;
            }
            set
            {
                _dateTimeTypeFormat = value;
            }
        }

    }
}
