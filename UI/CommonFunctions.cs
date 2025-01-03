using CMSCore.BLL;
using CMSUI.SystemConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSUI
{
    public class CommonFunctions
    {
        public static DataTable _dtDecentralizations = new DataTable();

        #region FormPermition
        internal class FormPermission : CMSCommonLib.PermissionUI
        {
            protected override List<CMSCommonLib.Permission> CreatePermission(DataTable dtDecentralizations)
            {
                List<CMSCommonLib.Permission> permission = new List<CMSCommonLib.Permission>();
                foreach (DataRow dr in dtDecentralizations.Rows)
                {
                    permission.Add(new CMSCommonLib.Permission((string)dr["ControlID"], (bool)dr["Enable"], (bool)dr["Visible"], (bool)dr["ReadOnly"]));
                }
                return permission;
            }

            protected override void Init_IgnoreListUser()
            {
                this.IgnoreListUser.Add("ADMIN");
                this.IgnoreListUser.Add("UISTEAM");
            }

            public override bool IgnoreUserPermission
            {
                get
                {
                    return this.IgnoreListUser.Any(user => string.Compare(user, CMSUser._UserID, true) == 0);
                }
            }
        }
        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };
        public static string ChuyenCoDauThanhKhongDau(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }

            return str;
        }

        static FormPermission _fPermission = new FormPermission();

        #region SetFormPermiss(Control Parent)
        public static void SetFormPermiss(Control Parent)
        {
            try
            {
                if (_fPermission.IgnoreUserPermission)
                    return;
                DataTable tblPermiss = new DataTable();
                DataView dv = new DataView(_dtDecentralizations);
                dv.RowFilter = "FormID = '" + Parent.Name + "'";
                tblPermiss = dv.ToTable(true, new string[] { "ControlID", "Enable", "Visible", "ReadOnly" });
                _fPermission.SetPermission(Parent, tblPermiss);
            }
            catch { }
        }
        #endregion
        #endregion

        #region Encode and decode
        public static string EncodeString(string toEncrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                // Key lock
                string key = "U2NvcmVNYW5hZ2FtZW50cw==";

                //If hashing use get hashcode regards to your key
                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    //Always release the resources and flush data
                    // of the Cryptographic service provide. Best Practice

                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes.
                //We choose ECB(Electronic code Book)
                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)

                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                //transform the specified region of bytes array to resultArray
                byte[] resultArray =
                  cTransform.TransformFinalBlock(toEncryptArray, 0,
                  toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor
                tdes.Clear();
                //Return the encrypted data into unreadable string format
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch { return toEncrypt; }
        }

        public static string DecodeString(string cipherString, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                //get the byte code of the string

                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                //Key to open the lock!
                string key = "U2NvcmVNYW5hZ2FtZW50cw==";

                if (useHashing)
                {
                    //if hashing was used get the hash code with regards to your key
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    //release any resource held by the MD5CryptoServiceProvider

                    hashmd5.Clear();
                }
                else
                {
                    //if hashing was not implemented get the byte code of the key
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);
                }

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes. 
                //We choose ECB(Electronic code Book)

                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(
                                     toEncryptArray, 0, toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor                
                tdes.Clear();
                //return the Clear decrypted TEXT
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch { return cipherString; }
        }

        public static string EncodeMD5(string userName, string password)
        {
            string result = string.Empty;
            try
            {
                result = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("UisStaffID=" + userName.ToUpper() + ";UisPassword=" + password, "MD5");
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }

        private static string ConvertFromBinaryToCharacter(string b)
        {
            double result = 0;
            for (int i = 0; i < 16; i++)
            {
                if (b[i] == '1') result += Math.Pow(2, 15 - i);
            }
            return Convert.ToChar(Convert.ToInt32(result)).ToString();
        }

        private static string ConvertFromCharacterToBinary(char c)
        {
            string result = string.Empty;
            double value = Convert.ToDouble(Convert.ToInt32(c));
            for (double i = 15; i >= 0; i--)
            {
                if (value >= Math.Pow(2, i))
                {
                    result += "1";
                    value -= Math.Pow(2, i);
                }
                else
                    result += "0";
            }
            return result;
        }

        public static string DecodeString(string s)
        {
            string result = string.Empty;
            if (s == string.Empty) return string.Empty;
            for (int i = 0; i < s.Length; i += 16)
            {
                string temp = string.Empty;
                for (int j = 0; j < 16; j++)
                {
                    temp += s[i + j].ToString();
                }
                result += ConvertFromBinaryToCharacter(temp);
            }
            return result;
        }

        public static string EncodeString(string s)
        {
            string result = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                result += ConvertFromCharacterToBinary(s[i]);
            }
            return result;
        }

        #endregion

        #region IsFocusForm
        public static bool IsFocusForm(Type type, Form frmParent, string title)
        {
            int i = 0;
            foreach (Form frm in frmParent.MdiChildren)
            {
                if (frm.GetType() == type)
                {
                    if (frm.Text.Trim() == title.Trim())
                    {
                        if (frm.MinimizeBox)
                        {
                            frm.Focus();
                            frm.WindowState = FormWindowState.Normal;
                        }
                        frm.Focus();
                        return true;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            if (i != 0)
                return false;
            return false;
        }

        public static bool IsFocusForm(Type type, Form frmParent)
        {
            int i = 0;
            foreach (Form frm in frmParent.MdiChildren)
            {
                if (frm.GetType() == type)
                {
                    if (frm.MinimizeBox)
                    {
                        frm.Focus();
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.Focus();
                    return true;
                }
                else
                {
                    i++;
                }
            }
            if (i != 0)
                return false;
            return false;
        }
        public static bool IsFocusForm_New(Type type, Form frmParent, string MaKH)
        {
            foreach (Form frm in frmParent.MdiChildren)
            {
                // Kiểm tra xem form có phải là loại cần tìm và mã đơn có trùng khớp không
                if (frm.GetType() == type && (frm as frm_CMS_KhachHang_Form).MaKH == MaKH)
                {
                    // Nếu form đã mở và mã đơn trùng, lấy focus cho form đó
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.Focus();
                    return true; // Form đã mở và đã lấy focus
                }
            }

            // Nếu chưa mở, tạo và mở form mới với mã đơn tương ứng
            Form newForm = (Form)Activator.CreateInstance(type, MaKH); // Tạo instance mới và truyền mã đơn
            newForm.MdiParent = frmParent; // Đặt form cha
            newForm.Show(); // Hiển thị form

            return false; // Form chưa mở, đã tạo form mới
        }
        #endregion

        public static string RefreshXmlString(string value)
        {
            try
            {
                if (value.Contains("&"))
                {
                    value = value.Replace("&", "&#038;");
                }
                if (value.Contains(">"))
                {
                    value = value.Replace(">", "&#062;");
                }
                if (value.Contains("<"))
                {
                    value = value.Replace("<", "&#060;");
                }
                if (value.Contains("\""))
                {
                    value = value.Replace("\"", "&#034;");
                }

                return value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
