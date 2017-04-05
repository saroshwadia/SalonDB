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
    public partial class AddServiceForm : BaseForm
    {

        public Service ReturnValue = null;
        private ServiceCollection ServiceCol = null;
        private bool AddNew = true;
        private bool FormLoading = true;

        public AddServiceForm(BusinessObjects.Service Service)
        {
            InitializeComponent();
            if (Service != null)
            {
                ReturnValue = Service;
                AddNew = false;
            }
        }

        private void AddServiceForm_Load(object sender, EventArgs e)
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
            FormLoading = true;
            this.LoadCategoryData();
            this.LoadServiceData();
            if (this.CategoryIDLookUpEdit.EditValue == null || this.CategoryIDLookUpEdit.EditValue == DBNull.Value)
            {
                var GetDefaultCategory = SalonDB.Data.DBProviderES.GetDefaultCategory(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
                if (GetDefaultCategory == null)
                {
                    ReturnValue.CategoryID = this.categoryCollection1[0].CategoryID;
                }
                else
                {
                    ReturnValue.CategoryID = GetDefaultCategory.CategoryID;
                }
            }
            FormLoading = false;
            this.RefreshControls();
        }

        private void LoadCategoryData()
        {
            this.categoryCollection1 = SalonDB.Data.DBProviderES.GetCategorys(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.CategoryBindingSource.DataSource = this.categoryCollection1;
        }

        private void LoadServiceData()
        {
            ServiceCol = new ServiceCollection();

            if (ReturnValue == null)

            {
                ReturnValue = ServiceCol.AddNew();
                this.ServiceCollectionBindingSource.DataSource = ServiceCol;
            }
            else
            {
                //_CustomerCol.Select(ReturnValue)
                //this.customerCollectionBindingSource.Position = ReturnValue;
                this.ServiceCollectionBindingSource.DataSource = ReturnValue;
            }
        }

        private void OK()
        {
            this.ServiceCollectionBindingSource.EndEdit();

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

            if (string.IsNullOrEmpty(this.NameTextEdit.Text))
            {
                ReturnValue = false;
                ErrorMessage = "Name cannot be blank.";
                this.NameTextEdit.Focus();
            }

            if (this.CategoryIDLookUpEdit.EditValue == null || this.CategoryIDLookUpEdit.EditValue == DBNull.Value)
            {
                ReturnValue = false;
                ErrorMessage = "Category cannot be blank.";
                this.CategoryIDLookUpEdit.Focus();
            }

            if (showPrompt && !string.IsNullOrEmpty(ErrorMessage))
            {
                XtraMessageBox.Show(ErrorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ReturnValue;
        }

        private void RefreshControls()
        {
            if (!FormLoading)
            {
                this.OKsimpleButton.Enabled = this.IsValid(false);
            }
        }

        private void NameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshControls();
        }

        private void CategoryIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshControls();
        }
    }
}