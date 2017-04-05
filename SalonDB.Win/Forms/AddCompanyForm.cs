using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;
using DevExpress.XtraEditors;

namespace SalonDB.Win.Forms
{
    public partial class AddCompanyForm : Form
    {

        public Company ReturnValue = null;
        private CompanyCollection _CompanyCollection = null;
        public AddCompanyForm(BusinessObjects.Company Company)
        {
            InitializeComponent();
            if (Company != null)
            {
                ReturnValue = Company;

            }

        }

        private void LoadData()
        {
            _CompanyCollection = new CompanyCollection();

            if (ReturnValue == null)

            {
                ReturnValue = _CompanyCollection.AddNew();
              
                this.CompanyBindingSource.DataSource = _CompanyCollection;
            }
            else
            {
                //_CustomerCol.Select(ReturnValue)
                //this.customerCollectionBindingSource.Position = ReturnValue;
                this.CompanyBindingSource.DataSource = ReturnValue;

            }

            this.RefreshControls();
        }

        private void OK()
        {
            this.CompanyBindingSource.EndEdit();
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

            if (string.IsNullOrEmpty(this.textEdit2.Text))
            {
                ReturnValue = false;
                ErrorMessage = "Name cannot be blank.";
                this.textEdit2.Focus();
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

        private void AddCompanyForm_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            RefreshControls();

        }

        private void OKsimpleButton_Click(object sender, EventArgs e)
        {
            this.OK();
        }

        private void CancelsimpleButton_Click(object sender, EventArgs e)
        {
            this.Cancel();

        }
    }
}
