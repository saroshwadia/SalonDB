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
    public partial class AddStoreForm : BaseForm
    {

        public Store ReturnValue = null;
        private StoreCollection _StoreCol = null;

        public AddStoreForm(BusinessObjects.Store Store)
        {
            InitializeComponent();
            if (Store != null)
            {
                ReturnValue = Store;

            }


        }

        private void AddStoreForm_Load(object sender, EventArgs e)
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
            _StoreCol = new StoreCollection();

            if (ReturnValue == null)

            {
                ReturnValue = _StoreCol.AddNew();
             
                this.storeCollectionBindingSource.DataSource = _StoreCol;
            }
            else
            {
                //_CustomerCol.Select(ReturnValue)
                //this.customerCollectionBindingSource.Position = ReturnValue;
                this.storeCollectionBindingSource.DataSource = ReturnValue;

                 
            }
           
               this.RefreshControls();
        }

        private void OK()
        {
            this.storeCollectionBindingSource.EndEdit();
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
                ErrorMessage = "Name cannot be blank.";
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