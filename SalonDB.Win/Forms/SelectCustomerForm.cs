using BusinessObjects;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SalonDB.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SalonDB.Win.Forms
{
    public partial class SelectCustomerForm :  BaseForm
    {

        public CustomerAppointmentInfo ReturnValue = new CustomerAppointmentInfo();
        //private DateTime DateFrom;
        //private DateTime DateTo;

        private bool ShowHotTracking = true;
        private int hotTrackRow = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        private int HotTrackRow
        {
            get
            {
                return hotTrackRow;
            }
            set
            {
                if (hotTrackRow != value)
                {
                    int prevHotTrackRow = hotTrackRow;
                    hotTrackRow = value;
                    gridView1.RefreshRow(prevHotTrackRow);
                    gridView1.RefreshRow(hotTrackRow);

                    if (hotTrackRow >= 0)
                        gridControl1.Cursor = Cursors.Hand;
                    else
                        gridControl1.Cursor = Cursors.Default;
                }
            }
        }

        public SelectCustomerForm()
        {
            InitializeComponent();
            this.CurrentDateDateEdit.EditValue = DateTime.Now.Date;
            this.Text = $"Select an Appointment or a Customer";
            //this.gridView1.ViewCaption = $"Appointments for - {((DateTime)this.CurrentDateDateEdit.EditValue).ToShortDateString()}";
        }

    private void SelectCustomerForm_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void CancelSimpleButton_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        private void OKSimpleButton_Click(object sender, EventArgs e)
        {
            this.OK();
        }

        private void CustomerSearchTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.CustomerSearch();
        }

        private void LoadData()
        {
            this.LoadStaffData();
            this.LoadCustomerData();
            this.LoadAppointmentData();
            this.RefreshControls();
        }

        private void LoadStaffData()
        {
            this.staffCollection1 = SalonDB.Data.DBProviderES.GetStaffs(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.StaffBindingSource.DataSource = this.staffCollection1;
        }

        private void LoadCustomerData()
        {
            this.customerCollection1 = SalonDB.Data.DBProviderES.GetCustomersOrderByFirstLastPhone(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID);
            this.CustomerBindingSource.DataSource = this.customerCollection1;
        }

        private void LoadAppointmentData()
        {
            var Date = (DateTime)this.CurrentDateDateEdit.EditValue;
            var DateFrom = Date.Date;
            var DateTo = DateFrom.AddHours(23).AddMinutes(59).AddSeconds(59);

            if (ShowAllDatesCheckEdit.Checked)
            {
                DateFrom = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
                DateTo = System.Data.SqlTypes.SqlDateTime.MaxValue.Value;
            }

            this.appointmentCollection1 = SalonDB.Data.DBProviderES.GetAppointments(SalonDB.Win.Forms.MainForm.LoggedInUser.CompanyID, DateFrom, DateTo);
            this.AppointmentBindingSource.DataSource = this.appointmentCollection1;
        }

        private void Cancel()
        {
            ReturnValue = null;
            this.Close();
        }

        private void OK()
        {
            if (ReturnValue.AppointmentEnt != null || ReturnValue.CustomerEnt != null)
            {
                this.Close();
            }

        }

        private void CustomerSearch()
        {
            var SearchValue = this.CustomerSearchTextEdit.EditValue.ToString().ToLower();
            ReturnValue.CustomerEnt = null;

            if (SearchValue.Length > 0)
            {
                ReturnValue.CustomerEnt = (from oRow in this.customerCollection1 where (oRow.FirstName != null && oRow.FirstName.ToLower().Contains(SearchValue)) || (oRow.LastName != null && oRow.LastName.ToLower().Contains(SearchValue)) || (oRow.Phone != null && oRow.Phone.Replace("-","").Replace(".","").ToLower().Contains(SearchValue)) || (oRow.Email != null && oRow.Email.ToLower().Contains(SearchValue)) select oRow).FirstOrDefault();
            }

            if (ReturnValue.CustomerEnt == null)
            {
                this.FirstNameTextEdit.EditValue = null;
                this.LastNameTextEdit.EditValue = null;
                this.PhoneTextEdit.EditValue = null;
                this.EmailTextEdit.EditValue = null;
            }
            else 
            {
                this.FirstNameTextEdit.EditValue = ReturnValue.CustomerEnt.FirstName;
                this.LastNameTextEdit.EditValue = ReturnValue.CustomerEnt.LastName;
                this.PhoneTextEdit.EditValue = ReturnValue.CustomerEnt.Phone;
                this.EmailTextEdit.EditValue = ReturnValue.CustomerEnt.Email;
            }

            this.RefreshControls();
        }

        private void RefreshControls()
        {
            this.OKSimpleButton.Enabled = ReturnValue != null && (ReturnValue.CustomerEnt != null || ReturnValue.AppointmentEnt != null);
        }

        private void gridView1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (ShowHotTracking)
            {
                GridView view = sender as GridView;
                GridHitInfo info = view.CalcHitInfo(new Point(e.X, e.Y));

                if (info.InRowCell)
                    HotTrackRow = info.RowHandle;
                else
                    HotTrackRow = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (ShowHotTracking && e.RowHandle == HotTrackRow)
                e.Appearance.BackColor = Color.LightBlue;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ReturnValue.AppointmentEnt = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Appointment;
            this.RefreshControls();
        }

        private void CurrentDateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.LoadAppointmentData();
        }

        private void ShowAllDatesCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadAppointmentData();
        }

        private void searchLookUpEdit1_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= popupForm_KeyUp;
            popupForm.KeyUp += popupForm_KeyUp;
        }

        void popupForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }
    }
}