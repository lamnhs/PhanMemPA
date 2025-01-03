namespace CMSUI.SystemConfiguration
{
    partial class frm_CMS_File
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_File));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditKhachHang = new DevExpress.XtraEditors.LookUpEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridViewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemLookUpEditNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEditTinhTrang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemCheckedComboBoxEditLamPhu = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemExit = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemKhachHang = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemFilter = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemRightFilter = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.cmsExcel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xToolStripMenuItemXuatExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.importExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTinhTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEditLamPhu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemRightFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.cmsExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnFilter);
            this.layoutControl.Controls.Add(this.lookUpEditKhachHang);
            this.layoutControl.Controls.Add(this.btnRefresh);
            this.layoutControl.Controls.Add(this.btnClose);
            this.layoutControl.Controls.Add(this.gridControlData);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(1284, 691);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // imageCollectionSmall
            // 
            this.imageCollectionSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionSmall.ImageStream")));
            this.imageCollectionSmall.Images.SetKeyName(0, "close_16x16.png");
            this.imageCollectionSmall.Images.SetKeyName(1, "refresh_16x16.png");
            this.imageCollectionSmall.Images.SetKeyName(2, "exporttoxlsx_16x16.png");
            this.imageCollectionSmall.Images.SetKeyName(3, "save_16x16.png");
            this.imageCollectionSmall.Images.SetKeyName(4, "saveandclose_16x16.png");
            this.imageCollectionSmall.Images.SetKeyName(5, "crossdatasourcefiltering _16x16.png");
            this.imageCollectionSmall.Images.SetKeyName(6, "apply_16x16.png");
            this.imageCollectionSmall.Images.SetKeyName(7, "cancel_16x16.png");
            this.imageCollectionSmall.Images.SetKeyName(8, "removesheetrows_16x16.png");
            // 
            // btnFilter
            // 
            this.btnFilter.AutoWidthInLayoutControl = true;
            this.btnFilter.ImageOptions.ImageIndex = 5;
            this.btnFilter.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnFilter.Location = new System.Drawing.Point(331, 10);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(77, 22);
            this.btnFilter.StyleController = this.layoutControl;
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Lọc dữ liệu";
            this.btnFilter.Click += new System.EventHandler(this.btn_LocDuLieu_Click);
            // 
            // lookUpEditKhachHang
            // 
            this.lookUpEditKhachHang.Location = new System.Drawing.Point(78, 10);
            this.lookUpEditKhachHang.Name = "lookUpEditKhachHang";
            this.lookUpEditKhachHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditKhachHang.Properties.NullText = "";
            this.lookUpEditKhachHang.Size = new System.Drawing.Size(249, 20);
            this.lookUpEditKhachHang.StyleController = this.layoutControl;
            this.lookUpEditKhachHang.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.ImageIndex = 1;
            this.btnRefresh.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnRefresh.Location = new System.Drawing.Point(11, 659);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(26, 22);
            this.btnRefresh.StyleController = this.layoutControl;
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.ImageOptions.ImageIndex = 0;
            this.btnClose.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnClose.Location = new System.Drawing.Point(1219, 659);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 22);
            this.btnClose.StyleController = this.layoutControl;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // gridControlData
            // 
            this.gridControlData.Location = new System.Drawing.Point(11, 36);
            this.gridControlData.MainView = this.gridViewData;
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditNhanVien,
            this.repositoryItemLookUpEditTinhTrang,
            this.repositoryItemCheckedComboBoxEditLamPhu});
            this.gridControlData.Size = new System.Drawing.Size(1262, 619);
            this.gridControlData.TabIndex = 4;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewData});
            // 
            // gridViewData
            // 
            this.gridViewData.GridControl = this.gridControlData;
            this.gridViewData.IndicatorWidth = 40;
            this.gridViewData.Name = "gridViewData";
            this.gridViewData.NewItemRowText = "Nhấn vào đây để thêm mới";
            this.gridViewData.OptionsView.ShowGroupPanel = false;
            this.gridViewData.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewData_CustomDrawRowIndicator);
            this.gridViewData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewData_KeyDown);
            // 
            // repositoryItemLookUpEditNhanVien
            // 
            this.repositoryItemLookUpEditNhanVien.AutoHeight = false;
            this.repositoryItemLookUpEditNhanVien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditNhanVien.Name = "repositoryItemLookUpEditNhanVien";
            // 
            // repositoryItemLookUpEditTinhTrang
            // 
            this.repositoryItemLookUpEditTinhTrang.AutoHeight = false;
            this.repositoryItemLookUpEditTinhTrang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditTinhTrang.Name = "repositoryItemLookUpEditTinhTrang";
            // 
            // repositoryItemCheckedComboBoxEditLamPhu
            // 
            this.repositoryItemCheckedComboBoxEditLamPhu.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEditLamPhu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEditLamPhu.Name = "repositoryItemCheckedComboBoxEditLamPhu";
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemGrid,
            this.layoutControlItemExit,
            this.layoutControlItemRefresh,
            this.layoutControlItemKhachHang,
            this.layoutControlItemFilter,
            this.emptySpaceItemRightFilter,
            this.emptySpaceItem1});
            this.layoutControlGroup.Name = "Root";
            this.layoutControlGroup.Size = new System.Drawing.Size(1284, 691);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItemGrid
            // 
            this.layoutControlItemGrid.Control = this.gridControlData;
            this.layoutControlItemGrid.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItemGrid.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItemGrid.Name = "layoutControlItemGrid";
            this.layoutControlItemGrid.Size = new System.Drawing.Size(1266, 623);
            this.layoutControlItemGrid.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemGrid.TextVisible = false;
            // 
            // layoutControlItemExit
            // 
            this.layoutControlItemExit.Control = this.btnClose;
            this.layoutControlItemExit.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItemExit.Location = new System.Drawing.Point(1208, 649);
            this.layoutControlItemExit.Name = "layoutControlItemExit";
            this.layoutControlItemExit.Size = new System.Drawing.Size(58, 26);
            this.layoutControlItemExit.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemExit.TextVisible = false;
            // 
            // layoutControlItemRefresh
            // 
            this.layoutControlItemRefresh.Control = this.btnRefresh;
            this.layoutControlItemRefresh.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItemRefresh.Location = new System.Drawing.Point(0, 649);
            this.layoutControlItemRefresh.MaxSize = new System.Drawing.Size(30, 26);
            this.layoutControlItemRefresh.MinSize = new System.Drawing.Size(30, 26);
            this.layoutControlItemRefresh.Name = "layoutControlItemRefresh";
            this.layoutControlItemRefresh.Size = new System.Drawing.Size(30, 26);
            this.layoutControlItemRefresh.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemRefresh.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemRefresh.TextVisible = false;
            // 
            // layoutControlItemKhachHang
            // 
            this.layoutControlItemKhachHang.Control = this.lookUpEditKhachHang;
            this.layoutControlItemKhachHang.CustomizationFormText = "Chức năng";
            this.layoutControlItemKhachHang.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemKhachHang.MaxSize = new System.Drawing.Size(320, 26);
            this.layoutControlItemKhachHang.MinSize = new System.Drawing.Size(320, 26);
            this.layoutControlItemKhachHang.Name = "layoutControlItemKhachHang";
            this.layoutControlItemKhachHang.Size = new System.Drawing.Size(320, 26);
            this.layoutControlItemKhachHang.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemKhachHang.Text = "Khách Hàng";
            this.layoutControlItemKhachHang.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItemFilter
            // 
            this.layoutControlItemFilter.Control = this.btnFilter;
            this.layoutControlItemFilter.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItemFilter.Location = new System.Drawing.Point(320, 0);
            this.layoutControlItemFilter.Name = "layoutControlItemFilter";
            this.layoutControlItemFilter.Size = new System.Drawing.Size(81, 26);
            this.layoutControlItemFilter.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemFilter.TextVisible = false;
            // 
            // emptySpaceItemRightFilter
            // 
            this.emptySpaceItemRightFilter.AllowHotTrack = false;
            this.emptySpaceItemRightFilter.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItemRightFilter.Location = new System.Drawing.Point(401, 0);
            this.emptySpaceItemRightFilter.Name = "emptySpaceItemRightFilter";
            this.emptySpaceItemRightFilter.Size = new System.Drawing.Size(865, 26);
            this.emptySpaceItemRightFilter.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(30, 649);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1178, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // cmsExcel
            // 
            this.cmsExcel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsExcel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItemXuatExcel,
            this.importExcelToolStripMenuItem});
            this.cmsExcel.Name = "cmsExcel";
            this.cmsExcel.Size = new System.Drawing.Size(141, 48);
            // 
            // xToolStripMenuItemXuatExcel
            // 
            this.xToolStripMenuItemXuatExcel.Name = "xToolStripMenuItemXuatExcel";
            this.xToolStripMenuItemXuatExcel.Size = new System.Drawing.Size(140, 22);
            this.xToolStripMenuItemXuatExcel.Text = "Xuất Excel";
            this.xToolStripMenuItemXuatExcel.Click += new System.EventHandler(this.xToolStripMenuItemXuatExcel_Click);
            // 
            // importExcelToolStripMenuItem
            // 
            this.importExcelToolStripMenuItem.Name = "importExcelToolStripMenuItem";
            this.importExcelToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.importExcelToolStripMenuItem.Text = "Import Excel";
            this.importExcelToolStripMenuItem.Click += new System.EventHandler(this.importExcelToolStripMenuItem_Click);
            // 
            // frm_CMS_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 691);
            this.Controls.Add(this.layoutControl);
            this.Name = "frm_CMS_File";
            this.Text = "PA - Quản Lý File";
            this.Load += new System.EventHandler(this.frm_CMS_GridColumn_Load);

            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditTinhTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEditLamPhu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemRightFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.cmsExcel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditKhachHang;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemGrid;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemExit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemKhachHang;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemFilter;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemRightFilter;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
        private System.Windows.Forms.ContextMenuStrip cmsExcel;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItemXuatExcel;
        private System.Windows.Forms.ToolStripMenuItem importExcelToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditNhanVien;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditTinhTrang;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEditLamPhu;
    }
}