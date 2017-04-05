namespace SalonDB.Win.UserControls
{
    partial class ProductUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.ProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.CategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryCollection1 = new BusinessObjects.CategoryCollection();
            this.colSupplierID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.SupplierBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.supplierCollection1 = new BusinessObjects.SupplierCollection();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.PriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.WholesalePriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CommissionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.BarCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.UnitsInStockTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.UnitsOnOrderTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CategoryIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.SupplierIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForWholesalePrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCommission = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBarCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUnitsInStock = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCategoryID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUnitsOnOrder = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSupplierID = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WholesalePriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommissionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitsInStockTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitsOnOrderTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWholesalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCommission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUnitsInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCategoryID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUnitsOnOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSupplierID)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.dataLayoutControl1);
            this.splitContainer1.Size = new System.Drawing.Size(888, 340);
            this.splitContainer1.SplitterDistance = 621;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridControl2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer2.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer2.Size = new System.Drawing.Size(621, 340);
            this.splitContainer2.SplitterDistance = 293;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.ProductBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2});
            this.gridControl2.Size = new System.Drawing.Size(621, 293);
            this.gridControl2.TabIndex = 2;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // ProductBindingSource
            // 
            this.ProductBindingSource.DataSource = typeof(BusinessObjects.ProductCollection);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colDescription,
            this.colCategoryID,
            this.colSupplierID});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsDetail.EnableMasterViewMode = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.OptionsView.ShowViewCaption = true;
            this.gridView2.RowHeight = 28;
            this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 243;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 189;
            // 
            // colCategoryID
            // 
            this.colCategoryID.Caption = "Category";
            this.colCategoryID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colCategoryID.FieldName = "CategoryID";
            this.colCategoryID.Name = "colCategoryID";
            this.colCategoryID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCategoryID.Visible = true;
            this.colCategoryID.VisibleIndex = 3;
            this.colCategoryID.Width = 90;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DataSource = this.CategoryBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "Name";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "CategoryID";
            // 
            // CategoryBindingSource
            // 
            this.CategoryBindingSource.DataSource = this.categoryCollection1;
            // 
            // categoryCollection1
            // 
            this.categoryCollection1.AllowDelete = true;
            this.categoryCollection1.AllowEdit = true;
            this.categoryCollection1.AllowNew = true;
            this.categoryCollection1.EnableHierarchicalBinding = true;
            this.categoryCollection1.Filter = null;
            // 
            // colSupplierID
            // 
            this.colSupplierID.Caption = "Supplier";
            this.colSupplierID.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colSupplierID.FieldName = "SupplierID";
            this.colSupplierID.Name = "colSupplierID";
            this.colSupplierID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colSupplierID.Visible = true;
            this.colSupplierID.VisibleIndex = 2;
            this.colSupplierID.Width = 97;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit2.DataSource = this.SupplierBindingSource1;
            this.repositoryItemLookUpEdit2.DisplayMember = "Name";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.ValueMember = "SupplierID";
            // 
            // SupplierBindingSource1
            // 
            this.SupplierBindingSource1.DataSource = this.supplierCollection1;
            // 
            // supplierCollection1
            // 
            this.supplierCollection1.AllowDelete = true;
            this.supplierCollection1.AllowEdit = true;
            this.supplierCollection1.AllowNew = true;
            this.supplierCollection1.EnableHierarchicalBinding = true;
            this.supplierCollection1.Filter = null;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleName = "Cancel";
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.CausesValidation = false;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.Location = new System.Drawing.Point(189, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleName = "Ok";
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(10, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleName = "Cancel";
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.CausesValidation = false;
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEdit.Location = new System.Drawing.Point(98, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.textEdit1);
            this.dataLayoutControl1.Controls.Add(this.textEdit2);
            this.dataLayoutControl1.Controls.Add(this.PriceTextEdit);
            this.dataLayoutControl1.Controls.Add(this.WholesalePriceTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CommissionTextEdit);
            this.dataLayoutControl1.Controls.Add(this.BarCodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.UnitsInStockTextEdit);
            this.dataLayoutControl1.Controls.Add(this.UnitsOnOrderTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CategoryIDLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.SupplierIDLookUpEdit);
            this.dataLayoutControl1.DataSource = this.ProductBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(934, 137, 250, 350);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(263, 340);
            this.dataLayoutControl1.TabIndex = 10;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProductBindingSource, "Name", true));
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(102, 42);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(137, 20);
            this.textEdit1.StyleController = this.dataLayoutControl1;
            this.textEdit1.TabIndex = 4;
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProductBindingSource, "Description", true));
            this.textEdit2.Enabled = false;
            this.textEdit2.Location = new System.Drawing.Point(102, 66);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.ReadOnly = true;
            this.textEdit2.Size = new System.Drawing.Size(137, 20);
            this.textEdit2.StyleController = this.dataLayoutControl1;
            this.textEdit2.TabIndex = 5;
            // 
            // PriceTextEdit
            // 
            this.PriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProductBindingSource, "Price", true));
            this.PriceTextEdit.Enabled = false;
            this.PriceTextEdit.Location = new System.Drawing.Point(102, 114);
            this.PriceTextEdit.Name = "PriceTextEdit";
            this.PriceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.PriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.PriceTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PriceTextEdit.Properties.Mask.EditMask = "G";
            this.PriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.PriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PriceTextEdit.Properties.ReadOnly = true;
            this.PriceTextEdit.Size = new System.Drawing.Size(137, 20);
            this.PriceTextEdit.StyleController = this.dataLayoutControl1;
            this.PriceTextEdit.TabIndex = 6;
            // 
            // WholesalePriceTextEdit
            // 
            this.WholesalePriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProductBindingSource, "WholesalePrice", true));
            this.WholesalePriceTextEdit.Enabled = false;
            this.WholesalePriceTextEdit.Location = new System.Drawing.Point(102, 90);
            this.WholesalePriceTextEdit.Name = "WholesalePriceTextEdit";
            this.WholesalePriceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.WholesalePriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.WholesalePriceTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.WholesalePriceTextEdit.Properties.Mask.EditMask = "G";
            this.WholesalePriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.WholesalePriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.WholesalePriceTextEdit.Properties.ReadOnly = true;
            this.WholesalePriceTextEdit.Size = new System.Drawing.Size(137, 20);
            this.WholesalePriceTextEdit.StyleController = this.dataLayoutControl1;
            this.WholesalePriceTextEdit.TabIndex = 7;
            // 
            // CommissionTextEdit
            // 
            this.CommissionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProductBindingSource, "Commission", true));
            this.CommissionTextEdit.Enabled = false;
            this.CommissionTextEdit.Location = new System.Drawing.Point(102, 138);
            this.CommissionTextEdit.Name = "CommissionTextEdit";
            this.CommissionTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CommissionTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.CommissionTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CommissionTextEdit.Properties.Mask.EditMask = "G";
            this.CommissionTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.CommissionTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.CommissionTextEdit.Properties.ReadOnly = true;
            this.CommissionTextEdit.Size = new System.Drawing.Size(137, 20);
            this.CommissionTextEdit.StyleController = this.dataLayoutControl1;
            this.CommissionTextEdit.TabIndex = 8;
            // 
            // BarCodeTextEdit
            // 
            this.BarCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProductBindingSource, "BarCode", true));
            this.BarCodeTextEdit.Enabled = false;
            this.BarCodeTextEdit.Location = new System.Drawing.Point(102, 162);
            this.BarCodeTextEdit.Name = "BarCodeTextEdit";
            this.BarCodeTextEdit.Properties.ReadOnly = true;
            this.BarCodeTextEdit.Size = new System.Drawing.Size(137, 20);
            this.BarCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.BarCodeTextEdit.TabIndex = 9;
            // 
            // UnitsInStockTextEdit
            // 
            this.UnitsInStockTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProductBindingSource, "UnitsInStock", true));
            this.UnitsInStockTextEdit.Enabled = false;
            this.UnitsInStockTextEdit.Location = new System.Drawing.Point(102, 186);
            this.UnitsInStockTextEdit.Name = "UnitsInStockTextEdit";
            this.UnitsInStockTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.UnitsInStockTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.UnitsInStockTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.UnitsInStockTextEdit.Properties.Mask.EditMask = "N0";
            this.UnitsInStockTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.UnitsInStockTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.UnitsInStockTextEdit.Properties.ReadOnly = true;
            this.UnitsInStockTextEdit.Size = new System.Drawing.Size(137, 20);
            this.UnitsInStockTextEdit.StyleController = this.dataLayoutControl1;
            this.UnitsInStockTextEdit.TabIndex = 10;
            // 
            // UnitsOnOrderTextEdit
            // 
            this.UnitsOnOrderTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProductBindingSource, "UnitsOnOrder", true));
            this.UnitsOnOrderTextEdit.Enabled = false;
            this.UnitsOnOrderTextEdit.Location = new System.Drawing.Point(102, 210);
            this.UnitsOnOrderTextEdit.Name = "UnitsOnOrderTextEdit";
            this.UnitsOnOrderTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.UnitsOnOrderTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.UnitsOnOrderTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.UnitsOnOrderTextEdit.Properties.Mask.EditMask = "N0";
            this.UnitsOnOrderTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.UnitsOnOrderTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.UnitsOnOrderTextEdit.Properties.ReadOnly = true;
            this.UnitsOnOrderTextEdit.Size = new System.Drawing.Size(137, 20);
            this.UnitsOnOrderTextEdit.StyleController = this.dataLayoutControl1;
            this.UnitsOnOrderTextEdit.TabIndex = 11;
            // 
            // CategoryIDLookUpEdit
            // 
            this.CategoryIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProductBindingSource, "CategoryID", true));
            this.CategoryIDLookUpEdit.Enabled = false;
            this.CategoryIDLookUpEdit.Location = new System.Drawing.Point(102, 258);
            this.CategoryIDLookUpEdit.Name = "CategoryIDLookUpEdit";
            this.CategoryIDLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CategoryIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CategoryIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.CategoryIDLookUpEdit.Properties.DataSource = this.CategoryBindingSource;
            this.CategoryIDLookUpEdit.Properties.DisplayMember = "Name";
            this.CategoryIDLookUpEdit.Properties.NullText = "";
            this.CategoryIDLookUpEdit.Properties.ValueMember = "CategoryID";
            this.CategoryIDLookUpEdit.Size = new System.Drawing.Size(137, 20);
            this.CategoryIDLookUpEdit.StyleController = this.dataLayoutControl1;
            this.CategoryIDLookUpEdit.TabIndex = 12;
            // 
            // SupplierIDLookUpEdit
            // 
            this.SupplierIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ProductBindingSource, "SupplierID", true));
            this.SupplierIDLookUpEdit.Enabled = false;
            this.SupplierIDLookUpEdit.Location = new System.Drawing.Point(102, 234);
            this.SupplierIDLookUpEdit.Name = "SupplierIDLookUpEdit";
            this.SupplierIDLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.SupplierIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SupplierIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.SupplierIDLookUpEdit.Properties.DataSource = this.SupplierBindingSource1;
            this.SupplierIDLookUpEdit.Properties.DisplayMember = "Name";
            this.SupplierIDLookUpEdit.Properties.NullText = "";
            this.SupplierIDLookUpEdit.Properties.ValueMember = "SupplierID";
            this.SupplierIDLookUpEdit.Size = new System.Drawing.Size(137, 20);
            this.SupplierIDLookUpEdit.StyleController = this.dataLayoutControl1;
            this.SupplierIDLookUpEdit.TabIndex = 13;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(263, 340);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(243, 320);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPrice,
            this.ItemForName,
            this.ItemForWholesalePrice,
            this.ItemForDescription,
            this.ItemForCommission,
            this.ItemForBarCode,
            this.ItemForUnitsInStock,
            this.ItemForCategoryID,
            this.ItemForUnitsOnOrder,
            this.ItemForSupplierID});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(243, 320);
            this.layoutControlGroup3.Text = " ";
            // 
            // ItemForPrice
            // 
            this.ItemForPrice.Control = this.PriceTextEdit;
            this.ItemForPrice.Location = new System.Drawing.Point(0, 72);
            this.ItemForPrice.Name = "ItemForPrice";
            this.ItemForPrice.Size = new System.Drawing.Size(219, 24);
            this.ItemForPrice.Text = "Price";
            this.ItemForPrice.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.textEdit1;
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(219, 24);
            this.ItemForName.Text = "Name";
            this.ItemForName.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForWholesalePrice
            // 
            this.ItemForWholesalePrice.Control = this.WholesalePriceTextEdit;
            this.ItemForWholesalePrice.Location = new System.Drawing.Point(0, 48);
            this.ItemForWholesalePrice.Name = "ItemForWholesalePrice";
            this.ItemForWholesalePrice.Size = new System.Drawing.Size(219, 24);
            this.ItemForWholesalePrice.Text = "Wholesale Price";
            this.ItemForWholesalePrice.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.textEdit2;
            this.ItemForDescription.Location = new System.Drawing.Point(0, 24);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(219, 24);
            this.ItemForDescription.Text = "Description";
            this.ItemForDescription.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForCommission
            // 
            this.ItemForCommission.Control = this.CommissionTextEdit;
            this.ItemForCommission.Location = new System.Drawing.Point(0, 96);
            this.ItemForCommission.Name = "ItemForCommission";
            this.ItemForCommission.Size = new System.Drawing.Size(219, 24);
            this.ItemForCommission.Text = "Commission";
            this.ItemForCommission.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForBarCode
            // 
            this.ItemForBarCode.Control = this.BarCodeTextEdit;
            this.ItemForBarCode.Location = new System.Drawing.Point(0, 120);
            this.ItemForBarCode.Name = "ItemForBarCode";
            this.ItemForBarCode.Size = new System.Drawing.Size(219, 24);
            this.ItemForBarCode.Text = "Bar Code";
            this.ItemForBarCode.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForUnitsInStock
            // 
            this.ItemForUnitsInStock.Control = this.UnitsInStockTextEdit;
            this.ItemForUnitsInStock.Location = new System.Drawing.Point(0, 144);
            this.ItemForUnitsInStock.Name = "ItemForUnitsInStock";
            this.ItemForUnitsInStock.Size = new System.Drawing.Size(219, 24);
            this.ItemForUnitsInStock.Text = "Units In Stock";
            this.ItemForUnitsInStock.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForCategoryID
            // 
            this.ItemForCategoryID.Control = this.CategoryIDLookUpEdit;
            this.ItemForCategoryID.Location = new System.Drawing.Point(0, 216);
            this.ItemForCategoryID.Name = "ItemForCategoryID";
            this.ItemForCategoryID.Size = new System.Drawing.Size(219, 62);
            this.ItemForCategoryID.Text = "Category";
            this.ItemForCategoryID.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForUnitsOnOrder
            // 
            this.ItemForUnitsOnOrder.Control = this.UnitsOnOrderTextEdit;
            this.ItemForUnitsOnOrder.Location = new System.Drawing.Point(0, 168);
            this.ItemForUnitsOnOrder.Name = "ItemForUnitsOnOrder";
            this.ItemForUnitsOnOrder.Size = new System.Drawing.Size(219, 24);
            this.ItemForUnitsOnOrder.Text = "Units On Order";
            this.ItemForUnitsOnOrder.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ItemForSupplierID
            // 
            this.ItemForSupplierID.Control = this.SupplierIDLookUpEdit;
            this.ItemForSupplierID.Location = new System.Drawing.Point(0, 192);
            this.ItemForSupplierID.Name = "ItemForSupplierID";
            this.ItemForSupplierID.Size = new System.Drawing.Size(219, 24);
            this.ItemForSupplierID.Text = "Supplier";
            this.ItemForSupplierID.TextSize = new System.Drawing.Size(75, 13);
            // 
            // ProductUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ProductUC";
            this.Size = new System.Drawing.Size(888, 340);
            this.Load += new System.EventHandler(this.ProductUC_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WholesalePriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommissionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitsInStockTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitsOnOrderTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWholesalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCommission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUnitsInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCategoryID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUnitsOnOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSupplierID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource ProductBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        protected DevExpress.XtraEditors.SimpleButton btnAdd;
        protected DevExpress.XtraEditors.SimpleButton btnEdit;
        protected DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit PriceTextEdit;
        private DevExpress.XtraEditors.TextEdit WholesalePriceTextEdit;
        private DevExpress.XtraEditors.TextEdit CommissionTextEdit;
        private DevExpress.XtraEditors.TextEdit BarCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit UnitsInStockTextEdit;
        private DevExpress.XtraEditors.TextEdit UnitsOnOrderTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForWholesalePrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCommission;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBarCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUnitsInStock;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUnitsOnOrder;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private System.Windows.Forms.BindingSource CategoryBindingSource;
        private BusinessObjects.CategoryCollection categoryCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.LookUpEdit CategoryIDLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCategoryID;
        private BusinessObjects.SupplierCollection supplierCollection1;
        private System.Windows.Forms.BindingSource SupplierBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.LookUpEdit SupplierIDLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSupplierID;
    }
}
