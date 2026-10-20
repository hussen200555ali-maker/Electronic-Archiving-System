using DevExpress.XtraEditors;
using Electronic_Archive.Helpers;
using Electronic_Archive.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Electronic_Archive.Pages
{
    public partial class HomePage : DevExpress.XtraEditors.XtraUserControl
    {
        private DBEArchieEntity db = new DBEArchieEntity();
        //      DBEArchieEntity db;
        private int Depcount;
        private int Userscount;
        private int Archivecount;
        private double TotalSize;
        
        public HomePage()
        {
            InitializeComponent();
            db = new DBEArchieEntity();
        }

        private async void HomePage_Load(object sender, EventArgs e)
        {
            
            try
            {
                await LoadStatistics(); // تحميل الإحصائيات عند التحميل
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في التحميل: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // تحميل الإحصائيات من قاعدة البيانات
        private async Task LoadStatistics()
        {
            await Task.Run(() =>
            {
                // جلب عدد الأقسام
                Depcount = db.TB_Dep.Count();
                // جلب عدد المستخدمين
                Userscount = db.TBUsers.Count();
                // جلب عدد الفئات الأرشيفية
                Archivecount = db.TBArchiveCat.Count();

                LoadDataSize();
            });

            // عرض الإحصائيات في عناصر الواجهة
            txt_DepCount.Text = Depcount.ToString();
            txt_usersCount.Text = Userscount.ToString();
            txt_archiveCount.Text = Archivecount.ToString();
        }

      
        // دالة البحث مع الفلترة حسب الصلاحيات
        private List<ArchiveFileVM> SearchFiles(string keyword)
        {
            var currentUserRole = Properties.Settings.Default.UserRole;
            var currentUserDep = Properties.Settings.Default.UserDep;
            var currentUserID = Properties.Settings.Default.UserID;

            var query = from file in db.ArchiveFiles
                        join archive in db.TBArchive1 on file.IDArchive equals archive.ID
                        join category in db.TBArchiveCat on archive.IDCategory equals category.ID
                        join user in db.TBUsers on category.IDUser equals user.ID
                        select new ArchiveFileVM
                        {
                            ID = file.ID,
                            FileName = file.FileName,
                            ArchiveTitle = archive.ArchiveTitle,
                            Category = category.ArchiveTitle,
                            Sender = archive.ArchSender,
                            Receiver = archive.ArchReciver,
                            ArchiveDate = archive.ArchDate,
                            FileSize = file.FileSize ?? 0,
                            FileData = file.FileData,
                            FileExtension = file.FileExtension,
                            UserName = user.UserName,
                            DepName = user.DeptName
                        };

            // تطبيق الفلترة حسب الصلاحية
            switch (currentUserRole)
            {
                case "مدير":
                    break;
                case "مدير قسم":
                    query = query.Where(f => f.DepName == currentUserDep);
                    break;
                case "موظف":
                    query = query.Where(f => f.UserName == Properties.Settings.Default.UserName);
                    break;
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(f =>
                    f.FileName.ToLower().Contains(keyword) ||
                    f.FileName.Contains(keyword) ||
                    f.ArchiveTitle.ToLower().Contains(keyword)||
                    f.FileExtension.ToLower().Contains(keyword)||
                    f.Sender.ToLower().Contains(keyword)||
                    f.Receiver.ToLower().Contains(keyword) ||
                    f.ArchiveDate.ToString().Contains(keyword)||
                    f.Receiver.ToLower().Contains(keyword)||
                   f.DepName.ToString().Contains(keyword)||
                   f.UserName.Equals(keyword)
                    );
            }

            return query.ToList();
        }

     

        private void LoadDataSize()
        {
            try
            {
                long totalBytes = db.ArchiveFiles
                    .Where(x => x.FileSize != null)
                    .Sum(x => x.FileSize ?? 0); // معالجة القيم الفارغة

                string[] sizes = { "B", "KB", "MB", "GB" };
                int order = 0;
                double size = totalBytes;

                // التحويل التلقائي للوحدات
                while (size >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    size /= 1024;
                }

                // تحديث عنصر الواجهة على thread UI
                this.Invoke((MethodInvoker)delegate
                {
                    txt_dataSize.Text = $"{size:N2} {sizes[order]}";
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LoadData: {ex.Message}");
                this.Invoke((MethodInvoker)delegate
                {
                    txt_dataSize.Text = "0.0 B";
                });
            }
        }
        private async void LoadData()
        {
           

            try
            {
                string keyword = btn_search.Text.Trim();
                var results = await Task.Run(() => SearchFiles(keyword));

                if (results.Count == 0)
                {
                    XtraMessageBox.Show("لا توجد نتائج", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SearchResultsForm resultsForm = new SearchResultsForm(results);
                resultsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btn_search_Click(object sender, EventArgs e)
        {
           
              //////// فتح نتائج البحث في نموذج جديد
            
          try
            {
                string keyword = edt_search.Text.Trim();
                var results = await Task.Run(() => SearchFiles(keyword));

                if (results.Count == 0)
                {
                    XtraMessageBox.Show("لا توجد نتائج مطابقة للبحث", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    
                    return;


                }

                // فتح نموذج النتائج وإرسال البيانات إليه
                SearchResultsForm resultsForm = new SearchResultsForm(results);
                resultsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            AddPage.Addnewfile addnewfile = new AddPage.Addnewfile();
            addnewfile.Show();

        }
    }
    }

