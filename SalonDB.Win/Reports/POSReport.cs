using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using static SalonDB.Data.DBProviderES;
using System.Collections.Generic;
using SalonDB.Win.Forms;
using BusinessObjects;

namespace SalonDB.Win.Reports
{
    public partial class POSReport : DevExpress.XtraReports.UI.XtraReport
    {
        private string DateFormat = "yyyy-MM-dd hh:mm:ss tt";

        public POSReport(Staff StaffEnt, List<ServiceProduct> ServiceProductCol, ServiceProductSummary ServiceProductSummaryEnt)
        {
            InitializeComponent();

            this.objectDataSource1.DataSource = ServiceProductCol;
            this.RefreshData(StaffEnt, ServiceProductSummaryEnt);
        }

        private void RefreshData(Staff StaffEnt, ServiceProductSummary ServiceProductSummaryEnt)
        {
            var DecimalFormat2 = "{0:n2}";
            var DecimalFormat0 = "{0:f0}";
            var CompanyEnt = StaffEnt.UpToCompanyByCompanyID;

            NamexrTableCell.Text = CompanyEnt.Name;
            DescriptionxrTableCell.Text = CompanyEnt.Description;
            PhonexrTableCell.Text = CompanyEnt.Phone;
            AddressxrTableCell.Text = CompanyEnt.Address;
            CityxrTableCell.Text = CompanyEnt.City;
            PostalCodexrTableCell.Text = CompanyEnt.PostalCode;
            StaffNamexrTableCell.Text = ServiceProductSummaryEnt.StaffName;
            StoreNamexrTableCell.Text = ServiceProductSummaryEnt.StoreName;
            TransactionDatexrTableCell.Text = ServiceProductSummaryEnt.TransactionDate.ToString(DateFormat);
            TransactionNumberxrTableCell.Text = String.Format(DecimalFormat0, ServiceProductSummaryEnt.TransactionNumber);
            CustomerNamexrTableCell.Text = ServiceProductSummaryEnt.CustomertName;
            StatusxrTableCell.Text = ServiceProductSummaryEnt.Status;

            AmountxrTableCell.Text = String.Format(DecimalFormat2, ServiceProductSummaryEnt.Amount);
            TaxAmountxrTableCell.Text = String.Format(DecimalFormat2, ServiceProductSummaryEnt.TaxAmount);
            TaxPercentxrTableCell.Text = String.Format(DecimalFormat2, ServiceProductSummaryEnt.TaxPercent);
            DiscountAmountxrTableCell.Text = String.Format(DecimalFormat2, ServiceProductSummaryEnt.DiscountAmount);
            DiscountPercentxrTableCell.Text = String.Format(DecimalFormat2, ServiceProductSummaryEnt.DiscountPercent);
            TotalxrTableCell.Text = String.Format(DecimalFormat2, ServiceProductSummaryEnt.Total);
        }

        private void POSReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            SetWatermarkText((POSReport)sender);
        }

        public void SetWatermarkText(XtraReport report)
        {
            // Adjust text watermark settings.
            report.Watermark.Text = $"{StatusxrTableCell.Text} - {TransactionDatexrTableCell.Text}";
            report.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.ForwardDiagonal;
            report.Watermark.Font = new Font(report.Watermark.Font.FontFamily, 40);

            if (StatusxrTableCell.Text == Data.eTransactionStatus.Paid.ToString())
            {
                report.Watermark.ForeColor = Color.Green;
            }
            else
            {
                report.Watermark.ForeColor = Color.DodgerBlue;
            }
            report.Watermark.TextTransparency = 150;
            report.Watermark.ShowBehind = false;
            //report.Watermark.PageRange = "1,3-5";
        }

    }
}
