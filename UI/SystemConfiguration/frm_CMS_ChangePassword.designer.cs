namespace CMSUI.SystemConfiguration
{
    partial class frm_CMS_ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CMS_ChangePassword));
            this.layout_CommonInfo = new System.Windows.Forms.TableLayoutPanel();
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnSaveAndClose = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemOldPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemConfirmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemNewPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBtnSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItemBtnSave = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layout_CommonInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOldPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemNewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemBtnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // layout_CommonInfo
            // 
            this.layout_CommonInfo.BackColor = System.Drawing.SystemColors.Control;
            this.layout_CommonInfo.ColumnCount = 3;
            this.layout_CommonInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_CommonInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 590F));
            this.layout_CommonInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_CommonInfo.Controls.Add(this.layoutControlMain, 1, 1);
            this.layout_CommonInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_CommonInfo.Location = new System.Drawing.Point(0, 0);
            this.layout_CommonInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layout_CommonInfo.Name = "layout_CommonInfo";
            this.layout_CommonInfo.RowCount = 3;
            this.layout_CommonInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.40267F));
            this.layout_CommonInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 228F));
            this.layout_CommonInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.59733F));
            this.layout_CommonInfo.Size = new System.Drawing.Size(1202, 445);
            this.layout_CommonInfo.TabIndex = 13;
            // 
            // layoutControlMain
            // 
            this.layoutControlMain.Controls.Add(this.btnSaveAndClose);
            this.layoutControlMain.Controls.Add(this.btnClose);
            this.layoutControlMain.Controls.Add(this.txtNewPassword);
            this.layoutControlMain.Controls.Add(this.txtConfirmPassword);
            this.layoutControlMain.Controls.Add(this.txtOldPassword);
            this.layoutControlMain.Controls.Add(this.txtUserName);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(310, 112);
            this.layoutControlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.Root = this.Root;
            this.layoutControlMain.Size = new System.Drawing.Size(582, 218);
            this.layoutControlMain.TabIndex = 16;
            this.layoutControlMain.Text = "layoutControl1";
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.AutoWidthInLayoutControl = true;
            this.btnSaveAndClose.ImageOptions.ImageIndex = 4;
            this.btnSaveAndClose.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnSaveAndClose.Location = new System.Drawing.Point(372, 148);
            this.btnSaveAndClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(117, 32);
            this.btnSaveAndClose.StyleController = this.layoutControlMain;
            this.btnSaveAndClose.TabIndex = 13;
            this.btnSaveAndClose.Text = "Lưu và thoát";
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSave_Click);
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
            // btnClose
            // 
            this.btnClose.AutoWidthInLayoutControl = true;
            this.btnClose.ImageOptions.ImageIndex = 0;
            this.btnClose.ImageOptions.ImageList = this.imageCollectionSmall;
            this.btnClose.Location = new System.Drawing.Point(495, 148);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 32);
            this.btnClose.StyleController = this.layoutControlMain;
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(171, 84);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Properties.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(393, 26);
            this.txtNewPassword.StyleController = this.layoutControlMain;
            this.txtNewPassword.TabIndex = 11;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(171, 116);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(393, 26);
            this.txtConfirmPassword.StyleController = this.layoutControlMain;
            this.txtConfirmPassword.TabIndex = 12;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(171, 52);
            this.txtOldPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Properties.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(393, 26);
            this.txtOldPassword.StyleController = this.layoutControlMain;
            this.txtOldPassword.TabIndex = 10;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(171, 18);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(393, 28);
            this.txtUserName.StyleController = this.layoutControlMain;
            this.txtUserName.TabIndex = 15;
            this.txtUserName.TabStop = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemUserName,
            this.layoutControlItemOldPassword,
            this.layoutControlItemConfirmPassword,
            this.layoutControlItemNewPassword,
            this.layoutControlItem5,
            this.layoutControlItemBtnSave,
            this.emptySpaceItemBtnSave});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(582, 218);
            this.Root.TextVisible = false;
            // 
            // layoutControlItemUserName
            // 
            this.layoutControlItemUserName.Control = this.txtUserName;
            this.layoutControlItemUserName.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemUserName.Name = "layoutControlItemUserName";
            this.layoutControlItemUserName.Size = new System.Drawing.Size(552, 34);
            this.layoutControlItemUserName.Text = "Người dùng";
            this.layoutControlItemUserName.TextSize = new System.Drawing.Size(135, 19);
            // 
            // layoutControlItemOldPassword
            // 
            this.layoutControlItemOldPassword.Control = this.txtOldPassword;
            this.layoutControlItemOldPassword.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItemOldPassword.Name = "layoutControlItemOldPassword";
            this.layoutControlItemOldPassword.Size = new System.Drawing.Size(552, 32);
            this.layoutControlItemOldPassword.Text = "Mật khẩu cũ";
            this.layoutControlItemOldPassword.TextSize = new System.Drawing.Size(135, 19);
            // 
            // layoutControlItemConfirmPassword
            // 
            this.layoutControlItemConfirmPassword.Control = this.txtConfirmPassword;
            this.layoutControlItemConfirmPassword.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItemConfirmPassword.Name = "layoutControlItemConfirmPassword";
            this.layoutControlItemConfirmPassword.Size = new System.Drawing.Size(552, 32);
            this.layoutControlItemConfirmPassword.Text = "Xác nhận mật khẩu";
            this.layoutControlItemConfirmPassword.TextSize = new System.Drawing.Size(135, 19);
            // 
            // layoutControlItemNewPassword
            // 
            this.layoutControlItemNewPassword.Control = this.txtNewPassword;
            this.layoutControlItemNewPassword.Location = new System.Drawing.Point(0, 66);
            this.layoutControlItemNewPassword.Name = "layoutControlItemNewPassword";
            this.layoutControlItemNewPassword.Size = new System.Drawing.Size(552, 32);
            this.layoutControlItemNewPassword.Text = "Mật khẩu mới";
            this.layoutControlItemNewPassword.TextSize = new System.Drawing.Size(135, 19);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnClose;
            this.layoutControlItem5.Location = new System.Drawing.Point(477, 130);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(75, 58);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItemBtnSave
            // 
            this.layoutControlItemBtnSave.Control = this.btnSaveAndClose;
            this.layoutControlItemBtnSave.Location = new System.Drawing.Point(354, 130);
            this.layoutControlItemBtnSave.Name = "layoutControlItemBtnSave";
            this.layoutControlItemBtnSave.Size = new System.Drawing.Size(123, 58);
            this.layoutControlItemBtnSave.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemBtnSave.TextVisible = false;
            // 
            // emptySpaceItemBtnSave
            // 
            this.emptySpaceItemBtnSave.AllowHotTrack = false;
            this.emptySpaceItemBtnSave.Location = new System.Drawing.Point(0, 130);
            this.emptySpaceItemBtnSave.Name = "emptySpaceItemBtnSave";
            this.emptySpaceItemBtnSave.Size = new System.Drawing.Size(354, 58);
            this.emptySpaceItemBtnSave.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frm_CMS_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1202, 445);
            this.Controls.Add(this.layout_CommonInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_CMS_ChangePassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UIS - Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frm_CMS_ChangePassword_Load);
            this.layout_CommonInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemOldPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemNewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItemBtnSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel layout_CommonInfo;
        private DevExpress.XtraEditors.SimpleButton btnSaveAndClose;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.TextEdit txtOldPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private DevExpress.XtraEditors.TextEdit txtNewPassword;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemUserName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemOldPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemConfirmPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemNewPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBtnSave;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemBtnSave;
    }
}