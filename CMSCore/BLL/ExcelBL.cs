using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;

namespace CMSCore.BLL
{
    public class ExcelBL
    {
        public static DataTable DevExpressGetSchema(string filePath)
        {
            try
            {
                Workbook wk = new Workbook();
                wk.LoadDocument(filePath);

                DataTable dt = new DataTable();
                dt.Columns.Add("FullSheetName", typeof(string));

                foreach (Worksheet sh in wk.Worksheets)
                {
                    DataRow drNew = dt.NewRow();
                    drNew["FullSheetName"] = sh.Name;
                    dt.Rows.Add(drNew);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DevExpressGetSheetContent(string filePath, string fullSheetName)
        {
            try
            {
                Workbook workbook = new Workbook();
                workbook.LoadDocument(filePath);
                Worksheet worksheet = workbook.Worksheets[fullSheetName];
                CellRange range = worksheet.GetUsedRange();

                DataTable dtExcel = worksheet.CreateDataTable(range, true);
                worksheet.CreateDataTableExporter(range, dtExcel, true);

                for (int col = 0; col < range.ColumnCount; col++)
                {
                    CellValueType cellType = range[0, col].Value.Type;
                    for (int r = 1; r < range.RowCount; r++)
                    {
                        if (cellType != range[r, col].Value.Type)
                        {
                            dtExcel.Columns[col].DataType = typeof(string);
                            break;
                        }
                    }
                }

                DataTableExporter exporter = worksheet.CreateDataTableExporter(range, dtExcel, true);
                exporter.CellValueConversionError += exporter_CellValueConversionError;

                // Specify exporter options.
                exporter.Options.ConvertEmptyCells = true;
                exporter.Options.DefaultCellValueToColumnTypeConverter.EmptyCellValue = 0;
                exporter.Options.DefaultCellValueToColumnTypeConverter.SkipErrorValues = true;

                // Perform the export.
                exporter.Export();

                return dtExcel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static void exporter_CellValueConversionError(object sender, DevExpress.Spreadsheet.Export.CellValueConversionErrorEventArgs e)
        {
            e.DataTableValue = null;
            e.Action = DataTableExporterAction.Continue;
        }
    }
}
