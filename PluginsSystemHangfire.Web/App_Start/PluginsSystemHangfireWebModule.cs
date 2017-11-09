using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Configuration.Startup;
using System;
using Abp.Web.Mvc.ModelBinding.Binders;
using System.Linq;
using Abp.Web.Mvc.Authorization;
using Abp.Runtime.Session;
using Abp.Dependency;
using System.Web.Http;
using Abp.Runtime.Caching.Redis;
using Abp.Hangfire;

namespace PluginsSystemHangfire.Web
{
    /// <summary>
    /// 通过注解来定义依赖关系
    /// </summary>
    [DependsOn(
        typeof(AbpWebMvcModule),
        typeof(PluginsSystemHangfireCoreModule),
        typeof(PluginsSystemHangfireApplicationModule),
        typeof(PluginsSystemHangfireWebApiModule),
        typeof(AbpRedisCacheModule),
        typeof(AbpHangfireModule)
        )]
    public class PluginsSystemHangfireWebModule : AbpModule
    {
        /// <summary>
        /// 预初始化：当应用启动后，第一次运行会先调用这个方法。
        /// 在依赖注入注册之前，你可以在这个方法中指定你需要注入的自定义启动类
        /// </summary>
        public override void PreInitialize()
        {
            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<PluginsSystemHangfireNavigationProvider>();

            Configuration.Caching.UseRedis();
        }

        /// <summary>
        /// 初始化：在这个方法中一般是来进行依赖注入的注册。
        /// 一般通过IocManager.RegisterAssemblyByConvention这个方法来实现。
        /// </summary>
        public override void Initialize()
        {
            //把当前程序集的特定类或接口注册到依赖注入容器中
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //GlobalConfiguration.Configuration.Routes.Add("",RouteConfig.RegisterRou);

            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;
        }

        /// <summary>
        /// 提交初始化，一般用来解析依赖关系
        /// </summary>
        public override void PostInitialize()
        {
            // 添加 自定义的权限验证
            //GlobalFilters.Filters.Add(new PluginsSystemHangfireWebAuthorizationProvider());

            base.PostInitialize();
        }

        /// <summary>
        /// 应用关闭时调用
        /// </summary>
        public override void Shutdown()
        {
            base.Shutdown();
        }
    }
}
