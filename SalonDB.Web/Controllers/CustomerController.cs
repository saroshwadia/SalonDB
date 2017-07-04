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
    public class CustomerController : Controller
    {
        // GET: Products
        LoginViewModel LoginInfo = new LoginViewModel();

        public ActionResult Index()
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            var Data = SalonDB.Data.DBProvider.GetCustomers(LoginInfo.CompanyID);
            return View(Data);
        }
        
        [HttpPost]
        public ActionResult Insert(Customer value)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            value.CompanyID = LoginInfo.CompanyID;
            value.StoreID = LoginInfo.StoreID;

            DBProvider.AddCustomer(value);
            var data = DBProvider.GetCustomers();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Customer value)

        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            DBProvider.UpdateCustomer(value);
            var data = DBProvider.GetCustomers(LoginInfo.CompanyID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(Guid key)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            DBProvider.DeleteCustomer(key);
            var data = DBProvider.GetCustomers(LoginInfo.CompanyID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
