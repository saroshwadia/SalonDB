using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SalonDB.Data;
using BusinessObjects;

namespace SalonDB.Win.Reports
{

    public partial class ServiceSalesChart : DevExpress.XtraReports.UI.XtraReport
    {
        //private int GroupCount = 0;
        private ServiceCollection ServiceColl;
        public ServiceSalesChart()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {

            this.objectDataSource2.DataSource = DBProviderES.GetServiceTransactionView(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));

            this.ServiceColl = new ServiceCollection();
            ServiceColl = DBProviderES.GetServices(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));
            this.bindingSource1.DataSource = ServiceColl;

        }

        private void ServiceSalesChart_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //GroupFooterBand band = sender as GroupFooterBand;
            ////Here, I expect an instance of ReportLineItemsBandData, but instead get an instance of SalesByItemDetailReportData

            //SalesView rowData = band.Report.GetCurrentRow() as SalesView;
            //if (this.xrLabel2.Text != rowData.Expr1.ToString())
            //{
            //    e.Cancel = true;
            //}
            ////  this.FilterString += "and Expr1 = " + rowData.Expr1.ToString();

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //DetailBand band = sender as DetailBand;
            //SalesView rowData = band.Report.GetCurrentRow() as SalesView;
            //if (this.xrLabel2.Text != rowData.Expr1.ToString())
            //{
            //    e.Cancel = true;
            //}

        }

        private void xrChart1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DevExpress.XtraReports.UI.XRChart s = sender as DevExpress.XtraReports.UI.XRChart;
            ServiceTransactionsViewCollection Coll = objectDataSource2.DataSource as ServiceTransactionsViewCollection;// s.DataSource as SalesViewCollection;
            ServiceTransactionsViewCollection FilteredColl = new ServiceTransactionsViewCollection();
 string Month = DateTime.Now.Month.ToString();
            string M = xrLabel2.Text;
            foreach (ServiceTransactionsView SView in Coll)
            {
               

                if (SView.Month.ToString() != Month)
                {
                    if (SView.Month.ToString() == xrLabel2.Text)
                        FilteredColl.AttachEntity(SView);
                }
                else {
                    if (SView.Month.ToString() == xrLabel2.Text &&  SView.TransactionDate.Value.Year ==DateTime.Now.Year)
                        FilteredColl.AttachEntity(SView);

                }
            }

            ////int ParamCount =  this.Parameters.Count;


            ////var arr = new string[ServiceColl.Count];

            ////arr = this.Parameters["ServiceFilter"].Value as string[];//= new int[] { 4, 5 };

            ////this.Parameters["ServiceFilter"].Value = new string[] { "Full leg ", "Manicure with Shellac " };


            //foreach (Service Service in ServiceColl)
            //{
            //    ServiceTransactionsView st = new ServiceTransactionsView();
            //    st.Name = Service.Name;
            //    st.Quantity = 0;

            //    FilteredColl.Add(st);
            //}

     s.DataSource = FilteredColl;
            
           

            //System.Windows.Forms.MessageBox.Show(sender.ToString());
        }

        private void MonthLabel_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            switch (xrLabel2.Text)
            {
                case "1":
                 MonthLabel.Text="January";
                    break;
                case "2":
                    MonthLabel.Text = "February";
                    break;
                case "3":
                    MonthLabel.Text = "March";
                    break;
                case "4":
                    MonthLabel.Text = "April";
                    break;
                case "5":
                    MonthLabel.Text = "May";
                    break;
                case "6":
                    MonthLabel.Text = "June";
                    break;
                case "7":
                    MonthLabel.Text = "July";
                    break;
                case "8":
                    MonthLabel.Text = "August";
                    break;
                case "9":
                    MonthLabel.Text = "September";
                    break;
                case "10":
                    MonthLabel.Text = "October";
                    break;
                case "11":
                    MonthLabel.Text = "November";
                    break;
                case "12":
                    MonthLabel.Text = "December";
                    break;
            }

        }

        //private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //{
        //    GroupCount += 1;
        //    if (GroupCount == 13)
        //        e.Cancel = true;

        //}
    }
}
