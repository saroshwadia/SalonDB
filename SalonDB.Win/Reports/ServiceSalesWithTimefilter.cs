using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SalonDB.Data;
using BusinessObjects;
using System.Windows.Forms;

namespace SalonDB.Win.Reports
{
    public partial class ServiceSalesWithTimefilter : DevExpress.XtraReports.UI.XtraReport
    {
        private ServiceCollection ServiceColl;
        public ServiceSalesWithTimefilter()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {

            this.objectDataSource1.DataSource = DBProviderES.GetServiceTransactionsTimefilterCollection(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));
            this.ServiceColl = new ServiceCollection();
            ServiceColl = DBProviderES.GetServices(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));

            this.objectDataSource2.DataSource = ServiceColl;
        }

        private void xrChart1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //DevExpress.XtraReports.UI.XRChart s = sender as DevExpress.XtraReports.UI.XRChart;
            //ServiceTransactionsTimefilterCollection Coll = objectDataSource1.DataSource as ServiceTransactionsTimefilterCollection;// s.DataSource as SalesViewCollection;
            //ServiceTransactionsTimefilterCollection FilteredColl = new ServiceTransactionsTimefilterCollection();

            //MessageBox.Show("Actual " +Coll.Count.ToString() + "For " + ServiceLabel.Text);

            //foreach (ServiceTransactionsTimefilter SView in Coll)
            //{


            //    if (SView.Name.ToString().Trim() == ServiceLabel.Text.Trim())
            //    {

            //        FilteredColl.AttachEntity(SView);
            //    }

            //}

            //foreach (Service Service in ServiceColl)
            //{
            //    ServiceTransactionsTimefilter st = new ServiceTransactionsTimefilter();
            //    st.Name = Service.Name;
            //    st.Quantity = 0;

            //    FilteredColl.Add(st);
            //}

            //MessageBox.Show("Filtered " + FilteredColl.Count.ToString());
            ////objectDataSource1.DataSource = FilteredColl;
            //objectDataSource1.DataSource = FilteredColl;

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //MessageBox.Show("Times called");
            ////this.objectDataSource1.DataSource = DBProvider.GetServiceTransactionsTimefilterCollection(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));
            //DevExpress.XtraReports.UI.DetailBand det = sender as DevExpress.XtraReports.UI.DetailBand;
            //DevExpress.XtraReports.UI.XRChart s = sender as DevExpress.XtraReports.UI.XRChart;
            //ServiceTransactionsTimefilterCollection Coll = objectDataSource1.DataSource as ServiceTransactionsTimefilterCollection;// s.DataSource as SalesViewCollection;
            //ServiceTransactionsTimefilterCollection FilteredColl = new ServiceTransactionsTimefilterCollection();

            //MessageBox.Show("Actual " + Coll.Count.ToString() + "For " + ServiceLabel.Text);

            //foreach (ServiceTransactionsTimefilter SView in Coll)
            //{


            //    if (SView.Name.ToString().Trim() == ServiceLabel.Text.Trim())
            //    {

            //        FilteredColl.AttachEntity(SView);
            //    }

            //}

            //foreach (Service Service in ServiceColl)
            //{
            //    ServiceTransactionsTimefilter st = new ServiceTransactionsTimefilter();
            //    st.Name = Service.Name;
            //    st.Quantity = 0;

            //    FilteredColl.Add(st);
            //}

            //MessageBox.Show("Filtered " + FilteredColl.Count.ToString());
            //objectDataSource1.DataSource = FilteredColl;
            //objectDataSource1.DataSource = Coll;
            //xrChart1.DataSource = objectDataSource1;
            //s.DataSource = FilteredColl;

        }



        //      
    }
}
