using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YMK.Commons.Consts
{
    public class WinKeys
    {
        /// <summary>
        /// 登録キー
        /// </summary>
        public static string ROOT_REGISTER_KEY = "Dream\\Software\\" + Application.CompanyName + "\\" +
            Application.ProductName + "\\" + Application.ProductVersion;

        /// <summary>
        /// パスワード
        /// </summary>
        public const string USER_PASSWORD = "userPassword";
        /// <summary>
        /// ログ出力のフォルダ
        /// </summary>
        public const string FOLDER_LOG = @"\Log";

        /// <summary>
        /// ログ出力のファイル名
        /// </summary>
        public const string LOG_FILE_NAME = @"\DreamLog.log";

        /// <summary>
        /// 記号「\r\n」
        /// </summary>
        public const string Mark_RN = @"\r\n";

        /// <summary>
        /// データ管理プロセスのため、主プロセス「JPBOOK」の状態が結合です。
        /// </summary>
        public const string THREAD_WAITE_FOR_DATAMGN = @"THREAD_WAITE_FOR_DATAMGN";

        /// <summary>
        /// メッセージのタイトル
        /// </summary>
        public const string MSG_TITILE = "JPBook     　標準日本語";

        ///// <summary>
        ///// 標日初級(上)
        ///// </summary>
        //public const String BOOK_1 = "標日初級(上)";

        ///// <summary>
        ///// 標日初級(下)
        ///// </summary>
        //public const String BOOK_2 = "標日初級(下)";

        ///// <summary>
        ///// 標日中級(上)
        ///// </summary>
        //public const String BOOK_3 = "標日中級(上)";

        ///// <summary>
        ///// 標日中級(下)
        ///// </summary>
        //public const String BOOK_4 = "標日中級(下)";

        ///// <summary>
        ///// 標日高級(上)
        ///// </summary>
        //public const String BOOK_5 = "標日高級(上)";

        ///// <summary>
        ///// 標日高級(上)
        ///// </summary>
        //public const String BOOK_6 = "標日高級(下)";

        /// <summary>
        /// 形式（9-99）「book_no」-「lesson_no」
        /// </summary>
        public const int LESSION_ID_LEN = 4;

        /// <summary>
        /// 三角形
        /// </summary>
        public const string TRIANGLE = "TRIANGLE";

        /// <summary>
        /// 保存
        /// </summary>
        public const string SAVE = "SAVE";

        /// <summary>
        /// 印刷
        /// </summary>
        public const string PRINT = "PRINT";

        //add by I.TYOU 20140519 start
        /// <summary>
        /// 展開
        /// </summary>
        public const string EXPAND = "EXPAND";
        //add by I.TYOU 20140519 end

        /// <summary>
        /// プレビュー
        /// </summary>
        public const string PREVIEW = "PREVIEW";

        /// <summary>
        /// 検索
        /// </summary>
        public const string FIND = "FIND";
        /// <summary>
        /// CSV
        /// </summary>
        public const string CSV = "CSV";

        /// <summary>
        ///DB操作成功 
        /// </summary>
        public const string SUCCESS = "SUCCESS";

        /// <summary>
        ///DB操作失敗 
        /// </summary>
        public const string FAILURE = "FAILURE";

        public const string REPO_DOCUMENT = "PRINT_DOCUMENT";
    }
}
