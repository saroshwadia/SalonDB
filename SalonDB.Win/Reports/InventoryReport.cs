using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SalonDB.Data;

namespace SalonDB.Win.Reports
{
    public partial class InventoryReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InventoryReport()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            this.objectDataSource1.DataSource = DBProviderES.GetProducts(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));
        }
    }
}
