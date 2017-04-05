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
using SalonDB.Data;

namespace SalonDB.Win.Forms
{
    public partial class LoginForm : BaseForm
    {

        public Staff ReturnValue = null;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.EmailTextEdit.Text = "s.w@gsmtech.com";
            this.PasswordTextEdit.Text = "12345";
            this.RefreshControls();
        }

        private void Cancel()
        {
            ReturnValue = null;
            this.Close();
        }

        private void OK()
        {
            var Email = this.EmailTextEdit.Text;
            var Password = this.PasswordTextEdit.Text;

            ReturnValue = DBProviderES.GetStaff(Email, Password);
            Class.Util.LoggedUser = ReturnValue;
            Class.Util.Company = ReturnValue.UpToCompanyByCompanyID;
            Class.Util.Store = ReturnValue.UpToStoreByStoreID;

            if (ReturnValue != null)
            {
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Invalid Email/Password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshControls()
        {
            this.OKsimpleButton.Enabled = !(string.IsNullOrEmpty(this.EmailTextEdit.Text) || string.IsNullOrEmpty(this.PasswordTextEdit.Text));
        }

        private void ShowHidePasswordChar()
        {
            char charValBlank = this.EmailTextEdit.Properties.PasswordChar;
            char charValStar = '*';

            if (this.ShowHidecheckButton.Checked == true)
            {
                this.PasswordTextEdit.Properties.PasswordChar = charValBlank;
            }
            else
            {
                this.PasswordTextEdit.Properties.PasswordChar = charValStar;
            }
        }

        private void ShowHidecheckButton_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowHidePasswordChar();
        }

        private void OKsimpleButton_Click(object sender, EventArgs e)
        {
            this.OK();
        }

        private void CancelsimpleButton_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        private void EmailTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshControls();
        }

        private void PasswordTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshControls();
        }
    }
}