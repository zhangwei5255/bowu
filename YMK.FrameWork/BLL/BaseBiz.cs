#region
using System.Data;
using System.Collections.Generic;
using YMK.FrameWork.EntityBean.Contracts;
using YMK.FrameWork.Infrastructure.Contexts.Contracts;
using YMK.FrameWork.Infrastructure;


#endregion


namespace YMK.FrameWork.BLL
{
    public abstract  class BaseBiz<TEntity> : IBaseBiz<TEntity> where TEntity : class, IBaseEntity
    {
        #region Fields (1) 

        private readonly IDataContext currentDataContext;

        #endregion Fields 

        #region Constructors (1) 

        protected BaseBiz()
        {
            var infrastructureFactory = new InfrastructureFactory();
            this.currentDataContext = infrastructureFactory.GetDataContext();
        }

        #endregion Constructors 

        #region Properties (1) 

        protected IDataContext CurrentDataContext
        {
            get
            {
                return this.currentDataContext;
            }
        }

        #endregion Properties 

        #region Transactions Control
        public void BeginTransaction()
        {
            this.CurrentDataContext.BeginTransaction<TEntity>();
        }
        public void RollBackTransaction()
        {
            this.CurrentDataContext.RollBackTransaction<TEntity>();
        }
        public void CommitTransaction()
        {
            this.CurrentDataContext.CommitTransaction<TEntity>();
        }
        #endregion

        public virtual IList<TEntity> GetList<TParameter>(string statement, TParameter parameter)
        {
            return this.CurrentDataContext.GetList<TEntity, TParameter>(statement, parameter);
        }

        public IList<TEntity> GetList(string statement, TEntity parameters)
        {
            return this.CurrentDataContext.GetList<TEntity>(statement,parameters);
        }

        #region Insert (6)
        public void InsertTM(TEntity entity, IsolationLevel isolationLevel)
        {
            this.CurrentDataContext.InsertTM<TEntity>(entity, isolationLevel);
        }

        public void InsertTM(TEntity entity)
        {
            this.CurrentDataContext.InsertTM<TEntity>(entity);
        }

        public void InsertTM(string statementName, TEntity entity, IsolationLevel isolationLevel)
        {
            this.CurrentDataContext.InsertTM<TEntity>(statementName,entity, isolationLevel);
        }

        public void InsertTM(string statementName, TEntity entity)
        {
            this.CurrentDataContext.InsertTM<TEntity>(statementName, entity);
        }

        public void Insert(TEntity entity)
        {
            this.CurrentDataContext.Insert<TEntity>(entity);
        }

        public void Insert(string statementName, TEntity entity)
        {
            this.CurrentDataContext.Insert<TEntity>(statementName,entity);
        }
        #endregion Insert

        #region Delete (6)
        public void DeleteTM(TEntity entity, IsolationLevel isolationLevel)
        {
            this.CurrentDataContext.DeleteTM<TEntity>(entity,isolationLevel);
        }

        public void DeleteTM(TEntity entity)
        {
            this.CurrentDataContext.DeleteTM<TEntity>(entity);
        }

        public void DeleteTM(string statementName, TEntity entity, IsolationLevel isolationLevel)
        {
            this.CurrentDataContext.DeleteTM<TEntity>(statementName,entity,isolationLevel);
        }

        public void DeleteTM(string statementName, TEntity entity)
        {
            this.CurrentDataContext.DeleteTM<TEntity>(statementName,entity);
        }

        public void Delete(TEntity entity)
        {
            this.CurrentDataContext.Delete<TEntity>(entity);
        }

        public void Delete(string statementName, TEntity entity)
        {
            this.CurrentDataContext.Delete<TEntity>(statementName,entity);
        }
        #endregion Delete

        #region Update (6)
        public void UpdateTM(TEntity entity, IsolationLevel isolationLevel)
        {
            this.CurrentDataContext.UpdateTM<TEntity>(entity, isolationLevel);
        }

        public void UpdateTM(TEntity entity)
        {
            this.CurrentDataContext.UpdateTM<TEntity>(entity);
        }

        public void UpdateTM(string statementName, TEntity entity, IsolationLevel isolationLevel)
        {
            this.CurrentDataContext.UpdateTM<TEntity>(statementName,entity, isolationLevel);
        }

        public void UpdateTM(string statementName, TEntity entity)
        {
            this.CurrentDataContext.UpdateTM<TEntity>(statementName,entity);
        }

        public void Update(TEntity entity)
        {
            this.CurrentDataContext.Update<TEntity>(entity);
        }

        public void Update(string statementName, TEntity entity)
        {
            this.CurrentDataContext.Update<TEntity>(statementName,entity);
        }
        #endregion Update


        #region Methods (6) 

        // Public Methods (6) 
        //public abstract void Create(TEntity entity);

        //public abstract void Delete(TEntity entity);

        //public abstract IList<TEntity> GetList(string where, string orderBy, int size);

        //public abstract IList<TEntity> GetList(string where, string orderBy, int index, int size);

        //public abstract TEntity Read(IIdentity id);

        //public abstract void Update(TEntity entity);

        #endregion Methods 
    }
}

