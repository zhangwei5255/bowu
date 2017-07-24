
using MySql.Data.MySqlClient;
using System;
namespace YMK.FrameWork.Tables
{
	public class tbl_word_kind
	{
		
		private String[] _primarykey = {"word_kind_id"};
		
		public String[] Primarykey
		{
			get
			{
				return _primarykey;
			}
		}
		
		
		public class ColumnNames
		{
			//単語種類ＩＤ
			public const string word_kind_id = "word_kind_id";

			//単語種類名
			public const string word_kind_name = "word_kind_name";
		}
		
		public class ColumnLengths
		{
			//単語種類ＩＤ
			public const int word_kind_id = 2;

			//単語種類名
			public const int word_kind_name = 20;
		}
		
		public class Parameters
		{
			
			public static MySqlParameter WordKindId
			{
				get
				{
					return new MySqlParameter("?p_word_kind_id", MySqlDbType.VarChar, 2);
				}
			}
			
			public static MySqlParameter WordKindName
			{
				get
				{
					return new MySqlParameter("?p_word_kind_name", MySqlDbType.VarChar, 20);
				}
			}
			
		}
	}
}
