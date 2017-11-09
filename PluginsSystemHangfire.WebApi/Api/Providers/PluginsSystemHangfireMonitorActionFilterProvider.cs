using MicroService.Framework.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PluginsSystemHangfire
{
    /// <summary>
    /// 监控 WebApi 接口服务
    /// </summary>
    public class PluginsSystemHangfireMonitorActionFilterProvider : ActionFilterAttribute
    {
        /// <summary>
        /// 记录监控接口执行日志
        /// </summary>
        private const string Key = "_Action_Duration_";

        /// <summary>
        /// 在调用操作方法之前发生
        /// </summary>
        /// <param name="actionContext">包含执行操作的信息。</param>
        /// <param name="cancellationToken">传播有关应取消操作的通知。</param>
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var stopWatch = new System.Diagnostics.Stopwatch();

            var actionName = actionContext.ActionDescriptor.ActionName;

            var controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;


            actionContext.Request.Properties[Key] = stopWatch;

            stopWatch.Start();

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        /// <summary>
        /// 在调用操作方法之后发生。
        /// </summary>
        /// <param name="actionExecutedContext">包含执行操作的信息</param>
        /// <param name="cancellationToken">传播有关应取消操作的通知</param>
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (!actionExecutedContext.Request.Properties.ContainsKey(Key))
                return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);

            var stopWatch = actionExecutedContext.Request.Properties[Key] as System.Diagnostics.Stopwatch;

            if (stopWatch != null)
            {
                stopWatch.Stop();

                var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

                var controllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;

                string log = string.Format("[execution controller：{0} - action：{1} take {2} time.]", controllerName, actionName, stopWatch.ElapsedMilliseconds,DateTime.Now.Millisecond);

                SystemLogger.Instance.Logger.Info(log);
            }

            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }

    /// <summary>
    /// 不记录监控接口执行日志
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    public class NoMonitorAttributer : Attribute { }
}
