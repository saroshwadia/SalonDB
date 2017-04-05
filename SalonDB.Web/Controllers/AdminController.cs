using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalonDB.Web;

namespace SalonDB.Web.Controllers
{
    public class AdminController : Controller
    {

        [AuthorizeRoles(eRoles.Admin)]
        public ActionResult Index()
        {
            return View();
        }
    }
}