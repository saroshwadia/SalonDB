using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.Configuration;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonDB.Win.Forms
{
    public partial class ReportsMainForm : BaseForm
    {
        public ReportsMainForm()
        {
            InitializeComponent();
        
        }

   

        private void ReportsMainForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void SalesaccordionControlElement_Click(object sender, EventArgs e)
        {
            Reports.SalesReportNew report = new Reports.SalesReportNew();
            this.documentViewer1.DocumentSource = report;
 



            report.CreateDocument();

          

        }

        private void documentViewer1_Load(object sender, EventArgs e)
        {
            DevExpress.XtraBars.Docking.DockPanel navigationDockPanel = documentViewer1.DockManager.Panels[new System.Guid("6b2e64eb-afd0-4676-bc3d-eca7e99946aa")];

            if   (navigationDockPanel != null)
                          {
                navigationDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;

            }
   
        }

        private void ServiceSalesMonthlyControlElement_Click(object sender, EventArgs e)
        {
            Reports.ServiceSalesChart report = new Reports.ServiceSalesChart();
            this.documentViewer1.DocumentSource = report;
            //report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.DocumentMap, CommandVisibility.);

            report.CreateDocument();
        }

        private void ServiceSalesTimeFilteraccordionControlElement_Click(object sender, EventArgs e)
        {
            Reports.ServiceSalesWithTimefilter report = new Reports.ServiceSalesWithTimefilter();
            this.documentViewer1.DocumentSource = report;
       
            report.CreateDocument();
        }

        private void documentViewer1_DocumentChanged(object sender, EventArgs e)
        {
            DocumentViewer viewer = sender as DocumentViewer;
            if (viewer.DocumentMapVisible)
            {
                viewer.DockManager.Panels[0].DockTo(DevExpress.XtraBars.Docking.DockingStyle.Right);
            }

        }

        private void ServiceSalesAnualaccordionControlElement_Click(object sender, EventArgs e)
        {
            Reports.ServiceSalesAnualChartReport report = new Reports.ServiceSalesAnualChartReport();
            this.documentViewer1.DocumentSource = report;

            report.CreateDocument();
        }

        private void ServiceSalesComparisonaccordionControlElement_Click(object sender, EventArgs e)
        {
            Reports.ServiceSalesComparisonOvertimeReport report = new Reports.ServiceSalesComparisonOvertimeReport();
            this.documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        private void InventoryaccordionControlElement_Click(object sender, EventArgs e)
        {
            Reports.InventoryReport report = new Reports.InventoryReport();
            this.documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}
