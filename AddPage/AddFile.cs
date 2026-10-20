using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraDashboardLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Electronic_Archive.Helpers;
using Electronic_Archive.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_Archive.AddPage
{
    public partial class AddFile : DevExpress.XtraEditors.XtraForm
    {
        public bool UpdatePage;
        private DBEArchieEntity db;
        private TBArchive1 tbadd;
        private List<ArchiveFile> tbFilesList;

        private static byte[] AESKey = Encoding.UTF8.GetBytes("12345647891041112131415617181920"); // 32 byte
        private static byte[] AESIV = Encoding.UTF8.GetBytes("1234567890123456"); // 16 byte
        bool fileChinge = false;
        public int id { get; set; }
        public int IDArch { get; set; }
        public string ArchDep { get; set; }
        public PL.ArchiveFilesForm page { get; set; }
        private string[] FileNames { get; set; }
        public string ArcTitle;

        private bool replaceExistingFiles = true; // القيمة الافتراضية: استبدال الملفات
        public AddFile()
        {
            InitializeComponent();
            InitializeForm();
        }


        private void InitializeForm()
        {

        
            if (id > 0)
            {
                var btnReplace = new SimpleButton { Text = "استبدال الملفات الحالية", Width = 160 };
                var btnAdd = new SimpleButton { Text = "إضافة إلى الملفات الحالية", Width = 160 };

                btnReplace.Click += (s, e) => { replaceExistingFiles = true; UpdateOperationMode(); };
                btnAdd.Click += (s, e) => { replaceExistingFiles = false; UpdateOperationMode(); };

                var panel = new Panel { Dock = DockStyle.Top, Height = 40 };
                panel.Controls.Add(btnReplace);
                panel.Controls.Add(btnAdd);
                btnAdd.Location = new Point(btnReplace.Right + 10, 0);

                this.Controls.Add(panel);
                panel.BringToFront();

                // تعيين الوضع الافتراضي عند التعديل
                replaceExistingFiles = true;
            }
            else
            {
                // في حالة الإضافة الجديدة، نستخدم الوضع الافتراضي (لا داعي للخيارات)
                replaceExistingFiles = true;
            }

            UpdateOperationMode();
        }


        //// edt_Archdate.Text = DateTime.Now.ToString();
        //// btn_selectFiles.Text = "اختر الملفات";
        //// Loading.Visible = false;

        //// إضافة زرين اختيار طريقة التعامل مع الملفات
        ////var btnReplace = new SimpleButton { Text = "استبدال الملفات الحالية", Width = 160 };
        //// var btnAdd = new SimpleButton { Text = "إضافة إلى الملفات الحالية", Width = 160 };

        //// btnReplace.Click += (s, e) => { replaceExistingFiles = true; UpdateOperationMode(); };
        //// btnAdd.Click += (s, e) => { replaceExistingFiles = false; UpdateOperationMode(); };

        //// var panel = new Panel { Dock = DockStyle.Top, Height = 40 };
        //// panel.Controls.Add(btnReplace);
        //// panel.Controls.Add(btnAdd);
        //// btnAdd.Location = new Point(btnReplace.Right + 10, 0);

        //// this.Controls.Add(panel);
        //// panel.BringToFront();

        //// UpdateOperationMode();



        private void UpdateOperationMode()
        {
            // تحديث واجهة المستخدم بناءً على الوضع الحالي
            if (id > 0)
            {
                lblOperationMode.Text = replaceExistingFiles ?
                    "وضع العملية: استبدال الملفات الحالية" :
                    "وضع العملية: إضافة إلى الملفات الحالية";
                lblOperationMode.Appearance.ForeColor = replaceExistingFiles ? Color.Red : Color.Green;
                lblOperationMode.Visible = true;
            }
            else
            {
                // إخفاء التسمية التوضيحية في حالة الإضافة الجديدة
                lblOperationMode.Visible = false;
            }
        }

            private void AddFile_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                LoadExistingRecord();
                InitializeForm();
            }
        }

        private void LoadExistingRecord()
        {
            using (db = new DBEArchieEntity())
            {
                var archive = db.TBArchive1.Find(id);
                if (archive != null)
                {
                    edt_Title.Text = archive.ArchiveTitle;
                    edt_number.Text = archive.ArchNumber;
                    edt_Archdate.Text = archive.ArchDate.ToString();
                    edt_sender.Text = archive.ArchSender;
                    edt_reciver.Text = archive.ArchReciver;
                    edt_details.Text = archive.ArchDetails;
                }

                var existingFiles = db.ArchiveFiles.Where(f => f.IDArchive == id).ToList();
                if (existingFiles.Any())
                {
                    FileNames = existingFiles.Select(f => f.FileName).ToArray();
                  //  btn_selectFiles.Text = $"تم اختيار {FileNames.Length} ملفات، انقر لتغييرها";
                }
            }
        }


        private async void btn_Add_Click(object sender, EventArgs e)
        {

            if (!ValidateInputs())
            {
                XtraMessageBox.Show("يرجى إكمال جميع الحقول المطلوبة", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrepareArchiveObject();
            tbFilesList = PrepareFilesList(FileNames);

            Loading.Visible = true;
            bool result = await Task.Run(() => AddOrEditArchive(tbadd, tbFilesList));
            HandleOperationResult(result);
            Loading.Visible = false;

        }

        private bool ValidateInputs()
        {
            return !string.IsNullOrWhiteSpace(edt_Title.Text) &&
                   FileNames != null &&
                   FileNames.Length > 0;
        }


        private void PrepareArchiveObject()
        {
            tbadd = new TBArchive1
            {
                ArchDate = edt_Archdate.Value,
                ArchDep = ArchDep,
                ArchDetails = edt_details.Text,
                ArchReciver = edt_reciver.Text,
                ArchSender = edt_sender.Text,
                ArchiveTitle = edt_Title.Text,
                IDCategory = IDArch,
                ArchNumber = edt_number.Text
            };

            if (id > 0) tbadd.ID = id;
        }

        private List<ArchiveFile> PrepareFilesList(string[] filePaths)
        {
            try
            {
                var filesList = new List<ArchiveFile>();
                foreach (string filePath in filePaths)
                {
                    var fileInfo = new FileInfo(filePath);
                    byte[] fileData = File.ReadAllBytes(filePath);
                    byte[] encryptedData = EncryptData(fileData);

                    filesList.Add(new ArchiveFile
                    {
                        FileName = fileInfo.Name,
                        FileExtension = fileInfo.Extension,
                        FileSize = (int)fileInfo.Length,
                        FileData = encryptedData,
                        UploadedDate = DateTime.Now
                    });
                }
                return filesList;
            }
            catch
            {
                XtraMessageBox.Show("يرجى اختيار ملف واحد على الأقل من أجل اكمال العملية بنجاح", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return null ;
            }
            }






        private byte[] EncryptData(byte[] data)
        {
            using (Aes aes = Aes.Create())
            {   
        
                aes.Key =  Encoding.UTF8.GetBytes("12345647891041112131415617181920"); // استخدام المفتاح الموحد
                aes.IV = Encoding.UTF8.GetBytes("1234567890123456");   // استخدام IV الموحد

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
        }

        private bool AddOrEditArchive(TBArchive1 archiveData, List<ArchiveFile> files)
        {
            if (files != null)
            {
                using (db = new DBEArchieEntity())
                using (var transaction = db.Database.BeginTransaction())
                {

                    try
                    {
                        db.Set<TBArchive1>().AddOrUpdate(archiveData);
                        db.SaveChanges();

                        if (archiveData.ID > 0 && replaceExistingFiles)
                        {
                            var existingFiles = db.ArchiveFiles.Where(f => f.IDArchive == archiveData.ID).ToList();
                            db.ArchiveFiles.RemoveRange(existingFiles);
                            db.SaveChanges();
                        }


                        foreach (var file in files)
                        {
                            file.IDArchive = archiveData.ID;
                            db.Set<ArchiveFile>().Add(file);
                        }

                        db.SaveChanges();

                        ManageArchiveFolders(archiveData);
                        transaction.Commit();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LogError(ex);
                        return false;
                    }
                }
            }
            else { return false; }
                
            
            
            
        }

        private void ManageArchiveFolders(TBArchive1 archive)
        {
            try
            {
                var categoryName = db.TBArchive1
                    .Where(c => c.ID == archive.IDCategory)
                    .Select(c => c.ArchiveTitle)
                    .FirstOrDefault();

                if (id == 0)
                {
                    FileManager.CreateArchiveCategoryFolder(archive.ArchDep, archive.ArchiveTitle);
                }
                else
                {
                    var oldTitle = db.TBArchive1
                        .Where(a => a.ID == archive.ID)
                        .Select(a => a.ArchiveTitle)
                        .FirstOrDefault();

                    if (oldTitle != archive.ArchiveTitle)
                    {
                        FileManager.RenameArchiveCategoryFolder(
                            archive.ArchDep,
                            oldTitle,
                            archive.ArchiveTitle
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private void btn_selectFiles_Click(object sender, EventArgs e) {
    
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;
                    ofd.Title = "اختر الملفات";
                    ofd.Filter = "كل الملفات|*.*";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        FileNames = ofd.FileNames;
                        btn_selectFiles.Text = $"تم اختيار {FileNames.Length} ملفات، انقر لتغييرها";
                        XtraMessageBox.Show($"{FileNames.Length} ملفات تم تحديدها بنجاح.",
                            "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
}
            }
            catch (Exception ex)
            {
    XtraMessageBox.Show("حدث خطأ غير متوقع: " + ex.Message,
        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
        }

        private void HandleOperationResult(bool result)
{
    if (result)
    {
                UpdatePage = true;
        page.LoadData();
        ShowSuccessMessage(id > 0 ? "تم التعديل بنجاح" : "تمت الإضافة بنجاح");
        Close();
    }
    else
    {
        XtraMessageBox.Show("حدث خطأ أثناء العملية", "خطأ",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

private void ShowSuccessMessage(string message)
{
    toastNotificationsManager1.ShowNotification("96b3f4ff-8dbc-4221-b131-4eba588d4ffa");
    XtraMessageBox.Show(message, "نجاح",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
}

private void LogError(Exception ex)
{
    try
    {
        string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt");
        File.AppendAllText(logPath, $"[{DateTime.Now}] Error: {ex.Message}\n{ex.StackTrace}\n\n");
    }
    catch { }
}
    }
}

                    