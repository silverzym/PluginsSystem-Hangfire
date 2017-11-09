using Abp.Runtime.Validation;
using System;

namespace PluginsSystemHangfire.Common.DTO.Account
{
    /// <summary>
    /// 输入参数
    /// </summary>
    [DisableValidation]
    public class SetCacheInput
    {
        /// <summary>
        /// 登录名称
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 用户ID，即：id
        /// </summary>
        public Guid USERID { get; set; }
        
        /// <summary>
        /// 人员ID，即：StaffId 
        /// </summary>
        public Guid RYID { get; set; }

        /// <summary>
        /// 人员姓名，即：UserName
        /// </summary>
        public string RYXM { get; set; }

        /// <summary>
        /// 医院ID，即：TenantId
        /// </summary>
        public int TenantId { get; set; }
        /// <summary>
        /// 人员Id，即：RoleId
        /// </summary>
        public string ROLEID { get; set; }
        
    }
}
