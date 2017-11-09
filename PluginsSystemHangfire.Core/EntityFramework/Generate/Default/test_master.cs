using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire.EntityFramework.Generate
{
    /// <summary>
    /// 用于跨库测试
    /// </summary>
    public class test_master : Entity<int>
    {
        public DateTime creationtime { get; set; }

        public string name { get; set; }
        public string value { get; set; }
    }
}
