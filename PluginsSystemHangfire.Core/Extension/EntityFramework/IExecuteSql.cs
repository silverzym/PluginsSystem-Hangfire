using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.EntityFramework
{
    /// <summary>
    /// 通过EF 直接执行Sql
    /// SQL 复杂逻辑，使用ORM的效率和性能都很低，故扩展一个执行Sql的一个。应用程序层对EntityFramework的引用，因为它返回的是返回的查询。这“污染”了应用层，故定义成一个接口而不是存储库
    /// </summary>
    public interface IExecuteSql : ITransientDependency
    {
        /// <summary>
        /// 执行 增、删、改 
        /// </summary>
        int Execute(string sql, params object[] parameters);

        /// <summary>
        /// 执行 查询语句
        /// </summary>
        IEnumerable<T> Execute<T>(string sql, params object[] parameters);
    }
}
