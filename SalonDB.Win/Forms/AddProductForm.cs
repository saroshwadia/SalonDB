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
    public partial class AddProductForm : BaseForm
    {

        public Product ReturnValue = null;
        private ProductCollection ProductCol = null;
        private bool AddNew = true;
        private bool FormLoading = true;

        public AddProductForm(BusinessObjects.Product Product)
        {
            InitializeComponent();
            if (Product != null)
            {
                ReturnValue = Product;
                AddNew = false;
            }
        }

        private void AddProductForm_Load(object sender, EventArgs e)
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
            this.LoadSupplierData();
            this.LoadCategoryData();
            this.LoadProductData();
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
            if (this.SupplierIDLookUpEdit.EditValue == null || this.SupplierIDLookUpEdit.EditValue == DBNull.Value)
            {
                var GetDefaultSupplier = SalonDB.Data.DBProviderES.GetDefaultSupplier(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
                if (GetDefaultSupplier == null)
                {
                    ReturnValue.SupplierID = this.supplierCollection1[0].SupplierID;
                }
                else
                {
                    ReturnValue.SupplierID = GetDefaultSupplier.SupplierID;
                }
            }
            FormLoading = false;
            this.RefreshControls();          
        }

        private void LoadSupplierData()
        {
            this.supplierCollection1 = SalonDB.Data.DBProviderES.GetSuppliers(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.SupplierBindingSource1.DataSource = this.supplierCollection1;
        }

        private void LoadCategoryData()
        {
            this.categoryCollection1 = SalonDB.Data.DBProviderES.GetCategorys(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.CategoryBindingSource.DataSource = this.categoryCollection1;
        }

        private void LoadProductData()
        {
            ProductCol = new ProductCollection();

            if (ReturnValue == null)

            {
                ReturnValue = ProductCol.AddNew();
                this.ProductCollectionBindingSource.DataSource = ProductCol;
            }
            else
            {
                //_CustomerCol.Select(ReturnValue)
                //this.customerCollectionBindingSource.Position = ReturnValue;
                this.ProductCollectionBindingSource.DataSource = ReturnValue;
            }
        }

        private void OK()
        {
            this.ProductCollectionBindingSource.EndEdit();

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

            if (this.SupplierIDLookUpEdit.EditValue == null || this.SupplierIDLookUpEdit.EditValue == DBNull.Value)
            {
                ReturnValue = false;
                ErrorMessage = "Supplier cannot be blank.";
                this.SupplierIDLookUpEdit.Focus();
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

        private void SupplierIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshControls();
        }

        private void CategoryIDLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshControls();
        }
    }
}