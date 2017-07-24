
using System;
namespace YMK.FrameWork.EntityBean
{
	public class TblExpression  : BaseEntity
	{
		
		//文法ＩＤ
		private string _expId;
		
		//文法のテーマ
		private string _expTopic;
		
		//サイズ
		private long _expSize;
		
		//例
		private byte[] _expExample;
		
		//削除ﾌﾗｸﾞ
		private string _expDelFlg;
		
		//ユーザＩＤ
		private string _updUserId;
		
		//更新日時
		private DateTime _updTime;
		
		
		
		public string ExpId
		{
			get
			{
				return _expId;
			}
			set
			{
				_expId = value;
			}
			
		}
		
		public string ExpTopic
		{
			get
			{
				return _expTopic;
			}
			set
			{
				_expTopic = value;
			}
			
		}
		
		public long ExpSize
		{
			get
			{
				return _expSize;
			}
			set
			{
				_expSize = value;
			}
			
		}
		
		public byte[] ExpExample
		{
			get
			{
				return _expExample;
			}
			set
			{
				_expExample = value;
			}
			
		}
		
		public string ExpDelFlg
		{
			get
			{
				return _expDelFlg;
			}
			set
			{
				_expDelFlg = value;
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
