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
    public partial class StaffUC : UserControl
    {
        BusinessObjects.StaffCollection StaffCollection = new BusinessObjects.StaffCollection();

        public StaffUC()
        {
            InitializeComponent();
            this.ResourceColorColorEdit.EditValue = this.ResourceColorColorEdit.EditValue;
            this.gridView2.ViewCaption = "Staff";

        }

        private void StaffUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.LoadStoreData();
            this.LoadStaffData();
        }

        private void LoadStaffData()
        {
            StaffCollection = SalonDB.Data.DBProviderES.GetStaffs(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.StaffBindingSource.DataSource = StaffCollection;
        }

        private void LoadStoreData()
        {
            storeCollection1 = SalonDB.Data.DBProviderES.GetStores(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.StoreBindingSource.DataSource = storeCollection1;
        }


        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var AddStaffForm = new SalonDB.Win.Forms.AddStaffForm(null);
            AddStaffForm.ShowDialog();

            if (AddStaffForm.ReturnValue != null)
            {
                AddStaffForm.ReturnValue.CompanyID = SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID;
                StaffCollection.AttachEntity(AddStaffForm.ReturnValue);
                StaffCollection.Save();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var Staff = this.gridView2.GetFocusedRow() as BusinessObjects.Staff;

            var AddStaffForm = new SalonDB.Win.Forms.AddStaffForm(Staff);
            AddStaffForm.ShowDialog();

            if (AddStaffForm.ReturnValue != null)
                AddStaffForm.ReturnValue.Save();


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
                this.StaffCollection.Save();
            }
        }
        
        private void ResourceColorColorEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "...";
        }
    }
}
