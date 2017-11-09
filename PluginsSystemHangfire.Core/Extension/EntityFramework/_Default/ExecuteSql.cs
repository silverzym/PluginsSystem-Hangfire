using Abp.EntityFramework;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire.EntityFramework
{
    /// <summary>
    /// 默认的数据库
    /// </summary>
    public class ExecuteSql : IExecuteSql
    {
        private readonly ServiceDbContext _DbContext;

        private DbContextTransaction _dbContextTransaction;
        public ExecuteSql(ServiceDbContext DbContext)
        {
            _DbContext = DbContext;
            _dbContextTransaction = this._DbContext.Database.BeginTransaction();
        }

        public void Commit(bool isSubmit)
        {
            if (isSubmit)
            {
                this._dbContextTransaction.Commit();
            }
            else
                this._dbContextTransaction.Rollback();
        }

        /// <summary>
        /// 执行 增、删、改 
        /// </summary>
        public int Execute(string sql, params object[] parameters)
        {
            if (parameters.Length == 0)
            {
                return this._DbContext.Database.ExecuteSqlCommand(sql);
            }
            
            return this._DbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        /// <summary>
        /// 执行 查询语句
        /// </summary>
        public IEnumerable<T> Execute<T>(string sql, params object[] parameters)
        {
            if (parameters.Length == 0)
            {
                return this._DbContext.Database.SqlQuery<T>(sql);
            }

            return this._DbContext.Database.SqlQuery<T>(sql, parameters);
        }
    }
}
