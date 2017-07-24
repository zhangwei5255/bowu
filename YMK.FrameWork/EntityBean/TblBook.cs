
namespace YMK.FrameWork.EntityBean
{
	public class TblBook  : BaseEntity
	{
		
		//本番号
		private string _bookNo;
		
		//本名称
		private string _bookName;
		
		
		
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
		
		public string BookName
		{
			get
			{
				return _bookName;
			}
			set
			{
				_bookName = value;
			}
			
		}
		
	}
}
