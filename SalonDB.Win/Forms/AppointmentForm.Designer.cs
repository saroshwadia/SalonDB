namespace SalonDB.Win
{
    partial class AppointmentForm
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
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.UseResourceColorsCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseResourceColorsCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.schedulerControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1209, 729);
            this.splitContainerControl1.SplitterPosition = 241;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.dateNavigator1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.UseResourceColorsCheckEdit);
            this.splitContainerControl2.Panel2.Controls.Add(this.radioGroup2);
            this.splitContainerControl2.Panel2.Controls.Add(this.radioGroup1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(241, 729);
            this.splitContainerControl2.SplitterPosition = 255;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.AllowAnimatedContentChange = true;
            this.dateNavigator1.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dateNavigator1.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.schedulerControl1;
            this.dateNavigator1.Size = new System.Drawing.Size(241, 255);
            this.dateNavigator1.TabIndex = 0;
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.Custom;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.Custom;
            this.schedulerControl1.OptionsView.ToolTipVisibility = DevExpress.XtraScheduler.ToolTipVisibility.Always;
            this.schedulerControl1.Size = new System.Drawing.Size(963, 729);
            this.schedulerControl1.Start = new System.DateTime(2016, 12, 19, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage1;
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.ToolTipController = this.toolTipController1;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.Enabled = true;
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schedulerControl1.AllowAppointmentDrag += new DevExpress.XtraScheduler.AppointmentOperationEventHandler(this.schedulerControl1_AllowAppointmentDrag);
            this.schedulerControl1.AllowAppointmentDelete += new DevExpress.XtraScheduler.AppointmentOperationEventHandler(this.schedulerControl1_AllowAppointmentDelete);
            this.schedulerControl1.AllowAppointmentEdit += new DevExpress.XtraScheduler.AppointmentOperationEventHandler(this.schedulerControl1_AllowAppointmentEdit);
            this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "EndTime";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "StaffID";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartTime";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.TimeZoneId = "StartTimeZone";
            this.schedulerStorage1.Resources.Mappings.Caption = "FirstName";
            this.schedulerStorage1.Resources.Mappings.Color = "ResourceColor";
            this.schedulerStorage1.Resources.Mappings.Id = "StaffID";
            this.schedulerStorage1.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsInserted);
            this.schedulerStorage1.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsChanged);
            this.schedulerStorage1.AppointmentDeleting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.schedulerStorage1_AppointmentDeleting);
            this.schedulerStorage1.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerStorage1_AppointmentsDeleted);
            // 
            // toolTipController1
            // 
            this.toolTipController1.AllowHtmlText = true;
            this.toolTipController1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolTipController1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.toolTipController1.Appearance.BorderColor = System.Drawing.Color.Black;
            this.toolTipController1.Appearance.Options.UseBackColor = true;
            this.toolTipController1.Appearance.Options.UseBorderColor = true;
            this.toolTipController1.KeepWhileHovered = true;
            this.toolTipController1.Rounded = true;
            this.toolTipController1.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            this.toolTipController1.BeforeShow += new DevExpress.Utils.ToolTipControllerBeforeShowEventHandler(this.toolTipController1_BeforeShow);
            // 
            // UseResourceColorsCheckEdit
            // 
            this.UseResourceColorsCheckEdit.Location = new System.Drawing.Point(0, 187);
            this.UseResourceColorsCheckEdit.Name = "UseResourceColorsCheckEdit";
            this.UseResourceColorsCheckEdit.Properties.Caption = "Use Resource Colors";
            this.UseResourceColorsCheckEdit.Size = new System.Drawing.Size(241, 19);
            this.UseResourceColorsCheckEdit.TabIndex = 2;
            this.UseResourceColorsCheckEdit.EditValueChanged += new System.EventHandler(this.UseResourceColorsCheckEdit_EditValueChanged);
            // 
            // radioGroup2
            // 
            this.radioGroup2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroup2.Location = new System.Drawing.Point(0, 88);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Size = new System.Drawing.Size(241, 82);
            this.radioGroup2.TabIndex = 1;
            this.radioGroup2.SelectedIndexChanged += new System.EventHandler(this.radioGroup2_SelectedIndexChanged);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroup1.Location = new System.Drawing.Point(0, 0);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Size = new System.Drawing.Size(241, 82);
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 729);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "AppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Appointments";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseResourceColorsCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.RadioGroup radioGroup2;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.CheckEdit UseResourceColorsCheckEdit;
    }
}

