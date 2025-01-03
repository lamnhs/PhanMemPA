using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace CMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                CMSUI.CMSUser._UserID = "";
                CMSUI.CMSUser._UserPass = "";
                CMSUI.CMSUser._UserGroup = "";
                CMSUI.CMSUser._ParaFromUIS = new string[] { };

                List<CommandLine> cmdLine = new List<CommandLine>();
                if (args != null)
                {
                    if (args.Contains("?") || args.Contains("-help"))
                    {
                        MessageBox.Show("-f : File thực thi\n"
                            + "-u: Username đăng nhập tự động vào ứng dụng\n"
                            + "-p: Password đăng nhập tự động vào ứng dụng\n"
                            + "-g: Nhóm sử dụng\n"
                            + "-form: Form tự động mở sau khi đăng nhập\n"
                            );
                        return;
                    }
                    if (args.Any(p => new string[] { "-u", "-p", "-form" }.Any(q => p.ToLower() == q)))
                    {
                        foreach (var cmd in args)
                        {
                            switch (cmd)
                            {
                                case "-f":
                                case "-u":
                                case "-p":
                                case "-g":
                                case "-form":
                                    {
                                        cmdLine.Add(new CommandLine { Name = cmd, Value = "" });
                                    }
                                    break;
                                default:
                                    {
                                        if (cmdLine.Count == 0)
                                        {
                                            cmdLine.Add(new CommandLine { Name = "-form", Value = "" });
                                        }

                                        cmdLine[cmdLine.Count - 1].Value += cmd;
                                    }
                                    break;
                            }
                        }
                        CommandLine cmd1 = cmdLine.FirstOrDefault(c => c.Name.ToLower() == "-u");
                        if (cmd1 != null)
                            CMSUI.CMSUser._UserID = cmd1.Value;
                        cmd1 = cmdLine.FirstOrDefault(c => c.Name.ToLower() == "-p");
                        if (cmd1 != null)
                            CMSUI.CMSUser._UserPass = cmd1.Value;
                        cmd1 = cmdLine.FirstOrDefault(c => c.Name.ToLower() == "-form");
                        if (cmd1 != null)
                            CMSUI.CMSUser._ParaFromUIS = new string[] { cmd1.Value };
                        cmd1 = cmdLine.FirstOrDefault(c => c.Name.ToLower() == "-g");
                        if (cmd1 != null)
                            CMSUI.CMSUser._UserGroup = cmd1.Value;
                    }
                    else
                    {
                        if (args.Length > 0)
                            CMSUI.CMSUser._UserID = args[0];
                        else
                            CMSUI.CMSUser._UserID = "";
                        if (args.Length > 1)
                            CMSUI.CMSUser._UserPass = args[1];
                        else
                            CMSUI.CMSUser._UserPass = "";
                        if (args.Length > 2)
                            CMSUI.CMSUser._UserGroup = args[2];
                        else
                            CMSUI.CMSUser._UserGroup = "";
                        if (CMSUI.CMSUser._ParaFromUIS == null)
                            CMSUI.CMSUser._ParaFromUIS = new string[] { };
                        if (args.Length > 3)
                        {
                            for (int i = 3; i < args.Length; i++)
                            {
                                if (args[i].Trim() != "")
                                {
                                    if (CMSUI.CMSUser._ParaFromUIS.Length == 0)
                                    {
                                        Array.Resize(ref CMSUI.CMSUser._ParaFromUIS, CMSUI.CMSUser._ParaFromUIS.Length + 1);
                                    }
                                    CMSUI.CMSUser._ParaFromUIS[0] = args[i];
                                }
                            }
                        }
                    }
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                BonusSkins.Register();

                if (Form.ModifierKeys == Keys.Shift)
                {
                    CMSUI.frm_CMS_ConnectDatabase frm = new CMSUI.frm_CMS_ConnectDatabase();
                    frm.ShowDialog();
                }

                Application.Run(new CMSUI.rfrm_CMS_Main());
            }
            catch { }
        }

        class CommandLine
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
