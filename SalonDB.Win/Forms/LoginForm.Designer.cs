namespace SalonDB.Win.Forms
{
    partial class LoginForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ShowHidecheckButton = new DevExpress.XtraEditors.CheckButton();
            this.CancelsimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.OKsimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.PasswordTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.EmailTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ShowHidecheckButton);
            this.layoutControl1.Controls.Add(this.CancelsimpleButton);
            this.layoutControl1.Controls.Add(this.OKsimpleButton);
            this.layoutControl1.Controls.Add(this.PasswordTextEdit);
            this.layoutControl1.Controls.Add(this.EmailTextEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(432, 153);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ShowHidecheckButton
            // 
            this.ShowHidecheckButton.Location = new System.Drawing.Point(370, 68);
            this.ShowHidecheckButton.Name = "ShowHidecheckButton";
            this.ShowHidecheckButton.Size = new System.Drawing.Size(50, 22);
            this.ShowHidecheckButton.StyleController = this.layoutControl1;
            this.ShowHidecheckButton.TabIndex = 8;
            this.ShowHidecheckButton.Text = "...";
            this.ShowHidecheckButton.CheckedChanged += new System.EventHandler(this.ShowHidecheckButton_CheckedChanged);
            // 
            // CancelsimpleButton
            // 
            this.CancelsimpleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelsimpleButton.Location = new System.Drawing.Point(340, 119);
            this.CancelsimpleButton.Name = "CancelsimpleButton";
            this.CancelsimpleButton.Size = new System.Drawing.Size(80, 22);
            this.CancelsimpleButton.StyleController = this.layoutControl1;
            this.CancelsimpleButton.TabIndex = 7;
            this.CancelsimpleButton.Text = "Cancel";
            this.CancelsimpleButton.Click += new System.EventHandler(this.CancelsimpleButton_Click);
            // 
            // OKsimpleButton
            // 
            this.OKsimpleButton.Location = new System.Drawing.Point(256, 119);
            this.OKsimpleButton.Name = "OKsimpleButton";
            this.OKsimpleButton.Size = new System.Drawing.Size(80, 22);
            this.OKsimpleButton.StyleController = this.layoutControl1;
            this.OKsimpleButton.TabIndex = 6;
            this.OKsimpleButton.Text = "OK";
            this.OKsimpleButton.Click += new System.EventHandler(this.OKsimpleButton_Click);
            // 
            // PasswordTextEdit
            // 
            this.PasswordTextEdit.Location = new System.Drawing.Point(12, 68);
            this.PasswordTextEdit.Name = "PasswordTextEdit";
            this.PasswordTextEdit.Properties.PasswordChar = '*';
            this.PasswordTextEdit.Size = new System.Drawing.Size(354, 20);
            this.PasswordTextEdit.StyleController = this.layoutControl1;
            this.PasswordTextEdit.TabIndex = 5;
            this.PasswordTextEdit.EditValueChanged += new System.EventHandler(this.PasswordTextEdit_EditValueChanged);
            // 
            // EmailTextEdit
            // 
            this.EmailTextEdit.Location = new System.Drawing.Point(12, 28);
            this.EmailTextEdit.Name = "EmailTextEdit";
            this.EmailTextEdit.Size = new System.Drawing.Size(354, 20);
            this.EmailTextEdit.StyleController = this.layoutControl1;
            this.EmailTextEdit.TabIndex = 4;
            this.EmailTextEdit.EditValueChanged += new System.EventHandler(this.EmailTextEdit_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(432, 153);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem1.Control = this.EmailTextEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(358, 40);
            this.layoutControlItem1.Text = "Email:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem2.Control = this.PasswordTextEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(358, 42);
            this.layoutControlItem2.Text = "Password:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.OKsimpleButton;
            this.layoutControlItem3.Location = new System.Drawing.Point(244, 107);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.CancelsimpleButton;
            this.layoutControlItem4.Location = new System.Drawing.Point(328, 107);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 107);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(244, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 82);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(412, 25);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ShowHidecheckButton;
            this.layoutControlItem5.Location = new System.Drawing.Point(358, 40);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(54, 42);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(54, 42);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = " ";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(358, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(54, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.OKsimpleButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelsimpleButton;
            this.ClientSize = new System.Drawing.Size(432, 153);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(448, 192);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(448, 192);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton CancelsimpleButton;
        private DevExpress.XtraEditors.SimpleButton OKsimpleButton;
        private DevExpress.XtraEditors.TextEdit PasswordTextEdit;
        private DevExpress.XtraEditors.TextEdit EmailTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.CheckButton ShowHidecheckButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}