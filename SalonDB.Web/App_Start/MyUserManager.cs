//using BusinessObjects;
using SalonDB.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web.App_Start
{
    public class MyUserManager
    {
        public bool IsValid(Data.Persistence.UnitOfWork unitOfWork, string email, string password, out Staff StaffEnt)
        {
            var ReturnValue = false;

            //StaffEnt = SalonDB.Data.DBProviderES.GetStaffByEmailAndPassword(email, password);
            //StaffEnt = SalonDB.Data.DBProviderEF.GetStaffByEmailAndPassword(email, password);
            StaffEnt = unitOfWork.Staffs.Find(c => c.Email == email && c.Password == password);

            ReturnValue = StaffEnt != null;

            return ReturnValue;
        }
    }

}
