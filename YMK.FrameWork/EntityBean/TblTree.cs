
using System;
namespace YMK.FrameWork.EntityBean
{
	public class TblTree  : BaseEntity
	{
		
		//ユーザＩＤ
		private string _userId;
		
		//本番号
		private string _bookNo;
		
		//課番号
		private string _lessionNo;
		
		//ノード名
		private string _name;
		
		//アイコン
		private int? _ImageIndex;
		
		//チェックﾌﾗｸﾞ
		private sbyte? _Checked;
		
		//展開ﾌﾗｸﾞ
		private sbyte? _expanded;
		
		//ソート１
		private int? _sortBook;
		
		//ソート２
		private int? _sortLes;
		
		//更新日時
		private DateTime _updTime;
		
		
		
		public string UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId = value;
			}
			
		}
		
		public string BookNo
		{
			get
			{
				return _bookNo;
			}
			set
			{
				_bookNo = value;
			}
			
		}
		
		public string LessionNo
		{
			get
			{
				return _lessionNo;
			}
			set
			{
				_lessionNo = value;
			}
			
		}
		
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
			
		}
		
		public int? ImageIndex
		{
			get
			{
				return _ImageIndex;
			}
			set
			{
				_ImageIndex = value;
			}
			
		}
		
		public sbyte? Checked
		{
			get
			{
				return _Checked;
			}
			set
			{
				_Checked = value;
			}
			
		}
		
		public sbyte? Expanded
		{
			get
			{
				return _expanded;
			}
			set
			{
				_expanded = value;
			}
			
		}
		
		public int? SortBook
		{
			get
			{
				return _sortBook;
			}
			set
			{
				_sortBook = value;
			}
			
		}
		
		public int? SortLes
		{
			get
			{
				return _sortLes;
			}
			set
			{
				_sortLes = value;
			}
			
		}
		
		public DateTime UpdTime
		{
			get
			{
				return _updTime;
			}
			set
			{
				_updTime = value;
			}
			
		}
		
	}
}
