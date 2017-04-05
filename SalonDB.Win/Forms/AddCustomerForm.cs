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
    public partial class AddCustomerForm : BaseForm
    {

        public Customer ReturnValue = null;
        private CustomerCollection _CustomerCol = null;

        public AddCustomerForm(BusinessObjects.Customer Cust)
        {
            InitializeComponent();
            if (Cust != null)
            {
                ReturnValue = Cust;

            }


        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
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
            _CustomerCol = new CustomerCollection();

            if (ReturnValue == null)

            {
                ReturnValue = _CustomerCol.AddNew();
                ReturnValue.Discount = 0;
                this.customerCollectionBindingSource.DataSource = _CustomerCol;
            }
            else
            {
                //_CustomerCol.Select(ReturnValue)
                //this.customerCollectionBindingSource.Position = ReturnValue;
                this.customerCollectionBindingSource.DataSource = ReturnValue;

                 
            }
           
               this.RefreshControls();
        }

        private void OK()
        {
            this.customerCollectionBindingSource.EndEdit();
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

        private void FirstNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshControls();
        }
    }
}