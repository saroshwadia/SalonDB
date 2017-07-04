#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using SalonDB.Data.Core.Domain;
using SalonDB.Web.Models;
using System.Security.Principal;
//using BusinessObjects;

namespace SalonDB.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    Server.ClearError();
        //    Response.Redirect("/Home/Error");
        //}

        public static LoginViewModel ConvertStaff(Staff staffEnt)
        {
            var ReturnValue = new Models.LoginViewModel()
            {
                FirstName = staffEnt.FirstName,
                LastName = staffEnt.LastName,
                StaffID = (Guid)staffEnt.StaffID,
                CompanyID = (Guid)staffEnt.CompanyID,
                StoreID = (Guid)staffEnt.StoreID,
                Email = staffEnt.Email
            };

            return ReturnValue;
        }

        public static Staff ConvertStaff(LoginViewModel loginViewModelEnt)
        {
            var ReturnValue = new Staff()
            {
                FirstName = loginViewModelEnt.FirstName,
                LastName = loginViewModelEnt.LastName,
                StaffID = (Guid)loginViewModelEnt.StaffID,
                CompanyID = (Guid)loginViewModelEnt.CompanyID,
                StoreID = (Guid)loginViewModelEnt.StoreID,
                Email = loginViewModelEnt.Email
            };

            return ReturnValue;
        }

        public static TEntity GetLoginInfo<TEntity>(System.Security.Principal.IIdentity userIdentity) where TEntity : class
        {
            TEntity ReturnValue = null;
            var IdentityClaimsKey = "/identity/claims/userdata";
            var js = new System.Web.Script.Serialization.JavaScriptSerializer();
            var oCI = userIdentity as System.Security.Claims.ClaimsIdentity;

            if (oCI != null)
            {
                var oClaims = oCI.Claims;
                if (oClaims != null)
                {
                    IEnumerable<System.Security.Claims.Claim> claims = oClaims;
                    foreach (var item in claims.Where(c => c.Type.ToLower().EndsWith($"{IdentityClaimsKey.ToLower()}")))
                    {
                        ReturnValue = js.Deserialize<TEntity>(item.Value);
                    }
                }
            }

            return ReturnValue;
        }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );
        }

        public static object[] AddCustomer(string customerName, string customerPhone, string customerEmail, LoginViewModel LoginInfo, Data.Persistence.UnitOfWork unitOfWork)
        {
            object[] ReturnValue = new object[2];
            var FirstName = string.Empty;
            var LastName = string.Empty;
            var Name = customerName.Split(' ');
            var MatchFound = new List<Data.Core.Domain.Customer>();
            var CustomerEnt = new Data.Core.Domain.Customer();
            var CustomerViewModelCol = new List<CustomerViewModel>();

            if (Name.Length > 1)
            {
                FirstName = Name[0];
                LastName = customerName.Substring(FirstName.Length).Trim();

                MatchFound = unitOfWork.Customers.FindAll(c => c.CompanyID == LoginInfo.CompanyID && c.FirstName.ToLower() == FirstName.ToLower() && c.LastName.ToLower() == LastName.ToLower()).ToList();
            }
            else
            {
                FirstName = Name[0];
                MatchFound = unitOfWork.Customers.FindAll(c => c.CompanyID == LoginInfo.CompanyID && c.FirstName.ToLower() == FirstName.ToLower()).ToList();
            }

            if (MatchFound.Count > 0)
            {
                ReturnValue[0] = MatchFound[0].CustomerID.ToString();
            }
            else
            {
                CustomerEnt.CustomerID = Guid.NewGuid();
                CustomerEnt.CompanyID = LoginInfo.CompanyID;
                CustomerEnt.FirstName = FirstName;
                CustomerEnt.LastName = LastName;
                CustomerEnt.Phone = customerPhone;
                CustomerEnt.Email = customerEmail;

                unitOfWork.Customers.Add(CustomerEnt);
                unitOfWork.Commit();

                ReturnValue[0] = CustomerEnt.CustomerID.ToString();
            }

            foreach (var item in unitOfWork.Customers.FindAll(c => c.CompanyID == (Guid)LoginInfo.CompanyID).ToList())
            {
                CustomerViewModelCol.Add(new CustomerViewModel { CustomerID = item.CustomerID, Name = $"{item.FirstName} {item.LastName}" });
            }

            ReturnValue[1] = CustomerViewModelCol;

            return ReturnValue;
        }
    }

    public static class WebUtil
    {
        public static bool IsInAnyRole(this IPrincipal principal, params string[] roles)
        {
            return roles.Any(principal.IsInRole);
        }
    }
}
