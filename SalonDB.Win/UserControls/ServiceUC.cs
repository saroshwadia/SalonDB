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
    public partial class ServiceUC : UserControl
    {
        BusinessObjects.ServiceCollection ServiceCollection = new BusinessObjects.ServiceCollection();

        public ServiceUC()
        {
            InitializeComponent();
            this.gridView2.ViewCaption = "Service";

        }

        private void ServiceUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.LoadCategoryData();
            this.LoadServiceData();
        }

        private void LoadCategoryData()
        {
            this.categoryCollection1 = SalonDB.Data.DBProviderES.GetCategorys(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.CategoryBindingSource.DataSource = this.categoryCollection1;
        }

        private void LoadServiceData()
        {
            ServiceCollection = SalonDB.Data.DBProviderES.GetServices(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.ServiceBindingSource.DataSource = ServiceCollection;
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var AddServiceForm = new SalonDB.Win.Forms.AddServiceForm(null);
            AddServiceForm.ShowDialog();

             if (AddServiceForm.ReturnValue != null)
            {
                AddServiceForm.ReturnValue.CompanyID = SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID;
                ServiceCollection.AttachEntity(AddServiceForm.ReturnValue);
                ServiceCollection.Save();
               
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           var Service =  this.gridView2.GetFocusedRow() as BusinessObjects.Service;

            var AddServiceForm = new SalonDB.Win.Forms.AddServiceForm(Service);
            AddServiceForm.ShowDialog();

            if (AddServiceForm.ReturnValue != null)
                AddServiceForm.ReturnValue.Save();        


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
                this.ServiceCollection.Save();
            }
        }
    }
}
