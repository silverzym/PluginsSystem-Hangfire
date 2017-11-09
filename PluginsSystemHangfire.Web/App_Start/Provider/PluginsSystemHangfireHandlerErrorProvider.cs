using Abp.Dependency;
using Abp.Web.Models;
using Abp.Web.Mvc.Models;
using Castle.Core.Logging;
using MicroService.Framework.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluginsSystemHangfire.Web
{
    public class PluginsSystemHangfireHandlerErrorProvider : HandleErrorAttribute
    {
        /// <summary>
        /// 重写异常处理
        /// </summary>
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                #region Ajax
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        Success = false,
                        TargetUrl = "",
                        Error = new ErrorInfo(filterContext.Exception.Message),
                        UnAuthorizedRequest = true,
                        Result = ""
                    }
                };
                #endregion

                // 写入日志
                SystemLogger.Instance.Logger.Error(Abp.Json.JsonSerializationHelper.SerializeWithType(filterContext.Result));

            }
            else
            {
                #region View
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                // 写入日志
                SystemLogger.Instance.Logger.Error(Abp.Json.JsonSerializationHelper.SerializeWithType(model));

                filterContext.Result = new ViewResult()
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary(model),
                    TempData = filterContext.Controller.TempData
                };
                #endregion
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            // 启用 IIS 自定义错误日志
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}