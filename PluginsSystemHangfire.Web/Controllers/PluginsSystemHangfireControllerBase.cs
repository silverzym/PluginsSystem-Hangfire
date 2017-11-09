using Abp.Dependency;
using Abp.Web.Mvc.Controllers;

using PluginsSystemHangfire.Common.DTO.Account;
using MicroService.Framework.Identity;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace PluginsSystemHangfire.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class PluginsSystemHangfireControllerBase : AbpController
    {
        protected PluginsSystemHangfireControllerBase()
        {
        }
    }
}