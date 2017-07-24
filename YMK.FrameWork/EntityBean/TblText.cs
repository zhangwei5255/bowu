
using System;
namespace YMK.FrameWork.EntityBean
{
	public class TblText  : BaseEntity
	{
		
		//文章ID
		private string _textId;
		
		//文章名称
		private string _textName;
		
		//サイズ
		private long _textSize;
		
		//内容
		private byte[] _textData;
		
		//更新ユーザＩＤ
		private string _updUserId;
		
		//更新日時
		private DateTime _updTime;
		
		
		
		public string TextId
		{
			get
			{
				return _textId;
			}
			set
			{
				_textId = value;
			}
			
		}
		
		public string TextName
		{
			get
			{
				return _textName;
			}
			set
			{
				_textName = value;
			}
			
		}
		
		public long TextSize
		{
			get
			{
				return _textSize;
			}
			set
			{
				_textSize = value;
			}
			
		}
		
		public byte[] TextData
		{
			get
			{
				return _textData;
			}
			set
			{
				_textData = value;
			}
			
		}
		
		public string UpdUserId
		{
			get
			{
				return _updUserId;
			}
			set
			{
				_updUserId = value;
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
