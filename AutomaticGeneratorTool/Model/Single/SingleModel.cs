using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using Abp.EntityFramework;

namespace MicroService.EntityFramework.Models
{
    public partial class SingleModel : AbpDbContext
    {
        public SingleModel()
            : base("Default")
        {
        }

        public SingleModel(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        
        public virtual IDbSet<rc_cloudhisaccessauth> rc_cloudhisaccessauth { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // rc_cloudhisaccessauth Definations
            modelBuilder.Entity<rc_cloudhisaccessauth>().ToTable("rc_cloudhisaccessauth");
            modelBuilder.Entity<rc_cloudhisaccessauth>().HasKey(_ => _.Id);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.Id).HasColumnName("CHAAID");
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.Id).IsRequired();
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.Id).HasMaxLength(36);
                                    modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.Id).IsUnicode(true);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.Id).IsFixedLength();
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.CreateTime).IsRequired();
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.CreateTime).HasColumnType("datetime2");
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.CreateTime).HasPrecision(0);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.ModifyTime).IsRequired();
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.ModifyTime).HasColumnType("datetime2");
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.ModifyTime).HasPrecision(0);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.UnitID).IsRequired();
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.UnitID).HasMaxLength(200);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.UnitID).IsUnicode(true);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.AuthCode).IsRequired();
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.AuthCode).HasMaxLength(200);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.AuthCode).IsUnicode(true);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.AccessToken).IsRequired();
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.AccessToken).HasMaxLength(200);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.AccessToken).IsUnicode(true);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.ExpireTime).IsRequired();
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.ExpireTime).HasColumnType("datetime2");
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.ExpireTime).HasPrecision(0);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.TenantId).IsRequired();
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.TenantCode).IsRequired();
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.TenantCode).HasMaxLength(100);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.TenantCode).IsUnicode(true);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.Remark).HasMaxLength(200);
            modelBuilder.Entity<rc_cloudhisaccessauth>().Property(_ => _.Remark).IsUnicode(true);

        
            base.OnModelCreating(modelBuilder);
        }
    }
}



