using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using static SalonDB.Data.DBProviderES;
using BusinessObjects;
using SalonDB.Win.Reports;
using DevExpress.XtraReports.UI;

namespace SalonDB.Win.UserControls
{
    public partial class TransactionUC : DevExpress.XtraEditors.XtraUserControl
    {

        private bool FormLoading = true;
        private Transaction TransactionEnt = new Transaction();
        private List<ServiceProduct> ServiceProductCol;
        private decimal GSTAmount = 0;
        private decimal Amount = 0;
        private decimal GrandTotal = 0;
        private decimal TotalDiscountPercent = 0;
        private decimal TotalDiscountAmount = 0;
        private int DecimalPlaces = 2;

        public TransactionUC()
        {
            InitializeComponent();
        }

        private void TransactionUC_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Cannot continue due to the following Error: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadData()
        {
            FormLoading = true;
            this.LoadStoreData();
            this.LoadStaffData();
            this.LoadCustomerData();
            this.LoadServiceData();
            this.LoadProductData();
            this.LoadTransactionData();
            this.LoadServiceProductData();
            FormLoading = false;
        }

        private void LoadStoreData()
        {
            this.storeCollection1 = SalonDB.Data.DBProviderES.GetStores(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.StoreBindingSource.DataSource = this.storeCollection1;
        }

        private void LoadStaffData()
        {
            this.staffCollection1 = SalonDB.Data.DBProviderES.GetStaffs(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.StaffBindingSource.DataSource = this.staffCollection1;
        }

        private void LoadCustomerData()
        {
            this.customerCollection1 = SalonDB.Data.DBProviderES.GetCustomers(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.CustomerBindingSource.DataSource = this.customerCollection1;
        }

        private void LoadProductData()
        {
            this.productCollection1 = SalonDB.Data.DBProviderES.GetProducts(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.ProductBindingSource.DataSource = productCollection1;
        }

        private void LoadServiceData()
        {
            this.serviceCollection1 = SalonDB.Data.DBProviderES.GetServices(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.ServiceBindingSource.DataSource = serviceCollection1;
        }

        private void LoadServiceProductData()
        {
            ServiceProductCol = new List<ServiceProduct>();
            this.ServiceProductBindingSource.DataSource = null;
            this.ServiceProductBindingSource.DataSource = ServiceProductCol;
        }

        private void LoadTransactionData()
        {
            this.transactionCollection1 = SalonDB.Data.DBProviderES.GetTransactions(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.TransactionBindingSource.DataSource = this.transactionCollection1;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.RefreshServiceProductData();
        }

        private Transaction GetCurrentTransaction()
        {
            var ReturnValue = new Transaction();

            ReturnValue = this.TransactionBindingSource.Current as Transaction;

            return ReturnValue;
        }

        private void RefreshServiceProductData()
        {
            TransactionEnt = this.GetCurrentTransaction();

            if (TransactionEnt == null)
            {
                this.LoadServiceProductData();
            }
            else
            {
                this.ServiceProductCol = SalonDB.Data.DBProviderES.GetServiceProductsByTransaction(TransactionEnt.TransactionID);
                this.ServiceProductBindingSource.DataSource = null;
                this.ServiceProductBindingSource.DataSource = ServiceProductCol;
                this.UpdateGrandTotal();
            }
        }

        private void PrintSimpleButton_Click(object sender, EventArgs e)
        {
            this.PrintData();
        }

        private void UpdateGrandTotal()
        {
            try
            {
                TotalDiscountPercent = Math.Round(Convert.ToDecimal(TransactionEnt.DiscountPercent), DecimalPlaces);
                this.gridView1.UpdateCurrentRow();
                this.gridView1.UpdateSummary();

                //if (this.colTotal.SummaryItem.SummaryValue != null)
                //{
                //    Amount = Math.Round(Convert.ToDecimal(TransactionEnt.Amount), DecimalPlaces);
                //}

                Amount = Math.Round(Convert.ToDecimal(TransactionEnt.Amount), DecimalPlaces);

                TotalDiscountAmount = Math.Round((TotalDiscountPercent / 100) * Amount, DecimalPlaces);
                GSTAmount = Math.Round((Convert.ToDecimal(TransactionEnt.TaxPercent)/ 100) * (Amount - TotalDiscountAmount), DecimalPlaces);
                GrandTotal = Math.Round((Amount - TotalDiscountAmount) + GSTAmount, DecimalPlaces);

            }
            catch (Exception)
            {
                TotalDiscountPercent = 0;
                TotalDiscountAmount = 0;
                GSTAmount = 0;
                GrandTotal = 0;
            }

            //this.GSTAmountSpinEdit.EditValue = GSTAmount;
            //this.GrandTotalSpinEdit.EditValue = GrandTotal;
        }

        private void PrintData()
        {
            var ServiceProductSummaryEnt = new ServiceProductSummary();
            var StaffEnt = TransactionEnt.UpToStaffByStaffID;

            ServiceProductSummaryEnt.Amount = Convert.ToDecimal(TransactionEnt.Amount);
            ServiceProductSummaryEnt.Total = Convert.ToDecimal(TransactionEnt.Total);
            ServiceProductSummaryEnt.DiscountPercent = Convert.ToDecimal(TransactionEnt.DiscountPercent );
            ServiceProductSummaryEnt.DiscountAmount = TotalDiscountAmount;
            ServiceProductSummaryEnt.TaxPercent = Convert.ToDecimal(TransactionEnt.TaxPercent);
            ServiceProductSummaryEnt.TaxAmount = GSTAmount;
            ServiceProductSummaryEnt.TransactionDate = Convert.ToDateTime(TransactionEnt.TransactionDate);
            ServiceProductSummaryEnt.TransactionNumber = Convert.ToInt32(TransactionEnt.TransactionNumber);
            ServiceProductSummaryEnt.CustomertName = TransactionEnt.UpToCustomerByCustomerID.FirstLastNamePhoneEmail;
            ServiceProductSummaryEnt.StoreName = TransactionEnt.UpToStoreByStoreID.Name;
            ServiceProductSummaryEnt.StaffName = TransactionEnt.UpToStaffByStaffID.Name;
            ServiceProductSummaryEnt.Status = TransactionEnt.Status;

            var oReport = new POSReport(StaffEnt, ServiceProductCol, ServiceProductSummaryEnt);

            //oReport.ShowRibbonPreviewDialog();
            oReport.ShowPreviewDialog();
        }
    }
}
