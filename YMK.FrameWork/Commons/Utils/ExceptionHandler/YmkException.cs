using System;
using System.Collections.Generic;
using System.Text;

//******************************************************************************
//  クラス名 ：DMFWException
//  作成者　 ：張威
//  作成日　 ：2007-04-05
//  処理内容 ：システム例外クラス
//  更新履歴 ：
//******************************************************************************

namespace YMK.FrameWork.Commons.Utils.ExceptionHandler
{
    public　class YmkException : ApplicationException 
    {
        private String _message;                // メッセージ
        private Exception _ex;                  //エラー

        /// <summary>
        /// 構造関数
        /// </summary>
        public YmkException()
        {
            //変数初期化
            _ex = new Exception();
        }

        /// <summary>
        /// 構造関数（引数：メッセージ）
        /// </summary>
        /// <param name="message">メッセージ</param>
        public YmkException(string message)
        {
            //変数初期化
            _message = message;
            _ex = new Exception(message);
        }

        /// <summary>
        /// 構造関数（引数：エラー）
        /// </summary>
        /// <param name="ex"></param>
        public YmkException(Exception ex)
        {
            //変数初期化
            _ex = ex;
        }

        public YmkException(string message, Exception ex)
        {
            //変数初期化
            _message = message;
            _ex = ex;
        }

        /// <summary>
        ///  メッセージ
        /// </summary>
        public String Msg
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }

        /// <summary>
        /// エラー
        /// </summary>
        public Exception Expton
        {
            get
            {
                return _ex;
            }
            set
            {
                _ex = value;
            }
        }

    }
}

