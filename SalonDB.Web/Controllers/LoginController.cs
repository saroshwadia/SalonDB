//using BusinessObjects;
using SalonDB.Data.Core.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SalonDB.Web.App_Start;
using SalonDB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using SalonDB.Data.Persistence;
using SalonDB.Data;

namespace SalonDB.Web.Controllers
{
    public class LoginController : Controller
    {

        UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());

        // GET: Login form MyUserName
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl) //Login(string username, string password)
        {
            if (this.LogMein(model, returnUrl, this.HttpContext))
            {
                return RedirectToAction("Index", "Home"); // auth succeed 
            }
            else
            {
                ModelState.AddModelError("", "Invalid Email or Password.");
                return View();
            }           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var ActionName = "About";
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //MvcApplication.CurrentStaff = null;
            //return RedirectToAction("Index", "Home");

            return RedirectToAction(ActionName, new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = ActionName, fromLogout = true }));

        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public bool LogMein(LoginViewModel model, string returnUrl, HttpContextBase oHttpContext)
        {
            var ReturnValue = false;
            var StaffEnt = new Staff();
            //MvcApplication.CurrentStaff = null;
            var js = new System.Web.Script.Serialization.JavaScriptSerializer();
            
            if (new MyUserManager().IsValid(unitOfWork, model.Email, model.Password, out StaffEnt))
            {

                var LoginViewModelEnt = MvcApplication.ConvertStaff(StaffEnt);
                var UserData = js.Serialize(LoginViewModelEnt);

                //MvcApplication.CurrentStaff = StaffEnt;

                var ident = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
                var c1 = new Claim(ClaimTypes.NameIdentifier, model.Email);
                var c2 = new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string");
                var c3 = new Claim(ClaimTypes.Name, $"{StaffEnt.FirstName} {StaffEnt.LastName}");
                var c4 = new Claim(ClaimTypes.Email , $"{StaffEnt.Email}");
                var c5 = new Claim(ClaimTypes.UserData, UserData);
             
                ident.AddClaim(c1);
                ident.AddClaim(c2);
                ident.AddClaim(c3);
                ident.AddClaim(c4);
                ident.AddClaim(c5);

                if (StaffEnt.Role == null)
                {
                    var cRole = new Claim(ClaimTypes.Role, eRoles.Guest);
                    ident.AddClaim(cRole);
                }
                else
                {
                    foreach (var item in StaffEnt.Role.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        var cRole = new Claim(ClaimTypes.Role, item.Trim());
                        ident.AddClaim(cRole);
                    }
                }

                oHttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, ident);
                //return RedirectToAction("Index", "Home"); // auth succeed 
                ReturnValue = true;

                //Save LstLogin for the current user.
                StaffEnt.LastLogin = DateTime.Now;
                unitOfWork.Commit();

            }
            // invalid username or password
            //ModelState.AddModelError("", "Invalid Email or Password.");
            //return View();

            return ReturnValue;
        }
    }
}