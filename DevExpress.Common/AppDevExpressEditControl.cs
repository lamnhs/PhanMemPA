using System;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace CMSDevExpressCommon
{
    public static class AppDevExpressEditControl
    {
        public static void InitLookUpEdit(LookUpEdit lkEdit, DataTable dtDataSource, string displayMember, string valueMember, string nullText, string col, string colDisplay, int colSearch)
        {
            try
            {
                lkEdit.Properties.DataSource = dtDataSource;
                lkEdit.Properties.DisplayMember = displayMember;
                lkEdit.Properties.ValueMember = valueMember;
                lkEdit.Properties.NullText = nullText;

                LookUpColumnInfoCollection coll = lkEdit.Properties.Columns;
                coll.Clear();
                string[] arrCol = col.Split(',');
                string[] arrColDisplay = colDisplay.Split(',');
                for (int i = 0; i < arrCol.Length; i++)
                    coll.Add(new LookUpColumnInfo(arrCol[i].ToString(), arrColDisplay[i].ToString()));

                lkEdit.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                lkEdit.Properties.SearchMode = SearchMode.AutoComplete;
                lkEdit.ItemIndex = 0;
                lkEdit.Properties.AutoSearchColumnIndex = colSearch;
            }
            catch { }
        }

        public static void InitCheckedComboBoxEdit(CheckedComboBoxEdit chkEdit, DataTable dtDataSource, string displayMember, string valueMember, string nullText, string selectAllItemCaption, char SeparatorChar, bool checkAll)
        {
            try
            {
                chkEdit.Properties.DataSource = dtDataSource;
                chkEdit.Properties.DisplayMember = displayMember;
                chkEdit.Properties.ValueMember = valueMember;
                chkEdit.Properties.NullText = nullText;
                chkEdit.Properties.SelectAllItemCaption = selectAllItemCaption;
                chkEdit.Properties.SeparatorChar = SeparatorChar;
                if (checkAll == true)
                    chkEdit.CheckAll();
            }
            catch { }
        }

        public static void InitRepositoryItemLookUpEdit(RepositoryItemLookUpEdit rlkEdit, DataTable dtDataSource, string displayMember, string valueMember, string nullText, string col, string colDisplay, int colSearch)
        {
            try
            {
                rlkEdit.DataSource = dtDataSource;
                rlkEdit.DisplayMember = displayMember;
                rlkEdit.ValueMember = valueMember;
                rlkEdit.NullText = nullText;

                LookUpColumnInfoCollection coll = rlkEdit.Columns;
                coll.Clear();
                string[] arrCol = col.Split(',');
                string[] arrColDisplay = colDisplay.Split(',');
                for (int i = 0; i < arrCol.Length; i++)
                    coll.Add(new LookUpColumnInfo(arrCol[i].ToString(), arrColDisplay[i].ToString()));

                rlkEdit.BestFitMode = BestFitMode.BestFitResizePopup;
                rlkEdit.SearchMode = SearchMode.AutoComplete;
                rlkEdit.AutoSearchColumnIndex = colSearch;
            }
            catch { }
        }

        public static void InitRepositoryItemCheckedComboBoxEdit(RepositoryItemCheckedComboBoxEdit rchkEdit, DataTable dtDataSource, string displayMember, string valueMember, string nullText, string selectAllItemCaption, char SeparatorChar)
        {
            try
            {
                rchkEdit.DataSource = dtDataSource;
                rchkEdit.DisplayMember = displayMember;
                rchkEdit.ValueMember = valueMember;
                rchkEdit.NullText = nullText;
                rchkEdit.SelectAllItemCaption = selectAllItemCaption;
                rchkEdit.SeparatorChar = SeparatorChar;
            }
            catch { }
        }

        public static void InitLookUpEdit(LookUpEdit lkEdit, DataView dvDataSource, string displayMember, string valueMember, string nullText, string col, string colDisplay, int colSearch)
        {
            try
            {
                lkEdit.Properties.DataSource = dvDataSource;
                lkEdit.Properties.DisplayMember = displayMember;
                lkEdit.Properties.ValueMember = valueMember;
                lkEdit.Properties.NullText = nullText;

                LookUpColumnInfoCollection coll = lkEdit.Properties.Columns;
                coll.Clear();
                string[] arrCol = col.Split(',');
                string[] arrColDisplay = colDisplay.Split(',');
                for (int i = 0; i < arrCol.Length; i++)
                    coll.Add(new LookUpColumnInfo(arrCol[i].ToString(), arrColDisplay[i].ToString()));

                lkEdit.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                lkEdit.Properties.SearchMode = SearchMode.AutoComplete;
                lkEdit.ItemIndex = 0;
                lkEdit.Properties.AutoSearchColumnIndex = colSearch;
            }
            catch { }
        }

        public static void InitRepositoryItemLookUpEdit(RepositoryItemLookUpEdit rlkEdit, DataView dvDataSource, string displayMember, string valueMember, string nullText, string col, string colDisplay, int colSearch)
        {
            try
            {
                rlkEdit.DataSource = dvDataSource;
                rlkEdit.DisplayMember = displayMember;
                rlkEdit.ValueMember = valueMember;
                rlkEdit.NullText = nullText;

                LookUpColumnInfoCollection coll = rlkEdit.Columns;
                coll.Clear();
                string[] arrCol = col.Split(',');
                string[] arrColDisplay = colDisplay.Split(',');
                for (int i = 0; i < arrCol.Length; i++)
                    coll.Add(new LookUpColumnInfo(arrCol[i].ToString(), arrColDisplay[i].ToString()));

                rlkEdit.BestFitMode = BestFitMode.BestFitResizePopup;
                rlkEdit.SearchMode = SearchMode.AutoComplete;
                rlkEdit.AutoSearchColumnIndex = colSearch;
            }
            catch { }
        }

    }
}
