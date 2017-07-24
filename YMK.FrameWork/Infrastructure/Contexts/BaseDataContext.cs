#region

using System;
using System.Data;
using System.Collections.Generic;
using YMK.FrameWork.Commons.Contexts;
using YMK.FrameWork.Infrastructure.Contexts.Contracts;
using YMK.FrameWork.EntityBean.Identities.Contracts;
using YMK.FrameWork.EntityBean.Contracts;
using YMK.FrameWork.Infrastructure.Contracts;

#endregion


namespace YMK.FrameWork.Infrastructure.Contexts
{
    public abstract partial class BaseDataContext :BaseCommonContext, IDataContext
    {
    
		#region Fields (1) 

        private readonly IdentityMap identityMap = new IdentityMap();

		#endregion Fields 


		#region Methods ( ) 		
        public virtual IList<TEntity> GetList<TEntity>(string statement,TEntity parameters) where TEntity : class, IBaseEntity
        {
        	return this.GetDataMapper<TEntity>().GetList(statement,parameters);
        }
        public virtual IList<TEntity> GetList<TEntity, TParameter>(string statement, TParameter parameters) where TEntity : class, IBaseEntity
        {
            return this.GetDataMapper<TEntity>().GetList<TParameter>(statement, parameters);
        }

        public virtual TEntity Read<TEntity>(string statement, TEntity parameters) where TEntity : class, IBaseEntity
        {
            return this.GetDataMapper<TEntity>().Read(statement, parameters);
        }

        public virtual TEntity Read<TEntity>(string statement, IIdentity id) where TEntity : class, IBaseEntity
        {
            return this.GetDataMapper<TEntity>().Read(statement, id);
        }

		#region Insert (6)
        public virtual void InsertTM<TEntity>(TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().InsertTM(entity,isolationLevel);
        }

        public virtual void InsertTM<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
			//throw new NotImplementedException();
        	this.GetDataMapper<TEntity>().InsertTM(entity);
        }

        public virtual void InsertTM<TEntity>(string statementName,TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().InsertTM(statementName,entity,isolationLevel);
        }

        public virtual void InsertTM<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().InsertTM(statementName,entity);
        }

        public virtual void Insert<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().Insert(entity);
        }

        public virtual void Insert<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().Insert(statementName,entity);
        }
        #endregion Insert

        #region Delete (6)
        public virtual void DeleteTM<TEntity>(TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().DeleteTM(entity,isolationLevel);
        }

        public virtual void DeleteTM<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().DeleteTM(entity);
        }

        public virtual void DeleteTM<TEntity>(string statementName,TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().DeleteTM(statementName,entity,isolationLevel);
        }

        public virtual void DeleteTM<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().DeleteTM(statementName,entity);
        }

        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().Delete(entity);
        }

        public virtual void Delete<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().Delete(statementName,entity);
        }
        #endregion Delete

        #region Update (6)
        public virtual void UpdateTM<TEntity>(TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().UpdateTM(entity,isolationLevel);
        }

        public virtual void UpdateTM<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().UpdateTM(entity);
        }

        public virtual void UpdateTM<TEntity>(string statementName,TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().UpdateTM(statementName,entity,isolationLevel);
        }

        public virtual void UpdateTM<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().UpdateTM(statementName,entity);
        }

        public virtual void Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().Update(entity);
        }

        public virtual void Update<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity
        {
        	this.GetDataMapper<TEntity>().Update(statementName,entity);
        }
        #endregion Update

        #region Operations ( ) 



        #endregion Operations 
        
		// Protected Methods (1) 

        public abstract IDataMapper<TEntity> GetDataMapper<TEntity>() where TEntity : class, IBaseEntity;


        #region Transactions Control
        public abstract void BeginTransaction();
        public abstract void RollBackTransaction();
        public abstract void CommitTransaction();
        public abstract void BeginTransaction<TEntity>() where TEntity : class, IBaseEntity;
        public abstract void RollBackTransaction<TEntity>() where TEntity : class, IBaseEntity;
        public abstract void CommitTransaction<TEntity>() where TEntity : class, IBaseEntity;
        #endregion

		#endregion Methods
    }
}

