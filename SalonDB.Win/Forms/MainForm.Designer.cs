namespace SalonDB.Win.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.MenuGroupControl = new DevExpress.XtraEditors.GroupControl();
            this.ReportscheckButton = new DevExpress.XtraEditors.CheckButton();
            this.sharedImageCollection1 = new DevExpress.Utils.SharedImageCollection(this.components);
            this.POSCheckButton = new DevExpress.XtraEditors.CheckButton();
            this.AdministrationCheckButton = new DevExpress.XtraEditors.CheckButton();
            this.AppointmentCheckButton = new DevExpress.XtraEditors.CheckButton();
            this.LogInOutCheckButton = new DevExpress.XtraEditors.CheckButton();
            this.StatusGroupControl = new DevExpress.XtraEditors.GroupControl();
            this.SkinsLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.SkinsPopupGalleryEdit = new SalonDB.Win.CustomSkinPopupGalleryEdit();
            this.LoggedInAsTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LoggedInAsLabelControl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuGroupControl)).BeginInit();
            this.MenuGroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1.ImageSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusGroupControl)).BeginInit();
            this.StatusGroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkinsPopupGalleryEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggedInAsTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // MenuGroupControl
            // 
            this.MenuGroupControl.Controls.Add(this.ReportscheckButton);
            this.MenuGroupControl.Controls.Add(this.POSCheckButton);
            this.MenuGroupControl.Controls.Add(this.AdministrationCheckButton);
            this.MenuGroupControl.Controls.Add(this.AppointmentCheckButton);
            this.MenuGroupControl.Controls.Add(this.LogInOutCheckButton);
            this.MenuGroupControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuGroupControl.Location = new System.Drawing.Point(0, 0);
            this.MenuGroupControl.Name = "MenuGroupControl";
            this.MenuGroupControl.Size = new System.Drawing.Size(1184, 65);
            this.MenuGroupControl.TabIndex = 0;
            this.MenuGroupControl.Text = "Menu";
            // 
            // ReportscheckButton
            // 
            this.ReportscheckButton.Image = ((System.Drawing.Image)(resources.GetObject("ReportscheckButton.Image")));
            this.ReportscheckButton.ImageList = this.sharedImageCollection1;
            this.ReportscheckButton.Location = new System.Drawing.Point(447, 24);
            this.ReportscheckButton.Name = "ReportscheckButton";
            this.ReportscheckButton.Size = new System.Drawing.Size(139, 36);
            this.ReportscheckButton.TabIndex = 6;
            this.ReportscheckButton.Text = "Reports";
            this.ReportscheckButton.CheckedChanged += new System.EventHandler(this.ReportscheckButton_CheckedChanged);
            // 
            // sharedImageCollection1
            // 
            // 
            // 
            // 
            this.sharedImageCollection1.ImageSource.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("sharedImageCollection1.ImageSource.ImageStream")));
            this.sharedImageCollection1.ParentControl = this;
            // 
            // POSCheckButton
            // 
            this.POSCheckButton.Image = ((System.Drawing.Image)(resources.GetObject("POSCheckButton.Image")));
            this.POSCheckButton.ImageList = this.sharedImageCollection1;
            this.POSCheckButton.Location = new System.Drawing.Point(157, 23);
            this.POSCheckButton.Name = "POSCheckButton";
            this.POSCheckButton.Size = new System.Drawing.Size(139, 36);
            this.POSCheckButton.TabIndex = 5;
            this.POSCheckButton.Text = "POS";
            this.POSCheckButton.CheckedChanged += new System.EventHandler(this.POSCheckButton_CheckedChanged);
            // 
            // AdministrationCheckButton
            // 
            this.AdministrationCheckButton.Image = ((System.Drawing.Image)(resources.GetObject("AdministrationCheckButton.Image")));
            this.AdministrationCheckButton.ImageList = this.sharedImageCollection1;
            this.AdministrationCheckButton.Location = new System.Drawing.Point(302, 24);
            this.AdministrationCheckButton.Name = "AdministrationCheckButton";
            this.AdministrationCheckButton.Size = new System.Drawing.Size(139, 36);
            this.AdministrationCheckButton.TabIndex = 4;
            this.AdministrationCheckButton.Text = "Administration";
            this.AdministrationCheckButton.CheckedChanged += new System.EventHandler(this.AdministrationCheckButton_CheckedChanged);
            // 
            // AppointmentCheckButton
            // 
            this.AppointmentCheckButton.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("AppointmentCheckButton.Appearance.Image")));
            this.AppointmentCheckButton.Appearance.Options.UseImage = true;
            this.AppointmentCheckButton.Image = ((System.Drawing.Image)(resources.GetObject("AppointmentCheckButton.Image")));
            this.AppointmentCheckButton.ImageList = this.sharedImageCollection1;
            this.AppointmentCheckButton.Location = new System.Drawing.Point(12, 23);
            this.AppointmentCheckButton.Name = "AppointmentCheckButton";
            this.AppointmentCheckButton.Size = new System.Drawing.Size(139, 36);
            this.AppointmentCheckButton.TabIndex = 3;
            this.AppointmentCheckButton.Text = "Appointments";
            this.AppointmentCheckButton.CheckedChanged += new System.EventHandler(this.AppointmentCheckButton_CheckedChanged);
            // 
            // LogInOutCheckButton
            // 
            this.LogInOutCheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogInOutCheckButton.Image = ((System.Drawing.Image)(resources.GetObject("LogInOutCheckButton.Image")));
            this.LogInOutCheckButton.ImageList = this.sharedImageCollection1;
            this.LogInOutCheckButton.Location = new System.Drawing.Point(1033, 23);
            this.LogInOutCheckButton.Name = "LogInOutCheckButton";
            this.LogInOutCheckButton.Size = new System.Drawing.Size(139, 36);
            this.LogInOutCheckButton.TabIndex = 2;
            this.LogInOutCheckButton.Text = "Login";
            this.LogInOutCheckButton.CheckedChanged += new System.EventHandler(this.LogInOutCheckButton_CheckedChanged);
            // 
            // StatusGroupControl
            // 
            this.StatusGroupControl.Controls.Add(this.SkinsLabelControl);
            this.StatusGroupControl.Controls.Add(this.SkinsPopupGalleryEdit);
            this.StatusGroupControl.Controls.Add(this.LoggedInAsTextEdit);
            this.StatusGroupControl.Controls.Add(this.LoggedInAsLabelControl);
            this.StatusGroupControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusGroupControl.Location = new System.Drawing.Point(0, 686);
            this.StatusGroupControl.Name = "StatusGroupControl";
            this.StatusGroupControl.Size = new System.Drawing.Size(1184, 55);
            this.StatusGroupControl.TabIndex = 1;
            this.StatusGroupControl.Text = "Status";
            // 
            // SkinsLabelControl
            // 
            this.SkinsLabelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SkinsLabelControl.Location = new System.Drawing.Point(985, 30);
            this.SkinsLabelControl.Name = "SkinsLabelControl";
            this.SkinsLabelControl.Size = new System.Drawing.Size(28, 13);
            this.SkinsLabelControl.TabIndex = 3;
            this.SkinsLabelControl.Text = "Skins:";
            // 
            // SkinsPopupGalleryEdit
            // 
            this.SkinsPopupGalleryEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SkinsPopupGalleryEdit.Location = new System.Drawing.Point(1019, 27);
            this.SkinsPopupGalleryEdit.Name = "SkinsPopupGalleryEdit";
            this.SkinsPopupGalleryEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SkinsPopupGalleryEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.SkinsPopupGalleryEdit.Size = new System.Drawing.Size(144, 20);
            this.SkinsPopupGalleryEdit.TabIndex = 2;
            this.SkinsPopupGalleryEdit.EditValueChanged += new System.EventHandler(this.SkinsPopupGalleryEdit_EditValueChanged);
            // 
            // LoggedInAsTextEdit
            // 
            this.LoggedInAsTextEdit.Enabled = false;
            this.LoggedInAsTextEdit.Location = new System.Drawing.Point(82, 27);
            this.LoggedInAsTextEdit.Name = "LoggedInAsTextEdit";
            this.LoggedInAsTextEdit.Size = new System.Drawing.Size(301, 20);
            this.LoggedInAsTextEdit.TabIndex = 1;
            // 
            // LoggedInAsLabelControl
            // 
            this.LoggedInAsLabelControl.Location = new System.Drawing.Point(12, 30);
            this.LoggedInAsLabelControl.Name = "LoggedInAsLabelControl";
            this.LoggedInAsLabelControl.Size = new System.Drawing.Size(64, 13);
            this.LoggedInAsLabelControl.TabIndex = 0;
            this.LoggedInAsLabelControl.Text = "Logged in as:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 741);
            this.Controls.Add(this.StatusGroupControl);
            this.Controls.Add(this.MenuGroupControl);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Salon Management";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuGroupControl)).EndInit();
            this.MenuGroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1.ImageSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusGroupControl)).EndInit();
            this.StatusGroupControl.ResumeLayout(false);
            this.StatusGroupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkinsPopupGalleryEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggedInAsTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraEditors.GroupControl MenuGroupControl;
        private DevExpress.XtraEditors.CheckButton LogInOutCheckButton;
        private DevExpress.XtraEditors.GroupControl StatusGroupControl;
        private DevExpress.XtraEditors.CheckButton AdministrationCheckButton;
        private DevExpress.XtraEditors.CheckButton AppointmentCheckButton;
        private DevExpress.XtraEditors.TextEdit LoggedInAsTextEdit;
        private DevExpress.XtraEditors.LabelControl LoggedInAsLabelControl;
        private DevExpress.Utils.SharedImageCollection sharedImageCollection1;
        private DevExpress.XtraEditors.LabelControl SkinsLabelControl;
        private CustomSkinPopupGalleryEdit SkinsPopupGalleryEdit;
        private DevExpress.XtraEditors.CheckButton POSCheckButton;
        private DevExpress.XtraEditors.CheckButton ReportscheckButton;
    }
}