using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using static SalonDB.Data.DBProviderES;
using DevExpress.XtraEditors.Repository;
using BusinessObjects;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Views.Grid;
using SalonDB.Win.Reports;
using DevExpress.XtraReports.UI;

namespace SalonDB.Win.Forms
{
    public partial class POSForm : BaseForm
    {

        private bool FormLoading = true;
        private List<ServiceProduct> ServiceProductCol;
        private Appointment CurrentAppointmentEnt = null;
        private Customer CurrentCustomerEnt = null;
        private Customer WalkInCustomerEnt = null;
        private Service CurrentServiceEnt = null;
        private Product CurrentProductEnt = null;
        private Transaction CurrrentTransaction = null;
        private decimal GSTPercent = 5;
        private decimal GSTAmount = 0;
        private decimal Amount = 0;
        private decimal GrandTotal = 0;
        private decimal TotalDiscountPercent = 0;
        private decimal TotalDiscountAmount = 0;
        private bool FromAppointmentChanged = false;
        private bool DataSaved = false;
        private int DecimalPlaces = 2;
        private int Sequence = 0;

        public POSForm()
        {
            InitializeComponent();
            this.Setup();
        }

        private void Setup()
        {

            this.CurrentDateDateEdit.EditValue = DateTime.Now.Date;

            layoutControlItem12.Text = $"GST {GSTPercent} %";

            this.SetSpinEditMask(ref this.ServicePriceTextEdit, "N2", 0, decimal.MaxValue);
            this.SetSpinEditMask(ref this.ServiceQuantityTextEdit, "N0", 1, decimal.MaxValue);
            this.SetSpinEditMask(ref this.ServiceDiscountTextEdit, "N2", 0, decimal.MaxValue);
            this.SetSpinEditMask(ref this.ServiceTotalTextEdit, "N2", 0, decimal.MaxValue);

            this.SetSpinEditMask(ref this.ProducPriceSpinEdit, "N2", 0, decimal.MaxValue);
            this.SetSpinEditMask(ref this.ProducQuantitySpinEdit, "N0", 1, decimal.MaxValue);
            this.SetSpinEditMask(ref this.ProducDiscountSpinEdit, "N2", 0, decimal.MaxValue);
            this.SetSpinEditMask(ref this.ProducTotalSpinEdit, "N2", 0, decimal.MaxValue);

            this.SetSpinEditMask(ref this.repositoryItemSpinEdit1, "N2", 0, decimal.MaxValue);
            this.SetSpinEditMask(ref this.repositoryItemSpinEdit2, "N0", 1, decimal.MaxValue);

            this.SetSpinEditMask(ref this.TotalDiscountSpinEdit, "N2", 0, decimal.MaxValue);
            this.SetSpinEditMask(ref this.GSTAmountSpinEdit, "N2", 0, decimal.MaxValue);
            this.SetSpinEditMask(ref this.GrandTotalSpinEdit, "N2", 0, decimal.MaxValue);

            this.colQuantity.SummaryItem.DisplayFormat = "{0:n0}";
            this.colTotal.SummaryItem.DisplayFormat = "{0:n2}";

            this.RefreshControls();
        }

        private void ResetData()
        {
            this.LoadServiceProductData();
            this.LoadAppointmentData();
            this.TotalDiscountSpinEdit.EditValue = 0;
            this.Sequence = 0;
            this.RefreshControls();
        }

        private void RefreshControls()
        {
            var OK = this.gridView1.RowCount > 0;

            this.ProductAddSimpleButton.Enabled = CurrentProductEnt != null;
            this.ServiceAddSimpleButton.Enabled = CurrentServiceEnt != null;
            this.DeleteSimpleButton.Enabled = OK && !DataSaved;
            this.EditSimpleButton.Enabled = OK && !DataSaved;
            this.CancelSimpleButton.Enabled = OK && !DataSaved;
            this.SaveSimpleButton.Enabled = OK && CurrentCustomerEnt != null && !DataSaved;
            this.AddNewSimpleButton.Enabled = OK && DataSaved;
            this.gridView1.OptionsBehavior.Editable = !DataSaved;

            this.UpdateGrandTotal();
            
        }

        private void SetSpinEditMask(ref SpinEdit oSpinEditor, string editMask, decimal minValue, decimal maxValue)
        {
            oSpinEditor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            oSpinEditor.Properties.Mask.EditMask = editMask;
            oSpinEditor.Properties.Mask.UseMaskAsDisplayFormat = true;
            oSpinEditor.Properties.MinValue = minValue;
            oSpinEditor.Properties.MaxValue = maxValue;
        }

        private void SetSpinEditMask(ref RepositoryItemSpinEdit oSpinEditor, string editMask, decimal minValue, decimal maxValue)
        {
            oSpinEditor.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            oSpinEditor.Mask.EditMask = editMask;
            oSpinEditor.Mask.UseMaskAsDisplayFormat = true;
            oSpinEditor.MinValue = minValue;
            oSpinEditor.MaxValue = maxValue;
        }

        private void POSForm_Load(object sender, EventArgs e)
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
            this.LoadStaffData();
            this.LoadAppointmentData();
            this.LoadCustomerData();
            this.LoadServiceData();
            this.LoadProductData();
            this.LoadServiceProductData();
            this.CustomerSearchLookUpEdit.EditValue = WalkInCustomerEnt.CustomerID;
            FormLoading = false;
            this.AddNew();

        }

        private void LoadStaffData()
        {
            this.staffCollection1 = SalonDB.Data.DBProviderES.GetStaffs(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.StaffBindingSource.DataSource = this.staffCollection1;
        }

        private void LoadAppointmentData()
        {
            var Date = (DateTime)this.CurrentDateDateEdit.EditValue;
            var DateFrom = Date.Date;
            var DateTo = DateFrom.AddHours(23).AddMinutes(59).AddSeconds(59);

            if (ShowAllDatesCheckEdit.Checked)
            {
                DateFrom = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
                DateTo = System.Data.SqlTypes.SqlDateTime.MaxValue.Value;
            }

            //this.appointmentCollection1 = SalonDB.Data.DBProvider.GetAppointments(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID, DateFrom, DateTo);
            this.appointmentCollection1 = SalonDB.Data.DBProviderES.GetAppointmentsNotPaid(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID, DateFrom, DateTo);
            this.AppointmentBindingSource.DataSource = this.appointmentCollection1;
        }

        private void LoadCustomerData()
        {
            this.customerCollection1 = SalonDB.Data.DBProviderES.GetCustomers(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.CustomerBindingSource.DataSource = this.customerCollection1;

            WalkInCustomerEnt = SalonDB.Data.DBProviderES.GetCustomerWalkIn(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
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

        private void ServiceLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshServiceData();
        }

        private void ProductLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshProductData();
        }

        private void RefreshServiceData()
        {

            this.AddNew();

            if (ServiceLookUpEdit.EditValue == null)
            {
                CurrentServiceEnt = null;
            }
            else
            {
                var ID = Guid.Parse(ServiceLookUpEdit.EditValue.ToString());
                CurrentServiceEnt = (from oRow in serviceCollection1 where oRow.ServiceID == ID select oRow).FirstOrDefault();
            }

            try
            {
                FormLoading = true;

                this.ServiceNameTextEdit.EditValue = null;
                this.ServicePriceTextEdit.EditValue = 0;
                this.ServiceQuantityTextEdit.EditValue = 0;
                this.ServiceDiscountTextEdit.EditValue = 0;

                if (CurrentServiceEnt != null)
                {
                    this.ServiceNameTextEdit.EditValue = CurrentServiceEnt.Name;
                    this.ServicePriceTextEdit.EditValue = CurrentServiceEnt.Price;
                    this.ServiceQuantityTextEdit.EditValue = 1;
                    this.ServiceDiscountTextEdit.EditValue = 0;
                }
            }
            catch (Exception)
            {
                CurrentServiceEnt = null;
            }
            finally
            {
                FormLoading = false;
                this.RefreshServiceTotal();
                this.RefreshControls();
            }
        }

        private void RefreshProductData()
        {
            this.AddNew();

            if (ProductLookUpEdit.EditValue == null)
            {
                CurrentProductEnt = null;
            }
            else
            {
                var ID = Guid.Parse(ProductLookUpEdit.EditValue.ToString());
                CurrentProductEnt = (from oRow in productCollection1 where oRow.ProductID == ID select oRow).FirstOrDefault();
            }

            try
            {
                FormLoading = true;

                this.ProducNameTextEdit.EditValue = null;
                this.ProducPriceSpinEdit.EditValue = 0;
                this.ProducQuantitySpinEdit.EditValue = 0;
                this.ProducDiscountSpinEdit.EditValue = 0;

                if (CurrentProductEnt != null)
                {
                    this.ProducNameTextEdit.EditValue = CurrentProductEnt.Name;
                    this.ProducPriceSpinEdit.EditValue = CurrentProductEnt.Price;
                    this.ProducQuantitySpinEdit.EditValue = 1;
                    this.ProducDiscountSpinEdit.EditValue = 0;
                }
            }
            catch (Exception)
            {
                CurrentProductEnt = null;
            }
            finally
            {
                FormLoading = false;
                this.RefreshProductTotal();
                this.RefreshControls();
            }
        }

        private void ServicePriceTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshServiceTotal();
        }

        private void ServiceQuantityTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshServiceTotal();
        }

        private void ServiceDiscountTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshServiceTotal();
        }

        private void ProducPriceSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshProductTotal();
        }

        private void ProducQuantitySpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshProductTotal();
        }

        private void ProducDiscountSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshProductTotal();
        }

        private void RefreshServiceTotal()
        {
            if (!FormLoading)
            {
                var Price = Math.Round(Convert.ToDecimal(this.ServicePriceTextEdit.EditValue), DecimalPlaces);
                var Quantity = Convert.ToInt32(this.ServiceQuantityTextEdit.EditValue);
                var DiscountPercent = Math.Round(Convert.ToDecimal(this.ServiceDiscountTextEdit.EditValue), DecimalPlaces);
                var Total = Math.Round(this.CalculateTotal(Price, Quantity, DiscountPercent), DecimalPlaces);

                this.ServiceTotalTextEdit.EditValue = Total;
            }
        }

        private void RefreshProductTotal()
        {
            if (!FormLoading)
            {
                var Price = Math.Round(Convert.ToDecimal(this.ProducPriceSpinEdit.EditValue), DecimalPlaces);
                var Quantity = Convert.ToInt32(this.ProducQuantitySpinEdit.EditValue);
                var DiscountPercent = Math.Round(Convert.ToDecimal(this.ProducDiscountSpinEdit.EditValue), DecimalPlaces);
                var Total = Math.Round(this.CalculateTotal(Price, Quantity, DiscountPercent), DecimalPlaces);

                this.ProducTotalSpinEdit.EditValue = Total;
            }
        }

        private decimal CalculateTotal(decimal price, decimal quantity, decimal discountPercent)
        {
            decimal ReturnValue = 0;
            decimal DiscountAmount = 0;

            try
            {
                ReturnValue = Math.Round((price * quantity), DecimalPlaces);
                DiscountAmount = Math.Round((discountPercent / 100) * ReturnValue, DecimalPlaces);
                ReturnValue = Math.Round(ReturnValue - DiscountAmount, DecimalPlaces);
            }
            catch (Exception)
            {
                ReturnValue = -1;
            }

            return ReturnValue;
        }

        private void ServiceAddSimpleButton_Click(object sender, EventArgs e)
        {
            this.AddService();
        }

        private void ProductAddSimpleButton_Click(object sender, EventArgs e)
        {
            this.AddProduct();
        }

        private void AddService()
        {
            if (CurrentServiceEnt != null)
            {
                this.AddNew();

                ServiceProduct oEnt = new ServiceProduct();

                oEnt.ServiceProductID = (Guid)CurrentServiceEnt.ServiceID;
                oEnt.Name = CurrentServiceEnt.Name;
                oEnt.Description = CurrentServiceEnt.Description;
                oEnt.Price = Math.Round(Convert.ToDecimal(this.ServicePriceTextEdit.EditValue), DecimalPlaces);
                oEnt.Quantity = Convert.ToInt32(this.ServiceQuantityTextEdit.EditValue);
                oEnt.DiscountPercent = Math.Round(Convert.ToDecimal(this.ServiceDiscountTextEdit.EditValue), DecimalPlaces);
                oEnt.IsService = true;
                oEnt.Sequence = ++this.Sequence;

                AddService(oEnt);
            }
        }

        private void AddService(ServiceProduct oEnt)
        {
            ServiceProductCol.Add(oEnt);
            this.gridView1.RefreshData();
            this.gridView1.FocusedRowHandle = this.gridView1.RowCount - 1;
            ServiceLookUpEdit.EditValue = null;
            this.RefreshControls();
        }

        private void AddProduct()
        {
            if (CurrentProductEnt != null)
            {

                this.AddNew();

                ServiceProduct oEnt = new ServiceProduct();

                oEnt.ServiceProductID = (Guid)CurrentProductEnt.ProductID;
                oEnt.Name = CurrentProductEnt.Name;
                oEnt.Description = CurrentProductEnt.Description;
                oEnt.Price = Math.Round(Convert.ToDecimal(this.ProducPriceSpinEdit.EditValue), DecimalPlaces);
                oEnt.Quantity = Convert.ToInt32(this.ProducQuantitySpinEdit.EditValue);
                oEnt.DiscountPercent = Math.Round(Convert.ToDecimal(this.ProducDiscountSpinEdit.EditValue), DecimalPlaces);
                oEnt.IsService = false;
                oEnt.Sequence = ++this.Sequence;

                AddProduct(oEnt);
            }

        }

        private void AddProduct(ServiceProduct oEnt)
        {
            ServiceProductCol.Add(oEnt);
            this.gridView1.RefreshData();
            this.gridView1.FocusedRowHandle = this.gridView1.RowCount - 1;
            ProductLookUpEdit.EditValue = null;
            this.RefreshControls();
        }

        private void AddNewSimpleButton_Click(object sender, EventArgs e)
        {
            this.AddNew();
        }

        private void PrintSimpleButton_Click(object sender, EventArgs e)
        {
            this.PrintData();
        }

        private void CancelSimpleButton_Click(object sender, EventArgs e)
        {
            this.CancelChanges();
        }

        private void SaveSimpleButton_Click(object sender, EventArgs e)
        {
            this.SaveChanges();
        }

        private void PrintData()
        {
            var ServiceProductSummaryEnt = new ServiceProductSummary();

            ServiceProductSummaryEnt.Amount = Amount;
            ServiceProductSummaryEnt.Total = GrandTotal;
            ServiceProductSummaryEnt.DiscountPercent = TotalDiscountPercent;
            ServiceProductSummaryEnt.DiscountAmount = TotalDiscountAmount;
            ServiceProductSummaryEnt.TaxPercent = GSTPercent;
            ServiceProductSummaryEnt.TaxAmount = GSTAmount;
            ServiceProductSummaryEnt.TransactionDate = DateTime.Now;
            ServiceProductSummaryEnt.TransactionNumber = 0;
            ServiceProductSummaryEnt.CustomertName = this.CurrentCustomerEnt.FirstLastNamePhoneEmail;
            ServiceProductSummaryEnt.StoreName = SalonDB.Win.Forms.MainForm.LoggedInUser.UpToStoreByStoreID.Name;
            ServiceProductSummaryEnt.StaffName = SalonDB.Win.Forms.MainForm.LoggedInUser.Name;
            ServiceProductSummaryEnt.Status = this.GetStatus(ServiceProductSummaryEnt.TransactionDate);

            var oReport = new POSReport(SalonDB.Win.Forms.MainForm.LoggedInUser, ServiceProductCol, ServiceProductSummaryEnt);

            //oReport.ShowRibbonPreviewDialog();
            oReport.ShowPreviewDialog();
        }

        private string GetStatus(DateTime TransactionDate)
        {
            var ReturnValue = string.Empty;
            //var DateFormat = "yyyy-MM-dd hh:mm:ss tt";

            if (DataSaved)
            {
                ReturnValue = $"{Data.eTransactionStatus.Paid.ToString()}";
            }
            else
            {
                ReturnValue = $"{Data.eTransactionStatus.Pending.ToString()}";
            }

            return ReturnValue;
        }

        private void CancelChanges()
        {
            if (XtraMessageBox.Show("Are you sure you want to Cancel Changes?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.ResetData();
            }
        }

        private void EditSimpleButton_Click(object sender, EventArgs e)
        {
            this.EditRow();
        }

        private void DeleteSimpleButton_Click(object sender, EventArgs e)
        {
            this.DeleteRow();
        }

        private void EditRow()
        {
            this.gridView1.ShowEditForm();
        }

        private void DeleteRow()
        {
            if (this.gridView1.RowCount > 0)
            {
                this.gridView1.DeleteRow(this.gridView1.FocusedRowHandle);
            }
        }

        private void TotalDiscountSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.UpdateGrandTotal();
        }

        private void UpdateGrandTotal()
        {
            try
            {
                TotalDiscountPercent = Math.Round(Convert.ToDecimal(this.TotalDiscountSpinEdit.EditValue), DecimalPlaces);
                this.gridView1.UpdateCurrentRow();
                this.gridView1.UpdateSummary();

                if (this.colTotal.SummaryItem.SummaryValue != null)
                {
                    Amount = Math.Round(Convert.ToDecimal(this.colTotal.SummaryItem.SummaryValue), DecimalPlaces);
                }

                TotalDiscountAmount = Math.Round((TotalDiscountPercent / 100) * Amount, DecimalPlaces);
                GSTAmount = Math.Round((GSTPercent / 100) * (Amount - TotalDiscountAmount), DecimalPlaces);
                GrandTotal = Math.Round((Amount - TotalDiscountAmount) + GSTAmount, DecimalPlaces);

            }
            catch (Exception)
            {
                TotalDiscountPercent = 0;
                TotalDiscountAmount = 0;
                GSTAmount = 0;
                GrandTotal = 0;
            }

            this.GSTAmountSpinEdit.EditValue = GSTAmount;
            this.GrandTotalSpinEdit.EditValue = GrandTotal;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.RefreshControls();
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            this.RefreshControls();
        }

        //private void SelectCustomer()
        //{
        //    var SelectCustomerForm = new SelectCustomerForm();
        //    SelectCustomerForm.ShowDialog();

        //    CurrentAppointmentEnt = null;
        //    CurrrentTransaction = null;

        //    if (SelectCustomerForm.ReturnValue!= null)
        //    {
        //        if (SelectCustomerForm.ReturnValue.CustomerEnt != null)
        //        {
        //            CustomerSearchLookUpEdit.EditValue = SelectCustomerForm.ReturnValue.CustomerEnt.CustomerID;
        //        }
        //        else
        //        {
        //            if (SelectCustomerForm.ReturnValue.AppointmentEnt != null)
        //            {
        //                CurrentAppointmentEnt = SelectCustomerForm.ReturnValue.AppointmentEnt;
        //                //CurrentCustomerEnt = CurrentAppointmentEnt.UpToCustomerByCustomerID;
        //                CustomerSearchLookUpEdit.EditValue = CurrentAppointmentEnt.CustomerID;

        //                if (SelectCustomerForm.ReturnValue.AppointmentEnt.TransactionCollectionByAppointmentID.Count > 0)
        //                {

        //                    CurrrentTransaction = SelectCustomerForm.ReturnValue.AppointmentEnt.TransactionCollectionByAppointmentID[0];

        //                    if (CurrrentTransaction.TransactionDetailServiceCollectionByTransactionID.Count > 0)
        //                    {
        //                        //Delete all existing rows first then add all services back from the TransactionDetailService table.
        //                        ServiceProductCol = new List<ServiceProduct>();
        //                        this.ServiceProductBindingSource.DataSource = null;
        //                        this.ServiceProductBindingSource.DataSource = ServiceProductCol;

        //                        foreach (var oEnt in CurrrentTransaction.TransactionDetailServiceCollectionByTransactionID)
        //                        {
        //                            var ServiceProductEnt = new ServiceProduct();
        //                            ServiceProductEnt.TransactionID = (Guid)oEnt.TransactionID;
        //                            ServiceProductEnt.TransactionDetailServiceID = (Guid)oEnt.TransactionDetailServiceID;
        //                            if (oEnt.ServiceID != null)
        //                            {
        //                                ServiceProductEnt.ServiceProductID = (Guid)oEnt.ServiceID;
        //                            }
        //                            ServiceProductEnt.Name = oEnt.Name;
        //                            ServiceProductEnt.Price = (Decimal)oEnt.UnitPrice;
        //                            ServiceProductEnt.Quantity = 1;
        //                            ServiceProductEnt.DiscountPercent = 0;
        //                            ServiceProductEnt.IsService = true;

        //                            ServiceProductCol.Add(ServiceProductEnt);
        //                        }
        //                    }

        //                }

        //            }
        //        }
        //    }

        //    this.gridView1.RefreshData();
        //    this.gridView1.FocusedRowHandle = this.gridView1.RowCount - 1;

        //    this.RefreshControls();
        //}

        private void ShowAllDatesCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadAppointmentData();
        }

        private void CurrentDateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.LoadAppointmentData();
        }

        private void AppointmentSearchLookUpEdit_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= popupForm_KeyUp;
            popupForm.KeyUp += popupForm_KeyUp;
        }

        private void CustomerSearchLookUpEdit_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= popupForm_KeyUp;
            popupForm.KeyUp += popupForm_KeyUp;
        }

        void popupForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }

        private void AppointmentSearchLookUpEdit_Enter(object sender, EventArgs e)
        {
            FromAppointmentChanged = true;
        }

        private void CustomerSearchLookUpEdit_Enter(object sender, EventArgs e)
        {
            FromAppointmentChanged = false;
        }

        private void AppointmentSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshAppointmentData();
        }

        private void CustomerSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshCustomerData();
        }

        private void RefreshAppointmentData()
        {
            if (!FormLoading)
            {

                this.AddNew();

                if (this.AppointmentSearchLookUpEdit.EditValue == null)
                {
                    this.CurrentAppointmentEnt = null;
                }
                else
                {
                    var AppointmentID = (Guid)this.AppointmentSearchLookUpEdit.EditValue;
                    this.CurrentAppointmentEnt = (from oRow in this.appointmentCollection1 where oRow.AppointmentID == AppointmentID select oRow).FirstOrDefault();
                }

                if (this.CurrentAppointmentEnt != null)
                {
                    this.CustomerSearchLookUpEdit.EditValue = this.CurrentAppointmentEnt.CustomerID;
                    this.UpdateServiceProductData();
                }
            }
        }

        private void RefreshCustomerData()
        {
            this.AddNew();

            if (CustomerSearchLookUpEdit.EditValue == null) //CustomerLookUpEdit.EditValue == null
            {
                CurrentCustomerEnt = null;
            }
            else
            {
                var ID = Guid.Parse(CustomerSearchLookUpEdit.EditValue.ToString());
                CurrentCustomerEnt = (from oRow in customerCollection1 where oRow.CustomerID == ID select oRow).FirstOrDefault();
            }

            if (!FormLoading && !FromAppointmentChanged)
            {
                this.AppointmentSearchLookUpEdit.EditValue = null;
                this.ResetData();
            }

            this.RefreshControls();
        }

        private void UpdateServiceProductData()
        {
            this.ResetData();
            if (this.CurrentAppointmentEnt != null)
            {
                if (this.CurrentAppointmentEnt.TransactionCollectionByAppointmentID.Count > 0)
                {
                    var TransactionEnt = this.CurrentAppointmentEnt.TransactionCollectionByAppointmentID[0];
                    if (TransactionEnt.TransactionDetailServiceCollectionByTransactionID.Count > 0)
                    {
                        foreach (var oEnt in TransactionEnt.TransactionDetailServiceCollectionByTransactionID)
                        {
                            var oNewEnt = new ServiceProduct();
                            oNewEnt.TransactionID = (Guid)oEnt.TransactionID;
                            oNewEnt.TransactionDetailServiceID = (Guid)oEnt.TransactionDetailServiceID;
                            oNewEnt.ServiceProductID = (Guid)oEnt.ServiceID;
                            oNewEnt.Name = oEnt.Name;
                            oNewEnt.Description = oEnt.Description;
                            oNewEnt.Price = Math.Round(Convert.ToDecimal(oEnt.UnitPrice), DecimalPlaces);
                            oNewEnt.Quantity = Convert.ToInt32(oEnt.Quantity);
                            oNewEnt.DiscountPercent = 0;
                            oNewEnt.Duration = Convert.ToInt32(oEnt.Duration);
                            oNewEnt.IsService = true;
                            oNewEnt.Sequence = ++this.Sequence;

                            AddService(oNewEnt);
                        }
                    }
                }
            }
        }

        private void SaveChanges()
        {
            try
            {
                if (this.ServiceProductCol.Count > 0)
                {

                    //XtraMessageBox.Show("Save not implemented as yet...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (CurrentAppointmentEnt != null)
                    {
                        if (CurrentAppointmentEnt.TransactionCollectionByAppointmentID.Count > 0)
                        {
                            CurrrentTransaction = CurrentAppointmentEnt.TransactionCollectionByAppointmentID[0];
                        }
                        else
                        {
                            CurrrentTransaction = null;
                        }
                    }

                    if (CurrrentTransaction == null)
                    {
                        CurrrentTransaction = new Transaction();
                        CurrrentTransaction.TransactionID = Guid.NewGuid();
                    }
                    else
                    {
                        if (CurrentAppointmentEnt != null && CurrentAppointmentEnt.AppointmentID != null)
                        {
                            CurrrentTransaction.AppointmentID = CurrentAppointmentEnt.AppointmentID;
                        }
                    }

                    CurrrentTransaction.CompanyID = SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID;
                    // TransactionNumber is an identity col so it will self increment.
                    //CurrrentTransaction.TransactionNumber = 999;
                    CurrrentTransaction.StoreID = SalonDB.Win.Forms.MainForm.LoggedInUser.StoreID;
                    CurrrentTransaction.StaffID = SalonDB.Win.Forms.MainForm.LoggedInUser.StaffID;
                    CurrrentTransaction.CustomerID = CurrentCustomerEnt.CustomerID;
                    CurrrentTransaction.TransactionDate = DateTime.Now;
                    CurrrentTransaction.Status = Data.eTransactionStatus.Paid.ToString();

                    //CurrrentTransaction.Tax = Convert.ToDecimal(this.GSTAmountSpinEdit.EditValue);
                    CurrrentTransaction.TaxPercent = Convert.ToDecimal(this.GSTPercent);
                    CurrrentTransaction.DiscountPercent = Convert.ToDecimal(this.TotalDiscountSpinEdit.EditValue);
                    CurrrentTransaction.Amount = Convert.ToDecimal(this.Amount);
                    CurrrentTransaction.Total = Convert.ToDecimal(this.GrandTotal);

                    CurrrentTransaction.TransactionDetailServiceCollectionByTransactionID.MarkAllAsDeleted();
                    CurrrentTransaction.TransactionDetailProductCollectionByTransactionID.MarkAllAsDeleted();

                    foreach (var ServiceProductEnt in this.ServiceProductCol.OrderBy(e => e.Sequence))
                    {

                        if (ServiceProductEnt.IsService)
                        {
                            // Service
                            var oEnt = CurrrentTransaction.TransactionDetailServiceCollectionByTransactionID.AddNew();
                            oEnt.ServiceID = ServiceProductEnt.ServiceProductID;
                            oEnt.Name = ServiceProductEnt.Name;
                            oEnt.Description = ServiceProductEnt.Description;
                            oEnt.Quantity = ServiceProductEnt.Quantity;
                            oEnt.UnitPrice = ServiceProductEnt.Price;
                            oEnt.DiscountPercent = ServiceProductEnt.DiscountPercent;
                            oEnt.Duration = ServiceProductEnt.Duration;
                            oEnt.ShowOnline = false; // ServiceProductEnt.ShowOnline;
                            oEnt.Sequence = ServiceProductEnt.Sequence;
                        }
                        else
                        {
                            // Product
                            var oEnt = CurrrentTransaction.TransactionDetailProductCollectionByTransactionID.AddNew();
                            oEnt.ProductID = ServiceProductEnt.ServiceProductID;
                            oEnt.Name = ServiceProductEnt.Name;
                            oEnt.Description = ServiceProductEnt.Description;
                            oEnt.Quantity = ServiceProductEnt.Quantity;
                            oEnt.UnitPrice = ServiceProductEnt.Price;
                            oEnt.DiscountPercent = ServiceProductEnt.DiscountPercent;
                            oEnt.WholesalePrice = ServiceProductEnt.Price;  //ServiceProductEnt.WholesalePrice;
                            oEnt.Commission = 0; //ServiceProductEnt.Commission;
                            oEnt.BarCode = null; // ServiceProductEnt.BarCode;
                            oEnt.Sequence = ServiceProductEnt.Sequence;
                        }

                    }

                    CurrrentTransaction.Save();
                    DataSaved = true;
                    this.RefreshControls();
                    //this.ResetData();
                }
                else
                {
                    XtraMessageBox.Show("Nothing Data to Save...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                DataSaved = false;
                XtraMessageBox.Show($"Could not Save Data due to the following Error{Environment.NewLine}{ex.Message}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNew()
        {
            if (DataSaved)
            {
                DataSaved = false;
                this.ResetData();
            }
        }

        private void gridView1_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            var IsService = (bool)this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, ColIsService);
            e.BindableControls[colQuantity].Enabled = !IsService; //e.BindableControls[ColIsService].;  //e.RowHandle % 2 == 0;
        }
    }
}