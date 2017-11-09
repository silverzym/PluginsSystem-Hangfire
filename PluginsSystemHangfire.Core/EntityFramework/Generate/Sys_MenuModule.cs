// =================================================================
//
// =================================================================

using System;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace MicroService.EntityFramework
{
    /// <summary>
    /// Test Default DataBase
    /// </summary>
    [Table("Sys_MenuModule")]
    public class Sys_MenuModule : Entity
    {
        /// <summary>
        /// 编码
        /// </summary>
	    public string Code{ get; set; }
        /// <summary>
        /// 名称
        /// </summary>
	    public string Name{ get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
	    public string LinkUrl{ get; set; }
        /// <summary>
        /// 状态
        /// </summary>
	    public int? Status{ get; set; }
    }
}
