using System.Data.Common;
using Abp.EntityFramework;
using System.Data.Entity;

namespace PluginsSystemHangfire.EntityFramework
{
    /// <summary>
    /// 默认数据库
    /// </summary>
    public partial class ServiceDbContext : AbpDbContext
    {

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ServiceDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in MicroServiceDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ServiceDbContext since ABP automatically handles it.
         */
        public ServiceDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
