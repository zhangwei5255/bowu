
namespace YMK.FrameWork.EntityBean
{
	public class TblDirect  : BaseEntity
	{
		
		//本番号
		private string _bookNo;
		
		//課番号
		private string _lessonNo;
		
		
		
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
		
		public string LessonNo
		{
			get
			{
				return _lessonNo;
			}
			set
			{
				_lessonNo = value;
			}
			
		}
		
	}
}
