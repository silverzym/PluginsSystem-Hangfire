using Abp.Application.Services;
using Abp.Dependency;
using Abp.WebApi.Client;
using Castle.Core.Logging;

using PluginsSystemHangfire.Common.DTO.Account;
using MicroService.Framework.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace PluginsSystemHangfire
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class PluginsSystemHangfireAppServiceBase : ApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        protected PluginsSystemHangfireAppServiceBase()
        {
        }
    }
}