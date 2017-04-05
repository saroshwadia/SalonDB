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
    public partial class AddSupplierForm : BaseForm
    {

        public Supplier ReturnValue = null;
        private SupplierCollection SupplierCol = null;

        public AddSupplierForm(BusinessObjects.Supplier Supplier)
        {
            InitializeComponent();
            if (Supplier != null)
            {
                ReturnValue = Supplier;

            }


        }

        private void AddSupplierForm_Load(object sender, EventArgs e)
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
            SupplierCol = new SupplierCollection();

            if (ReturnValue == null)

            {
                ReturnValue = SupplierCol.AddNew();
                this.SupplierCollectionBindingSource.DataSource = SupplierCol;
            }
            else
            {
                //_CustomerCol.Select(ReturnValue)
                //this.customerCollectionBindingSource.Position = ReturnValue;
                this.SupplierCollectionBindingSource.DataSource = ReturnValue;

                 
            }
           
               this.RefreshControls();
        }

        private void OK()
        {
            this.SupplierCollectionBindingSource.EndEdit();
      
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

            //if (this.LastNameTextEdit.EditValue == null)
            //{
            //    ErrorMessage = "Last Name cannot be blank.";
            //    this.LastNameTextEdit.Focus();
            //}

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

   

        private void NameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
 this.RefreshControls();
        }
    }
}