
using MySql.Data.MySqlClient;
using System;
namespace YMK.FrameWork.Tables
{
	public class tbl_word
	{
		
		private String[] _primarykey = {"word_id"};
		
		public String[] Primarykey
		{
			get
			{
				return _primarykey;
			}
		}
		
		
		public class ColumnNames
		{
			//単語ＩＤ
			public const string word_id = "word_id";

			//単語
			public const string word_name = "word_name";

			//中国語の意味
			public const string word_china_meaning = "word_china_meaning";

			//カタカタ
			public const string word_kana = "word_kana";

			//単語の種類
			public const string word_kind_id = "word_kind_id";

			//コメント
			public const string word_remarks = "word_remarks";

			//削除ﾌﾗｸﾞ
			public const string word_del_flg = "word_del_flg";

			//更新ユーザ
			public const string upd_user_id = "upd_user_id";

			//更新日時
			public const string upd_time = "upd_time";
		}
		
		public class ColumnLengths
		{
			//単語ＩＤ
			public const int word_id = 10;

			//単語
			public const int word_name = 20;

			//中国語の意味
			public const int word_china_meaning = 60;

			//カタカタ
			public const int word_kana = 60;

			//単語の種類
			public const int word_kind_id = 2;

			//コメント
			public const int word_remarks = 255;

			//削除ﾌﾗｸﾞ
			public const int word_del_flg = 1;

			//更新ユーザ
			public const int upd_user_id = 20;

			//更新日時
			public const int upd_time = 0;
		}
		
		public class Parameters
		{
			
			public static MySqlParameter WordId
			{
				get
				{
					return new MySqlParameter("?p_word_id", MySqlDbType.VarChar, 10);
				}
			}
			
			public static MySqlParameter WordName
			{
				get
				{
					return new MySqlParameter("?p_word_name", MySqlDbType.VarChar, 20);
				}
			}
			
			public static MySqlParameter WordChinaMeaning
			{
				get
				{
					return new MySqlParameter("?p_word_china_meaning", MySqlDbType.VarChar, 60);
				}
			}
			
			public static MySqlParameter WordKana
			{
				get
				{
					return new MySqlParameter("?p_word_kana", MySqlDbType.VarChar, 60);
				}
			}
			
			public static MySqlParameter WordKindId
			{
				get
				{
					return new MySqlParameter("?p_word_kind_id", MySqlDbType.VarChar, 2);
				}
			}
			
			public static MySqlParameter WordRemarks
			{
				get
				{
					return new MySqlParameter("?p_word_remarks", MySqlDbType.VarChar, 255);
				}
			}
			
			public static MySqlParameter WordDelFlg
			{
				get
				{
					return new MySqlParameter("?p_word_del_flg", MySqlDbType.VarChar, 1);
				}
			}
			
			public static MySqlParameter UpdUserId
			{
				get
				{
					return new MySqlParameter("?p_upd_user_id", MySqlDbType.VarChar, 20);
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
