using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web
{
    public class AuthorizeRolesAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }

    }
}