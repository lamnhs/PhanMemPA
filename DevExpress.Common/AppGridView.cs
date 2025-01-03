using System;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.XtraGrid.Columns;
using System.Data;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;
using System.Collections.Generic;
using DevExpress.Export;
using DevExpress.Utils;

namespace CMSDevExpressCommon
{
    public static class AppGridView
    {
        public static void InitGridView(GridView grid, DataRow drGridOption, DataTable dtColumnOption, bool foreignLan)
        {
            try
            {
                //ShowAutoFilterRow
                if (drGridOption["ShowAutoFilterRow"].ToString().ToUpper() == "TRUE")
                    grid.OptionsView.ShowAutoFilterRow = true;
                else
                    grid.OptionsView.ShowAutoFilterRow = false;

                //MultiSelect
                if (drGridOption["MultiSelect"].ToString().ToUpper() == "TRUE")
                    grid.OptionsSelection.MultiSelect = true;
                else
                    grid.OptionsSelection.MultiSelect = false;

                //MultiSelectMode
                switch (drGridOption["MultiSelectMode"].ToString().ToUpper())
                {
                    case "CELL":
                        grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                        break;
                    case "ROW":
                        grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
                        break;
                    default:
                        grid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                        break;
                }

                //ShowGroupPanel
                if (drGridOption["ShowGroupPanel"].ToString().ToUpper() == "TRUE")
                    grid.OptionsView.ShowGroupPanel = true;
                else
                    grid.OptionsView.ShowGroupPanel = false;

                //GroupPanelText
                if (foreignLan)
                    grid.GroupPanelText = "Drap a column header here to group by that column";
                else
                    grid.GroupPanelText = "Thả tiêu đề cột muốn nhóm vào đây";

                //NewItemRowPosition
                switch (drGridOption["NewItemRowPosition"].ToString().ToUpper())
                {
                    case "TOP":
                        grid.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                        break;
                    case "BOTTOM":
                        grid.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        break;
                    default:
                        grid.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        break;
                }

                //NewItemRowText
                if (foreignLan)
                    grid.NewItemRowText = "Click here to add a new row";
                else
                    grid.NewItemRowText = "Mới";


                //ShowViewCaption
                if (drGridOption["ShowViewCaption"].ToString().ToUpper() == "TRUE")
                    grid.OptionsView.ShowViewCaption = true;
                else
                    grid.OptionsView.ShowViewCaption = false;

                //ViewCaption
                if (foreignLan)
                    grid.ViewCaption = drGridOption["ForeignGridName"].ToString();
                else
                    grid.ViewCaption = drGridOption["GridName"].ToString();

                for (int i = 0; i < grid.Columns.Count; i++)
                    grid.Columns[i].VisibleIndex = -1;

                DataView dv = dtColumnOption.DefaultView;
                dv.Sort = "VisibleIndex ASC";
                DataTable dtColumnVisible = dv.ToTable();

                DataRow[] drVisible = dtColumnVisible.Select("Visible = '" + true + "'");
                DataRow dr;
                bool showFooter = false;

                for (int i = 0; i < drVisible.Length; i++)
                {
                    try
                    {
                        dr = drVisible[i];

                        if (foreignLan)
                            grid.Columns[dr["ID"].ToString()].Caption = dr["ForeignColumnName"].ToString();
                        else
                            grid.Columns[dr["ID"].ToString()].Caption = dr["ColumnName"].ToString();

                        grid.Columns[dr["ID"].ToString()].VisibleIndex = i + 1;

                        if (dr["ReadOnly"].ToString().ToUpper() == "TRUE")
                            grid.Columns[dr["ID"].ToString()].OptionsColumn.ReadOnly = true;
                        else
                            grid.Columns[dr["ID"].ToString()].OptionsColumn.ReadOnly = false;

                        switch (dr["SummaryType"].ToString().ToUpper())
                        {
                            case "COUNT":
                                SummaryField(grid, dr["ID"].ToString(), foreignLan == true ? "COUNT = {0:#,0}" : "Số lượng = {0:#,0}", DevExpress.Data.SummaryItemType.Count);
                                showFooter = true;
                                break;
                            case "SUM":
                                SummaryField(grid, dr["ID"].ToString(), foreignLan == true ? "SUM = {0:#,0}" : "Tổng = {0:#,0}", DevExpress.Data.SummaryItemType.Sum);
                                showFooter = true;
                                break;
                            case "AVERAGE":
                                SummaryField(grid, dr["ID"].ToString(), foreignLan == true ? "AVG = {0:#,0}" : "Trung bình = {0:#,0}", DevExpress.Data.SummaryItemType.Average);
                                showFooter = true;
                                break;
                            case "MIN":
                                SummaryField(grid, dr["ID"].ToString(), foreignLan == true ? "MIN = {0:#,0}" : "Nhỏ nhất = {0:#,0}", DevExpress.Data.SummaryItemType.Min);
                                showFooter = true;
                                break;
                            case "MAX":
                                SummaryField(grid, dr["ID"].ToString(), foreignLan == true ? "MAX = {0:#,0}" : "Lớn nhất = {0:#,0}", DevExpress.Data.SummaryItemType.Max);
                                showFooter = true;
                                break;
                            default:
                                SummaryField(grid, dr["ID"].ToString(), "{0:#,0}", DevExpress.Data.SummaryItemType.None);
                                break;
                        }

                        switch (dr["HeaderAlign"].ToString().ToUpper())
                        {
                            case "CENTER":
                                grid.Columns[dr["ID"].ToString()].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                                break;
                            case "FAR":
                                grid.Columns[dr["ID"].ToString()].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
                                break;
                            case "NEAR":
                                grid.Columns[dr["ID"].ToString()].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
                                break;
                            default:
                                grid.Columns[dr["ID"].ToString()].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Default;
                                break;
                        }

                        switch (dr["DataAlign"].ToString().ToUpper())
                        {
                            case "CENTER":
                                grid.Columns[dr["ID"].ToString()].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                                break;
                            case "FAR":
                                grid.Columns[dr["ID"].ToString()].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                                break;
                            case "NEAR":
                                grid.Columns[dr["ID"].ToString()].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                                break;
                            default:
                                grid.Columns[dr["ID"].ToString()].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
                                break;
                        }

                        if (dr["Sorted"].ToString().ToUpper() == "TRUE")
                            grid.Columns[dr["ID"].ToString()].OptionsColumn.AllowSort = DefaultBoolean.True;
                        else if (dr["Sorted"].ToString().ToUpper() == "FALSE")
                            grid.Columns[dr["ID"].ToString()].OptionsColumn.AllowSort = DefaultBoolean.False;
                        else
                            grid.Columns[dr["ID"].ToString()].OptionsColumn.AllowSort = DefaultBoolean.Default;

                        grid.Columns[dr["ID"].ToString()].Width = Convert.ToInt32(dr["Width"]);
                    }
                    catch { }
                }

                foreach (DataRow drF in dtColumnVisible.Select("Visible = '" + true + "'" + " And Fixed ='LEFT'", "VisibleIndex ASC"))
                {
                    switch (drF["Fixed"].ToString().ToUpper())
                    {
                        case "LEFT":
                            grid.Columns[drF["ID"].ToString()].Fixed = FixedStyle.Left;
                            break;
                        default:
                            grid.Columns[drF["ID"].ToString()].Fixed = FixedStyle.None;
                            break;
                    }
                }

                foreach (DataRow drF in dtColumnVisible.Select("Visible = '" + true + "'" + " And Fixed ='RIGHT'", "VisibleIndex DESC"))
                {
                    switch (drF["Fixed"].ToString().ToUpper())
                    {
                        case "RIGHT":
                            grid.Columns[drF["ID"].ToString()].Fixed = FixedStyle.Right;
                            break;
                        default:
                            grid.Columns[drF["ID"].ToString()].Fixed = FixedStyle.None;
                            break;
                    }
                }

                //ColumnAutoWidth
                if (drGridOption["ColumnAutoWidth"].ToString().ToUpper() == "TRUE")
                    grid.OptionsView.ColumnAutoWidth = true;
                else
                    grid.OptionsView.ColumnAutoWidth = false;

                //BestFitColumns
                if (drGridOption["BestFitColumns"].ToString().ToUpper() == "TRUE")
                    grid.BestFitColumns();

                grid.OptionsView.ShowFooter = showFooter;
            }
            catch { }
        }

        // Khong cho phep edit toan bo cot tren luoi
        public static void ReadOnlyColumn(GridView grid)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].OptionsColumn.AllowEdit = false;
        }

        // Tinh tong gia tri trong cot
        public static void SummaryField(GridView grid, string fieldName, string displayFormat, DevExpress.Data.SummaryItemType summaryType)
        {
            grid.OptionsView.ShowFooter = true;
            grid.Columns[fieldName].SummaryItem.FieldName = fieldName;
            grid.Columns[fieldName].SummaryItem.DisplayFormat = displayFormat;
            grid.Columns[fieldName].SummaryItem.SummaryType = summaryType;
        }

        public static void GridViewExportExcel(GridView gridView, GridControl gridControl, string fileName, bool multiSelect)
        {
            try
            {
                if (multiSelect == true)
                {
                    gridView.OptionsSelection.MultiSelect = false;
                    ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                    gridControl.ExportToXlsx(fileName);
                    gridView.OptionsSelection.MultiSelect = true;
                }
                else
                {
                    ExportSettings.DefaultExportType = ExportType.WYSIWYG;
                    gridControl.ExportToXlsx(fileName);
                }
            }
            catch(Exception ex)
            {
                if (multiSelect == true)
                    gridView.OptionsSelection.MultiSelect = true;
                throw new Exception(ex.Message);
            }
        }
    }
}
