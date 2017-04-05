using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SalonDB.Data;

namespace SalonDB.Win.Reports
{
 

    public partial class SalesReportNew : DevExpress.XtraReports.UI.XtraReport
    {  
        public SalesReportNew()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {

            this.objectDataSource1.DataSource = DBProviderES.GetSalesView(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));


        }

    }
}
