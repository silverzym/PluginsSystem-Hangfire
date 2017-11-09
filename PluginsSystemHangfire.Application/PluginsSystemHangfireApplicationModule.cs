using System.Reflection;
using Abp.Modules;

namespace PluginsSystemHangfire
{
    /// <summary>
    /// 通过注解来定义依赖关系
    /// </summary>
    [DependsOn(typeof(PluginsSystemHangfireCoreModule))]
    public class PluginsSystemHangfireApplicationModule : AbpModule
    {
        /// <summary>
        /// 预初始化：当应用启动后，第一次运行会先调用这个方法。
        /// 在依赖注入注册之前，你可以在这个方法中指定你需要注入的自定义启动类
        /// </summary>
        public override void PreInitialize()
        {
            // 对“权限认证”注册
            Configuration.Authorization.Providers.Add<PluginsSystemHangfireAuthorizationProvider>();
        }

        /// <summary>
        /// 初始化：在这个方法中一般是来进行依赖注入的注册。
        /// 一般通过IocManager.RegisterAssemblyByConvention这个方法来实现。
        /// </summary>
        public override void Initialize()
        {
            //把当前程序集的特定类或接口注册到依赖注入容器中
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// 提交初始化，一般用来解析依赖关系
        /// </summary>
        public override void PostInitialize()
        {
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
