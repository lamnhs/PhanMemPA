using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Resources;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_ThemMoiDonHang : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        ResourceManager rm;
        public bool _confirm = false;
        public string SoLuong = string.Empty;
        #endregion

        #region Inits
        public frm_CMS_ThemMoiDonHang()
        {
            InitializeComponent();
            SetLanguage();
        } 
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_ConfirmPassword).Assembly);

            btnConfirm.Text = rm.GetString("btnConfirm", CMSUser._culture);
            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            //layoutControlItemSoLuong.Text = rm.GetString("MatKhau", CMSUser._culture);
        }
        #endregion

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn thêm mới số lượng đơn hàng này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Kiểm tra người dùng có nhấn "Yes" hay không
            if (result == DialogResult.Yes)
            {
                // Gán giá trị và đóng form
                SoLuong = txtMatKhau.Text;
                this.Close();
                _confirm = true;
            }else
            {
                _confirm = false;
            }
            
        }
        #endregion

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (Backspace, Delete)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn ký tự không hợp lệ
            }
        }
    }
}