using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNet.Identity;

namespace SalonDB.Web
{
    public class SimpleUser : IUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<SimpleUser> manager)
        {
            Logger.Log("SimpleUser:GenerateUserIdentityAsync ()");
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public override string ToString()
        {
            return string.Format("Id={0} PasswordHash={1}", Email, (PasswordHash == null ? string.Empty : PasswordHash));
        }
    }

    /// <summary>
    /// Works with SimpleUser objects stored in an XML file
    /// </summary>
    public class XmlUserStore : IUserStore<SimpleUser>, IUserPasswordStore<SimpleUser>, IUserLockoutStore<SimpleUser, object>
    {
        protected XmlDocument m_doc;

        public XmlUserStore(string credentialsXmlFile)
        {
            m_doc = new XmlDocument();
            m_doc.Load(credentialsXmlFile);
        }

        #region IUserStore implementation

        public Task<SimpleUser> FindByIdAsync(string userId)
        {
            Logger.Log("XmlUserStore:FindByIdAsync (userId = {0})", userId);

            if (string.IsNullOrEmpty(userId)) return Task.FromResult<SimpleUser>(null);

            //XmlNode n = m_doc.SelectSingleNode(string.Format("/users/user[@id='{0}']", userId));
            XmlNode n = m_doc.SelectSingleNode(string.Format("/users/user[@email='{0}']", userId));
            SimpleUser u = null;

            if (n != null)
            {
                //u = new SimpleUser { Email = userId, UserName = userId, PasswordHash = n.Attributes["password"].Value, PhoneNumber = n.Attributes["phonenumber"].Value, Id = n.Attributes["id"].Value };
                u = new SimpleUser { Email = userId, UserName = userId, PasswordHash = n.Attributes["password"].Value, PhoneNumber = n.Attributes["phonenumber"].Value, Id = n.Attributes["email"].Value };
            }

            return Task.FromResult<SimpleUser>(u);
        }

        public Task<SimpleUser> FindByNameAsync(string userName)
        {
            Logger.Log("XmlUserStore:FindByNameAsync (userName = {0})", userName);
            string s = "pop";
            string s1 = new PasswordHasher().HashPassword(s);
            var RV = FindByIdAsync(userName);
            return RV; 

        }

        public Task CreateAsync(SimpleUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(SimpleUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SimpleUser user)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserPasswordStore implementation

        public Task<string> GetPasswordHashAsync(SimpleUser user)
        {
            Logger.Log("XmlUserStore:GetPasswordHashAsync (user = {0})", user);
            string hash = user.PasswordHash;
            return Task.FromResult<string>(hash);
        }

        public Task<bool> HasPasswordAsync(SimpleUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(SimpleUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserLockoutStore implementation

        public Task<int> GetAccessFailedCountAsync(SimpleUser user)
        {
            //throw new NotImplementedException();
            Logger.Log("XmlUserStore:GetAccessFailedCountAsync (user = {0})", user);
            return Task.FromResult<int>(0);
        }

        public Task<bool> GetLockoutEnabledAsync(SimpleUser user)
        {
            Logger.Log("XmlUserStore:GetLockoutEnabledAsync (user = {0})", user);
            return Task.FromResult<bool>(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(SimpleUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(SimpleUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(SimpleUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(SimpleUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(SimpleUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleUser> FindByIdAsync(object userId)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
        }
    }


}