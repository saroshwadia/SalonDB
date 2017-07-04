using System;
using System.Web.Mvc;
using SalonDB.Data.Core.Domain;
using SalonDB.Data;
using SalonDB.Web;
using SalonDB.Web.Models;

namespace SalonManagement.Web.Controllers
{
    public class ServiceController : Controller
    {
        LoginViewModel LoginInfo = new LoginViewModel();

        // GET: Products
        public ActionResult Index()
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            return View(SalonDB.Data.DBProvider.GetServices(LoginInfo.StoreID));
        }
        
        [HttpPost]
        public ActionResult Insert(Service value)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            value.CompanyID = LoginInfo.CompanyID;
            value.StoreID = LoginInfo.StoreID;
           DBProvider.AddService(value);
            var data = DBProvider.GetServices(LoginInfo.StoreID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Service value)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            DBProvider.UpdateService(value);
            var data = DBProvider.GetServices(LoginInfo.StoreID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(Guid key)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
           DBProvider.DeleteService(key);
            var data = DBProvider.GetServices(LoginInfo.StoreID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
