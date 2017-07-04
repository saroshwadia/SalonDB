using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalonDB.Data.Core.Domain;
using System.Collections;
using Syncfusion.JavaScript.DataSources;
using Syncfusion.Linq;
using SalonDB.Data;
using SalonDB.Web.Models;
using SalonDB.Web;

namespace SalonManagement.Web.Controllers
{
    public class StoreController : Controller
    {
        LoginViewModel LoginInfo = new LoginViewModel();

        // GET: Products
        public ActionResult Index()
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            return View(SalonDB.Data.DBProvider.GetStores(LoginInfo.CompanyID));
        }
        
        [HttpPost]
        public ActionResult Insert(Store value)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            value.CompanyID = LoginInfo.CompanyID;
            DBProvider.AddStore(value);
            var data = DBProvider.GetStores(LoginInfo.CompanyID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Store value)

        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            DBProvider.UpdateStore(value);
            var data = DBProvider.GetStores(LoginInfo.CompanyID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(Guid key)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            DBProvider.DeleteStore(key);
            var data = DBProvider.GetStores(LoginInfo.CompanyID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
