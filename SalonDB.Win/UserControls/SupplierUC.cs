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
    public partial class SupplierUC : UserControl
    {
        BusinessObjects.SupplierCollection SupplierCollection = new BusinessObjects.SupplierCollection();

        public SupplierUC()
        {
            InitializeComponent();
            this.gridView2.ViewCaption = "Supplier";

        }

        private void SupplierUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            SupplierCollection = SalonDB.Data.DBProviderES.GetSuppliers(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.SupplierBindingSource.DataSource = SupplierCollection;
        }


        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var AddSupplierForm = new SalonDB.Win.Forms.AddSupplierForm(null);
            AddSupplierForm.ShowDialog();

             if (AddSupplierForm.ReturnValue != null)
            {
                AddSupplierForm.ReturnValue.CompanyID = SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID;
                SupplierCollection.AttachEntity(AddSupplierForm.ReturnValue);
                SupplierCollection.Save();
               
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           var Supplier =  this.gridView2.GetFocusedRow() as BusinessObjects.Supplier;

            var AddSupplierForm = new SalonDB.Win.Forms.AddSupplierForm(Supplier);
            AddSupplierForm.ShowDialog();

            if (AddSupplierForm.ReturnValue != null)
                AddSupplierForm.ReturnValue.Save();        


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
                this.SupplierCollection.Save();
            }
        }
    }
}
