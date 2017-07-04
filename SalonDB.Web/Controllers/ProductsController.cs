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
    public class ProductsController : Controller
    {
        LoginViewModel LoginInfo = new LoginViewModel();
        // GET: Products


        public ActionResult Index()
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            return View(SalonDB.Data.DBProvider.GetProducts(LoginInfo.StoreID));
        }
        
        [HttpPost]
        public ActionResult Insert(Product value)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            value.CompanyID = LoginInfo.CompanyID;
            value.StoreID = LoginInfo.StoreID;
            DBProvider.AddProduct(value);
            var data = DBProvider.GetProducts(LoginInfo.StoreID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Product value)

        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            value.CompanyID = LoginInfo.CompanyID;
            value.StoreID = LoginInfo.StoreID;
            DBProvider.UpdateProduct(value);
            var data = DBProvider.GetProducts(LoginInfo.StoreID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(Guid key)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            DBProvider.DeleteProduct(key);
            var data = DBProvider.GetProducts(LoginInfo.StoreID);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
