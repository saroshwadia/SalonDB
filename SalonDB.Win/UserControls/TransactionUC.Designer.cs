namespace SalonDB.Win.UserControls
{
    partial class TransactionUC
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.TransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionCollection1 = new BusinessObjects.TransactionCollection();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTransactionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.StoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.storeCollection1 = new BusinessObjects.StoreCollection();
            this.colStaffID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.StaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.staffCollection1 = new BusinessObjects.StaffCollection();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.CustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerCollection1 = new BusinessObjects.CustomerCollection();
            this.colTransactionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.ServiceProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.serviceCollection1 = new BusinessObjects.ServiceCollection();
            this.ServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productCollection1 = new BusinessObjects.ProductCollection();
            this.ProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrintSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(13, 12);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(742, 475);
            this.splitContainerControl1.SplitterPosition = 235;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.TransactionBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit3});
            this.gridControl1.Size = new System.Drawing.Size(742, 235);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // TransactionBindingSource
            // 
            this.TransactionBindingSource.DataSource = this.transactionCollection1;
            // 
            // transactionCollection1
            // 
            this.transactionCollection1.AllowDelete = true;
            this.transactionCollection1.AllowEdit = true;
            this.transactionCollection1.AllowNew = true;
            this.transactionCollection1.EnableHierarchicalBinding = true;
            this.transactionCollection1.Filter = null;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTransactionNumber,
            this.colStoreID,
            this.colStaffID,
            this.colCustomerID,
            this.colTransactionDate,
            this.colAmount,
            this.colDiscountPercent,
            this.colTaxPercent,
            this.colTotal,
            this.colStatus});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 28;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colTransactionNumber
            // 
            this.colTransactionNumber.FieldName = "TransactionNumber";
            this.colTransactionNumber.Name = "colTransactionNumber";
            this.colTransactionNumber.Visible = true;
            this.colTransactionNumber.VisibleIndex = 0;
            this.colTransactionNumber.Width = 104;
            // 
            // colStoreID
            // 
            this.colStoreID.Caption = "Store";
            this.colStoreID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colStoreID.FieldName = "StoreID";
            this.colStoreID.Name = "colStoreID";
            this.colStoreID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colStoreID.Visible = true;
            this.colStoreID.VisibleIndex = 1;
            this.colStoreID.Width = 150;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DataSource = this.StoreBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "Name";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "StoreID";
            // 
            // StoreBindingSource
            // 
            this.StoreBindingSource.DataSource = this.storeCollection1;
            // 
            // storeCollection1
            // 
            this.storeCollection1.AllowDelete = true;
            this.storeCollection1.AllowEdit = true;
            this.storeCollection1.AllowNew = true;
            this.storeCollection1.EnableHierarchicalBinding = true;
            this.storeCollection1.Filter = null;
            // 
            // colStaffID
            // 
            this.colStaffID.Caption = "Staff";
            this.colStaffID.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colStaffID.FieldName = "StaffID";
            this.colStaffID.Name = "colStaffID";
            this.colStaffID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colStaffID.Visible = true;
            this.colStaffID.VisibleIndex = 2;
            this.colStaffID.Width = 150;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit2.DataSource = this.StaffBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "Name";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.ValueMember = "StaffID";
            // 
            // StaffBindingSource
            // 
            this.StaffBindingSource.DataSource = this.staffCollection1;
            // 
            // staffCollection1
            // 
            this.staffCollection1.AllowDelete = true;
            this.staffCollection1.AllowEdit = true;
            this.staffCollection1.AllowNew = true;
            this.staffCollection1.EnableHierarchicalBinding = true;
            this.staffCollection1.Filter = null;
            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "Customer";
            this.colCustomerID.ColumnEdit = this.repositoryItemLookUpEdit3;
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCustomerID.Visible = true;
            this.colCustomerID.VisibleIndex = 3;
            this.colCustomerID.Width = 150;
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit3.DataSource = this.CustomerBindingSource;
            this.repositoryItemLookUpEdit3.DisplayMember = "Name";
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            this.repositoryItemLookUpEdit3.NullText = "";
            this.repositoryItemLookUpEdit3.ValueMember = "CustomerID";
            // 
            // CustomerBindingSource
            // 
            this.CustomerBindingSource.DataSource = this.customerCollection1;
            // 
            // customerCollection1
            // 
            this.customerCollection1.AllowDelete = true;
            this.customerCollection1.AllowEdit = true;
            this.customerCollection1.AllowNew = true;
            this.customerCollection1.EnableHierarchicalBinding = true;
            this.customerCollection1.Filter = null;
            // 
            // colTransactionDate
            // 
            this.colTransactionDate.DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss tt";
            this.colTransactionDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTransactionDate.FieldName = "TransactionDate";
            this.colTransactionDate.Name = "colTransactionDate";
            this.colTransactionDate.Visible = true;
            this.colTransactionDate.VisibleIndex = 4;
            this.colTransactionDate.Width = 150;
            // 
            // colAmount
            // 
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 5;
            this.colAmount.Width = 125;
            // 
            // colDiscountPercent
            // 
            this.colDiscountPercent.DisplayFormat.FormatString = "n2";
            this.colDiscountPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiscountPercent.FieldName = "DiscountPercent";
            this.colDiscountPercent.Name = "colDiscountPercent";
            this.colDiscountPercent.Visible = true;
            this.colDiscountPercent.VisibleIndex = 6;
            this.colDiscountPercent.Width = 125;
            // 
            // colTaxPercent
            // 
            this.colTaxPercent.DisplayFormat.FormatString = "n2";
            this.colTaxPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxPercent.FieldName = "TaxPercent";
            this.colTaxPercent.Name = "colTaxPercent";
            this.colTaxPercent.Visible = true;
            this.colTaxPercent.VisibleIndex = 7;
            this.colTaxPercent.Width = 125;
            // 
            // colTotal
            // 
            this.colTotal.DisplayFormat.FormatString = "n2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 8;
            this.colTotal.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;
            this.colStatus.Width = 125;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.ServiceProductBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2});
            this.gridControl2.Size = new System.Drawing.Size(742, 235);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.UseEmbeddedNavigator = true;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colPrice,
            this.colQuantity,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView2.OptionsDetail.EnableMasterViewMode = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.ShowDetailButtons = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.RowHeight = 28;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 200;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Price";
            this.colPrice.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 1;
            this.colPrice.Width = 100;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Mask.EditMask = "n2";
            this.repositoryItemSpinEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Quantity";
            this.colQuantity.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:0}")});
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 2;
            this.colQuantity.Width = 100;
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit2.Mask.EditMask = "n0";
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Discount %";
            this.gridColumn1.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn1.FieldName = "DiscountPercent";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Total";
            this.gridColumn2.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn2.FieldName = "Total";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:0.00}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 100;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // serviceCollection1
            // 
            this.serviceCollection1.AllowDelete = true;
            this.serviceCollection1.AllowEdit = true;
            this.serviceCollection1.AllowNew = true;
            this.serviceCollection1.EnableHierarchicalBinding = true;
            this.serviceCollection1.Filter = null;
            // 
            // ServiceBindingSource
            // 
            this.ServiceBindingSource.DataSource = this.serviceCollection1;
            // 
            // productCollection1
            // 
            this.productCollection1.AllowDelete = true;
            this.productCollection1.AllowEdit = true;
            this.productCollection1.AllowNew = true;
            this.productCollection1.EnableHierarchicalBinding = true;
            this.productCollection1.Filter = null;
            // 
            // ProductBindingSource
            // 
            this.ProductBindingSource.DataSource = this.productCollection1;
            // 
            // PrintSimpleButton
            // 
            this.PrintSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PrintSimpleButton.Location = new System.Drawing.Point(13, 521);
            this.PrintSimpleButton.Name = "PrintSimpleButton";
            this.PrintSimpleButton.Size = new System.Drawing.Size(75, 23);
            this.PrintSimpleButton.TabIndex = 4;
            this.PrintSimpleButton.Text = "Print";
            this.PrintSimpleButton.Click += new System.EventHandler(this.PrintSimpleButton_Click);
            // 
            // TransactionUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PrintSimpleButton);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "TransactionUC";
            this.Size = new System.Drawing.Size(772, 567);
            this.Load += new System.EventHandler(this.TransactionUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource TransactionBindingSource;
        private BusinessObjects.TransactionCollection transactionCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreID;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffID;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private BusinessObjects.StaffCollection staffCollection1;
        private System.Windows.Forms.BindingSource StaffBindingSource;
        private BusinessObjects.StoreCollection storeCollection1;
        private System.Windows.Forms.BindingSource StoreBindingSource;
        private BusinessObjects.ServiceCollection serviceCollection1;
        private System.Windows.Forms.BindingSource ServiceBindingSource;
        private BusinessObjects.ProductCollection productCollection1;
        private System.Windows.Forms.BindingSource ProductBindingSource;
        private System.Windows.Forms.BindingSource ServiceProductBindingSource;
        private BusinessObjects.CustomerCollection customerCollection1;
        private System.Windows.Forms.BindingSource CustomerBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.SimpleButton PrintSimpleButton;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
    }
}
