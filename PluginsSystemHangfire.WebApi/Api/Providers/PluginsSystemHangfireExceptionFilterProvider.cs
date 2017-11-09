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
using System.Web.Http.Filters;
using MicroService.Framework.Logger;

namespace PluginsSystemHangfire.Api.Providers
{
    /// <summary>
    /// 异常过滤器
    /// </summary>
    public class PluginsSystemHangfireExceptionFilterProvider : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // 记录日志
            SystemLogger.Instance.Logger.ErrorFormat(
                actionExecutedContext.Request.RequestUri.ToString(),
                actionExecutedContext.Exception.Message);

            actionExecutedContext.Request.CreateErrorResponse(
                HttpStatusCode.BadGateway,
                actionExecutedContext.Exception.Message);
        }
    }
}