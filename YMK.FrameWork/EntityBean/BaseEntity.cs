#region

using System;
using System.Collections.Generic;
using YMK.FrameWork.EntityBean.Contracts;

#endregion


namespace YMK.FrameWork.EntityBean
{
    public abstract class BaseEntity : BaseDomainObject, IBaseEntity
    {
		protected BaseEntity()
		{
			this.Identities = new List<string>();
			this.RegisterIdenties();
		}

		public bool SupportInterfaceIIdenty(Type type)
		{
			var interfaces = type.GetInterfaces();

			if (interfaces.Length != 1)
			{
				return false;
			}

			foreach (var subType in interfaces)
			{
                if (subType.FullName == " YMK.FrameWork.EntityBean.Identities.Contracts.IIdentity")										 
				{
					return true;
				}
			}
			return false;
		}

    	private void RegisterIdenties()
    	{
			var interfaces = this.GetType().GetInterfaces();
			foreach (var type in interfaces)
			{
					if (this.SupportInterfaceIIdenty(type))
					{
						var properties = type.GetProperties();
						foreach (var property in properties)
						{
							this.Identities.Add(property.Name);
						}
					}
			}
    	}

    	#region?Properties?(2)

		public T GetIdentityValue<T>(string propertyName)
		{
			return (T)this.GetType().GetProperty(propertyName).GetValue(this, new object[0]);
		}

		public void SetIdentityValue<T>(string propertyName, T value)
		{
			this.GetType().GetProperty(propertyName).SetValue(this, value, new object[0]);
		}

        public byte[] Timestamp { get; set; }



        #endregion?Properties?
    	}
}

