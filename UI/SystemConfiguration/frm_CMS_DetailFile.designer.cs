namespace CMSUI.SystemConfiguration
{
    partial class frm_CMS_DetailFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_DetailFile));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridViewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemLookUpEditNhanVien = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemExit = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemCenterButton = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemBtnExcel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemCenterButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnExcel);
            this.layoutControl.Controls.Add(this.btnRefresh);
            this.layoutControl.Controls.Add(this.btnClose);
            this.layoutControl.Controls.Add(this.gridControlData);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(1155, 695);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // btnExcel
            // 
            this.btnExcel.AutoWidthInLayoutControl = true;
            this.btnExcel.ImageOptions.ImageIndex = 2;
            this.btnExcel.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnExcel.Location = new System.Drawing.Point(47, 655);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(55, 27);
            this.btnExcel.StyleController = this.layoutControl;
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
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
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.ImageIndex = 1;
            this.btnRefresh.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnRefresh.Location = new System.Drawing.Point(12, 655);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(31, 28);
            this.btnRefresh.StyleController = this.layoutControl;
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.ImageOptions.ImageIndex = 0;
            this.btnClose.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnClose.Location = new System.Drawing.Point(1084, 655);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 27);
            this.btnClose.StyleController = this.layoutControl;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // gridControlData
            // 
            this.gridControlData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gridControlData.Location = new System.Drawing.Point(12, 12);
            this.gridControlData.MainView = this.gridViewData;
            this.gridControlData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditNhanVien});
            this.gridControlData.Size = new System.Drawing.Size(1131, 639);
            this.gridControlData.TabIndex = 4;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewData});
            // 
            // gridViewData
            // 
            this.gridViewData.DetailHeight = 431;
            this.gridViewData.GridControl = this.gridControlData;
            this.gridViewData.IndicatorWidth = 47;
            this.gridViewData.Name = "gridViewData";
            this.gridViewData.NewItemRowText = "Nhấn vào đây để thêm mới";
            this.gridViewData.OptionsView.ShowGroupPanel = false;
            this.gridViewData.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewData_CustomDrawRowIndicator);
            // 
            // repositoryItemLookUpEditNhanVien
            // 
            this.repositoryItemLookUpEditNhanVien.AutoHeight = false;
            this.repositoryItemLookUpEditNhanVien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditNhanVien.Name = "repositoryItemLookUpEditNhanVien";
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
            this.emptySpaceItemCenterButton,
            this.layoutControlItemBtnExcel});
            this.layoutControlGroup.Name = "Root";
            this.layoutControlGroup.Size = new System.Drawing.Size(1155, 695);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItemGrid
            // 
            this.layoutControlItemGrid.Control = this.gridControlData;
            this.layoutControlItemGrid.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItemGrid.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemGrid.Name = "layoutControlItemGrid";
            this.layoutControlItemGrid.Size = new System.Drawing.Size(1135, 643);
            this.layoutControlItemGrid.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemGrid.TextVisible = false;
            // 
            // layoutControlItemExit
            // 
            this.layoutControlItemExit.Control = this.btnClose;
            this.layoutControlItemExit.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItemExit.Location = new System.Drawing.Point(1072, 643);
            this.layoutControlItemExit.Name = "layoutControlItemExit";
            this.layoutControlItemExit.Size = new System.Drawing.Size(63, 32);
            this.layoutControlItemExit.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemExit.TextVisible = false;
            // 
            // layoutControlItemRefresh
            // 
            this.layoutControlItemRefresh.Control = this.btnRefresh;
            this.layoutControlItemRefresh.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItemRefresh.Location = new System.Drawing.Point(0, 643);
            this.layoutControlItemRefresh.MaxSize = new System.Drawing.Size(35, 32);
            this.layoutControlItemRefresh.MinSize = new System.Drawing.Size(35, 32);
            this.layoutControlItemRefresh.Name = "layoutControlItemRefresh";
            this.layoutControlItemRefresh.Size = new System.Drawing.Size(35, 32);
            this.layoutControlItemRefresh.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemRefresh.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemRefresh.TextVisible = false;
            // 
            // emptySpaceItemCenterButton
            // 
            this.emptySpaceItemCenterButton.AllowHotTrack = false;
            this.emptySpaceItemCenterButton.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItemCenterButton.Location = new System.Drawing.Point(94, 643);
            this.emptySpaceItemCenterButton.Name = "emptySpaceItemCenterButton";
            this.emptySpaceItemCenterButton.Size = new System.Drawing.Size(978, 32);
            this.emptySpaceItemCenterButton.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItemBtnExcel
            // 
            this.layoutControlItemBtnExcel.Control = this.btnExcel;
            this.layoutControlItemBtnExcel.Location = new System.Drawing.Point(35, 643);
            this.layoutControlItemBtnExcel.Name = "layoutControlItemBtnExcel";
            this.layoutControlItemBtnExcel.Size = new System.Drawing.Size(59, 32);
            this.layoutControlItemBtnExcel.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnExcel.TextVisible = false;
            // 
            // frm_CMS_DetailFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 695);
            this.Controls.Add(this.layoutControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_CMS_DetailFile";
            this.Text = "PA - Chi tiết";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_CMS_GridColumn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemCenterButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemGrid;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemExit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemRefresh;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemCenterButton;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnExcel;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditNhanVien;
    }
}