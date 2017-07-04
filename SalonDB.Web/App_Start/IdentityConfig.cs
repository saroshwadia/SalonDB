#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SalonDB.Web.Models;
using System.Diagnostics;

namespace SalonDB.Web
{

    public static class Logger
    {
        public static void Log(string fmt, params object[] args)
        {
            string s = string.Format(fmt, args);
            Debug.WriteLine(s);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.    
    public class ApplicationUserManager : UserManager<SimpleUser>
    {
        public ApplicationUserManager(IUserStore<SimpleUser> store) : base(store)
        {
            this.UserLockoutEnabledByDefault = false;
            this.DefaultAccountLockoutTimeSpan = new TimeSpan(0, 0, 0);
            this.MaxFailedAccessAttemptsBeforeLockout = 0;
        }

        public override Task<SimpleUser> FindAsync(string userName, string password)
        {
            Logger.Log("ApplicationUserManager:FindAsync (userName = {0}, password = {1})", userName, password);
            return base.FindAsync(userName, password);
        }

        public override Task<SimpleUser> FindByEmailAsync(string email)
        {
            Logger.Log("ApplicationUserManager:FindAsync (email = {0})", email);
            return base.FindByEmailAsync(email);
        }

        public override Task<SimpleUser> FindByNameAsync(string userName)
        {
            Logger.Log("ApplicationUserManager:FindByNameAsync (userName = {0})", userName);
            return base.FindByNameAsync(userName);
        }

        protected override Task<bool> VerifyPasswordAsync(IUserPasswordStore<SimpleUser, string> store, SimpleUser user, string password)
        {
            Logger.Log("ApplicationUserManager:VerifyPasswordAsync (user = {0}, password = {1})", user, password);
            return base.VerifyPasswordAsync(store, user, password);
        }

        public override Task<bool> IsLockedOutAsync(string userId)
        {
            Logger.Log("ApplicationUserManager:IsLockedOutAsync (userId = {0})", userId);
            return base.IsLockedOutAsync(userId);
        }

        public override Task<bool> GetTwoFactorEnabledAsync(string userId)
        {
            Logger.Log("ApplicationUserManager:GetTwoFactorEnabledAsync (userId = {0})", userId);
            return Task.FromResult<bool>(false);
        }

        public override Task<string> GetSecurityStampAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<string>> GetRolesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<Claim>> GetClaimsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public override Task<ClaimsIdentity> CreateIdentityAsync(SimpleUser user, string authenticationType)
        {
            Logger.Log("ApplicationUserManager:CreateIdentityAsync (user = {0}, authenticationType = {1})", user, authenticationType);
            ClaimsIdentity claims = new ClaimsIdentity(authenticationType);
            claims.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", user.UserName));
            claims.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", user.UserName));
            return Task.FromResult(claims);
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            Logger.Log("ApplicationUserManager:Create ()");
            string credfile = HttpContext.Current.Server.MapPath("~/App_Data/credentials.xml");
            var manager = new ApplicationUserManager(new XmlUserStore(credfile));
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<SimpleUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<SimpleUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
            Logger.Log("ApplicationSignInManager:ApplicationSignInManager ()");
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(SimpleUser user)
        {
            Logger.Log("ApplicationSignInManager:CreateUserIdentityAsync (user = {0})", user);
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }
        
        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            Logger.Log("ApplicationSignInManager:PasswordSignInAsync (userName = {0}, password = {1}, isPersistent = {2}, shouldLockout = {3})",
                userName, password, isPersistent, shouldLockout);
            var ReturnValue = base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
            return ReturnValue;
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            Logger.Log("ApplicationSignInManager:Create ()");
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
