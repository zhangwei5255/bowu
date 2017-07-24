using System.Collections.Generic;

namespace YMK.FrameWork.EntityBean.Identities.Contracts
{
	public interface IIdentity
	{
		List<string> Identities { get; }

		T GetIdentityValue<T>(string propertyName);

		void SetIdentityValue<T>(string propertyName, T value);
	}
}


