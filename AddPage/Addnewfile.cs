using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraLayout.Customization;
using Electronic_Archive.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_Archive.AddPage
{
    public partial class Addnewfile : DevExpress.XtraEditors.XtraForm
    {
        private string DepName;
        private string UserRole;
        private int UserId;
        private string UserName;
        
        DBEArchieEntity db;
        private List<string> listCategory;
        TBArchiveCat tbadd;
        private int id;

        public Addnewfile()
        {
            InitializeComponent();
            DepName = Properties.Settings.Default.UserDep;
            UserRole = Properties.Settings.Default.UserRole;
            UserId = Properties.Settings.Default.UserID;
            db = new DBEArchieEntity();
        }
        private void GetCategoryName()
        {
            try
            {
                if(UserRole == "مدير") { listCategory = db.TBArchiveCat.Select(x => x.ArchiveTitle).ToList(); }
               else if(UserRole =="مدير قسم")
                {
                    listCategory = db.TBArchiveCat.Where(x=> x.UserDep == DepName).Select(x => x.ArchiveTitle).ToList();
                }
                else
                {
                    listCategory = db.TBArchiveCat.Where(x=> x.IDUser == UserId).Select(x => x.ArchiveTitle).ToList();
                }
                  
            }catch { }
        }

        private async void  comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void Addnewfile_Load(object sender, EventArgs e)
        {
            await Task.Run(() => GetCategoryName());
            comboBox1.DataSource = listCategory;
        }
    
    private void setCatData(string catName)
        {
            try
            {
                tbadd = db.TBArchiveCat.Where(x=>x.ArchiveTitle ==catName).FirstOrDefault();
            }
            catch { }
        }

        private async void btn_search_Click(object sender, EventArgs e)
        {

            try
            {
                var catName = comboBox1.SelectedItem.ToString();
                await Task.Run(() => setCatData(catName));
                PL.ArchiveFilesForm archive = new PL.ArchiveFilesForm();

                id = tbadd.ID;
                archive.lb_id.Text = id.ToString();
                archive.AchiveID = id;
                archive.lb_ArchiveName.Text = tbadd.ArchiveTitle;
                archive.lb_Dep.Text = tbadd.UserDep;
                archive.Show();
               this.Close();
            }
            catch { }
        }
    }
}