using Electronic_Archive.Pages;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using DevExpress.Utils.Drawing.Helpers;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Identity.Client;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using System.Diagnostics;
using DevExpress.XtraEditors;


namespace Electronic_Archive.PL
{
    public partial class SettingForm : DevExpress.XtraEditors.XtraForm
    {

        // يجب تغيير هذه المفاتيح وحفظها في مكان آمن (يفضل استخدام إدارة الأسرار)
     
        private DBEArchieEntity db;
        private string msg;
        public int start;
        // حدث للإشعار بتحديث الإعدادات
        public static event Action SettingsUpdated;

        // حدث للإشعار بتحديث الإعدادات
       // public static event Action SettingsUpdated;

        public SettingForm()
        {
            InitializeComponent();
            this.Load += SettingForm_Load;
        }

       
// حدث تحميل النموذج
private void SettingForm_Load(object sender, EventArgs e)
        {
            LoadDatabaseSettings(); // تحميل إعدادات قاعدة البيانات
            LoadCompanySettings();  // تحميل إعدادات الشركة
            SetConnectionType();    // ضبط نوع الاتصال

            //try
            //{
            //    LoadDatabaseSettings();
            //    LoadCompanySettings();
            //}
            //catch (Exception ex)
            //{
            //    ShowError("خطأ في التحميل الأولي", ex);
            //}

        }


        #region إعدادات الشركة

        /// <summary>
        /// تحميل إعدادات الشركة من ملف الإعدادات
        /// </summary>
        private void LoadCompanySettings()
        {
            try
            {
                // تحميل البيانات النصية
                edt_Companyname.Text = Properties.Settings.Default.CompanyName;
                edt_CompanyDes.Text = Properties.Settings.Default.CompanyDes;

                // تحميل صورة الشعار إذا كانت موجودة
                if (!string.IsNullOrEmpty(Properties.Settings.Default.CompanyLogoPath))
                {
                    string fullPath = Path.Combine(Application.StartupPath,
                                                Properties.Settings.Default.CompanyLogoPath);
                    if (File.Exists(fullPath))
                    {
                        pic_logo.Image = Image.FromFile(fullPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل إعدادات الشركة: {ex.Message}",
                              "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// حدث تغيير صورة الشعار
        /// </summary>
        private void btn_ChangeLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "ملفات الصور|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "اختر صورة الشعار";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // إنشاء مجلد الصور إذا لم يكن موجوداً
                        string imagesDir = Path.Combine(Application.StartupPath, "Images");
                        if (!Directory.Exists(imagesDir))
                            Directory.CreateDirectory(imagesDir);

                        // نسخ الصورة إلى مجلد التطبيق
                        string fileName = Path.GetFileName(ofd.FileName);
                        string destPath = Path.Combine("Images", fileName); // مسار نسبي
                        string fullDestPath = Path.Combine(Application.StartupPath, destPath);

                        File.Copy(ofd.FileName, fullDestPath, true);

                        // عرض الصورة وحفظ المسار
                        pic_logo.Image?.Dispose(); // تحرير الموارد إن وجدت
                        pic_logo.Image = Image.FromFile(fullDestPath);
                        Properties.Settings.Default.CompanyLogoPath = destPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"خطأ في تحميل الصورة: {ex.Message}",
                                      "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// حفظ إعدادات الشركة
        /// </summary>
        private void SaveCompanySettings()
        {
            try
            {
                // التحقق من البيانات المطلوبة
                if (string.IsNullOrWhiteSpace(edt_Companyname.Text))
                {
                    MessageBox.Show("يجب إدخال اسم الشركة", "تحذير",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // حفظ الإعدادات
                Properties.Settings.Default.CompanyName = edt_Companyname.Text.Trim();
                Properties.Settings.Default.CompanyDes = edt_CompanyDes.Text.Trim();
                Properties.Settings.Default.Save();

                // إشعار النوافذ الأخرى بالتحديث
                SettingsUpdated?.Invoke();

                MessageBox.Show("تم حفظ إعدادات الشركة بنجاح",
                               "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حفظ إعدادات الشركة: {ex.Message}",
                               "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region إعدادات قاعدة البيانات

        /// <summary>
        /// تحميل إعدادات قاعدة البيانات الحالية
        /// </summary>
        //////private void LoadDatabaseSettings()
        //////{


        //////    ////////try
        //////    //////////{
        //////    //////////    var connString = ConfigurationManager.ConnectionStrings["DBEArchieEntity"].ConnectionString;
        //////    //////////    var entityBuilder = new EntityConnectionStringBuilder(connString);
        //////    //////////    var sqlBuilder = new SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString);
        //////    ////////{ 
        //////    ////////    string encryptedConnection = ConfigurationManager.ConnectionStrings["DBEArchieEntity"].ConnectionString;

        //////    ////////    // فك تشفير سلسلة الاتصال
        //////    ////////    string connString = AesEncryptionHelper.Decrypt(encryptedConnection);

        //////    ////////    var entityBuilder = new EntityConnectionStringBuilder(connString);
        //////    ////////    var sqlBuilder = new SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString);


        //////    ////////    edt_serverName.Text = sqlBuilder.DataSource.Split(',')[0];
        //////    ////////    edt_DB.Text = sqlBuilder.InitialCatalog;

        //////    ////////    bool isWindowsAuth = sqlBuilder.IntegratedSecurity ||
        //////    ////////                       (string.IsNullOrEmpty(sqlBuilder.UserID) &&
        //////    ////////                        string.IsNullOrEmpty(sqlBuilder.Password));

        //////    ////////    rb_local.Checked = isWindowsAuth;
        //////    ////////    rb_remote.Checked = !isWindowsAuth;  // تأكد من أن الزرين متعارضان

        //////    ////////    if (!isWindowsAuth)
        //////    ////////    {
        //////    ////////        edt_username.Text = sqlBuilder.UserID;
        //////    ////////        edt_password.Text = sqlBuilder.Password;
        //////    ////////        if (sqlBuilder.DataSource.Contains(","))
        //////    ////////            edt_Port.Text = sqlBuilder.DataSource.Split(',')[1];
        //////    ////////    }
        //////    ////////}
        //////    ////////catch (Exception ex)
        //////    ////////{
        //////    ////////    MessageBox.Show($"خطأ في تحميل إعدادات قاعدة البيانات: {ex.Message}", "خطأ",
        //////    ////////                   MessageBoxButtons.OK, MessageBoxIcon.Error);
        //////    ////////}

        //////    //try
        //////    //{
        //////    //    string connString = ConfigurationManager.ConnectionStrings["DBEArchieEntity"].ConnectionString;

        //////    //    // التحقق مما إذا كانت السلسلة مشفرة
        //////    //    if (IsBase64String(connString))
        //////    //    {
        //////    //        try
        //////    //        {
        //////    //            connString = AesEncryptionHelper.Decrypt(connString);
        //////    //        }
        //////    //        catch (Exception decEx)
        //////    //        {
        //////    //            MessageBox.Show($"خطأ في فك تشفير سلسلة الاتصال: {decEx.Message}\nسيتم استخدام السلسلة كما هي",
        //////    //                          "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //////    //        }
        //////    //    }

        //////    //    var entityBuilder = new EntityConnectionStringBuilder(connString);
        //////    //    var sqlBuilder = new SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString);

        //////    //    edt_serverName.Text = sqlBuilder.DataSource.Split(',')[0];
        //////    //    edt_DB.Text = sqlBuilder.InitialCatalog;

        //////    //    bool isWindowsAuth = sqlBuilder.IntegratedSecurity ||
        //////    //                       (string.IsNullOrEmpty(sqlBuilder.UserID) &&
        //////    //                        string.IsNullOrEmpty(sqlBuilder.Password));

        //////    //    rb_local.Checked = isWindowsAuth;
        //////    //    rb_remote.Checked = !isWindowsAuth;

        //////    //    if (!isWindowsAuth)
        //////    //    {
        //////    //        edt_username.Text = sqlBuilder.UserID;
        //////    //        edt_password.Text = sqlBuilder.Password;
        //////    //        if (sqlBuilder.DataSource.Contains(","))
        //////    //            edt_Port.Text = sqlBuilder.DataSource.Split(',')[1];
        //////    //    }
        //////    //}
        //////    //catch (Exception ex)
        //////    //{
        //////    //    // إذا فشل كل شيء، استخدم إعدادات افتراضية
        //////    //    SetDefaultConnectionSettings();
        //////    //    MessageBox.Show($"خطأ في تحميل إعدادات قاعدة البيانات: {ex.Message}\nتم استخدام الإعدادات الافتراضية",
        //////    //                  "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //////    //}


        //////    try
        //////    {
        //////        var connString = ConfigurationManager.ConnectionStrings["DBEArchieEntity"].ConnectionString;
        //////        var entityBuilder = new EntityConnectionStringBuilder(connString);
        //////        var sqlBuilder = new SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString);

        //////        edt_serverName.Text = sqlBuilder.DataSource.Split(',')[0];
        //////        edt_DB.Text = sqlBuilder.InitialCatalog;

        //////        bool isWindowsAuth = sqlBuilder.IntegratedSecurity ||
        //////                           (string.IsNullOrEmpty(sqlBuilder.UserID) &&
        //////                            string.IsNullOrEmpty(sqlBuilder.Password));

        //////        rb_local.Checked = isWindowsAuth;
        //////        rb_remote.Checked = !isWindowsAuth;  // تأكد من أن الزرين متعارضان

        //////        if (!isWindowsAuth)
        //////        {
        //////            edt_username.Text = sqlBuilder.UserID;
        //////            edt_password.Text = sqlBuilder.Password;
        //////            if (sqlBuilder.DataSource.Contains(","))
        //////                edt_Port.Text = sqlBuilder.DataSource.Split(',')[1];
        //////        }
        //////    }
        //////    catch (Exception ex)
        //////    {
        //////        MessageBox.Show($"خطأ في تحميل إعدادات قاعدة البيانات: {ex.Message}", "خطأ",
        //////                       MessageBoxButtons.OK, MessageBoxIcon.Error);
        //////    }



        //////    ////////////////////try
        //////    ////////////////////{
        //////    ////////////////////    var connString = ConfigurationManager.ConnectionStrings["DBEArchieEntity"]?.ConnectionString;

        //////    ////////////////////    if (string.IsNullOrEmpty(connString))
        //////    ////////////////////        throw new Exception("سلسلة الاتصال غير موجودة في ملف الإعدادات");

        //////    ////////////////////    // التعديل 5: تسجيل السلسلة للتصحيح
        //////    ////////////////////    Debug.WriteLine($"السلسلة المشفرة: {connString}");

        //////    ////////////////////    if (IsBase64String(connString))
        //////    ////////////////////    {
        //////    ////////////////////        connString = AesEncryptionHelper.Decrypt(connString);
        //////    ////////////////////        Debug.WriteLine($"السلسلة بعد الفك: {connString}");
        //////    ////////////////////    }

        //////    ////////////////////    var entityBuilder = new EntityConnectionStringBuilder(connString);
        //////    ////////////////////    var sqlBuilder = new SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString);

        //////    ////////////////////    edt_serverName.Text = sqlBuilder.DataSource;
        //////    ////////////////////    edt_DB.Text = sqlBuilder.InitialCatalog;

        //////    ////////////////////    var isWindowsAuth = sqlBuilder.IntegratedSecurity;
        //////    ////////////////////    rb_local.Checked = isWindowsAuth;
        //////    ////////////////////    rb_remote.Checked = !isWindowsAuth;

        //////    ////////////////////    if (!isWindowsAuth)
        //////    ////////////////////    {
        //////    ////////////////////        edt_username.Text = sqlBuilder.UserID;
        //////    ////////////////////        edt_password.Text = sqlBuilder.Password;
        //////    ////////////////////    }
        //////    ////////////////////}
        //////    ////////////////////catch (Exception ex)
        //////    ////////////////////{
        //////    ////////////////////    ShowError("فشل تحميل إعدادات قاعدة البيانات", ex);
        //////    ////////////////////}



        //////}

        private void LoadDatabaseSettings()
        {
            try
            {
                var connString = ConfigurationManager.ConnectionStrings["DBEArchieEntity"].ConnectionString;
                var entityBuilder = new EntityConnectionStringBuilder(connString);
                var sqlBuilder = new SqlConnectionStringBuilder(entityBuilder.ProviderConnectionString);

                edt_serverName.Text = sqlBuilder.DataSource.Split(',')[0];
                edt_DB.Text = sqlBuilder.InitialCatalog;

                bool isWindowsAuth = sqlBuilder.IntegratedSecurity ||
                                    (string.IsNullOrEmpty(sqlBuilder.UserID) &&
                                     string.IsNullOrEmpty(sqlBuilder.Password));

                rb_local.Checked = isWindowsAuth;
                rb_remote.Checked = !isWindowsAuth;

                if (!isWindowsAuth)
                {
                    edt_username.Text = sqlBuilder.UserID;
                    edt_password.Text = sqlBuilder.Password;
                    if (sqlBuilder.DataSource.Contains(","))
                        edt_Port.Text = sqlBuilder.DataSource.Split(',')[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل إعدادات قاعدة البيانات: {ex.Message}", "خطأ",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //private void SetDefaultConnectionSettings()
        //{
        //    edt_serverName.Text = "localhost";
        //    edt_DB.Text = "DBEArchie";
        //    rb_local.Checked = true;
        //    edt_username.Text = "";
        //    edt_password.Text = "";
        //    edt_Port.Text = "";
        //}

        /// <summary>
        /// ضبط نوع الاتصال (محلي/بعيد)
        /// </summary>
        private void SetConnectionType()
        {
            // تمكين/تعطيل الحقول حسب نوع الاتصال
            bool isRemote = rb_remote.Checked;
            edt_username.Enabled = isRemote;
            edt_password.Enabled = isRemote;
            edt_Port.Enabled = isRemote;

            // إعادة تعيين القيم إذا تم التبديل إلى المحلي
            if (!isRemote)
            {
                edt_username.Enabled = isRemote;
                edt_password.Enabled = isRemote;
                edt_Port.Enabled = isRemote;

            }


            //// تمكين/تعطيل الحقول حسب نوع الاتصال
            //bool isRemote = rb_remote.Checked;
            //edt_username.Enabled = isRemote;
            //edt_password.Enabled = isRemote;
            //edt_Port.Enabled = isRemote;

            //// إعادة تعيين القيم إذا تم التبديل إلى المحلي
            //if (!isRemote)
            //{
            //    edt_username.Enabled = isRemote;
            //    edt_password.Enabled = isRemote;
            //    edt_Port.Enabled = isRemote;

            //}

        }

        /// <summary>
        /// حدث تغيير نوع الاتصال إلى محلي
        /// </summary>
        private void rb_local_CheckedChanged(object sender, EventArgs e)
        {
   if (rb_local.Checked)
            {
                SetConnectionType();
            }
        }

        /// <summary>
        /// حدث تغيير نوع الاتصال إلى بعيد
        /// </summary>
        private void rb_remote_CheckedChanged(object sender, EventArgs e)
        {
         
            if (rb_remote.Checked)
            {
                SetConnectionType();
            }
        }



        /// <summary>
        /// اختبار الاتصال بقاعدة البيانات
        /// </summary>
        //////private bool TestDatabaseConnection(string connectionString)
        //////    {

        //////        try
        //////        {
        //////            // إذا كانت السلسلة مشفرة، فك تشفيرها أولاً
        //////            string decryptedConnection;
        //////            try
        //////            {
        //////                decryptedConnection = AesEncryptionHelper.Decrypt(connectionString);
        //////            }
        //////            catch
        //////            {
        //////                // إذا فشل فك التشفير، افترض أنها غير مشفرة
        //////                decryptedConnection = connectionString;
        //////            }

        //////            var entityBuilder = new EntityConnectionStringBuilder(decryptedConnection);
        //////            var sqlConnectionString = entityBuilder.ProviderConnectionString;

        //////            using (var connection = new SqlConnection(sqlConnectionString))
        //////            {
        //////                connection.Open();
        //////                using (var cmd = new SqlCommand("SELECT @@SERVERNAME", connection))
        //////                {
        //////                    var result = cmd.ExecuteScalar();
        //////                    return result != null;
        //////                }
        //////            }
        //////        }
        //////        catch (Exception ex)
        //////        {
        //////            msg = $"سلسلة الاتصال المستخدمة: {connectionString}\n\n{ex.Message}";
        //////            return false;
        //////        }

        //////        //try
        //////        //{
        //////        //    var entityBuilder = new EntityConnectionStringBuilder(connectionString);
        //////        //    var sqlConnectionString = entityBuilder.ProviderConnectionString;

        //////        //    using (var connection = new SqlConnection(sqlConnectionString))
        //////        //    {
        //////        //        connection.Open();
        //////        //        using (var cmd = new SqlCommand("SELECT @@SERVERNAME", connection))
        //////        //        {
        //////        //            var result = cmd.ExecuteScalar();
        //////        //            return result != null;
        //////        //        }
        //////        //    }
        //////        //}
        //////        //catch (Exception ex)
        //////        //{
        //////        //    msg = $"سلسلة الاتصال المسنحدمة:{connectionString}\n\n{ ex.Message}";
        //////        //    return false;
        //////        //}


        //////    }


        //////private bool TestDatabaseConnection(string connectionString)
        //////{
        //////    try
        //////    {
        //////        // 1. الحصول على سلسلة اتصال مزود SQL
        //////        var providerConnectionString =
        //////            new EntityConnectionStringBuilder(connectionString).ProviderConnectionString;

        //////        // 2. إنشاء SqlConnectionStringBuilder (دون using)
        //////        var sqlBuilder = new SqlConnectionStringBuilder(providerConnectionString);

        //////        // 3. استخدام using مع SqlConnection فقط
        //////        using (var connection = new SqlConnection(sqlBuilder.ConnectionString))
        //////        {
        //////            connection.Open();
        //////            return true;
        //////        }
        //////    }
        //////    catch (Exception ex)
        //////    {
        //////        Debug.WriteLine($"تفاصيل الخطأ: {ex}");
        //////        throw new Exception($"فشل الاتصال: {ex.Message}");
        //////    }
        //////}

        /// <summary>
        /// اختبار الاتصال بقاعدة البيانات
        /// </summary>
        private bool TestDatabaseConnection(string connectionString)
        {

            try
            {
                var entityBuilder = new EntityConnectionStringBuilder(connectionString);
                var sqlConnectionString = entityBuilder.ProviderConnectionString;

                using (var connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT @@SERVERNAME", connection))
                    {
                        var result = cmd.ExecuteScalar();
                        return result != null;
                    }
                }
            }
            catch (Exception ex)
            {
                msg = $"سلسلة الاتصال المسنحدمة:{connectionString}\n\n{ex.Message}";
                return false;
            }


        }



        ////private void ShowError(string title, Exception ex)
        ////{
        ////    Debug.WriteLine($"{title}: {ex}");
        ////    XtraMessageBox.Show($"{title}\n{ex.Message}", "خطأ",
        ////        MessageBoxButtons.OK, MessageBoxIcon.Error);
        ////}
    


/// <summary>
/// بناء سلسلة الاتصال الجديدة
/// </summary>
private string BuildConnectionString()
        {

            //if (rb_local.Checked)
            //{
            //    return BuildLocalConnectionString();
            //}
            //else
            //{
            //    return BuildRemoteConnectionString();
            //}


            if (rb_local.Checked)
            {
                return BuildLocalConnectionString();
            }
            else
            {
                return BuildRemoteConnectionString();
            }




        }

        //الاتصال المحلي
        private string BuildLocalConnectionString()
        {
        ////    var sqlBuilder = new SqlConnectionStringBuilder
        ////    {
        ////        DataSource = edt_serverName.Text, // اسم السيرفر فقط
        ////        InitialCatalog = edt_DB.Text,     // اسم قاعدة البيانات
        ////        IntegratedSecurity = true         // استخدام مصادقة ويندوز
        ////    };

        ////    var entityBuilder = new EntityConnectionStringBuilder
        ////    {
        ////        Metadata = "res://*/Pages.DBEArchiveModel.csdl|res://*/Pages.DBEArchiveModel.ssdl|res://*/Pages.DBEArchiveModel.msl",
        ////        Provider = "System.Data.SqlClient",
        ////        ProviderConnectionString = sqlBuilder.ToString()
        ////    };

        ////    return entityBuilder.ToString();

            var sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = edt_serverName.Text, // اسم السيرفر فقط
                InitialCatalog = edt_DB.Text,     // اسم قاعدة البيانات
                IntegratedSecurity = true         // استخدام مصادقة ويندوز
            };

        var entityBuilder = new EntityConnectionStringBuilder
        {
            Metadata = "res://*/Pages.DBEArchiveModel.csdl|res://*/Pages.DBEArchiveModel.ssdl|res://*/Pages.DBEArchiveModel.msl",
            Provider = "System.Data.SqlClient",
            ProviderConnectionString = sqlBuilder.ToString()
        };

            return entityBuilder.ToString();

        }

    //الاتصال الشبكي
    private string BuildRemoteConnectionString()
        {
            ////var sqlBuilder = new SqlConnectionStringBuilder
            ////{
            ////    DataSource = !string.IsNullOrEmpty(edt_Port.Text)
            ////        ? $"{edt_serverName.Text},{edt_Port.Text}"  // اسم السيرفر + المنفذ
            ////        : edt_serverName.Text,
            ////    InitialCatalog = edt_DB.Text,     // اسم قاعدة البيانات
            ////    UserID = edt_username.Text,       // اسم المستخدم
            ////    Password = edt_password.Text,     // كلمة المرور
            ////    IntegratedSecurity = false       // استخدام مصادقة SQL
            ////};

            ////var entityBuilder = new EntityConnectionStringBuilder
            ////{
            ////    Metadata = "res://*/Pages.DBEArchiveModel.csdl|res://*/Pages.DBEArchiveModel.ssdl|res://*/Pages.DBEArchiveModel.msl",
            ////    Provider = "System.Data.SqlClient",
            ////    ProviderConnectionString = sqlBuilder.ToString()
            ////};

            ////return entityBuilder.ToString();

            ////////////////////        var sqlBuilder = new SqlConnectionStringBuilder
            ////////////////////        {

            ////////////////////            DataSource = !string.IsNullOrEmpty(edt_Port.Text)
            ////////////////////            ? $"{edt_serverName.Text},{edt_Port.Text}"
            ////////////////////            : edt_serverName.Text,
            ////////////////////    InitialCatalog = edt_DB.Text,
            ////////////////////    UserID = edt_username.Text,
            ////////////////////    Password = edt_password.Text,
            ////////////////////    IntegratedSecurity = false,
            ////////////////////    ConnectTimeout = 60, // تم إضافة هذا
            ////////////////////    MultipleActiveResultSets = true,
            ////////////////////    ApplicationName = "EntityFramework" // تم إضافة هذا
            ////////////////////};

            ////////////////////    var entityBuilder = new EntityConnectionStringBuilder
            ////////////////////    {
            ////////////////////        Metadata = "res://*/Pages.DBEArchiveModel.csdl|res://*/Pages.DBEArchiveModel.ssdl|res://*/Pages.DBEArchiveModel.msl",
            ////////////////////        Provider = "System.Data.SqlClient",
            ////////////////////        ProviderConnectionString = sqlBuilder.ToString()
            ////////////////////    };

            ////////////////////return entityBuilder.ToString();


            var sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = !string.IsNullOrEmpty(edt_Port.Text)
                    ? $"{edt_serverName.Text},{edt_Port.Text}"  // اسم السيرفر + المنفذ
                    : edt_serverName.Text,
                InitialCatalog = edt_DB.Text,     // اسم قاعدة البيانات
                UserID = edt_username.Text,       // اسم المستخدم
                Password = edt_password.Text,     // كلمة المرور
                IntegratedSecurity = false       // استخدام مصادقة SQL
            };

            var entityBuilder = new EntityConnectionStringBuilder
            {
                Metadata = "res://*/Pages.DBEArchiveModel.csdl|res://*/Pages.DBEArchiveModel.ssdl|res://*/Pages.DBEArchiveModel.msl",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sqlBuilder.ToString()
            };

            return entityBuilder.ToString();


        }


        /////////// <summary>
        /////////// تشفير سلسلة الاتصال في ملف الإعدادات
        /////////// </summary>
        ////////private void EncryptConnectionString()
        ////////{
        ////////    try
        ////////    {
        ////////        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        ////////        var section = config.GetSection("connectionStrings") as ConnectionStringsSection;

        ////////        if (!section.SectionInformation.IsProtected)
        ////////        {
        ////////            section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
        ////////            config.Save(ConfigurationSaveMode.Modified);
        ////////            ConfigurationManager.RefreshSection("connectionStrings");
        ////////        }
        ////////    }
        ////////    catch (Exception ex)
        ////////    {
        ////////        MessageBox.Show($"خطأ في تشفير سلسلة الاتصال: {ex.Message}",
        ////////                      "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        ////////    }
        ////////}

        /// <summary>
        /// حفظ إعدادات قاعدة البيانات
        /// </summary>


        private void SaveDatabaseSettings()
        {
            try
            {
                // ... (التحقق من الإدخالات)

                // التحقق من البيانات الأساسية
                if (string.IsNullOrWhiteSpace(edt_serverName.Text))
                {
                    MessageBox.Show("يجب إدخال اسم السيرفر", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(edt_DB.Text))
                {
                    MessageBox.Show("يجب إدخال اسم قاعدة البيانات", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string providerConnectionString;

                if (rb_local.Checked)
                {
                    // اتصال محلي (Windows Authentication)
                    providerConnectionString = $"data source={edt_serverName.Text};" +
                                              $"initial catalog={edt_DB.Text};" +
                                              "integrated security=True;" +
                                              "MultipleActiveResultSets=True;" +
                                              "App=EntityFramework";
                }
                else
                {
                    // اتصال شبكي (SQL Authentication)
                    if (string.IsNullOrWhiteSpace(edt_username.Text))
                    {
                        MessageBox.Show("يجب إدخال اسم المستخدم", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string portPart = string.IsNullOrEmpty(edt_Port.Text) ? "" : $",{edt_Port.Text}";

                    providerConnectionString = $"data source={edt_serverName.Text}{portPart};" +
                                              $"initial catalog={edt_DB.Text};" +
                                              $"user id={edt_username.Text};" +
                                              $"password={edt_password.Text};" +
                                              "MultipleActiveResultSets=True;" +
                                              "App=EntityFramework";
                }

                // بناء سلسلة الاتصال الكاملة
                string fullConnectionString = "metadata=res://*/Pages.DBEArchiveModel.csdl|" +
                                             "res://*/Pages.DBEArchiveModel.ssdl|" +
                                             "res://*/Pages.DBEArchiveModel.msl;" +
                                             "provider=System.Data.SqlClient;" +
                                             $"provider connection string=\"{providerConnectionString}\"";


                string connectionString = BuildConnectionString();

                // اختبار الاتصال
                if (!TestDatabaseConnection(connectionString))
                {
                    MessageBox.Show($"فشل الاتصال بقاعدة البيانات: {msg}",
                                  "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // حفظ السلسلة غير مشفرة في الإعدادات
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["DBEArchieEntity"].ConnectionString = connectionString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                // تشفير قسم connectionStrings
                Encrypteconstring();

                MessageBox.Show("تم الحفظ بنجاح - سيتم إعادة التشغيل", "نجاح",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حفظ الإعدادات: {ex.Message}",
                              "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        //////private void SaveDatabaseSettings()
        //////{
        //////   try
        //////    {
        //////        // التحقق من البيانات الأساسية
        //////        if (string.IsNullOrWhiteSpace(edt_serverName.Text))
        //////        {
        //////            MessageBox.Show("يجب إدخال اسم السيرفر", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //////            return;
        //////        }

        //////        if (string.IsNullOrWhiteSpace(edt_DB.Text))
        //////        {
        //////            MessageBox.Show("يجب إدخال اسم قاعدة البيانات", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //////            return;
        //////        }

        //////        string providerConnectionString;

        //////        if (rb_local.Checked)
        //////        {
        //////            // اتصال محلي (Windows Authentication)
        //////            providerConnectionString = $"data source={edt_serverName.Text};" +
        //////                                      $"initial catalog={edt_DB.Text};" +
        //////                                      "integrated security=True;" +
        //////                                      "MultipleActiveResultSets=True;" +
        //////                                      "App=EntityFramework";
        //////        }
        //////        else
        //////        {
        //////            // اتصال شبكي (SQL Authentication)
        //////            if (string.IsNullOrWhiteSpace(edt_username.Text))
        //////            {
        //////                MessageBox.Show("يجب إدخال اسم المستخدم", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //////                return;
        //////            }

        //////            string portPart = string.IsNullOrEmpty(edt_Port.Text) ? "" : $",{edt_Port.Text}";

        //////            providerConnectionString = $"data source={edt_serverName.Text}{portPart};" +
        //////                                      $"initial catalog={edt_DB.Text};" +
        //////                                      $"user id={edt_username.Text};" +
        //////                                      $"password={edt_password.Text};" +
        //////                                      "MultipleActiveResultSets=True;" +
        //////                                      "App=EntityFramework";
        //////        }

        //////        // بناء سلسلة الاتصال الكاملة
        //////        string fullConnectionString = "metadata=res://*/Pages.DBEArchiveModel.csdl|" +
        //////                                     "res://*/Pages.DBEArchiveModel.ssdl|" +
        //////                                     "res://*/Pages.DBEArchiveModel.msl;" +
        //////                                     "provider=System.Data.SqlClient;" +
        //////                                     $"provider connection string=\"{providerConnectionString}\"";

        //////        //////string connectionString = BuildConnectionString();
        //////        //////// اختبار الاتصال أولاً
        //////        //////if (!TestDatabaseConnection(fullConnectionString))
        //////        //////{
        //////        //////    MessageBox.Show($"فشل الاتصال بقاعدة البيانات. يرجى التحقق من الإعدادات\n{msg}",
        //////        //////                  "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //////        //////    return;
        //////        //////}

        //////        //////// حفظ الإعدادات في ملف التكوين
        //////        //////var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //////        //////config.ConnectionStrings.ConnectionStrings["DBEArchieEntity"].ConnectionString = fullConnectionString;
        //////        //////config.Save(ConfigurationSaveMode.Modified);
        //////        //////ConfigurationManager.RefreshSection("connectionStrings");
        //////        string connectionString = BuildConnectionString();


        //////        // اختبار الاتصال أولاً بالسلسلة غير المشفرة
        //////        ////if (!TestDatabaseConnection(connectionString))
        //////        ////{
        //////        ////    MessageBox.Show($"فشل الاتصال بقاعدة البيانات. يرجى التحقق من الإعدادات\n{msg}",
        //////        ////                  "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //////        ////    return;
        //////        ////}

        //////        ////// تشفير سلسلة الاتصال قبل الحفظ
        //////        ////string encryptedConnection = AesEncryptionHelper.Encrypt(connectionString);

        //////        ////// حفظ الإعدادات في ملف التكوين (مشفر)
        //////        ////var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //////        ////config.ConnectionStrings.ConnectionStrings["DBEArchieEntity"].ConnectionString = encryptedConnection;
        //////        ////config.Save(ConfigurationSaveMode.Modified);
        //////        ////ConfigurationManager.RefreshSection("connectionStrings");
        //////        // اختبار الاتصال أولاً
        //////        if (!TestDatabaseConnection(fullConnectionString))
        //////        {
        //////            MessageBox.Show($"فشل الاتصال بقاعدة البيانات: {msg}",
        //////                          "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //////            return;
        //////        }

        //////        // تشفير السلسلة قبل الحفظ
        //////    //    string encryptedConnection = AesEncryptionHelper.Encrypt(fullConnectionString);

        //////        // حفظ الإعدادات في ملف التكوين
        //////        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //////        config.ConnectionStrings.ConnectionStrings["DBEArchieEntity"].ConnectionString = connectionString;
        //////        config.Save(ConfigurationSaveMode.Modified);
        //////        ConfigurationManager.RefreshSection("connectionStrings");

        //////        // إعدادات إضافية
        //////        Properties.Settings.Default.ConnectionMode = rb_local.Checked ? "Local" : "Remote";
        //////        Properties.Settings.Default.Save();

        //////        MessageBox.Show("تم حفظ الإعدادات بنجاح وسيتم إعادة تشغيل التطبيق",
        //////                      "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //////        Application.Restart();
        //////    }
        //////    catch (Exception ex)
        //////    {
        //////        MessageBox.Show($"حدث خطأ أثناء حفظ الإعدادات: {ex.Message}",
        //////                      "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //////    }

        //////}

        #endregion

        #region النسخ الاحتياطي

        /// <summary>
        /// تنفيذ عملية النسخ الاحتياطي
        /// </summary>
        private bool PerformBackup(string backupPath)
        {
            try
            {
                using (var db = new DBEArchieEntity())
                {
                    string dbName = db.Database.Connection.Database;
                    string backupName = $"DBEArchie_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                    string fullPath = Path.Combine(backupPath, backupName);

                    string sql = $@"
                    BACKUP DATABASE [{dbName}] 
                    TO DISK = N'{fullPath}' 
                    WITH NOFORMAT, INIT, 
                    NAME = N'{dbName}-Full Backup', 
                    SKIP, NOREWIND, NOUNLOAD, STATS = 10";

                    db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في النسخ الاحتياطي: {ex.Message}",
                              "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// حدث النقر على زر النسخ الاحتياطي
        /// </summary>
        private async void btn_Backup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "اختر مجلد لحفظ النسخة الاحتياطية";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Loading.Visible = true;
                        bool result = await Task.Run(() => PerformBackup(fbd.SelectedPath));

                        MessageBox.Show(result ?
                            "تم إنشاء النسخة الاحتياطية بنجاح" :
                            "فشل في إنشاء النسخة الاحتياطية",
                            result ? "نجاح" : "خطأ",
                            MessageBoxButtons.OK,
                            result ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Loading.Visible = false;
                    }
                }
            }
        }

        #endregion

        #region أحداث الأزرار

        private void btn_save_Gen_Click(object sender, EventArgs e)
        {
            SaveCompanySettings();
        }

        private void btn_conString_Click(object sender, EventArgs e)
        {
            SaveDatabaseSettings();
            Encrypteconstring();
            ////try
            ////{
            ////    var connectionString = BuildConnectionString();

            ////    if (!TestDatabaseConnection(connectionString))
            ////        throw new Exception("فشل اختبار الاتصال");

            ////    SaveEncryptedConnection(connectionString);
            ////    XtraMessageBox.Show("تم الحفظ بنجاح - سيتم إعادة التشغيل");
            ////    Application.Restart();
            ////}
            ////catch (Exception ex)
            ////{
            ////    ShowError("فشل حفظ إعدادات الاتصال", ex);
            ////}


        }
        ////private void SaveEncryptedConnection(string connectionString)
        ////{
        ////    var encrypted = AesEncryptionHelper.Encrypt(connectionString);
        ////    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        ////    config.ConnectionStrings.ConnectionStrings["DBEArchieEntity"].ConnectionString = encrypted;
        ////    config.Save(ConfigurationSaveMode.Modified);
        ////    ConfigurationManager.RefreshSection("connectionStrings");
        ////}



        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void rb_local_CheckedChanged_1(object sender, EventArgs e)
        {
            SetConnectionType();
        }

        private void btn_save_Gen_Click_1(object sender, EventArgs e)
        {
            SaveCompanySettings();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(rb_local.Checked.ToString());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            MessageBox.Show(rb_remote.Checked.ToString());
        }
        private void Encrypteconstring()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ExeConfigurationFileMap configfileMap= new ExeConfigurationFileMap();

            configfileMap.ExeConfigFilename = config.FilePath;

            System.Configuration.Configuration myConfig = ConfigurationManager.OpenMappedExeConfiguration(configfileMap, ConfigurationUserLevel.None);

            ConnectionStringsSection section = myConfig.GetSection("connectionStrings") as ConnectionStringsSection;

        if (section.SectionInformation.IsProtected)

                // Remove encryption.

                section.SectionInformation.UnprotectSection();

            else

                // Encrypt the section.

                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

            myConfig.Save();

        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(start == 1)
            {
                Application.Exit();
            }
        }
    }
}

