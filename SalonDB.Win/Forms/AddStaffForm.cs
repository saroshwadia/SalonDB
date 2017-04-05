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
using BusinessObjects;

namespace SalonDB.Win.Forms
{
    public partial class AddStaffForm : BaseForm
    {

        public Staff ReturnValue = null;
        private StaffCollection StaffCol = null;

        public AddStaffForm(BusinessObjects.Staff Staff)
        {
            InitializeComponent();
            this.ResourceColorColorEdit.EditValue = this.ResourceColorColorEdit.EditValue;
            if (Staff != null)
            {
                ReturnValue = Staff;

            }


        }

        private void AddStaffForm_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void OKsimpleButton_Click(object sender, EventArgs e)
        {
            this.OK();
        }

        private void CancelsimpleButton_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        private void LoadData()
        {

            this.LoadStoreData();
            this.LoadStaffData();
            this.RefreshControls();
        }

        private void LoadStaffData()
        {
            StaffCol = new StaffCollection();

            if (ReturnValue == null)

            {
                ReturnValue = StaffCol.AddNew();

                this.StaffCollectionBindingSource.DataSource = StaffCol;
            }
            else
            {
                //_CustomerCol.Select(ReturnValue)
                //this.customerCollectionBindingSource.Position = ReturnValue;
                this.StaffCollectionBindingSource.DataSource = ReturnValue;
            }

        }

        private void LoadStoreData()
        {
            storeCollection1 = SalonDB.Data.DBProviderES.GetStores(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.StoreBindingSource.DataSource = storeCollection1;
        }

        private void OK()
        {
            this.StaffCollectionBindingSource.EndEdit();
            this.dataLayoutControl1.Validate();
            if (IsValid(true))
            {
                //ReturnValue = this.customerCollectionBindingSource.Current as Customer;
                this.Close();
            }
        }

        private void Cancel()
        {
            ReturnValue = null;
            this.Close();
        }

        private bool IsValid(bool showPrompt)
        {
            var ReturnValue = true;
            var ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(this.FirstNameTextEdit.Text))
            {
                ReturnValue = false;
                ErrorMessage = "First Name cannot be blank.";
                this.FirstNameTextEdit.Focus();
            }

            if (this.StoreIDLookUpEdit.EditValue == null || this.StoreIDLookUpEdit.EditValue == DBNull.Value)
            {
                ReturnValue = false;
                ErrorMessage = "Store cannot be blank.";
                this.StoreIDLookUpEdit.Focus();
            }

            if (showPrompt && !string.IsNullOrEmpty(ErrorMessage))
            {
                XtraMessageBox.Show(ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ReturnValue;
        }

        private void RefreshControls()
        {
            this.OKsimpleButton.Enabled = this.IsValid(false);
        }

        private void FirstNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshControls();
        }

        private void StoreIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshControls();
        }

        private void ResourceColorColorEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "...";
        }
    }
}