namespace SalonDB.Win.Reports
{
    partial class InventoryReport
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.lbTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 34.79167F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.BackColor = System.Drawing.Color.White;
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Bookmark", null, "Suppliers.SuppliersProducts.ProductName")});
            this.xrTable1.Dpi = 100F;
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable1.KeepTogether = true;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(714F, 34.79167F);
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell3,
            this.xrTableCell10});
            this.xrTableRow1.Dpi = 100F;
            this.xrTableRow1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic);
            this.xrTableRow1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(196)))));
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableRow1.Weight = 0.48D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.BackColor = System.Drawing.Color.White;
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Name")});
            this.xrTableCell5.Dpi = 100F;
            this.xrTableCell5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell5.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell5.StylePriority.UseBackColor = false;
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.StylePriority.UseForeColor = false;
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell5.Weight = 0.16973119084513663D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.BackColor = System.Drawing.Color.White;
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Description")});
            this.xrTableCell6.Dpi = 100F;
            this.xrTableCell6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell6.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell6.StylePriority.UseBackColor = false;
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.StylePriority.UseForeColor = false;
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.Weight = 0.30251337110390464D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.BackColor = System.Drawing.Color.White;
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Commission")});
            this.xrTableCell8.Dpi = 100F;
            this.xrTableCell8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell8.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell8.StylePriority.UseBackColor = false;
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseForeColor = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell8.Weight = 0.13914740700646069D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BackColor = System.Drawing.Color.White;
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Price")});
            this.xrTableCell9.Dpi = 100F;
            this.xrTableCell9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell9.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell9.StylePriority.UseBackColor = false;
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseForeColor = false;
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 0.16016321122366167D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.BackColor = System.Drawing.Color.White;
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "UnitsInStock")});
            this.xrTableCell3.Dpi = 100F;
            this.xrTableCell3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell3.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell3.StylePriority.UseBackColor = false;
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseForeColor = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 0.13131372104022271D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.BackColor = System.Drawing.Color.White;
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "UnitsOnOrder")});
            this.xrTableCell10.Dpi = 100F;
            this.xrTableCell10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell10.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UseBackColor = false;
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UseForeColor = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell10.Weight = 0.15272947880551505D;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbTitle,
            this.xrPageInfo2});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 101F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbTitle
            // 
            this.lbTitle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lbTitle.Dpi = 100F;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 18F);
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.lbTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62F);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTitle.SizeF = new System.Drawing.SizeF(206.75F, 38F);
            this.lbTitle.Text = "Inventory Report";
            this.lbTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrPageInfo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.xrPageInfo2.Format = "{0:\"Date: \" dddd, dd MMMM yyyy}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(357.9999F, 78.00001F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(292F, 23F);
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(BusinessObjects.ProductCollection);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 40.625F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable4
            // 
            this.xrTable4.BackColor = System.Drawing.Color.Transparent;
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Bookmark", null, "Suppliers.SuppliersProducts.ProductName")});
            this.xrTable4.Dpi = 100F;
            this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrTable4.KeepTogether = true;
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow14});
            this.xrTable4.SizeF = new System.Drawing.SizeF(714F, 40.625F);
            this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableRow14
            // 
            this.xrTableRow14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell1,
            this.xrTableCell2});
            this.xrTableRow14.Dpi = 100F;
            this.xrTableRow14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic);
            this.xrTableRow14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(196)))));
            this.xrTableRow14.Name = "xrTableRow14";
            this.xrTableRow14.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrTableRow14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableRow14.Weight = 0.48D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Dpi = 100F;
            this.xrTableCell11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell11.Text = "Name";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell11.Weight = 0.12480803458921369D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Dpi = 100F;
            this.xrTableCell12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell12.Text = "Description";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell12.Weight = 0.226896034716245D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Dpi = 100F;
            this.xrTableCell13.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell13.Text = "Commission";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell13.Weight = 0.10362999280126028D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Dpi = 100F;
            this.xrTableCell14.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell14.Text = "Unit Price";
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell14.Weight = 0.11928150365180448D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Units in Stock";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.097795934571887455D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Units on Order";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 0.11374519833286342D;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 100F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic);
            this.xrPageInfo1.Format = "{0} of {1} pages";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(563.0001F, 10.00001F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(151F, 17F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.Text = "Total";
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // InventoryReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(64, 72, 101, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRLabel lbTitle;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRTable xrTable4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
    }
}
