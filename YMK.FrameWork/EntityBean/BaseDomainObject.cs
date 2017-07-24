#region

using System.Collections.Generic;
using YMK.FrameWork.EntityBean.BusinessRules;
using YMK.FrameWork.EntityBean.Contracts;

#endregion


namespace YMK.FrameWork.EntityBean
{
    public abstract class BaseDomainObject : IDomainObject
    {
        #region?Fields?(2)?
        protected static readonly string VersionDefault = "NotSet";
        private readonly IList<BusinessRule> businessRules = new List<BusinessRule>();
        #endregion?Fields

		public List<string> Identities { get; protected set; }

        #region?Constructors?(1)?

        protected BaseDomainObject()
        {
            this.ValidationErrors = new List<string>();
        }

        #endregion?Constructors?

        #region?Properties?(1)?
        public IList<string> ValidationErrors { get; private set; }

        #endregion?Properties?

        #region?Methods?(2)?

		public virtual bool Validate()
		{
			return this.Validate(false);
		}
		public virtual bool Validate(bool onlyIdentities)
		{
			bool isValid = true;

			this.ValidationErrors.Clear();

			foreach (BusinessRule rule in this.businessRules)
			{
				var checkRule = this.Identities != null && this.Identities.Contains(rule.PropertyName);

				if (!onlyIdentities || checkRule)
				{
					if (!rule.Validate(this))
					{
						isValid = false;
						this.ValidationErrors.Add(rule.ErrorMessage);
					}
				}
			}
			return isValid;
		}

        protected void AddRule(BusinessRule rule)
        {
            this.businessRules.Add(rule);
        }

        #endregion?Methods?
    }
}
