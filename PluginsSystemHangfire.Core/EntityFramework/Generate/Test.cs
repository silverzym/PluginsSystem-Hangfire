
using System;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace MicroService.EntityFramework
{
    /// <summary>
    /// Test Default DataBase
    /// </summary>
    [Table("Test")]
    public class Test : Entity
    {
        /// <summary>
        ///  
        /// </summary>
	    public string Name{ get; set; }
        /// <summary>
        ///  
        /// </summary>
	    public string value{ get; set; }
    }
}
