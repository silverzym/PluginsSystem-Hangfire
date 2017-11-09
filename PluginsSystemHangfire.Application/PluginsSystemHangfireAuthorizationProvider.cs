
using Abp.Authorization;

namespace PluginsSystemHangfire
{
    /// <summary>
    /// 权限验证
    /// </summary>
    public class PluginsSystemHangfireAuthorizationProvider : AuthorizationProvider
    {
        /// <summary>
        /// 定义权限
        /// </summary>
        /// <param name="context">Abp权限系统使用IPermissionChecker去检查授权</param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
        
        }
    }
}
