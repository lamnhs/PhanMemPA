namespace CMSReport
{
    partial class frm_CMS_ReportName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_ReportName));
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.textEditReportName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemReportName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemLeftBtnOK = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditReportName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemReportName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemLeftBtnOK)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlMain
            // 
            this.layoutControlMain.Controls.Add(this.btnOK);
            this.layoutControlMain.Controls.Add(this.btnClose);
            this.layoutControlMain.Controls.Add(this.textEditReportName);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(0, 0);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.Root = this.Root;
            this.layoutControlMain.Size = new System.Drawing.Size(348, 71);
            this.layoutControlMain.TabIndex = 0;
            this.layoutControlMain.Text = "layoutControl1";
            // 
            // btnOK
            // 
            this.btnOK.AutoWidthInLayoutControl = true;
            this.btnOK.ImageOptions.ImageIndex = 6;
            this.btnOK.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnOK.Location = new System.Drawing.Point(240, 36);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(40, 22);
            this.btnOK.StyleController = this.layoutControlMain;
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.ImageOptions.ImageIndex = 0;
            this.btnClose.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnClose.Location = new System.Drawing.Point(284, 36);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 22);
            this.btnClose.StyleController = this.layoutControlMain;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textEditReportName
            // 
            this.textEditReportName.Location = new System.Drawing.Point(77, 12);
            this.textEditReportName.Name = "textEditReportName";
            this.textEditReportName.Size = new System.Drawing.Size(259, 20);
            this.textEditReportName.StyleController = this.layoutControlMain;
            this.textEditReportName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemReportName,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItemLeftBtnOK});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(348, 71);
            this.Root.TextVisible = false;
            // 
            // layoutControlItemReportName
            // 
            this.layoutControlItemReportName.Control = this.textEditReportName;
            this.layoutControlItemReportName.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemReportName.Name = "layoutControlItemReportName";
            this.layoutControlItemReportName.Size = new System.Drawing.Size(328, 24);
            this.layoutControlItemReportName.Text = "Report name";
            this.layoutControlItemReportName.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.Location = new System.Drawing.Point(272, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(56, 27);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnOK;
            this.layoutControlItem3.Location = new System.Drawing.Point(228, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(44, 27);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItemLeftBtnOK
            // 
            this.emptySpaceItemLeftBtnOK.AllowHotTrack = false;
            this.emptySpaceItemLeftBtnOK.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItemLeftBtnOK.Name = "emptySpaceItemLeftBtnOK";
            this.emptySpaceItemLeftBtnOK.Size = new System.Drawing.Size(228, 27);
            this.emptySpaceItemLeftBtnOK.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_CMS_ReportName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 71);
            this.Controls.Add(this.layoutControlMain);
            this.Name = "frm_CMS_ReportName";
            this.Text = "UIS - Report name";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditReportName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemReportName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemLeftBtnOK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.TextEdit textEditReportName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemReportName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemLeftBtnOK;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
    }
}