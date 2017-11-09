using Abp.EntityFramework;
using MicroService.EntityFramework.Generate;
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
        public virtual IDbSet<BRedisKey> BRedisKey { get; set; }
        public virtual IDbSet<BLocalUser> BLocalUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BRedisKey>().ToTable("BRedisKey");
            modelBuilder.Entity<BRedisKey>().HasKey(_ => _.Id);
            modelBuilder.Entity<BRedisKey>().Property(_ => _.Id).HasColumnName("hcjid");

            modelBuilder.Entity<BLocalUser>().ToTable("BLocalUser");
            modelBuilder.Entity<BLocalUser>().HasKey(_ => _.Id);
            modelBuilder.Entity<BLocalUser>().Property(_ => _.Id).HasColumnName("bdyhid");

            base.OnModelCreating(modelBuilder);
        }
    }
}
