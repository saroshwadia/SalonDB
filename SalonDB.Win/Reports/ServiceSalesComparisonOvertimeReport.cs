using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SalonDB.Data;

namespace SalonDB.Win.Reports
{
    public partial class ServiceSalesComparisonOvertimeReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ServiceSalesComparisonOvertimeReport()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {

            this.objectDataSource1.DataSource = DBProviderES.GetServiceTransactionsTimefilterCollection(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));
            //this.ServiceColl = new ServiceCollection();
            //ServiceColl = DBProvider.GetServices(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));


            //this.objectDataSource2.DataSource = ServiceColl;
        }


    }
}
