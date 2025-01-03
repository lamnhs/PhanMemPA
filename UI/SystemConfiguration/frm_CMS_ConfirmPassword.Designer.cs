namespace CMSUI.SystemConfiguration
{
    partial class frm_CMS_ConfirmPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_ConfirmPassword));
            this.layoutControlXacNhanMatKhau = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemMatKhau = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnXacNhan = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnThoat = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemBtn = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlXacNhanMatKhau)).BeginInit();
            this.layoutControlXacNhanMatKhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemMatKhau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnXacNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnThoat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlXacNhanMatKhau
            // 
            this.layoutControlXacNhanMatKhau.Controls.Add(this.btnClose);
            this.layoutControlXacNhanMatKhau.Controls.Add(this.btnConfirm);
            this.layoutControlXacNhanMatKhau.Controls.Add(this.txtMatKhau);
            this.layoutControlXacNhanMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlXacNhanMatKhau.Location = new System.Drawing.Point(0, 0);
            this.layoutControlXacNhanMatKhau.Name = "layoutControlXacNhanMatKhau";
            this.layoutControlXacNhanMatKhau.Root = this.Root;
            this.layoutControlXacNhanMatKhau.Size = new System.Drawing.Size(297, 71);
            this.layoutControlXacNhanMatKhau.TabIndex = 0;
            this.layoutControlXacNhanMatKhau.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageOptions.ImageIndex = 0;
            this.btnClose.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnClose.Location = new System.Drawing.Point(231, 36);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 22);
            this.btnClose.StyleController = this.layoutControlXacNhanMatKhau;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            // btnConfirm
            // 
            this.btnConfirm.AutoWidthInLayoutControl = true;
            this.btnConfirm.ImageOptions.ImageIndex = 6;
            this.btnConfirm.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnConfirm.Location = new System.Drawing.Point(157, 36);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(70, 22);
            this.btnConfirm.StyleController = this.layoutControlXacNhanMatKhau;
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(68, 12);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(217, 20);
            this.txtMatKhau.StyleController = this.layoutControlXacNhanMatKhau;
            this.txtMatKhau.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemMatKhau,
            this.layoutControlItemBtnXacNhan,
            this.layoutControlItemBtnThoat,
            this.emptySpaceItemBtn});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(297, 71);
            this.Root.TextVisible = false;
            // 
            // layoutControlItemMatKhau
            // 
            this.layoutControlItemMatKhau.Control = this.txtMatKhau;
            this.layoutControlItemMatKhau.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemMatKhau.Name = "layoutControlItemMatKhau";
            this.layoutControlItemMatKhau.Size = new System.Drawing.Size(277, 24);
            this.layoutControlItemMatKhau.Text = "Mật khẩu";
            this.layoutControlItemMatKhau.TextSize = new System.Drawing.Size(44, 13);
            // 
            // layoutControlItemBtnXacNhan
            // 
            this.layoutControlItemBtnXacNhan.Control = this.btnConfirm;
            this.layoutControlItemBtnXacNhan.Location = new System.Drawing.Point(145, 24);
            this.layoutControlItemBtnXacNhan.Name = "layoutControlItemBtnXacNhan";
            this.layoutControlItemBtnXacNhan.Size = new System.Drawing.Size(74, 27);
            this.layoutControlItemBtnXacNhan.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnXacNhan.TextVisible = false;
            // 
            // layoutControlItemBtnThoat
            // 
            this.layoutControlItemBtnThoat.Control = this.btnClose;
            this.layoutControlItemBtnThoat.Location = new System.Drawing.Point(219, 24);
            this.layoutControlItemBtnThoat.Name = "layoutControlItemBtnThoat";
            this.layoutControlItemBtnThoat.Size = new System.Drawing.Size(58, 27);
            this.layoutControlItemBtnThoat.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnThoat.TextVisible = false;
            // 
            // emptySpaceItemBtn
            // 
            this.emptySpaceItemBtn.AllowHotTrack = false;
            this.emptySpaceItemBtn.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItemBtn.Name = "emptySpaceItemBtn";
            this.emptySpaceItemBtn.Size = new System.Drawing.Size(145, 27);
            this.emptySpaceItemBtn.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_CMS_ConfirmPassword
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(297, 71);
            this.Controls.Add(this.layoutControlXacNhanMatKhau);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_CMS_ConfirmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UIS - Xác nhận mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlXacNhanMatKhau)).EndInit();
            this.layoutControlXacNhanMatKhau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemMatKhau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnXacNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnThoat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlXacNhanMatKhau;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemMatKhau;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnXacNhan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnThoat;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemBtn;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
    }
}