using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using CMSCore.BLL;
using System.Resources;
using CMSDevExpressCommon;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_ImportExcel : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        public DataTable _dtResult = new DataTable(), _dtExcelMapping = new DataTable();
        public string _sChucNang = string.Empty;

        public bool _isAccepted = false;
        DataTable _dtColumnExcelSheet = new DataTable();

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_ImportExcel()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_ImportExcel_Load(object sender, EventArgs e)
        {
            MappingColumns();
        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_ImportExcel).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnOK.Text = rm.GetString("btnAgree", CMSUser._culture);
            this.Text = rm.GetString("frm_CMS_ImportExcel", CMSUser._culture); 
            btnExportExcel.Text = rm.GetString("ExportExcel", CMSUser._culture);
        }

        private void MappingColumns()
        {
            try
            {
                gridControlData.DataSource = null;
                gridViewData.Columns.Clear();

                #region Lưới hiển thị
                DataTable dtGrid = BL_System.GetGrid();
                DataRow drGrids = (DataRow)dtGrid.Select("GridID = '" + _sChucNang + "'").GetValue(0);
                DataTable dtGridColumns = BL_System.GetGridColumn(drGrids["ID"].ToString());
                #endregion

                #region Cấu trúc file import
                _dtExcelMapping = new DataTable();
                _dtExcelMapping.Columns.Add("ID", typeof(string));
                _dtExcelMapping.Columns.Add("ColumnName", typeof(string));
                _dtExcelMapping.Columns.Add("ColumnMapping", typeof(string));

                _dtColumnExcelSheet = new DataTable();
                _dtColumnExcelSheet.Columns.Add("ColumnExcel", typeof(string));
                #endregion

                foreach (DataRow dr in dtGridColumns.Rows)
                {
                    if (dr["ID"].ToString() != "TinhTrang" && bool.Parse(dr["Visible"].ToString()) == true)
                    {
                        _dtExcelMapping.Rows.Add(dr["ID"].ToString(),
                            CMSUser._foreignLanguageData == false ? dr["ColumnName"].ToString() : dr["ForeignColumnName"].ToString(),
                            string.Empty);
                    }
                }

                gridControlData.DataSource = _dtExcelMapping;

                #region Lưới hiển thị
                DataRow drHienThi = (DataRow)dtGrid.Select("GridID = 'HT-IMP-MappingColumnExcel'").GetValue(0);
                DataTable dtHienThi = BL_System.GetGridColumn(drHienThi["ID"].ToString());
                #endregion

                AppGridView.InitGridView(gridViewData, drHienThi, dtHienThi, CMSUser._foreignLanguageInterface);

                #region Cột Excel
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEdit_Map, _dtColumnExcelSheet, "ColumnExcel", "ColumnExcel", string.Empty, "ColumnExcel", rm.GetString("ColumnMapping", CMSUser._culture), 0);
                gridViewData.Columns["ColumnMapping"].ColumnEdit = repositoryItemLookUpEdit_Map;
                #endregion

                if (drHienThi["ColumnAutoWidth"].ToString() == "True")
                    gridViewData.OptionsView.ColumnAutoWidth = true;
                else
                    gridViewData.OptionsView.ColumnAutoWidth = false;

                if (drHienThi["BestFitColumns"].ToString() == "True")
                    gridViewData.BestFitColumns();
            }
            catch { }
        }
        #endregion

        #region Events
        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                _isAccepted = true;
                this.Close();
            }
            catch { }
        } 

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_chonFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                lkuSheet.Properties.DataSource = null;

                ofdFiles.Filter = "Excel File|*.xlsx|Excel 97 - 2003|*.xls";

                if (ofdFiles.ShowDialog() == DialogResult.OK)
                {
                    buttonEdit_chonFile.Text = ofdFiles.FileName;
                    lkuSheet.Properties.DataSource = null;
                    if (buttonEdit_chonFile.Text == string.Empty) return;

                    DataTable dtSheet = ExcelBL.DevExpressGetSchema(buttonEdit_chonFile.Text);
                    AppDevExpressEditControl.InitLookUpEdit(lkuSheet, dtSheet, "FullSheetName", "FullSheetName", string.Empty, "FullSheetName", "Sheets", 0);
                }
            }
            catch { }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

        }

        private void lookUpEdit_sheet_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                _dtResult = ExcelBL.DevExpressGetSheetContent(ofdFiles.FileName, lkuSheet.EditValue.ToString());

                if (_dtResult.Columns.Count == 0)
                {
                    XtraMessageBox.Show(rm.GetString("NoData", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (DataColumn dc in _dtResult.Columns)
                    _dtColumnExcelSheet.Rows.Add(dc.ColumnName);

                foreach (DataRow drE in _dtExcelMapping.Rows)
                {
                    foreach (DataRow drEC in _dtColumnExcelSheet.Rows)
                    {
                        if (drE["ID"].ToString() == drEC["ColumnExcel"].ToString()
                            || drE["ColumnName"].ToString() == drEC["ColumnExcel"].ToString())
                        {
                            drE["ColumnMapping"] = drEC["ColumnExcel"].ToString();
                        }
                    }
                }

                repositoryItemLookUpEdit_Map.DataSource = _dtColumnExcelSheet;
            }
            catch { }
        }
        #endregion
    }
}