namespace SalonDB.Win.Forms
{
    partial class AdminForm
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
            this.ActivityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.ProductaccControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ServiceaccControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ClientaccControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.StaffaccControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.SupplieraccControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.StoreaccControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.CompanyaccControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.TransactionaccControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.ActivityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.accordionControl1);
            this.splitContainer1.Size = new System.Drawing.Size(982, 463);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ProductaccControlElement,
            this.ServiceaccControlElement,
            this.ClientaccControlElement,
            this.StaffaccControlElement,
            this.SupplieraccControlElement,
            this.StoreaccControlElement,
            this.CompanyaccControlElement,
            this.TransactionaccControlElement});
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.Size = new System.Drawing.Size(239, 463);
            this.accordionControl1.TabIndex = 0;
            this.accordionControl1.Text = "accordionControl1";
            // 
            // ProductaccControlElement
            // 
            this.ProductaccControlElement.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.ProductaccControlElement.Name = "ProductaccControlElement";
            this.ProductaccControlElement.Text = "Product";
            this.ProductaccControlElement.Click += new System.EventHandler(this.ProductaccControlElement_Click);
            // 
            // ServiceaccControlElement
            // 
            this.ServiceaccControlElement.Name = "ServiceaccControlElement";
            this.ServiceaccControlElement.Text = "Service";
            this.ServiceaccControlElement.Click += new System.EventHandler(this.ServiceaccControlElement_Click);
            // 
            // ClientaccControlElement
            // 
            this.ClientaccControlElement.Name = "ClientaccControlElement";
            this.ClientaccControlElement.Text = "Client";
            this.ClientaccControlElement.Click += new System.EventHandler(this.ClientaccControlElement_Click);
            // 
            // StaffaccControlElement
            // 
            this.StaffaccControlElement.Name = "StaffaccControlElement";
            this.StaffaccControlElement.Text = "Staff";
            this.StaffaccControlElement.Click += new System.EventHandler(this.StaffaccControlElement_Click);
            // 
            // SupplieraccControlElement
            // 
            this.SupplieraccControlElement.Name = "SupplieraccControlElement";
            this.SupplieraccControlElement.Text = "Supplier";
            this.SupplieraccControlElement.Click += new System.EventHandler(this.SupplieraccControlElement_Click);
            // 
            // StoreaccControlElement
            // 
            this.StoreaccControlElement.Name = "StoreaccControlElement";
            this.StoreaccControlElement.Text = "Store";
            this.StoreaccControlElement.Click += new System.EventHandler(this.StoreaccControlElement_Click);
            // 
            // CompanyaccControlElement
            // 
            this.CompanyaccControlElement.Expanded = true;
            this.CompanyaccControlElement.Name = "CompanyaccControlElement";
            this.CompanyaccControlElement.Text = "Company";
            this.CompanyaccControlElement.Click += new System.EventHandler(this.CompanyaccControlElement_Click);
            // 
            // TransactionaccControlElement
            // 
            this.TransactionaccControlElement.Expanded = true;
            this.TransactionaccControlElement.Name = "TransactionaccControlElement";
            this.TransactionaccControlElement.Text = "Transactions";
            this.TransactionaccControlElement.Click += new System.EventHandler(this.TransactionaccControlElement_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 463);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administration";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ActivityBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource ActivityBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ProductaccControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ServiceaccControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ClientaccControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement StaffaccControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement SupplieraccControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement StoreaccControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement CompanyaccControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement TransactionaccControlElement;
    }
}