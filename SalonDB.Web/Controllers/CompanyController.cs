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

namespace SalonDB.Web.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View(SalonDB.Data.DBProvider.GetCompanys());
        }
        
        [HttpPost]
        public ActionResult Insert(Company value)
        {
            DBProvider.AddCompany(value);
            var data = DBProvider.GetCompanys();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(Company value)

        {
            DBProvider.UpdateCompany(value);
            var data = DBProvider.GetCompanys();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Remove(Guid key)
        {
            DBProvider.DeleteCompany(key);
            var data = DBProvider.GetCompanys();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
