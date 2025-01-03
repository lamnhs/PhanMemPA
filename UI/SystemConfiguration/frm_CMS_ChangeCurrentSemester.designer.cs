namespace CMSUI.SystemConfiguration
{
    partial class frm_CMS_ChangeCurrentSemester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_ChangeCurrentSemester));
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnAgree = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditAcademicSemester = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditAcademicYear = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemAcademicYear = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnAgree = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemAcademicSemester = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemLeftBtn = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAcademicSemester.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAcademicYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAcademicYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnAgree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAcademicSemester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemLeftBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlMain
            // 
            this.layoutControlMain.Controls.Add(this.btnClose);
            this.layoutControlMain.Controls.Add(this.btnAgree);
            this.layoutControlMain.Controls.Add(this.lookUpEditAcademicSemester);
            this.layoutControlMain.Controls.Add(this.lookUpEditAcademicYear);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(0, 0);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.Root = this.layoutControlGroupMain;
            this.layoutControlMain.Size = new System.Drawing.Size(345, 94);
            this.layoutControlMain.TabIndex = 0;
            this.layoutControlMain.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.ImageOptions.ImageIndex = 0;
            this.btnClose.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnClose.Location = new System.Drawing.Point(279, 60);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 22);
            this.btnClose.StyleController = this.layoutControlMain;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btn_Close_Click);
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
            // 
            // btnAgree
            // 
            this.btnAgree.AutoWidthInLayoutControl = true;
            this.btnAgree.ImageOptions.ImageIndex = 6;
            this.btnAgree.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnAgree.Location = new System.Drawing.Point(214, 60);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Size = new System.Drawing.Size(61, 22);
            this.btnAgree.StyleController = this.layoutControlMain;
            this.btnAgree.TabIndex = 6;
            this.btnAgree.Text = "Đồng ý";
            this.btnAgree.Click += new System.EventHandler(this.btn_DongY_Click);
            // 
            // lookUpEditAcademicSemester
            // 
            this.lookUpEditAcademicSemester.Location = new System.Drawing.Point(56, 36);
            this.lookUpEditAcademicSemester.Name = "lookUpEditAcademicSemester";
            this.lookUpEditAcademicSemester.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditAcademicSemester.Size = new System.Drawing.Size(277, 20);
            this.lookUpEditAcademicSemester.StyleController = this.layoutControlMain;
            this.lookUpEditAcademicSemester.TabIndex = 5;
            // 
            // lookUpEditAcademicYear
            // 
            this.lookUpEditAcademicYear.Location = new System.Drawing.Point(56, 12);
            this.lookUpEditAcademicYear.Name = "lookUpEditAcademicYear";
            this.lookUpEditAcademicYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditAcademicYear.Size = new System.Drawing.Size(277, 20);
            this.lookUpEditAcademicYear.StyleController = this.layoutControlMain;
            this.lookUpEditAcademicYear.TabIndex = 4;
            this.lookUpEditAcademicYear.EditValueChanged += new System.EventHandler(this.lookUpEdit_YearStudy_EditValueChanged);
            // 
            // layoutControlGroupMain
            // 
            this.layoutControlGroupMain.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroupMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupMain.GroupBordersVisible = false;
            this.layoutControlGroupMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemAcademicYear,
            this.layoutControlItemBtnAgree,
            this.layoutControlItemAcademicSemester,
            this.layoutControlItemBtnClose,
            this.emptySpaceItemLeftBtn});
            this.layoutControlGroupMain.Name = "layoutControlGroupMain";
            this.layoutControlGroupMain.Size = new System.Drawing.Size(345, 94);
            this.layoutControlGroupMain.TextVisible = false;
            // 
            // layoutControlItemAcademicYear
            // 
            this.layoutControlItemAcademicYear.Control = this.lookUpEditAcademicYear;
            this.layoutControlItemAcademicYear.CustomizationFormText = "Năm học";
            this.layoutControlItemAcademicYear.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemAcademicYear.Name = "layoutControlItemAcademicYear";
            this.layoutControlItemAcademicYear.Size = new System.Drawing.Size(325, 24);
            this.layoutControlItemAcademicYear.Text = "Năm học";
            this.layoutControlItemAcademicYear.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemAcademicYear.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlItemBtnAgree
            // 
            this.layoutControlItemBtnAgree.Control = this.btnAgree;
            this.layoutControlItemBtnAgree.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItemBtnAgree.Location = new System.Drawing.Point(202, 48);
            this.layoutControlItemBtnAgree.Name = "layoutControlItemBtnAgree";
            this.layoutControlItemBtnAgree.Size = new System.Drawing.Size(65, 26);
            this.layoutControlItemBtnAgree.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemBtnAgree.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnAgree.TextVisible = false;
            // 
            // layoutControlItemAcademicSemester
            // 
            this.layoutControlItemAcademicSemester.Control = this.lookUpEditAcademicSemester;
            this.layoutControlItemAcademicSemester.CustomizationFormText = "  Học kỳ";
            this.layoutControlItemAcademicSemester.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItemAcademicSemester.Name = "layoutControlItemAcademicSemester";
            this.layoutControlItemAcademicSemester.Size = new System.Drawing.Size(325, 24);
            this.layoutControlItemAcademicSemester.Text = "  Học kỳ";
            this.layoutControlItemAcademicSemester.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemAcademicSemester.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlItemBtnClose
            // 
            this.layoutControlItemBtnClose.Control = this.btnClose;
            this.layoutControlItemBtnClose.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItemBtnClose.Location = new System.Drawing.Point(267, 48);
            this.layoutControlItemBtnClose.Name = "layoutControlItemBtnClose";
            this.layoutControlItemBtnClose.Size = new System.Drawing.Size(58, 26);
            this.layoutControlItemBtnClose.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemBtnClose.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnClose.TextVisible = false;
            // 
            // emptySpaceItemLeftBtn
            // 
            this.emptySpaceItemLeftBtn.AllowHotTrack = false;
            this.emptySpaceItemLeftBtn.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItemLeftBtn.Name = "emptySpaceItemLeftBtn";
            this.emptySpaceItemLeftBtn.Size = new System.Drawing.Size(202, 26);
            this.emptySpaceItemLeftBtn.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_CMS_ChangeCurrentSemester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 94);
            this.Controls.Add(this.layoutControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_CMS_ChangeCurrentSemester";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UIS - Đổi Năm Học - Học Kỳ Hiện Tại";
            this.Load += new System.EventHandler(this.frm_CMS_ChangeCurrentSemester_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAcademicSemester.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAcademicYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAcademicYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnAgree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemAcademicSemester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemLeftBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnAgree;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditAcademicSemester;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditAcademicYear;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemAcademicYear;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemAcademicSemester;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnAgree;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnClose;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemLeftBtn;
    }
}