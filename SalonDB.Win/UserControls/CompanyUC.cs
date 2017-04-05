using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SalonDB.Win.UserControls
{
    public partial class CompanyUC : UserControl
    {

        BusinessObjects.CompanyCollection CompanyCollection = new BusinessObjects.CompanyCollection();

        public CompanyUC()
        {
            InitializeComponent();
            this.gridView2.ViewCaption = "Company";
        }


        private void LoadData()
        {
            CompanyCollection = SalonDB.Data.DBProviderES.GetCompanys();
            this.CompanyBindingSource.DataSource = CompanyCollection;
        }

        private void CompUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var AddCompanyForm = new SalonDB.Win.Forms.AddCompanyForm(null);
            AddCompanyForm.ShowDialog();

            if (AddCompanyForm.ReturnValue != null)
            {
                //AddCompanyForm.ReturnValue.CompanyID = SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID;
                CompanyCollection.AttachEntity(AddCompanyForm.ReturnValue);
                CompanyCollection.Save();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var Company = this.gridView2.GetFocusedRow() as BusinessObjects.Company;
            var AddCompanyForm = new SalonDB.Win.Forms.AddCompanyForm(Company);
            AddCompanyForm.ShowDialog();

            if (AddCompanyForm.ReturnValue != null)
            AddCompanyForm.ReturnValue.Save();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.gridView2 == null || gridView2.SelectedRowsCount == 0) return;
            var confirmResult = XtraMessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.gridView2.DeleteRow(this.gridView2.FocusedRowHandle);
                this.CompanyCollection.Save();
            }
        }
    }
}
