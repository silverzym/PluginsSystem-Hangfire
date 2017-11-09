using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.EntityFramework
{
    /// <summary>
    /// 设置的第一个数据库
    /// </summary>
    public partial class MicroServiceFirstDbContext : AbpDbContext
    {
        public MicroServiceFirstDbContext()
            : base("Default_First")
        {

        }
    }
}
