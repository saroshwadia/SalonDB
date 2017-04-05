namespace SalonDB.Win.UserControls
{
    partial class SupplierUC
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
            this.SupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit5 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit6 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPostalCode = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPostalCode)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(1037, 536);
            this.splitContainer1.SplitterDistance = 652;
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
            this.splitContainer2.Size = new System.Drawing.Size(652, 536);
            this.splitContainer2.SplitterDistance = 452;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.SupplierBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(652, 452);
            this.gridControl2.TabIndex = 2;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // SupplierBindingSource
            // 
            this.SupplierBindingSource.DataSource = typeof(BusinessObjects.SupplierCollection);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colDescription});
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
            // btnDelete
            // 
            this.btnDelete.AccessibleName = "Cancel";
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.CausesValidation = false;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.Location = new System.Drawing.Point(189, 41);
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
            this.btnAdd.Location = new System.Drawing.Point(10, 41);
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
            this.btnEdit.Location = new System.Drawing.Point(98, 41);
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
            this.dataLayoutControl1.Controls.Add(this.textEdit3);
            this.dataLayoutControl1.Controls.Add(this.textEdit4);
            this.dataLayoutControl1.Controls.Add(this.textEdit5);
            this.dataLayoutControl1.Controls.Add(this.textEdit6);
            this.dataLayoutControl1.DataSource = this.SupplierBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(985, 333, 250, 350);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(381, 536);
            this.dataLayoutControl1.TabIndex = 12;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplierBindingSource, "Name", true));
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(84, 42);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(273, 20);
            this.textEdit1.StyleController = this.dataLayoutControl1;
            this.textEdit1.TabIndex = 4;
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplierBindingSource, "Description", true));
            this.textEdit2.Enabled = false;
            this.textEdit2.Location = new System.Drawing.Point(84, 66);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.ReadOnly = true;
            this.textEdit2.Size = new System.Drawing.Size(273, 20);
            this.textEdit2.StyleController = this.dataLayoutControl1;
            this.textEdit2.TabIndex = 5;
            // 
            // textEdit3
            // 
            this.textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplierBindingSource, "Phone", true));
            this.textEdit3.Enabled = false;
            this.textEdit3.Location = new System.Drawing.Point(84, 90);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.ReadOnly = true;
            this.textEdit3.Size = new System.Drawing.Size(273, 20);
            this.textEdit3.StyleController = this.dataLayoutControl1;
            this.textEdit3.TabIndex = 6;
            // 
            // textEdit4
            // 
            this.textEdit4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplierBindingSource, "Address", true));
            this.textEdit4.Enabled = false;
            this.textEdit4.Location = new System.Drawing.Point(84, 114);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.ReadOnly = true;
            this.textEdit4.Size = new System.Drawing.Size(273, 20);
            this.textEdit4.StyleController = this.dataLayoutControl1;
            this.textEdit4.TabIndex = 7;
            // 
            // textEdit5
            // 
            this.textEdit5.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplierBindingSource, "City", true));
            this.textEdit5.Enabled = false;
            this.textEdit5.Location = new System.Drawing.Point(84, 138);
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Properties.ReadOnly = true;
            this.textEdit5.Size = new System.Drawing.Size(273, 20);
            this.textEdit5.StyleController = this.dataLayoutControl1;
            this.textEdit5.TabIndex = 8;
            // 
            // textEdit6
            // 
            this.textEdit6.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SupplierBindingSource, "PostalCode", true));
            this.textEdit6.Enabled = false;
            this.textEdit6.Location = new System.Drawing.Point(84, 162);
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Properties.ReadOnly = true;
            this.textEdit6.Size = new System.Drawing.Size(273, 20);
            this.textEdit6.StyleController = this.dataLayoutControl1;
            this.textEdit6.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(381, 536);
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(361, 516);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForName,
            this.ItemForDescription,
            this.ItemForPhone,
            this.ItemForAddress,
            this.ItemForCity,
            this.ItemForPostalCode});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(361, 516);
            this.layoutControlGroup3.Text = " ";
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.textEdit1;
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(337, 24);
            this.ItemForName.Text = "Name";
            this.ItemForName.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.textEdit2;
            this.ItemForDescription.Location = new System.Drawing.Point(0, 24);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(337, 24);
            this.ItemForDescription.Text = "Description";
            this.ItemForDescription.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForPhone
            // 
            this.ItemForPhone.Control = this.textEdit3;
            this.ItemForPhone.Location = new System.Drawing.Point(0, 48);
            this.ItemForPhone.Name = "ItemForPhone";
            this.ItemForPhone.Size = new System.Drawing.Size(337, 24);
            this.ItemForPhone.Text = "Phone";
            this.ItemForPhone.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForAddress
            // 
            this.ItemForAddress.Control = this.textEdit4;
            this.ItemForAddress.Location = new System.Drawing.Point(0, 72);
            this.ItemForAddress.Name = "ItemForAddress";
            this.ItemForAddress.Size = new System.Drawing.Size(337, 24);
            this.ItemForAddress.Text = "Address";
            this.ItemForAddress.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForCity
            // 
            this.ItemForCity.Control = this.textEdit5;
            this.ItemForCity.Location = new System.Drawing.Point(0, 96);
            this.ItemForCity.Name = "ItemForCity";
            this.ItemForCity.Size = new System.Drawing.Size(337, 24);
            this.ItemForCity.Text = "City";
            this.ItemForCity.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForPostalCode
            // 
            this.ItemForPostalCode.Control = this.textEdit6;
            this.ItemForPostalCode.Location = new System.Drawing.Point(0, 120);
            this.ItemForPostalCode.Name = "ItemForPostalCode";
            this.ItemForPostalCode.Size = new System.Drawing.Size(337, 354);
            this.ItemForPostalCode.Text = "Postal Code";
            this.ItemForPostalCode.TextSize = new System.Drawing.Size(57, 13);
            // 
            // SupplierUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SupplierUC";
            this.Size = new System.Drawing.Size(1037, 536);
            this.Load += new System.EventHandler(this.SupplierUC_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPostalCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource SupplierBindingSource;
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
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit5;
        private DevExpress.XtraEditors.TextEdit textEdit6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPhone;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPostalCode;
    }
}
