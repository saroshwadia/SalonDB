using EntitySpaces.Interfaces;
using SalonDB.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraScheduler;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Utils;
using SalonDB.Win.Forms;
using static SalonDB.Data.DBProviderES;

namespace SalonDB.Win
{
    public partial class AppointmentForm : BaseForm
    {
        public static Random RandomInstance = new Random();
        public static string Const_CustomApptCustomerID = "ApptCustomerID";
        public static string Const_CustomApptStoreID = "ApptStoreID";

        private BindingList<CustomResource> CustomResourceCollection = new BindingList<CustomResource>();
        private BindingList<CustomAppointment> CustomEventList = new BindingList<CustomAppointment>();

        private BusinessObjects.Company _CompanyEnt = new BusinessObjects.Company();
        private BusinessObjects.AppointmentCollection _AppointmentCol = new BusinessObjects.AppointmentCollection();
        private BusinessObjects.StaffCollection _StaffCol = new BusinessObjects.StaffCollection();
        public static BusinessObjects.Transaction _TransactionEnt = new BusinessObjects.Transaction();

        public AppointmentForm()
        {
            InitializeComponent();
            this.SetupRadioButtons();
            this.SetGroupType();
            this.SetViewType();
            //this.schedulerStorage1.Resources.ColorSaving = ColorSavingType.ArgbColor;
            //this.ConnectToDB();
        }

        private void MainForm_Load(object sender, EventArgs e)
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


        private void PreSetup()
        {
            this.schedulerControl1.Storage.Appointments.Clear();
            this.schedulerControl1.Storage.Resources.Clear();
            //this.SetupAppointmentsLabels();
            //this.SetupAppointmentsStatuses();
            this.schedulerControl1.DayView.TimeIndicatorDisplayOptions.ShowOverAppointment = true;
            this.schedulerStorage1.Appointments.ResourceSharing = false;
            //this.schedulerControl1.DayView.ResourcesPerPage = 2;
        }

        private void PostSetup()
        {
            var oResource = GetResource(); // this.schedulerControl1.Storage.Resources.Items[2];
            var CurrentDateTime = DateTime.Now;
            var oStartTime = new DevExpress.XtraScheduler.TimeInterval();
            oStartTime.Start = CurrentDateTime;
            oStartTime.End = oStartTime.Start.AddMinutes(15);
            this.schedulerControl1.DayView.TopRowTime = new TimeSpan(CurrentDateTime.Hour, CurrentDateTime.Minute, CurrentDateTime.Second);
            this.schedulerControl1.DayView.TimeIndicatorDisplayOptions.ShowOverAppointment = true;
            this.schedulerControl1.DayView.GotoTimeInterval(oStartTime);
            this.schedulerControl1.Start = CurrentDateTime;
            if (oResource != null)
            {
                this.schedulerControl1.ActiveView.SetSelection(oStartTime, oResource);
            }
        }

        private DevExpress.XtraScheduler.Resource GetResource()
        {
            DevExpress.XtraScheduler.Resource ReturnValue = null;
            foreach (var oResource in this.schedulerControl1.Storage.Resources.Items)
            {
                if (oResource.Id.ToString() == MainForm.LoggedInUser.StaffID.ToString())
                {
                    ReturnValue = oResource;
                    break;
                }
            }

            return ReturnValue;
        }

        private void SetupAppointmentsLabels()
        {
            string[] AppointmentLabels = { "Consultation", "Treatment", "Wash" };
            Color[] AppointmentColorLabels = { Color.Ivory, Color.Pink, Color.Plum };

            IAppointmentLabelStorage labelStorage = this.schedulerControl1.Storage.Appointments.Labels;
            labelStorage.Clear();
            int count = AppointmentLabels.Length;
            for (int i = 0; i < count; i++)
            {
                IAppointmentLabel label = labelStorage.CreateNewLabel(i, AppointmentLabels[i]);
                label.SetColor(AppointmentColorLabels[i]);
                labelStorage.Add(label);
            }
        }

        private void SetupAppointmentsStatuses()
        {
            string[] AppointmentStatuses = { "Paid", "Unpaid", "OnAccount" };
            Color[] AppointmentColorStatuses = { Color.Green, Color.Red, Color.Blue };

            AppointmentStatusCollection statusColl = this.schedulerControl1.Storage.Appointments.Statuses;
            statusColl.Clear();
            int count = AppointmentStatuses.Length;
            for (int i = 0; i < count; i++)
            {
                AppointmentStatus status = statusColl.CreateNewStatus(i, AppointmentStatuses[i], AppointmentStatuses[i]);
                status.SetBrush(new SolidBrush(AppointmentColorStatuses[i]));
                statusColl.Add(status);
            }
        }

        private string GetTimeZoneName()
        {
            var ReturnValue = string.Empty;
            var localZone = TimeZoneInfo.Local;
            ReturnValue = localZone.DisplayName;

            var Pos = ReturnValue.IndexOf(")");
            ReturnValue = ReturnValue.Substring(0, Pos).Replace("(", "");

            return ReturnValue;
        }

        private List<DateTime> GetDates(int max)
        {
            var ReturnValue = new List<DateTime>();
            var FirstDateTime = DateTime.Now;
            var FromHour = 9;
            var ToHour = 16;
            var StartTime = new DateTime(FirstDateTime.Year, FirstDateTime.Month, FirstDateTime.Day, FromHour, 0, 0);

            for (int Counter = 1; Counter <= max; Counter++)
            {
                StartTime = StartTime.AddHours(Counter);
                if (!(StartTime.Hour >= FromHour && StartTime.Hour <= ToHour))
                {
                    StartTime = StartTime.AddDays(1);
                    StartTime = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, FromHour, 0, 0);
                }

                ReturnValue.Add(StartTime);

            }

            return ReturnValue;
        }

        private void GenerateData()
        {
            //var email = "s.w@gsmtech.com";
            //var StaffEnt = DBProvider.GetStaffByEmail(email);
            var CompanyEnt = DBProviderES.GetCompanyFirst();
            var AppointmentsToAdd = 10;
            var StartTime = DateTime.Now;
            var EndTime = DateTime.Now;
            var Days = new List<DateTime>();
            var TimeZone = "";
            var oRandom = new Random(DateTime.Now.Date.Minute);
            var MaxStaff = 0;
            var MaxService = 0;
            var MaxProduct = 0;
            var RowNumber = 0;
            var ClearAppointments = true;

            if (CompanyEnt != null)
            {

                var StaffCol = DBProviderES.GetStaffs(CompanyEnt.CompanyID);
                var ServiceCol = DBProviderES.GetServices(CompanyEnt.CompanyID);
                var ProductCol = DBProviderES.GetProducts(CompanyEnt.CompanyID);
                var AppointmentCol = DBProviderES.GetAppointments(CompanyEnt.CompanyID);
                var CustomerEnt = DBProviderES.GetCustomerWalkIn(CompanyEnt.CompanyID);

                MaxStaff = StaffCol.Count;
                MaxService = ServiceCol.Count;
                MaxProduct = ProductCol.Count;
                TimeZone = GetTimeZoneName();
                Days = GetDates(AppointmentsToAdd);

                if (ClearAppointments)
                {
                    AppointmentCol.MarkAllAsDeleted();
                }

                for (int Row = 1; Row <= AppointmentsToAdd; Row++)
                {

                    RowNumber = oRandom.Next(MaxStaff);
                    var StaffEnt = StaffCol[RowNumber];

                    RowNumber = oRandom.Next(MaxService);
                    var ServiceEnt = ServiceCol[RowNumber];

                    RowNumber = oRandom.Next(MaxProduct);
                    var ProductEnt = ProductCol[RowNumber];

                    RowNumber = oRandom.Next(AppointmentsToAdd);
                    StartTime = Days[RowNumber];
                    EndTime = StartTime.AddMinutes(Convert.ToDouble(ServiceEnt.Duration));

                    var AppointmentEnt = AppointmentCol.AddNew();

                    AppointmentEnt.CompanyID = CompanyEnt.CompanyID;
                    AppointmentEnt.StoreID = StaffEnt.StoreID;
                    AppointmentEnt.StaffID = StaffEnt.StaffID;
                    AppointmentEnt.CustomerID = CustomerEnt.CustomerID;
                    AppointmentEnt.Notes = $"Duration {ServiceEnt.Duration}";
                    AppointmentEnt.Color = null;
                    AppointmentEnt.Subject = $" {ServiceEnt.Name}";
                    AppointmentEnt.Description = $"{ProductEnt.Name}";
                    AppointmentEnt.StartTime = StartTime;
                    AppointmentEnt.EndTime = EndTime;
                    AppointmentEnt.AllDay = false;
                    AppointmentEnt.Recurrence = 0;
                    AppointmentEnt.RecurrenceRule = null;
                    AppointmentEnt.StartTimeZone = TimeZone;
                    AppointmentEnt.EndTimeZone = TimeZone;

                }

                AppointmentCol.Save();

            }

        }

        private void LoadData()
        {
            //this.GenerateData();
            this.PreSetup();
            _CompanyEnt = SalonDB.Win.Forms.MainForm.LoggedInUser.UpToCompanyByCompanyID; //DBProviderES.GetCompanyFirst();
            this.SyncAppointmentsAndResourcesFromDBToScheduler();
            this.PostSetup();
            this.UpdateControls();
        }

        private void SyncAppointmentsAndResourcesFromDBToScheduler()
        {
            _AppointmentCol = DBProviderES.GetAppointments(_CompanyEnt.CompanyID, (DateTime)this.schedulerControl1.Start.AddDays(-7), null);
            _StaffCol = DBProviderES.GetStaffs(_CompanyEnt.CompanyID);

            this.InitResources();
            this.InitAppointments();
            this.SetResourceColors();
        }

        private void InitResources()
        {
            ResourceMappingInfo mappings = this.schedulerStorage1.Resources.Mappings;
            mappings.Id = "ResourceID";
            mappings.Color = "ResourceColor";
            mappings.Caption = "ResourceName";

            CustomResourceCollection = new BindingList<CustomResource>();

            var FromDB = true;

            if (FromDB)
            {
                foreach (var StaffEnt in _StaffCol)
                {
                    var UID = new Guid(StaffEnt.StaffID.ToString());
                    //schedulerControl1.ResourceColorSchemas.Add(new SchedulerColorSchema(Color.FromArgb(Convert.ToInt32(StaffEnt.ResourceColor))));
                    CustomResourceCollection.Add(CreateCustomResource(UID, StaffEnt.FirstName, Color.FromArgb(Convert.ToInt32(StaffEnt.ResourceColor))));
                }
            }
            else
            {
                CustomResourceCollection.Add(CreateCustomResource(new Guid("FB1EEFD2-E376-4754-B4CF-0ED3CF8251CB"), "Max Fowler", Color.PowderBlue));
                CustomResourceCollection.Add(CreateCustomResource(new Guid("C9B371B4-7097-4B79-AFE9-68A32D77F2FB"), "Nancy Drewmore", Color.PaleVioletRed));
                CustomResourceCollection.Add(CreateCustomResource(new Guid("E726682A-0591-42BD-B21A-AEBBD25F03A2"), "Pak Jang", Color.PeachPuff));
            }

            this.schedulerStorage1.Resources.DataSource = CustomResourceCollection;
        }

        private void SetResourceColors()
        {
            var UseRC = UseResourceColorsCheckEdit.Checked;

            this.schedulerControl1.ResourceColorSchemas.BeginUpdate();
            this.schedulerControl1.ResourceColorSchemas.Clear();

            if (UseRC)
            {
                foreach (var StaffEnt in _StaffCol)
                {
                    schedulerControl1.ResourceColorSchemas.Add(new SchedulerColorSchema(Color.FromArgb(Convert.ToInt32(StaffEnt.ResourceColor))));
                }
            }
            else
            {
                this.schedulerControl1.ResourceColorSchemas.LoadDefaults();
            }

            this.schedulerControl1.ResourceColorSchemas.EndUpdate();
        }

        private CustomResource CreateCustomResource(Guid ResourceID, string resourceName, Color ResourceColor)
        {
            CustomResource cr = new CustomResource();
            cr.ResourceID = ResourceID;
            cr.ResourceName = resourceName;
            cr.ResourceColor = ResourceColor;
            return cr;
        }

        private void InitAppointments()
        {
            AppointmentMappingInfo mappings = this.schedulerStorage1.Appointments.Mappings;
            mappings.Start = "StartTime";
            mappings.End = "EndTime";
            mappings.Subject = "Subject";
            mappings.AllDay = "AllDay";
            mappings.Description = "Description";
            mappings.Label = "Label";
            mappings.Location = "Location";
            mappings.RecurrenceInfo = "RecurrenceInfo";
            mappings.ReminderInfo = "ReminderInfo";
            mappings.ResourceId = "ResourceID";
            mappings.Status = "Status";
            mappings.Type = "EventType";
            mappings.AppointmentId = "AppointmentID";

            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping(Const_CustomApptCustomerID, "CustomerID", FieldValueType.Object));
            this.schedulerStorage1.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping(Const_CustomApptStoreID, "StoreID", FieldValueType.Object));

            CustomEventList = new BindingList<CustomAppointment>();

            GenerateEvents(CustomEventList);
            this.schedulerStorage1.Appointments.DataSource = CustomEventList;
        }

        private void GenerateEvents(BindingList<CustomAppointment> eventList)
        {
            int count = schedulerStorage1.Resources.Count;

            foreach (var AppointmentEnt in _AppointmentCol)
            {
                var Location = string.Empty;

                if (AppointmentEnt.UpToStoreByStoreID != null)
                {
                    Location = AppointmentEnt.UpToStoreByStoreID.Name;
                }

                eventList.Add(CreateEvent((Guid)AppointmentEnt.AppointmentID, AppointmentEnt.Subject, AppointmentEnt.StaffID, (int)AppointmentEnt.Status, (int)AppointmentEnt.Label, Location, AppointmentEnt.Description, (DateTime)AppointmentEnt.StartTime, (DateTime)AppointmentEnt.EndTime, (Guid)AppointmentEnt.CustomerID, (Guid)AppointmentEnt.StoreID, AppointmentEnt.ReminderInfo, AppointmentEnt.RecurrenceInfo));
            }

        }
        private CustomAppointment CreateEvent(Guid appointmentID, string subject, object resourceId, int status, int label, string location, string description, DateTime startTime, DateTime endTime, Guid customerID, Guid storeID, string reminderInfo, string recurrenceInfo)
        {
            CustomAppointment apt = new CustomAppointment();
            apt.Subject = subject;
            apt.ResourceID = resourceId;
            apt.StartTime = startTime;
            apt.EndTime = endTime;
            apt.Status = status;
            apt.Label = label;
            apt.Location = location;
            apt.Description = description;
            apt.AppointmentID = appointmentID;
            apt.CustomerID = customerID;
            apt.StoreID = storeID;
            apt.ReminderInfo = reminderInfo;
            apt.RecurrenceInfo = recurrenceInfo;

            return apt;
        }

        private void CopyAppointmentData(BusinessObjects.Appointment sourceEnt, DevExpress.XtraScheduler.Appointment targetEnt)
        {
            targetEnt.Subject = sourceEnt.Subject;
            targetEnt.ResourceId = sourceEnt.StaffID;
            targetEnt.Start = (DateTime)sourceEnt.StartTime;
            targetEnt.End = (DateTime)sourceEnt.EndTime;
            targetEnt.StatusKey = (int)sourceEnt.Status;
            targetEnt.LabelKey = (int)sourceEnt.Label;
            //targetEnt.Location = location;
            targetEnt.Description = sourceEnt.Description;
            //targetEnt.Id  = (Guid)sourceEnt.AppointmentID;
        }

        private void CopyAppointmentData(DevExpress.XtraScheduler.Appointment sourceEnt, BusinessObjects.Appointment targetEnt)
        {
            targetEnt.Subject = sourceEnt.Subject;
            targetEnt.StaffID = (Guid)sourceEnt.ResourceId;
            targetEnt.StartTime = (DateTime)sourceEnt.Start;
            targetEnt.EndTime = (DateTime)sourceEnt.End;
            targetEnt.Status = (int)sourceEnt.StatusKey;
            targetEnt.Label = (int)sourceEnt.LabelKey;
            //targetEnt.Location = sourceEnt.Location;
            targetEnt.Description = sourceEnt.Description;
            targetEnt.ReminderInfo = sourceEnt.Reminder?.ToString();
            targetEnt.RecurrenceInfo = sourceEnt.RecurrenceInfo?.ToXml();
            var oValue = (Guid)sourceEnt.CustomFields[Const_CustomApptCustomerID];
            targetEnt.CustomerID = new Guid(oValue.ToString());
            oValue = (Guid)sourceEnt.CustomFields[Const_CustomApptStoreID];
            targetEnt.StoreID = oValue;
        }

        private void CopyAppointmentData(CustomAppointment sourceEnt, BusinessObjects.Appointment targetEnt)
        {
            targetEnt.Subject = sourceEnt.Subject;
            targetEnt.StaffID = (Guid)sourceEnt.ResourceID;
            targetEnt.StartTime = (DateTime)sourceEnt.StartTime;
            targetEnt.EndTime = (DateTime)sourceEnt.EndTime;
            targetEnt.Status = (int)sourceEnt.Status;
            targetEnt.Label = (int)sourceEnt.Label;
            //targetEnt.Location = sourceEnt.Location;
            targetEnt.Description = sourceEnt.Description;
            targetEnt.ReminderInfo = sourceEnt.ReminderInfo;
            targetEnt.RecurrenceInfo = sourceEnt.RecurrenceInfo;
            targetEnt.CustomerID = sourceEnt.CustomerID;
            targetEnt.StoreID = sourceEnt.StoreID;
        }

        private void UpdateControls()
        {
            this.radioGroup1.EditValue = (int)schedulerControl1.GroupType;
            this.radioGroup2.EditValue = (int)schedulerControl1.ActiveViewType;
        }

        private void SetupRadioButtons()
        {
            foreach (var item in Enum.GetValues(typeof(SchedulerGroupType)))
            {
                radioGroup1.Properties.Items.Add(new RadioGroupItem((int)item, item.ToString()));
            }
            radioGroup1.EditValue = (int)SchedulerGroupType.Resource;

            foreach (var item in Enum.GetValues(typeof(SchedulerViewType)))
            {
                radioGroup2.Properties.Items.Add(new RadioGroupItem((int)item, item.ToString()));
            }
            radioGroup2.EditValue = (int)SchedulerViewType.Day;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetGroupType();
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetViewType();
        }

        private void UseResourceColorsCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.SetResourceColors();
        }

        private void SetGroupType()
        {
            SchedulerGroupType oSchedulerGroupType = (SchedulerGroupType)radioGroup1.EditValue;
            this.schedulerControl1.GroupType = oSchedulerGroupType;
        }

        private void SetViewType()
        {
            SchedulerViewType oSchedulerViewType = (SchedulerViewType)radioGroup2.EditValue;
            this.schedulerControl1.ActiveViewType = oSchedulerViewType;
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            SalonDB.Win.CustomAppointmentForm form = new SalonDB.Win.CustomAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm, _CompanyEnt);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }

        }

        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            this.SaveChanges(e.Objects, RowState.Changed);
        }

        private void schedulerStorage1_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            if (schedulerControl1.SelectedAppointments.Count == 1)
            {
                Appointment apt = schedulerControl1.SelectedAppointments[0];
                e.Cancel = !AllowAppointmentEdit(apt.Id, false);
            }
        }

        private void schedulerStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            this.SaveChanges(e.Objects, RowState.Deleted);
        }

        private void schedulerStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            //this.schedulerControl1.Storage.SetAppointmentId((Appointment)e.o)
            this.SaveChanges(e.Objects, RowState.Inserted);
        }

        private void SaveChanges(object oSource, RowState oRowState)
        {
            var SourceRows = (DevExpress.XtraScheduler.AppointmentBaseCollection)oSource;
            BusinessObjects.Appointment oEnt1 = null;
            CustomAppointment oEnt2 = null;
            Guid? ID = null;
            var ErrorCount = 0;

            foreach (var oApptEnt in SourceRows)
            {
                if (oApptEnt.Id == null)
                {
                    if (oRowState != RowState.Inserted)
                    {

                        foreach (var item in this.schedulerControl1.Storage.Appointments.Items)
                        {
                            var IDX = item.GetSourceObject(this.schedulerControl1.Storage);
                        }
                        ErrorCount += 1;
                        XtraMessageBox.Show($"Cannot continue as the Appointment ID was not found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                       
                }
                else
                {
                    ID = (Guid)oApptEnt.Id;
                    oEnt1 = (from oRow in _AppointmentCol where (Guid)oRow.AppointmentID == (Guid)ID select oRow).FirstOrDefault();
                    oEnt2 = (from oRow in CustomEventList where (Guid)oRow.AppointmentID == (Guid)ID select oRow).FirstOrDefault();
                }

                if (true || ID != null)
                {
                    if (oRowState == RowState.Changed)
                    {
                        //CopyAppointmentData(oApptEnt, oEnt);
                        CopyAppointmentData(oEnt2, oEnt1);
                        this.UpdateTransaction(oEnt1, false, false);
                    }
                    else if (oRowState == RowState.Inserted)
                    {
                        oEnt1 = _AppointmentCol.AddNew();
                        //CopyAppointmentData(oApptEnt, oEnt1);
                        oEnt2 = (from oRow in CustomEventList where (Guid)oRow.AppointmentID == Guid.Empty select oRow).FirstOrDefault();
                        CopyAppointmentData(oEnt2, oEnt1);
                        oEnt1.AppointmentID = Guid.NewGuid();
                        oEnt1.CompanyID = _CompanyEnt.CompanyID;
                        oEnt2.AppointmentID = (Guid)oEnt1.AppointmentID;

                        var X1 = oApptEnt.Id;
                        oApptEnt.SetId(oEnt1.AppointmentID);
                        var X2 = oApptEnt.Id;

                        this.UpdateTransaction(oEnt1, false, false);
                    }
                    else if (oRowState == RowState.Deleted)
                    {
                        AppointmentForm._TransactionEnt = DBProviderES.GetTransaction(oEnt1.AppointmentID, oEnt1.CompanyID);

                        if (AppointmentForm._TransactionEnt != null)
                        {
                            if (AppointmentForm._TransactionEnt.Status == SalonDB.Data.eTransactionStatus.Paid.ToString())
                            {
                                XtraMessageBox.Show($"Cannot Delete the current Appointment as it's Status is '{SalonDB.Data.eTransactionStatus.Paid.ToString()}'", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                this.UpdateTransaction(oEnt1, true, false);
                                oEnt1.MarkAsDeleted();
                            }
                        }
                        else
                        {
                            //This should not normally happen as each Appointment has a Transaction row.
                            oEnt1.MarkAsDeleted();
                        }
                    }
                }

            }

            if (ErrorCount == 0)
            {
                var IsDirty = _AppointmentCol.IsGraphDirty;

                try
                {
                    using (esTransactionScope oScope = new esTransactionScope())
                    {
                        if (oRowState == RowState.Deleted)
                        {
                            if (AppointmentForm._TransactionEnt != null)
                            {
                                AppointmentForm._TransactionEnt.Save();
                            }
                            _AppointmentCol.Save();
                        }
                        else
                        {
                            _AppointmentCol.Save();
                            AppointmentForm._TransactionEnt.CompanyID = _CompanyEnt.CompanyID;
                            AppointmentForm._TransactionEnt.Save();
                        }

                        oScope.Complete();
                        //this.SyncAppointmentsAndResourcesFromDBToScheduler();
                        //this.LoadData();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Cannot Save Changes due to the following Error:{Environment.NewLine}{Environment.NewLine}{ex.Message}'", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateTransaction(BusinessObjects.Appointment AppointmentEnt, bool deleteTransaction, bool saveChanges)
        {
            var oTransactionEnt = AppointmentForm._TransactionEnt;
            decimal Amount = 0;
            decimal TaxRate = Convert.ToDecimal(5.0);

            if (deleteTransaction)
            {
                oTransactionEnt.TransactionDetailProductCollectionByTransactionID.MarkAllAsDeleted();
                oTransactionEnt.TransactionDetailServiceCollectionByTransactionID.MarkAllAsDeleted();
                oTransactionEnt.MarkAsDeleted();
            }
            else
            {

                //if (oTransactionEnt.AppointmentID == null || oTransactionEnt.AppointmentID == Guid.Empty)
                //{

                if (oTransactionEnt.TransactionID == null)
                {
                    //This fixed the duplicate issue in the Transaction table.
                    AppointmentForm._TransactionEnt = DBProviderES.GetTransaction(AppointmentEnt.AppointmentID, AppointmentEnt.CompanyID);
                    if (AppointmentForm._TransactionEnt == null)
                    {
                        AppointmentForm._TransactionEnt = new BusinessObjects.Transaction();
                        AppointmentForm._TransactionEnt.AppointmentID = Guid.Empty;
                    }
                    oTransactionEnt = AppointmentForm._TransactionEnt;
                }

                if (oTransactionEnt.TransactionID == null)
                {
                    oTransactionEnt.TransactionID = Guid.NewGuid();
                    oTransactionEnt.TransactionDate = DateTime.Now;
                    oTransactionEnt.CompanyID = SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID;
                    oTransactionEnt.StaffID = SalonDB.Win.Forms.MainForm.LoggedInUser.StaffID;
                    oTransactionEnt.StoreID = SalonDB.Win.Forms.MainForm.LoggedInUser.StoreID;
                    oTransactionEnt.CustomerID = AppointmentEnt.CustomerID;
                }
                oTransactionEnt.AppointmentID = AppointmentEnt.AppointmentID;
                oTransactionEnt.StaffID = AppointmentEnt.StaffID;
                //}

                foreach (var oChildEnt in oTransactionEnt.TransactionDetailServiceCollectionByTransactionID)
                {
                    //oChildEnt.CompanyID = oTransactionEnt.CompanyID;
                    oChildEnt.TransactionID = oTransactionEnt.TransactionID;
                    Amount += (decimal)oChildEnt.UnitPrice;
                }

                oTransactionEnt.Amount = Amount;
                //oTransactionEnt.Tax = Amount * TaxRate / 100;
                oTransactionEnt.TaxPercent = TaxRate;
                oTransactionEnt.DiscountPercent = 0;
                // No Discount% DiscountAmount required in Appointments
                oTransactionEnt.Total = Amount + (Amount * TaxRate / 100);
            }

            if (saveChanges)
            {
                this.SaveTransactionChanges();
            }

        }

        private void SaveTransactionChanges()
        {
            var oTransactionEnt = AppointmentForm._TransactionEnt;
            try
            {
                oTransactionEnt.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Transaction Save Error: {ex.Message}");
                throw;
            }

        }

        private void toolTipController1_BeforeShow(object sender, DevExpress.Utils.ToolTipControllerShowEventArgs e)
        {
            AppointmentViewInfo aptViewInfo;
            ToolTipController controller = (ToolTipController)sender;
            try
            {
                aptViewInfo = (AppointmentViewInfo)controller.ActiveObject;
            }
            catch
            {
                return;
            }

            if (aptViewInfo == null) return;

            if (toolTipController1.ToolTipType == ToolTipType.Standard || toolTipController1.ToolTipType == ToolTipType.Default)
            {
                e.IconType = ToolTipIconType.Information;
                e.ToolTip = aptViewInfo.Description;
            }

            if (toolTipController1.ToolTipType == ToolTipType.SuperTip)
            {
                SuperToolTip SuperTip = new SuperToolTip();
                SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
                args.Title.Text = $"Info:";
                args.Title.Font = new Font("Tahoma", 14);
                args.Contents.Text = $"Subject: {aptViewInfo.Appointment.Subject}{Environment.NewLine}Description: {aptViewInfo.Description}{Environment.NewLine}StartTime: {aptViewInfo.Appointment.Start}{Environment.NewLine}EndTime: {aptViewInfo.Appointment.End}";
                args.Contents.Font = new Font("Tahoma", 10);
                ////args.Contents.Image = this.Icon;
                args.ShowFooterSeparator = true;
                args.Footer.Font = new Font("Tahoma",12);
                args.Footer.Text = $"Status: {GetAppointmentStatus(aptViewInfo.Appointment.Id)}";
                SuperTip.Setup(args);
                e.SuperTip = SuperTip;
            }

        }

        private void schedulerControl1_AllowAppointmentEdit(object sender, AppointmentOperationEventArgs e)
        {
            e.Allow = AllowAppointmentEdit(e.Appointment.Id, false);
        }

        private void schedulerControl1_AllowAppointmentDrag(object sender, AppointmentOperationEventArgs e)
        {
            e.Allow = AllowAppointmentEdit(e.Appointment.Id, false);
        }

        private void schedulerControl1_AllowAppointmentDelete(object sender, AppointmentOperationEventArgs e)
        {
            e.Allow = AllowAppointmentEdit(e.Appointment.Id, false);
        }

        private bool AllowAppointmentEdit(object ID, bool prompt)
        {
            var ReturnValue = true;

            var oEnt = new BusinessObjects.Transaction(); //SalonDB.Data.DBProvider.GetTransaction((Guid)e.Appointment.Id, _CompanyEnt.CompanyID);
            var AppointmentPaid = false;
            var cs = oEnt.es.Connection.ConnectionString;
            var StatusPaid = SalonDB.Data.eTransactionStatus.Paid.ToString();
            var Status = string.Empty;

            if (ID != null)
            {
                oEnt = SalonDB.Data.DBProviderES.GetTransaction((Guid)ID, _CompanyEnt.CompanyID);
                if (oEnt != null)
                {
                    Status = GetAppointmentStatus(ID);
                    AppointmentPaid = oEnt.Status == StatusPaid;

                    if (AppointmentPaid && prompt)
                    {
                        //XtraMessageBox.Show($"Cannot Upate the current Appointment as it's Status is '{StatusPaid}'", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            ReturnValue = !AppointmentPaid;

            return ReturnValue;
        }

        private string GetAppointmentStatus(object ID)
        {
            var ReturnValue = string.Empty;
            var oEnt = new BusinessObjects.Transaction();

            if (ID != null)
            {
                oEnt = SalonDB.Data.DBProviderES.GetTransaction((Guid)ID, _CompanyEnt.CompanyID);
                if (oEnt != null)
                {
                    ReturnValue = oEnt.Status;
                }
            }

            return ReturnValue;
        }
    
    }
}
