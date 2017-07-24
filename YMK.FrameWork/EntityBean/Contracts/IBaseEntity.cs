using YMK.FrameWork.EntityBean.Identities.Contracts;
namespace YMK.FrameWork.EntityBean.Contracts
{
    public interface IBaseEntity : IDomainObject, IIdentity
    {
        #region Data Members (2)

        byte[] Timestamp { get; set; }

        #endregion Data Members
    }
}

