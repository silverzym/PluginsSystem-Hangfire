using System.Data.Common;
using Abp.EntityFramework;
using System.Data.Entity;
using MicroService.EntityFramework.Generate;

namespace MicroService.EntityFramework
{
    /// <summary>
    /// 默认数据库
    /// </summary>
    public partial class MicroServiceDbContext : AbpDbContext
    {

        //    //Example:
        //    //public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<CUser> CUser { get; set; }
        public virtual IDbSet<CHospitalInfo> CHospitalInfo { get; set; }
        public virtual IDbSet<CParameter> CParameter { get; set; }
        public virtual IDbSet<CEmployeeCode> CEmployeeCode { get; set; }
        public virtual IDbSet<CMenu> CMenu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region CUser Definations
            modelBuilder.Entity<CUser>().ToTable("CUser");
            modelBuilder.Entity<CUser>().HasKey(_ => _.Id);
            modelBuilder.Entity<CUser>().Property(_ => _.Id).HasColumnName("USERID");
            modelBuilder.Entity<CUser>().Property(_ => _.Id).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.CreationTime).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.RYID).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.ROLEID).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.DLM).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.DLM).HasMaxLength(50);
            modelBuilder.Entity<CUser>().Property(_ => _.DLM).IsUnicode(false);
            modelBuilder.Entity<CUser>().Property(_ => _.PWD).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.PWD).HasMaxLength(50);
            modelBuilder.Entity<CUser>().Property(_ => _.PWD).IsUnicode(false);
            modelBuilder.Entity<CUser>().Property(_ => _.SD).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.TenantId).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.SCBZ).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.JMPS).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.JMPS).HasMaxLength(50);
            modelBuilder.Entity<CUser>().Property(_ => _.JMPS).IsUnicode(false);
            modelBuilder.Entity<CUser>().Property(_ => _.SBCS).IsRequired();
            modelBuilder.Entity<CUser>().Property(_ => _.SBSJ).IsRequired();
            #endregion

            #region CHospitalInfo Definations
            modelBuilder.Entity<CHospitalInfo>().ToTable("CHospitalInfo");
            modelBuilder.Entity<CHospitalInfo>().HasKey(_ => _.Id);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.Id).HasColumnName("YYID");
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.Id).IsRequired();
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.CreationTime).IsRequired();
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.YYMC).IsRequired();
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.YYMC).HasMaxLength(50);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.YYMC).IsUnicode(false);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.YLJGDM).IsRequired();
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.YLJGDM).HasMaxLength(50);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.YLJGDM).IsUnicode(false);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.DZ).IsRequired();
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.DZ).HasMaxLength(200);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.DZ).IsUnicode(false);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.LXDH).IsRequired();
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.LXDH).HasMaxLength(50);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.LXDH).IsUnicode(false);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.JGLXDM).IsRequired();
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.JGLXDM).HasMaxLength(50);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.JGLXDM).IsUnicode(false);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.SQYXQ).IsRequired();
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.PYM).HasMaxLength(50);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.PYM).IsUnicode(false);
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.SHID).IsRequired();
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.SID).IsRequired();
            modelBuilder.Entity<CHospitalInfo>().Property(_ => _.QID).IsRequired();
            #endregion

            #region CParameter Definations
            modelBuilder.Entity<CParameter>().ToTable("CParameter");
            modelBuilder.Entity<CParameter>().HasKey(_ => _.Id);
            modelBuilder.Entity<CParameter>().Property(_ => _.Id).HasColumnName("CSID");
            modelBuilder.Entity<CParameter>().Property(_ => _.Id).IsRequired();
            modelBuilder.Entity<CParameter>().Property(_ => _.CSDM).IsRequired();
            modelBuilder.Entity<CParameter>().Property(_ => _.CSDM).HasMaxLength(50);
            modelBuilder.Entity<CParameter>().Property(_ => _.CSDM).IsUnicode(false);
            modelBuilder.Entity<CParameter>().Property(_ => _.CSMC).IsRequired();
            modelBuilder.Entity<CParameter>().Property(_ => _.CSMC).HasMaxLength(200);
            modelBuilder.Entity<CParameter>().Property(_ => _.CSMC).IsUnicode(false);
            modelBuilder.Entity<CParameter>().Property(_ => _.CSZ).IsRequired();
            modelBuilder.Entity<CParameter>().Property(_ => _.CSZ).HasMaxLength(200);
            modelBuilder.Entity<CParameter>().Property(_ => _.CSZ).IsUnicode(false);
            modelBuilder.Entity<CParameter>().Property(_ => _.WHQX).IsRequired();
            #endregion

            #region CEmployeeCode Definations
            modelBuilder.Entity<CEmployeeCode>().ToTable("CEmployeeCode");
            modelBuilder.Entity<CEmployeeCode>().HasKey(_ => _.Id);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.Id).HasColumnName("RYID");
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.Id).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.CreationTime).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.TenantId).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.KSID).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.RYGH).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.RYGH).HasMaxLength(50);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.RYGH).IsUnicode(false);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.RYXM).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.RYXM).HasMaxLength(50);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.RYXM).IsUnicode(false);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.PYM).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.PYM).HasMaxLength(50);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.PYM).IsUnicode(false);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.ZJBZ).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.KBID).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.GHF).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.GHF).HasPrecision(13, 4);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.ZLF).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.ZLF).HasPrecision(13, 4);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.SCBZ).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.ZCDM).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.ZCDM).HasMaxLength(50);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.ZCDM).IsUnicode(false);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.ZYYSBH).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.ZYYSBH).HasMaxLength(50);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.ZYYSBH).IsUnicode(false);
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.GYSID).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.SFYY).IsRequired();
            modelBuilder.Entity<CEmployeeCode>().Property(_ => _.TSXZ).IsRequired();
            #endregion

            #region CMenu Definations
            modelBuilder.Entity<CMenu>().ToTable("CMenu");
            modelBuilder.Entity<CMenu>().HasKey(_ => _.Id);
            modelBuilder.Entity<CMenu>().Property(_ => _.Id).HasColumnName("ITEMID");
            modelBuilder.Entity<CMenu>().Property(_ => _.Id).IsRequired();
            modelBuilder.Entity<CMenu>().Property(_ => _.CreationTime).IsRequired();
            modelBuilder.Entity<CMenu>().Property(_ => _.MNAME).IsRequired();
            modelBuilder.Entity<CMenu>().Property(_ => _.MNAME).HasMaxLength(100);
            modelBuilder.Entity<CMenu>().Property(_ => _.MNAME).IsUnicode(false);
            modelBuilder.Entity<CMenu>().Property(_ => _.LINKURL).IsRequired();
            modelBuilder.Entity<CMenu>().Property(_ => _.LINKURL).HasMaxLength(200);
            modelBuilder.Entity<CMenu>().Property(_ => _.LINKURL).IsUnicode(false);
            modelBuilder.Entity<CMenu>().Property(_ => _.LINKIMG).IsRequired();
            modelBuilder.Entity<CMenu>().Property(_ => _.LINKIMG).HasMaxLength(200);
            modelBuilder.Entity<CMenu>().Property(_ => _.LINKIMG).IsUnicode(false);
            modelBuilder.Entity<CMenu>().Property(_ => _.MENUDESC).IsRequired();
            modelBuilder.Entity<CMenu>().Property(_ => _.MENUDESC).HasMaxLength(200);
            modelBuilder.Entity<CMenu>().Property(_ => _.MENUDESC).IsUnicode(false);
            modelBuilder.Entity<CMenu>().Property(_ => _.CSORT).IsRequired();
            modelBuilder.Entity<CMenu>().Property(_ => _.CSORT).HasPrecision(13, 4);
            modelBuilder.Entity<CMenu>().Property(_ => _.WZJZ).IsRequired();
            modelBuilder.Entity<CMenu>().Property(_ => _.WZJZ).HasMaxLength(50);
            modelBuilder.Entity<CMenu>().Property(_ => _.WZJZ).IsUnicode(true);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
