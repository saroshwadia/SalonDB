namespace SalonDB.Win.UserControls
{
    partial class ServiceUC
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
            this.ServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.CategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryCollection1 = new BusinessObjects.CategoryCollection();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.PriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DurationTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.CategoryIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDuration = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForShowOnline = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCategoryID = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForShowOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCategoryID)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(957, 483);
            this.splitContainer1.SplitterDistance = 646;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Size = new System.Drawing.Size(646, 483);
            this.splitContainer2.SplitterDistance = 407;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.ServiceBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl2.Size = new System.Drawing.Size(646, 407);
            this.gridControl2.TabIndex = 2;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // ServiceBindingSource
            // 
            this.ServiceBindingSource.DataSource = typeof(BusinessObjects.ServiceCollection);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colDescription,
            this.colCategoryID});
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
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colCategoryID
            // 
            this.colCategoryID.Caption = "Category";
            this.colCategoryID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colCategoryID.FieldName = "CategoryID";
            this.colCategoryID.Name = "colCategoryID";
            this.colCategoryID.Visible = true;
            this.colCategoryID.VisibleIndex = 2;
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
            // btnDelete
            // 
            this.btnDelete.AccessibleName = "Cancel";
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.CausesValidation = false;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.Location = new System.Drawing.Point(189, 33);
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
            this.btnAdd.Location = new System.Drawing.Point(10, 33);
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
            this.btnEdit.Location = new System.Drawing.Point(98, 33);
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
            this.dataLayoutControl1.Controls.Add(this.DurationTextEdit);
            this.dataLayoutControl1.Controls.Add(this.checkEdit1);
            this.dataLayoutControl1.Controls.Add(this.CategoryIDLookUpEdit);
            this.dataLayoutControl1.DataSource = this.ServiceBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(992, 83, 250, 350);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(307, 483);
            this.dataLayoutControl1.TabIndex = 10;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ServiceBindingSource, "Name", true));
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(86, 42);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(197, 20);
            this.textEdit1.StyleController = this.dataLayoutControl1;
            this.textEdit1.TabIndex = 4;
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ServiceBindingSource, "Description", true));
            this.textEdit2.Enabled = false;
            this.textEdit2.Location = new System.Drawing.Point(86, 66);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.ReadOnly = true;
            this.textEdit2.Size = new System.Drawing.Size(197, 20);
            this.textEdit2.StyleController = this.dataLayoutControl1;
            this.textEdit2.TabIndex = 5;
            // 
            // PriceTextEdit
            // 
            this.PriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ServiceBindingSource, "Price", true));
            this.PriceTextEdit.Enabled = false;
            this.PriceTextEdit.Location = new System.Drawing.Point(86, 90);
            this.PriceTextEdit.Name = "PriceTextEdit";
            this.PriceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.PriceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.PriceTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.PriceTextEdit.Properties.Mask.EditMask = "G";
            this.PriceTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.PriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.PriceTextEdit.Properties.ReadOnly = true;
            this.PriceTextEdit.Size = new System.Drawing.Size(197, 20);
            this.PriceTextEdit.StyleController = this.dataLayoutControl1;
            this.PriceTextEdit.TabIndex = 6;
            // 
            // DurationTextEdit
            // 
            this.DurationTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ServiceBindingSource, "Duration", true));
            this.DurationTextEdit.Enabled = false;
            this.DurationTextEdit.Location = new System.Drawing.Point(86, 114);
            this.DurationTextEdit.Name = "DurationTextEdit";
            this.DurationTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.DurationTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.DurationTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DurationTextEdit.Properties.Mask.EditMask = "N0";
            this.DurationTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.DurationTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DurationTextEdit.Properties.ReadOnly = true;
            this.DurationTextEdit.Size = new System.Drawing.Size(197, 20);
            this.DurationTextEdit.StyleController = this.dataLayoutControl1;
            this.DurationTextEdit.TabIndex = 7;
            // 
            // checkEdit1
            // 
            this.checkEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ServiceBindingSource, "ShowOnline", true));
            this.checkEdit1.Enabled = false;
            this.checkEdit1.Location = new System.Drawing.Point(86, 138);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Show Online";
            this.checkEdit1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.checkEdit1.Properties.ReadOnly = true;
            this.checkEdit1.Size = new System.Drawing.Size(197, 19);
            this.checkEdit1.StyleController = this.dataLayoutControl1;
            this.checkEdit1.TabIndex = 8;
            // 
            // CategoryIDLookUpEdit
            // 
            this.CategoryIDLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ServiceBindingSource, "CategoryID", true));
            this.CategoryIDLookUpEdit.Enabled = false;
            this.CategoryIDLookUpEdit.Location = new System.Drawing.Point(86, 161);
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
            this.CategoryIDLookUpEdit.Size = new System.Drawing.Size(197, 20);
            this.CategoryIDLookUpEdit.StyleController = this.dataLayoutControl1;
            this.CategoryIDLookUpEdit.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(307, 483);
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(287, 463);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForName,
            this.ItemForDescription,
            this.ItemForPrice,
            this.ItemForDuration,
            this.ItemForShowOnline,
            this.ItemForCategoryID});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(287, 463);
            this.layoutControlGroup3.Text = " ";
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.textEdit1;
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(263, 24);
            this.ItemForName.Text = "Name";
            this.ItemForName.TextSize = new System.Drawing.Size(59, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.textEdit2;
            this.ItemForDescription.Location = new System.Drawing.Point(0, 24);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(263, 24);
            this.ItemForDescription.Text = "Description";
            this.ItemForDescription.TextSize = new System.Drawing.Size(59, 13);
            // 
            // ItemForPrice
            // 
            this.ItemForPrice.Control = this.PriceTextEdit;
            this.ItemForPrice.Location = new System.Drawing.Point(0, 48);
            this.ItemForPrice.Name = "ItemForPrice";
            this.ItemForPrice.Size = new System.Drawing.Size(263, 24);
            this.ItemForPrice.Text = "Price";
            this.ItemForPrice.TextSize = new System.Drawing.Size(59, 13);
            // 
            // ItemForDuration
            // 
            this.ItemForDuration.Control = this.DurationTextEdit;
            this.ItemForDuration.Location = new System.Drawing.Point(0, 72);
            this.ItemForDuration.Name = "ItemForDuration";
            this.ItemForDuration.Size = new System.Drawing.Size(263, 24);
            this.ItemForDuration.Text = "Duration";
            this.ItemForDuration.TextSize = new System.Drawing.Size(59, 13);
            // 
            // ItemForShowOnline
            // 
            this.ItemForShowOnline.Control = this.checkEdit1;
            this.ItemForShowOnline.Location = new System.Drawing.Point(0, 96);
            this.ItemForShowOnline.Name = "ItemForShowOnline";
            this.ItemForShowOnline.Size = new System.Drawing.Size(263, 23);
            this.ItemForShowOnline.Text = "Show Online";
            this.ItemForShowOnline.TextSize = new System.Drawing.Size(59, 13);
            // 
            // ItemForCategoryID
            // 
            this.ItemForCategoryID.Control = this.CategoryIDLookUpEdit;
            this.ItemForCategoryID.Enabled = false;
            this.ItemForCategoryID.Location = new System.Drawing.Point(0, 119);
            this.ItemForCategoryID.Name = "ItemForCategoryID";
            this.ItemForCategoryID.Size = new System.Drawing.Size(263, 302);
            this.ItemForCategoryID.Text = "Category";
            this.ItemForCategoryID.TextSize = new System.Drawing.Size(59, 13);
            // 
            // ServiceUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ServiceUC";
            this.Size = new System.Drawing.Size(957, 483);
            this.Load += new System.EventHandler(this.ServiceUC_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForShowOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCategoryID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource ServiceBindingSource;
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
        private DevExpress.XtraEditors.TextEdit DurationTextEdit;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDuration;
        private DevExpress.XtraLayout.LayoutControlItem ItemForShowOnline;
        private System.Windows.Forms.BindingSource CategoryBindingSource;
        private BusinessObjects.CategoryCollection categoryCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.LookUpEdit CategoryIDLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCategoryID;
    }
}
