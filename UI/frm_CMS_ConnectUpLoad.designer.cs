namespace CMSUI
{
    partial class frm_CMS_ConnectUpLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_ConnectUpLoad));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtServerName = new DevExpress.XtraEditors.TextEdit();
            this.txtTenDangNhap = new DevExpress.XtraEditors.TextEdit();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.txtThuMuc = new DevExpress.XtraEditors.TextEdit();
            this.txtDomain = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemProvider = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemFolder = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemServerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem_btnFinish = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem_btnClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem_buttonLeft = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItemButtonTop = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuMuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDomain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemServerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_btnFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem_buttonLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemButtonTop)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 342F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.layoutControl, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(495, 294);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnClose);
            this.layoutControl.Controls.Add(this.btnSave);
            this.layoutControl.Controls.Add(this.txtServerName);
            this.layoutControl.Controls.Add(this.txtTenDangNhap);
            this.layoutControl.Controls.Add(this.txtMatKhau);
            this.layoutControl.Controls.Add(this.txtThuMuc);
            this.layoutControl.Controls.Add(this.txtDomain);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(79, 59);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(336, 176);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.ImageOptions.ImageIndex = 3;
            this.btnClose.ImageOptions.ImageList = this.imageCollection;
            this.btnClose.Location = new System.Drawing.Point(270, 142);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 22);
            this.btnClose.StyleController = this.layoutControl;
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "add_16x16.png");
            this.imageCollection.Images.SetKeyName(1, "apply_16x16.png");
            this.imageCollection.Images.SetKeyName(2, "cancel_16x16.png");
            this.imageCollection.Images.SetKeyName(3, "close_16x16.png");
            this.imageCollection.Images.SetKeyName(4, "refresh_16x16.png");
            this.imageCollection.Images.SetKeyName(5, "save_16x16.png");
            this.imageCollection.Images.SetKeyName(6, "deletesheetrows_16x16.png");
            this.imageCollection.Images.SetKeyName(7, "exporttoxlsx_16x16.png");
            // 
            // btnSave
            // 
            this.btnSave.AutoWidthInLayoutControl = true;
            this.btnSave.ImageOptions.ImageIndex = 5;
            this.btnSave.ImageOptions.ImageList = this.imageCollection;
            this.btnSave.Location = new System.Drawing.Point(187, 142);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 22);
            this.btnSave.StyleController = this.layoutControl;
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu dữ liệu";
            this.btnSave.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(100, 36);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(224, 20);
            this.txtServerName.StyleController = this.layoutControl;
            this.txtServerName.TabIndex = 10;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(100, 60);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(224, 20);
            this.txtTenDangNhap.StyleController = this.layoutControl;
            this.txtTenDangNhap.TabIndex = 9;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(100, 84);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(224, 20);
            this.txtMatKhau.StyleController = this.layoutControl;
            this.txtMatKhau.TabIndex = 8;
            // 
            // txtThuMuc
            // 
            this.txtThuMuc.Location = new System.Drawing.Point(100, 108);
            this.txtThuMuc.Name = "txtThuMuc";
            this.txtThuMuc.Size = new System.Drawing.Size(224, 20);
            this.txtThuMuc.StyleController = this.layoutControl;
            this.txtThuMuc.TabIndex = 7;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(100, 12);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(224, 20);
            this.txtDomain.StyleController = this.layoutControl;
            this.txtDomain.TabIndex = 4;
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemProvider,
            this.layoutControlItemFolder,
            this.layoutControlItemPassword,
            this.layoutControlItemUserName,
            this.layoutControlItemServerName,
            this.layoutControlItem_btnFinish,
            this.layoutControlItem_btnClose,
            this.emptySpaceItem_buttonLeft,
            this.emptySpaceItemButtonTop});
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Size = new System.Drawing.Size(336, 176);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItemProvider
            // 
            this.layoutControlItemProvider.Control = this.txtDomain;
            this.layoutControlItemProvider.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemProvider.Name = "layoutControlItemProvider";
            this.layoutControlItemProvider.Size = new System.Drawing.Size(316, 24);
            this.layoutControlItemProvider.Text = "Domain:";
            this.layoutControlItemProvider.TextSize = new System.Drawing.Size(76, 13);
            // 
            // layoutControlItemFolder
            // 
            this.layoutControlItemFolder.Control = this.txtThuMuc;
            this.layoutControlItemFolder.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItemFolder.Name = "layoutControlItemFolder";
            this.layoutControlItemFolder.Size = new System.Drawing.Size(316, 24);
            this.layoutControlItemFolder.Text = "Thư mục:";
            this.layoutControlItemFolder.TextSize = new System.Drawing.Size(76, 13);
            // 
            // layoutControlItemPassword
            // 
            this.layoutControlItemPassword.Control = this.txtMatKhau;
            this.layoutControlItemPassword.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItemPassword.Name = "layoutControlItemPassword";
            this.layoutControlItemPassword.Size = new System.Drawing.Size(316, 24);
            this.layoutControlItemPassword.Text = "Mật khẩu:";
            this.layoutControlItemPassword.TextSize = new System.Drawing.Size(76, 13);
            // 
            // layoutControlItemUserName
            // 
            this.layoutControlItemUserName.Control = this.txtTenDangNhap;
            this.layoutControlItemUserName.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItemUserName.Name = "layoutControlItemUserName";
            this.layoutControlItemUserName.Size = new System.Drawing.Size(316, 24);
            this.layoutControlItemUserName.Text = "Tên đăng nhập:";
            this.layoutControlItemUserName.TextSize = new System.Drawing.Size(76, 13);
            // 
            // layoutControlItemServerName
            // 
            this.layoutControlItemServerName.Control = this.txtServerName;
            this.layoutControlItemServerName.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItemServerName.Name = "layoutControlItemServerName";
            this.layoutControlItemServerName.Size = new System.Drawing.Size(316, 24);
            this.layoutControlItemServerName.Text = "Server name:";
            this.layoutControlItemServerName.TextSize = new System.Drawing.Size(76, 13);
            // 
            // layoutControlItem_btnFinish
            // 
            this.layoutControlItem_btnFinish.Control = this.btnSave;
            this.layoutControlItem_btnFinish.Location = new System.Drawing.Point(175, 130);
            this.layoutControlItem_btnFinish.Name = "layoutControlItem_btnFinish";
            this.layoutControlItem_btnFinish.Size = new System.Drawing.Size(83, 26);
            this.layoutControlItem_btnFinish.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem_btnFinish.TextVisible = false;
            // 
            // layoutControlItem_btnClose
            // 
            this.layoutControlItem_btnClose.Control = this.btnClose;
            this.layoutControlItem_btnClose.Location = new System.Drawing.Point(258, 130);
            this.layoutControlItem_btnClose.Name = "layoutControlItem_btnClose";
            this.layoutControlItem_btnClose.Size = new System.Drawing.Size(58, 26);
            this.layoutControlItem_btnClose.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem_btnClose.TextVisible = false;
            // 
            // emptySpaceItem_buttonLeft
            // 
            this.emptySpaceItem_buttonLeft.AllowHotTrack = false;
            this.emptySpaceItem_buttonLeft.Location = new System.Drawing.Point(0, 130);
            this.emptySpaceItem_buttonLeft.Name = "emptySpaceItem_buttonLeft";
            this.emptySpaceItem_buttonLeft.Size = new System.Drawing.Size(175, 26);
            this.emptySpaceItem_buttonLeft.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItemButtonTop
            // 
            this.emptySpaceItemButtonTop.AllowHotTrack = false;
            this.emptySpaceItemButtonTop.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItemButtonTop.Name = "emptySpaceItemButtonTop";
            this.emptySpaceItemButtonTop.Size = new System.Drawing.Size(316, 10);
            this.emptySpaceItemButtonTop.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_CMS_ConnectUpLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 294);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "frm_CMS_ConnectUpLoad";
            this.Text = "UIS - Cấu hình UpdaLoad file phụ lục văn bằng";
            this.Load += new System.EventHandler(this.frm_CMS_ConnectUpLoad_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThuMuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDomain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemServerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_btnFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem_btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem_buttonLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemButtonTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtServerName;
        private DevExpress.XtraEditors.TextEdit txtTenDangNhap;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.TextEdit txtThuMuc;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemProvider;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemFolder;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemUserName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemServerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem_btnFinish;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem_btnClose;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem_buttonLeft;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.TextEdit txtDomain;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemButtonTop;
    }
}