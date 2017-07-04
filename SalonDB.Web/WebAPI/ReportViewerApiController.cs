using Syncfusion.EJ.ReportViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Syncfusion.Reports.EJ;


using System.Collections;

using System.IO;
using System.Threading;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using SalonDB.Data.Core.Domain;
using SalonDB.Data;
using SalonDB.Web.Models;
using SalonDB.Data.Persistence;

namespace SalonDB.Web.WebAPI
{
    public class ReportViewerApiController : ApiController, IReportController
    {

        UnitOfWork unitOfWork = new UnitOfWork(new SalonContext());
        LoginViewModel LoginInfo = new LoginViewModel();

        // GET api/<controller>
        public object PostReportAction(Dictionary<string, object> jsonResult)
        {

            return ReportHelper.ProcessReport(jsonResult, this);
        }

        [System.Web.Http.ActionName("GetResource")]
        [AcceptVerbs("GET")]
        public object GetResource(string key, string resourcetype, bool isPrint)
        {
            return ReportHelper.GetResource(key, resourcetype, isPrint);
        }

        public void OnInitReportOptions(ReportViewerOptions reportOption)
        {

           
            
        }

        public void OnReportLoaded(ReportViewerOptions reportOption)
        {
            LoginInfo = MvcApplication.GetLoginInfo<LoginViewModel>(User.Identity);
            Guid StoreID = LoginInfo.StoreID;

            Guid CompanyID =LoginInfo.CompanyID;
            reportOption.ReportModel.DataSources.Clear();

            if (reportOption.ReportModel.ReportPath.Contains("SalesReport"))
            {
                var Sales = DBProvider.GetSales(StoreID);
                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "dsSales", Value = Sales });
            }

            else if (reportOption.ReportModel.ReportPath.Contains("InventoryReport"))
            {
               
                var products = DBProvider.GetProducts(StoreID);
                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "dsInventory", Value = products });
            }
          else  if (reportOption.ReportModel.ReportPath.Contains("CategorySummaryReport"))
            {

                var FromDate = reportOption.ReportModel.Parameters.ToList()[0].Values[0].ToString() +" 00:00:00";
                var ToDate = reportOption.ReportModel.Parameters.ToList()[1].Values[0].ToString() +" 23:59:59";
                var Category = DBProvider.GetCategories(CompanyID);
                var Detail = DBProvider.GetCategorySummaryDetail(StoreID, FromDate, ToDate);
                var ProductTotal = DBProvider.GetCategorySummaryProductTotal(StoreID, FromDate, ToDate);
                var ServiceTotal = DBProvider.GetCategorySummaryServiceTotal(StoreID, FromDate, ToDate);


                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "DSCategory", Value = Category });
                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "DSProductTotal", Value = ProductTotal });
                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "DSServiceTotal", Value = ServiceTotal });

                if (reportOption.SubReportModel != null)

                {
                    reportOption.SubReportModel.DataSources.Clear();

                    reportOption.SubReportModel.DataSources.Add(new ReportDataSource { Name = "DSCategorySummaryDetailSub", Value = Detail });
                }
            }
            else if (reportOption.ReportModel.ReportPath.Contains("CategoryDetailReport"))
            {
                var FromDate = reportOption.ReportModel.Parameters.ToList()[0].Values[0].ToString() + " 00:00:00";
                var ToDate = reportOption.ReportModel.Parameters.ToList()[1].Values[0].ToString() + " 23:59:59";

                var Category = DBProvider.GetCategories(CompanyID);
                var CategoryDetailProduct = DBProvider.GetCategoryDetailProduct(StoreID,FromDate, ToDate);
                var CategoryDetailService = DBProvider.GetCategoryDetailService(StoreID, FromDate, ToDate);

                var ServiceSales = DBProvider.GetServiceSales(StoreID, FromDate, ToDate);
                var ProductSales = DBProvider.GetProductSales(StoreID, FromDate, ToDate);


                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "DSCategoryDetailProduct", Value = CategoryDetailProduct });
                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "DSCategoryDetailService", Value = CategoryDetailService });


                //if (reportOption.SubReportModel != null)
                //{
                //    reportOption.SubReportModel.DataSources.Add(new ReportDataSource { Name = "DSCategoryDetailProduct", Value = CategoryDetailProduct });
                //    reportOption.SubReportModel.DataSources.Add(new ReportDataSource { Name = "DSCategoryDetailService", Value = CategoryDetailService });

                //}
            }
            else if (reportOption.ReportModel.ReportPath.Contains("CashOutSummaryReport"))
            {

                var FromDate = reportOption.ReportModel.Parameters.ToList()[0].Values[0].ToString() + " 00:00:00";
                var ToDate = reportOption.ReportModel.Parameters.ToList()[1].Values[0].ToString() + " 23:59:59";

                //var _parameters = ReportHelper.GetParameters();
                //IList<ReportParameter> _params = new List<ReportParameter>();
                //foreach (var param in _parameters)
                //{
                //    ReportParameter _param = new ReportParameter();
                //    _param.Name = param.Name;
                //    //if (param.Name == "CompanyID")
                //    //{
                //    //    _param.Labels = new List<string>();
                //    //    _param.Values = new List<string>();
                //    //    _param.Labels.Add(CompanyID.ToString());
                //    //    _param.Values.Add(CompanyID.ToString());

                //    //}
                //    //else if (param.Name == "StoreID")
                //    //{
                //    //    _param.Labels = new List<string>();
                //    //    _param.Values = new List<string>();
                //    //    _param.Labels.Add(StoreID.ToString());
                //    //    _param.Values.Add(StoreID.ToString());
                //    //}
                //     if (param.Name == "FromDate")
                //    {
                //        _param.Labels = new List<string>();
                //        _param.Values = new List<string>();
                //        _param.Labels.Add(FromDate);
                //        _param.Values.Add(FromDate);
                //    }
                //    else if (param.Name == "ToDate")
                //    {
                //        _param.Labels = new List<string>();
                //        _param.Values = new List<string>();
                //        _param.Labels.Add(ToDate);
                //        _param.Values.Add(ToDate);
                //    }
                //    _params.Add(_param);
                //}
                //reportOption.ReportModel.Parameters = _params;




                var CashOutSummary = DBProvider.GetCashOutSummary(CompanyID, StoreID, FromDate, ToDate);

                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "DSCashoutSummary", Value = CashOutSummary });
            }

            else if (reportOption.ReportModel.ReportPath.Contains("CashOutDetailReport"))
            {

                var FromDate = reportOption.ReportModel.Parameters.ToList()[0].Values[0].ToString();
                var ToDate = reportOption.ReportModel.Parameters.ToList()[1].Values[0].ToString();

                var CashOutDetail = DBProvider.GetCashOutDetail(StoreID, FromDate, ToDate);

                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "DSCashoutDetail", Value = CashOutDetail });
            }


            else if (reportOption.ReportModel.ReportPath.Contains("POSReport"))
            {
                var _parameters = ReportHelper.GetParameters();
                Guid TransactionID = new Guid(_parameters[0].Values[0].ToString());

                var POS = DBProvider.GetPOS(TransactionID);
                var TransactionData = DBProvider.GetTransactionData(TransactionID);


                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "dsPOS", Value = POS });
                reportOption.ReportModel.DataSources.Add(new ReportDataSource { Name = "dsTransaction", Value = TransactionData });


            }
     
     
        }
    }
}