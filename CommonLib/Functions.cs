using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSCommonLib
{
    public class Permission
    {
        string _controlID = "";

        public string ControlID
        {
            get { return _controlID; }
            set { _controlID = value; }
        }
        bool _enable = false, _visible = false, _readOnly = false;

        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        public Permission(string controlID, bool enable, bool visible, bool readOnly)
        {
            this._controlID = controlID;
            this._enable = enable;
            this._visible = visible;
            this._readOnly = readOnly;
        }
    }

    public abstract class PermissionUI
    {
        List<string> _ignoreListUser = new List<string>();
        public static bool DefaultVisible { get; set; }
        public static bool DefaultEnable { get; set; }

        static PermissionUI()
        {
            DefaultVisible = false;
            DefaultEnable = false;
        }

        public PermissionUI()
        {
            Init_IgnoreListUser();
        }

        protected List<string> IgnoreListUser
        {
            get
            {
                if (_ignoreListUser == null)
                    _ignoreListUser = new List<string>();
                return _ignoreListUser;
            }
        }

        protected abstract List<Permission> CreatePermission(DataTable dtDecentralizations);

        public abstract bool IgnoreUserPermission { get; }

        protected abstract void Init_IgnoreListUser();

        public virtual void SetPermission(Control Parent, DataTable dtDecentralizations)
        {
            try
            {
                if (this.IgnoreUserPermission) return;

                List<Permission> permission = this.CreatePermission(dtDecentralizations);
                if (permission.Count > 0 || !PermissionUI.DefaultVisible || !PermissionUI.DefaultEnable)
                {
                    SetPermission(Parent, permission);
                }
            }
            catch { }
        }

        #region Set Permission Detail
        #region Set Permission on Control
        void SetPermission(Control Parent, List<Permission> dtPermission)
        {
            if (Parent is DevExpress.XtraBars.Ribbon.RibbonControl)
                SetPermission((DevExpress.XtraBars.Ribbon.RibbonControl)Parent, dtPermission);
            else if (Parent is DevExpress.XtraTab.XtraTabControl)
                SetPermission((DevExpress.XtraTab.XtraTabControl)Parent, dtPermission);
            else
            {
                Permission permission = dtPermission.FirstOrDefault(p => p.ControlID == Parent.Name);
                if (permission != null)
                {
                    Parent.Visible = permission.Visible;
                    Parent.Enabled = permission.Enable;
                    dtPermission.Remove(permission);
                    if (Parent.Visible)
                    {
                        if (Parent is DevExpress.XtraEditors.TextEdit)
                        {
                            ((DevExpress.XtraEditors.TextEdit)Parent).Properties.ReadOnly = permission.ReadOnly;
                        }
                    }
                }

                if (Parent.Visible)
                {
                    foreach (Control ctrl in Parent.Controls)
                    {
                        SetPermission(ctrl, dtPermission);
                    }
                }
            }
        }
        #endregion

        #region Set Permission on XtraTabControl
        void SetPermission(DevExpress.XtraTab.XtraTabControl Parent, List<Permission> dtPermission)
        {
            Permission permission = dtPermission.FirstOrDefault(p => p.ControlID == Parent.Name);
            if (permission != null)
            {
                Parent.Visible = permission.Visible;
            }
            if (Parent.Visible)
            {
                foreach (DevExpress.XtraTab.XtraTabPage tPage in Parent.TabPages)
                {
                    SetPermission(tPage, dtPermission);
                }
            }
        }

        void SetPermission(DevExpress.XtraTab.XtraTabPage Parent, List<Permission> dtPermission)
        {
            Permission permission = dtPermission.FirstOrDefault(p => p.ControlID == Parent.Name);
            if (permission != null)
            {
                Parent.PageVisible = permission.Visible;
                dtPermission.Remove(permission);
            }
            if (Parent.PageVisible)
            {
                foreach (Control ctrl in Parent.Controls)
                {
                    if (ctrl is DevExpress.XtraTab.XtraTabControl)
                        SetPermission((DevExpress.XtraTab.XtraTabControl)ctrl, dtPermission);
                    else
                        SetPermission(ctrl, dtPermission);
                }
            }
        }
        #endregion

        #region SetPermission on Ribbon
        void SetPermission(DevExpress.XtraBars.Ribbon.RibbonControl Parent, List<Permission> dtPermission)
        {
            foreach (DevExpress.XtraBars.Ribbon.RibbonPage rPage in Parent.Pages)
            {
                SetPermission(rPage, dtPermission);
            }
            foreach (DevExpress.XtraBars.BarItemLink item in Parent.Toolbar.ItemLinks)
            {
                SetPermission(item.Item, dtPermission);
            }

            foreach (DevExpress.XtraBars.BarItemLink item in Parent.StatusBar.ItemLinks)
            {
                SetPermission(item.Item, dtPermission);
            }

        }

        void SetPermission(DevExpress.XtraBars.Ribbon.RibbonPage Parent, List<Permission> dtPermission)
        {
            bool visCount = false;
            Permission permission = dtPermission.FirstOrDefault(p => p.ControlID == Parent.Name);
            if (permission != null)
            {
                Parent.Visible = permission.Visible;
                dtPermission.Remove(permission);
            }
            foreach (DevExpress.XtraBars.Ribbon.RibbonPageGroup gPage in Parent.Groups)
            {
                SetPermission(gPage, dtPermission);
                if (gPage.Visible)
                    visCount = true;
            }
            if (visCount)
                Parent.Visible = true;
            else
                Parent.Visible = PermissionUI.DefaultVisible;
        }

        void SetPermission(DevExpress.XtraBars.Ribbon.RibbonPageGroup Parent, List<Permission> dtPermission)
        {
            bool visCount = false;
            Permission permission = dtPermission.FirstOrDefault(p => p.ControlID == Parent.Name);
            if (permission != null)
            {
                Parent.Visible = permission.Visible;
                dtPermission.Remove(permission);
            }
            if (Parent.Visible)
            {
                foreach (DevExpress.XtraBars.BarItemLink item in Parent.ItemLinks)
                {
                    SetPermission(item.Item, dtPermission);
                    if (item.Item.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
                        visCount = true;
                }
                if (visCount)
                    Parent.Visible = true;
                else
                    Parent.Visible = PermissionUI.DefaultVisible;
            }
        }

        void SetPermission(DevExpress.XtraBars.BarSubItem Parent, List<Permission> dtPermission)
        {
            Permission permission = dtPermission.FirstOrDefault(p => p.ControlID == Parent.Name);

            if (permission != null)
            {
                Parent.Visibility = permission.Visible ? DevExpress.XtraBars.BarItemVisibility.Always : (PermissionUI.DefaultVisible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
                Parent.Enabled = permission.Enable;
                dtPermission.Remove(permission);
            }
            if (Parent.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                bool visCount = false;
                foreach (DevExpress.XtraBars.BarItemLink item in Parent.ItemLinks)
                {
                    SetPermission(item.Item, dtPermission);
                    if (item.Item.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
                        visCount = true;
                }
                if (visCount)
                    Parent.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                else
                    Parent.Visibility = (PermissionUI.DefaultVisible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
            }
        }

        void SetPermission(DevExpress.XtraBars.BarItem Parent, List<Permission> dtPermission)
        {
            if (Parent is DevExpress.XtraBars.BarSubItem)
            {
                SetPermission(((DevExpress.XtraBars.BarSubItem)Parent), dtPermission);
            }
            else
            {
                Permission permission = dtPermission.FirstOrDefault(p => p.ControlID == Parent.Name);
                if (permission != null)
                {
                    Parent.Visibility = permission.Visible ? DevExpress.XtraBars.BarItemVisibility.Always : (PermissionUI.DefaultVisible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
                    Parent.Enabled = permission.Enable;
                    dtPermission.Remove(permission);

                    if (Parent is DevExpress.XtraBars.BarEditItem)
                    {
                        ((DevExpress.XtraBars.BarEditItem)Parent).Edit.ReadOnly = permission.ReadOnly;
                    }

                }
                else
                {
                    Parent.Visibility = PermissionUI.DefaultVisible ? DevExpress.XtraBars.BarItemVisibility.Always : (PermissionUI.DefaultVisible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
                    Parent.Enabled = PermissionUI.DefaultEnable;
                }
            }
        }
        #endregion
        #endregion
    }

    public class Functions
    {
        public static string UNI_2_VNI(string _text1)
        {
            var str = _text1;
            string _text2 = string.Empty;
            string[] UNI = { "Ỵ", "ỵ", "Ý", "Ỳ", "Ỷ", "Ỹ", "U", "Y", "ý", "ỳ", "ỷ", "ỹ", "u", "y", " ", "ă", "ắ", "ằ", "ặ", "ẳ", " ẵ ", "a", "á", "à", "ạ", "ã", "ả", "â", "ấ", "ầ", "ậ", "ẫ", "ẩ", "b", "c", "d", "đ", "e", "é", "è", "ẹ", "ẻ", "ẽ", "ê", "ế", "ề", "ệ", "ễ", "ể", "f", "g", "h", "i", "í", "ì", "ị", "ĩ", "ỉ", "j", "k", "l", "m", "n", "o", "ó", "ò", "ọ", "õ", "ỏ", "ô", "ố", "ồ", "ộ", "ổ", "ỗ", "ơ", "ớ", "ờ", "ợ", "ở", "ỡ", "p", "q", "r", "s", "t", "ú", "ù", "ụ", "ủ", "ũ", "ư", "ứ", "ừ", "ự", "ử", "ữ", "v", "w", "x", "z", "Ă", "Ắ", "Ằ", "Ặ", "Ẳ", " Ẵ ", "A", "Á", "À", "Ạ", "Ã", "Ả", "Â", "Ấ", "Ầ", "Ậ", "Ẫ", "Ẩ", "B", "C", "D", "Đ", "E", "É", "È", "Ẹ", "Ẻ", "Ẽ", "Ê", "Ế", "Ề", "Ệ", "Ễ", "Ể", "F", "G", "H", "I", "Í", "Ì", "Ị", "Ĩ", "Ỉ", "J", "K", "L", "M", "N", "O", "Ó", "Ò", "Ọ", "Õ", "Ỏ", "Ô", "Ố", "Ồ", "Ộ", "Ổ", "Ỗ", "Ơ", "Ớ", "Ờ", "Ợ", "Ở", "Ỡ", "P", "Q", "R", "S", "T", "Ú", "Ù", "Ụ", "Ủ", "Ũ", "Ư", "Ứ", "Ừ", "Ự", "Ử", "Ữ", "V", "W", "X", "Z" };
            string[] VNI = { "Î", "î", "YÙ", "YØ", "YÛ", "YÕ", "U", "Y", "yù", "yø", "yû", "yõ", "u", "y", " ", "aê", "aé", "aè", "aë", "aú", "aü", "a", "aù", "aø", "aï", "aõ", "aû", "aâ", "aá", "aà", "aä", "aã", "aå", "b", "c", "d", "ñ", "e", "eù", "eø", "eï", "eû", "eõ", "eâ", "eá", "eà", "eä", "eã", "eå", "f", "g", "h", "i", "í", "ì", "ò", "ó", "æ", "j", "k", "l", "m", "n", "o", "où", "oø", "oï", "oõ", "oû", "oâ", "oá", "oà", "oä", "oå", "oã", "ô", "ôù", "ôø", "ôï", "ôû", "ôõ", "p", "q", "r", "s", "t", "uù", "uø", "uï", "uû", "uõ", "ö", "öù", "öø", "öï", "öû", "öõ", "v", "w", "x", "z", "AÊ", "AÉ", "AÈ", "AË", "AÚ", "AÜ", "A", "AÙ", "AØ", "AÏ", "AÕ", "AÛ", "AÂ", "AÁ", "AÀ", "AÄ", "AÃ", "AÅ", "B", "C", "D", "Ñ", "E", "EÙ", "EØ", "EÏ", "EÛ", "EÕ", "EÂ", "EÁ", "EÀ", "EÄ", "EÃ", "EÅ", "F", "G", "H", "I", "Í", "Ì", "Ò", "Ó", "Æ", "J", "K", "L", "M", "N", "O", "OÙ", "OØ", "OÏ", "OÕ", "OÛ", "OÂ", "OÁ", "OÀ", "OÄ", "OÅ", "OÃ", "Ô", "ÔÙ", "ÔØ", "ÔÏ", "ÔÛ", "ÔÕ", "P", "Q", "R", "S", "T", "UÙ", "UØ", "UÏ", "UÛ", "UÕ", "Ö", "ÖÙ", "ÖØ", "ÖÏ", "ÖÛ", "ÖÕ", "V", "W", "X", "Z" };

            bool khongCoKyTu = true;

            for (int i = 0; i < _text1.Length; ++i)
            {
                khongCoKyTu = true;

                for (int j = 0; j < UNI.Length; ++j)
                {
                    if (str[i].ToString().Equals(UNI[j]))
                    {
                        _text2 += str[i].ToString().Replace(UNI[j], VNI[j]);
                        khongCoKyTu = false;
                    }
                }

                if (khongCoKyTu == true)
                    _text2 += str[i].ToString();
            }
            return _text2;
        }
    }
}
