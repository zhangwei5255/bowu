
using IBatisNet.DataMapper;
using YMK.FrameWork.Infrastructure.Contexts.Contracts;
namespace YMK.FrameWork.Infrastructure.Contracts
{
    public partial interface IInfrastructureFactory
    {
        #region Operations

        IDataContext GetDataContext();

        ISqlMapper GetSqlMapper(string databaseName);

        ISqlMapper GetSqlMapper();

        #endregion Operations
    }
}


