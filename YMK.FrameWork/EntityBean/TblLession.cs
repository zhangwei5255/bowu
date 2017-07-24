
namespace YMK.FrameWork.EntityBean
{
	public class TblLession  : BaseEntity
	{
		
		//課番号
		private string _lessionNo;
		
		//名称
		private string _lessionName;
		
		
		
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
		
		public string LessionName
		{
			get
			{
				return _lessionName;
			}
			set
			{
				_lessionName = value;
			}
			
		}
		
	}
}
