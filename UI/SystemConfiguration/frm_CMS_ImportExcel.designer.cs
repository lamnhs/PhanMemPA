namespace CMSUI.SystemConfiguration
{
    partial class frm_CMS_ImportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_ImportExcel));
            this.Root = new DevExpress.XtraLayout.LayoutControl();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridViewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemLookUpEdit_Map = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lkuSheet = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonEdit_chonFile = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemBrowse = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemSheet = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnOK = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemButtonLeft = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnExcel = new DevExpress.XtraLayout.LayoutControlItem();
            this.ofdFiles = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            this.Root.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuSheet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_chonFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemButtonLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // Root
            // 
            this.Root.Controls.Add(this.btnExportExcel);
            this.Root.Controls.Add(this.gridControlData);
            this.Root.Controls.Add(this.btnClose);
            this.Root.Controls.Add(this.btnOK);
            this.Root.Controls.Add(this.lkuSheet);
            this.Root.Controls.Add(this.buttonEdit_chonFile);
            this.Root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Root = this.layoutControlGroupMain;
            this.Root.Size = new System.Drawing.Size(551, 434);
            this.Root.TabIndex = 0;
            this.Root.Text = "layoutControl1";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.AutoWidthInLayoutControl = true;
            this.btnExportExcel.ImageOptions.ImageIndex = 2;
            this.btnExportExcel.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnExportExcel.Location = new System.Drawing.Point(12, 400);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(51, 22);
            this.btnExportExcel.StyleController = this.Root;
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
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
            this.imageCollectionSmall.Images.SetKeyName(6, "iconsetsymbols3_16x16.png");
            // 
            // gridControlData
            // 
            this.gridControlData.Location = new System.Drawing.Point(12, 60);
            this.gridControlData.MainView = this.gridViewData;
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Map});
            this.gridControlData.Size = new System.Drawing.Size(527, 336);
            this.gridControlData.TabIndex = 5;
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
            // 
            // repositoryItemLookUpEdit_Map
            // 
            this.repositoryItemLookUpEdit_Map.AutoHeight = false;
            this.repositoryItemLookUpEdit_Map.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Map.Name = "repositoryItemLookUpEdit_Map";
            // 
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.ImageOptions.ImageIndex = 0;
            this.btnClose.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnClose.Location = new System.Drawing.Point(485, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 22);
            this.btnClose.StyleController = this.Root;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btnOK
            // 
            this.btnOK.AutoWidthInLayoutControl = true;
            this.btnOK.ImageOptions.ImageIndex = 6;
            this.btnOK.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnOK.Location = new System.Drawing.Point(441, 400);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(40, 22);
            this.btnOK.StyleController = this.Root;
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lkuSheet
            // 
            this.lkuSheet.Location = new System.Drawing.Point(66, 36);
            this.lkuSheet.Name = "lkuSheet";
            this.lkuSheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuSheet.Properties.NullText = "";
            this.lkuSheet.Size = new System.Drawing.Size(473, 20);
            this.lkuSheet.StyleController = this.Root;
            this.lkuSheet.TabIndex = 5;
            this.lkuSheet.EditValueChanged += new System.EventHandler(this.lookUpEdit_sheet_EditValueChanged);
            // 
            // buttonEdit_chonFile
            // 
            this.buttonEdit_chonFile.Location = new System.Drawing.Point(66, 12);
            this.buttonEdit_chonFile.Name = "buttonEdit_chonFile";
            this.buttonEdit_chonFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_chonFile.Properties.ReadOnly = true;
            this.buttonEdit_chonFile.Size = new System.Drawing.Size(473, 20);
            this.buttonEdit_chonFile.StyleController = this.Root;
            this.buttonEdit_chonFile.TabIndex = 4;
            this.buttonEdit_chonFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_chonFile_ButtonClick);
            // 
            // layoutControlGroupMain
            // 
            this.layoutControlGroupMain.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroupMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupMain.GroupBordersVisible = false;
            this.layoutControlGroupMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemBrowse,
            this.layoutControlItemSheet,
            this.layoutControlItemBtnOK,
            this.layoutControlItemBtnClose,
            this.emptySpaceItemButtonLeft,
            this.layoutControlItemGrid,
            this.layoutControlItemBtnExcel});
            this.layoutControlGroupMain.Name = "layoutControlGroupMain";
            this.layoutControlGroupMain.Size = new System.Drawing.Size(551, 434);
            this.layoutControlGroupMain.TextVisible = false;
            // 
            // layoutControlItemBrowse
            // 
            this.layoutControlItemBrowse.Control = this.buttonEdit_chonFile;
            this.layoutControlItemBrowse.CustomizationFormText = "Chọn file";
            this.layoutControlItemBrowse.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemBrowse.Name = "layoutControlItemBrowse";
            this.layoutControlItemBrowse.Size = new System.Drawing.Size(531, 24);
            this.layoutControlItemBrowse.Text = "Chọn file";
            this.layoutControlItemBrowse.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItemSheet
            // 
            this.layoutControlItemSheet.Control = this.lkuSheet;
            this.layoutControlItemSheet.CustomizationFormText = "Sheet";
            this.layoutControlItemSheet.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItemSheet.Name = "layoutControlItemSheet";
            this.layoutControlItemSheet.Size = new System.Drawing.Size(531, 24);
            this.layoutControlItemSheet.Text = "Sheet";
            this.layoutControlItemSheet.TextSize = new System.Drawing.Size(42, 13);
            // 
            // layoutControlItemBtnOK
            // 
            this.layoutControlItemBtnOK.Control = this.btnOK;
            this.layoutControlItemBtnOK.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItemBtnOK.Location = new System.Drawing.Point(429, 388);
            this.layoutControlItemBtnOK.Name = "layoutControlItemBtnOK";
            this.layoutControlItemBtnOK.Size = new System.Drawing.Size(44, 26);
            this.layoutControlItemBtnOK.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnOK.TextVisible = false;
            // 
            // layoutControlItemBtnClose
            // 
            this.layoutControlItemBtnClose.Control = this.btnClose;
            this.layoutControlItemBtnClose.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItemBtnClose.Location = new System.Drawing.Point(473, 388);
            this.layoutControlItemBtnClose.Name = "layoutControlItemBtnClose";
            this.layoutControlItemBtnClose.Size = new System.Drawing.Size(58, 26);
            this.layoutControlItemBtnClose.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnClose.TextVisible = false;
            // 
            // emptySpaceItemButtonLeft
            // 
            this.emptySpaceItemButtonLeft.AllowHotTrack = false;
            this.emptySpaceItemButtonLeft.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItemButtonLeft.Location = new System.Drawing.Point(55, 388);
            this.emptySpaceItemButtonLeft.Name = "emptySpaceItemButtonLeft";
            this.emptySpaceItemButtonLeft.Size = new System.Drawing.Size(374, 26);
            this.emptySpaceItemButtonLeft.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItemGrid
            // 
            this.layoutControlItemGrid.Control = this.gridControlData;
            this.layoutControlItemGrid.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItemGrid.Name = "layoutControlItemGrid";
            this.layoutControlItemGrid.Size = new System.Drawing.Size(531, 340);
            this.layoutControlItemGrid.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemGrid.TextVisible = false;
            // 
            // layoutControlItemBtnExcel
            // 
            this.layoutControlItemBtnExcel.Control = this.btnExportExcel;
            this.layoutControlItemBtnExcel.Location = new System.Drawing.Point(0, 388);
            this.layoutControlItemBtnExcel.Name = "layoutControlItemBtnExcel";
            this.layoutControlItemBtnExcel.Size = new System.Drawing.Size(55, 26);
            this.layoutControlItemBtnExcel.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnExcel.TextVisible = false;
            // 
            // frm_CMS_ImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 434);
            this.Controls.Add(this.Root);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_CMS_ImportExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UIS - Chọn file";
            this.Load += new System.EventHandler(this.frm_CMS_ImportExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            this.Root.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuSheet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_chonFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemButtonLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMain;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LookUpEdit lkuSheet;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_chonFile;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBrowse;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSheet;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnOK;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnClose;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemButtonLeft;
        private System.Windows.Forms.OpenFileDialog ofdFiles;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemGrid;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Map;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnExcel;
    }
}