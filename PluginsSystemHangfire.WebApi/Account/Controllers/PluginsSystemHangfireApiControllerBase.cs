using Abp.Dependency;
using Abp.WebApi.Controllers;
using MicroService.Framework.Identity;

using PluginsSystemHangfire.Common.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PluginsSystemHangfire.Controllers
{
    public class PluginsSystemHangfireApiControllerBase : AbpApiController
    {
        protected PluginsSystemHangfireApiControllerBase()
        {
        }
    }
}
