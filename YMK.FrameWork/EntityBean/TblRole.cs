
namespace YMK.FrameWork.EntityBean
{
	public class TblRole  : BaseEntity
	{
		
		//権限ＩＤ
		private string _roleId;
		
		//権限名称
		private string _roleName;
		
		
		
		public string RoleId
		{
			get
			{
				return _roleId;
			}
			set
			{
				_roleId = value;
			}
			
		}
		
		public string RoleName
		{
			get
			{
				return _roleName;
			}
			set
			{
				_roleName = value;
			}
			
		}
		
	}
}
