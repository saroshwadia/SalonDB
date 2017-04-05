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
    public partial class ProductUC : UserControl
    {
        BusinessObjects.ProductCollection ProductCollection = new BusinessObjects.ProductCollection();

        public ProductUC()
        {
            InitializeComponent();
            this.gridView2.ViewCaption = "Product";

        }

        private void ProductUC_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.LoadSupplierData();
            this.LoadCategoryData();
            this.LoadProductData();
        }

        private void LoadSupplierData()
        {
            this.supplierCollection1 = SalonDB.Data.DBProviderES.GetSuppliers(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.SupplierBindingSource1.DataSource = this.supplierCollection1;
        }

        private void LoadCategoryData()
        {
            this.categoryCollection1 = SalonDB.Data.DBProviderES.GetCategorys(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.CategoryBindingSource.DataSource = this.categoryCollection1;
        }

        private void LoadProductData()
        {
            ProductCollection = SalonDB.Data.DBProviderES.GetProducts(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.ProductBindingSource.DataSource = ProductCollection;
        }


        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var AddProductForm = new SalonDB.Win.Forms.AddProductForm(null);
            AddProductForm.ShowDialog();

             if (AddProductForm.ReturnValue != null)
            {
                AddProductForm.ReturnValue.CompanyID = SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID;
                ProductCollection.AttachEntity(AddProductForm.ReturnValue);
                ProductCollection.Save();
               
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           var Product =  this.gridView2.GetFocusedRow() as BusinessObjects.Product;

            var AddProductForm = new SalonDB.Win.Forms.AddProductForm(Product);
            AddProductForm.ShowDialog();

            if (AddProductForm.ReturnValue != null)
                AddProductForm.ReturnValue.Save();        


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
                this.ProductCollection.Save();
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
