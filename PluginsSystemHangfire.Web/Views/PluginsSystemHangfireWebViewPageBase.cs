using Abp.Web.Mvc.Views;

namespace PluginsSystemHangfire.Web.Views
{
    public abstract class PluginsSystemHangfireWebViewPageBase : PluginsSystemHangfireWebViewPageBase<dynamic>
    {

    }

    public abstract class PluginsSystemHangfireWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected PluginsSystemHangfireWebViewPageBase()
        {           
        }
    }
}