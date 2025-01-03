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
using System.Xml;
using System.Reflection;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using DevExpress.XtraTabbedMdi;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraTreeList;
using DevExpress.XtraTab;
using System.Globalization;
using System.Resources;
using CMSCore.BLL;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_MainObjectSource : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        string _sFormID = string.Empty;
        string _sModuleID = "CMS";

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_MainObjectSource()
        {
            InitializeComponent();

            SetLanguage();
        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_MainObjectSource).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnReadSource.Text = rm.GetString("btnReadSource", CMSUser._culture);
        }

        private void GetAllForms()
        {
            try
            {
                Type formType = typeof(Form);
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (formType.IsAssignableFrom(type))
                    {
                        _sFormID = type.Name;

                        #region Form cần đọc sử dụng
                        if (_sFormID == "frm_CMS_InBangChungChi" || _sFormID == "MailMerge" 
                            || _sFormID == "frm_CMS_ExcelSheet" || _sFormID == "frmLoadingPrint" 
                            || _sFormID == "frm_CMS_DashboardViewer" || _sFormID == "frm_CMS_DesignDashboard" || _sFormID== "frm_CMS_ThongKePivot")
                            continue;
                        #endregion

                        string sFullFormID = type.FullName;
                        string sNamespace = type.Namespace;
                        if (_sFormID == memoEdit_Status.Text || memoEdit_Status.Text == "ALL")
                        {
                            Type form = Type.GetType(sFullFormID);
                            if (form != null)
                            {
                                Form frm = Activator.CreateInstance(form) as Form;
                                string sformName = frm.Text;
                                //Save Form Infomation
                                BL_HeThong.SaveListOfForms(_sModuleID, _sFormID, sformName, sNamespace);

                                GetAllControls(frm);
                                GetAllComponents(frm);
                            }
                        }
                    }
                }

                memoEdit_Status.Text = "Successful.";
            }
            catch (Exception ex)
            {
                memoEdit_Status.Text = ex.Message;
            }
        }

        private void GetAllControls(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                // Save Control Infomation
                BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, control.Name, control.Text, control.GetType().Name, parentControl.Name);

                #region Get All Child Controls
                string sTypeControl = control.GetType().Name;
                switch (sTypeControl)
                {
                    case "RibbonControl":
                        RibbonControl ribbon = control as RibbonControl;
                        GetAllControlInRibbonControl(ribbon);
                        break;
                    case "RibbonStatusBar":
                        RibbonStatusBar ribbonStatusBar = control as RibbonStatusBar;
                        GetAllControlInRibbonStatusBar(ribbonStatusBar);
                        break;
                    case "LayoutControl":
                        LayoutControl layout = control as LayoutControl;
                        GetAllControlInLayoutControl(layout);
                        break;
                    case "GridControl":
                        GridControl gridControl = control as GridControl;
                        BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, gridControl.Name, "", gridControl.GetType().Name, parentControl.Name);
                        GetAllObjectInGridControl(gridControl);
                        break;
                    default:
                        if (control.HasChildren == true)
                            GetAllControls(control);
                        break;
                }
                #endregion
            }
        }

        private void GetAllComponents(Form frm)
        {
            try
            {
                FieldInfo fInfo = frm.GetType().GetField("components", BindingFlags.Instance | BindingFlags.NonPublic);
                Container compInfo = fInfo.GetValue(frm) as Container;

                foreach (var ctrl in compInfo.Components)
                {
                    string sTypeControl = ctrl.GetType().Name;
                    switch (sTypeControl)
                    {
                        case "ContextMenuStrip":
                            ContextMenuStrip contextMenuStrip = ctrl as ContextMenuStrip;
                            BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, contextMenuStrip.Name, contextMenuStrip.Text, contextMenuStrip.GetType().Name, frm.Name);

                            foreach (var item in contextMenuStrip.Items)
                            {
                                if (item.GetType().Name == "ToolStripMenuItem")
                                {
                                    ToolStripMenuItem toolStripMenuItem = item as ToolStripMenuItem;
                                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, toolStripMenuItem.Name, toolStripMenuItem.Text, toolStripMenuItem.GetType().Name, contextMenuStrip.Name);

                                    foreach (var item1 in toolStripMenuItem.DropDownItems)
                                    {
                                        if (item1.GetType().ToString() == "ToolStripMenuItem")
                                        {
                                            ToolStripMenuItem toolStripMenuItem1 = item1 as ToolStripMenuItem;
                                            BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, toolStripMenuItem1.Name, toolStripMenuItem1.Text, toolStripMenuItem1.GetType().Name, toolStripMenuItem.Name);

                                        }
                                    }
                                }
                            }
                            break;
                        case "DockManager":
                            DockManager dockManager = ctrl as DockManager;
                            BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, "dockManager", "", dockManager.GetType().Name, frm.Name);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch { }
        }

        private void GetAllObjectInGridControl(GridControl gridControl)
        {
            try
            {
                foreach (var view in gridControl.Views)
                {
                    string sTypeView = view.GetType().Name;
                    switch (sTypeView)
                    {
                        case "GridView":
                            GridView gridView = view as GridView;
                            BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, gridView.Name, gridView.ViewCaption, gridView.GetType().Name, gridControl.Name);
                            break;
                    }
                }
                foreach (var res in gridControl.RepositoryItems)
                {
                    string sTypeRes = res.GetType().Name;
                    switch (sTypeRes)
                    {
                        case "RepositoryItemLookUpEdit":
                            RepositoryItemLookUpEdit repositoryItemLookUpEdit = res as RepositoryItemLookUpEdit;
                            BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, repositoryItemLookUpEdit.Name, "", repositoryItemLookUpEdit.GetType().Name, gridControl.Name);
                            break;
                        case "RepositoryItemGridLookUpEdit":
                            RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit = res as RepositoryItemGridLookUpEdit;
                            BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, repositoryItemGridLookUpEdit.Name, "", repositoryItemGridLookUpEdit.GetType().Name, gridControl.Name);
                            BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, repositoryItemGridLookUpEdit.PopupView.Name, "", repositoryItemGridLookUpEdit.PopupView.GetType().Name, repositoryItemGridLookUpEdit.Name);
                            break;
                        case "RepositoryItemButtonEdit":
                            RepositoryItemButtonEdit repositoryItemButtonEdit = res as RepositoryItemButtonEdit;
                            BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, repositoryItemButtonEdit.Name, repositoryItemButtonEdit.Buttons[0].Caption, repositoryItemButtonEdit.GetType().Name, gridControl.Name);
                            break;
                        case "RepositoryItemCheckedComboBoxEdit":
                            RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit = res as RepositoryItemCheckedComboBoxEdit;
                            BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, repositoryItemCheckedComboBoxEdit.Name, "", repositoryItemCheckedComboBoxEdit.GetType().Name, gridControl.Name);
                            break;
                    }
                }
            }
            catch { }
        }

        private void GetAllChildControlsInLayoutControlItem(LayoutControlItem layoutControlItem)
        {
            var control = layoutControlItem.Control;

            string sTypeControl = control.GetType().Name;
            switch (sTypeControl)
            {
                case "SimpleButton":
                    SimpleButton simpleButton = control as SimpleButton;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, simpleButton.Name, simpleButton.Text, simpleButton.GetType().Name, layoutControlItem.Name);
                    break;
                case "PictureEdit":
                    PictureEdit pictureEdit = control as PictureEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, pictureEdit.Name, layoutControlItem.Text, pictureEdit.GetType().Name, layoutControlItem.Name);
                    break;
                case "TextEdit":
                    TextEdit textEdit = control as TextEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, textEdit.Name, layoutControlItem.Text, textEdit.GetType().Name, layoutControlItem.Name);
                    break;
                case "LookUpEdit":
                    LookUpEdit lookUpEdit = control as LookUpEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, lookUpEdit.Name, layoutControlItem.Text, lookUpEdit.GetType().Name, layoutControlItem.Name);
                    break;
                case "ComboBoxEdit":
                    ComboBoxEdit comboBoxEdit = control as ComboBoxEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, comboBoxEdit.Name, layoutControlItem.Text, comboBoxEdit.GetType().Name, layoutControlItem.Name);
                    break;
                case "MemoEdit":
                    MemoEdit memoEdit = control as MemoEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, memoEdit.Name, layoutControlItem.Text, memoEdit.GetType().Name, layoutControlItem.Name);
                    break;
                case "CheckedComboBoxEdit":
                    CheckedComboBoxEdit checkedComboBoxEdit = control as CheckedComboBoxEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, checkedComboBoxEdit.Name, layoutControlItem.Text, checkedComboBoxEdit.GetType().Name, layoutControlItem.Name);
                    break;
                case "GridControl":
                    GridControl gridControl = control as GridControl;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, gridControl.Name, "", gridControl.GetType().Name, layoutControlItem.Name);
                    GetAllObjectInGridControl(gridControl);
                    break;
                case "TreeList":
                    TreeList treeList = control as TreeList;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, treeList.Name, treeList.Caption, treeList.GetType().Name, layoutControlItem.Name);
                    break;
                case "RadioGroup":
                    RadioGroup radioGroup = control as RadioGroup;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, radioGroup.Name, "", radioGroup.GetType().Name, layoutControlItem.Name);
                    for (int i = 0; i < radioGroup.Properties.Items.Count; i++)
                    {
                        BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, radioGroup.Name + "Item" + i.ToString()
                            , radioGroup.Properties.Items[i].Description, radioGroup.Properties.Items[i].GetType().Name, radioGroup.Name);
                    }
                    break;
                case "CheckEdit":
                    CheckEdit checkEdit = control as CheckEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, checkEdit.Name, checkEdit.Text, checkEdit.GetType().Name, layoutControlItem.Name);
                    break;
                case "GroupControl":
                    GroupControl groupControl = control as GroupControl;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, groupControl.Name, groupControl.Text, groupControl.GetType().Name, layoutControlItem.Name);
                    GetAllControls(groupControl);
                    break;
                case "DateEdit":
                    DateEdit dateEdit = control as DateEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, dateEdit.Name, layoutControlItem.Text, dateEdit.GetType().Name, layoutControlItem.Name);
                    break;
                case "ButtonEdit":
                    ButtonEdit buttonEdit = control as ButtonEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, buttonEdit.Name, layoutControlItem.Text, buttonEdit.GetType().Name, layoutControlItem.Name);
                    break;
                case "GridLookUpEdit":
                    GridLookUpEdit gridLookUpEdit = control as GridLookUpEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, gridLookUpEdit.Name, layoutControlItem.Text, gridLookUpEdit.GetType().Name, layoutControlItem.Name);
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, gridLookUpEdit.Properties.PopupView.Name, "", gridLookUpEdit.Properties.PopupView.GetType().Name, gridLookUpEdit.Name);
                    break;
                case "SplitContainerControl":
                    SplitContainerControl splitContainerControl = control as SplitContainerControl;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, splitContainerControl.Name, "", splitContainerControl.GetType().Name, layoutControlItem.Name);
                    GetAllControls(splitContainerControl.Panel1);
                    GetAllControls(splitContainerControl.Panel2);
                    break;
                case "XtraTabControl":
                    XtraTabControl xtraTabControl = control as XtraTabControl;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, xtraTabControl.Name, "", xtraTabControl.GetType().Name, layoutControlItem.Name);
                    foreach (XtraTabPage tabPage in xtraTabControl.TabPages)
                    {
                        BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, tabPage.Name, tabPage.Text, tabPage.GetType().Name, xtraTabControl.Name);
                        GetAllControls(tabPage);
                    }
                    break;
                case "TableLayoutPanel":
                    TableLayoutPanel tableLayoutPanel = control as TableLayoutPanel;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, tableLayoutPanel.Name, "", tableLayoutPanel.GetType().Name, layoutControlItem.Name);
                    GetAllControls(tableLayoutPanel);
                    break;
                case "ProgressBarControl":
                    ProgressBarControl progressBar = control as ProgressBarControl;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, progressBar.Name, "", progressBar.GetType().Name, layoutControlItem.Name);
                    break;
                case "SpinEdit":
                    SpinEdit spinEdit = control as SpinEdit;
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, spinEdit.Name, "", spinEdit.GetType().Name, layoutControlItem.Name);
                    break;
                default:
                    break;
            }
        }

        private void GetAllControlInRibbonControl(RibbonControl ribbon)
        {
            foreach (RibbonPage ribbonPage in ribbon.Pages)
            {
                // Save RibbonPage Infomation
                BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, ribbonPage.Name, ribbonPage.Text, ribbonPage.GetType().Name, ribbon.Name);

                #region Get All RibbonPageGroup In Page
                foreach (RibbonPageGroup ribbonPageGroup in ribbonPage.Groups)
                {
                    // Save RibbonPageGroup Infomation
                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, ribbonPageGroup.Name, ribbonPageGroup.Text, ribbonPageGroup.GetType().Name, ribbonPage.Name);

                    #region Get All Control In RibbonPageGroup
                    foreach (var itemLink in ribbonPageGroup.ItemLinks)
                    {
                        string sTypeItemLink = itemLink.GetType().Name;
                        switch (sTypeItemLink)
                        {
                            case "BarButtonItemLink":
                                BarButtonItemLink barButtonItemLink = itemLink as BarButtonItemLink;
                                BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, barButtonItemLink.Item.Name, barButtonItemLink.Item.Caption, barButtonItemLink.GetType().Name, ribbonPageGroup.Name);
                                break;
                            case "BarSubItemLink":
                                BarSubItemLink barSubItemLink = itemLink as BarSubItemLink;
                                BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, barSubItemLink.Item.Name, barSubItemLink.Item.Caption, barSubItemLink.GetType().Name, ribbonPageGroup.Name);
                                foreach (BarButtonItemLink subBarButtonItemLink in barSubItemLink.Item.ItemLinks)
                                    BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, subBarButtonItemLink.Item.Name, subBarButtonItemLink.Item.Caption, subBarButtonItemLink.GetType().Name, barSubItemLink.Item.Name);
                                break;
                        }
                    }
                    #endregion
                }
                #endregion
            }

            foreach (var ribbonItem in ribbon.Items)
            {
                string sTypeRibbonItem = ribbonItem.GetType().Name;
                switch (sTypeRibbonItem)
                {
                    case "BarButtonItem":
                        BarButtonItem barButtonItem = ribbonItem as BarButtonItem;
                        BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, barButtonItem.Name, barButtonItem.Caption, barButtonItem.GetType().Name, ribbon.Name);
                        break;
                }
            }
        }

        private void GetAllControlInRibbonStatusBar(RibbonStatusBar ribbon)
        {
            foreach (var itemLink in ribbon.ItemLinks)
            {
                string sTypeItemLink = itemLink.GetType().Name;
                switch (sTypeItemLink)
                {
                    case "BarButtonItemLink":
                        BarButtonItemLink barButtonItemLink = itemLink as BarButtonItemLink;
                        BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, barButtonItemLink.Item.Name, barButtonItemLink.Item.Caption, barButtonItemLink.GetType().Name, ribbon.Name);
                        break;
                    case "BarEditItemLink":
                        BarEditItemLink barEditItemLink = itemLink as BarEditItemLink;
                        BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, barEditItemLink.Item.Name, barEditItemLink.Item.Caption, barEditItemLink.GetType().Name, ribbon.Name);
                        BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, barEditItemLink.Edit.Name, "", barEditItemLink.Edit.GetType().Name, barEditItemLink.Item.Name);
                        break;
                }
            }
        }

        private void GetAllControlInLayoutControl(LayoutControl layout)
        {
            foreach (var layoutItem in layout.Items)
            {
                string sTypeLayoutItem = layoutItem.GetType().Name;
                switch (sTypeLayoutItem)
                {
                    case "LayoutControlItem":
                        LayoutControlItem layoutControlItem = layoutItem as LayoutControlItem;
                        BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, layoutControlItem.Name, layoutControlItem.Text, layoutControlItem.GetType().Name, layout.Name);
                        if (layoutControlItem.Control != null)
                            GetAllChildControlsInLayoutControlItem(layoutControlItem);
                        break;
                    case "EmptySpaceItem":
                        EmptySpaceItem emptySpaceItem = layoutItem as EmptySpaceItem;
                        BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, emptySpaceItem.Name, emptySpaceItem.Text, emptySpaceItem.GetType().Name, layout.Name);
                        break;
                    case "LayoutControlGroup":
                        LayoutControlGroup layoutControlGroup = layoutItem as LayoutControlGroup;
                        BL_HeThong.SaveListOfFormObjects(_sModuleID, _sFormID, layoutControlGroup.Name, layoutControlGroup.Text, layoutControlGroup.GetType().Name, layout.Name);
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void btnReadSource_Click(object sender, EventArgs e)
        {
            GetAllForms();
        }        
        #endregion
    }
}