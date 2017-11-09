using System.Reflection;
using Abp.Modules;
using System.Data.Entity;

using Abp.EntityFramework;
using System;
using System.Configuration;
using Abp.Threading.BackgroundWorkers;
using PluginsSystemHangfire.EntityFramework;

namespace PluginsSystemHangfire
{
    [DependsOn(typeof(AbpEntityFrameworkModule))]
    public class PluginsSystemHangfireCoreModule : AbpModule
    {
        /// <summary>
        /// 预初始化：当应用启动后，第一次运行会先调用这个方法。
        /// 在依赖注入注册之前，你可以在这个方法中指定你需要注入的自定义启动类
        /// </summary>
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        /// <summary>
        /// 初始化：在这个方法中一般是来进行依赖注入的注册。
        /// 一般通过IocManager.RegisterAssemblyByConvention这个方法来实现。
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<ServiceDbContext>(null);

            Configuration.Caching.ConfigureAll(cache =>
            {
                // 绝对过期时间
                cache.DefaultAbsoluteExpireTime = TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["CacheExpireTime_Global"]));
                // 相对过期时间
                // cache.DefaultSlidingExpireTime = TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["CacheExpireTime_Global"]));
            });

            //为特定的缓存配置有效期
            //Configuration.Caching.Configure("CustomCache", cache =>
            //{
            //    cache.DefaultAbsoluteExpireTime = TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["CacheExpireTime_Global"]));
            //});
        }

        /// <summary>
        /// 提交初始化，一般用来解析依赖关系
        /// </summary>
        public override void PostInitialize()
        {
            // 直接实例化 后台工作者 
            // 后台工作者不同于后台工作。它们是运行在应用后台的简单独立线程
            //var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            //workManager.Add(IocManager.Resolve<TraceLogWorker>());
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
