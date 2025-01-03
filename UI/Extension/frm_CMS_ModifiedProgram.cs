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
using DevExpress.XtraEditors.Controls;
using System.Resources;
using CMSCore.BLL;
using CMSDevExpressCommon;
using DevExpress.Export;

namespace CMSUI.Extension
{
    public partial class frm_CMS_ModifiedProgram : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        DataTable _dtData = new DataTable();

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_ModifiedProgram()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_ModifiedProgram_Load(object sender, EventArgs e)
        {
            #region Phân quyền
            CommonFunctions.SetFormPermiss(this);
            #endregion

            #region Bậc đào tạo mặc định
            GetGraduateLevels();
            if (CMSUser._CurrentGraduateLevelID == string.Empty)
                chkComboBacDaoTao.CheckAll();
            else
            {
                bool macDinh = false;
                foreach (string str in CMSUser._CurrentGraduateLevelID.Split(';'))
                    if (((DataTable)chkComboBacDaoTao.Properties.DataSource).Select("GraduateLevelID = '" + str + "'").Length > 0)
                    {
                        macDinh = true;
                        break;
                    }

                if (macDinh == false)
                    chkComboBacDaoTao.CheckAll();
                else
                    chkComboBacDaoTao.EditValue = CMSUser._CurrentGraduateLevelID;
            }
            chkComboBacDaoTao.RefreshEditValue();
            #endregion

            #region Loại hình đào tạo mặc định
            GetStudyTypes();
            if (CMSUser._CurrentStudyTypeID == string.Empty)
                chkComboLoaiHinhDaoTao.CheckAll();
            else
            {
                bool macDinh = false;
                foreach (string str in CMSUser._CurrentStudyTypeID.Split(';'))
                    if (((DataTable)chkComboLoaiHinhDaoTao.Properties.DataSource).Select("StudyTypeID = '" + str + "'").Length > 0)
                    {
                        macDinh = true;
                        break;
                    }

                if (macDinh == false)
                    chkComboLoaiHinhDaoTao.CheckAll();
                else
                    chkComboLoaiHinhDaoTao.EditValue = CMSUser._CurrentStudyTypeID;
            }
            chkComboLoaiHinhDaoTao.RefreshEditValue();
            #endregion

            DanhHieu();
            GetLanguage();
            GetQualityStandard();
        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_ModifiedProgram).Assembly);

            btnFilter.Text = rm.GetString("btnFilter", CMSUser._culture);
            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnSave.Text = rm.GetString("btnSave", CMSUser._culture);
            btnExcel.Text = rm.GetString("ExportExcel", CMSUser._culture);
            layoutControlItemAcademicLevel.Text = rm.GetString("layoutControlItemAcademicLevel", CMSUser._culture);
            layoutControlItemModeOfStudy.Text = rm.GetString("layoutControlItemModeOfStudy", CMSUser._culture);
            layoutControlItemCourse.Text = rm.GetString("layoutControlItemCourse", CMSUser._culture);
            layoutControlItemTitle.Text = rm.GetString("layoutControlItemTitle", CMSUser._culture);
            layoutControlItemLanguage.Text = rm.GetString("layoutControlItemLanguage", CMSUser._culture);
            layoutControlItemQualityStandard.Text = rm.GetString("layoutControlItemQualityStandard", CMSUser._culture);

            mnu_CapNhatCLC.Text = rm.GetString("btnSetAdvanceProgramed", CMSUser._culture);
            mnu_HuyCLC.Text = rm.GetString("btnDeleteAdvanceProgramed", CMSUser._culture);
            mnu_CapNhatTaiNang.Text = rm.GetString("btn_CapNhatCTTaiNang", CMSUser._culture);
            mnu_HuyTaiNang.Text = rm.GetString("btn_HuyCTTaiNang", CMSUser._culture);
            btn_CapNhatThongTin.Text = rm.GetString("btn_CapNhat", CMSUser._culture);
        }

        private void GetGraduateLevels()
        {
            try
            {
                DataTable _dtGraduateLevels = CMSUser._dsDataDictionaries.Tables["GraduateLevels"].Copy();
                AppDevExpressEditControl.InitCheckedComboBoxEdit(chkComboBacDaoTao, _dtGraduateLevels, "GraduateLevelName", "GraduateLevelID", string.Empty, rm.GetString("ChonTatCa", CMSUser._culture), ';', false);
            }
            catch { }
        }

        private void GetStudyTypes()
        {
            try
            {
                DataTable _dtStudyTypes = CMSUser._dsDataDictionaries.Tables["StudyTypes"].Copy();
                AppDevExpressEditControl.InitCheckedComboBoxEdit(chkComboLoaiHinhDaoTao, _dtStudyTypes, "StudyTypeName", "StudyTypeID", string.Empty, rm.GetString("ChonTatCa", CMSUser._culture), ';', false);
            }
            catch { }
        }

        private void GetCourses()
        {
            try
            {
                if (chkComboBacDaoTao.EditValue == null || chkComboLoaiHinhDaoTao.EditValue == null)
                    return;

                #region Định nghĩa lưới
                DataTable dtGrid = BL_System.GetGrid();
                DataRow _drGrids = (DataRow)dtGrid.Select("GridID = 'frm_CMS_ModifiedProgram_Course'").GetValue(0);
                DataTable _dtGridColumns = BL_System.GetGridColumn(_drGrids["ID"].ToString());
                #endregion

                gridView_KhoaHoc.Columns.Clear();

                DataTable dtCourses = BL_System.GetCourse(chkComboBacDaoTao.EditValue.ToString(), chkComboLoaiHinhDaoTao.EditValue.ToString());

                gridControl_KhoaHoc.DataSource = dtCourses;
              
                AppGridView.InitGridView(gridView_KhoaHoc, _drGrids, _dtGridColumns, CMSUser._foreignLanguageInterface);

                if (_drGrids["ReadOnlyAllGrid"].ToString() == "True")
                    AppGridView.ReadOnlyColumn(gridView_KhoaHoc);

                if (_drGrids["ColumnAutoWidth"].ToString() == "True")
                    gridView_KhoaHoc.OptionsView.ColumnAutoWidth = true;
                else
                    gridView_KhoaHoc.OptionsView.ColumnAutoWidth = false;

                if (_drGrids["BestFitColumns"].ToString() == "True")
                    gridView_KhoaHoc.BestFitColumns();

                Cursor.Current = Cursors.Default;
            }
            catch { }
        }

        private void GetData()
        {
            try
            {
                _dtData = BL_Extension.GetStudyPrograms(chkComboKhoaHoc.EditValue.ToString(), CMSUser._foreignLanguageData);

                foreach (DataColumn dc in _dtData.Columns)
                    dc.ReadOnly = false;

                gridControlData.DataSource = _dtData;

                #region Định nghĩa lưới
                DataTable dtGrid = BL_System.GetGrid();
                DataRow _drGrids = (DataRow)dtGrid.Select("GridID = 'MR-MR-CTDT'").GetValue(0);
                DataTable _dtGridColumns = BL_System.GetGridColumn(_drGrids["ID"].ToString());
                #endregion

                AppGridView.InitGridView(gridViewData, _drGrids, _dtGridColumns, CMSUser._foreignLanguageInterface);

                if (_drGrids["ReadOnlyAllGrid"].ToString() == "True")
                    AppGridView.ReadOnlyColumn(gridViewData);

                #region Danh hiệu
                DataTable dtDanhHieu = BL_Extension.viewGetTitle();
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEdit_danhHieu, dtDanhHieu, "GraduationDegreeName", "GraduationDegreeID", string.Empty, "GraduationDegreeName", rm.GetString("layoutControlItemTitle", CMSUser._culture), 0);
                gridViewData.Columns["GraduationDegreeID"].ColumnEdit = repositoryItemLookUpEdit_danhHieu;
                #endregion

                #region Ngôn ngữ đào tạo
                DataTable dtLanguage = BL_Extension.GetLanguage();
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditLanguage, dtLanguage, "TenNgonNguGD", "MaNgonNguGD", string.Empty, "TenNgonNguGD", rm.GetString("layoutControlItemLanguage", CMSUser._culture), 0);
                gridViewData.Columns["MaNgonNguGD"].ColumnEdit = repositoryItemLookUpEditLanguage;
                #endregion

                #region Chuẩn kiểm định
                DataTable dtQualityStandard = BL_Extension.GetQualityStandard();
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditQualityStandard, dtQualityStandard, "TenChuanKiemDinh", "MaChuanKiemDinh", string.Empty, "TenChuanKiemDinh", rm.GetString("layoutControlItemQualityStandard", CMSUser._culture), 0);
                gridViewData.Columns["MaChuanKiemDinh"].ColumnEdit = repositoryItemLookUpEditQualityStandard;
                #endregion

                if (_drGrids["ColumnAutoWidth"].ToString() == "True")
                    gridViewData.OptionsView.ColumnAutoWidth = true;
                else
                    gridViewData.OptionsView.ColumnAutoWidth = false;

                if (_drGrids["BestFitColumns"].ToString() == "True")
                    gridViewData.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DanhHieu()
        {
            try
            {
                DataTable dtDanhHieu = BL_Extension.viewGetTitle();
                AppDevExpressEditControl.InitLookUpEdit(lkuDanhHieu, dtDanhHieu, "GraduationDegreeName", "GraduationDegreeID", string.Empty, "GraduationDegreeName", rm.GetString("layoutControlItemTitle", CMSUser._culture), 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetLanguage()
        {
            try
            {
                DataTable dtLanguage = BL_Extension.GetLanguage();
                AppDevExpressEditControl.InitLookUpEdit(lookUpEditLanguage, dtLanguage, "TenNgonNguGD", "MaNgonNguGD", string.Empty, "TenNgonNguGD", rm.GetString("layoutControlItemLanguage", CMSUser._culture), 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetQualityStandard()
        {
            try
            {
                DataTable dtQualityStandard = BL_Extension.GetQualityStandard();
                AppDevExpressEditControl.InitLookUpEdit(lookUpEditQualityStandard, dtQualityStandard, "TenChuanKiemDinh", "MaChuanKiemDinh", string.Empty, "TenChuanKiemDinh", rm.GetString("layoutControlItemQualityStandard", CMSUser._culture), 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    SystemConfiguration.frm_CMS_ConfirmPassword frm = new SystemConfiguration.frm_CMS_ConfirmPassword();
                    frm.ShowDialog();

                    if (frm._confirm == false)
                        return;
                }

                string strXml = string.Empty;
                foreach (DataRow dr in _dtData.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                        strXml += "<StudyPrograms StudyProgramID = \"" + dr["StudyProgramID"].ToString()
                                + "\" GraduationDegreeID = \"" + dr["GraduationDegreeID"].ToString()
                                + "\" MaNgonNguGD = \"" + dr["MaNgonNguGD"].ToString()
                                + "\" MaChuanKiemDinh = \"" + dr["MaChuanKiemDinh"].ToString()
                                + "\" ChatLuongCao = \"" + dr["ChatLuongCao"].ToString()
                                + "\" IsTaiNang = \"" + dr["IsTaiNang"].ToString()
                                + "\"/>";
                }

                if (strXml == string.Empty)
                    return;

                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_Extension.SaveStudyPrograms(strXml, CMSUser._UserID);

                if (result == 0)
                {
                    GetData();
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events
        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuuDuLieu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void chkComboLoaiHinhDaoTao_EditValueChanged(object sender, EventArgs e)
        {
            GetCourses();
        }

        private void chkComboBacDaoTao_EditValueChanged(object sender, EventArgs e)
        {
            GetCourses();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frm_CMS_ModifiedProgram_Load(null, null);
        }

        private void btnDanhHieu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    gridViewData.GetDataRow(i)["GraduationDegreeID"] = lkuDanhHieu.EditValue.ToString();
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfdFiles = new SaveFileDialog();

                sfdFiles.Filter = "Excel Workbook|*.xlsx";

                if (sfdFiles.ShowDialog() == DialogResult.OK && sfdFiles.FileName != string.Empty)
                {
                    AppGridView.GridViewExportExcel(gridViewData, gridControlData, sfdFiles.FileName, true);

                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnSetLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    gridViewData.GetDataRow(i)["MaNgonNguGD"] = lookUpEditLanguage.EditValue.ToString();
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void btnSetQualityStandard_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    gridViewData.GetDataRow(i)["MaChuanKiemDinh"] = lookUpEditQualityStandard.EditValue.ToString();
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void btnDeleteQualityStandard_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    gridViewData.GetDataRow(i)["MaChuanKiemDinh"] = DBNull.Value;
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void btnDeleteLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    gridViewData.GetDataRow(i)["MaNgonNguGD"] = DBNull.Value;
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void btnDeleteTitle_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    gridViewData.GetDataRow(i)["GraduationDegreeID"] = DBNull.Value;
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void chkComboKhoaHoc_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            try
            {
                string value = string.Empty;
                foreach (int i in gridView_KhoaHoc.GetSelectedRows())
                {
                    DataRow v = gridView_KhoaHoc.GetDataRow(i);
                    value += string.Format("{0};", v["CourseID"]);
                }

                if (value.Length > 0)
                    value = value.Remove(value.Length - 1, 1);

                e.Value = value;
            }
            catch { }
        }

        private void gridView_KhoaHoc_DoubleClick(object sender, EventArgs e)
        {
            if (popupContainerControlCourse.OwnerEdit != null)
                popupContainerControlCourse.OwnerEdit.ClosePopup();
        }

        private void mnu_CapNhatCLC_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    gridViewData.GetDataRow(i)["ChatLuongCao"] = true;
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void mnu_HuyCLC_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    gridViewData.GetDataRow(i)["ChatLuongCao"] = false;
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void mnu_CapNhatTaiNang_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    gridViewData.GetDataRow(i)["IsTaiNang"] = true;
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void mnu_HuyTaiNang_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    gridViewData.GetDataRow(i)["IsTaiNang"] = false;
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void btn_CapNhatThongTin_Click(object sender, EventArgs e)
        {
            cms_UpDate.Show(Cursor.Position.X, Cursor.Position.Y);
        }
        #endregion
    }
}