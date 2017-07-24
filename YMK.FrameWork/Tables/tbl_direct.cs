
using MySql.Data.MySqlClient;
using System;
namespace YMK.FrameWork.Tables
{
	public class tbl_direct
	{
		
		private String[] _primarykey = {"book_no", "lesson_no"};
		
		public String[] Primarykey
		{
			get
			{
				return _primarykey;
			}
		}
		
		
		public class ColumnNames
		{
			//本番号
			public const string book_no = "book_no";

			//課番号
			public const string lesson_no = "lesson_no";
		}
		
		public class ColumnLengths
		{
			//本番号
			public const int book_no = 1;

			//課番号
			public const int lesson_no = 2;
		}
		
		public class Parameters
		{
			
			public static MySqlParameter BookNo
			{
				get
				{
					return new MySqlParameter("?p_book_no", MySqlDbType.VarChar, 1);
				}
			}
			
			public static MySqlParameter LessonNo
			{
				get
				{
					return new MySqlParameter("?p_lesson_no", MySqlDbType.VarChar, 2);
				}
			}
			
		}
	}
}
