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
    public class SupplierController : Controller
    {
        LoginViewModel LoginInfo = new LoginViewModel();

        // GET: Products
        public ActionResult Index()
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            return View(SalonDB.Data.DBProvider.GetSuppliers(LoginInfo.CompanyID));
        }
        
        [HttpPost]
        public ActionResult Insert(Supplier value)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            value.CompanyID = LoginInfo.CompanyID;
            DBProvider.AddSupplier(value);
            var data = DBProvider.GetSuppliers(LoginInfo.CompanyID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Supplier value)

        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            DBProvider.UpdateSupplier(value);
            var data = DBProvider.GetSuppliers(LoginInfo.CompanyID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(Guid key)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            DBProvider.DeleteSupplier(key);
            var data = DBProvider.GetSuppliers(LoginInfo.CompanyID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
