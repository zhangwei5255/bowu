using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win.YMK.XmlSerialization;
using YMK.Commons.Consts;

namespace YMK.Commons.Messages
{
    //public enum ForwardOption
    //{ 
    //    SUCCESS = 0,        //OK
    //    FAILURE         //システムエラー
    //}

    public class Msg
    {
        //インスタント
        private static Msg _instance;

        //メッセージを格納するためのフィールド
        private IDictionary<string, string> DicMsg;

        private Msg()
        {
            DicMsg = new Dictionary<string, string>();

            //メッセージリストにキーと値を追加する
            AddMsgVal();
        }

        /// <summary>
        /// インスタンス取得
        /// </summary>
        /// <returns>メッセージクラス</returns>
        public static Msg GetInstance()
        {
            //update by I.TYOU 20140722 機能強化「非スレッドセーフのため」 start
            //if (_instance == null)
            //{
            //    _instance = new Msg();
            //}
            lock (typeof(Msg))
            {

                if (_instance == null)
                {
                    _instance = new Msg();
                }
            }
            //update by I.TYOU 20140722 機能強化「非スレッドセーフのため」 end

            return _instance;
        }

        /// <summary>
        /// メッセージ情報の内容を取得する
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns>メッセージ情報の内容</returns>
        public string GetMsg(string key)
        {
            //指定のキーがメッセージリストに存在する場合
            if (Msglist.ContainsKey(key))
            {
                return Msglist[key];
            }
            else
            {
                //return WinKeys.MSG_ERR_SYS;
                return "";
            }
        }

        /// <summary>
        /// Information型メッセージ
        /// </summary>
        /// <param name="message">メッセージ内容</param>
        public void Information(string message)
        {
           // MessageBox.Show(message, WinKeys.MSG_TITILE, MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show(message, "MSG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// エラー型メッセージ
        /// </summary>
        /// <param name="message">メッセージ内容</param>
        public void Error(string message)
        {
            MessageBox.Show(message, WinKeys.MSG_TITILE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Question型メッセージ
        /// </summary>
        /// <returns>true:「YES」を選択した場合、false:「NO」を選択した場合</returns>
        public bool Question(string msg)
        {
            if (MessageBox.Show(msg, WinKeys.MSG_TITILE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// メッセージリストにキーと値を追加する
        /// </summary>
        private void AddMsgVal()
        {
            //update by i.tyou 20131112 start
            /* //ファイルIOエラー
             DicMsg.Add(MsgCd.ER_FILE_IO, WinKeys.MSG_ER001);

             //ディスク空き容量エラー
             DicMsg.Add(MsgCd.ER_DISK_ALMOST_FULL, WinKeys.MSG_ER002);

             //ファイルがreadOnlyです
             DicMsg.Add(MsgCd.ER_FILE_NOT_WRITER, WinKeys.MSG_ER003);

             //DB操作エラー
             DicMsg.Add(MsgCd.ER_DB_OPERATION_FAIL, WinKeys.MSG_DBER0001);

             //更新排他エラ-
             DicMsg.Add(MsgCd.ER_DB_CHECKREAD, WinKeys.MSG_DBER0002);

             //DBディスク空き容量不足
             DicMsg.Add(MsgCd.ER_DB_DISK_FULL, WinKeys.MSG_DBER0003);

             //メモリが溢れる
             DicMsg.Add(MsgCd.ER_DB_OUTOFMEMORY, WinKeys.MSG_DBER0004);

             // 接続が多すぎる
             DicMsg.Add(MsgCd.ER_DB_CON_COUNT_ERROR, WinKeys.MSG_DBER0005);

             //DB操作を行う時、サービスがクローズされる
             DicMsg.Add(MsgCd.ER_DB_SERVER_SHUTDOWN, WinKeys.MSG_DBER0006);

             //主キーが該当テーブルに存在する
             DicMsg.Add(MsgCd.ER_DB_DUP_ENTRY, WinKeys.MSG_DBER0007);

             // テーブルをReadOnlyにロックする
             DicMsg.Add(MsgCd.ER_DB_TABLE_NOT_LOCKED_FOR_WRITE, WinKeys.MSG_DBER0008);

             //テーブルのレコードがいっぱいになる
             DicMsg.Add(MsgCd.ER_DB_RECORD_FULL, WinKeys.MSG_DBER0009);

             //データベースの名称がエラーです。
             DicMsg.Add(MsgCd.ER_DB_NAME_ERROR, WinKeys.MSG_DBER0010);

             // 必須入力項目です。入力して下さい。
             DicMsg.Add(MsgCd.INFOR_NULL, WinKeys.MSG_INFRO_NULL);

             // 登録します。宜しいですか？
             DicMsg.Add(MsgCd.INFOR_CREATE, WinKeys.MSG_INFOR_CREATE);

             //入力中のデータを破棄し、前画面へ戻ります。\nよろしいですか？
             DicMsg.Add(MsgCd.INFOR_RETURN, WinKeys.MSG_INFRO_RETURN);

             //半角片仮名を入力してくだい。
             DicMsg.Add(MsgCd.INFOR_HANKANA, WinKeys.MSG_INFRO_HANKANA);

             //入力のメールアドレスは無効です。
             DicMsg.Add(MsgCd.INFOR_EMAIL, WinKeys.MSG_INFRO_EMAIL);

             //入力の電話番号は無効です。
             DicMsg.Add(MsgCd.INFOR_TELPHONE, WinKeys.MSG_INFOR_TELPHONE);

             //入力のユーザIDが既存にありました。
             DicMsg.Add(MsgCd.INFOR_USER_ID_EXIST, WinKeys.MSG_INFOR_USER_ID_EXIST);

             //入力のユーザIDがそんざいしません。
             DicMsg.Add(MsgCd.INFOR_USER_ID_NOT_EXIST, WinKeys.MSG_INFOR_USER_ID_NOT_EXIST);

             //パスワードがエラーです。
             DicMsg.Add(MsgCd.INFOR_PASSWORD_NOT_EXIST, WinKeys.MSG_INFOR_PASSWORD_NOT_EXIST);

             //更新してしまいました
             DicMsg.Add(MsgCd.INFOR_UPDATE, WinKeys.MSG_INFOR_UPDATE);

             //全角の単語を入力してくだい。
             DicMsg.Add(MsgCd.INFOR_FULL_JPWORD, WinKeys.MSG_INFRO_FULL_JPWORD);

             //初期化パスワードを指定メールに送るのは、失敗ですが、\n メールアドレスとネットワークを確認してください。
             DicMsg.Add(MsgCd.INFOR_SEND_MAIL_FAILURE, WinKeys.MSG_INFOR_SEND_MAIL_FAILURE);

             //メールを開けて、パスワードを取得してください。
             DicMsg.Add(MsgCd.INFOR_SEND_MAIL_SUCCESS, WinKeys.MSG_INFOR_SEND_MAIL_SUCCESS);

             //二つの入力パスワードが一致しません。\nご確認お願いします。
             DicMsg.Add(MsgCd.INFOR_PASSWORD_NOT_SAME, WinKeys.MSG_INFOR_PASSWORD_NOT_SAME);

             //少なくとも一つの更新行をチェックしてください。
             DicMsg.Add(MsgCd.INFOR_LEAST_ONLY_SELECT, WinKeys.MSG_INFRO_LEAST_ONLY_SELECT);

             //add by i.tyou 20130628 start
             //このプロジェクトが既に起動されています。
             DicMsg.Add(MsgCd.INFOR_MSG_PJ_RUN, WinKeys.MSG_PJ_RUN);

             //タスク名が既に存在します。
             DicMsg.Add(MsgCd.INFOR_MSG_PJ_TASK_TYOUFUKU, WinKeys.MSG_PJ_TASK_TYOUFUKU);
             //add by i.tyou 20130628 end*/

            // XmlSerializer ser = new XmlSerializer(typeof(List<DREAM_FW.Win.Common.XML.XmlSettings.MsgInfo>));

            MsgBean msgBean = XmlSerializer<MsgBean>.DeserializeFromFile(ConfigurationManager.AppSettings["MsgXmlFile"]);

            foreach (MsgInfo msgInfo in msgBean.msgInfos.Items)
            {
                DicMsg.Add(msgInfo.ID, msgInfo.Value);
            }

            //update by i.tyou 20131112 end
        }

        /// <summary>
        /// メッセージ情報を取得する
        /// </summary>
        private IDictionary<string, string> Msglist
        {
            get
            {
                return DicMsg;
            }
        }
    }
}
