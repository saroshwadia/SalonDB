using System;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.UI;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Native;
using DevExpress.Utils.Internal;
using System.Collections.Generic;
using DevExpress.XtraScheduler.Internal;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using SalonDB.Win.Forms;

namespace SalonDB.Win
{
    public partial class CustomAppointmentForm : BaseForm, IDXManagerPopupMenu
    {
        private bool _AllowMultiResouces = false;
        private BusinessObjects.Company _CompanyEnt;
        private BusinessObjects.CustomerCollection _CustomerCol;
        private BusinessObjects.StoreCollection _StoreCol;
        private BusinessObjects.ServiceCollection _ServiceCol;
        private BusinessObjects.TransactionDetailServiceCollection _TransactionDetailServiceCol;
        //private BusinessObjects.Transaction _TransactionEnt;
        private Guid _AppointmentID;
        private bool _AutoCalEndDateTime = false;
        private bool _AppointmentPaid = false;

        #region Fields
        bool openRecurrenceForm;
        readonly ISchedulerStorage storage;
        readonly SchedulerControl control;
        Icon recurringIcon;
        Icon normalIcon;
        readonly AppointmentFormController controller;
        IDXMenuManager menuManager;
        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CustomAppointmentForm()
        {
            InitializeComponent();
        }
        public CustomAppointmentForm(SchedulerControl control, Appointment apt)
                    : this(control, apt, false, null)
        {
        }
        public CustomAppointmentForm(SchedulerControl control, Appointment apt, bool openRecurrenceForm, BusinessObjects.Company companyEnt)
        {
            Guard.ArgumentNotNull(control, "control");
            Guard.ArgumentNotNull(control.Storage, "control.Storage");
            Guard.ArgumentNotNull(apt, "apt");

            _CompanyEnt = companyEnt;

            //if (apt.Id == null)
            //{
            //    apt.SetId(Guid.NewGuid());
            //}

            if (apt.Id != null)
            {
                _AppointmentID = (Guid)apt.Id;
            }

            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = CreateController(control, apt);
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            SetupPredefinedConstraints();

            LoadIcons();

            this.control = control;
            this.storage = control.Storage;

            this.edtShowTimeAs.Storage = this.storage;
            this.edtLabel.Storage = storage;
            this.edtResource.SchedulerControl = control;
            this.edtResource.Storage = storage;
            this.edtResources.SchedulerControl = control;

            SubscribeControllerEvents(Controller);
            SubscribeEditorsEvents();
            BindControllerToControls();

        }
        #region Properties
        protected override FormShowMode ShowMode { get { return DevExpress.XtraEditors.FormShowMode.AfterInitialization; } }
        public IDXMenuManager MenuManager { get { return menuManager; } private set { menuManager = value; } }
        protected internal AppointmentFormController Controller { get { return controller; } }
        protected internal SchedulerControl Control { get { return control; } }
        protected internal ISchedulerStorage Storage { get { return storage; } }
        protected internal bool IsNewAppointment { get { return controller != null ? controller.IsNewAppointment : true; } }
        protected internal Icon RecurringIcon { get { return recurringIcon; } }
        protected internal Icon NormalIcon { get { return normalIcon; } }
        protected internal bool OpenRecurrenceForm { get { return openRecurrenceForm; } }
        public bool ReadOnly
        {
            get { return Controller != null && Controller.ReadOnly; }
            set
            {
                if (Controller.ReadOnly == value)
                    return;
                Controller.ReadOnly = value;
            }
        }
        #endregion

        public virtual void LoadFormData(Appointment appointment)
        {
            this.CustomerLookUpEdit.EditValue = (Controller as CustomAppointmentFormController).CustomerID;
            this.StoreLookUpEdit.EditValue = (Controller as CustomAppointmentFormController).StoreID;
        }
        public virtual bool SaveFormData(Appointment appointment)
        {
            (Controller as CustomAppointmentFormController).CustomerID = (Guid)this.CustomerLookUpEdit.EditValue;
            (Controller as CustomAppointmentFormController).StoreID = (Guid)this.StoreLookUpEdit.EditValue;
            return true;
        }
        public virtual bool IsAppointmentChanged(Appointment appointment)
        {
            return false;
        }
        public virtual void SetMenuManager(DevExpress.Utils.Menu.IDXMenuManager menuManager)
        {
            MenuManagerUtils.SetMenuManager(Controls, menuManager);
            this.menuManager = menuManager;
        }

        protected internal virtual void SetupPredefinedConstraints()
        {
            this.tbProgress.Properties.Minimum = AppointmentProcessValues.Min;
            this.tbProgress.Properties.Maximum = AppointmentProcessValues.Max;
            this.tbProgress.Properties.SmallChange = AppointmentProcessValues.Step;
            this.edtResources.Visible = true;
        }
        protected virtual void BindControllerToControls()
        {
            BindControllerToIcon();
            BindProperties(this.tbSubject, "Text", "Subject");
            BindProperties(this.tbLocation, "Text", "Location");
            BindProperties(this.tbDescription, "Text", "Description");
            BindProperties(this.edtShowTimeAs, "Status", "Status");
            BindProperties(this.edtStartDate, "EditValue", "DisplayStartDate");
            BindProperties(this.edtStartDate, "Enabled", "IsDateTimeEditable");
            BindProperties(this.edtStartTime, "EditValue", "DisplayStartTime");
            BindProperties(this.edtStartTime, "Visible", "IsTimeVisible");
            BindProperties(this.edtStartTime, "Enabled", "IsTimeVisible");
            BindProperties(this.edtEndDate, "EditValue", "DisplayEndDate", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndDate, "Enabled", "IsDateTimeEditable", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "EditValue", "DisplayEndTime", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "Visible", "IsTimeVisible", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "Enabled", "IsTimeVisible", DataSourceUpdateMode.Never);
            BindProperties(this.chkAllDay, "Checked", "AllDay");
            BindProperties(this.chkAllDay, "Enabled", "IsDateTimeEditable");

            BindProperties(this.edtResource, "ResourceId", "ResourceId");
            BindProperties(this.edtResource, "Enabled", "CanEditResource");
            BindToBoolPropertyAndInvert(this.edtResource, "Visible", "ResourceSharing");

            BindProperties(this.edtResources, "ResourceIds", "ResourceIds");
            BindProperties(this.edtResources, "Visible", "ResourceSharing");
            BindProperties(this.edtResources, "Enabled", "CanEditResource");
            BindProperties(this.lblResource, "Enabled", "CanEditResource");

            BindProperties(this.edtLabel, "Label", "Label");
            BindProperties(this.chkReminder, "Enabled", "ReminderVisible");
            BindProperties(this.chkReminder, "Visible", "ReminderVisible");
            BindProperties(this.chkReminder, "Checked", "HasReminder");
            BindProperties(this.cbReminder, "Enabled", "HasReminder");
            BindProperties(this.cbReminder, "Visible", "ReminderVisible");
            BindProperties(this.cbReminder, "Duration", "ReminderTimeBeforeStart");

            BindProperties(this.tbProgress, "Value", "PercentComplete");
            BindProperties(this.lblPercentCompleteValue, "Text", "PercentComplete", ObjectToStringConverter);
            BindProperties(this.progressPanel, "Visible", "ShouldEditTaskProgress");
            BindToBoolPropertyAndInvert(this.btnOk, "Enabled", "ReadOnly");
            BindToBoolPropertyAndInvert(this.btnRecurrence, "Enabled", "ReadOnly");
            BindProperties(this.btnDelete, "Enabled", "CanDeleteAppointment");
            BindProperties(this.btnRecurrence, "Visible", "ShouldShowRecurrenceButton");
        }
        protected virtual void BindControllerToIcon()
        {
            Binding binding = new Binding("Icon", Controller, "AppointmentType");
            binding.Format += AppointmentTypeToIconConverter;
            DataBindings.Add(binding);
        }
        protected virtual void ObjectToStringConverter(object o, ConvertEventArgs e)
        {
            e.Value = e.Value.ToString();
        }
        protected virtual void AppointmentTypeToIconConverter(object o, ConvertEventArgs e)
        {
            AppointmentType type = (AppointmentType)e.Value;
            if (type == AppointmentType.Pattern)
                e.Value = RecurringIcon;
            else
                e.Value = NormalIcon;
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty)
        {
            BindProperties(target, targetProperty, sourceProperty, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty, DataSourceUpdateMode updateMode)
        {
            target.DataBindings.Add(targetProperty, Controller, sourceProperty, true, updateMode);
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty, ConvertEventHandler objectToStringConverter)
        {
            Binding binding = new Binding(targetProperty, Controller, sourceProperty, true);
            binding.Format += objectToStringConverter;
            target.DataBindings.Add(binding);
        }
        protected virtual void BindToBoolPropertyAndInvert(Control target, string targetProperty, string sourceProperty)
        {
            target.DataBindings.Add(new BoolInvertBinding(targetProperty, Controller, sourceProperty));
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Controller == null)
                return;
            this.DataBindings.Add("Text", Controller, "Caption");
            SubscribeControlsEvents();
            LoadFormData(Controller.EditedAppointmentCopy);
            RecalculateLayoutOfControlsAffectedByProgressPanel();

            if (_AllowMultiResouces)
            {
                edtResources.Visible = true;
                edtResources.Enabled = true;
                edtResource.Visible = false;
                edtResource.Enabled = false;
            }
            else 
            {
                edtResource.Properties.Items.RemoveAt(0);

                edtResources.Visible = false;
                edtResources.Enabled = false;
                edtResource.Visible = true;
                edtResource.Enabled = true;
            }

            //this.edtEndDate.Enabled = false;
            //this.edtEndTime.Enabled = false;

            if (_AutoCalEndDateTime)
            {
                this.edtEndDate.Properties.ReadOnly = true;
                this.edtEndTime.Properties.ReadOnly = true;
            }

            _CustomerCol = SalonDB.Data.DBProviderES.GetCustomers((Guid)_CompanyEnt.CompanyID);
            _StoreCol = SalonDB.Data.DBProviderES.GetStores((Guid)_CompanyEnt.CompanyID);
            _ServiceCol = SalonDB.Data.DBProviderES.GetServices((Guid)_CompanyEnt.CompanyID);
            _TransactionDetailServiceCol = new BusinessObjects.TransactionDetailServiceCollection();

            CustomerLookUpEdit.Properties.DisplayMember = "Name";
            CustomerLookUpEdit.Properties.ValueMember = "CustomerID";
            this.CustomerBindingSource.DataSource = _CustomerCol;

            StoreLookUpEdit.Properties.DisplayMember = "Name";
            StoreLookUpEdit.Properties.ValueMember = "StoreID";
            this.StoreBindingSource.DataSource = _StoreCol;

            this.ServiceBindingSource.DataSource = _ServiceCol;

            AppointmentForm._TransactionEnt = null;

            if (Controller.IsNewAppointment)
            {
                var oSpan = this.controller.End.Subtract(this.controller.Start);

                tbSubject.Text = "New Appointment";
                //tbDescription.Text = $"Appointment duration: {oSpan.Minutes}";

                var CustomerEnt = SalonDB.Data.DBProviderES.GetCustomerWalkIn((Guid)_CompanyEnt.CompanyID);
                if (CustomerEnt != null)
                {
                    CustomerLookUpEdit.EditValue = CustomerEnt.CustomerID;
                }

                var StaffEnt = SalonDB.Data.DBProviderES.GetStaff((Guid)this.Controller.ResourceId, (Guid)_CompanyEnt.CompanyID);
                if (StaffEnt != null)
                {
                    //edtResource.EditValue = this.Controller.ResourceId;
                    if (StaffEnt.UpToStoreByStoreID != null)
                    {
                        tbLocation.Text = StaffEnt.UpToStoreByStoreID.Name;
                        StoreLookUpEdit.EditValue = StaffEnt.StoreID;
                    }
                }
            }
            else
            {
                //edtResource.Enabled = false;
                AppointmentForm._TransactionEnt = SalonDB.Data.DBProviderES.GetTransaction(_AppointmentID, _CompanyEnt.CompanyID);
            }

            if (AppointmentForm._TransactionEnt == null)
            {
                AppointmentForm._TransactionEnt = new BusinessObjects.Transaction();
                AppointmentForm._TransactionEnt.CompanyID = _CompanyEnt.CompanyID;
                AppointmentForm._TransactionEnt.AppointmentID = _AppointmentID;
                AppointmentForm._TransactionEnt.Amount = 0;
                AppointmentForm._TransactionEnt.TaxPercent = 0;
                AppointmentForm._TransactionEnt.DiscountPercent = 0;
                AppointmentForm._TransactionEnt.Total = 0;
                AppointmentForm._TransactionEnt.Status = SalonDB.Data.eTransactionStatus.Appointment.ToString();

            }

            _TransactionDetailServiceCol = AppointmentForm._TransactionEnt.TransactionDetailServiceCollectionByTransactionID;
            this.TransactionDetailServiceBindingSource.DataSource = _TransactionDetailServiceCol;
            //this.gridControl1.DataSource = this.TransactionDetailServiceBindingSource;

            _AppointmentPaid = AppointmentForm._TransactionEnt.Status == SalonDB.Data.eTransactionStatus.Paid.ToString();

        }

        protected virtual AppointmentFormController CreateController(SchedulerControl control, Appointment apt)
        {
            //return new AppointmentFormController(control, apt);
            return new CustomAppointmentFormController(control, apt);
        }
        void SubscribeEditorsEvents()
        {
            this.cbReminder.EditValueChanging += OnCbReminderEditValueChanging;
        }
        void SubscribeControllerEvents(AppointmentFormController controller)
        {
            if (controller == null)
                return;
            controller.PropertyChanged += OnControllerPropertyChanged;
        }
        void OnControllerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ReadOnly")
                UpdateReadonly();
        }
        protected virtual void UpdateReadonly()
        {
            if (Controller == null)
                return;
            IList<Control> controls = GetAllControls(this);
            foreach (Control control in controls)
            {
                BaseEdit editor = control as BaseEdit;
                if (editor == null)
                    continue;
                editor.ReadOnly = Controller.ReadOnly;
            }
            this.btnOk.Enabled = !Controller.ReadOnly;
            this.btnRecurrence.Enabled = !Controller.ReadOnly;
        }

        List<Control> GetAllControls(Control rootControl)
        {
            List<Control> result = new List<Control>();
            foreach (Control control in rootControl.Controls)
            {
                result.Add(control);
                IList<Control> childControls = GetAllControls(control);
                result.AddRange(childControls);
            }
            return result;
        }
        protected internal virtual void LoadIcons()
        {
            Assembly asm = typeof(SchedulerControl).Assembly;
            recurringIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.RecurringAppointment, asm);
            normalIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.Appointment, asm);
        }
        protected internal virtual void SubscribeControlsEvents()
        {
            this.edtEndDate.Validating += new CancelEventHandler(OnEdtEndDateValidating);
            this.edtEndDate.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtEndDateInvalidValue);
            this.edtEndTime.Validating += new CancelEventHandler(OnEdtEndTimeValidating);
            this.edtEndTime.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtEndTimeInvalidValue);
            this.cbReminder.InvalidValue += new InvalidValueExceptionEventHandler(OnCbReminderInvalidValue);
            this.cbReminder.Validating += new CancelEventHandler(OnCbReminderValidating);
            this.edtStartDate.Validating += new CancelEventHandler(OnEdtStartDateValidating);
            this.edtStartDate.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtStartDateInvalidValue);
            this.edtStartTime.Validating += new CancelEventHandler(OnEdtStartTimeValidating);
            this.edtStartTime.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtStartTimeInvalidValue);
        }
        protected internal virtual void UnsubscribeControlsEvents()
        {
            this.edtEndDate.Validating -= new CancelEventHandler(OnEdtEndDateValidating);
            this.edtEndDate.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtEndDateInvalidValue);
            this.edtEndTime.Validating -= new CancelEventHandler(OnEdtEndTimeValidating);
            this.edtEndTime.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtEndTimeInvalidValue);
            this.cbReminder.InvalidValue -= new InvalidValueExceptionEventHandler(OnCbReminderInvalidValue);
            this.cbReminder.Validating -= new CancelEventHandler(OnCbReminderValidating);
            this.edtStartDate.Validating -= new CancelEventHandler(OnEdtStartDateValidating);
            this.edtStartDate.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtStartDateInvalidValue);
            this.edtStartTime.Validating -= new CancelEventHandler(OnEdtStartTimeValidating);
            this.edtStartTime.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtStartTimeInvalidValue);
        }
        void OnBtnOkClick(object sender, System.EventArgs e)
        {
            OnOkButton();
        }
        protected internal virtual void OnEdtStartTimeInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual void OnEdtStartTimeValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Controller.ValidateLimitInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay);
        }
        protected internal virtual void OnEdtStartDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual void OnEdtStartDateValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Controller.ValidateLimitInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay);
        }
        protected internal virtual void OnEdtEndDateValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValidInterval();
            if (!e.Cancel)
                this.edtEndDate.DataBindings["EditValue"].WriteValue();
        }
        protected internal virtual void OnEdtEndDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (!AppointmentFormControllerBase.ValidateInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay))
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidEndDate);
            else
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual void OnEdtEndTimeValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValidInterval();
            if (!e.Cancel)
                this.edtEndTime.DataBindings["EditValue"].WriteValue();
        }
        protected internal virtual void OnEdtEndTimeInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (!AppointmentFormControllerBase.ValidateInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay))
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidEndDate);
            else
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual bool IsValidInterval()
        {
            return AppointmentFormControllerBase.ValidateInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay) &&
                Controller.ValidateLimitInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay);
        }
        protected internal virtual void OnOkButton()
        {
            if (!ValidateDateAndTime())
                return;
            if (!SaveFormData(Controller.EditedAppointmentCopy))
                return;
            if (!Controller.IsConflictResolved())
            {
                ShowMessageBox(SchedulerLocalizer.GetString(SchedulerStringId.Msg_Conflict), Controller.GetMessageBoxCaption(SchedulerStringId.Msg_Conflict), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Controller.IsAppointmentChanged() || Controller.IsNewAppointment || IsAppointmentChanged(Controller.EditedAppointmentCopy) || AppointmentForm._TransactionEnt.RowState == EntitySpaces.Interfaces.esDataRowState.Added  || AppointmentForm._TransactionEnt.RowState == EntitySpaces.Interfaces.esDataRowState.Modified || AppointmentForm._TransactionEnt.TransactionDetailServiceCollectionByTransactionID.IsDirty)
                Controller.ApplyChanges();

            this.DialogResult = DialogResult.OK;
        }
        private bool ValidateDateAndTime()
        {
            this.edtEndDate.DoValidate();
            this.edtEndTime.DoValidate();
            this.edtStartDate.DoValidate();
            this.edtStartTime.DoValidate();

            return String.IsNullOrEmpty(this.edtEndTime.ErrorText) && String.IsNullOrEmpty(this.edtEndDate.ErrorText) && String.IsNullOrEmpty(this.edtStartDate.ErrorText) && String.IsNullOrEmpty(this.edtStartTime.ErrorText);
        }
        protected internal virtual DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return XtraMessageBox.Show(this, text, caption, buttons, icon);
        }
        void OnBtnDeleteClick(object sender, System.EventArgs e)
        {
            OnDeleteButton();
        }
        protected internal virtual void OnDeleteButton()
        {
            if (IsNewAppointment)
                return;

            if (_AppointmentPaid)
            {
                XtraMessageBox.Show($"Cannot Delete the current Appointment as it's Status is '{SalonDB.Data.eTransactionStatus.Paid.ToString()}'", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Controller.DeleteAppointment();

                DialogResult = DialogResult.Abort;
                Close();
            }

        }
        void OnBtnRecurrenceClick(object sender, System.EventArgs e)
        {
            OnRecurrenceButton();
        }
        protected internal virtual void OnRecurrenceButton()
        {
            if (!Controller.ShouldShowRecurrenceButton)
                return;

            Appointment patternCopy = Controller.PrepareToRecurrenceEdit();

            DialogResult result;
            using (Form form = CreateAppointmentRecurrenceForm(patternCopy, Control.OptionsView.FirstDayOfWeek))
            {
                result = ShowRecurrenceForm(form);
            }

            if (result == DialogResult.Abort)
            {
                Controller.RemoveRecurrence();
            }
            else if (result == DialogResult.OK)
            {
                Controller.ApplyRecurrence(patternCopy);
            }
        }
        protected virtual DialogResult ShowRecurrenceForm(Form form)
        {
            return FormTouchUIAdapter.ShowDialog(form, this);
        }
        protected internal virtual Form CreateAppointmentRecurrenceForm(Appointment patternCopy, FirstDayOfWeek firstDayOfWeek)
        {
            AppointmentRecurrenceForm form = new AppointmentRecurrenceForm(patternCopy, firstDayOfWeek, Controller);
            form.SetMenuManager(MenuManager);
            form.LookAndFeel.ParentLookAndFeel = LookAndFeel;
            form.ShowExceptionsRemoveMsgBox = controller.AreExceptionsPresent();
            return form;
        }
        internal void OnAppointmentFormActivated(object sender, EventArgs e)
        {
            if (openRecurrenceForm)
            {
                openRecurrenceForm = false;
                OnRecurrenceButton();
            }

            if (_AutoCalEndDateTime)
            {
                this.RefreshTimeEndTime();
            }

        }
        protected internal virtual void OnCbReminderValidating(object sender, CancelEventArgs e)
        {
            TimeSpan span = cbReminder.Duration;
            e.Cancel = (span == TimeSpan.MinValue) || (span.Ticks < 0);
            if (!e.Cancel)
                this.cbReminder.DataBindings["Duration"].WriteValue();
        }
        protected internal virtual void OnCbReminderInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidReminderTimeBeforeStart);
        }
        protected internal virtual void RecalculateLayoutOfControlsAffectedByProgressPanel()
        {
            if (progressPanel.Visible)
                return;
            int intDeltaY = progressPanel.Height;
            tbDescription.Location = new Point(tbDescription.Location.X, tbDescription.Location.Y - intDeltaY);
            tbDescription.Size = new Size(tbDescription.Size.Width, tbDescription.Size.Height + intDeltaY);
        }
        void OnCbReminderEditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue is TimeSpan)
                return;
            string stringValue = e.NewValue as String;
            TimeSpan duration = HumanReadableTimeSpanHelper.Parse(stringValue);
            if (duration.Ticks < 0)
                e.NewValue = TimeSpan.FromTicks(0);
        }
              
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var oEnt = this.GetCurrentTransactionDetailServiceEntity();
            if (oEnt != null)
            {
                oEnt.UnitPrice = 0;
                oEnt.Duration = 0;
            }
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            this.RefreshGrid(this.gridView1);
        }

        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var oEditor = sender as LookUpEdit;
            oEditor.DoValidate();
            this.RefreshGrid(this.gridView1);
        }

        private void repositoryItemSpinEdit2_EditValueChanged(object sender, EventArgs e)
        {
            //var oEditor = sender as SpinEdit;
            //oEditor.DoValidate();
            //this.RefreshGrid(this.gridView1);
        }

        private BusinessObjects.TransactionDetailService GetCurrentTransactionDetailServiceEntity()
        {
            return this.TransactionDetailServiceBindingSource.Current as BusinessObjects.TransactionDetailService;
        }

        private void RefreshGridData()
        {
            var oEnt = this.GetCurrentTransactionDetailServiceEntity();
            if (oEnt != null)
            {
                var ServiceEnt = (from oRow in _ServiceCol where oRow.Name == oEnt.Name select oRow).FirstOrDefault();

                if (ServiceEnt != null)
                {
                    oEnt.ServiceID = ServiceEnt.ServiceID;
                    oEnt.Description = ServiceEnt.Description;
                    oEnt.Duration = ServiceEnt.Duration;
                    oEnt.UnitPrice = ServiceEnt.Price;
                    oEnt.Quantity = 1;
                }
            }
        }

        private void RefreshGrid(GridView oGridView)
        {
            oGridView.PostEditor();
            oGridView.CloseEditor();
            oGridView.UpdateCurrentRow();
            if (gridView1.FocusedColumn.FieldName == colName.FieldName)
            {
                this.RefreshGridData();
            }
            this.gridView1.UpdateSummary();
            this.RefreshTimeEndTime();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.RefreshGrid(this.gridView1);
        }

        private void NewCustomersimpleButton_Click(object sender, EventArgs e)
        {
            this.AddNewCustomer();
        }

        private void AddNewCustomer()
        {
            var oAddCustomerForm = new AddCustomerForm(null);
            oAddCustomerForm.ShowDialog();

            if (oAddCustomerForm.ReturnValue != null)
            {
                oAddCustomerForm.ReturnValue.CompanyID = MainForm.LoggedInUser.CompanyID;
                _CustomerCol.AttachEntity(oAddCustomerForm.ReturnValue);
                _CustomerCol.Save();
                this.CustomerLookUpEdit.EditValue = oAddCustomerForm.ReturnValue.CustomerID;
            }
        }

        private void edtStartTime_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshTimeEndTime();
        }

        private void edtStartDate_EditValueChanged(object sender, EventArgs e)
        {
            this.RefreshTimeEndTime();
        }

        private void RefreshTimeEndTime()
        {
            Decimal Price = 0;
            int Duration = 0;

            if (this.colDuration.SummaryItem.SummaryValue != null)
            {
                Duration = (int)this.colDuration.SummaryItem.SummaryValue;
                if (Duration > 0)
                {
                    if (this.colPrice.SummaryItem.SummaryValue != null)
                    {
                        Price = (decimal)this.colPrice.SummaryItem.SummaryValue;
                    }

                    var oTS = new TimeSpan(0, Duration, 0);
                    var TempEndData = Controller.Start.Add(oTS);
                    //Controller.EditedAppointmentCopy.End = TempEndData;
                    //Controller.End = TempEndData;
                    this.edtEndDate.DateTime  = TempEndData;
                    this.edtEndTime.Time = TempEndData;
                    Controller.EditedAppointmentCopy.End = TempEndData;
                }
            }

            this.tbDescription.Text = $"Duration: {Duration}{Environment.NewLine}Amount: {Math.Round(Price, 2)}";
        }

        private void CustomerLookUpEdit_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            //if (XtraMessageBox.Show(this, "Add '" + e.DisplayValue.ToString() + "' entry to the list?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    var NewCustomer = e.DisplayValue.ToString();
            //    //(CustomerLookUpEdit.Properties.DataSource as _CustomerCol ).Add(new Contact());
            //    e.Handled = true;
            //}

            var NewCustomer = e.DisplayValue.ToString().Trim().Split(new char[] { ' ' }, 2);
            var DS = ((System.Windows.Forms.BindingSource)CustomerLookUpEdit.Properties.DataSource).List as BusinessObjects.CustomerCollection; //CustomerLookUpEdit.Properties.DataSource as BusinessObjects.CustomerCollection;
            var oEntNew = DS.AddNew();
            oEntNew.CustomerID = Guid.NewGuid();
            oEntNew.CompanyID = _CompanyEnt.CompanyID;

            if (NewCustomer.Length == 1)
            {
                oEntNew.FirstName = NewCustomer[0];
                oEntNew.LastName = "";
            }
            else
            {
                oEntNew.FirstName = NewCustomer[0];
                oEntNew.LastName = NewCustomer[1];
            }

            e.Handled = true;

            _CustomerCol.Save();
        }
    }

    public class CustomAppointmentFormController : AppointmentFormController
    {
        private static string Const_ApptCustomerID = "ApptCustomerID";
        private static string Const_ApptStoreID = "ApptStoreID";
        public CustomAppointmentFormController(SchedulerControl control, Appointment apt)
            : base(control, apt)
        {
        }

        public override bool IsAppointmentChanged()
        {
            if (base.IsAppointmentChanged())
                return true;
            return SourceCustomerID != CustomerID || SourceStoreID != StoreID;
        }

        protected override void ApplyCustomFieldsValues()
        {
            SourceCustomerID = CustomerID;
            SourceStoreID = StoreID;
        }

        public Guid CustomerID
        {
            get
            {
                return EditedAppointmentCopy.CustomFields[Const_ApptCustomerID] == null ? Guid.Empty : (Guid)EditedAppointmentCopy.CustomFields[Const_ApptCustomerID];
            }
            set
            {
                EditedAppointmentCopy.CustomFields[Const_ApptCustomerID] = value;
            }
        }

        public Guid SourceCustomerID
        {
            get
            {
                return (Guid)SourceAppointment.CustomFields[Const_ApptCustomerID];
            }
            set
            {
                SourceAppointment.CustomFields[Const_ApptCustomerID] = value;
            }
        }

        public Guid StoreID
        {
            get
            {
                return EditedAppointmentCopy.CustomFields[Const_ApptStoreID] == null ? Guid.Empty : (Guid)EditedAppointmentCopy.CustomFields[Const_ApptStoreID];
            }
            set
            {
                EditedAppointmentCopy.CustomFields[Const_ApptStoreID] = value;
            }
        }

        public Guid SourceStoreID
        {
            get
            {
                return (Guid)SourceAppointment.CustomFields[Const_ApptStoreID];
            }
            set
            {
                SourceAppointment.CustomFields[Const_ApptStoreID] = value;
            }
        }

    }
}