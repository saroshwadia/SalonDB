using BusinessObjects;
using EntitySpaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data
{
    public static class DBProviderES
    {

        public static void ConnectToDB()
        {
            var UseRemoteDB = true;
            string ConnectionString = string.Empty;

            if (UseRemoteDB)
            {
                ConnectionString = "Server=tcp:azuredbserver2016.database.windows.net,1433;Initial Catalog=SalonDB;Persist Security Info=False;User ID=salonmanagementuser;Password=SMUser@2016;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            else
            {
                ConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SalonDB;Data Source=DESKTOP-364IFQO\MSSQLSERVER2016;";
                if (Environment.UserName.ToLower().StartsWith("Saros".ToLower()))
                {
                    ConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SalonDB;Data Source=(local);";
                }
            }

            // Manually register a connection 
            esConnectionElement conn = new esConnectionElement();
            conn.ConnectionString = ConnectionString;
            conn.Name = "SalonManagementServer";
            conn.Provider = "EntitySpaces.SqlClientProvider";
            conn.ProviderClass = "DataProvider";
            conn.SqlAccessType = esSqlAccessType.DynamicSQL;
            conn.ProviderMetadataKey = "esDefault";
            conn.DatabaseVersion = "2005";

            // Assign the Default Connection 
            esConfigSettings.ConnectionInfo.Connections.Add(conn);
            esConfigSettings.ConnectionInfo.Default = conn.Name;

            // Register the Loader
            esProviderFactory.Factory = new EntitySpaces.Loader.esDataProviderFactory();
        }

        public static CompanyCollection GetCompanys()
        {
            var ReturnValue = new CompanyCollection();
            ReturnValue.Query.Load();

            return ReturnValue;
        }

        public static Company GetCompany(Guid companyID)
        {
            var ReturnValue = new Company();
            ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static TransactionCollection GetTransactions(Guid? companyID)
        {
            var ReturnValue = new TransactionCollection();
            ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
            ReturnValue.Query.OrderBy(ReturnValue.Query.TransactionDate.Ascending, ReturnValue.Query.Status.Ascending);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static List<ServiceProduct> GetServiceProductsByTransaction(Guid? transactionID)
        {
            var ReturnValue = new List<ServiceProduct>();
            var TransactionEnt = GetTransaction(transactionID);
            var TransactionServiceCol = new TransactionDetailServiceCollection();
            var TransactionProductCol = new TransactionDetailProductCollection();

            if (TransactionEnt != null)
            {
                foreach (var oEnt in TransactionEnt.TransactionDetailServiceCollectionByTransactionID)
                {
                    var ServiceProductEnt = new ServiceProduct();

                    ServiceProductEnt.ServiceProductID = (Guid)oEnt.ServiceID;
                    ServiceProductEnt.Name = oEnt.Name;
                    ServiceProductEnt.Description = oEnt.Description;
                    ServiceProductEnt.Quantity = Convert.ToInt32(oEnt.Quantity);
                    ServiceProductEnt.Price = Convert.ToDecimal(oEnt.UnitPrice);
                    ServiceProductEnt.DiscountPercent = Convert.ToDecimal(oEnt.DiscountPercent);
                    ServiceProductEnt.Duration = Convert.ToInt32(oEnt.Duration);
                    oEnt.ShowOnline = false; // ServiceProductEnt.ShowOnline;
                    ServiceProductEnt.IsService = true;
                    ServiceProductEnt.Sequence = Convert.ToInt32(oEnt.Sequence);

                    ReturnValue.Add(ServiceProductEnt);
                }

                foreach (var oEnt in TransactionEnt.TransactionDetailProductCollectionByTransactionID)
                {
                    var ServiceProductEnt = new ServiceProduct();

                    ServiceProductEnt.ServiceProductID = (Guid)oEnt.ProductID;
                    ServiceProductEnt.Name = oEnt.Name;
                    ServiceProductEnt.Description = oEnt.Description;
                    ServiceProductEnt.Quantity = Convert.ToInt32(oEnt.Quantity);
                    ServiceProductEnt.Price = Convert.ToDecimal(oEnt.UnitPrice);
                    ServiceProductEnt.DiscountPercent = Convert.ToDecimal(oEnt.DiscountPercent);
                    oEnt.WholesalePrice = ServiceProductEnt.Price;  //ServiceProductEnt.WholesalePrice;
                    oEnt.Commission = 0; //ServiceProductEnt.Commission;
                    oEnt.BarCode = null; // ServiceProductEnt.BarCode;
                    ServiceProductEnt.IsService = false;
                    ServiceProductEnt.Sequence = Convert.ToInt32(oEnt.Sequence);

                    ReturnValue.Add(ServiceProductEnt);
                }

            }

            //return ReturnValue;
            return ReturnValue.OrderBy(e => e.Sequence).ToList();
        }

        public static SalesViewCollection GetSalesView(Guid companyID)
        {
            var ReturnValue = new SalesViewCollection();
            ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;


        }



        public static ServiceTransactionsViewCollection GetServiceTransactionView(Guid companyID)
        {
            var ReturnValue = new ServiceTransactionsViewCollection();
            
            ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
            ReturnValue.Query.OrderBy(ReturnValue.Query.Month.Descending);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;


        }
        
        public static ServiceTransactionsTimefilterCollection GetServiceTransactionsTimefilterCollection(Guid companyID)
        {
            var ReturnValue = new ServiceTransactionsTimefilterCollection();

            ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
            //ReturnValue.Query.OrderBy(ReturnValue.Query.TransactionDate.Descending);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;


        }
        public static Company GetCompanyFirst()
        {
            var ReturnValue = new Company();
            var CompanyCol = DBProviderES.GetCompanys();

            if (CompanyCol.Count > 0)
            {
                ReturnValue = CompanyCol[0];
            }
            else
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static StoreCollection GetStores()
        {
            var ReturnValue = new StoreCollection();
            ReturnValue.Query.Load();

            return ReturnValue;
        }

        public static StoreCollection GetStores(Guid? companyID)
        {
            var ReturnValue = new StoreCollection();
            if (companyID != null)
            {
                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static Store GetStore(Guid storeID)
        {
            var ReturnValue = new Store();
            ReturnValue.Query.Where(ReturnValue.Query.StoreID == storeID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static Store GetStore(Guid storeID, Guid companyID)
        {
            var ReturnValue = new Store();
            ReturnValue.Query.Where(ReturnValue.Query.StoreID == storeID && ReturnValue.Query.CompanyID == companyID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }


        public static StaffCollection GetStaffs()
        {
            var ReturnValue = new StaffCollection();
            ReturnValue.Query.Load();

            return ReturnValue;
        }

        public static StaffCollection GetStaffs(Guid? companyID)
        {
            var ReturnValue = new StaffCollection();
            if (companyID != null)
            {
                ReturnValue.Query.OrderBy(ReturnValue.Query.FirstName.Ascending);
                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static Staff GetStaff(Guid StaffID)
        {
            var ReturnValue = new Staff();
            ReturnValue.Query.Where(ReturnValue.Query.StaffID == StaffID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static Staff GetStaff(string email, string password)
        {
            var ReturnValue = new Staff();
            ReturnValue.Query.es.Top = 1;
            ReturnValue.Query.Where(ReturnValue.Query.Email == email && ReturnValue.Query.Password == password);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }


        public static Staff GetStaff(Guid StaffID, Guid companyID)
        {
            var ReturnValue = new Staff();
            ReturnValue.Query.Where(ReturnValue.Query.StaffID == StaffID && ReturnValue.Query.CompanyID == companyID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static Staff GetStaffByEmail(string email)
        {
            var ReturnValue = new Staff();
            ReturnValue.Query.Where(ReturnValue.Query.Email == email);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static Staff GetStaffByEmailAndPassword(string email, string password)
        {
            var ReturnValue = new Staff();

            if (email == null || password == null)
            {
                ReturnValue = null;
            }
            else
            {
                ReturnValue.Query.Where(ReturnValue.Query.Email == email && ReturnValue.Query.Password == password);

                if (!ReturnValue.Query.Load())
                {
                    ReturnValue = null;
                }
            }

            return ReturnValue;
        }


        public static ServiceCollection GetServices()
        {
            var ReturnValue = new ServiceCollection();
            ReturnValue.Query.Load();

            return ReturnValue;
        }

        public static ServiceCollection GetServices(Guid? companyID)
        {
            var ReturnValue = new ServiceCollection();

            if (companyID != null)
            {
                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static Service GetService(Guid ServiceID)
        {
            var ReturnValue = new Service();
            ReturnValue.Query.Where(ReturnValue.Query.ServiceID == ServiceID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static Service GetService(Guid ServiceID, Guid companyID)
        {
            var ReturnValue = new Service();
            ReturnValue.Query.Where(ReturnValue.Query.ServiceID == ServiceID && ReturnValue.Query.CompanyID == companyID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static ProductCollection GetProducts()
        {
            var ReturnValue = new ProductCollection();
            ReturnValue.Query.Load();

            return ReturnValue;
        }

        public static ProductCollection GetProducts(Guid? companyID)
        {
            var ReturnValue = new ProductCollection();
            if (companyID != null)
            {
                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static Product GetProduct(Guid ProductID)
        {
            var ReturnValue = new Product();
            ReturnValue.Query.Where(ReturnValue.Query.ProductID == ProductID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static Product GetProduct(Guid ProductID, Guid companyID)
        {
            var ReturnValue = new Product();
            ReturnValue.Query.Where(ReturnValue.Query.ProductID == ProductID && ReturnValue.Query.CompanyID == companyID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static AppointmentCollection GetAppointments()
        {
            var ReturnValue = new AppointmentCollection();
            ReturnValue.Query.Load();

            return ReturnValue;
        }

        public static AppointmentCollection GetAppointments(Guid? companyID)
        {
            var ReturnValue = new AppointmentCollection();
            ReturnValue = GetAppointments(companyID, null, null);

            return ReturnValue;
        }

        public static AppointmentCollection GetAppointments(Guid? companyID, DateTime? dateFrom, DateTime? dateTo)
        {
            var ReturnValue = new AppointmentCollection();
            if (companyID != null)
            {
                if (dateFrom == null)
                {
                    dateFrom = System.Data.SqlTypes.SqlDateTime.MinValue.Value; //DateTime.MinValue;
                }

                if (dateTo == null)
                {
                    dateTo = System.Data.SqlTypes.SqlDateTime.MaxValue.Value; //DateTime.MaxValue
                }

                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID && ReturnValue.Query.StartTime.Between(dateFrom, dateTo));
                ReturnValue.Query.OrderBy(ReturnValue.Query.StartTime.Ascending, ReturnValue.Query.EndTime.Ascending, ReturnValue.Query.StaffID.Ascending);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static AppointmentCollection GetAppointmentsNotPaid(Guid? companyID, DateTime? dateFrom, DateTime? dateTo)
        {
            var ReturnValue = new AppointmentCollection();
            var AppointmentQ = new AppointmentQuery("AQ");
            var TransactionQ = new TransactionQuery("TQ");

            if (companyID != null)
            {
                if (dateFrom == null)
                {
                    dateFrom = System.Data.SqlTypes.SqlDateTime.MinValue.Value; //DateTime.MinValue;
                }

                if (dateTo == null)
                {
                    dateTo = System.Data.SqlTypes.SqlDateTime.MaxValue.Value; //DateTime.MaxValue
                }

                AppointmentQ.SelectAll();
                AppointmentQ.LeftJoin(TransactionQ).On(AppointmentQ.AppointmentID == TransactionQ.AppointmentID);
                AppointmentQ.Where(AppointmentQ.CompanyID == companyID && AppointmentQ.StartTime.Between(dateFrom, dateTo) && TransactionQ.AppointmentID.IsNotNull() && TransactionQ.Status != eTransactionStatus.Paid.ToString());
                AppointmentQ.OrderBy(AppointmentQ.StartTime.Ascending, AppointmentQ.EndTime.Ascending, AppointmentQ.StaffID.Ascending);

                ReturnValue.Load(AppointmentQ);
            }

            return ReturnValue;
        }


        public static Appointment GetAppointment(Guid AppointmentID)
        {
            var ReturnValue = new Appointment();
            ReturnValue.Query.Where(ReturnValue.Query.AppointmentID == AppointmentID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static Appointment GetAppointment(Guid AppointmentID, Guid companyID)
        {
            var ReturnValue = new Appointment();
            ReturnValue.Query.Where(ReturnValue.Query.AppointmentID == AppointmentID && ReturnValue.Query.CompanyID == companyID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static CustomerCollection GetCustomers()
        {
            var ReturnValue = new CustomerCollection();
            ReturnValue.Query.Load();

            return ReturnValue;
        }

        public static CustomerCollection GetCustomers(Guid? companyID)
        {
            var ReturnValue = new CustomerCollection();
            if (companyID != null)
            {
                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static CustomerCollection GetCustomersOrderByFirstLastPhone(Guid? companyID)
        {
            var ReturnValue = new CustomerCollection();
            if (companyID != null)
            {
                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
                ReturnValue.Query.OrderBy(ReturnValue.Query.FirstName.Ascending, ReturnValue.Query.LastName.Ascending, ReturnValue.Query.Phone.Ascending);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static CategoryCollection GetCategorys()
        {
            var ReturnValue = new CategoryCollection();
            ReturnValue.Query.Load();

            return ReturnValue;
        }

        public static CategoryCollection GetCategorys(Guid? companyID)
        {
            var ReturnValue = new CategoryCollection();
            if (companyID != null)
            {
                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
                ReturnValue.Query.OrderBy(ReturnValue.Query.Name.Ascending);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static Category GetDefaultCategory(Guid? companyID)
        {
            var ReturnValue = new Category();
            var DefaultCategory = "-";
            if (companyID != null)
            {
                ReturnValue.Query.es.Top = 1;
                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID && ReturnValue.Query.Name == DefaultCategory);
                ReturnValue.Query.OrderBy(ReturnValue.Query.Name.Ascending);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static SupplierCollection GetSuppliers(Guid? companyID)
        {
            var ReturnValue = new SupplierCollection();
            if (companyID != null)
            {
                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static Supplier GetDefaultSupplier(Guid? companyID)
        {
            var ReturnValue = new Supplier();
            var DefaultSupplier = "-";
            if (companyID != null)
            {
                ReturnValue.Query.es.Top = 1;
                ReturnValue.Query.Where(ReturnValue.Query.CompanyID == companyID && ReturnValue.Query.Name == DefaultSupplier);
                ReturnValue.Query.OrderBy(ReturnValue.Query.Name.Ascending);
                ReturnValue.Query.Load();
            }

            return ReturnValue;
        }

        public static Customer GetCustomer(Guid CustomerID)
        {
            var ReturnValue = new Customer();
            ReturnValue.Query.Where(ReturnValue.Query.CustomerID == CustomerID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static Customer GetCustomer(Guid CustomerID, Guid companyID)
        {
            var ReturnValue = new Customer();
            ReturnValue.Query.Where(ReturnValue.Query.CustomerID == CustomerID && ReturnValue.Query.CompanyID == companyID);

            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static Customer GetCustomerWalkIn(Guid? companyID)
        {
            var ReturnValue = new Customer();
            var WalkInFirstName = "Walk";
            var WalkInLastName = "In";

            if (companyID != null)
            {
                ReturnValue.Query.Where(ReturnValue.Query.FirstName == WalkInFirstName && ReturnValue.Query.LastName == WalkInLastName && ReturnValue.Query.CompanyID == companyID);
                if (!ReturnValue.Query.Load())
                {
                    ReturnValue = null;
                }
            }

            return ReturnValue;
        }

        public static Transaction GetTransaction(Guid? appointmentID, Guid? companyID)
        {
            var ReturnValue = new Transaction();

            if (companyID == null)
            {
                ReturnValue.Query.Where(ReturnValue.Query.AppointmentID == appointmentID);
            }
            else
            {
                ReturnValue.Query.Where(ReturnValue.Query.AppointmentID == appointmentID && ReturnValue.Query.CompanyID == companyID);
            }
            if (!ReturnValue.Query.Load())
            {
                ReturnValue = null;
            }

            return ReturnValue;
        }

        public static Transaction GetTransaction(Guid? transactionID)
        {
            var ReturnValue = new Transaction();
            ReturnValue.Query.Where(ReturnValue.Query.TransactionID == transactionID);
            ReturnValue.Query.Load();

            return ReturnValue;
        }

       

        public static List<string> GetTransactionStatus()
        {
            var ReturnValue = new List<string>();

            return ReturnValue;
        }

        #region #customappointment
        public class CustomAppointment
        {
            public Guid AppointmentID { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Subject { get; set; }
            public int Status { get; set; }
            public string Description { get; set; }
            public int Label { get; set; }
            public string Location { get; set; }
            public bool AllDay { get; set; }
            public int EventType { get; set; }
            public string RecurrenceInfo { get; set; }
            public string ReminderInfo { get; set; }
            public object ResourceID { get; set; }
            public Guid CustomerID { get; set; }
            public Guid StoreID { get; set; }
        }
        #endregion  #customappointment

        #region #customresource
        public class CustomResource
        {
            public Guid ResourceID { get; set; }
            public string ResourceName { get; set; }
            public System.Drawing.Color ResourceColor { get; set; }
        }
        #endregion #customresource

        public enum RowState
        {
            Changed,
            Deleted,
            Inserted
        }

        public class Activity
        {
            public string Name { get; set; }
            public string FormName { get; set; }

            public Activity(string name, string formName)
            {
                Name = name;
                FormName = formName;
            }

        }

        public static class ActivityList
        {
            public static List<Activity> GetActivityData()
            {
                var ReturnValue = new List<Activity>();

                ReturnValue.Add(new Activity("Company", "CompanyForm"));
                ReturnValue.Add(new Activity("Store", "StoreForm"));
                ReturnValue.Add(new Activity("Staff", "StaffForm"));
                ReturnValue.Add(new Activity("Client", "ClientForm"));
                ReturnValue.Add(new Activity("Supplier", "SupplierForm"));
                ReturnValue.Add(new Activity("Service", "ServiceForm"));
                ReturnValue.Add(new Activity("Product", "ProductForm"));
                ReturnValue.Add(new Activity("Category", "CategoryForm"));

                return ReturnValue;
            }
        }

        public class ServiceProductSummary
        {
            public string CustomertName { get; set; }
            public string StaffName { get; set; }
            public string StoreName { get; set; }
            public decimal DiscountPercent { get; set; }
            public decimal DiscountAmount { get; set; }
            public decimal TaxPercent { get; set; }
            public decimal TaxAmount { get; set; }
            public decimal Amount { get; set; }
            public decimal Total { get; set; }
            public int TransactionNumber { get; set; }
            public DateTime TransactionDate { get; set; }
            public string Status { get; set; }
        }

        public class ServiceProduct
        {
            public Guid ServiceProductID { get; set; }
            public Guid TransactionID { get; set; }
            public Guid TransactionDetailServiceID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int Quantity{ get; set; }
            public int Duration { get; set; }
            public decimal DiscountPercent { get; set; }
            public decimal Total {
                get
                {
                    decimal ReturnValue = 0;
                    decimal DiscountAmount = 0;

                    try
                    {
                        ReturnValue = (Price * Quantity);
                        DiscountAmount = (DiscountPercent / 100) * ReturnValue;
                        ReturnValue = ReturnValue - DiscountAmount;
                    }
                    catch (Exception)
                    {
                        ReturnValue = -1;
                    }

                    return ReturnValue;
                }
            }
            public bool IsService { get; set; }
            public int Sequence { get; set; }

            public ServiceProduct()
            {
            }

            public ServiceProduct(string name, string description, decimal price, int quantity, int duration, decimal discountPercent, bool isService)
            {
                Name = name;
                Description = description;
                Price = price;
                Quantity = quantity;
                Duration = duration;
                DiscountPercent = discountPercent;
                IsService = isService;
            }

        }

    }

    public class CustomerAppointmentInfo
    {
        public Customer CustomerEnt { get; set; }
        public Appointment AppointmentEnt { get; set; }
    }
}
