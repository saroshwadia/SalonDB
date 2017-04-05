//using BusinessObjects;
using SalonDB.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web.App_Start
{
    public class MyUserManager
    {
        public bool IsValid(string email, string password, out Staff StaffEnt)
        {
            var ReturnValue = false;

            //StaffEnt = SalonDB.Data.DBProviderES.GetStaffByEmailAndPassword(email, password);
            StaffEnt = SalonDB.Data.DBProviderEF.GetStaffByEmailAndPassword(email, password);
            ReturnValue = StaffEnt != null;

            return ReturnValue;
        }
    }
}