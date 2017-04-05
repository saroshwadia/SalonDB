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

namespace SalonDB.Win.Forms
{
    public partial class AdminForm : BaseForm
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.LoadData();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadData()
        {
            //var ActivityList = SalonDB.Data.DBProvider.ActivityList.GetActivityData();
            //this.ActivityBindingSource.DataSource = ActivityList;
        }

        private void ProductaccControlElement_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            UserControls.ProductUC ProductUC = new UserControls.ProductUC();
            splitContainer1.Panel2.Controls.Add(ProductUC);
            ProductUC.Dock = DockStyle.Fill;
        }

        private void ServiceaccControlElement_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            UserControls.ServiceUC ServiceUC = new UserControls.ServiceUC();
            splitContainer1.Panel2.Controls.Add(ServiceUC);
            ServiceUC.Dock = DockStyle.Fill;
        }

        private void ClientaccControlElement_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            UserControls.ClientUC ClientUC = new UserControls.ClientUC();
            splitContainer1.Panel2.Controls.Add(ClientUC);
            ClientUC.Dock = DockStyle.Fill;
        }

        private void StaffaccControlElement_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            UserControls.StaffUC StaffUC = new UserControls.StaffUC();
            splitContainer1.Panel2.Controls.Add(StaffUC);

            StaffUC.Dock = DockStyle.Fill;
        }

        private void SupplieraccControlElement_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            UserControls.SupplierUC SupplierUC = new UserControls.SupplierUC();
            splitContainer1.Panel2.Controls.Add(SupplierUC);
            SupplierUC.Dock = DockStyle.Fill;
        }

        private void StoreaccControlElement_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            UserControls.StoreUC StoreUC = new UserControls.StoreUC();
            splitContainer1.Panel2.Controls.Add(StoreUC);
            StoreUC.Dock = DockStyle.Fill;
        }

        private void CompanyaccControlElement_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var DataCol = SalonDB.Data.DBProviderES.GetCompanys();
            UserControls.CompanyUC CompanyUC = new UserControls.CompanyUC();
            splitContainer1.Panel2.Controls.Add(CompanyUC);
            CompanyUC.Dock = DockStyle.Fill;
        }

        private void TransactionaccControlElement_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var DataCol = SalonDB.Data.DBProviderES.GetCompanys();
            UserControls.TransactionUC TransactionUC = new UserControls.TransactionUC();
            splitContainer1.Panel2.Controls.Add(TransactionUC);
            TransactionUC.Dock = DockStyle.Fill;
        }
    }
}