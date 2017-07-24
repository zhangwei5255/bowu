#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using IBatisNet.DataMapper;
using YMK.FrameWork.EntityBean.Identities.Contracts;


#endregion


namespace YMK.FrameWork.Infrastructure.Contracts
{
    public partial interface IDataMapper<TEntity> where TEntity : class
    {
    	ISqlMapper Mapper{get;set;}

		IList<TEntity> GetList(string statement,TEntity parameters);

        IList<TEntity> GetList<TParameter>(string statement, TParameter parameters);

        TEntity Read(string statement, IIdentity id);

        TEntity Read(string statement, TEntity parameters);


		#region Insert (6)
        void InsertTM(TEntity entity, IsolationLevel isolationLevel);

        void InsertTM(TEntity entity);

        void InsertTM(string statementName,TEntity entity, IsolationLevel isolationLevel);

        void InsertTM(string statementName,TEntity entity);

        void Insert(TEntity entity);

        void Insert(string statementName,TEntity entity);
        #endregion Insert

        #region Delete (6)
        void DeleteTM(TEntity entity, IsolationLevel isolationLevel);

        void DeleteTM(TEntity entity);

        void DeleteTM(string statementName,TEntity entity, IsolationLevel isolationLevel);

        void DeleteTM(string statementName,TEntity entity);

        void Delete(TEntity entity);

        void Delete(string statementName,TEntity entity);
        #endregion Delete

        #region Update (6)
        void UpdateTM(TEntity entity, IsolationLevel isolationLevel);

        void UpdateTM(TEntity entity);

        void UpdateTM(string statementName,TEntity entity, IsolationLevel isolationLevel);

        void UpdateTM(string statementName,TEntity entity);

        void Update(TEntity entity);

        void Update(string statementName,TEntity entity);
        #endregion Update

        #region?Operations?(?)?

		[Obsolete("Don't use this method for the implementation. It is workaround for AccidentDataMapper only.")]
		IList<TEntity> GetList(IIdentity id);


        #endregion?Operations?
    }
}

