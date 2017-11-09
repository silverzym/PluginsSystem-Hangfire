using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using System.Web.Mvc;

namespace PluginsSystemHangfire.Web
{
    public class MvcApplication : AbpWebApplication<PluginsSystemHangfireWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );

            // 添加异常处理 Controller 
            RegisterGlobalFilters(GlobalFilters.Filters);

            base.Application_Start(sender, e);
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new PluginsSystemHangfireHandlerErrorProvider());
        }
    }
}
