
using System;
namespace YMK.FrameWork.EntityBean
{
	public class TTblWord  : BaseEntity
	{
		
		//単語ＩＤ
		private string _wordId;
		
		//単語名称
		private string _wordName;
		
		//中国語の意味
		private string _wordChinaMeaning;
		
		//カタカタ
		private string _wordKana;
		
		//単語の種類
		private string _wordKindId;
		
		//コメント
		private string _wordRemarks;
		
		//削除ﾌﾗｸﾞ
		private string _wordDelFlg;
		
		//更新ユーザ
		private string _updUserId;
		
		//更新日時
		private DateTime _updTime;
		
		
		
		public string WordId
		{
			get
			{
				return _wordId;
			}
			set
			{
				_wordId = value;
			}
			
		}
		
		public string WordName
		{
			get
			{
				return _wordName;
			}
			set
			{
				_wordName = value;
			}
			
		}
		
		public string WordChinaMeaning
		{
			get
			{
				return _wordChinaMeaning;
			}
			set
			{
				_wordChinaMeaning = value;
			}
			
		}
		
		public string WordKana
		{
			get
			{
				return _wordKana;
			}
			set
			{
				_wordKana = value;
			}
			
		}
		
		public string WordKindId
		{
			get
			{
				return _wordKindId;
			}
			set
			{
				_wordKindId = value;
			}
			
		}
		
		public string WordRemarks
		{
			get
			{
				return _wordRemarks;
			}
			set
			{
				_wordRemarks = value;
			}
			
		}
		
		public string WordDelFlg
		{
			get
			{
				return _wordDelFlg;
			}
			set
			{
				_wordDelFlg = value;
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
