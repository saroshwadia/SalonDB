using DevExpress.XtraScheduler.UI;
namespace SalonDB.Win
{
    partial class CustomAppointmentForm
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomAppointmentForm));
            this.lblSubject = new DevExpress.XtraEditors.LabelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.tbSubject = new DevExpress.XtraEditors.TextEdit();
            this.lblLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.lblEndTime = new DevExpress.XtraEditors.LabelControl();
            this.chkAllDay = new DevExpress.XtraEditors.CheckEdit();
            this.lblShowTimeAs = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnRecurrence = new DevExpress.XtraEditors.SimpleButton();
            this.edtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.edtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.chkReminder = new DevExpress.XtraEditors.CheckEdit();
            this.tbDescription = new DevExpress.XtraEditors.MemoEdit();
            this.lblResource = new DevExpress.XtraEditors.LabelControl();
            this.tbLocation = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.NewCustomersimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.cbReminder = new DevExpress.XtraScheduler.UI.DurationEdit();
            this.edtLabel = new DevExpress.XtraScheduler.UI.AppointmentLabelEdit();
            this.edtResource = new DevExpress.XtraScheduler.UI.AppointmentResourceEdit();
            this.edtResources = new DevExpress.XtraScheduler.UI.AppointmentResourcesEdit();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.tbProgress = new DevExpress.XtraEditors.TrackBarControl();
            this.lblPercentCompleteValue = new DevExpress.XtraEditors.LabelControl();
            this.lblPercentComplete = new DevExpress.XtraEditors.LabelControl();
            this.edtStartTime = new DevExpress.XtraScheduler.UI.SchedulerTimeEdit();
            this.edtEndTime = new DevExpress.XtraScheduler.UI.SchedulerTimeEdit();
            this.edtShowTimeAs = new DevExpress.XtraScheduler.UI.AppointmentStatusEdit();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.CustomerLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.CustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StoreLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.TransactionDetailServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReminder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbReminder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.ResourcesCheckedListBoxControl)).BeginInit();
            this.progressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowTimeAs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDetailServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubject
            // 
            resources.ApplyResources(this.lblSubject, "lblSubject");
            this.lblSubject.Name = "lblSubject";
            // 
            // lblLocation
            // 
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Name = "lblLocation";
            // 
            // tbSubject
            // 
            resources.ApplyResources(this.tbSubject, "tbSubject");
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Properties.AccessibleName = resources.GetString("tbSubject.Properties.AccessibleName");
            // 
            // lblLabel
            // 
            resources.ApplyResources(this.lblLabel, "lblLabel");
            this.lblLabel.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lblLabel.Appearance.BackColor")));
            this.lblLabel.Appearance.Options.UseBackColor = true;
            this.lblLabel.Name = "lblLabel";
            // 
            // lblStartTime
            // 
            resources.ApplyResources(this.lblStartTime, "lblStartTime");
            this.lblStartTime.Name = "lblStartTime";
            // 
            // lblEndTime
            // 
            resources.ApplyResources(this.lblEndTime, "lblEndTime");
            this.lblEndTime.Name = "lblEndTime";
            // 
            // chkAllDay
            // 
            resources.ApplyResources(this.chkAllDay, "chkAllDay");
            this.chkAllDay.Name = "chkAllDay";
            this.chkAllDay.Properties.AccessibleName = resources.GetString("chkAllDay.Properties.AccessibleName");
            this.chkAllDay.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.chkAllDay.Properties.AutoWidth = true;
            this.chkAllDay.Properties.Caption = resources.GetString("chkAllDay.Properties.Caption");
            // 
            // lblShowTimeAs
            // 
            resources.ApplyResources(this.lblShowTimeAs, "lblShowTimeAs");
            this.lblShowTimeAs.Name = "lblShowTimeAs";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.OnBtnOkClick);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.CausesValidation = false;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.OnBtnDeleteClick);
            // 
            // btnRecurrence
            // 
            resources.ApplyResources(this.btnRecurrence, "btnRecurrence");
            this.btnRecurrence.Name = "btnRecurrence";
            this.btnRecurrence.Click += new System.EventHandler(this.OnBtnRecurrenceClick);
            // 
            // edtStartDate
            // 
            resources.ApplyResources(this.edtStartDate, "edtStartDate");
            this.edtStartDate.Name = "edtStartDate";
            this.edtStartDate.Properties.AccessibleName = resources.GetString("edtStartDate.Properties.AccessibleName");
            this.edtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtStartDate.Properties.Buttons"))))});
            this.edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtStartDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            this.edtStartDate.EditValueChanged += new System.EventHandler(this.edtStartDate_EditValueChanged);
            // 
            // edtEndDate
            // 
            resources.ApplyResources(this.edtEndDate, "edtEndDate");
            this.edtEndDate.Name = "edtEndDate";
            this.edtEndDate.Properties.AccessibleName = resources.GetString("edtEndDate.Properties.AccessibleName");
            this.edtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtEndDate.Properties.Buttons"))))});
            this.edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtEndDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            // 
            // chkReminder
            // 
            resources.ApplyResources(this.chkReminder, "chkReminder");
            this.chkReminder.Name = "chkReminder";
            this.chkReminder.Properties.AutoWidth = true;
            this.chkReminder.Properties.Caption = resources.GetString("chkReminder.Properties.Caption");
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Properties.AccessibleName = resources.GetString("tbDescription.Properties.AccessibleName");
            this.tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            // 
            // lblResource
            // 
            resources.ApplyResources(this.lblResource, "lblResource");
            this.lblResource.Name = "lblResource";
            // 
            // tbLocation
            // 
            resources.ApplyResources(this.tbLocation, "tbLocation");
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Properties.AccessibleName = resources.GetString("tbLocation.Properties.AccessibleName");
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel1.Controls.Add(this.NewCustomersimpleButton);
            this.panel1.Controls.Add(this.lblLabel);
            this.panel1.Controls.Add(this.cbReminder);
            this.panel1.Controls.Add(this.chkAllDay);
            this.panel1.Controls.Add(this.edtLabel);
            this.panel1.Controls.Add(this.chkReminder);
            this.panel1.Controls.Add(this.tbLocation);
            this.panel1.Name = "panel1";
            // 
            // NewCustomersimpleButton
            // 
            resources.ApplyResources(this.NewCustomersimpleButton, "NewCustomersimpleButton");
            this.NewCustomersimpleButton.Name = "NewCustomersimpleButton";
            this.NewCustomersimpleButton.Click += new System.EventHandler(this.NewCustomersimpleButton_Click);
            // 
            // cbReminder
            // 
            resources.ApplyResources(this.cbReminder, "cbReminder");
            this.cbReminder.Name = "cbReminder";
            this.cbReminder.Properties.AccessibleName = resources.GetString("cbReminder.Properties.AccessibleName");
            this.cbReminder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbReminder.Properties.Buttons"))))});
            this.cbReminder.Properties.DisabledStateText = "";
            this.cbReminder.Properties.ShowEmptyItem = false;
            // 
            // edtLabel
            // 
            resources.ApplyResources(this.edtLabel, "edtLabel");
            this.edtLabel.Name = "edtLabel";
            this.edtLabel.Properties.AccessibleName = resources.GetString("edtLabel.Properties.AccessibleName");
            this.edtLabel.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.edtLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtLabel.Properties.Buttons"))))});
            // 
            // edtResource
            // 
            resources.ApplyResources(this.edtResource, "edtResource");
            this.edtResource.Name = "edtResource";
            this.edtResource.Properties.AccessibleName = resources.GetString("edtResource.Properties.AccessibleName");
            this.edtResource.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.edtResource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtResource.Properties.Buttons"))))});
            // 
            // edtResources
            // 
            resources.ApplyResources(this.edtResources, "edtResources");
            this.edtResources.Name = "edtResources";
            this.edtResources.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtResources.Properties.Buttons"))))});
            // 
            // 
            // 
            this.edtResources.ResourcesCheckedListBoxControl.Location = ((System.Drawing.Point)(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Location")));
            this.edtResources.ResourcesCheckedListBoxControl.Name = "";
            this.edtResources.ResourcesCheckedListBoxControl.TabIndex = ((int)(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.TabIndex")));
            // 
            // progressPanel
            // 
            resources.ApplyResources(this.progressPanel, "progressPanel");
            this.progressPanel.Controls.Add(this.tbProgress);
            this.progressPanel.Controls.Add(this.lblPercentCompleteValue);
            this.progressPanel.Controls.Add(this.lblPercentComplete);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.TabStop = true;
            // 
            // tbProgress
            // 
            resources.ApplyResources(this.tbProgress, "tbProgress");
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.Properties.AutoSize = false;
            this.tbProgress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tbProgress.Properties.Maximum = 100;
            this.tbProgress.Properties.ShowValueToolTip = true;
            this.tbProgress.Properties.TickFrequency = 10;
            // 
            // lblPercentCompleteValue
            // 
            resources.ApplyResources(this.lblPercentCompleteValue, "lblPercentCompleteValue");
            this.lblPercentCompleteValue.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lblPercentCompleteValue.Appearance.BackColor")));
            this.lblPercentCompleteValue.Appearance.Options.UseBackColor = true;
            this.lblPercentCompleteValue.Name = "lblPercentCompleteValue";
            // 
            // lblPercentComplete
            // 
            resources.ApplyResources(this.lblPercentComplete, "lblPercentComplete");
            this.lblPercentComplete.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lblPercentComplete.Appearance.BackColor")));
            this.lblPercentComplete.Appearance.Options.UseBackColor = true;
            this.lblPercentComplete.Name = "lblPercentComplete";
            // 
            // edtStartTime
            // 
            resources.ApplyResources(this.edtStartTime, "edtStartTime");
            this.edtStartTime.Name = "edtStartTime";
            this.edtStartTime.Properties.AccessibleName = resources.GetString("edtStartTime.Properties.AccessibleName");
            this.edtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtStartTime.EditValueChanged += new System.EventHandler(this.edtStartTime_EditValueChanged);
            // 
            // edtEndTime
            // 
            resources.ApplyResources(this.edtEndTime, "edtEndTime");
            this.edtEndTime.Name = "edtEndTime";
            this.edtEndTime.Properties.AccessibleName = resources.GetString("edtEndTime.Properties.AccessibleName");
            this.edtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // edtShowTimeAs
            // 
            resources.ApplyResources(this.edtShowTimeAs, "edtShowTimeAs");
            this.edtShowTimeAs.Name = "edtShowTimeAs";
            this.edtShowTimeAs.Properties.AccessibleName = resources.GetString("edtShowTimeAs.Properties.AccessibleName");
            this.edtShowTimeAs.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.edtShowTimeAs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtShowTimeAs.Properties.Buttons"))))});
            // 
            // lblCustomer
            // 
            resources.ApplyResources(this.lblCustomer, "lblCustomer");
            this.lblCustomer.Name = "lblCustomer";
            // 
            // CustomerLookUpEdit
            // 
            resources.ApplyResources(this.CustomerLookUpEdit, "CustomerLookUpEdit");
            this.CustomerLookUpEdit.Name = "CustomerLookUpEdit";
            this.CustomerLookUpEdit.Properties.AccessibleName = resources.GetString("CustomerLookUpEdit.Properties.AccessibleName");
            this.CustomerLookUpEdit.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.CustomerLookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.CustomerLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("CustomerLookUpEdit.Properties.Buttons"))))});
            this.CustomerLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("CustomerLookUpEdit.Properties.Columns"), ((int)(resources.GetObject("CustomerLookUpEdit.Properties.Columns1"))), resources.GetString("CustomerLookUpEdit.Properties.Columns2"))});
            this.CustomerLookUpEdit.Properties.DataSource = this.CustomerBindingSource;
            this.CustomerLookUpEdit.Properties.NullText = resources.GetString("CustomerLookUpEdit.Properties.NullText");
            this.CustomerLookUpEdit.Properties.PopupSizeable = false;
            this.CustomerLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.CustomerLookUpEdit.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.CustomerLookUpEdit_ProcessNewValue);
            // 
            // StoreLookUpEdit
            // 
            resources.ApplyResources(this.StoreLookUpEdit, "StoreLookUpEdit");
            this.StoreLookUpEdit.Name = "StoreLookUpEdit";
            this.StoreLookUpEdit.Properties.AccessibleName = resources.GetString("StoreLookUpEdit.Properties.AccessibleName");
            this.StoreLookUpEdit.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.StoreLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("StoreLookUpEdit.Properties.Buttons"))))});
            this.StoreLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("StoreLookUpEdit.Properties.Columns"), ((int)(resources.GetObject("StoreLookUpEdit.Properties.Columns1"))), resources.GetString("StoreLookUpEdit.Properties.Columns2"))});
            this.StoreLookUpEdit.Properties.DataSource = this.StoreBindingSource;
            this.StoreLookUpEdit.Properties.NullText = resources.GetString("StoreLookUpEdit.Properties.NullText");
            this.StoreLookUpEdit.Properties.PopupSizeable = false;
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.DataSource = this.TransactionDetailServiceBindingSource;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2});
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colPrice,
            this.colDuration});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.RowHeight = 28;
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gridView1_RowDeleted);
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            // 
            // repositoryItemLookUpEdit1
            // 
            resources.ApplyResources(this.repositoryItemLookUpEdit1, "repositoryItemLookUpEdit1");
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemLookUpEdit1.Buttons"))))});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("repositoryItemLookUpEdit1.Columns"), ((int)(resources.GetObject("repositoryItemLookUpEdit1.Columns1"))), resources.GetString("repositoryItemLookUpEdit1.Columns2")),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("repositoryItemLookUpEdit1.Columns3"), ((int)(resources.GetObject("repositoryItemLookUpEdit1.Columns4"))), resources.GetString("repositoryItemLookUpEdit1.Columns5"))});
            this.repositoryItemLookUpEdit1.DataSource = this.ServiceBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "Name";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemLookUpEdit1.ValueMember = "Name";
            this.repositoryItemLookUpEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemLookUpEdit1_EditValueChanged);
            // 
            // colPrice
            // 
            resources.ApplyResources(this.colPrice, "colPrice");
            this.colPrice.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colPrice.FieldName = "UnitPrice";
            this.colPrice.Name = "colPrice";
            this.colPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colPrice.Summary"))), resources.GetString("colPrice.Summary1"), resources.GetString("colPrice.Summary2"))});
            // 
            // repositoryItemSpinEdit1
            // 
            resources.ApplyResources(this.repositoryItemSpinEdit1, "repositoryItemSpinEdit1");
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemSpinEdit1.Buttons"))))});
            this.repositoryItemSpinEdit1.DisplayFormat.FormatString = "f2";
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.EditFormat.FormatString = "f2";
            this.repositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // colDuration
            // 
            resources.ApplyResources(this.colDuration, "colDuration");
            this.colDuration.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colDuration.FieldName = "Duration";
            this.colDuration.Name = "colDuration";
            this.colDuration.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("colDuration.Summary"))), resources.GetString("colDuration.Summary1"), resources.GetString("colDuration.Summary2"))});
            // 
            // repositoryItemSpinEdit2
            // 
            resources.ApplyResources(this.repositoryItemSpinEdit2, "repositoryItemSpinEdit2");
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemSpinEdit2.Buttons"))))});
            this.repositoryItemSpinEdit2.DisplayFormat.FormatString = "f0";
            this.repositoryItemSpinEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit2.EditFormat.FormatString = "f0";
            this.repositoryItemSpinEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            this.repositoryItemSpinEdit2.EditValueChanged += new System.EventHandler(this.repositoryItemSpinEdit2_EditValueChanged);
            // 
            // CustomAppointmentForm
            // 
            this.AcceptButton = this.btnOk;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.StoreLookUpEdit);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.edtResource);
            this.Controls.Add(this.edtResources);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.lblResource);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.edtStartTime);
            this.Controls.Add(this.edtStartDate);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblShowTimeAs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRecurrence);
            this.Controls.Add(this.edtEndDate);
            this.Controls.Add(this.edtEndTime);
            this.Controls.Add(this.edtShowTimeAs);
            this.Controls.Add(this.CustomerLookUpEdit);
            this.Name = "CustomAppointmentForm";
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.OnAppointmentFormActivated);
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReminder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbReminder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.ResourcesCheckedListBoxControl)).EndInit();
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShowTimeAs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDetailServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        protected DevExpress.XtraEditors.LabelControl lblSubject;
        protected DevExpress.XtraEditors.LabelControl lblLocation;
        protected DevExpress.XtraEditors.LabelControl lblLabel;
        protected DevExpress.XtraEditors.LabelControl lblStartTime;
        protected DevExpress.XtraEditors.LabelControl lblEndTime;
        protected DevExpress.XtraEditors.LabelControl lblShowTimeAs;
        protected DevExpress.XtraEditors.CheckEdit chkAllDay;
        protected DevExpress.XtraEditors.SimpleButton btnOk;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        protected DevExpress.XtraEditors.SimpleButton btnDelete;
        protected DevExpress.XtraEditors.SimpleButton btnRecurrence;
        protected DevExpress.XtraEditors.DateEdit edtStartDate;
        protected DevExpress.XtraEditors.DateEdit edtEndDate;
        protected DevExpress.XtraScheduler.UI.SchedulerTimeEdit edtStartTime;
        protected DevExpress.XtraScheduler.UI.SchedulerTimeEdit edtEndTime;
        protected DevExpress.XtraScheduler.UI.AppointmentLabelEdit edtLabel;
        protected DevExpress.XtraScheduler.UI.AppointmentStatusEdit edtShowTimeAs;
        protected DevExpress.XtraEditors.TextEdit tbSubject;
        protected DevExpress.XtraScheduler.UI.AppointmentResourceEdit edtResource;
        protected DevExpress.XtraEditors.LabelControl lblResource;
        protected DevExpress.XtraScheduler.UI.AppointmentResourcesEdit edtResources;
        protected DevExpress.XtraEditors.CheckEdit chkReminder;
        protected DevExpress.XtraEditors.MemoEdit tbDescription;
        protected DevExpress.XtraScheduler.UI.DurationEdit cbReminder;
        private System.ComponentModel.IContainer components = null;
        protected DevExpress.XtraEditors.TextEdit tbLocation;
        protected DevExpress.XtraEditors.PanelControl panel1;
        protected System.Windows.Forms.Panel progressPanel;
        protected DevExpress.XtraEditors.TrackBarControl tbProgress;
        protected DevExpress.XtraEditors.LabelControl lblPercentComplete;
        protected DevExpress.XtraEditors.LabelControl lblPercentCompleteValue;
        protected DevExpress.XtraEditors.LabelControl lblCustomer;
        private DevExpress.XtraEditors.LookUpEdit CustomerLookUpEdit;
        private System.Windows.Forms.BindingSource CustomerBindingSource;
        private System.Windows.Forms.BindingSource StoreBindingSource;
        private DevExpress.XtraEditors.LookUpEdit StoreLookUpEdit;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource ServiceBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private System.Windows.Forms.BindingSource TransactionDetailServiceBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colDuration;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraEditors.SimpleButton NewCustomersimpleButton;
    }
}
