using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire
{
    /// <summary>
    /// 全局静态属性或者方法
    /// </summary>
    public class PluginsSystemHangfireContext
    {
        /// <summary>
        /// 是否启用Redis
        /// </summary>
        public static bool UseRedis
        {
            get
            {
                string useRedis = System.Web.Configuration.WebConfigurationManager.AppSettings["UseRedis"];

                return bool.Parse(useRedis ?? "false");
            }
        }
    }
}
