
using MySql.Data.MySqlClient;
using System;
namespace YMK.FrameWork.Tables
{
	public class tbl_audio_file
	{
		
		private String[] _primarykey = {"audio_file_no"};
		
		public String[] Primarykey
		{
			get
			{
				return _primarykey;
			}
		}
		
		
		public class ColumnNames
		{
			//音声ファイル番号
			public const string audio_file_no = "audio_file_no";

			//ファイルパス
			public const string audio_file_url = "audio_file_url";

			//更新ユーザＩＤ
			public const string upd_user_id = "upd_user_id";

			//更新日時
			public const string upd_time = "upd_time";
		}
		
		public class ColumnLengths
		{
			//音声ファイル番号
			public const int audio_file_no = 5;

			//ファイルパス
			public const int audio_file_url = 100;

			//更新ユーザＩＤ
			public const int upd_user_id = 20;

			//更新日時
			public const int upd_time = 0;
		}
		
		public class Parameters
		{
			
			public static MySqlParameter AudioFileNo
			{
				get
				{
					return new MySqlParameter("?p_audio_file_no", MySqlDbType.VarChar, 5);
				}
			}
			
			public static MySqlParameter AudioFileUrl
			{
				get
				{
					return new MySqlParameter("?p_audio_file_url", MySqlDbType.VarChar, 100);
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
