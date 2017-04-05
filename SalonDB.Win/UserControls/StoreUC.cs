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
    public partial class StoreUC : DevExpress.XtraEditors.XtraUserControl
    {

        BusinessObjects.StoreCollection StoreCollection = new BusinessObjects.StoreCollection();
        public StoreUC()
        {
            InitializeComponent();
            this.gridView2.ViewCaption = "Store";
        }

        private void LoadData()
        {
            StoreCollection = SalonDB.Data.DBProviderES.GetStores(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.StoreBindingSource.DataSource = StoreCollection;
        }

        private void StoreUC_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var AddStoreForm = new SalonDB.Win.Forms.AddStoreForm(null);
            AddStoreForm.ShowDialog();

            if (AddStoreForm.ReturnValue != null)
            {
                AddStoreForm.ReturnValue.CompanyID = SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID;
                StoreCollection.AttachEntity(AddStoreForm.ReturnValue);
                StoreCollection.Save();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var Store = this.gridView2.GetFocusedRow() as BusinessObjects.Store;

            var AddStoreForm = new SalonDB.Win.Forms.AddStoreForm(Store);
            AddStoreForm.ShowDialog();

            if (AddStoreForm.ReturnValue != null)
                AddStoreForm.ReturnValue.Save();
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
                this.StoreCollection.Save();

            //DataRow[] rows = new DataRow[gridView2.SelectedRowsCount];

            //for (int i = 0; i < gridView2.SelectedRowsCount; i++)

            //    rows[i] = gridView2.GetDataRow(gridView2.GetSelectedRows()[i]);

            //try
            //{
            //        foreach (DataRow row in rows)
            //        {
            //            row.Delete();
            //            //var Store = this.gridView2.GetFocusedRow() as BusinessObjects.Store;
            //            //Store.MarkAsDeleted();

            //        }
                   
            //}

            //finally
            //{
            //    //gridView2.EndSort();
            //} 
            }
           
        }
    }
}
