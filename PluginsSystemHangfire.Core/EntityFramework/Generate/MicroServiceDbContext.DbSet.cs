namespace MicroService.EntityFramework
{
    using System.Data.Common;
    using Abp.EntityFramework;
    using System.Data.Entity;

    public partial class MicroServiceDbContext
    {
        public virtual IDbSet<Sys_MenuModule> Sys_MenuModule { get; set; } 
        public virtual IDbSet<Sys_LSH> Sys_LSH { get; set; } 
        public virtual IDbSet<Sys_User> Sys_User { get; set; } 
        public virtual IDbSet<Sys_Menus> Sys_Menus { get; set; } 
        public virtual IDbSet<Test> Test { get; set; } 
    }
}
