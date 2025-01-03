namespace CMSUI.SystemConfiguration
{
    partial class frm_CMS_DataField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_DataField));
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridViewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnThoat = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnLuuDuLieu = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemBtn = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemXoaDuLieu = new DevExpress.XtraLayout.LayoutControlItem();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnThoat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnLuuDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemXoaDuLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlMain
            // 
            this.layoutControlMain.Controls.Add(this.btnDelete);
            this.layoutControlMain.Controls.Add(this.btnSave);
            this.layoutControlMain.Controls.Add(this.btnRefresh);
            this.layoutControlMain.Controls.Add(this.btnClose);
            this.layoutControlMain.Controls.Add(this.gridControlData);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(0, 0);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.Root = this.layoutControlGroupMain;
            this.layoutControlMain.Size = new System.Drawing.Size(653, 306);
            this.layoutControlMain.TabIndex = 0;
            this.layoutControlMain.Text = "layoutControl1";
            // 
            // btnDelete
            // 
            this.btnDelete.AutoWidthInLayoutControl = true;
            this.btnDelete.ImageOptions.ImageIndex = 8;
            this.btnDelete.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnDelete.Location = new System.Drawing.Point(421, 272);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 22);
            this.btnDelete.StyleController = this.layoutControlMain;
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa dữ liệu";
            this.btnDelete.Click += new System.EventHandler(this.btnXoaDuLieu_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoWidthInLayoutControl = true;
            this.btnSave.ImageOptions.ImageIndex = 3;
            this.btnSave.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnSave.Location = new System.Drawing.Point(504, 272);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 22);
            this.btnSave.StyleController = this.layoutControlMain;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu dữ liệu";
            this.btnSave.Click += new System.EventHandler(this.btnLuuDuLieu_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoWidthInLayoutControl = true;
            this.btnRefresh.ImageOptions.ImageIndex = 1;
            this.btnRefresh.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnRefresh.Location = new System.Drawing.Point(12, 272);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(22, 22);
            this.btnRefresh.StyleController = this.layoutControlMain;
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.ImageOptions.ImageIndex = 0;
            this.btnClose.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnClose.Location = new System.Drawing.Point(587, 272);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 22);
            this.btnClose.StyleController = this.layoutControlMain;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // gridControlData
            // 
            this.gridControlData.Location = new System.Drawing.Point(12, 12);
            this.gridControlData.MainView = this.gridViewData;
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.Size = new System.Drawing.Size(629, 256);
            this.gridControlData.TabIndex = 4;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewData});
            // 
            // gridViewData
            // 
            this.gridViewData.GridControl = this.gridControlData;
            this.gridViewData.IndicatorWidth = 40;
            this.gridViewData.Name = "gridViewData";
            this.gridViewData.OptionsView.ShowGroupPanel = false;
            this.gridViewData.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewData_CustomDrawRowIndicator);
            // 
            // layoutControlGroupMain
            // 
            this.layoutControlGroupMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupMain.GroupBordersVisible = false;
            this.layoutControlGroupMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemGrid,
            this.layoutControlItemBtnThoat,
            this.layoutControlItemBtnRefresh,
            this.layoutControlItemBtnLuuDuLieu,
            this.emptySpaceItemBtn,
            this.layoutControlItemXoaDuLieu});
            this.layoutControlGroupMain.Name = "layoutControlGroupMain";
            this.layoutControlGroupMain.Size = new System.Drawing.Size(653, 306);
            this.layoutControlGroupMain.TextVisible = false;
            // 
            // layoutControlItemGrid
            // 
            this.layoutControlItemGrid.Control = this.gridControlData;
            this.layoutControlItemGrid.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemGrid.Name = "layoutControlItemGrid";
            this.layoutControlItemGrid.Size = new System.Drawing.Size(633, 260);
            this.layoutControlItemGrid.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemGrid.TextVisible = false;
            // 
            // layoutControlItemBtnThoat
            // 
            this.layoutControlItemBtnThoat.Control = this.btnClose;
            this.layoutControlItemBtnThoat.Location = new System.Drawing.Point(575, 260);
            this.layoutControlItemBtnThoat.Name = "layoutControlItemBtnThoat";
            this.layoutControlItemBtnThoat.Size = new System.Drawing.Size(58, 26);
            this.layoutControlItemBtnThoat.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnThoat.TextVisible = false;
            // 
            // layoutControlItemBtnRefresh
            // 
            this.layoutControlItemBtnRefresh.Control = this.btnRefresh;
            this.layoutControlItemBtnRefresh.Location = new System.Drawing.Point(0, 260);
            this.layoutControlItemBtnRefresh.Name = "layoutControlItemBtnRefresh";
            this.layoutControlItemBtnRefresh.Size = new System.Drawing.Size(26, 26);
            this.layoutControlItemBtnRefresh.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnRefresh.TextVisible = false;
            // 
            // layoutControlItemBtnLuuDuLieu
            // 
            this.layoutControlItemBtnLuuDuLieu.Control = this.btnSave;
            this.layoutControlItemBtnLuuDuLieu.Location = new System.Drawing.Point(492, 260);
            this.layoutControlItemBtnLuuDuLieu.Name = "layoutControlItemBtnLuuDuLieu";
            this.layoutControlItemBtnLuuDuLieu.Size = new System.Drawing.Size(83, 26);
            this.layoutControlItemBtnLuuDuLieu.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnLuuDuLieu.TextVisible = false;
            // 
            // emptySpaceItemBtn
            // 
            this.emptySpaceItemBtn.AllowHotTrack = false;
            this.emptySpaceItemBtn.Location = new System.Drawing.Point(26, 260);
            this.emptySpaceItemBtn.Name = "emptySpaceItemBtn";
            this.emptySpaceItemBtn.Size = new System.Drawing.Size(383, 26);
            this.emptySpaceItemBtn.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItemXoaDuLieu
            // 
            this.layoutControlItemXoaDuLieu.Control = this.btnDelete;
            this.layoutControlItemXoaDuLieu.Location = new System.Drawing.Point(409, 260);
            this.layoutControlItemXoaDuLieu.Name = "layoutControlItemXoaDuLieu";
            this.layoutControlItemXoaDuLieu.Size = new System.Drawing.Size(83, 26);
            this.layoutControlItemXoaDuLieu.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemXoaDuLieu.TextVisible = false;
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
            // frm_CMS_DataField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 306);
            this.Controls.Add(this.layoutControlMain);
            this.Name = "frm_CMS_DataField";
            this.Text = "UIS - Trường dữ liệu";
            this.Load += new System.EventHandler(this.frm_CMS_DataField_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnThoat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnLuuDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemXoaDuLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewData;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemGrid;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnThoat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnLuuDuLieu;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemBtn;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemXoaDuLieu;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
    }
}