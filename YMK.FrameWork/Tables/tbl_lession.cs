
using MySql.Data.MySqlClient;
using System;
namespace YMK.FrameWork.Tables
{
	public class tbl_lession
	{
		
		private String[] _primarykey = {"lession_no"};
		
		public String[] Primarykey
		{
			get
			{
				return _primarykey;
			}
		}
		
		
		public class ColumnNames
		{
			//課番号
			public const string lession_no = "lession_no";

			//名称
			public const string lession_Name = "lession_Name";
		}
		
		public class ColumnLengths
		{
			//課番号
			public const int lession_no = 4;

			//名称
			public const int lession_Name = 60;
		}
		
		public class Parameters
		{
			
			public static MySqlParameter LessionNo
			{
				get
				{
					return new MySqlParameter("?p_lession_no", MySqlDbType.VarChar, 4);
				}
			}
			
			public static MySqlParameter LessionName
			{
				get
				{
					return new MySqlParameter("?p_lession_Name", MySqlDbType.VarChar, 60);
				}
			}
			
		}
	}
}
