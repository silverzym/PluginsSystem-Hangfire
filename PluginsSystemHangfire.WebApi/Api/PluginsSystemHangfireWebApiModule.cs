using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Swashbuckle.Application;
using System.Linq;
using System;
using System.IO;
using PluginsSystemHangfire.Api.Providers;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;

namespace PluginsSystemHangfire
{
    /// <summary>
    /// 通过注解来定义依赖关系
    /// </summary>
    [DependsOn(typeof(AbpWebApiModule), typeof(PluginsSystemHangfireApplicationModule))]
    public class PluginsSystemHangfireWebApiModule : AbpModule
    {
        /// <summary>
        /// 预初始化：当应用启动后，第一次运行会先调用这个方法。
        /// 在依赖注入注册之前，你可以在这个方法中指定你需要注入的自定义启动类
        /// </summary>
        public override void PreInitialize()
        {
            base.PreInitialize();
            Configuration.Localization.IsEnabled = false;
        }

        /// <summary>
        /// 初始化：在这个方法中一般是来进行依赖注入的注册。
        /// 一般通过IocManager.RegisterAssemblyByConvention这个方法来实现。
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // 注册 自定义的路由规则，只适用于 静态APIController
            // WebApiConfig.Register(GlobalConfiguration.Configuration);
            // 授权过滤
            // Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new PluginsSystemHangfireAuthorizationServerProvider());

            // 异常过滤
            // Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new PluginsSystemHangfireExceptionFilterProvider());

            // Web Api 监控
            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new PluginsSystemHangfireMonitorActionFilterProvider());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(PluginsSystemHangfireApplicationModule).Assembly, "app").WithConventionalVerbs()
                .Build();

            // Web API跨域问题 解决方案
            var cors = new EnableCorsAttribute("*", "*", "*");
            GlobalConfiguration.Configuration.EnableCors(cors);

            ConfigureSwaggerUi();
        }

        /// <summary>
        /// 提交初始化，一般用来解析依赖关系
        /// </summary>
        public override void PostInitialize()
        {
            base.PostInitialize();
            //Abp默认为输出小写字母开头的json，更改为Newtonsoft.Json默认输出
            Configuration.Modules.AbpWebApi()
                    .HttpConfiguration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new DefaultContractResolver();
        }

        /// <summary>
        /// 应用关闭时调用
        /// </summary>
        public override void Shutdown()
        {
            base.Shutdown();
        }

        // <summary>
        /// 配置SwaggerUi
        /// </summary>
        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v", "PluginsSystemHangfire.APIs 文档");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    //将application层中的注释添加到SwaggerUI中
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var commentsFileName = "Bin//PluginsSystemHangfire.Application.XML";
                    var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                    //将注释的XML文档添加到SwaggerUI中
                    c.IncludeXmlComments(commentsFile);
                })
                .EnableSwaggerUi("apis/{*assetPath}", b =>
                {
                    b.InjectJavaScript(Assembly.GetExecutingAssembly(), "PluginsSystemHangfire.Scripts.swagger.js");
                });
        }
    }
}
