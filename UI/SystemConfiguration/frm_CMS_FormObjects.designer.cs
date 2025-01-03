namespace CMSUI.SystemConfiguration
{
    partial class frm_CMS_FormObjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_FormObjects));
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.lookUpEditForm = new DevExpress.XtraEditors.LookUpEdit();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridViewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnThoat = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnExcel = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemRightBtnExcel = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemForm = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnFilter = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemRightBtnFilter = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditForm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnThoat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemRightBtnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemRightBtnFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlMain
            // 
            this.layoutControlMain.Controls.Add(this.lookUpEditForm);
            this.layoutControlMain.Controls.Add(this.btnFilter);
            this.layoutControlMain.Controls.Add(this.btnExcel);
            this.layoutControlMain.Controls.Add(this.btnRefesh);
            this.layoutControlMain.Controls.Add(this.btnClose);
            this.layoutControlMain.Controls.Add(this.gridControlData);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(0, 0);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.Root = this.layoutControlGroupMain;
            this.layoutControlMain.Size = new System.Drawing.Size(679, 338);
            this.layoutControlMain.TabIndex = 0;
            this.layoutControlMain.Text = "layoutControl1";
            // 
            // lookUpEditForm
            // 
            this.lookUpEditForm.Location = new System.Drawing.Point(69, 12);
            this.lookUpEditForm.Name = "lookUpEditForm";
            this.lookUpEditForm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditForm.Properties.NullText = "";
            this.lookUpEditForm.Size = new System.Drawing.Size(167, 20);
            this.lookUpEditForm.StyleController = this.layoutControlMain;
            this.lookUpEditForm.TabIndex = 25;
            // 
            // btnFilter
            // 
            this.btnFilter.AutoWidthInLayoutControl = true;
            this.btnFilter.ImageOptions.ImageIndex = 5;
            this.btnFilter.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnFilter.Location = new System.Drawing.Point(240, 12);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(77, 22);
            this.btnFilter.StyleController = this.layoutControlMain;
            this.btnFilter.TabIndex = 24;
            this.btnFilter.Text = "Lọc dữ liệu";
            this.btnFilter.Click += new System.EventHandler(this.btnLocDuLieu_Click);
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
            // btnExcel
            // 
            this.btnExcel.AutoWidthInLayoutControl = true;
            this.btnExcel.ImageOptions.ImageIndex = 2;
            this.btnExcel.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnExcel.Location = new System.Drawing.Point(38, 304);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(51, 22);
            this.btnExcel.StyleController = this.layoutControlMain;
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefesh
            // 
            this.btnRefesh.AutoWidthInLayoutControl = true;
            this.btnRefesh.ImageOptions.ImageIndex = 1;
            this.btnRefesh.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnRefesh.Location = new System.Drawing.Point(12, 304);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(22, 22);
            this.btnRefesh.StyleController = this.layoutControlMain;
            this.btnRefesh.TabIndex = 7;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.ImageOptions.ImageIndex = 0;
            this.btnClose.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnClose.Location = new System.Drawing.Point(613, 304);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 22);
            this.btnClose.StyleController = this.layoutControlMain;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // gridControlData
            // 
            this.gridControlData.Location = new System.Drawing.Point(12, 38);
            this.gridControlData.MainView = this.gridViewData;
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.Size = new System.Drawing.Size(655, 262);
            this.gridControlData.TabIndex = 4;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewData});
            // 
            // gridViewData
            // 
            this.gridViewData.GridControl = this.gridControlData;
            this.gridViewData.GroupPanelText = "Thả tiêu đề cột muốn nhóm vào đây";
            this.gridViewData.IndicatorWidth = 40;
            this.gridViewData.Name = "gridViewData";
            this.gridViewData.NewItemRowText = "Nhấn vào đây để thêm mới";
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
            this.layoutControlItemBtnExcel,
            this.emptySpaceItemRightBtnExcel,
            this.layoutControlItemForm,
            this.layoutControlItemBtnFilter,
            this.emptySpaceItemRightBtnFilter});
            this.layoutControlGroupMain.Name = "Root";
            this.layoutControlGroupMain.Size = new System.Drawing.Size(679, 338);
            this.layoutControlGroupMain.TextVisible = false;
            // 
            // layoutControlItemGrid
            // 
            this.layoutControlItemGrid.Control = this.gridControlData;
            this.layoutControlItemGrid.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItemGrid.Name = "layoutControlItemGrid";
            this.layoutControlItemGrid.Size = new System.Drawing.Size(659, 266);
            this.layoutControlItemGrid.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemGrid.TextVisible = false;
            // 
            // layoutControlItemBtnThoat
            // 
            this.layoutControlItemBtnThoat.Control = this.btnClose;
            this.layoutControlItemBtnThoat.Location = new System.Drawing.Point(601, 292);
            this.layoutControlItemBtnThoat.Name = "layoutControlItemBtnThoat";
            this.layoutControlItemBtnThoat.Size = new System.Drawing.Size(58, 26);
            this.layoutControlItemBtnThoat.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnThoat.TextVisible = false;
            // 
            // layoutControlItemBtnRefresh
            // 
            this.layoutControlItemBtnRefresh.Control = this.btnRefesh;
            this.layoutControlItemBtnRefresh.Location = new System.Drawing.Point(0, 292);
            this.layoutControlItemBtnRefresh.Name = "layoutControlItemBtnRefresh";
            this.layoutControlItemBtnRefresh.Size = new System.Drawing.Size(26, 26);
            this.layoutControlItemBtnRefresh.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnRefresh.TextVisible = false;
            // 
            // layoutControlItemBtnExcel
            // 
            this.layoutControlItemBtnExcel.Control = this.btnExcel;
            this.layoutControlItemBtnExcel.Location = new System.Drawing.Point(26, 292);
            this.layoutControlItemBtnExcel.Name = "layoutControlItemBtnExcel";
            this.layoutControlItemBtnExcel.Size = new System.Drawing.Size(55, 26);
            this.layoutControlItemBtnExcel.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnExcel.TextVisible = false;
            // 
            // emptySpaceItemRightBtnExcel
            // 
            this.emptySpaceItemRightBtnExcel.AllowHotTrack = false;
            this.emptySpaceItemRightBtnExcel.Location = new System.Drawing.Point(81, 292);
            this.emptySpaceItemRightBtnExcel.Name = "emptySpaceItemRightBtnExcel";
            this.emptySpaceItemRightBtnExcel.Size = new System.Drawing.Size(520, 26);
            this.emptySpaceItemRightBtnExcel.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItemForm
            // 
            this.layoutControlItemForm.Control = this.lookUpEditForm;
            this.layoutControlItemForm.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemForm.Name = "layoutControlItemForm";
            this.layoutControlItemForm.Size = new System.Drawing.Size(228, 26);
            this.layoutControlItemForm.Text = "Chức năng";
            this.layoutControlItemForm.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemForm.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItemForm.TextToControlDistance = 5;
            // 
            // layoutControlItemBtnFilter
            // 
            this.layoutControlItemBtnFilter.Control = this.btnFilter;
            this.layoutControlItemBtnFilter.Location = new System.Drawing.Point(228, 0);
            this.layoutControlItemBtnFilter.Name = "layoutControlItemBtnFilter";
            this.layoutControlItemBtnFilter.Size = new System.Drawing.Size(81, 26);
            this.layoutControlItemBtnFilter.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnFilter.TextVisible = false;
            // 
            // emptySpaceItemRightBtnFilter
            // 
            this.emptySpaceItemRightBtnFilter.AllowHotTrack = false;
            this.emptySpaceItemRightBtnFilter.Location = new System.Drawing.Point(309, 0);
            this.emptySpaceItemRightBtnFilter.Name = "emptySpaceItemRightBtnFilter";
            this.emptySpaceItemRightBtnFilter.Size = new System.Drawing.Size(350, 26);
            this.emptySpaceItemRightBtnFilter.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_CMS_FormObjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 338);
            this.Controls.Add(this.layoutControlMain);
            this.Name = "frm_CMS_FormObjects";
            this.Text = "UIS - Đối tượng";
            this.Load += new System.EventHandler(this.frm_CMS_FormObjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditForm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnThoat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemRightBtnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemRightBtnFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraEditors.SimpleButton btnRefesh;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemGrid;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnThoat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnExcel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewData;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemRightBtnExcel;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditForm;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemForm;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnFilter;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemRightBtnFilter;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
    }
}