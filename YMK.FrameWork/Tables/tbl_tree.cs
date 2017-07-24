
using MySql.Data.MySqlClient;
using System;
namespace YMK.FrameWork.Tables
{
    public class tbl_tree
    {

        private String[] _primarykey = { "user_id", "book_no" };

        public String[] Primarykey
        {
            get
            {
                return _primarykey;
            }
        }


        public class ColumnNames
        {
            //ユーザＩＤ
            public const string user_id = "user_id";

            //本番号
            public const string book_no = "book_no";

            //課番号
            public const string lession_no = "lession_no";

            //ノード名
            public const string name = "name";

            //アイコン
            public const string ImageIndex = "ImageIndex";

            //チェックﾌﾗｸﾞ
            public const string Checked = "Checked";

            //展開ﾌﾗｸﾞ
            public const string expanded = "expanded";

            //ソート１
            public const string sort_book = "sort_book";

            //ソート２
            public const string sort_les = "sort_les";

            //更新日時
            public const string upd_time = "upd_time";
        }

        public class ColumnLengths
        {
            //ユーザＩＤ
            public const int user_id = 20;

            //本番号
            public const int book_no = 2;

            //課番号
            public const int lession_no = 2;

            //ノード名
            public const int name = 20;

            //アイコン
            public const int ImageIndex = 0;

            //チェックﾌﾗｸﾞ
            public const int Checked = 0;

            //展開ﾌﾗｸﾞ
            public const int expanded = 0;

            //ソート１
            public const int sort_book = 0;

            //ソート２
            public const int sort_les = 0;

            //更新日時
            public const int upd_time = 0;
        }

        public class Parameters
        {

            public static MySqlParameter UserId
            {
                get
                {
                    return new MySqlParameter("?p_user_id", MySqlDbType.VarChar, 20);
                }
            }

            public static MySqlParameter BookNo
            {
                get
                {
                    return new MySqlParameter("?p_book_no", MySqlDbType.VarChar, 2);
                }
            }

            public static MySqlParameter LessionNo
            {
                get
                {
                    return new MySqlParameter("?p_lession_no", MySqlDbType.VarChar, 2);
                }
            }

            public static MySqlParameter Name
            {
                get
                {
                    return new MySqlParameter("?p_name", MySqlDbType.VarChar, 20);
                }
            }

            public static MySqlParameter ImageIndex
            {
                get
                {
                    return new MySqlParameter("?p_ImageIndex", MySqlDbType.Int32);
                }
            }

            public static MySqlParameter Checked
            {
                get
                {
                    return new MySqlParameter("?p_Checked", MySqlDbType.Byte);
                }
            }

            public static MySqlParameter Expanded
            {
                get
                {
                    return new MySqlParameter("?p_expanded", MySqlDbType.Byte);
                }
            }

            public static MySqlParameter SortBook
            {
                get
                {
                    return new MySqlParameter("?p_sort_book", MySqlDbType.Int32);
                }
            }

            public static MySqlParameter SortLes
            {
                get
                {
                    return new MySqlParameter("?p_sort_les", MySqlDbType.Int32);
                }
            }

            public static MySqlParameter UpdTime
            {
                get
                {
                    return new MySqlParameter("?p_upd_time", MySqlDbType.Timestamp);
                }
            }

        }
    }
}

