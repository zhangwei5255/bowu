#region

using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Common;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Configuration.ResultMapping;
using log4net;
using log4net.Config;
using YMK.FrameWork.EntityBean.Identities.Contracts;

#endregion


namespace YMK.FrameWork.Infrastructure.Contracts
{
    public abstract partial class BaseDataMapper<TEntity> : IDataMapper<TEntity> where TEntity : class
    {
        private static readonly ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected ISqlMapper mapper;
        public virtual ISqlMapper Mapper
        {
            get
            {
                if (mapper == null)
                    mapper = new InfrastructureFactory().GetSqlMapper();
                return mapper;
            }
            set
            {
                mapper = value;
            }
        }

        public virtual IList<TEntity> GetList(string statement, TEntity parameters)
        {
            //logger.Debug("GetList<TEntity> start!");
            try
            {
                using (OpenConnection())
                {
                    if (String.IsNullOrEmpty(statement))
                        statement = GetDefaultStatement("SELECT");
                    //throw new ArgumentNullException("parameter null");
                    String sql = GetSqlText(statement, parameters);
                    logger.Info(sql);
                    return Mapper.QueryForList<TEntity>(statement, parameters);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex.Message);
                throw ex;
            }
        }

        public virtual IList<TEntity> GetList<TParameter>(string statement, TParameter parameters)
        {
            //try
            {
                using (OpenConnection())
                {
                    if (String.IsNullOrEmpty(statement))
                        statement = GetDefaultStatement("SELECT");
                    //throw new ArgumentNullException("parameter null");
                    return Mapper.QueryForList<TEntity>(statement, parameters);
                }
            }
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public virtual TEntity Read(string statement, IIdentity id)
        {
            using (OpenConnection())
            {
                if (String.IsNullOrEmpty(statement))
                    statement = GetDefaultStatement("READ");
                return Mapper.QueryForObject<TEntity>(statement, id);
            }
        }

        public virtual TEntity Read(string statement, TEntity parameters)
        {
            try
            {
                using (OpenConnection())
                {
                    if (String.IsNullOrEmpty(statement))
                        statement = GetDefaultStatement("READ");
                    //throw new ArgumentNullException("parameter null");
                    return Mapper.QueryForObject<TEntity>(statement, parameters);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex.Message);
                throw ex;
            }
        }


        #region Insert (6)
        public virtual void InsertTM(TEntity entity, IsolationLevel isolationLevel)
        {
            string sqlStatement = GetDefaultStatement("INSERT");
            InsertTM(sqlStatement, entity, isolationLevel);
        }

        public virtual void InsertTM(TEntity entity)
        {
            InsertTM(entity, IsolationLevel.Unspecified);
        }

        public virtual void Insert(TEntity entity)
        {
            string sqlStatement = GetDefaultStatement("INSERT");
            Insert(sqlStatement, entity);
        }

        public virtual void InsertTM(string statementName, TEntity entity)
        {
            InsertTM(statementName, entity, IsolationLevel.Unspecified);
        }


        public virtual void InsertTM(string statementName, TEntity entity, IsolationLevel isolationLevel)
        {
            using (var conn = OpenConnection())
            {
                try
                {
                    conn.BeginTransaction(isolationLevel);
                    Mapper.Insert(statementName, entity);
                    conn.CommitTransaction();
                }
                catch (Exception ex)
                {
                    conn.RollBackTransaction();
                    throw ex;
                }
            }
        }

        public virtual void Insert(string statementName, TEntity entity)
        {
            Mapper.Insert(statementName, entity);
        }

        #endregion Insert

        #region Update (6)
        public virtual void UpdateTM(TEntity entity, IsolationLevel isolationLevel)
        {
            string sqlStatement = GetDefaultStatement("UPDATE");
            UpdateTM(sqlStatement, entity, isolationLevel);
        }

        public virtual void UpdateTM(TEntity entity)
        {
            UpdateTM(entity, IsolationLevel.Unspecified);
        }

        public virtual void Update(TEntity entity)
        {
            string sqlStatement = GetDefaultStatement("UPDATE");
            Update(sqlStatement, entity);
        }

        public virtual void UpdateTM(string statementName, TEntity entity, IsolationLevel isolationLevel)
        {
            using (var conn = OpenConnection())
            {
                try
                {
                    conn.BeginTransaction(isolationLevel);
                    Mapper.Update(statementName, entity);
                    conn.CommitTransaction();
                }
                catch (Exception ex)
                {
                    conn.RollBackTransaction();
                    throw ex;
                }
            }
        }

        public virtual void UpdateTM(string statementName, TEntity entity)
        {
            UpdateTM(statementName, entity, IsolationLevel.Unspecified);
        }

        public virtual void Update(string statementName, TEntity entity)
        {
            //OpenConnection();
            //using (var conn = OpenConnection())
            {
                try
                {
                    Mapper.Update(statementName, entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion Update

        #region Delete (6)
        public virtual void DeleteTM(TEntity entity, IsolationLevel isolationLevel)
        {
            string sqlStatement = GetDefaultStatement("DELETE");
            DeleteTM(sqlStatement, entity, isolationLevel);
        }

        public virtual void DeleteTM(TEntity entity)
        {
            DeleteTM(entity, IsolationLevel.Unspecified);
        }

        public virtual void Delete(TEntity entity)
        {
            string sqlStatement = GetDefaultStatement("DELETE");
            Delete(sqlStatement, entity);
        }

        public virtual void DeleteTM(string statementName, TEntity entity, IsolationLevel isolationLevel)
        {
            using (var conn = OpenConnection())
            {
                try
                {
                    conn.BeginTransaction(isolationLevel);
                    Mapper.Delete(statementName, entity);
                    conn.CommitTransaction();
                }
                catch (Exception ex)
                {
                    conn.RollBackTransaction();
                    throw ex;
                }
            }
        }

        public virtual void DeleteTM(string statementName, TEntity entity)
        {
            DeleteTM(statementName, entity, IsolationLevel.Unspecified);
        }

        public virtual void Delete(string statementName, TEntity entity)
        {
            //OpenConnection();
            {
                try
                {
                    Mapper.Delete(statementName, entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion Delete

        #region Methods (?)

        // Public Methods (?) 


        public virtual IList<TEntity> GetList(string where, string orderBy, int size)
        {
            throw new NotImplementedException();
        }

        public virtual IList<TEntity> GetList(IIdentity id)
        {
            throw new NotImplementedException();
        }

        #endregion Methods

        private string GetDefaultStatement(string commandType)
        {
            string typeName = typeof(TEntity).Name;
            //string namespaceName = typeof(TEntity).Namespace;


            var res = from string item in Mapper.MappedStatements.Keys
                      where item.ToUpper().Contains("DEFAULT")
                        && item.ToUpper().Contains(commandType.ToUpper())
                        && item.ToUpper().Contains(typeName.Substring(1).ToUpper())
                      select item;
            var arr = res.ToArray<string>();
            if (arr.Length == 1)
                return res.ToArray()[0];
            else if (arr.Length > 1)
            {
                foreach (string item in arr)
                {
                    if (item.ToUpper().Contains(typeName.Substring(1).ToUpper() + "_" + commandType.ToUpper()))
                        return item;
                }
                throw new Exception("there is not default sql statement");
            }
            else
                throw new Exception("there is not default sql statement");
        }

        private string GetSqlText(string statementStr, object parameter)
        {
            IMappedStatement statement = (IMappedStatement)Mapper.MappedStatements[statementStr];
            return statement.Statement.Sql.GetRequestScope(statement, parameter, null).PreparedStatement.PreparedSql;
        }

        private ISqlMapSession OpenConnection()
        {
            if (!Mapper.IsSessionStarted)
                return Mapper.OpenConnection();
            else
                return Mapper.LocalSession;
        }

    }
}


