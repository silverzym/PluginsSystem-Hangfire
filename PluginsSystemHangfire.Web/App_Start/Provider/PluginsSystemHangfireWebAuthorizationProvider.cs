using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Dependency;
using PluginsSystemHangfire.Common.DTO.Account;


namespace PluginsSystemHangfire.Web
{
    ///// <summary>
    ///// 授权过程
    ///// </summary>
    //public class PluginsSystemHangfireWebAuthorizationProvider : AuthorizeAttribute
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

    //    protected override bool AuthorizeCore(HttpContextBase httpContext)
    //    {
    //        string token = GetRequsetAccessToken();

    //        TokenVaildOutput result = null;

    //        if (PluginsSystemHangfireContext.UseRedis)
    //            result = IocManager.Instance.Resolve<IAccountRedisAppService>().GetTokenVaild(token);
    //        else
    //            result = IocManager.Instance.Resolve<IAccountDbAppService>().GetTokenVaild(token);

    //        if (result == null)
    //            return false;

    //        return result.Vaild;
    //    }
        
    //    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    //    {
    //        filterContext.Result = new JsonResult
    //        {
    //            Data = new
    //            {
    //                result = string.Empty,
    //                success = false,
    //                error = "服务端拒绝访问：请检查，是否具有服务令牌、权限、是否登录了？",
    //                targetUrl = string.Empty,
    //                statusCode = filterContext.HttpContext.Response.StatusCode
    //            },
    //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
    //        };
    //        return;
    //    }

    //}
}