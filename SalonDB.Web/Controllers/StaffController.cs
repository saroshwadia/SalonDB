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
using SalonDB.Web;
using SalonDB.Web.Models;

namespace SalonManagement.Web.Controllers
{
    public class StaffController : Controller
    {
        LoginViewModel LoginInfo = new LoginViewModel();

        // GET: Products
        public ActionResult Index()
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            return View(SalonDB.Data.DBProvider.GetStaffs(LoginInfo.StoreID));
        }
        
        [HttpPost]
        public ActionResult Insert(Staff value)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            DBProvider.AddStaff(value);
            var data = DBProvider.GetStaffs(LoginInfo.StoreID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Staff value)

        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            value.CompanyID = LoginInfo.CompanyID;
            value.StoreID = LoginInfo.StoreID;
            DBProvider.UpdateStaff(value);
            var data = DBProvider.GetStaffs(LoginInfo.StoreID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(Guid key)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            DBProvider.DeleteStaff(key);
            var data = DBProvider.GetStaffs(LoginInfo.StoreID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
