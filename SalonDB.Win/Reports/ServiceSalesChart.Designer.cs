namespace SalonDB.Win.Reports
{
    partial class ServiceSalesChart
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.MonthLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.objectDataSource2 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 4.666646F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo3,
            this.xrLabel1});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 106.5417F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Dpi = 100F;
            this.xrPageInfo3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrPageInfo3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.xrPageInfo3.Format = "{0:\"Date: \" dddd, dd MMMM yyyy}";
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(710.0417F, 83.54166F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(240.9583F, 23F);
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 18F);
            this.xrLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 68.54167F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(358F, 38F);
            this.xrLabel1.Text = "Service Sales Chart (Monthly)";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 55.83331F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.MonthLabel});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Month", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 51.12502F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Month")});
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(409.0417F, 10.00001F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel2.Visible = false;
            // 
            // MonthLabel
            // 
            this.MonthLabel.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.MonthLabel.Dpi = 100F;
            this.MonthLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.MonthLabel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.MonthLabel.Name = "MonthLabel";
            this.MonthLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.MonthLabel.SizeF = new System.Drawing.SizeF(358F, 38F);
            this.MonthLabel.StylePriority.UseFont = false;
            this.MonthLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            this.MonthLabel.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthLabel_BeforePrint);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart1});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 628.9584F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.GroupFooter1_BeforePrint);
            // 
            // xrChart1
            // 
            this.xrChart1.BorderColor = System.Drawing.Color.Black;
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart1.DataSource = this.objectDataSource2;
            xyDiagram1.AxisX.Tickmarks.MinorVisible = false;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart1.Diagram = xyDiagram1;
            this.xrChart1.Dpi = 100F;
            this.xrChart1.Legend.Name = "Default Legend";
            this.xrChart1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 43.75F);
            this.xrChart1.Name = "xrChart1";
            series1.ArgumentDataMember = "Name";
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.Name = "Series 1";
            series1.ValueDataMembersSerializable = "Amount";
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.xrChart1.SizeF = new System.Drawing.SizeF(918.0833F, 585.2084F);
            this.xrChart1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrChart1_BeforePrint);
            // 
            // objectDataSource2
            // 
            this.objectDataSource2.DataSource = typeof(BusinessObjects.ServiceTransactionsViewCollection);
            this.objectDataSource2.Name = "objectDataSource2";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(BusinessObjects.ServiceCollection);
            // 
            // ServiceSalesChart
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource2});
            this.DataSource = this.objectDataSource2;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(49, 100, 107, 56);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ServiceSalesChart_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel MonthLabel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource2;
        private DevExpress.XtraReports.UI.XRChart xrChart1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
