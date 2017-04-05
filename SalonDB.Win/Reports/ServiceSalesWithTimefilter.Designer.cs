namespace SalonDB.Win.Reports
{
    partial class ServiceSalesWithTimefilter
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
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.objectDataSource2 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.FromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.ToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrChart2 = new DevExpress.XtraReports.UI.XRChart();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Service = new DevExpress.XtraReports.Parameters.Parameter();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // objectDataSource2
            // 
            this.objectDataSource2.DataSource = typeof(BusinessObjects.ServiceCollection);
            this.objectDataSource2.Name = "objectDataSource2";
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 4.166667F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrPageInfo3});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 122.9167F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 18F);
            this.xrLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 74.91666F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(459.0417F, 38F);
            this.xrLabel1.Text = "Sales overtime / Service";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Dpi = 100F;
            this.xrPageInfo3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrPageInfo3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.xrPageInfo3.Format = "{0:\"Date: \" dddd, dd MMMM yyyy}";
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(649.0417F, 89.91667F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(240.9583F, 23F);
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // FromDate
            // 
            this.FromDate.Description = "From Date";
            this.FromDate.Name = "FromDate";
            this.FromDate.Type = typeof(System.DateTime);
            this.FromDate.ValueInfo = "2016-01-01";
            // 
            // ToDate
            // 
            this.ToDate.Description = "To Date";
            this.ToDate.Name = "ToDate";
            this.ToDate.Type = typeof(System.DateTime);
            this.ToDate.ValueInfo = "2017-01-24";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart2});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 527.5F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrChart2
            // 
            this.xrChart2.BorderColor = System.Drawing.Color.Black;
            this.xrChart2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            xyDiagram1.AxisX.DateTimeScaleOptions.AggregateFunction = DevExpress.XtraCharts.AggregateFunction.Sum;
            xyDiagram1.AxisX.DateTimeScaleOptions.AutoGrid = false;
            xyDiagram1.AxisX.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Month;
            xyDiagram1.AxisX.DateTimeScaleOptions.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Month;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart2.Diagram = xyDiagram1;
            this.xrChart2.Dpi = 100F;
            this.xrChart2.Legend.Name = "Default Legend";
            this.xrChart2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 10.00001F);
            this.xrChart2.Name = "xrChart2";
            series1.ArgumentDataMember = "TransactionDate";
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.Name = "Service Sales";
            series1.ValueDataMembersSerializable = "Amount";
            this.xrChart2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.xrChart2.SizeF = new System.Drawing.SizeF(918.9167F, 418.125F);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 100F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // Service
            // 
            this.Service.Description = "Service";
            dynamicListLookUpSettings1.DataAdapter = null;
            dynamicListLookUpSettings1.DataMember = null;
            dynamicListLookUpSettings1.DataSource = this.objectDataSource2;
            dynamicListLookUpSettings1.DisplayMember = "Name";
            dynamicListLookUpSettings1.FilterString = null;
            dynamicListLookUpSettings1.ValueMember = "Name";
            this.Service.LookUpSettings = dynamicListLookUpSettings1;
            this.Service.Name = "Service";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(BusinessObjects.ServiceTransactionsTimefilterCollection);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // ServiceSalesWithTimefilter
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource2,
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.FilterString = "[TransactionDate] Between(?FromDate, ?ToDate) And [Name] = ?Service";
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(67, 81, 123, 100);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.FromDate,
            this.ToDate,
            this.Service});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo3;
        private DevExpress.XtraReports.Parameters.Parameter FromDate;
        private DevExpress.XtraReports.Parameters.Parameter ToDate;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource2;
        private DevExpress.XtraReports.Parameters.Parameter Service;
        private DevExpress.XtraReports.UI.XRChart xrChart2;
    }
}
