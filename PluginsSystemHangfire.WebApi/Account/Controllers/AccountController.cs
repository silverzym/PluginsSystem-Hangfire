//using Abp.Domain.Uow;
//using Abp.UI;
//using Abp.Web.Models;
//using Abp.WebApi.Controllers;
//using MicroService.Controllers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Transactions;
//using System.Web.Http;

//namespace PluginsSystemHangfire.Api.Controllers
//{
//    public class AccountController : PluginsSystemHangfireApiControllerBase
//    {
//        //private readonly ITestAppService _usersApp;
//        //private readonly ITest1AppService _usersApp1;

//        //public AccountController(
//        //    ITestAppService usersApp,
//        //    ITest1AppService usersApp1)
//        //{
//        //    this._usersApp = usersApp;
//        //    this._usersApp1 = usersApp1;
//        //}
        
//        [UnitOfWork(timeout:10)]
//        [HttpGet]
//        [Route("api/Account/Authenticate")]
//        public AjaxResponse Authenticate()
//        {
//            //_usersApp.InsertDefaultDbContextData();
//            //_usersApp1.InsertFirstDbContextData();

//            return new AjaxResponse();
//        }
//        /// <summary>
//        /// 跨不同服务器 操作数据库 插入数据
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        [Route("api/t/GetBeatLibraryOperationInsert")]
//        public AjaxResponse GetBeatLibraryOperationInsert()
//        {
//            var r = this.CurrentUser;
//            //ServiceCacheManager.Instance.Set("a", "string");
//            //_usersApp.InsertDefaultDbContextData();
//            //_usersApp1.InsertFirstDbContextData();

//            return new AjaxResponse();
//        }

//        /// <summary>
//        /// 跨不同服务器 操作数据库 插入数据 抛出异常
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        [Route("api/t/GetBeatLibraryOperationInsertError")]
        
//        public AjaxResponse GetBeatLibraryOperationInsertError(int id)
//        {
//            throw new UserFriendlyException("仅仅做测试事务，");
//        }
//    }
//}
