using System.Data.Common;
using Abp.EntityFramework;
using System.Data.Entity;
using PluginsSystemHangfire.EntityFramework.Generate;

namespace PluginsSystemHangfire.EntityFramework
{
    /// <summary>
    /// 默认数据库
    /// </summary>
    public partial class ServiceDbContext : AbpDbContext
    {
        
        /// <summary>
        /// 用于跨库测试
        /// </summary>
        public virtual IDbSet<test_master> test_master { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
