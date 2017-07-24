#region

using System.Data;
using System.Collections.Generic;
using YMK.FrameWork.EntityBean.Contracts;

#endregion


namespace YMK.FrameWork.BLL
{
    public interface IBaseBiz<TEntity> where TEntity : class, IBaseEntity
	{
		#region Operations (7) 

        //void Create(TEntity entity);

        //void Delete(TEntity entity);

        //IList<TEntity> GetList(string where, string orderBy, int size);

        //IList<TEntity> GetList(string where, string orderBy, int index, int size);

        //TEntity Read(IIdentity id);

        //void Update(TEntity entity);

		#endregion Operations 

        #region Insert (6)
        void InsertTM(TEntity entity, IsolationLevel isolationLevel);

        void InsertTM(TEntity entity);

        void InsertTM(string statementName, TEntity entity, IsolationLevel isolationLevel);

        void InsertTM(string statementName, TEntity entity);

        void Insert(TEntity entity);

        void Insert(string statementName, TEntity entity);
        #endregion Insert

        #region Delete (6)
        void DeleteTM(TEntity entity, IsolationLevel isolationLevel);

        void DeleteTM(TEntity entity);

        void DeleteTM(string statementName, TEntity entity, IsolationLevel isolationLevel);

        void DeleteTM(string statementName, TEntity entity);

        void Delete(TEntity entity);

        void Delete(string statementName, TEntity entity);
        #endregion Delete

        #region Update (6)
        void UpdateTM(TEntity entity, IsolationLevel isolationLevel);

        void UpdateTM(TEntity entity);

        void UpdateTM(string statementName, TEntity entity, IsolationLevel isolationLevel);

        void UpdateTM(string statementName, TEntity entity);

        void Update(TEntity entity);

        void Update(string statementName, TEntity entity);
        #endregion Update

        IList<TEntity> GetList(string statement, TEntity parameters);

        IList<TEntity> GetList<TParameter>(string statement, TParameter parameter);

        #region Transactions Control
        void BeginTransaction();
        void RollBackTransaction();
        void CommitTransaction();
        #endregion
	}
}



