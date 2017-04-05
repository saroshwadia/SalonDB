namespace SalonDB.Win.Forms
{
    partial class SelectCustomerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OKSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.CancelSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.appointmentCollection1 = new BusinessObjects.AppointmentCollection();
            this.customerCollection1 = new BusinessObjects.CustomerCollection();
            this.CustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.FirstNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LastNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PhoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.EmailTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CustomerSearchTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.AppointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.staffCollection1 = new BusinessObjects.StaffCollection();
            this.StaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.CurrentDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.CurrentDateLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.ShowAllDatesCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSearchTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowAllDatesCheckEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // OKSimpleButton
            // 
            this.OKSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKSimpleButton.Location = new System.Drawing.Point(764, 480);
            this.OKSimpleButton.Name = "OKSimpleButton";
            this.OKSimpleButton.Size = new System.Drawing.Size(75, 23);
            this.OKSimpleButton.TabIndex = 0;
            this.OKSimpleButton.Text = "OK";
            this.OKSimpleButton.Click += new System.EventHandler(this.OKSimpleButton_Click);
            // 
            // CancelSimpleButton
            // 
            this.CancelSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelSimpleButton.Location = new System.Drawing.Point(845, 480);
            this.CancelSimpleButton.Name = "CancelSimpleButton";
            this.CancelSimpleButton.Size = new System.Drawing.Size(75, 23);
            this.CancelSimpleButton.TabIndex = 1;
            this.CancelSimpleButton.Text = "Cancel";
            this.CancelSimpleButton.Click += new System.EventHandler(this.CancelSimpleButton_Click);
            // 
            // appointmentCollection1
            // 
            this.appointmentCollection1.AllowDelete = true;
            this.appointmentCollection1.AllowEdit = true;
            this.appointmentCollection1.AllowNew = true;
            this.appointmentCollection1.EnableHierarchicalBinding = true;
            this.appointmentCollection1.Filter = null;
            // 
            // customerCollection1
            // 
            this.customerCollection1.AllowDelete = true;
            this.customerCollection1.AllowEdit = true;
            this.customerCollection1.AllowNew = true;
            this.customerCollection1.EnableHierarchicalBinding = true;
            this.customerCollection1.Filter = null;
            // 
            // CustomerBindingSource
            // 
            this.CustomerBindingSource.DataSource = this.customerCollection1;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl2.Controls.Add(this.FirstNameTextEdit);
            this.layoutControl2.Controls.Add(this.LastNameTextEdit);
            this.layoutControl2.Controls.Add(this.PhoneTextEdit);
            this.layoutControl2.Controls.Add(this.EmailTextEdit);
            this.layoutControl2.Controls.Add(this.CustomerSearchTextEdit);
            this.layoutControl2.Location = new System.Drawing.Point(18, 332);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(739, 32, 250, 350);
            this.layoutControl2.Root = this.layoutControlGroup4;
            this.layoutControl2.Size = new System.Drawing.Size(902, 142);
            this.layoutControl2.TabIndex = 7;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // FirstNameTextEdit
            // 
            this.FirstNameTextEdit.Enabled = false;
            this.FirstNameTextEdit.Location = new System.Drawing.Point(113, 66);
            this.FirstNameTextEdit.Name = "FirstNameTextEdit";
            this.FirstNameTextEdit.Size = new System.Drawing.Size(335, 20);
            this.FirstNameTextEdit.StyleController = this.layoutControl2;
            this.FirstNameTextEdit.TabIndex = 4;
            // 
            // LastNameTextEdit
            // 
            this.LastNameTextEdit.Enabled = false;
            this.LastNameTextEdit.Location = new System.Drawing.Point(541, 66);
            this.LastNameTextEdit.Name = "LastNameTextEdit";
            this.LastNameTextEdit.Size = new System.Drawing.Size(337, 20);
            this.LastNameTextEdit.StyleController = this.layoutControl2;
            this.LastNameTextEdit.TabIndex = 4;
            // 
            // PhoneTextEdit
            // 
            this.PhoneTextEdit.Enabled = false;
            this.PhoneTextEdit.Location = new System.Drawing.Point(113, 90);
            this.PhoneTextEdit.Name = "PhoneTextEdit";
            this.PhoneTextEdit.Size = new System.Drawing.Size(335, 20);
            this.PhoneTextEdit.StyleController = this.layoutControl2;
            this.PhoneTextEdit.TabIndex = 4;
            // 
            // EmailTextEdit
            // 
            this.EmailTextEdit.Enabled = false;
            this.EmailTextEdit.Location = new System.Drawing.Point(541, 90);
            this.EmailTextEdit.Name = "EmailTextEdit";
            this.EmailTextEdit.Size = new System.Drawing.Size(337, 20);
            this.EmailTextEdit.StyleController = this.layoutControl2;
            this.EmailTextEdit.TabIndex = 4;
            // 
            // CustomerSearchTextEdit
            // 
            this.CustomerSearchTextEdit.Location = new System.Drawing.Point(101, 12);
            this.CustomerSearchTextEdit.Name = "CustomerSearchTextEdit";
            this.CustomerSearchTextEdit.Size = new System.Drawing.Size(789, 20);
            this.CustomerSearchTextEdit.StyleController = this.layoutControl2;
            this.CustomerSearchTextEdit.TabIndex = 4;
            this.CustomerSearchTextEdit.EditValueChanged += new System.EventHandler(this.CustomerSearchTextEdit_EditValueChanged);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup5,
            this.layoutControlItem5});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "Root";
            this.layoutControlGroup4.Size = new System.Drawing.Size(902, 142);
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlGroup5.Name = "layoutControlGroup3";
            this.layoutControlGroup5.Size = new System.Drawing.Size(882, 98);
            this.layoutControlGroup5.Text = "Customer Details:";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.FirstNameTextEdit;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem1";
            this.layoutControlItem6.Size = new System.Drawing.Size(428, 24);
            this.layoutControlItem6.Text = "First Name:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.LastNameTextEdit;
            this.layoutControlItem2.CustomizationFormText = "Name:";
            this.layoutControlItem2.Location = new System.Drawing.Point(428, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(430, 24);
            this.layoutControlItem2.Text = "Last Name:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.PhoneTextEdit;
            this.layoutControlItem3.CustomizationFormText = "First Name:";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(428, 32);
            this.layoutControlItem3.Text = "Phone:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.EmailTextEdit;
            this.layoutControlItem4.CustomizationFormText = "First Name:";
            this.layoutControlItem4.Location = new System.Drawing.Point(428, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(430, 32);
            this.layoutControlItem4.Text = "Email:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.CustomerSearchTextEdit;
            this.layoutControlItem5.CustomizationFormText = "First Name:";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(882, 24);
            this.layoutControlItem5.Text = "Customer Search:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(86, 13);
            // 
            // AppointmentBindingSource
            // 
            this.AppointmentBindingSource.DataSource = this.appointmentCollection1;
            // 
            // staffCollection1
            // 
            this.staffCollection1.AllowDelete = true;
            this.staffCollection1.AllowEdit = true;
            this.staffCollection1.AllowNew = true;
            this.staffCollection1.EnableHierarchicalBinding = true;
            this.staffCollection1.Filter = null;
            // 
            // StaffBindingSource
            // 
            this.StaffBindingSource.DataSource = this.staffCollection1;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.AppointmentBindingSource;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(873, 244);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2});
            this.gridControl1.Size = new System.Drawing.Size(47, 62);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSubject,
            this.colDescription,
            this.colStartTime,
            this.colEndTime,
            this.colStaffID,
            this.colCustomerID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.RowHeight = 28;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseMove);
            // 
            // colSubject
            // 
            this.colSubject.FieldName = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 0;
            this.colSubject.Width = 160;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 212;
            // 
            // colStartTime
            // 
            this.colStartTime.ColumnEdit = this.repositoryItemDateEdit1;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 2;
            this.colStartTime.Width = 150;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss tt";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "yyyy-MM-dd hh:mm:ss tt";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "yyyy-MM-dd hh:mm:ss tt";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // colEndTime
            // 
            this.colEndTime.ColumnEdit = this.repositoryItemDateEdit1;
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 3;
            this.colEndTime.Width = 150;
            // 
            // colStaffID
            // 
            this.colStaffID.Caption = "Staff";
            this.colStaffID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colStaffID.FieldName = "StaffID";
            this.colStaffID.Name = "colStaffID";
            this.colStaffID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colStaffID.Visible = true;
            this.colStaffID.VisibleIndex = 4;
            this.colStaffID.Width = 99;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FirstName", "First Name", 61, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LastName", "Last Name", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DataSource = this.StaffBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "FirstName";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "StaffID";
            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "Customer";
            this.colCustomerID.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCustomerID.Visible = true;
            this.colCustomerID.VisibleIndex = 5;
            this.colCustomerID.Width = 100;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit2.DataSource = this.CustomerBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "Name";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.ValueMember = "CustomerID";
            // 
            // CurrentDateDateEdit
            // 
            this.CurrentDateDateEdit.EditValue = null;
            this.CurrentDateDateEdit.Location = new System.Drawing.Point(219, 93);
            this.CurrentDateDateEdit.Name = "CurrentDateDateEdit";
            this.CurrentDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CurrentDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CurrentDateDateEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CurrentDateDateEdit.Size = new System.Drawing.Size(247, 20);
            this.CurrentDateDateEdit.TabIndex = 9;
            this.CurrentDateDateEdit.EditValueChanged += new System.EventHandler(this.CurrentDateDateEdit_EditValueChanged);
            // 
            // CurrentDateLabelControl
            // 
            this.CurrentDateLabelControl.Location = new System.Drawing.Point(18, 25);
            this.CurrentDateLabelControl.Name = "CurrentDateLabelControl";
            this.CurrentDateLabelControl.Size = new System.Drawing.Size(67, 13);
            this.CurrentDateLabelControl.TabIndex = 10;
            this.CurrentDateLabelControl.Text = "Current Date:";
            // 
            // ShowAllDatesCheckEdit
            // 
            this.ShowAllDatesCheckEdit.Location = new System.Drawing.Point(353, 22);
            this.ShowAllDatesCheckEdit.Name = "ShowAllDatesCheckEdit";
            this.ShowAllDatesCheckEdit.Properties.Caption = "Show All Dates";
            this.ShowAllDatesCheckEdit.Size = new System.Drawing.Size(101, 19);
            this.ShowAllDatesCheckEdit.TabIndex = 11;
            this.ShowAllDatesCheckEdit.CheckedChanged += new System.EventHandler(this.ShowAllDatesCheckEdit_CheckedChanged);
            // 
            // SelectCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 515);
            this.Controls.Add(this.ShowAllDatesCheckEdit);
            this.Controls.Add(this.CurrentDateLabelControl);
            this.Controls.Add(this.CurrentDateDateEdit);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.layoutControl2);
            this.Controls.Add(this.CancelSimpleButton);
            this.Controls.Add(this.OKSimpleButton);
            this.Name = "SelectCustomerForm";
            this.Text = "Select Customer";
            this.Load += new System.EventHandler(this.SelectCustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FirstNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSearchTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowAllDatesCheckEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton OKSimpleButton;
        private DevExpress.XtraEditors.SimpleButton CancelSimpleButton;
        private BusinessObjects.AppointmentCollection appointmentCollection1;
        private BusinessObjects.CustomerCollection customerCollection1;
        private System.Windows.Forms.BindingSource CustomerBindingSource;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.TextEdit FirstNameTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit LastNameTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit PhoneTextEdit;
        private DevExpress.XtraEditors.TextEdit EmailTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit CustomerSearchTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.BindingSource AppointmentBindingSource;
        private BusinessObjects.StaffCollection staffCollection1;
        private System.Windows.Forms.BindingSource StaffBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffID;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.DateEdit CurrentDateDateEdit;
        private DevExpress.XtraEditors.LabelControl CurrentDateLabelControl;
        private DevExpress.XtraEditors.CheckEdit ShowAllDatesCheckEdit;
    }
}