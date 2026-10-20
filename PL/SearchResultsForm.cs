using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using Electronic_Archive.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DevExpress.XtraLayout;

namespace Electronic_Archive.PL
{
    public partial class SearchResultsForm : DevExpress.XtraEditors.XtraForm
    {
        private List<ArchiveFileVM> _results;
        string Depname;
        string UserRole;
        int UserId;

        public SearchResultsForm(List<ArchiveFileVM> results)
        {
            InitializeComponent();

            _results = results;
            InitializeGrid();
            WireUpEvents();
            gridResults.DataSource = _results;
         //   ApplySecurity();
            
        }

        // تهيئة أعمدة الجريد
        private void InitializeGrid()
        {
            gridViewResults.Columns.Clear();

            // إضافة الأعمدة مع التخصيص
            var columns = new[]
            {
                new { Field = "FileName", Caption = "اسم الملف", Width = 150},
                new { Field = "ArchiveTitle", Caption = "عنوان السجل", Width = 150 },
                new { Field = "Category", Caption = "الفئة", Width = 100 },
                new { Field = "Sender", Caption = "المرسل", Width = 100 },
                new { Field = "Receiver", Caption = "المستلم", Width = 100 },
                new { Field = "ArchiveDateFormatted", Caption = "التاريخ", Width = 80 },
                new { Field = "FileSizeFormatted", Caption = "الحجم", Width = 70 }
            };

            foreach (var col in columns)
            {
                gridViewResults.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    FieldName = col.Field,
                    Caption = col.Caption,
                    Width = col.Width,
                    
                    Visible = true
                });
            }
        }


        // ربط الأحداث
        private void WireUpEvents()
        {
            gridViewResults.DoubleClick += (s, e) => OpenSelectedFile();
            btnOpen.Click += (s, e) => OpenSelectedFile();
        }

        // تطبيق الصلاحيات على الأزرار
        //private void ApplySecurity()
        //{
        //    var role = Properties.Settings.Default.UserRole;
        //    btnOpen.Enabled = role == "مدير عام" || role == "مدير قسم";
        //}

        // فتح الملف المحدد
        private void OpenSelectedFile()
        {
            try
            {
                var selectedFile = gridViewResults.GetFocusedRow() as ArchiveFileVM;
                if (selectedFile == null)
                {
                    XtraMessageBox.Show("الرجاء تحديد ملف أولاً", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tempFile = Path.GetTempFileName() + selectedFile.FileExtension;
                File.WriteAllBytes(tempFile, selectedFile.FileData);
                Process.Start(new ProcessStartInfo(tempFile) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"فشل فتح الملف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

// تطبيق إعدادات الشركة من ملف الإعدادات
private void ApplyCompanySettings()
        {
            this.Text = $"{Properties.Settings.Default.CompanyName} - نتائج البحث";
            lblCompany.Text = Properties.Settings.Default.CompanyName;
            LoadCompanyLogo();
        }

        // تحميل شعار الشركة
        private void LoadCompanyLogo()
        {
            string logoPath = Properties.Settings.Default.CompanyLogoPath;
            if (!string.IsNullOrEmpty(logoPath))
            {
                string fullPath = System.IO.Path.Combine(Application.StartupPath, logoPath);
                if (System.IO.File.Exists(fullPath))
                {
                    picLogo.Image = System.Drawing.Image.FromFile(fullPath);
                }
            }
        }

        // حدث تصدير إلى Excel


        private void btnExportExcel_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "ملف Excel|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    gridViewResults.ExportToXlsx(sfd.FileName);
                    System.Diagnostics.Process.Start(sfd.FileName);
                }



            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenSelectedFile();
        }

        private void gridViewResults_Click(object sender, EventArgs e)
        {
            
            OpenSelectedFile();
        }
    }
}