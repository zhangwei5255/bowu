
using MySql.Data.MySqlClient;
using System;
namespace YMK.FrameWork.Tables
{
	public class tbl_user
	{
		
		private String[] _primarykey = {"user_id"};
		
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

			//権限ＩＤ
			public const string role_id = "role_id";

			//パスワード
			public const string pswd = "pswd";

			//ユーザ名称
			public const string user_name = "user_name";

			//カタカタ
			public const string katakana = "katakana";

			//メールアドレス
			public const string email = "email";

			//電話番号
			public const string tel_phone = "tel_phone";

			//生年月日
			public const string birthDay = "birthDay";

			//性別
			public const string sex = "sex";

			//住所
			public const string addresse = "addresse";

			//郵便番号
			public const string post_no = "post_no";

			//登録日時
			public const string reg_time = "reg_time";

			//更新日時
			public const string last_upd_time = "last_upd_time";
		}
		
		public class ColumnLengths
		{
			//ユーザＩＤ
			public const int user_id = 20;

			//権限ＩＤ

			public const int role_id = 2;

			//パスワード
			public const int pswd = 20;

			//ユーザ名称
			public const int user_name = 20;

			//カタカタ
			public const int katakana = 40;

			//メールアドレス
			public const int email = 40;

			//電話番号
			public const int tel_phone = 12;

			//生年月日
			public const int birthDay = 0;

			//性別
			public const int sex = 1;

			//住所
			public const int addresse = 70;

			//郵便番号
			public const int post_no = 6;

			//登録日時
			public const int reg_time = 0;

			//更新日時
			public const int last_upd_time = 0;
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
			
			public static MySqlParameter RoleId
			{
				get
				{
					return new MySqlParameter("?p_role_id", MySqlDbType.VarChar, 2);
				}
			}
			
			public static MySqlParameter Pswd
			{
				get
				{
					return new MySqlParameter("?p_pswd", MySqlDbType.VarChar, 20);
				}
			}
			
			public static MySqlParameter UserName
			{
				get
				{
					return new MySqlParameter("?p_user_name", MySqlDbType.VarChar, 20);
				}
			}
			
			public static MySqlParameter Katakana
			{
				get
				{
					return new MySqlParameter("?p_katakana", MySqlDbType.VarChar, 40);
				}
			}
			
			public static MySqlParameter Email
			{
				get
				{
					return new MySqlParameter("?p_email", MySqlDbType.VarChar, 40);
				}
			}
			
			public static MySqlParameter TelPhone
			{
				get
				{
					return new MySqlParameter("?p_tel_phone", MySqlDbType.VarChar, 12);
				}
			}
			
			public static MySqlParameter BirthDay
			{
				get
				{
					return new MySqlParameter("?p_birthDay", MySqlDbType.Date);
				}
			}
			
			public static MySqlParameter Sex
			{
				get
				{
					return new MySqlParameter("?p_sex", MySqlDbType.VarChar, 1);
				}
			}
			
			public static MySqlParameter Addresse
			{
				get
				{
					return new MySqlParameter("?p_addresse", MySqlDbType.VarChar, 70);
				}
			}
			
			public static MySqlParameter PostNo
			{
				get
				{
					return new MySqlParameter("?p_post_no", MySqlDbType.VarChar, 6);
				}
			}
			
			public static MySqlParameter RegTime
			{
				get
				{
					return new MySqlParameter("?p_reg_time", MySqlDbType.Timestamp);
				}
			}
			
			public static MySqlParameter LastUpdTime
			{
				get
				{
					return new MySqlParameter("?p_last_upd_time", MySqlDbType.Timestamp);
				}
			}
			
		}
	}
}
