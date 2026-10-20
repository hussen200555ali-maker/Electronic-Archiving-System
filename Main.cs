using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Electronic_Archive
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
            LoadHomePage();
        }
        // Load Home Page

        private void btn_Home_ItemClic(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            LoadHomePage();

        }
        private void LoadHomePage()
        {
            Pages.HomePage page = new Pages.HomePage();
            LoadPage(page);

        }
        //Load Page Method

        private void LoadPage(DevExpress.XtraEditors.XtraUserControl Page)
        {
            try
            {
                var oldPage = pn_container.Controls.OfType<XtraUserControl>().FirstOrDefault();
                if (oldPage != null)
                {
                    pn_container.Controls.Remove(oldPage);
                    oldPage.Dispose();
                }
                pn_container.Controls.Clear();
                Page.Dock = DockStyle.Fill;
                pn_container.Controls.Add(Page);
            }
            catch { }
        }

        private void btn_Dep_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Pages.DepPage  page = new Pages.DepPage();
            LoadPage(page);

        }

        private void btn_users_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Pages.UsersPage page = new Pages.UsersPage();
            LoadPage(page);
        }

        private void btn_Archive_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Pages.ArchiveCatPage page = new Pages.ArchiveCatPage();
            LoadPage(page);

        }

        private void btn_Setting_ItemClick(object sender, TileItemEventArgs e)
        {
            PL.SettingForm setting = new PL.SettingForm();

            setting.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

        private void btn_logout_ItemClick(object sender, TileItemEventArgs e)
        {
            PL.LoginForm loginForm = new PL.LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
