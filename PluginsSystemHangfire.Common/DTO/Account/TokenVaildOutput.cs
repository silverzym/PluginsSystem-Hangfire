using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire.Common.DTO.Account
{
    /// <summary>
    /// 服务凭证是否有效
    /// </summary>
    public class TokenVaildOutput
    {
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Vaild { get; set; }

        /// <summary>
        /// 说明信息
        /// </summary>
        public string Message { get; set; }
    }
}
