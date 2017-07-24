
namespace YMK.FrameWork.EntityBean
{
	public class TblWordKind  : BaseEntity
	{
		
		//単語種類ＩＤ
		private string _wordKindId;
		
		//単語種類名
		private string _wordKindName;
		
		
		
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
		
		public string WordKindName
		{
			get
			{
				return _wordKindName;
			}
			set
			{
				_wordKindName = value;
			}
			
		}
		
	}
}
