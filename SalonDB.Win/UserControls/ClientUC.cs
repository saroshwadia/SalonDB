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
    public partial class ClientUC : UserControl
    {
        BusinessObjects.CustomerCollection ClientCollection = new BusinessObjects.CustomerCollection();

        public ClientUC()
        {
            InitializeComponent();
            this.gridView2.ViewCaption = "Client";
        }

        private void ClientUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ClientCollection = SalonDB.Data.DBProviderES.GetCustomers(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.ClientBindingSource.DataSource = ClientCollection;
        }


        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var AddCustomerForm = new SalonDB.Win.Forms.AddCustomerForm(null);
            AddCustomerForm.ShowDialog();

             if (AddCustomerForm.ReturnValue != null)
            {
                AddCustomerForm.ReturnValue.CompanyID = SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID;
                ClientCollection.AttachEntity(AddCustomerForm.ReturnValue);
                ClientCollection.Save();
               
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           var Client =  this.gridView2.GetFocusedRow() as BusinessObjects.Customer;

            var AddCustomerForm = new SalonDB.Win.Forms.AddCustomerForm(Client);
            AddCustomerForm.ShowDialog();

            if (AddCustomerForm.ReturnValue != null)
                AddCustomerForm.ReturnValue.Save();        


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
                this.ClientCollection.Save();
            }
        }
    }
}
