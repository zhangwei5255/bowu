using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ServiceModel;
using System.Runtime.Serialization;
using YMK.Commons.Messages;

//******************************************************************************
//  クラス名 ：BaseFormBean
//  作成者　 ：張威
//  作成日　 ：2007-04-05
//  処理内容 ：全FormBean親クラスです
//  更新履歴 ：
//******************************************************************************

namespace YMK.FrameWork.FormBean
{
    [ServiceContract]
    [DataContract]
    public abstract class BaseFormBean
    {
        private string _LoginUserID;               //ログインユーザID
        private string _screenID;                  //画面ID
        private Hashtable _hterrMessage;           //全てエラーメッセージ
        private string _errMessage;                //カレントのエラーメッセージ
        private string _reCode;         //リターンコード

        /// <summary>
        /// 構造関数
        /// </summary>
        public BaseFormBean()
        {
            _hterrMessage = new Hashtable();
        }

        /// <summary>
        /// FormBean初期化処理
        /// </summary>
        public abstract void InitAll();

        /// <summary>
        /// ログインユーザID
        /// </summary>
         [DataMember]
        public string LoginUserID
        {
            get
            {
                return _LoginUserID;
            }
            set
            {
                _LoginUserID = value;
            }
        }

        /// <summary>
        /// 画面ID
        /// </summary>
         [DataMember]
        public string ScreenID
        {
            get
            {
                return _screenID;
            }
            set
            {
                _screenID = value;
            }
        }

        /// <summary>
        /// 全てエラーメッセージ
        /// </summary>
         [DataMember]
        public Hashtable HterrMessage
        {
            get
            {
                return _hterrMessage;
            }
            set
            {
                _hterrMessage = value;
            }
        }

        /// <summary>
        /// カレントのエラーメッセージ
        /// </summary>
         [DataMember]
        public string ErrMessage
        {
            get
            {
                return _errMessage;
            }
            set
            {
                _errMessage = value;
            }
        }

        /// <summary>
        /// リターンコード
        /// </summary>
         [DataMember]
         public string ReCode
        {
            get
            {
                return _reCode;
            }
            set
            {
                _reCode = value;
            }
        }

    }
}
