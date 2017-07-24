using System.Collections.Generic;
namespace YMK.FrameWork.EntityBean.Contracts
{
	public partial interface IDomainObject
	{
		#region Data Members (1)

		IList<string> ValidationErrors { get; }

		#endregion Data Members 

		#region Operations (2) 

		bool Validate();

		bool Validate(bool onlyIdentities);

		#endregion Operations 
	}
}


