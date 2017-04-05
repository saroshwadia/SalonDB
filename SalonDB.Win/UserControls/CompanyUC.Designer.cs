namespace SalonDB.Win.UserControls
{
    partial class CompanyUC
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
            this.CompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.CustomerIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CompanyIDLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.FirstNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LastNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PhoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.AddressTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PostalCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCustomerID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCompanyID = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPostalCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForFirstName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastName = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyIDLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddressTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostalCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompanyID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPostalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastName)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.dataLayoutControl1);
            this.splitContainer1.Size = new System.Drawing.Size(799, 464);
            this.splitContainer1.SplitterDistance = 534;
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
            this.splitContainer2.Size = new System.Drawing.Size(534, 464);
            this.splitContainer2.SplitterDistance = 413;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.CompanyBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(534, 413);
            this.gridControl2.TabIndex = 3;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // CompanyBindingSource
            // 
            this.CompanyBindingSource.DataSource = typeof(BusinessObjects.CompanyCollection);
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
            this.btnDelete.Location = new System.Drawing.Point(198, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleName = "Ok";
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(15, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleName = "Cancel";
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.CausesValidation = false;
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEdit.Location = new System.Drawing.Point(103, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLayoutControl1.Controls.Add(this.CustomerIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CompanyIDLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.FirstNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.LastNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PhoneTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AddressTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CityTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PostalCodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NameTextEdit);
            this.dataLayoutControl1.DataSource = this.CompanyBindingSource;
            this.dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForName,
            this.ItemForCustomerID,
            this.ItemForCompanyID});
            this.dataLayoutControl1.Location = new System.Drawing.Point(9, -10);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(626, 268, 250, 350);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(244, 483);
            this.dataLayoutControl1.TabIndex = 2;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // CustomerIDTextEdit
            // 
            this.CustomerIDTextEdit.Location = new System.Drawing.Point(87, 42);
            this.CustomerIDTextEdit.Name = "CustomerIDTextEdit";
            this.CustomerIDTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CustomerIDTextEdit.Size = new System.Drawing.Size(455, 20);
            this.CustomerIDTextEdit.StyleController = this.dataLayoutControl1;
            this.CustomerIDTextEdit.TabIndex = 4;
            // 
            // CompanyIDLookUpEdit
            // 
            this.CompanyIDLookUpEdit.Location = new System.Drawing.Point(87, 66);
            this.CompanyIDLookUpEdit.Name = "CompanyIDLookUpEdit";
            this.CompanyIDLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CompanyIDLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CompanyIDLookUpEdit.Properties.NullText = "";
            this.CompanyIDLookUpEdit.Size = new System.Drawing.Size(455, 20);
            this.CompanyIDLookUpEdit.StyleController = this.dataLayoutControl1;
            this.CompanyIDLookUpEdit.TabIndex = 5;
            // 
            // FirstNameTextEdit
            // 
            this.FirstNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CompanyBindingSource, "Name", true));
            this.FirstNameTextEdit.Enabled = false;
            this.FirstNameTextEdit.Location = new System.Drawing.Point(84, 42);
            this.FirstNameTextEdit.Name = "FirstNameTextEdit";
            this.FirstNameTextEdit.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.FirstNameTextEdit.Properties.Appearance.Options.UseBackColor = true;
            this.FirstNameTextEdit.Properties.ReadOnly = true;
            this.FirstNameTextEdit.Size = new System.Drawing.Size(136, 20);
            this.FirstNameTextEdit.StyleController = this.dataLayoutControl1;
            this.FirstNameTextEdit.TabIndex = 6;
            // 
            // LastNameTextEdit
            // 
            this.LastNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CompanyBindingSource, "Description", true));
            this.LastNameTextEdit.Enabled = false;
            this.LastNameTextEdit.Location = new System.Drawing.Point(84, 66);
            this.LastNameTextEdit.Name = "LastNameTextEdit";
            this.LastNameTextEdit.Properties.ReadOnly = true;
            this.LastNameTextEdit.Size = new System.Drawing.Size(136, 20);
            this.LastNameTextEdit.StyleController = this.dataLayoutControl1;
            this.LastNameTextEdit.TabIndex = 7;
            // 
            // PhoneTextEdit
            // 
            this.PhoneTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CompanyBindingSource, "Phone", true));
            this.PhoneTextEdit.Enabled = false;
            this.PhoneTextEdit.Location = new System.Drawing.Point(84, 132);
            this.PhoneTextEdit.Name = "PhoneTextEdit";
            this.PhoneTextEdit.Properties.ReadOnly = true;
            this.PhoneTextEdit.Size = new System.Drawing.Size(136, 20);
            this.PhoneTextEdit.StyleController = this.dataLayoutControl1;
            this.PhoneTextEdit.TabIndex = 8;
            // 
            // AddressTextEdit
            // 
            this.AddressTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CompanyBindingSource, "Address", true));
            this.AddressTextEdit.Enabled = false;
            this.AddressTextEdit.Location = new System.Drawing.Point(84, 156);
            this.AddressTextEdit.Name = "AddressTextEdit";
            this.AddressTextEdit.Properties.ReadOnly = true;
            this.AddressTextEdit.Size = new System.Drawing.Size(136, 20);
            this.AddressTextEdit.StyleController = this.dataLayoutControl1;
            this.AddressTextEdit.TabIndex = 10;
            // 
            // CityTextEdit
            // 
            this.CityTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CompanyBindingSource, "City", true));
            this.CityTextEdit.Enabled = false;
            this.CityTextEdit.Location = new System.Drawing.Point(84, 180);
            this.CityTextEdit.Name = "CityTextEdit";
            this.CityTextEdit.Properties.ReadOnly = true;
            this.CityTextEdit.Size = new System.Drawing.Size(136, 20);
            this.CityTextEdit.StyleController = this.dataLayoutControl1;
            this.CityTextEdit.TabIndex = 11;
            // 
            // PostalCodeTextEdit
            // 
            this.PostalCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CompanyBindingSource, "PostalCode", true));
            this.PostalCodeTextEdit.Enabled = false;
            this.PostalCodeTextEdit.Location = new System.Drawing.Point(84, 204);
            this.PostalCodeTextEdit.Name = "PostalCodeTextEdit";
            this.PostalCodeTextEdit.Properties.ReadOnly = true;
            this.PostalCodeTextEdit.Size = new System.Drawing.Size(136, 20);
            this.PostalCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.PostalCodeTextEdit.TabIndex = 12;
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.Location = new System.Drawing.Point(76, 276);
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Size = new System.Drawing.Size(465, 20);
            this.NameTextEdit.StyleController = this.dataLayoutControl1;
            this.NameTextEdit.TabIndex = 15;
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 264);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(533, 39);
            this.ItemForName.Text = "Name";
            this.ItemForName.TextSize = new System.Drawing.Size(50, 20);
            // 
            // ItemForCustomerID
            // 
            this.ItemForCustomerID.Control = this.CustomerIDTextEdit;
            this.ItemForCustomerID.Location = new System.Drawing.Point(0, 0);
            this.ItemForCustomerID.Name = "ItemForCustomerID";
            this.ItemForCustomerID.Size = new System.Drawing.Size(522, 24);
            this.ItemForCustomerID.Text = "Customer ID";
            this.ItemForCustomerID.TextSize = new System.Drawing.Size(60, 13);
            // 
            // ItemForCompanyID
            // 
            this.ItemForCompanyID.Control = this.CompanyIDLookUpEdit;
            this.ItemForCompanyID.Location = new System.Drawing.Point(0, 0);
            this.ItemForCompanyID.Name = "ItemForCompanyID";
            this.ItemForCompanyID.Size = new System.Drawing.Size(522, 48);
            this.ItemForCompanyID.Text = "Company";
            this.ItemForCompanyID.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(244, 483);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlGroup6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(224, 463);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPhone,
            this.ItemForAddress,
            this.ItemForCity,
            this.ItemForPostalCode,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 90);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(224, 373);
            this.layoutControlGroup3.Text = "Contact Information:";
            // 
            // ItemForPhone
            // 
            this.ItemForPhone.Control = this.PhoneTextEdit;
            this.ItemForPhone.Location = new System.Drawing.Point(0, 0);
            this.ItemForPhone.Name = "ItemForPhone";
            this.ItemForPhone.Size = new System.Drawing.Size(200, 24);
            this.ItemForPhone.Text = "Phone";
            this.ItemForPhone.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForAddress
            // 
            this.ItemForAddress.Control = this.AddressTextEdit;
            this.ItemForAddress.Location = new System.Drawing.Point(0, 24);
            this.ItemForAddress.Name = "ItemForAddress";
            this.ItemForAddress.Size = new System.Drawing.Size(200, 24);
            this.ItemForAddress.Text = "Address";
            this.ItemForAddress.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForCity
            // 
            this.ItemForCity.Control = this.CityTextEdit;
            this.ItemForCity.Location = new System.Drawing.Point(0, 48);
            this.ItemForCity.Name = "ItemForCity";
            this.ItemForCity.Size = new System.Drawing.Size(200, 24);
            this.ItemForCity.Text = "City";
            this.ItemForCity.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForPostalCode
            // 
            this.ItemForPostalCode.Control = this.PostalCodeTextEdit;
            this.ItemForPostalCode.Location = new System.Drawing.Point(0, 72);
            this.ItemForPostalCode.MinSize = new System.Drawing.Size(114, 24);
            this.ItemForPostalCode.Name = "ItemForPostalCode";
            this.ItemForPostalCode.Size = new System.Drawing.Size(200, 31);
            this.ItemForPostalCode.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForPostalCode.Text = "Postal Code";
            this.ItemForPostalCode.TextSize = new System.Drawing.Size(57, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 103);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(200, 228);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForFirstName,
            this.ItemForLastName});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(224, 90);
            this.layoutControlGroup6.Text = "Name:";
            // 
            // ItemForFirstName
            // 
            this.ItemForFirstName.Control = this.FirstNameTextEdit;
            this.ItemForFirstName.Location = new System.Drawing.Point(0, 0);
            this.ItemForFirstName.Name = "ItemForFirstName";
            this.ItemForFirstName.Size = new System.Drawing.Size(200, 24);
            this.ItemForFirstName.Text = "Name";
            this.ItemForFirstName.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForLastName
            // 
            this.ItemForLastName.Control = this.LastNameTextEdit;
            this.ItemForLastName.Location = new System.Drawing.Point(0, 24);
            this.ItemForLastName.Name = "ItemForLastName";
            this.ItemForLastName.Size = new System.Drawing.Size(200, 24);
            this.ItemForLastName.Text = "Description";
            this.ItemForLastName.TextSize = new System.Drawing.Size(57, 13);
            // 
            // CompanyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CompanyUC";
            this.Size = new System.Drawing.Size(799, 464);
            this.Load += new System.EventHandler(this.CompUC_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyIDLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddressTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostalCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompanyID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPostalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        protected DevExpress.XtraEditors.SimpleButton btnAdd;
        protected DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit CustomerIDTextEdit;
        private DevExpress.XtraEditors.LookUpEdit CompanyIDLookUpEdit;
        private DevExpress.XtraEditors.TextEdit FirstNameTextEdit;
        private DevExpress.XtraEditors.TextEdit LastNameTextEdit;
        private DevExpress.XtraEditors.TextEdit PhoneTextEdit;
        private DevExpress.XtraEditors.TextEdit AddressTextEdit;
        private DevExpress.XtraEditors.TextEdit CityTextEdit;
        private DevExpress.XtraEditors.TextEdit PostalCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCustomerID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCompanyID;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPhone;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPostalCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFirstName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastName;
        public System.Windows.Forms.BindingSource CompanyBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        protected DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
