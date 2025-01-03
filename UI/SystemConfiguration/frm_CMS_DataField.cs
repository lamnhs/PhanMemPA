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
using CMSDevExpressCommon;
using CMSCore.BLL;
using System.Resources;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_DataField : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        DataTable _dtData = new DataTable();

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_DataField()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_DataField_Load(object sender, EventArgs e)
        {
            #region Phân quyền
            CommonFunctions.SetFormPermiss(this);
            #endregion

            GetData();
        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_Grid).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnSave.Text = rm.GetString("btnSave", CMSUser._culture);
            btnDelete.Text = rm.GetString("btnDelete", CMSUser._culture);
        }

        private void GetData()
        {
            try
            {
                _dtData = BL_System.GetDataField();
                _dtData.Columns["OldTenTruongDuLieu"].AllowDBNull = true;

                gridControlData.DataSource = _dtData;

                #region Định nghĩa lưới
                DataTable dtGrid = BL_System.GetGrid();
                DataRow drGrids = (DataRow)dtGrid.Select("GridID = 'HT-HT-TruongDuLieu'").GetValue(0);
                DataTable dtGridColumns = BL_System.GetGridColumn(drGrids["ID"].ToString());
                #endregion

                AppGridView.InitGridView(gridViewData, drGrids, dtGridColumns, CMSUser._foreignLanguageInterface);

                if (drGrids["ReadOnlyAllGrid"].ToString() == "True")
                    AppGridView.ReadOnlyColumn(gridViewData);

                if (drGrids["ColumnAutoWidth"].ToString() == "True")
                    gridViewData.OptionsView.ColumnAutoWidth = true;
                else
                    gridViewData.OptionsView.ColumnAutoWidth = false;

                if (drGrids["BestFitColumns"].ToString() == "True")
                    gridViewData.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveData()
        {
            try
            {
                if (CMSUser._HoiLaiKhiLuu)
                {
                    if (XtraMessageBox.Show(rm.GetString("LuuDuLieu?", CMSUser._culture),
                                rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;
                }

                if (CMSUser._XacNhanMatKhauKhiLuu)
                {
                    frm_CMS_ConfirmPassword frm = new frm_CMS_ConfirmPassword();
                    frm.ShowDialog();

                    if (frm._confirm == false)
                        return;
                }

                string strXml = string.Empty;
                foreach (DataRow dr in _dtData.Rows)
                {
                    if (dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Added)
                    {
                        strXml += "<TruongIn TenTruongDuLieu = \"" + dr["TenTruongDuLieu"].ToString()
                                + "\" DienGiai = \"" + dr["DienGiai"].ToString()
                                + "\" DienGiaiTiengAnh = \"" + dr["DienGiaiTiengAnh"].ToString()
                                + "\" DuLieuMau = \"" + dr["DuLieuMau"].ToString()
                                + "\" TenTruongDuLieuCu = \"" + dr["OldTenTruongDuLieu"].ToString()
                                + "\"/>";
                    }
                }

                if (strXml == string.Empty)
                    return;

                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_System.SaveDataField(strXml, CMSUser._UserID);

                if (result == 0)
                {
                    GetData();
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture),
                        rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture),
                        rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteData()
        {
            try
            {
                if (CMSUser._HoiLaiKhiXoa)
                {
                    if (XtraMessageBox.Show(rm.GetString("XoaDuLieu?", CMSUser._culture),
                                rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;
                }

                if (CMSUser._XacNhanMatKhauKhiXoa)
                {
                    frm_CMS_ConfirmPassword frm = new frm_CMS_ConfirmPassword();
                    frm.ShowDialog();

                    if (frm._confirm == false)
                        return;
                }

                string strXml = string.Empty;
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    strXml += "<TruongIn TenTruongDuLieu = \"" + gridViewData.GetDataRow(i)["OldTenTruongDuLieu"].ToString()
                            + "\"/>";
                }

                if (strXml == string.Empty)
                    return;

                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_System.DeleteDataField(strXml, CMSUser._UserID);

                if (result == 0)
                {
                    GetData();
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture),
                        rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture),
                        rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuuDuLieu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnXoaDuLieu_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frm_CMS_DataField_Load(null, null);
        }

        private void gridViewData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        #endregion
    }
}