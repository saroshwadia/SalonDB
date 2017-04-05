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
    public partial class ServiceSalesAnualChartReport : DevExpress.XtraReports.UI.XtraReport
    {
        private ServiceCollection ServiceColl;
        public ServiceSalesAnualChartReport()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {

            this.objectDataSource1.DataSource = DBProviderES.GetServiceTransactionsTimefilterCollection(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));
            this.ServiceColl = new ServiceCollection();
            ServiceColl = DBProviderES.GetServices(new Guid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID.ToString()));


            //    xrChart1.axis
            this.objectDataSource2.DataSource = ServiceColl;
            //    this.xrChart1.AxisX.WholeRange.Auto = False
            //diagram.AxisX.WholeRange.MinValue = -25
            //diagram.AxisX.WholeRange.MaxValue = 25
        }

        private void xrChart1_CustomDrawAxisLabel(object sender, DevExpress.XtraCharts.CustomDrawAxisLabelEventArgs e)
        {
            
        }

        private void xrChart1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //DevExpress.XtraReports.UI.XRChart s = sender as DevExpress.XtraReports.UI.XRChart;
            //ServiceTransactionsTimefilterCollection Coll = objectDataSource1.DataSource as ServiceTransactionsTimefilterCollection;// s.DataSource as SalesViewCollection;
            //                                                                                                                       //ServiceTransactionsTimefilterCollection FilteredColl = new ServiceTransactionsTimefilterCollection();

            //MessageBox.Show(Coll.Count.ToString());

            //foreach (ServiceTransactionsTimefilter SView in Coll)
            //{


            //    if (SView.Name.ToString() == ServiceLabel.Text)
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

            ////objectDataSource1.DataSource = FilteredColl;
            //objectDataSource1.DataSource = FilteredColl;
        }
    }
}
