namespace CMSUI.SystemConfiguration
{
    partial class frm_CMS_MainObjectSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_MainObjectSource));
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.tablePanelMain = new DevExpress.Utils.Layout.TablePanel();
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnReadSource = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit_Status = new DevExpress.XtraEditors.MemoEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemMemo = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnReadSource = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemBtn = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanelMain)).BeginInit();
            this.tablePanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Status.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnReadSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "close_32x32.png");
            this.imageCollection.Images.SetKeyName(1, "loadfrom_16x16.png");
            this.imageCollection.Images.SetKeyName(2, "window_16x16.png");
            this.imageCollection.Images.SetKeyName(3, "table_16x16.png");
            this.imageCollection.Images.SetKeyName(4, "freezefirstcolumn_16x16.png");
            this.imageCollection.Images.SetKeyName(5, "selectall_16x16.png");
            // 
            // tablePanelMain
            // 
            this.tablePanelMain.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 81F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 389.72F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 81F)});
            this.tablePanelMain.Controls.Add(this.layoutControlMain);
            this.tablePanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelMain.Location = new System.Drawing.Point(0, 0);
            this.tablePanelMain.Name = "tablePanelMain";
            this.tablePanelMain.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 199F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F)});
            this.tablePanelMain.Size = new System.Drawing.Size(509, 283);
            this.tablePanelMain.TabIndex = 0;
            // 
            // layoutControlMain
            // 
            this.tablePanelMain.SetColumn(this.layoutControlMain, 1);
            this.layoutControlMain.Controls.Add(this.btnReadSource);
            this.layoutControlMain.Controls.Add(this.memoEdit_Status);
            this.layoutControlMain.Controls.Add(this.btnClose);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(63, 45);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.Root = this.Root;
            this.tablePanelMain.SetRow(this.layoutControlMain, 1);
            this.layoutControlMain.Size = new System.Drawing.Size(384, 193);
            this.layoutControlMain.TabIndex = 0;
            this.layoutControlMain.Text = "layoutControl1";
            // 
            // btnReadSource
            // 
            this.btnReadSource.AutoWidthInLayoutControl = true;
            this.btnReadSource.ImageOptions.ImageIndex = 1;
            this.btnReadSource.ImageOptions.ImageList = this.imageCollection;
            this.btnReadSource.Location = new System.Drawing.Point(220, 159);
            this.btnReadSource.Name = "btnReadSource";
            this.btnReadSource.Size = new System.Drawing.Size(94, 22);
            this.btnReadSource.StyleController = this.layoutControlMain;
            this.btnReadSource.TabIndex = 9;
            this.btnReadSource.Text = "Đọc đối tượng";
            this.btnReadSource.Click += new System.EventHandler(this.btnReadSource_Click);
            // 
            // memoEdit_Status
            // 
            this.memoEdit_Status.Location = new System.Drawing.Point(12, 12);
            this.memoEdit_Status.Name = "memoEdit_Status";
            this.memoEdit_Status.Size = new System.Drawing.Size(360, 143);
            this.memoEdit_Status.StyleController = this.layoutControlMain;
            this.memoEdit_Status.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.ImageOptions.ImageIndex = 0;
            this.btnClose.ImageOptions.ImageList = this.imageCollection;
            this.btnClose.Location = new System.Drawing.Point(318, 159);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 22);
            this.btnClose.StyleController = this.layoutControlMain;
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemMemo,
            this.layoutControlItemBtnClose,
            this.layoutControlItemBtnReadSource,
            this.emptySpaceItemBtn});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(384, 193);
            this.Root.TextVisible = false;
            // 
            // layoutControlItemMemo
            // 
            this.layoutControlItemMemo.Control = this.memoEdit_Status;
            this.layoutControlItemMemo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemMemo.Name = "layoutControlItemMemo";
            this.layoutControlItemMemo.Size = new System.Drawing.Size(364, 147);
            this.layoutControlItemMemo.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemMemo.TextVisible = false;
            // 
            // layoutControlItemBtnClose
            // 
            this.layoutControlItemBtnClose.Control = this.btnClose;
            this.layoutControlItemBtnClose.Location = new System.Drawing.Point(306, 147);
            this.layoutControlItemBtnClose.Name = "layoutControlItemBtnClose";
            this.layoutControlItemBtnClose.Size = new System.Drawing.Size(58, 26);
            this.layoutControlItemBtnClose.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnClose.TextVisible = false;
            // 
            // layoutControlItemBtnReadSource
            // 
            this.layoutControlItemBtnReadSource.Control = this.btnReadSource;
            this.layoutControlItemBtnReadSource.Location = new System.Drawing.Point(208, 147);
            this.layoutControlItemBtnReadSource.Name = "layoutControlItemBtnReadSource";
            this.layoutControlItemBtnReadSource.Size = new System.Drawing.Size(98, 26);
            this.layoutControlItemBtnReadSource.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnReadSource.TextVisible = false;
            // 
            // emptySpaceItemBtn
            // 
            this.emptySpaceItemBtn.AllowHotTrack = false;
            this.emptySpaceItemBtn.Location = new System.Drawing.Point(0, 147);
            this.emptySpaceItemBtn.Name = "emptySpaceItemBtn";
            this.emptySpaceItemBtn.Size = new System.Drawing.Size(208, 26);
            this.emptySpaceItemBtn.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_CMS_MainObjectSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 283);
            this.Controls.Add(this.tablePanelMain);
            this.Name = "frm_CMS_MainObjectSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMS - OBJECT IN SOURCE";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanelMain)).EndInit();
            this.tablePanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Status.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnReadSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.Utils.Layout.TablePanel tablePanelMain;
        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraEditors.SimpleButton btnReadSource;
        private DevExpress.XtraEditors.MemoEdit memoEdit_Status;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemMemo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnReadSource;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemBtn;
    }
}