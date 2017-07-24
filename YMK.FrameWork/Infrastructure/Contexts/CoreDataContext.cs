
#region

using System;
using IBatisNet.DataMapper;
using YMK.FrameWork.Infrastructure.Contracts;
using YMK.FrameWork.Infrastructure.Contexts.Contracts;
#endregion


namespace YMK.FrameWork.Infrastructure.Contexts
{
	public class CoreDataContext : BaseDataContext
	{
		#region Constructors (1) 
		
		//SqlMapperSession _session=new SqlMapperSession();

		protected CoreDataContext()
		{
		}

		#endregion Constructors 

		#region Methods (2) 

		// Protected Methods (1) 

		public override IDataMapper<TEntity> GetDataMapper<TEntity>()
		{
            //delete by I.TYOU 20141212 複数ＤＢ start 
            //DB：user
            //if (typeof (TEntity) == typeof (Iuserinfo))
            //{
            //    return (IDataMapper<TEntity>)new userinfoDataMapper();
            //}
            //DB:userdetail
            //if (typeof (TEntity) == typeof (Iuserdetail))
            //{
            //    return (IDataMapper<TEntity>)new userdetailDataMapper();
            //}
            //typeof(TEntity).Assembly.GetTypes()
            //delete by I.TYOU 20141212 end
            JPBookDataMapper<TEntity> dataMapper = new JPBookDataMapper<TEntity>();
            return (IDataMapper<TEntity>)dataMapper;

            foreach (Type t in this.GetType().Assembly.GetTypes())
            {
                if (t.BaseType != null)
                {
                    bool checkFlag = false;
                    Type tmp = t;
                    while (tmp.BaseType != null)
                    {
                        if (tmp.FullName == typeof(BaseDataMapper<TEntity>).FullName)
                        {
                            checkFlag = true;
                            break;
                        }
                        tmp = tmp.BaseType;
                    }
                    if (checkFlag)
                    {
                        foreach (var attrib in t.BaseType.GetGenericArguments())
                        {
                            if (attrib.Name == typeof(TEntity).Name)
                                //IBatisNet.DataMapper.Mapper.Instance()
                                //Mapper.Instance().Update()
                                return (IDataMapper<TEntity>)Activator.CreateInstance(t);

                        }
                    }
                }
            }

            throw new ArgumentException("Unknown entity type. Can't create DataMapper.");
		}

        #region Transactions Control
        public override void BeginTransaction()
        {
            (new InfrastructureFactory().GetSqlMapper()).BeginTransaction();
        }
        public override void RollBackTransaction()
        {
            (new InfrastructureFactory().GetSqlMapper()).RollBackTransaction();
        }
        public override void CommitTransaction()
        {
            (new InfrastructureFactory().GetSqlMapper()).CommitTransaction();
        }

        public override void BeginTransaction<TEntity>()
        {
            this.GetDataMapper<TEntity>().Mapper.BeginTransaction();
        }
        public override void RollBackTransaction<TEntity>()
        {
            this.GetDataMapper<TEntity>().Mapper.RollBackTransaction();
        }
        public override void CommitTransaction<TEntity>()
        {
            this.GetDataMapper<TEntity>().Mapper.CommitTransaction();
        }
        #endregion


		// Internal Methods (1) 

		public static IDataContext GetDataContext()
		{
			return new CoreDataContext();
		}

		#endregion Methods 
	}
}


