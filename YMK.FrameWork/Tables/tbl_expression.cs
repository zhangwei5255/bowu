
using MySql.Data.MySqlClient;
using System;
namespace YMK.FrameWork.Tables
{
	public class tbl_expression
	{
		
		private String[] _primarykey = {"exp_id"};
		
		public String[] Primarykey
		{
			get
			{
				return _primarykey;
			}
		}
		
		
		public class ColumnNames
		{
			//文法ＩＤ
			public const string exp_id = "exp_id";

			//文法のテーマ
			public const string exp_topic = "exp_topic";

			//サイズ
			public const string exp_size = "exp_size";

			//例
			public const string exp_example = "exp_example";

			//削除ﾌﾗｸﾞ
			public const string exp_del_flg = "exp_del_flg";

			//ユーザＩＤ
			public const string upd_user_id = "upd_user_id";

			//更新日時
			public const string upd_time = "upd_time";
		}
		
		public class ColumnLengths
		{
			//文法ＩＤ
			public const int exp_id = 10;

			//文法のテーマ
			public const int exp_topic = 60;

			//サイズ
			public const int exp_size = 0;

			//例
			public const int exp_example = 0;

			//削除ﾌﾗｸﾞ
			public const int exp_del_flg = 1;

			//ユーザＩＤ
			public const int upd_user_id = 20;

			//更新日時
			public const int upd_time = 0;
		}
		
		public class Parameters
		{
			
			public static MySqlParameter ExpId
			{
				get
				{
					return new MySqlParameter("?p_exp_id", MySqlDbType.VarChar, 10);
				}
			}
			
			public static MySqlParameter ExpTopic
			{
				get
				{
					return new MySqlParameter("?p_exp_topic", MySqlDbType.VarChar, 60);
				}
			}
			
			public static MySqlParameter ExpSize
			{
				get
				{
					return new MySqlParameter("?p_exp_size", MySqlDbType.Int64);
				}
			}
			
			public static MySqlParameter ExpExample
			{
				get
				{
					return new MySqlParameter("?p_exp_example", MySqlDbType.Blob);
				}
			}
			
			public static MySqlParameter ExpDelFlg
			{
				get
				{
					return new MySqlParameter("?p_exp_del_flg", MySqlDbType.VarChar, 1);
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
