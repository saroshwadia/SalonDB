using SalonDB.Data.Core;
using System.Data;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonDB.Data.Core.Domain;
using SalonDB.Data.Persistence;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace SalonDB.Data
{
    public static class DBProvider
    {
        private static SalonDB.Data.Persistence.SalonContext db = new SalonDB.Data.Persistence.SalonContext();

        public static IList<Company> GetCompanys()
        {
            return db.Companies.ToList();
        }

        public static IList<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public static IList<Product> GetProductsByCompany(Guid CompanyID)
        {
            return db.Products.Where(x => x.CompanyID == CompanyID).ToList();
        }
        public static IList<Product> GetProducts(Guid StoreID)
        {
            return db.Products.Where(x => x.StoreID == StoreID).ToList();
        }

        public static IList<Category> GetCategories()
        {
            return db.Categories.ToList();
        }
        public static IList<Category> GetCategories(Guid CompanyID)
        {
            return db.Categories.Where(x => x.CompanyID == CompanyID & x.Name != "-").ToList();
        }

        public static IList<spCategorySummaryDetail_Result> GetCategorySummaryDetail(Guid CompanyID, String FromDate, String ToDate)
        {
            var result = spCategorySummaryDetail(CompanyID, FromDate, ToDate);

            return result.ToList();
        }

        public static IList<spCategoryDetailProduct_Result> GetCategoryDetailProduct(Guid StoreID, String FromDate, String ToDate)
        {
            var result = spCategoryDetailProduct(StoreID, FromDate, ToDate);

            return result.ToList();
        }
        public static IList<spCategoryDetailService_Result> GetCategoryDetailService(Guid StoreID, String FromDate, string ToDate)
        {
            var result = spCategoryDetailService(StoreID, FromDate, ToDate);
            return result.ToList();
        }

        public static IList<Supplier> GetSuppliers()
        {
            return db.Suppliers.ToList();
        }

        public static IList<Supplier> GetSuppliers(Guid CompanyID)
        {
            return db.Suppliers.Where(x => x.CompanyID == CompanyID).ToList();
        }

        public static IList<Service> GetServices()
        {
            return db.Services.ToList();
        }

        public static IList<Service> GetServicesByCompany(Guid CompanyID)
        {
            return db.Services.Where(x => x.CompanyID == CompanyID).ToList();
        }
        public static IList<Service> GetServices(Guid StoreID)
        {
            return db.Services.Where(x => x.StoreID == StoreID).ToList();
        }

        public static List<string> GetServiceNames()
        {
            var ServiceNames = db.Services.Select(t => t.Name).ToList();
            return ServiceNames;
        }
        public static IList<Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }

        public static IList<Customer> GetCustomers(Guid CompanyID)
        {
            return db.Customers.Where(x => x.CompanyID == CompanyID).ToList();
        }

        public static IList<Staff> GetStaffs()
        {
            return db.Staffs.ToList();
        }
        public static IList<Staff> GetStaffs(Guid StoreID)
        {
            return db.Staffs.Where(x => x.StoreID == StoreID).ToList();
        }

        public static IList<Store> GetStores()
        {
            return db.Stores.ToList();
        }

        public static IList<Store> GetStores(Guid CompanyID)
        {
            return db.Stores.Where(x => x.CompanyID == CompanyID).ToList();
        }
        public static IList<spPOS_Result> GetPOS(Guid TransactionID)
        {
            var result = spPOS(TransactionID);
            return result.ToList();
        }

        public static IList<PaymentType> GetPaymentTypes(Guid CompanyID)
        {
            return db.PaymentTypes.Where(x => x.CompanyID == CompanyID).OrderBy(x => x.Sequence).ToList();
        }

        public static IList<spTransactionData_Result> GetTransactionData(Guid TransactionID)
        {
            var result = spTransactionData(TransactionID);
            return result.ToList();
        }

        public static IList<spSalesOvertimeByService_Result> GetSalesOvertimeByService(Guid CompanyID)
        {
            var result = spSalesOvertimeByService(CompanyID, null, null, null);

            return result.ToList();
        }

        public static IList<spServiceSalesOvertime_Result> GetServiceSalesOvertime(Guid StoreID, DateTime FromDate, DateTime ToDate)
        {
            var result = spServiceSalesOvertime(StoreID, FromDate, ToDate);

            return result.ToList();
        }

        public static IList<spCashOutSummary_Result> GetCashOutSummary(Guid CompanyID, Guid StoreID, String FromDate, String ToDate)
        {
            var result = spCashOutSummary(CompanyID, StoreID, FromDate, ToDate);

            return result.ToList();
        }

        public static IEnumerable<ServiceSalesMonthly> GetServiceSalesMonthlyByMonthYear(string Month, String Year, Guid StoreID)
        {
            var result = db.ServiceSalesMonthlies.Where(s => s.Month == Month && s.Year == Year && s.StoreID == StoreID);

            return result;
        }

        public static IList<ServiceSalesMonthly> GetServiceSalesMonthly()
        {
            var result = db.ServiceSalesMonthlies.ToList();

            return result;
        }

        public static IList<ServiceSalesMonthly> GetServiceSalesCurrentMonth(Guid StoreID)
        {
            var month = DateTime.Now.ToString("MMMM");
            var year = DateTime.Now.Year;
            var result = db.ServiceSalesMonthlies.Where(s => s.Month == month && s.Year == year.ToString() && s.StoreID == StoreID);

            return result.ToList();
        }

        public static IList<SalesOvertimePerServiceView> GetSalesOvertimePerService()
        {
            var result = db.SalesOvertimePerServiceViews.ToList();
            return result;
        }

        public static List<spSalesComparison_Result> GetSalesComparison(Guid StoreID)
        {
            var result = spSalesComparison(StoreID);

            return result.ToList();
        }

        public static List<string> GetYear()
        {
            System.Data.Entity.Infrastructure.DbRawSqlQuery<String> result = db.Database.SqlQuery<string>("SELECT DISTINCT CONVERT(nvarchar(255), YEAR(TransactionDate)) FROM [Transaction]");
            return result.ToList();
        }

        public static List<CountTotal> GetCategorySummaryServiceTotal(Guid StoreID, String FromDate, String ToDate)
        {
            System.Data.Entity.Infrastructure.DbRawSqlQuery<CountTotal> result = db.Database.SqlQuery<CountTotal>("SELECT SUM(TransactionDetailService.Quantity) AS Count, SUM(TransactionDetailService.UnitPrice) AS Total FROM[Transaction] INNER JOIN TransactionDetailService ON[Transaction].TransactionID = TransactionDetailService.TransactionID where ([Transaction].Status = 'Paid') and [Transaction].StoreID = '" + StoreID.ToString() + "' and  [Transaction].TransactionDate > '" + FromDate + "' and [Transaction].TransactionDate <= '" + ToDate + "'");
            return result.ToList();
        }

        public static List<CountTotal> GetServiceSales(Guid StoreID, String FromDate, String ToDate)
        {
            System.Data.Entity.Infrastructure.DbRawSqlQuery<CountTotal> result = db.Database.SqlQuery<CountTotal>("SELECT SUM(TransactionDetailService.Quantity) AS Count, SUM(TransactionDetailService.Quantity * TransactionDetailService.UnitPrice) AS TotalSales FROM [Transaction] INNER JOIN TransactionDetailService ON [Transaction].TransactionID = TransactionDetailService.TransactionID WHERE (YEAR([Transaction].TransactionDate) = '2017') AND ([Transaction].Status = 'Paid') and [Transaction].StoreID = '" + StoreID.ToString() + "' and  [Transaction].TransactionDate > '" + FromDate + "' and [Transaction].TransactionDate <= '" + ToDate + "'");
            return result.ToList();
        }

        public static List<CountTotal> GetProductSales(Guid StoreID, String FromDate, String ToDate)
        {
            System.Data.Entity.Infrastructure.DbRawSqlQuery<CountTotal> result = db.Database.SqlQuery<CountTotal>("SELECT SUM(TransactionDetailProduct.Quantity) AS Count, SUM(TransactionDetailProduct.Quantity * TransactionDetailProduct.UnitPrice) AS TotalSales FROM [Transaction] INNER JOIN TransactionDetailProduct ON[Transaction].TransactionID = TransactionDetailProduct.TransactionID WHERE(YEAR([Transaction].TransactionDate) = '2017') AND([Transaction].Status = 'Paid') and [Transaction].StoreID = '" + StoreID.ToString() + "' and  [Transaction].TransactionDate > '" + FromDate + "' and [Transaction].TransactionDate <= '" + ToDate + "'");
            return result.ToList();
        }
        public static List<CountTotal> GetCategorySummaryProductTotal(Guid StoreID, String FromDate, String ToDate)
        {
            System.Data.Entity.Infrastructure.DbRawSqlQuery<CountTotal> result = db.Database.SqlQuery<CountTotal>("SELECT SUM(TransactionDetailProduct.Quantity) AS Count, SUM(TransactionDetailProduct.UnitPrice) AS Total FROM[Transaction] INNER JOIN TransactionDetailProduct ON[Transaction].TransactionID = TransactionDetailProduct.TransactionID where ([Transaction].Status = 'Paid') and [Transaction].StoreID = '" + StoreID.ToString() + "' and  [Transaction].TransactionDate > '" + FromDate + "' and [Transaction].TransactionDate <= '" + ToDate + "'");
            return result.ToList();
        }

        public class CountTotal
        {
            public int? Count { get; set; }
            public decimal? Total { get; set; }
        }

        public static List<string> GetMonth()
        {
            List<string> result = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return result.ToList();
        }

        public static List<Transaction> GetCustomerSales(DateTime? dateFrom, DateTime? dateTo, Guid? customerID, Guid? companyID)
        {
            var ReturnValue = new List<Transaction>();
            var DateFrom = dateFrom.Value;
            var DateTo = dateTo.Value;
            var StatusPaid = eTransactionStatus.Paid.ToString();

            ReturnValue = db.Transactions.Where(c => c.CustomerID == customerID && c.TransactionDate >= DateFrom && c.TransactionDate <= DateTo && c.Status == StatusPaid).OrderByDescending(c => c.TransactionDate).ThenByDescending(c => c.TransactionNumber).ToList();
            //ReturnValue = db.Transactions.Where(c => c.CustomerID == customerID && c.TransactionDate >= DateFrom && c.TransactionDate <= DateTo).OrderByDescending(c => c.TransactionDate).ThenByDescending(c => c.TransactionNumber).ToList();

            return ReturnValue;
        }

        public static IList<spSalesByCompany_Result> GetSales(Guid StoreID)
        {
            //var result = db.spSalesByCompany(CompanyID);
            var result = spSalesByCompany(StoreID);

            return result.ToList();
        }

        public static Company GetCompany(Guid companyID)
        {
            Company ReturnValue = GetCompanys().Where(c => c.CompanyID == companyID).FirstOrDefault();

            return ReturnValue;
        }


        public static Customer GetCustomer(Guid customerID)
        {
            Customer ReturnValue = db.Customers.Where(c => c.CustomerID == customerID).FirstOrDefault();

            return ReturnValue;
        }

        public static void AddProduct(Product product)
        {
            product.ProductID = Guid.NewGuid();
            db.Products.Add(product);
            db.SaveChanges();
        }

        public static void UpdateProduct(Product Product)
        {
            Product p = db.Products.Single(a => a.ProductID == Product.ProductID);
            db.Entry(p).CurrentValues.SetValues(Product);
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteProduct(Guid Key)
        {
            Product product = db.Products.Find(Key);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public static void AddService(Service Service)
        {
            Service.ServiceID = Guid.NewGuid();
            //Service.CompanyID = new Guid("bad47e3c-381b-452b-bda6-03dfab26a4c8");
            db.Services.Add(Service);
            db.SaveChanges();
        }

        public static void UpdateService(Service Service)
        {
            Service s = db.Services.Single(a => a.ServiceID == Service.ServiceID);
            db.Entry(s).CurrentValues.SetValues(Service);
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteService(Guid Key)
        {
            Service Service = db.Services.Find(Key);
            db.Services.Remove(Service);
            db.SaveChanges();
        }

        public static void AddCustomer(Customer Customer)
        {
            Customer.CustomerID = Guid.NewGuid();
            db.Customers.Add(Customer);
            db.SaveChanges();
        }

        public static void UpdateCustomer(Customer Customer)
        {
            Customer p = db.Customers.Single(a => a.CustomerID == Customer.CustomerID);
            db.Entry(p).CurrentValues.SetValues(Customer);
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteCustomer(Guid Key)
        {
            Customer Customer = db.Customers.Find(Key);
            db.Customers.Remove(Customer);
            db.SaveChanges();
        }

        public static void AddStaff(Staff Staff)
        {
            Staff.StaffID = Guid.NewGuid();
            db.Staffs.Add(Staff);
            db.SaveChanges();
        }

        public static void UpdateStaff(Staff Staff)
        {
            Staff s = db.Staffs.Single(a => a.StaffID == Staff.StaffID);
            db.Entry(s).CurrentValues.SetValues(Staff);
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static bool IsUserAdmin(Staff staffEnt)
        {
            bool IsAdmin = false;

            if (!string.IsNullOrEmpty(staffEnt.Role))
            {
                IsAdmin = staffEnt.Role.ToLower().Contains(eRoles.Admin.ToString().ToLower());
            }

            return IsAdmin;
        }

        public static bool IsUserOwner(Staff staffEnt)
        {
            bool IsAdmin = false;

            if (!string.IsNullOrEmpty(staffEnt.Role))
            {
                IsAdmin = staffEnt.Role.ToLower().Contains(eRoles.Owner.ToString().ToLower());
            }

            return IsAdmin;
        }

        public static bool IsUserStaff(Staff staffEnt)
        {
            bool IsAdmin = false;

            if (!string.IsNullOrEmpty(staffEnt.Role))
            {
                IsAdmin = staffEnt.Role.ToLower().Contains(eRoles.Staff.ToString().ToLower());
            }

            return IsAdmin;
        }

        public static void DeleteStaff(Guid Key)
        {
            Staff Staff = db.Staffs.Find(Key);
            db.Staffs.Remove(Staff);
            db.SaveChanges();
        }

        public static void AddStore(Store Store)
        {
            Store.StoreID = Guid.NewGuid();
            db.Stores.Add(Store);
            db.SaveChanges();
        }

        public static void UpdateStore(Store Store)
        {
            Store s = db.Stores.Single(a => a.StoreID == Store.StoreID);
            db.Entry(s).CurrentValues.SetValues(Store);
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteStore(Guid Key)
        {
            Store Store = db.Stores.Find(Key);
            db.Stores.Remove(Store);
            db.SaveChanges();
        }

        public static void AddSupplier(Supplier Supplier)
        {
            Supplier.SupplierID = Guid.NewGuid();
            db.Suppliers.Add(Supplier);
            db.SaveChanges();
        }

        public static void UpdateSupplier(Supplier Supplier)
        {
            Supplier s = db.Suppliers.Single(a => a.SupplierID == Supplier.SupplierID);
            db.Entry(s).CurrentValues.SetValues(Supplier);
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteSupplier(Guid Key)
        {
            Supplier Supplier = db.Suppliers.Find(Key);
            db.Suppliers.Remove(Supplier);
            db.SaveChanges();
        }

        public static void AddCompany(Company Company)
        {
            Company.CompanyID = Guid.NewGuid();
            db.Companies.Add(Company);
            db.SaveChanges();
        }

        public static void UpdateCompany(Company Company)
        {
            Company s = db.Companies.Single(a => a.CompanyID == Company.CompanyID);
            db.Entry(s).CurrentValues.SetValues(Company);
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteCompany(Guid Key)
        {
            Company Company = db.Companies.Find(Key);
            db.Companies.Remove(Company);
            db.SaveChanges();
        }

        public static int GetTotalAppointmentsToday(Guid StoreID)
        {
            var DateFrom = DateTime.Now.Date;
            var DateTo = DateTime.Now.Date.AddDays(1).AddMilliseconds(-1);            //var aps = db.Appointments.Where(a => a.StoreID == StoreID && a.StartTime.Value.Date == d.Value.Date).ToList();
            var ReturnValue = GetTotalAppointments(StoreID, DateFrom, DateTo);

            return ReturnValue;
        }

        public static int GetTotalAppointmentsLastYear(Guid StoreID)
        {
            var CurrentDate = DateTime.Now.Date;
            var DateFrom = new DateTime(CurrentDate.Year - 1, CurrentDate.Month, CurrentDate.Day).Date;
            var DateTo = DateFrom.AddDays(1).AddMilliseconds(-1);
            var ReturnValue = GetTotalAppointments(StoreID, DateFrom, DateTo);

            return ReturnValue;
        }
        public static int GetTotalAppointmentsLastWeek(Guid StoreID)
        {
            var CurrentDate = DateTime.Now.Date;
            var DateFrom = CurrentDate.AddDays(-7).Date;
            var DateTo = DateFrom.AddDays(1).AddMilliseconds(-1);
            var ReturnValue = GetTotalAppointments(StoreID, DateFrom, DateTo);

            return ReturnValue;
        }

        public static int GetTotalAppointments(Guid StoreID, DateTime DateFrom, DateTime DateTo)
        {
            var ReturnValue = (from a in db.Appointments
                               where a.StoreID == StoreID && a.StartTime >= DateFrom && a.StartTime <= DateTo
                               select a).Count();

            return ReturnValue;
        }

        public static List<int> GetSalesPerHour(Guid StoreID, DateTime StartingDateTime, DateTime EndingDateTime)
        {
            List<int> List = new List<int>();
            for (DateTime date = StartingDateTime; date <= EndingDateTime; date = date.AddHours(1))
            {
                List.Add(date.Hour);
            }
            return List;
        }

        public static IList<spCashOutDetail_Result> GetCashOutDetail(Guid StoreID, String FromDate, String ToDate)
        {
            var result = spCashOutDetail(StoreID, FromDate, ToDate);

            return result.ToList();
        }

        public static IEnumerable<spCashOutDetail_Result> spCashOutDetail(Nullable<System.Guid> StoreID, String fromDate, String toDate)
        {

            var StoreIDParameter = StoreID.HasValue ?
                new ObjectParameter("StoreID", StoreID) :
                new ObjectParameter("StoreID", typeof(System.Guid));


            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = $"EXEC [dbo].[spCashOutDetail] @StoreID = '{StoreIDParameter.Value.ToString()}', @FromDate ='{fromDate}' , @ToDate ='{toDate}'";

            var ReturnValue = unitOfWork.SQLQuery<spCashOutDetail_Result>(SQL);

            return ReturnValue;
        }

        #region Handle Stored Procs

        public static IEnumerable<spSalesOvertimeByService_Result> spSalesOvertimeByService(Nullable<System.Guid> companyID, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, string service)
        {
            var companyIDParameter = companyID.HasValue ?
                new ObjectParameter("CompanyID", companyID) :
                new ObjectParameter("CompanyID", typeof(System.Guid));

            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));

            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));

            var serviceParameter = service != null ?
                new ObjectParameter("Service", service) :
                new ObjectParameter("Service", typeof(string));

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = $"EXEC [dbo].[spSalesOvertimeByService] @CompanyID = '{companyIDParameter.Value.ToString()}', @FromDate = '{fromDateParameter.Value.ToString()}', @ToDate = '{toDateParameter.Value.ToString()}', @Service = '{serviceParameter.Value.ToString()}' ";
            var ReturnValue = unitOfWork.SQLQuery<spSalesOvertimeByService_Result>(SQL);

            //return db.Database.SqlQuery< spSalesOvertimeByService_Result>("spSalesOvertimeByService", companyIDParameter, fromDateParameter, toDateParameter, serviceParameter);
            //return ((IObjectContextAdapter))db.ExecuteFunction<spSalesOvertimeByService_Result>("spSalesOvertimeByService", companyIDParameter, fromDateParameter, toDateParameter, serviceParameter);

            return ReturnValue;
        }

        public static IEnumerable<spServiceTransactionsByCompany_Result> spServiceTransactionsByCompany(Nullable<System.Guid> companyID, Nullable<int> month)
        {
            var companyIDParameter = companyID.HasValue ?
                new ObjectParameter("CompanyID", companyID) :
                new ObjectParameter("CompanyID", typeof(System.Guid));

            var monthParameter = month.HasValue ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(int));

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = $"EXEC [dbo].[spServiceTransactionsByCompany] @CompanyID = '{companyIDParameter.Value.ToString()}', @Month = {monthParameter.Value} ";
            var ReturnValue = unitOfWork.SQLQuery<spServiceTransactionsByCompany_Result>(SQL);

            //return db.Database.SqlQuery<spServiceTransactionsByCompany_Result>("spServiceTransactionsByCompany", companyIDParameter, monthParameter);
            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spServiceTransactionsByCompany_Result>("spServiceTransactionsByCompany", companyIDParameter, monthParameter);

            return ReturnValue;
        }

        public static IEnumerable<spSalesComparison_Result> spSalesComparison(Guid StoreID)
        {

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = $"EXEC [dbo].[spSalesComparison]  @StoreID = '{StoreID.ToString()}'";
            var ReturnValue = unitOfWork.SQLQuery<spSalesComparison_Result>(SQL);

            //return db.Database.SqlQuery<spSalesComparison_Result>("spSalesComparison");
            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spSalesComparison_Result>("spSalesComparison");

            return ReturnValue;
        }

        public static IEnumerable<spSalesByCompany_Result> spSalesByCompany(Nullable<System.Guid> StoreID)
        {
            var StoreIDParameter = StoreID.HasValue ?
               new ObjectParameter("StoreID", StoreID) :
               new ObjectParameter("StoreID", typeof(System.Guid));

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = $"EXEC [dbo].[spSalesByCompany] @StoreID = '{StoreIDParameter.Value.ToString()}'";
            var ReturnValue = unitOfWork.SQLQuery<spSalesByCompany_Result>(SQL);

            return ReturnValue;
        }

        public static IEnumerable<spCategorySummaryDetail_Result> spCategorySummaryDetail(Nullable<System.Guid> StoreID, String FromDate, String ToDate)
        {
            var StoreIDParameter = StoreID.HasValue ?
               new ObjectParameter("StoreID", StoreID) :
               new ObjectParameter("StoreID", typeof(System.Guid));

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            //var SQL = $"EXEC [dbo].[spSalesByCompany] @CompanyID = '{CompanyIDParameter.Value.ToString()}'";
            var SQL = $"EXEC [dbo].[spCategorySummaryDetail] @StoreID = '{StoreIDParameter.Value.ToString()}' , @FromDate ='{FromDate}' , @ToDate ='{ToDate}'";

            var ReturnValue = unitOfWork.SQLQuery<spCategorySummaryDetail_Result>(SQL);

            return ReturnValue;
        }

        public static IEnumerable<spCategoryDetailProduct_Result> spCategoryDetailProduct(Nullable<System.Guid> StoreID, String FromDate, String ToDate)
        {
            var StoreIDParameter = StoreID.HasValue ?
               new ObjectParameter("StoreID", StoreID) :
               new ObjectParameter("StoreID", typeof(System.Guid));

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            //var SQL = $"EXEC [dbo].[spSalesByCompany] @CompanyID = '{CompanyIDParameter.Value.ToString()}'";
            var SQL = $"EXEC [dbo].[spCategoryDetailProduct]  @StoreID = '{StoreIDParameter.Value.ToString()}' , @FromDate ='{FromDate}' , @ToDate ='{ToDate}'";

            var ReturnValue = unitOfWork.SQLQuery<spCategoryDetailProduct_Result>(SQL);

            return ReturnValue;
        }

        public static IEnumerable<spCategoryDetailService_Result> spCategoryDetailService(Nullable<System.Guid> StoreID, String FromDate, String ToDate)
        {
            var StoreIDParameter = StoreID.HasValue ?
               new ObjectParameter("StoreID", StoreID) :
               new ObjectParameter("StoreID", typeof(System.Guid));

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            //var SQL = $"EXEC [dbo].[spSalesByCompany] @CompanyID = '{CompanyIDParameter.Value.ToString()}'";
            var SQL = $"EXEC [dbo].[spCategoryDetailService] @StoreID = '{StoreIDParameter.Value.ToString()}' , @FromDate ='{FromDate}' , @ToDate ='{ToDate}'";

            var ReturnValue = unitOfWork.SQLQuery<spCategoryDetailService_Result>(SQL);

            return ReturnValue;
        }

        public static IEnumerable<spPOS_Result> spPOS(Nullable<System.Guid> TransactionID)
        {
            var TransactionIDParameter = TransactionID.HasValue ?
               new ObjectParameter("TransactionID", TransactionID) :
               new ObjectParameter("TransactionID", typeof(System.Guid));

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = $"EXEC [dbo].[spPOS] @TransactionID = '{TransactionIDParameter.Value.ToString()}'";
            var ReturnValue = unitOfWork.SQLQuery<spPOS_Result>(SQL);

            return ReturnValue;
        }

        public static IEnumerable<spTransactionData_Result> spTransactionData(Nullable<System.Guid> TransactionID)
        {
            var TransactionIDParameter = TransactionID.HasValue ?
               new ObjectParameter("TransactionID", TransactionID) :
               new ObjectParameter("TransactionID", typeof(System.Guid));

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = $"EXEC [dbo].[spTransactionData] @TransactionID = '{TransactionIDParameter.Value.ToString()}'";
            var ReturnValue = unitOfWork.SQLQuery<spTransactionData_Result>(SQL);

            return ReturnValue;
        }

        public static IEnumerable<spServiceSalesOvertime_Result> spServiceSalesOvertime(Nullable<System.Guid> StoreID, Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate)
        {
            var StoreIDParameter = StoreID.HasValue ?
                new ObjectParameter("StoreID", StoreID) :
                new ObjectParameter("StoreID", typeof(System.Guid));

            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));

            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = $"EXEC [dbo].[spServiceSalesOvertime] @StoreID = '{StoreIDParameter.Value.ToString()}', @FromDate = '{fromDateParameter.Value.ToString()}', @ToDate = '{toDateParameter.Value.ToString()}' ";
            var ReturnValue = unitOfWork.SQLQuery<spServiceSalesOvertime_Result>(SQL);


            //return db.Database.SqlQuery<spServiceSalesOvertime_Result>("spServiceSalesOvertime", companyIDParameter, fromDateParameter, toDateParameter);
            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spServiceSalesOvertime_Result>("spServiceSalesOvertime", companyIDParameter, fromDateParameter, toDateParameter);

            return ReturnValue;
        }

        public static IEnumerable<spCashOutSummary_Result> spCashOutSummary(Nullable<System.Guid> CompanyID, Nullable<System.Guid> StoreID, String fromDate, String toDate)
        {
            var CompanyIDParameter = CompanyID.HasValue ?
               new ObjectParameter("CompanyID", CompanyID) :
               new ObjectParameter("CompanyID", typeof(System.Guid));

            var StoreIDParameter = StoreID.HasValue ?
                new ObjectParameter("StoreID", StoreID) :
                new ObjectParameter("StoreID", typeof(System.Guid));


            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = $"EXEC [dbo].[spCashOutSummary] @CompanyID = '{CompanyIDParameter.Value.ToString()}',  @StoreID = '{StoreIDParameter.Value.ToString()}', @FromDate ='{fromDate}' , @ToDate ='{toDate}'";

            var ReturnValue = unitOfWork.SQLQuery<spCashOutSummary_Result>(SQL);

            return ReturnValue;
        }

        #endregion

        #region Generate Data

        public static void GenerateTransactionData(Staff StaffEnt, int maxTransactions, DateTime startDate, DateTime endDate, int maxAppointments = 0)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var AppointmentEnt = new Appointment();
            var TransactionEnt = new Transaction();
            var oRand = new Random(Guid.NewGuid().GetHashCode());
            var Result = 0;
            var CompanyID = StaffEnt.CompanyID;
            var DateList = new List<DateTime>();
            var CustomerEnt = new Customer();
            var CustomerCol = unitOfWork.Customers.FindAll(c => c.CompanyID == CompanyID).ToList();
            var StaffCol = unitOfWork.Staffs.FindAll(c => c.StoreID == StaffEnt.StoreID && c.Role.ToLower().Contains(eRoles.Staff.ToString().ToLower())).ToList();
            var ServiceCol = unitOfWork.Services.FindAll(c => c.CompanyID == CompanyID).ToList();
            var ProductCol = unitOfWork.Products.FindAll(c => c.CompanyID == CompanyID).ToList();
            var TransactionCol = new List<Transaction>();
            var Count = DateList.Count();
            var TransactionList = new List<Guid>();
            var CurrentDate = DateTime.Now;
            var SaveChanges = true;
            int TotalAppointmentsAdded = 0;
            int TotalTransactionsAdded = 0;
            int TotalTransactionServicesAdded = 0;
            int TotalTransactionProductsAdded = 0;
            int StartHour = 8; //8:00 am
            int EndHour = 18; //6:00 pm
            int MaxAppointmentDuration = 60; // Max 1 hour appointment
            int MaxAppointmentsPerDay = 5; // Max appointments to create per day
            bool AddOnlyOneAppointment = false;
            var HourRange = Enumerable.Range(StartHour, EndHour - StartHour + 1).ToList();

            if (startDate.Date > endDate.Date)
            {
                startDate = endDate.Date;
            }

            if (maxTransactions == 0 && maxAppointments == 0) // Just create Appointments
            {
                DateList = Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days).Select(offset => startDate.AddDays(offset)).ToList();

                foreach (var oDate in DateList) // Each Date
                {
                    HourRange = Enumerable.Range(StartHour, EndHour - StartHour + 1).ToList();
                    MaxAppointmentsPerDay = oRand.Next(5, 8);

                    for (int appointmentCount = 0; appointmentCount < MaxAppointmentsPerDay; appointmentCount++)
                    {
                        var OnHour = HourRange.RandomElementUsing(oRand);
                        var Removed = HourRange.Remove(OnHour);

                        var StartTime = new DateTime(oDate.Date.Year, oDate.Date.Month, oDate.Date.Day, OnHour, 0, 0);
                        var EndTime = StartTime.AddMinutes(45);
                        var TransactionDate = EndTime;
                        var StaffTempCol = new List<Staff>();

                        StaffTempCol.Add(StaffCol[oRand.Next(0, StaffCol.Count - 1)]);

                        foreach (var oStaffEnt in StaffTempCol) // Each Staff
                        {
                            TransactionEnt = new Transaction();
                            AppointmentEnt = new Appointment();
                            CustomerEnt = CustomerCol[oRand.Next(0, CustomerCol.Count - 1)];

                            AppointmentEnt = CreateAppointment(CompanyID, oStaffEnt, CustomerEnt, StartTime, EndTime, ref unitOfWork, StaffCol, CustomerCol, ServiceCol, ProductCol, DateList, oRand, TransactionDate, ref TransactionEnt);

                            if (AppointmentEnt != null)
                            {
                                if (TransactionEnt != null)
                                {
                                    TotalTransactionsAdded++;
                                    TotalTransactionServicesAdded += TransactionEnt.TransactionDetailServices.Count;
                                    TotalTransactionProductsAdded += TransactionEnt.TransactionDetailProducts.Count;

                                    unitOfWork.Transactions.Add(TransactionEnt);
                                }

                            }

                            //For now
                            TimeSpan Duration = (AppointmentEnt.EndTime.Value - AppointmentEnt.StartTime.Value);

                            if (Duration.TotalMinutes > MaxAppointmentDuration)
                            {
                                AppointmentEnt.EndTime = AppointmentEnt.StartTime.Value.AddMinutes(MaxAppointmentDuration);
                            }

                            unitOfWork.Appointments.Add(AppointmentEnt);
                            TotalAppointmentsAdded++;

                            if (AddOnlyOneAppointment)
                            {
                                break;
                            }

                        }

                        if (AddOnlyOneAppointment)
                        {
                            break;
                        }

                    }

                    if (AddOnlyOneAppointment)
                    {
                        break;
                    }

                }

            }

            else
            {
                DateList = GetRandomDateRange(startDate, endDate).ToList();

                foreach (var TransactionDate in DateList)
                {
                    AppointmentEnt = null;
                    TransactionEnt = null;

                    var IsAppointment = GenerateAppointment(oRand);

                    if (IsInTheFuture(TransactionDate))
                    {
                        IsAppointment = true;
                    }

                    if (IsAppointment)
                    {
                        TransactionEnt = new Transaction();
                        CustomerEnt = CustomerCol[oRand.Next(0, CustomerCol.Count - 1)];

                        var StartTime = TransactionDate;
                        var EndTime = StartTime.AddMinutes(30);

                        AppointmentEnt = CreateAppointment(CompanyID, StaffEnt, CustomerEnt, StartTime, EndTime, ref unitOfWork, StaffCol, CustomerCol, ServiceCol, ProductCol, DateList, oRand, TransactionDate, ref TransactionEnt);

                        if (AppointmentEnt != null)
                        {
                            if (TransactionEnt != null)
                            {
                                TotalTransactionsAdded++;
                                TotalTransactionServicesAdded += TransactionEnt.TransactionDetailServices.Count;
                                TotalTransactionProductsAdded += TransactionEnt.TransactionDetailProducts.Count;

                                unitOfWork.Transactions.Add(TransactionEnt);
                            }

                        }

                        unitOfWork.Appointments.Add(AppointmentEnt);
                        TotalAppointmentsAdded++;

                    }
                    else
                    {
                        AppointmentEnt = null;
                        StaffEnt = StaffCol[oRand.Next(0, StaffCol.Count - 1)];
                        CustomerEnt = CustomerCol[oRand.Next(0, CustomerCol.Count - 1)];
                        TransactionEnt = CreateTransaction(CompanyID, StaffEnt, CustomerEnt, ref unitOfWork, StaffCol, CustomerCol, ServiceCol, ProductCol, TransactionDate, oRand, ref AppointmentEnt);

                        if (TransactionEnt != null)
                        {
                            TotalTransactionsAdded++;
                            TotalTransactionServicesAdded += TransactionEnt.TransactionDetailServices.Count;
                            TotalTransactionProductsAdded += TransactionEnt.TransactionDetailProducts.Count;

                            unitOfWork.Transactions.Add(TransactionEnt);
                        }
                    }
                }

            }

            var FinalResult = $"TotalAppointmentsAdded: {TotalAppointmentsAdded} TotalTransactionsAdded: {TotalTransactionsAdded} TotalTransactionServicesAdded: {TotalTransactionServicesAdded} TotalTransactionProductsAdded: {TotalTransactionProductsAdded}";

            if (SaveChanges)
            {
                Result = unitOfWork.Commit();
            }
            else
            {
                unitOfWork.RollBack();
            }

        }

        private static Transaction CreateTransaction(Guid CompanyID, Staff StaffEnt, Customer CustomerEnt, ref UnitOfWork unitOfWork, List<Staff> StaffCol, List<Customer> CustomerCol, List<Service> ServiceCol, List<Product> ProductCol, DateTime TransactionDate, Random oRand, ref Appointment appointmentEnt)
        {
            var ReturnValue = new Transaction();
            decimal TotalAmount = 0;
            decimal TotalTaxPercent = 5;
            decimal TotalTaxAmount = 0;
            decimal TotalDiscountPercent = 0;
            decimal TotalDiscountAmount = 0;
            decimal TotalTipAmount = 0;
            decimal GrandTotal = 0;
            int DecimalPlaces = 2;
            int Sequence = 1;
            int Duration = 0;
            bool IsFutureDate = IsInTheFuture(TransactionDate);
            var NotPaidPaymentType = GetNotPaidPaymentType(CompanyID);
            var CashPaymentType = GetCashPaymentType(CompanyID);

            ReturnValue.TransactionID = Guid.NewGuid();
            ReturnValue.CompanyID = CompanyID;
            ReturnValue.StoreID = StaffEnt.StoreID;
            ReturnValue.StaffID = StaffEnt.StaffID; //StaffCol[oRand.Next(0, StaffCol.Count - 1)].StaffID;
            ReturnValue.CustomerID = CustomerEnt.CustomerID; // CustomerCol[oRand.Next(0, CustomerCol.Count - 1)].CustomerID;
            ReturnValue.TransactionDate = TransactionDate;

            if (IsFutureDate)
            {
                ReturnValue.Status = eTransactionStatus.Appointment.ToString();
                ReturnValue.PaymentType = NotPaidPaymentType.Name;
                ReturnValue.PaymentTypeID = NotPaidPaymentType.PaymentTypeID;
            }
            else
            {
                ReturnValue.Status = eTransactionStatus.Paid.ToString();
                ReturnValue.PaymentType = CashPaymentType.Name;
                ReturnValue.PaymentTypeID = CashPaymentType.PaymentTypeID;
            }

            var MaxServiceRows = oRand.Next(0, 5); //0 - 5 will allow some Appointments with no services.
            var TempServiceCol = GetRandomList<Service>(ServiceCol, MaxServiceRows);

            if (MaxServiceRows == 0)
            {
                MaxServiceRows = 0;
            }

            for (int ServiceRow = 0; ServiceRow < MaxServiceRows; ServiceRow++)
            {
                var TransactionDetailServiceEnt = new TransactionDetailService();
                var ServiceEnt = TempServiceCol[ServiceRow];

                TransactionDetailServiceEnt.TransactionDetailServiceID = Guid.NewGuid();
                TransactionDetailServiceEnt.TransactionID = ReturnValue.TransactionID;
                TransactionDetailServiceEnt.ServiceID = ServiceEnt.ServiceID;
                TransactionDetailServiceEnt.Name = ServiceEnt.Name;
                TransactionDetailServiceEnt.Description = ServiceEnt.Description;
                TransactionDetailServiceEnt.Quantity = 1;
                TransactionDetailServiceEnt.UnitPrice = ServiceEnt.Price;
                TransactionDetailServiceEnt.DiscountPercent = 0;
                TransactionDetailServiceEnt.Duration = ServiceEnt.Duration;
                TransactionDetailServiceEnt.ShowOnline = true;
                TransactionDetailServiceEnt.Sequence = Sequence++;

                Duration += TransactionDetailServiceEnt.Duration;
                TotalAmount = TotalAmount + RecalTotal(TransactionDetailServiceEnt.UnitPrice, TransactionDetailServiceEnt.Quantity, TransactionDetailServiceEnt.DiscountPercent);

                ReturnValue.TransactionDetailServices.Add(TransactionDetailServiceEnt);

            }

            if (!IsFutureDate)
            {
                var MaxProductsRows = oRand.Next(1, 5);
                var TempProductCol = GetRandomList<Product>(ProductCol, MaxProductsRows);

                for (int ProductRow = 0; ProductRow < MaxProductsRows; ProductRow++)
                {
                    var TransactionDetailProductEnt = new TransactionDetailProduct();
                    var ProductEnt = TempProductCol[ProductRow];

                    TransactionDetailProductEnt.TransactionDetailProductID = Guid.NewGuid();
                    TransactionDetailProductEnt.TransactionID = ReturnValue.TransactionID;
                    TransactionDetailProductEnt.ProductID = ProductEnt.ProductID;
                    TransactionDetailProductEnt.Name = ProductEnt.Name;
                    TransactionDetailProductEnt.Description = ProductEnt.Description;
                    TransactionDetailProductEnt.Quantity = oRand.Next(1, 5);
                    TransactionDetailProductEnt.UnitPrice = ProductEnt.Price;
                    TransactionDetailProductEnt.WholesalePrice = ProductEnt.WholesalePrice;
                    TransactionDetailProductEnt.Commission = 0;
                    TransactionDetailProductEnt.BarCode = $"{ProductRow}";
                    TransactionDetailProductEnt.Sequence = Sequence++;

                    TotalAmount = TotalAmount + RecalTotal(TransactionDetailProductEnt.UnitPrice, TransactionDetailProductEnt.Quantity, TransactionDetailProductEnt.DiscountPercent);

                    ReturnValue.TransactionDetailProducts.Add(TransactionDetailProductEnt);

                }
            }

            // Refresh Summary columns
            TotalDiscountPercent = 0;
            TotalDiscountAmount = Math.Round((TotalDiscountPercent / 100) * TotalAmount, DecimalPlaces);
            TotalTaxAmount = Math.Round((TotalTaxPercent / 100) * (TotalAmount - TotalDiscountAmount), DecimalPlaces);
            GrandTotal = Math.Round((TotalAmount - TotalDiscountAmount) + TotalTaxAmount + TotalTipAmount, DecimalPlaces);

            ReturnValue.Amount = TotalAmount;
            ReturnValue.DiscountPercent = TotalDiscountPercent;
            ReturnValue.TaxPercent = TotalTaxPercent;
            ReturnValue.TipAmount = TotalTipAmount;
            ReturnValue.Total = GrandTotal;

            if (appointmentEnt != null)
            {
                appointmentEnt.EndTime = appointmentEnt.StartTime.Value.AddMinutes(Duration);

                ReturnValue.AppointmentID = appointmentEnt.AppointmentID;
                ReturnValue.TransactionDate = appointmentEnt.EndTime;
                ReturnValue.StoreID = StaffEnt.StoreID;
                ReturnValue.StaffID = appointmentEnt.StaffID;
                ReturnValue.CustomerID = appointmentEnt.CustomerID;
            }

            return ReturnValue;
        }

        private static Appointment CreateAppointment(Guid CompanyID, Staff StaffEnt, Customer CustomerEnt, DateTime StartTime, DateTime EndTime, ref UnitOfWork unitOfWork, List<Staff> StaffCol, List<Customer> CustomerCol, List<Service> ServiceCol, List<Product> ProductCol, List<DateTime> DateList, Random oRand, DateTime TransactionDate, ref Transaction TransactionEnt)
        {
            var AppointmentEnt = new Appointment();
            //var CustomerEnt = CustomerCol[oRand.Next(0, CustomerCol.Count - 1)];
            //StaffEnt = StaffCol[oRand.Next(0, StaffCol.Count - 1)];
            bool IsFutureDate = IsInTheFuture(TransactionDate);
            var StoreTimeZone = GetTimeZoneByStoreID(StaffEnt.StoreID);

            AppointmentEnt.AppointmentID = Guid.NewGuid();
            AppointmentEnt.CompanyID = (Guid)StaffEnt.CompanyID;
            AppointmentEnt.StoreID = (Guid)StaffEnt.StoreID;
            AppointmentEnt.StaffID = (Guid)StaffEnt.StaffID;
            AppointmentEnt.CustomerID = CustomerEnt.CustomerID;
            AppointmentEnt.StartTime = StartTime; // TransactionDate;
            AppointmentEnt.EndTime = EndTime; // AppointmentEnt.StartTime.Value.AddMinutes(30); // DateList[Row];
            AppointmentEnt.StartTimeZone = StoreTimeZone;
            AppointmentEnt.EndTimeZone = StoreTimeZone;
            AppointmentEnt.Subject = FormatAppointmentSubject(AppointmentEnt, unitOfWork);
            AppointmentEnt.Description = FormatAppointmentDescription(AppointmentEnt, unitOfWork);
            AppointmentEnt.AllDay = false;

            if (IsFutureDate)
            {
                AppointmentEnt.Status = Convert.ToInt32(SalonDB.Data.CategorizeSettings.GetScheduledID());
            }
            else
            {
                AppointmentEnt.Status = Convert.ToInt32(SalonDB.Data.CategorizeSettings.GetCheckedOutID());
            }

            TransactionEnt = CreateTransaction(CompanyID, StaffEnt, CustomerEnt, ref unitOfWork, StaffCol, CustomerCol, ServiceCol, ProductCol, TransactionDate, oRand, ref AppointmentEnt);

            // Have to update Subject after creating its Transaction.
            AppointmentEnt.Subject = FormatAppointmentSubject(AppointmentEnt, unitOfWork);
            AppointmentEnt.Description = FormatAppointmentDescription(AppointmentEnt, unitOfWork);

            return AppointmentEnt;
        }

        private static bool GenerateAppointment(Random oRand)
        {
            var ReturnValue = false;

            //TranType 1 = Transaction, 2 = Appointment
            var TranType = oRand.Next(1, 100);

            ReturnValue = TranType >= 50;

            return ReturnValue;
        }

        private static int GetHour(Random oRand, int startHour, int endHour)
        {
            var ReturnValue = oRand.Next(startHour, endHour);

            return ReturnValue;
        }

        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.RandomElementUsing<T>(new Random());
        }

        public static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand)
        {
            int index = rand.Next(0, enumerable.Count());
            return enumerable.ElementAt(index);
        }

        private static bool IsInTheFuture(DateTime Date)
        {
            var ReturnValue = Date.Date >= DateTime.Now.Date;

            return ReturnValue;
        }

        private static List<DateTime> GetRandomDateRange(DateTime startDate, DateTime endDate)
        {
            var ReturnValue = new List<DateTime>();
            var oRand = new Random(Guid.NewGuid().GetHashCode());
            //var oTS = DateTimeSpan.CompareDates(startDate, endDate);
            TimeSpan oTimeSpan = endDate.Subtract(startDate);
            //var Months = GetMonthDifference(startDate, endDate);

            if (endDate < startDate)
                throw new ArgumentException("endDate must be greater than or equal to startDate");

            var start = startDate;
            var end = endDate;

            // set end-date to end of month
            end = new DateTime(end.Year, end.Month, DateTime.DaysInMonth(end.Year, end.Month));

            //var diff = Enumerable.Range(0, Int32.MaxValue)
            //                     .Select(e => start.AddMonths(e))
            //                     .TakeWhile(e => e <= end)
            //                     .Select(e => e.ToString("MMMM")).ToList();

            var Months = Enumerable.Range(0, Int32.MaxValue)
                                .Select(e => start.AddMonths(e))
                                .TakeWhile(e => e <= end)
                                .Select(e => e.Date).ToList();

            //foreach (var item in Months)
            //{
            //    var TDate = item.Date;

            //    //while (TempDate.Date.DayOfWeek != DayOfWeek.Monday && TempDate.Date.Day <= 7)
            //    //{
            //    //    TempDate = TempDate.AddDays(1);
            //    //}

            //    //if (TempDate.Date.DayOfWeek == DayOfWeek.Monday && TempDate.Date.Day <= 7)
            //    //{
            //    //    ReturnValue.Add(TempDate);
            //    //}

            //    var TempDate = Enumerable.Range(0, 7)
            //                       .Select(e => TDate.Date.AddDays(e))
            //                       .Where(e => e.Date.DayOfWeek == DayOfWeek.Monday)
            //                       .Select(e => e.Date).ToList();

            //    if (TempDate.Count == 1)
            //    {
            //        ReturnValue.Add(TempDate[0]);
            //    }
            //}

            var TempData = Enumerable.Range(0, (int)oTimeSpan.TotalDays + 1)
                                   .Select(e => start.Date.AddDays(e))
                                   .Where(e => (e.Date.DayOfWeek != DayOfWeek.Saturday && e.Date.DayOfWeek != DayOfWeek.Sunday))
                                   .Select(e => e.Date).ToList();

            foreach (var item in TempData)
            {
                var Hour = oRand.Next(9, 18);
                var TempDate = new DateTime(item.Date.Year, item.Date.Month, item.Date.Day, Hour, 0, 0);

                ReturnValue.Add(TempDate);
            }

            return ReturnValue;
        }

        public static string GetTimeZoneByStoreID(Guid? storeID = null)
        {
            var ReturnValue = string.Empty;
            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var StoreEnt = new Store();

            if (storeID == null || storeID == Guid.Empty)
            {
                ReturnValue = GetCurrentTimeZone();
            }
            else
            {
                StoreEnt = unitOfWork.Stores.Get((Guid)storeID);
                ReturnValue = StoreEnt.TimeZone;
            }

            return ReturnValue;
        }

        public static string GetCurrentTimeZone()
        {
            var ReturnValue = string.Empty;

            System.Globalization.CultureInfo.CurrentCulture.ClearCachedData(); // clear the cache 

            TimeZone localZone = TimeZone.CurrentTimeZone; // time zone will be updated after clearing the cache   
            DateTime currentDate = DateTime.Now;
            int currentYear = currentDate.Year;

            var a1 = localZone.IsDaylightSavingTime(currentDate);

            DateTime currentUTC = localZone.ToUniversalTime(currentDate);
            TimeSpan currentOffset = localZone.GetUtcOffset(currentDate);
            System.Globalization.DaylightTime daylight = localZone.GetDaylightChanges(currentYear);
            var a2 = $"{daylight.Start:yyyy-MM-dd HH:mm}";
            var a3 = $"{daylight.End:yyyy-MM-dd HH:mm}";
            var a4 = $"delta: {daylight.Delta}";
            var CTZ = $"{currentOffset}";
            int count = CTZ.Split(':').Length - 1;
            var Breakup = CTZ.Split(':');
            ReturnValue = CTZ;

            if (Breakup.Length > 2)
            {
                ReturnValue = $"{Breakup[0]}:{Breakup[1]}";
            }

            ReturnValue = $"UTC {ReturnValue}";

            return ReturnValue;
        }

        public static decimal RecalTotal(decimal price, int quantity, decimal discountpercentage)
        {
            decimal ReturnValue = 0;
            decimal DiscountAmount = 0;
            decimal Amount = 0;
            int decimalPlaces = 2;
            try
            {
                Amount = price * quantity;
                DiscountAmount = Math.Round((discountpercentage / 100) * Amount, decimalPlaces);
                //DiscountAmount = Math.round((discountpercentage / 100) * Amount);
                ReturnValue = Math.Round((Amount - DiscountAmount), decimalPlaces);
            }
            catch (Exception)
            {
                ReturnValue = 0;
            }

            return ReturnValue;
        }

        public static string FormatAppointmentSubject(SalonDB.Data.Core.Domain.Appointment appointmentEnt, UnitOfWork unitOfWork)
        {
            var ReturnValue = string.Empty;

            if (appointmentEnt != null)
            {
                var CustomerEnt = unitOfWork.Customers.Get(appointmentEnt.CustomerID);
                DateTime StartTime = (DateTime)appointmentEnt.StartTime;
                DateTime EndTime = (DateTime)appointmentEnt.EndTime;
                TimeSpan Duration = EndTime.Subtract(StartTime);

                //ReturnValue = $"{CustomerEnt.FirstName} {CustomerEnt.LastName} - {appointmentEnt.StartTime} {appointmentEnt.EndTime} {Duration}";
                ReturnValue = $"Customer: {CustomerEnt.FirstName} {CustomerEnt.LastName}";
            }

            return ReturnValue;
        }

        public static string FormatAppointmentDescription(SalonDB.Data.Core.Domain.Appointment appointmentEnt, UnitOfWork unitOfWork)
        {
            var ReturnValue = string.Empty;

            if (appointmentEnt != null)
            {
                var CustomerEnt = unitOfWork.Customers.Get(appointmentEnt.CustomerID);
                DateTime StartTime = (DateTime)appointmentEnt.StartTime;
                DateTime EndTime = (DateTime)appointmentEnt.EndTime;
                TimeSpan Duration = EndTime.Subtract(StartTime);

                //ReturnValue = $"{CustomerEnt.FirstName} {CustomerEnt.LastName} - {appointmentEnt.StartTime} {appointmentEnt.EndTime} {Duration}";
                ReturnValue = $"Duration (mins): {Duration}";
            }

            return ReturnValue;
        }

        private static PaymentType GetCashPaymentType(Guid companyID)
        {
            var ReturnValue = new PaymentType();
            ReturnValue = db.PaymentTypes.Where(c => c.CompanyID == companyID && c.Name == ePaymentType.Cash.ToString()).SingleOrDefault();

            return ReturnValue;
        }

        private static PaymentType GetNotPaidPaymentType(Guid companyID)
        {
            var ReturnValue = new PaymentType();
            ReturnValue = db.PaymentTypes.Where(c => c.CompanyID == companyID && c.Name == ePaymentType.NotPaid.ToString()).SingleOrDefault();

            return ReturnValue;
        }

        public static List<string> EnumToList<TEntity>(TEntity source)
        {
            var ReturnValue = Enum.GetNames(typeof(TEntity)).ToList();

            return ReturnValue;
        }

        private static List<TEntity> GetRandomList<TEntity>(List<TEntity> sourceList, int maxRows) where TEntity : class
        {
            var ReturnValue = new List<TEntity>();

            if (maxRows > sourceList.Count)
            {
                maxRows = sourceList.Count;
            }

            ReturnValue = sourceList.OrderBy(p => (p.GetHashCode().ToString() + Guid.NewGuid().ToString()).GetHashCode()).Take(maxRows).ToList();

            return ReturnValue;
        }

        private static TEntity ParseEnum<TEntity>(string value)
        {
            return (TEntity)Enum.Parse(typeof(TEntity), value, true);
        }

        private static TEntity RandomEnumValue<TEntity>()
        {
            var enumEnt = Enum.GetValues(typeof(TEntity));
            var oRand = new Random(Guid.NewGuid().GetHashCode());
            return (TEntity)enumEnt.GetValue(oRand.Next(enumEnt.Length));
        }

        private static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
        #endregion

        #region Dashboard Routines

        private static string GetTopSQL(int top, DateTime fromDate, DateTime toDate, Guid storeID, string fromTableName)
        {
            var ReturnValue = $"Select Top {top} b.[Name], Sum(round((b.[UnitPrice] * b.[Quantity]) - ((b.[DiscountPercent] / 100 ) * (b.[UnitPrice] * b.[Quantity])),2)) as [Total] From [Transaction] as a Inner Join [{fromTableName}] as b on a.[TransactionID] = b.[TransactionID] Where a.[StoreID] = '{storeID.ToString()}' and convert(date, a.[TransactionDate]) >= '{fromDate.ToString("yyyy-MM-dd")}' and convert(date, a.[TransactionDate]) <= '{toDate.ToString("yyyy-MM-dd")}' Group By b.[Name] Order By [Total] Desc, b.[Name] Asc";

            return ReturnValue;
        }

        private static string GetSalesSQL(DateTime fromDate, DateTime toDate, Guid storeID, string fromTableName)
        {
            var ReturnValue = $"Select Sum(round((b.[UnitPrice] * b.[Quantity]) - ((b.[DiscountPercent] / 100 ) * (b.[UnitPrice] * b.[Quantity])),2)) as [Total] From [Transaction] as a Inner Join [{fromTableName}] as b on a.[TransactionID] = b.[TransactionID] Where a.[StoreID] = '{storeID.ToString()}' and convert(date, a.[TransactionDate]) >= '{fromDate.ToString("yyyy-MM-dd")}' and convert(date, a.[TransactionDate]) <= '{toDate.ToString("yyyy-MM-dd")}'";

            return ReturnValue;
        }

        private static string GetSalesByHourSQL(DateTime fromDate, DateTime toDate, Guid storeID)
        {
            var StatusPaid = eTransactionStatus.Paid.ToString();
            var ReturnValue = $"Select dateadd(hour, datediff(hour, 0, [TransactionDate]), 0) as [Hour], sum([Total]) as [Total], count(*) as [Count] from [Transaction] Where [StoreID] = '{storeID.ToString()}' and [Status] = '{StatusPaid}' and convert(date, [TransactionDate]) >= '{fromDate.ToString("yyyy-MM-dd")}' and convert(date, [TransactionDate]) <= '{toDate.ToString("yyyy-MM-dd")}' Group By dateadd(hour, datediff(hour, 0, [TransactionDate]), 0) Order By dateadd(hour, datediff(hour, 0, [TransactionDate]), 0);";

            return ReturnValue;
        }


        public static IEnumerable<spTopServiceProducts_Result> GetTopServices(int top, Guid storeID, DateTime fromDate, DateTime toDate)
        {
            var storeIDParameter = new ObjectParameter("StoreID", storeID);
            var fromDateParameter = new ObjectParameter("FromDate", fromDate);
            var toDateParameter = new ObjectParameter("ToDate", toDate);
            var FromTableName = "TransactionDetailService";

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = GetTopSQL(top, fromDate, toDate, storeID, FromTableName);

            var ReturnValue = unitOfWork.SQLQuery<spTopServiceProducts_Result>(SQL);

            return ReturnValue;
        }

        public static IEnumerable<spTopServiceProducts_Result> GetTopProducts(int top, Guid storeID, DateTime fromDate, DateTime toDate)
        {
            var storeIDParameter = new ObjectParameter("StoreID", storeID);
            var fromDateParameter = new ObjectParameter("FromDate", fromDate);
            var toDateParameter = new ObjectParameter("ToDate", toDate);
            var FromTableName = "TransactionDetailProduct";

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = GetTopSQL(top, fromDate, toDate, storeID, FromTableName);

            var ReturnValue = unitOfWork.SQLQuery<spTopServiceProducts_Result>(SQL);

            return ReturnValue;
        }

        public static Decimal GetSales(Guid storeID, DateTime fromDate, DateTime toDate)
        {
            decimal ReturnValue = 0;
            var storeIDParameter = new ObjectParameter("StoreID", storeID);
            var fromDateParameter = new ObjectParameter("FromDate", fromDate);
            var toDateParameter = new ObjectParameter("ToDate", toDate);
            var ServiceTableName = "TransactionDetailService";
            var ProductTableName = "TransactionDetailProduct";

            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL1 = GetSalesSQL(fromDate, toDate, storeID, ServiceTableName);
            var SQL2 = GetSalesSQL(fromDate, toDate, storeID, ProductTableName);
            var SQL = $"{SQL1} union {SQL2}";

            try
            {
                var Result = unitOfWork.SQLQuery<Decimal>(SQL).ToList();

                if (Result != null)
                {
                    foreach (decimal item in Result)
                    {
                        ReturnValue += item;
                    }
                }
            }
            catch (Exception)
            {
                // Log the error here.
                ReturnValue = 0;
            }

            return ReturnValue;
        }

        public static Dictionary<DateTime, decimal> GetSalesByHour(Guid storeID, DateTime fromDate, DateTime toDate)
        {
            var ReturnValue = new Dictionary<DateTime, decimal>();
            var ErrorMessage = string.Empty;
            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
            var SQL = GetSalesByHourSQL(fromDate, toDate, storeID);

            try
            {
                var Hours = GetSalesPerHour(storeID, fromDate, toDate);
                var Result = unitOfWork.SQLQuery<spSalesByHour_Result>(SQL).ToList();
                var FoundEnt = new spSalesByHour_Result();

                foreach (int Hour in Hours)
                {
                    var SalesDate = new DateTime(fromDate.Date.Year, fromDate.Date.Month, fromDate.Date.Day, Hour, 0, 0);

                    if (Result == null)
                    {
                        FoundEnt = null;
                    }
                    else
                    {
                        FoundEnt = (from oRow in Result where oRow.Hour == SalesDate select oRow).SingleOrDefault();
                    }

                    if (FoundEnt == null)
                    {
                        ReturnValue.Add(SalesDate, 0);
                    }
                    else
                    {
                        ReturnValue.Add(SalesDate, FoundEnt.Total);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                ReturnValue = null;
            }


            return ReturnValue;
        }

        #endregion

        #region RegisterCompany Routines

        public static Staff RegisterCompany(string firstName, string lastName, string phone, string email, string password, string companyName, string storeName, string storeAddress, string storeCity, string storePostalCode, string storeTimeZone, string defaultRole, DateTime registeredOn, string registrationType, ref List<string> errorMessages, bool captchaValid, string captchaError)
        {
            Staff ReturnValue = null;
            Company CompanyEnt = null;
            Store StoreEnt = null;
            UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());

            errorMessages = new List<string>();

            if (string.IsNullOrEmpty(firstName))
            {
                errorMessages.Add("First Name cannot be blank.");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                errorMessages.Add("Last Name cannot be blank.");
            }

            if (string.IsNullOrEmpty(password))
            {
                errorMessages.Add("Password cannot be blank.");
            }

            if (string.IsNullOrEmpty(email))
            {
                errorMessages.Add("Email cannot be blank.");
            }

            if (string.IsNullOrEmpty(companyName))
            {
                errorMessages.Add("Company Name cannot be blank.");
            }

            if (string.IsNullOrEmpty(storeName))
            {
                errorMessages.Add("Store Name cannot be blank.");
            }

            if (!captchaValid)
            {
                errorMessages.Add(captchaError);
            }

            if (errorMessages.Count == 0)
            {
                var StaffFoundEnt = unitOfWork.Staffs.Find(c => c.Email == email);

                if (StaffFoundEnt != null)
                {
                    // Found so error
                    errorMessages.Add("Cannot use this Email as it's already in use.");
                }
                else
                {
                    var CompanyFounfEnt = unitOfWork.Companys.Find(c => c.Name == companyName);

                    if (CompanyFounfEnt != null)
                    {
                        // Found so error
                        errorMessages.Add("Cannot use this Company Name as it's already in use.");
                    }
                    else
                    {
                        // If we are here then we have passed all validation are ready to create a new company and related data.
                        CompanyEnt = new Company();
                        StoreEnt = new Store();
                        ReturnValue = new Staff();

                        try
                        {
                            CompanyEnt.CompanyID = Guid.NewGuid();
                            CompanyEnt.Name = companyName;
                            CompanyEnt.Description = companyName;
                            CompanyEnt.RegisteredOn = registeredOn;
                            CompanyEnt.RegistrationType = registrationType;
                            unitOfWork.Companys.Add(CompanyEnt);

                            StoreEnt.StoreID = Guid.NewGuid();
                            StoreEnt.CompanyID = CompanyEnt.CompanyID;
                            StoreEnt.Name = storeName;
                            StoreEnt.Description = storeName;
                            StoreEnt.Address = storeAddress;
                            StoreEnt.City = storeCity;
                            StoreEnt.PostalCode = storePostalCode;
                            StoreEnt.TimeZone = storeTimeZone;
                            unitOfWork.Stores.Add(StoreEnt);

                            ReturnValue.StaffID = Guid.NewGuid();
                            ReturnValue.CompanyID = CompanyEnt.CompanyID;
                            ReturnValue.StoreID = StoreEnt.StoreID;
                            ReturnValue.FirstName = firstName;
                            ReturnValue.LastName = lastName;
                            ReturnValue.Phone = phone;
                            ReturnValue.Email = email;
                            ReturnValue.Password = password;
                            ReturnValue.Role = defaultRole;
                            ReturnValue.ResourceColor = "#51a0ed";
                            unitOfWork.Staffs.Add(ReturnValue);

                            unitOfWork.Commit();

                        }
                        catch (Exception ex)
                        {
                            unitOfWork.RollBack();
                            ReturnValue = null;
                            errorMessages.Add(ex.Message);
                        }

                    }

                }
            }

            return ReturnValue;
        }

        #endregion

        #region Clear Appointments/Transactions

        public static string DeleteAppointment(Guid appointmentID)
        {
            var ReturnValue = string.Empty;

            try
            {
                using (var context = db)
                {
                    var parent = context.Appointments
                        //.Include(p => p.Transactions)
                        //.Include(p => p.Transactions.Select(c1 => c1.TransactionDetailServices))
                        //.Include(p => p.Transactions.Select(c1 => c1.TransactionDetailProducts))
                        .SingleOrDefault(p => p.AppointmentID == appointmentID);

                    //foreach (var child in parent.Transactions.ToList())
                    //    //context.Transactions.Remove(child);

                    if (parent != null)
                    {
                        var TransEnt = context.Transactions.Where(c => c.AppointmentID == appointmentID).SingleOrDefault();
                        if (TransEnt != null)
                        {
                            DeleteTransaction(TransEnt.TransactionID);
                        }
                        else
                        {
                            db.Appointments.Remove(parent);
                            context.SaveChanges();
                        }

                    }
                   
                }
            }
            catch (Exception ex)
            {
                ReturnValue = ex.Message;
            }

            return ReturnValue;
        }

        public static string DeleteTransaction(Guid transactionID)
        {
            var ReturnValue = string.Empty;
           
            try
            {
                using (var context = db)
                {
                    var parent = context.Transactions.Include(p => p.Appointment).Include(p => p.TransactionDetailServices).Include(p => p.TransactionDetailProducts)
                        .SingleOrDefault(p => p.TransactionID == transactionID);

                    if (parent.Appointment != null)
                        context.Appointments.Remove(parent.Appointment);

                    foreach (var child in parent.TransactionDetailServices.ToList())
                        context.TransactionDetailServices.Remove(child);

                    foreach (var child in parent.TransactionDetailProducts.ToList())
                        context.TransactionDetailProducts.Remove(child);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ReturnValue = ex.Message;
            }

            return ReturnValue;
        }


        #endregion
    }
}

public struct DateTimeSpan
{
    private readonly int years;
    private readonly int months;
    private readonly int days;
    private readonly int hours;
    private readonly int minutes;
    private readonly int seconds;
    private readonly int milliseconds;

    public DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
    {
        this.years = years;
        this.months = months;
        this.days = days;
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
        this.milliseconds = milliseconds;
    }

    public int Years { get { return years; } }
    public int Months { get { return months; } }
    public int Days { get { return days; } }
    public int Hours { get { return hours; } }
    public int Minutes { get { return minutes; } }
    public int Seconds { get { return seconds; } }
    public int Milliseconds { get { return milliseconds; } }

    enum Phase { Years, Months, Days, Done }

    public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
    {
        if (date2 < date1)
        {
            var sub = date1;
            date1 = date2;
            date2 = sub;
        }

        DateTime current = date1;
        int years = 0;
        int months = 0;
        int days = 0;

        Phase phase = Phase.Years;
        DateTimeSpan span = new DateTimeSpan();
        int officialDay = current.Day;

        while (phase != Phase.Done)
        {
            switch (phase)
            {
                case Phase.Years:
                    if (current.AddYears(years + 1) > date2)
                    {
                        phase = Phase.Months;
                        current = current.AddYears(years);
                    }
                    else
                    {
                        years++;
                    }
                    break;
                case Phase.Months:
                    if (current.AddMonths(months + 1) > date2)
                    {
                        phase = Phase.Days;
                        current = current.AddMonths(months);
                        if (current.Day < officialDay && officialDay <= DateTime.DaysInMonth(current.Year, current.Month))
                            current = current.AddDays(officialDay - current.Day);
                    }
                    else
                    {
                        months++;
                    }
                    break;
                case Phase.Days:
                    if (current.AddDays(days + 1) > date2)
                    {
                        current = current.AddDays(days);
                        var timespan = date2 - current;
                        span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                        phase = Phase.Done;
                    }
                    else
                    {
                        days++;
                    }
                    break;
            }
        }

        return span;
    }
}
