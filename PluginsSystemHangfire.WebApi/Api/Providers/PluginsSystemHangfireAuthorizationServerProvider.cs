using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Threading;
using Abp.UI;

using System.Web;
using PluginsSystemHangfire.Common.DTO.Account;

namespace PluginsSystemHangfire.Api.Providers
{
    /// <summary>
    /// 权限验证
    /// </summary>
    //public class PluginsSystemHangfireAuthorizationServerProvider : AuthorizeAttribute
    //{
    //    private string GetRequsetAccessToken()
    //    {
    //        string token = string.Empty;

    //        string menthodType = HttpContext.Current.Request.HttpMethod.ToLower();
    //        switch (menthodType)
    //        {
    //            case "get":
    //                token = HttpContext.Current.Request["token"];
    //                if (string.IsNullOrWhiteSpace(token))
    //                {
    //                    return null;
    //                }
    //                return token;
    //            default:
    //                token = HttpContext.Current.Request.Headers.Get("access_token");
    //                if (string.IsNullOrWhiteSpace(token))
    //                {
    //                    return null;
    //                }
    //                return token;
    //        }
    //    }

    //    /// <summary>
    //    /// 是否授权
    //    /// </summary>
    //    /// <param name="actionContext"></param>
    //    /// <returns></returns>
    //    protected override bool IsAuthorized(HttpActionContext actionContext)
    //    {
    //        string url = actionContext.Request.RequestUri.ToString().ToLower();

    //        if (url.Contains("localhost"))
    //        {
    //            return true;
    //        }

    //        string token = GetRequsetAccessToken();

    //        TokenVaildOutput result = null;

    //        if (PluginsSystemHangfireContext.UseRedis)
    //            result = IocManager.Instance.Resolve<IAccountRedisAppService>().GetTokenVaild(token);
    //        else
    //            result = IocManager.Instance.Resolve<IAccountDbAppService>().GetTokenVaild(token);

    //        if (result==null)
    //            return false;

    //        return result.Vaild;
    //    }
        
    //    /// <summary>
    //    /// 处理授权失败时返回json,避免跳转登录页
    //    /// </summary>
    //    /// <param name="actionContext"></param>
    //    protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
    //    {
    //        throw new UserFriendlyException("服务端拒绝访问：你没有权限，或者掉线了");
    //    }
    //}
}