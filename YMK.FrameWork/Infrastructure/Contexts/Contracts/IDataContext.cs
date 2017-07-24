#region

using System.Data;
using System.Collections.Generic;
using YMK.FrameWork.EntityBean.Contracts;
using YMK.FrameWork.EntityBean.Identities.Contracts;
using YMK.FrameWork.Infrastructure.Contracts;

#endregion


namespace YMK.FrameWork.Infrastructure.Contexts.Contracts
{
    public interface IDataContext
    {

    	IList<TEntity> GetList<TEntity>(string statement,TEntity parameters) where TEntity : class, IBaseEntity;
        IList<TEntity> GetList<TEntity, TParameter>(string statement, TParameter parameters) where TEntity : class, IBaseEntity;

        TEntity Read<TEntity>(string statement, TEntity parameters) where TEntity : class, IBaseEntity;

        #region Transactions Control
        void BeginTransaction();
        void RollBackTransaction();
        void CommitTransaction();
        void BeginTransaction<TEntity>() where TEntity : class, IBaseEntity;
        void RollBackTransaction<TEntity>() where TEntity : class, IBaseEntity;
        void CommitTransaction<TEntity>() where TEntity : class, IBaseEntity;
        #endregion

        #region Insert (6)
        void InsertTM<TEntity>(TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity;

        void InsertTM<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        void InsertTM<TEntity>(string statementName,TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity;

        void InsertTM<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity;

        void Insert<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        void Insert<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity;
        #endregion Insert

        #region Delete (6)
        void DeleteTM<TEntity>(TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity;

        void DeleteTM<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        void DeleteTM<TEntity>(string statementName,TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity;

        void DeleteTM<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity;

        void Delete<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        void Delete<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity;
        #endregion Delete

        #region Update (6)
        void UpdateTM<TEntity>(TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity;

        void UpdateTM<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        void UpdateTM<TEntity>(string statementName,TEntity entity, IsolationLevel isolationLevel) where TEntity : class, IBaseEntity;

        void UpdateTM<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity;

        void Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        void Update<TEntity>(string statementName,TEntity entity) where TEntity : class, IBaseEntity;
        #endregion Update

        #region Operations ( ) 

        TEntity Read<TEntity>(string statement, IIdentity id) where TEntity : class, IBaseEntity;
        
        IDataMapper<TEntity> GetDataMapper<TEntity>() where TEntity : class, IBaseEntity;

        #endregion Operations 

    }
}

