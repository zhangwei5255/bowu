
using MySql.Data.MySqlClient;
namespace YMK.FrameWork.Tables
{
	public class tbl_book
	{
		
		
		public class ColumnNames
		{
			//本番号
			public const string book_no = "book_no";

			//本名称
			public const string book_Name = "book_Name";
		}
		
		public class ColumnLengths
		{
			//本番号
			public const int book_no = 1;

			//本名称
			public const int book_Name = 30;
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
			
			public static MySqlParameter BookName
			{
				get
				{
					return new MySqlParameter("?p_book_Name", MySqlDbType.VarChar, 30);
				}
			}
			
		}
	}
}
