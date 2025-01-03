using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using System.Resources;
using CMSCore.BLL;
using CMSDevExpressCommon;
using DevExpress.XtraEditors.Repository;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_DetailFile : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        DataTable _dtData = new DataTable();
        string _luoiHienThi = string.Empty;
        public string _MaNV = string.Empty, _TuNgay = string.Empty, _DenNgay = string.Empty;
        public int _SoLuong = 0;

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_DetailFile()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_GridColumn_Load(object sender, EventArgs e)
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
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_DetailFile).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnExcel.Text = rm.GetString("ExportExcel", CMSUser._culture);
        }
       
        private void GetData()
        {
            try
            {
            _dtData = BL_ManageDegreeAndCertificate.GetDetailNhanVien(_MaNV, _SoLuong, _TuNgay, _DenNgay);


                foreach (DataColumn dc in _dtData.Columns)
                {
                    dc.ReadOnly = false;
                    dc.AllowDBNull = true;
                }

                gridControlData.DataSource = _dtData;

                #region Định nghĩa lưới
                DataTable dtGrid = BL_System.GetGrid();
                DataRow _drGrids = (DataRow)dtGrid.Select("GridID = 'QLVBCC-QLVBCC-DetailNhanVien'").GetValue(0);
                DataTable _dtGridColumns = BL_System.GetGridColumn(_drGrids["ID"].ToString());
                #endregion

                AppGridView.InitGridView(gridViewData, _drGrids, _dtGridColumns, CMSUser._foreignLanguageInterface);

                if (_drGrids["ReadOnlyAllGrid"].ToString() == "True")
                    AppGridView.ReadOnlyColumn(gridViewData);

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

        #endregion

        #region Events
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btn_refresh_Click(object sender, EventArgs e)
        {
            frm_CMS_GridColumn_Load(null, null);
        }


        private void gridViewData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
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
        #endregion

    }
}