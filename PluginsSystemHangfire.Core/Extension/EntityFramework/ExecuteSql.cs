using Abp.EntityFramework;
using MicroService.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.EntityFramework
{
    public class ExecuteSql : IExecuteSql
    {
        private readonly IDbContextProvider<MicroServiceDbContext> _DbContext;

        public ExecuteSql(IDbContextProvider<MicroServiceDbContext> DbContext)
        {
            _DbContext = DbContext;
        }

        /// <summary>
        /// 执行 增、删、改 
        /// </summary>
        public int Execute(string sql, params object[] parameters)
        {
            if (parameters.Length > 0)
            {
                return this._DbContext.GetDbContext().Database.ExecuteSqlCommand(sql);
            }
            
            return this._DbContext.GetDbContext().Database.ExecuteSqlCommand(sql, parameters);
        }

        /// <summary>
        /// 执行 查询语句
        /// </summary>
        public IEnumerable<T> Execute<T>(string sql, params object[] parameters)
        {
            if (parameters.Length > 0)
            {
                return this._DbContext.GetDbContext().Database.SqlQuery<T>(sql);
            }

            return this._DbContext.GetDbContext().Database.SqlQuery<T>(sql, parameters);
        }
    }
}
