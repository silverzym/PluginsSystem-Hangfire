using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire._System
{
    public class RedisKey
    {
        /// <summary>
        /// 账户区域·登录用户·相对过期时间
        /// </summary>
        public readonly static int Area_Account_Client_Time = int.Parse(ConfigurationManager.AppSettings["CacheExpireTime_Global_Account"]);
    }
}
