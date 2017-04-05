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
using SalonDB.Data.Model;
//using BusinessObjects;

namespace SalonDB.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        static bool _FirstTime = true;
        public static bool FirstTime
        {
            get
            {
                return _FirstTime;
            }
            set
            {
                _FirstTime = value;
            }
        }


        /// <summary>
        /// Global variable storing Staff Entity.
        /// </summary>
        static Staff _CurrentStaff;

        /// <summary>
        /// Get or set the static Staff Entity.
        /// </summary>
        public static Staff CurrentStaff
        {
            get
            {
                return _CurrentStaff;
            }
            set
            {
                _CurrentStaff = value;
            }
        }

        /// <summary>
        /// Global variable storing Staff Entity.
        /// </summary>
        static Company _CurrentCompany;

        /// <summary>
        /// Get or set the static Staff Entity.
        /// </summary>
        public static Company CurrentCompany
        {
            get
            {
                _CurrentCompany = null;

                if (_CurrentStaff != null)
                {
                    if (_CurrentStaff.CompanyID != null)
                    {
                        _CurrentCompany = _CurrentStaff.Company; 
                    }
                }

                return _CurrentCompany;
            }
        }

        static Models.POSViewModel _POSViewModel = null;

        public static Models.POSViewModel POSViewModel
        {
            get
            {
                return _POSViewModel;
            }
            set
            {
                _POSViewModel = value;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            this.ConnectToDB();
        }

        public void ConnectToDB()
        {
            SalonDB.Data.DBProviderES.ConnectToDB();
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
    }
}
