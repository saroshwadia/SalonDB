using System;
using System.Linq;
using System.Web.Mvc;
using SalonDB.Data;
using SalonDB.Data.Persistence;
using SalonDB.Web.Models;

namespace SalonDB.Web.Controllers
{
    public class AdminController : Controller
    {

        UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
        Guid CompanyID = Guid.Empty;
        Guid StoreID = Guid.Empty;
        LoginViewModel LoginInfo = new LoginViewModel();
        AdminViewModel AdminViewModel = null;

        [AuthorizeRoles(eRoles.Admin)]
        public ActionResult Index()
        {

            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            CompanyID = LoginInfo.CompanyID;
            StoreID = LoginInfo.StoreID;
            AdminViewModel = new AdminViewModel();
            AdminViewModel.Services = unitOfWork.Services.FindAll(c => c.StoreID == StoreID).ToList();
            AdminViewModel.Products = unitOfWork.Products.FindAll(c => c.StoreID == StoreID).ToList();
            AdminViewModel.Staffs = unitOfWork.Staffs.FindAll(c => c.StoreID == StoreID).ToList();
            AdminViewModel.Stores = unitOfWork.Stores.FindAll(c => c.CompanyID == CompanyID).ToList();
            AdminViewModel.Customers = unitOfWork.Customers.FindAll(c => c.CompanyID == CompanyID).ToList();
            AdminViewModel.Companies = unitOfWork.Companys.FindAll(c => c.CompanyID == CompanyID).ToList();
            AdminViewModel.Categories = unitOfWork.Categorys.FindAll(c => c.CompanyID == CompanyID).ToList();
            AdminViewModel.Suppliers = unitOfWork.Suppliers.FindAll(c => c.CompanyID == CompanyID).ToList();

            return View(AdminViewModel);
        }

        [AuthorizeRoles(eRoles.Admin)]
        [HttpPost]
        public ActionResult Index(string viewName)
        {
            LoadViewModelData(viewName);

            return View(AdminViewModel);
        }

        private void LoadViewModelData(string viewName)
        {
            var All = false; // viewName == "*";
            AdminViewModel = new AdminViewModel();
            AdminViewModel.Name = viewName;
            //AdminViewModel.Companies = DBProvider.GetCompanys();
            if (All || viewName == "_Product")
            {
                AdminViewModel.Products = unitOfWork.Products.FindAll(c => c.StoreID == StoreID).ToList();
            }

            if (All || viewName == "_Service")
            {
                AdminViewModel.Services = unitOfWork.Services.FindAll(c => c.StoreID == StoreID).ToList();
            }
            //AdminViewModel.Suppliers = DBProvider.GetSuppliers();
            //AdminViewModel.Categories = DBProvider.GetCategories();
            //AdminViewModel.Suppliers = DBProvider.GetSuppliers();

            if (All || viewName == "_Staff")
            {
                AdminViewModel.Staffs = unitOfWork.Staffs.FindAll(c => c.StoreID == StoreID).ToList();
            }

            //AdminViewModel.Stores = DBProvider.GetStores();

            if (All || viewName == "_Customer")
            {
                AdminViewModel.Customers = unitOfWork.Customers.FindAll(c => c.CompanyID == CompanyID).ToList();
            }

        }
    }
}