using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalonDB.Data.Core.Domain;
using SalonDB.Web.Models;
using SalonDB.Data;
using SalonDB.Data.Persistence;

namespace SalonDB.Web.Controllers
{
    public class ReportController : Controller
    {

        UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
        Guid CompanyID = Guid.Empty;
        LoginViewModel LoginInfo = new LoginViewModel();

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ReportPartial(string fcn)
        {

            ViewBag.ReportName = fcn;
            return PartialView("_PartialReportViewer", ViewData);
        }

        public PartialViewResult CategoryDetailReport(string fromDate, string toDate)
        {

            ViewBag.ReportName = "CategoryDetailReport";
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            return PartialView("_ReportViewerFromToDate", ViewData);
        }


        public PartialViewResult CategorySummaryReport(string fromDate, string toDate)
        {

            ViewBag.ReportName = "CategorySummaryReport";
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            return PartialView("_ReportViewerFromToDate", ViewData);
        }

        public PartialViewResult CashOutSummaryReport(string fromDate, string toDate)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);


            ViewBag.ReportName = "CashOutSummaryReport";
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            ViewBag.CompanyID = LoginInfo.CompanyID.ToString();
            ViewBag.StoreID = LoginInfo.StoreID.ToString();
            //var CashOutSummary = DBProvider.GetCashOutSummary(LoginInfo.CompanyID, LoginInfo.StoreID, fromDate, toDate);
            //ViewBag.DataSource = CashOutSummary;
            return PartialView("_ReportViewerFromToDate", ViewData);
        }

        public PartialViewResult CashOutDetailReport(string fromDate, string toDate)
        {

            ViewBag.ReportName = "CashOutDetailReport";
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            return PartialView("_ReportViewerFromToDate", ViewData);
        }

        public ViewResult POSReport(string reportName, string transactionID)
        {
            Guid TransactionID = new Guid(transactionID);

            var POS = DBProvider.GetPOS(TransactionID);
            var TransactionData = DBProvider.GetTransactionData(TransactionID);


            ViewBag.ReportName = reportName;
            ViewBag.TransactionID = transactionID;
            ViewBag.POS = POS;
            ViewBag.TransactionData = TransactionData;
            return View("POSReport", ViewData);
        }


        public PartialViewResult SalesComparison()
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            var result = DBProvider.GetSalesComparison(LoginInfo.StoreID).OrderBy(x => x.Month).ToList();
            return PartialView(result);

        }

        public PartialViewResult CurrentMonthServiceSales()
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);


            var Result = DBProvider.GetServiceSalesCurrentMonth(LoginInfo.StoreID);
            return PartialView(Result);

        }

        public PartialViewResult ServiceSalesMonthly()
        {

            var ServiceSalesView = new Models.ServiceSalesMonthlyViewModel();

            ServiceSalesView.Month = DBProvider.GetMonth();
            ServiceSalesView.Year = DBProvider.GetYear();

            return PartialView(ServiceSalesView);
        }
        public PartialViewResult _SalesMonthlyChart(string month, string year)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);

            var ServiceSalesChartView = new Models.ServiceSalesMonthlyChartViewModel();
            ServiceSalesChartView.Label = month + " " + year;
            ServiceSalesChartView.Chart = DBProvider.GetServiceSalesMonthlyByMonthYear(month, year, LoginInfo.StoreID).ToList();
           
            return PartialView(ServiceSalesChartView);
        }

        public PartialViewResult ServiceSalesOvertime()
        {
            return PartialView();
        }

        public PartialViewResult _ServiceSalesOvertime(DateTime FromDate, DateTime ToDate)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            var result = DBProvider.GetServiceSalesOvertime(LoginInfo.StoreID, FromDate, ToDate);
            return PartialView(result);
        }

        public PartialViewResult CategoryDetail()
        {
            return PartialView();
        }

        public PartialViewResult CategorySummary()
        {
            return PartialView();
        }
        public PartialViewResult CashOutSummary()
        {
            return PartialView();
        }

        public PartialViewResult CashOutDetail()
        {
            return PartialView();
        }
    }


}
