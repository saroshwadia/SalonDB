//using BusinessObjects;
using SalonDB.Data.Model;
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

namespace SalonDB.Web.Controllers
{
    public class LoginController : Controller
    {
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
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            MvcApplication.CurrentStaff = null;
            return RedirectToAction("Index", "Home");
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
            MvcApplication.CurrentStaff = null;

            if (new MyUserManager().IsValid(model.Email, model.Password, out StaffEnt))
            {

                MvcApplication.CurrentStaff = StaffEnt;

                var ident = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
                var c1 = new Claim(ClaimTypes.NameIdentifier, model.Email);
                var c2 = new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string");
                var c3 = new Claim(ClaimTypes.Name, $"{StaffEnt.FirstName} {StaffEnt.LastName}");
                //var c4 = new Claim(ClaimTypes.Role, eRoles.User);

                ident.AddClaim(c1);
                ident.AddClaim(c2);
                ident.AddClaim(c3);

                if (StaffEnt.Role == null)
                {
                    var c4 = new Claim(ClaimTypes.Role, eRoles.Guest);
                    ident.AddClaim(c4);
                }
                else
                {
                    foreach (var item in StaffEnt.Role.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        var c4 = new Claim(ClaimTypes.Role, item.Trim());
                        ident.AddClaim(c4);
                    }
                }

                oHttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, ident);
                //return RedirectToAction("Index", "Home"); // auth succeed 
                ReturnValue = true;
            }
            // invalid username or password
            //ModelState.AddModelError("", "Invalid Email or Password.");
            //return View();

            return ReturnValue;
        }
    }
}