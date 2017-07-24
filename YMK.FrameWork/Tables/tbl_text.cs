
using MySql.Data.MySqlClient;
using System;
namespace YMK.FrameWork.Tables
{
	public class tbl_text
	{
		
		private String[] _primarykey = {"text_id"};
		
		public String[] Primarykey
		{
			get
			{
				return _primarykey;
			}
		}
		
		
		public class ColumnNames
		{
			//文章ID
			public const string text_id = "text_id";

			//文章名称
			public const string text_name = "text_name";

			//サイズ
			public const string text_size = "text_size";

			//内容
			public const string text_data = "text_data";

			//更新ユーザＩＤ
			public const string upd_user_id = "upd_user_id";

			//更新日時
			public const string upd_time = "upd_time";
		}
		
		public class ColumnLengths
		{
			//文章ID
			public const int text_id = 5;

			//文章名称
			public const int text_name = 20;

			//サイズ
			public const int text_size = 0;

			//内容
			public const int text_data = 0;

			//更新ユーザＩＤ
			public const int upd_user_id = 20;

			//更新日時
			public const int upd_time = 0;
		}
		
		public class Parameters
		{
			
			public static MySqlParameter TextId
			{
				get
				{
					return new MySqlParameter("?p_text_id", MySqlDbType.VarChar, 5);
				}
			}
			
			public static MySqlParameter TextName
			{
				get
				{
					return new MySqlParameter("?p_text_name", MySqlDbType.VarChar, 20);
				}
			}
			
			public static MySqlParameter TextSize
			{
				get
				{
					return new MySqlParameter("?p_text_size", MySqlDbType.Int64);
				}
			}
			
			public static MySqlParameter TextData
			{
				get
				{
					return new MySqlParameter("?p_text_data", MySqlDbType.Blob);
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
