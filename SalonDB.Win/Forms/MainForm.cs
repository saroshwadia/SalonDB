using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EntitySpaces.Interfaces;
using BusinessObjects;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.PivotGrid;
using DevExpress.XtraReports.UserDesigner;

namespace SalonDB.Win.Forms
{
    public partial class MainForm : BaseForm
    {

        public static Staff LoggedInUser = null;
        private const string conLoginText = "Login";
        private const string conLogoutText = "Logout";
        private bool CheckToggleLogInOut = true;
        private string SkinName = "McSkin"; //"Office 2010 Silver";

        public MainForm()
        {
            InitializeComponent();
            this.ConnectToDB();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.AddSkinPopup();
        }

        private void ConnectToDB()
        {
            SalonDB.Data.DBProviderES.ConnectToDB();
        }

        private void LoadData()
        {
            this.RefreshControls();
        }

        private void AddSkinPopup()
        {
            //var oCustomSkinPopupGalleryEdit = new CustomSkinPopupGalleryEdit();
            //oCustomSkinPopupGalleryEdit.Visible = true;
            //oCustomSkinPopupGalleryEdit.Location = new Point(100, 100);

            //this.Controls.Add(oCustomSkinPopupGalleryEdit);

            SkinHelper.InitSkinGallery(this.SkinsPopupGalleryEdit,false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle(SkinName);
            this.SetSkinName();

        }
        private Random gen = new Random();

        DateTime RandomDay()
        {
            DateTime start = new DateTime(2016, 1, 1);
            DateTime end = new DateTime(2016,12, 12);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        private void AddService()
        {


                 TransactionCollection tc = new TransactionCollection();
            ServiceCollection SCol = new ServiceCollection();
            SCol.LoadAll();
            List<Service> sList = new List<Service>();
            sList = SCol.ToList();
            Random rnd = new Random();
     

            tc.LoadAll();
            int i = 0;
            foreach (Transaction t in tc)
            {
                if (i == 1)
                {
                    i = 0;
                    continue;
                }

                if (i == 0)
                {
                    i += 1;
                    TransactionDetailService ts = new TransactionDetailService();
                    ts.TransactionID = t.TransactionID;
                    int j = rnd.Next(1, SCol.Count);
                    ts.ServiceID = SCol[j].ServiceID;
                    ts.Name = SCol[j].Name;
                    ts.Description = SCol[j].Description;
                    ts.UnitPrice = SCol[j].Price;
                    ts.Quantity = 1;
                    ts.Duration = SCol[j].Duration;
                    ts.ShowOnline= SCol[j].ShowOnline;

                    t.TransactionDetailServiceCollectionByTransactionID.Add(ts);
                    

                }
               
            }
            tc.Save();

            //ProductCollection PCol = new ProductCollection();
            //                  PCol.LoadAll();
            //                  List<Product> pList = new List<Product>();
            //          pList = PCol.ToList();

            //          int PCount =0;

            //          for (int i = 1; i < 50; i++)
            //          {
            //              Transaction t = new Transaction();
            //                  t.TransactionDate = RandomDay();
            //                  t.CompanyID = new Guid("bad47e3c-381b-452b-bda6-03dfab26a4c8");
            //              decimal Amount = 0; 

            //              for (int j = 1; j <= 50; j++)
            //              {

            //               if (PCount == 11)
            //                      PCount = 0;
            //                  else
            //                      PCount += 1;
            //                  TransactionDetailProduct td = new TransactionDetailProduct();



            //                  //td.CompanyID = new Guid("bad47e3c-381b-452b-bda6-03dfab26a4c8");

            //                  td.Name =pList[PCount].Name; // "Damage Remedy™ Daily Hair Repair";
            //                  td.Description = pList[PCount].Description;
            //                  td.ProductID = pList[PCount].ProductID;
            //                  td.UnitPrice = 5 * i;
            //                  td.Quantity = PCount;


            //                  Amount = Convert.ToDecimal( Amount + (PCount * td.UnitPrice));

            //                  td.WholesalePrice = 5 + i;
            //                  td.Commission = i;

            //                  t.TransactionDetailProductCollectionByTransactionID.Add(td);



            //              }

            //              t.Amount = Amount;
            //              tc.Add(t);
            //              tc.Save();



            //          }
        }

        private void RefreshControls()
        {


            //AddService();

  //          TransactionCollection tc = new TransactionCollection();
  //ProductCollection PCol = new ProductCollection();
  //                  PCol.LoadAll();
  //                  List<Product> pList = new List<Product>();
  //          pList = PCol.ToList();

        //          int PCount =0;

        //          for (int i = 1; i < 50; i++)
        //          {
        //              Transaction t = new Transaction();
        //                  t.TransactionDate = RandomDay();
        //                  t.CompanyID = new Guid("bad47e3c-381b-452b-bda6-03dfab26a4c8");
        //              decimal Amount = 0; 

        //              for (int j = 1; j <= 50; j++)
        //              {

        //               if (PCount == 11)
        //                      PCount = 0;
        //                  else
        //                      PCount += 1;
        //                  TransactionDetailProduct td = new TransactionDetailProduct();



        //                  //td.CompanyID = new Guid("bad47e3c-381b-452b-bda6-03dfab26a4c8");

        //                  td.Name =pList[PCount].Name; // "Damage Remedy™ Daily Hair Repair";
        //                  td.Description = pList[PCount].Description;
        //                  td.ProductID = pList[PCount].ProductID;
        //                  td.UnitPrice = 5 * i;
        //                  td.Quantity = PCount;


        //                  Amount = Convert.ToDecimal( Amount + (PCount * td.UnitPrice));

        //                  td.WholesalePrice = 5 + i;
        //                  td.Commission = i;

        //                  t.TransactionDetailProductCollectionByTransactionID.Add(td);



        //              }

        //              t.Amount = Amount;
        //              tc.Add(t);
        //              tc.Save();



        //          }

        var LoginName = "Not Logged in";
            var IsUserLoggedIn = false;

            if (MainForm.LoggedInUser != null)
            {
                LoginName = $"{MainForm.LoggedInUser.FirstName} {MainForm.LoggedInUser.LastName}";
                IsUserLoggedIn = true;
            }

            this.LoggedInAsTextEdit.Text = $"{LoginName}";
            this.AppointmentCheckButton.Enabled = IsUserLoggedIn;
            this.POSCheckButton.Enabled = IsUserLoggedIn;
            this.AdministrationCheckButton.Enabled = IsUserLoggedIn;
            this.ReportscheckButton.Enabled = IsUserLoggedIn;
            CheckToggleLogInOut = false;
            this.LogInOutCheckButton.Checked = IsUserLoggedIn;
            CheckToggleLogInOut = true;

        }

        private void AppointmentCheckButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AppointmentCheckButton.Checked)
            {
                this.OpenForm(new AppointmentForm(), true);
            }
            else
            {
                this.CloseForm(new AppointmentForm(), true);
            }
        }

        private void POSCheckButton_CheckedChanged(object sender, EventArgs e)
        {
            if (POSCheckButton.Checked)
            {
                this.OpenForm(new POSForm(), true);
            }
            else
            {
                this.CloseForm(new POSForm(), true);
            }
        }

        private void AdministrationCheckButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AdministrationCheckButton.Checked)
            {
                this.OpenForm(new AdminForm(), true);
            }
            else
            {
                this.CloseForm(new AdminForm(), true);
            }
        }

        private void LogInOutCheckButton_CheckedChanged(object sender, EventArgs e)
        {
            this.ToggleLogInOut();
        }

        private bool IsFormOpen(BaseForm oForm, bool closeForm = false)
        {
            var ReturnValue = false;

            foreach (var oChildForm in this.MdiChildren)
            {
                if (oChildForm.Name == oForm.Name)
                {
                    ReturnValue = true;
                    if (closeForm)
                    {
                        oChildForm.Close();
                    }
                    break;
                }
            }

            return ReturnValue;
        }

        private void CloseForm(BaseForm oForm, bool singleInstance)
        {
            this.IsFormOpen(oForm, true);
        }

        private void OpenForm(BaseForm oForm, bool singleInstance)
        {
            var FormAlreadyOpen = false;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                oForm.Cursor = Cursors.WaitCursor;

                if (singleInstance)
                {
                    FormAlreadyOpen = this.IsFormOpen(oForm);
                }

                if (FormAlreadyOpen)
                {
                    oForm.Activate();
                }
                else
                {

                    oForm.FormClosed += ChildForm_FormClosed;
                    oForm.MdiParent = this;
                    oForm.Show();
                }
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

        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var oForm = sender as BaseForm;
            oForm.FormClosed -= ChildForm_FormClosed;

            if (oForm.GetType() == typeof(AppointmentForm))
            {
                this.AppointmentCheckButton.Checked = false;
            }

            if (oForm.GetType() == typeof(AdminForm))
            {
                this.AdministrationCheckButton.Checked = false;
            }


            if (oForm.GetType() == typeof(POSForm))
            {
                this.POSCheckButton.Checked = false;
            }

            if (oForm.GetType() == typeof(ReportsMainForm))
            {
                this.ReportscheckButton.Checked = false;
            }

        }

        private void TryCloseOpenForms()
        {
            foreach (var oChildForm in this.MdiChildren)
            {
                oChildForm.Close();
            }
        }

        private void ToggleLogInOut()
        {
            if (CheckToggleLogInOut)
            {
                if (this.LogInOutCheckButton.Text == conLoginText)
                {
                    this.Login();
                }
                else
                {
                    this.Logout();
                }
            }
        }

        private void Logout()
        {
            this.TryCloseOpenForms();
            MainForm.LoggedInUser = null;
            this.LogInOutCheckButton.Text = conLoginText;
            this.RefreshControls();
        }

        private void Login()
        {
            var oFrom = new LoginForm();
            try
            {
                TryCloseOpenForms();
                if (this.MdiChildren.Length > 0)
                {
                    XtraMessageBox.Show("Close all open Forms and try again.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    oFrom.ShowDialog();
                    if (oFrom.ReturnValue != null)
                    {
                        MainForm.LoggedInUser = oFrom.ReturnValue;
                        this.LogInOutCheckButton.Text = conLogoutText;
                    }
                }
                this.RefreshControls();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Cannot continue due to the following Error{Environment.NewLine}{Environment.NewLine}{ex.Message}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SkinsPopupGalleryEdit_EditValueChanged(object sender, EventArgs e)
        {
            this.SetSkinName();
        }

        private void SetSkinName()
        {
            SkinsPopupGalleryEdit.EditValue = UserLookAndFeel.Default.ActiveSkinName;
        }

        private void ReportscheckButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ReportscheckButton.Checked)
            {
                this.OpenForm(new ReportsMainForm(), true);
            }
            else
            {
                this.CloseForm(new ReportsMainForm(), true);
            }
        }
    }
}