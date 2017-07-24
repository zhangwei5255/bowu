#region

using System.Reflection;
using YMK.FrameWork.EntityBean.Contracts;

#endregion


namespace YMK.FrameWork.EntityBean.BusinessRules
{
    public abstract class BusinessRule
    {
        #region?Constructors?(2)?

        protected BusinessRule(string propertyName, string errorMessage)
            : this(propertyName)
        {
            this.ErrorMessage = errorMessage;
        }

        protected BusinessRule(string propertyName)
        {
            this.PropertyName = propertyName;
            this.ErrorMessage = propertyName + " is not valid";
        }

        #endregion?Constructors?

        #region?Properties?(2)?

        public string ErrorMessage { get; set; }

        public string PropertyName { get; set; }

        #endregion?Properties?

        #region?Methods?(2)?

        public abstract bool Validate(IDomainObject businessObject);

        protected object GetPropertyValue(IDomainObject businessObject)
        {
            return businessObject.GetType().GetProperty(this.PropertyName).GetValue(businessObject, null);
        }

        #endregion?Methods?
    }
}

