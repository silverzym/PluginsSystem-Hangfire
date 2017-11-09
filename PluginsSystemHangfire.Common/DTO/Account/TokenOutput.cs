
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire.Common.DTO.Account
{
    /// <summary>
    /// 输出信息
    /// </summary>
    public class TokenOutput
    {
        /// <summary>
        /// 是否有效 Valid=true 有登录用户信息 Valid=false 没有信息，需要重新登录
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }
    }
}
