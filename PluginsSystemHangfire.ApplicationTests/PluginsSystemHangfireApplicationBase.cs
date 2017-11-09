using Abp.Modules;
using Abp.TestBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire.ApplicationTests
{
    public class PluginsSystemHangfireApplicationBase : AbpIntegratedTestBase<PluginsSystemHangfireTestModule>
    {
        protected PluginsSystemHangfireApplicationBase()
        {
        }

        protected override void PreInitialize()
        {
            base.PreInitialize();
        }

    }

    [DependsOn(
         typeof(PluginsSystemHangfireCoreModule),
         typeof(PluginsSystemHangfireApplicationModule)
     )]
    public class PluginsSystemHangfireTestModule : AbpModule
    {

    }
}
