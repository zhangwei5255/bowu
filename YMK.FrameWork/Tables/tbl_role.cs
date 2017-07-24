
using MySql.Data.MySqlClient;
using System;
namespace YMK.FrameWork.Tables
{
	public class tbl_role
	{
		
		private String[] _primarykey = {"role_id"};
		
		public String[] Primarykey
		{
			get
			{
				return _primarykey;
			}
		}
		
		
		public class ColumnNames
		{
			//権限ＩＤ
			public const string role_id = "role_id";

			//権限名称
			public const string role_name = "role_name";
		}
		
		public class ColumnLengths
		{
			//権限ＩＤ
			public const int role_id = 2;

			//権限名称
			public const int role_name = 20;
		}
		
		public class Parameters
		{
			
			public static MySqlParameter RoleId
			{
				get
				{
					return new MySqlParameter("?p_role_id", MySqlDbType.VarChar, 2);
				}
			}
			
			public static MySqlParameter RoleName
			{
				get
				{
					return new MySqlParameter("?p_role_name", MySqlDbType.VarChar, 20);
				}
			}
			
		}
	}
}
