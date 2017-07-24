using IBatisNet.DataMapper;
using YMK.FrameWork.Commons.Contexts;
using YMK.FrameWork.Infrastructure.Contexts;
using YMK.FrameWork.Infrastructure.Contexts.Contracts;
using YMK.FrameWork.Infrastructure.Contracts;
namespace YMK.FrameWork.Infrastructure
{
	public sealed class InfrastructureFactory : IInfrastructureFactory
	{
		#region Methods (3) 
		public IDataContext GetDataContext()
		{
			return CoreDataContext.GetDataContext();
		}
		
		public ISqlMapper GetSqlMapper()
		{
            return IbatisSqlMapContext.Context.GetSqlMapper();
		}

        public ISqlMapper GetSqlMapper(string databaseName)
        {
            return IbatisSqlMapContext.Context.GetSqlMapper(databaseName);
        }

		#endregion Methods
	}
}


