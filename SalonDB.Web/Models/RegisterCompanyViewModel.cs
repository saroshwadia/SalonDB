using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SalonDB.Web.Models
{
    public class RegisterCompanyViewModel
    {
        public  Guid ID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [DisplayName("Store Name")]
        public string StoreName { get; set; }
        [DisplayName("Store Address")]
        public string StoreAddress { get; set; }
        [DisplayName("Store City")]
        public string StoreCity { get; set; }
        [DisplayName("Store Postal Code")]
        public string StorePostalCode { get; set; }
        [DisplayName("Store TimeZone")]
        public string StoreTimeZone { get; set; }
    }
}