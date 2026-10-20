using DevExpress.ClipboardSource.SpreadsheetML;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_Archive.AddPage
{
    /// <summary>
    /// نموذج لإضافة أو تعديل سجلات الأرشيف
    /// </summary>

    public partial class AddArchiveCat : DevExpress.XtraEditors.XtraForm
    {

        // متغيرات الاتصال بقاعدة البيانات
        private DBEArchieEntity db; // كائن Entity Framework للاتصال بالقاعدة
        TBArchiveCat tbadd; // كائن يمثل سجل الأرشيف

        // متغيرات التحكم
        public int id; // ID السجل (0 للإضافة، غير صفر للتعديل)
        public Pages.ArchiveCatPage page; // مرجع للصفحة الرئيسية لتحديث الشبكة
        bool state; // حالة العملية (نجاح/فشل)

        /// <summary>
        /// Initialize the form components
        /// </summary>

        public AddArchiveCat()
        {
            InitializeComponent();
        }

        /// <summary>
        /// حدث النقر على زر الحفظ (إضافة/تعديل)
        /// </summary>

        private async void btn_AddDep_Click_1(object sender, EventArgs e)
        {

            //// التحقق من إدال اسم السجل (حقل مطلوب)
            //if (string.IsNullOrWhiteSpace(txt_TitleCatName.Text))
            //{
            //    XtraMessageBox.Show("يجب إدخال اسم السجل", "تحذير",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_TitleCatName.Focus();
            //    return;
            //}


            //// إنشاء كائن السجل الجديد مع تعبئة البيانات
            //tbadd = new TBArchiveCat
            //{
            //    ArchiveTitle = txt_TitleCatName.Text, // عنوان السجل
            //    ArchiveDes = rtxt_details.Text, // الوصف
            //    UserName = Properties.Settings.Default.FullName, // اسم المستخدم الحالي
            //    UserDep = Properties.Settings.Default.UserDep, // القسم التابع له
            //    IDUser = Properties.Settings.Default.UserID // معرف المستخدم
            //};

            //// إذا كان عملية تعديل (ID > 0)
            //if (id > 0)
            //{
            //    tbadd.ID = id; // تعيين معرف السجل المعدل
            //}

            //// عرض مؤشر التحميل
            //Loading.Visible = true;

            //// تنفيذ العملية في thread منفصل لمنع تجميد الواجهة
            //var result = await Task.Run(() => AddOrEdit(tbadd));

            //// إخفاء مؤشر التحميل
            //Loading.Visible = false;

            //// إذا نجحت العملية
            //if (result)
            //{
            //    // تحديث البيانات في الصفحة الرئيسية إذا كانت متاحة
            //    if (page != null)
            //    {
            //        page.LoadData();
            //    }


            //    // عرض إشعار النجاح
            //    toastNotificationsManager1.ShowNotification("96b3f4ff-8dbc-4221-b131-4eba588d4ffa");
            //    Close(); // إغلاق النموذج
            //}
            //else
            //{
            //    // عرض رسالة الخطأ
            //    MessageBox.Show("تأكد من الاتصال في السيرفر لطفاً", "خطأ في الاتصال",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            // التحقق من إدخال اسم السجل (حقل مطلوب)
            if (string.IsNullOrWhiteSpace(txt_TitleCatName.Text))
            {
                XtraMessageBox.Show("ادخل اسم السجل", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // إنشاء كائن السجل الجديد مع تعبئة البيانات
            tbadd = new TBArchiveCat
            {
                ArchiveTitle = txt_TitleCatName.Text, // عنوان السجل
                ArchiveDes = rtxt_details.Text, // الوصف
                UserName = Properties.Settings.Default.FullName, // اسم المستخدم الحالي
                UserDep = Properties.Settings.Default.UserDep, // القسم التابع له
                IDUser = Properties.Settings.Default.UserID // معرف المستخدم
            };

            // إذا كان عملية تعديل (ID > 0)
            if (id > 0)
            {
                tbadd.ID = id; // تعيين معرف السجل المعدل
            }

            // عرض مؤشر التحميل
            Loading.Visible = true;

            try
            {
                // تنفيذ العملية في thread منفصل
                bool result = await Task.Run(() => AddOrEdit(tbadd));

                if (result)
                {       //    // تحديث البيانات في الصفحة الرئيسية إذا كانت متاحة
                    if (page != null)
                    {
                        page.LoadData();
                    }
                    // إغلاق النموذج مع نتيجة ناجحة
                    this.DialogResult = DialogResult.OK;
                    Close();
                    //    // عرض إشعار النجاح
                    //  toastNotificationsManager1.ShowNotification("23518c72-8f0c-4a8c-9a8b-a6484ca2c1bd");
                }
                else
                {
                    // عرض رسالة الخطأ
                    MessageBox.Show("تأكد من الاتصال في السيرفر لطفاً", "خطأ في الاتصال",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            finally
            {
                // إخفاء مؤشر التحميل
                Loading.Visible = false;
            }


        }


        /// <summary>
        /// دالة تنفذ عملية الإضافة أو التعديل في قاعدة البيانات ونظام الملفات
        /// </summary>
        /// <param name="Data">كائن السجل الماد حفظه</param>
        /// <returns>true إذا نجحت العملية</returns>
        private bool AddOrEdit(TBArchiveCat Data)
        {
            //try
            //{
            //    // استخدام using لضمان إغلاق اتصال قاعدة البيانات
            //    using (db = new DBEArchieEntity())
            //    {
            //        if (id == 0) // عملية إضافة
            //        {
            //            // إضافة السجل الجديد
            //            db.TBArchiveCats.Add(Data);
            //            db.SaveChanges();

            //            // إنشاء المجلد المادي بعد الحفظ في قاعدة البيانات
            //            try
            //            {
            //                FileManager.CreateArchiveCategoryFolder(Data.UserDep, Data.ArchiveTitle);
            //            }
            //            catch (Exception ex)
            //            {
            //                // التراجع عن الإضافة إذا فشل إنشاء المجلد
            //                db.TBArchiveCats.Remove(Data);
            //                db.SaveChanges();
            //                throw new Exception($"تم حفظ السجل ولكن فشل إنشاء المجلد: {ex.Message}");
            //            }
            //        }
            //        else // عملية تعديل
            //        {
            //            // جلب السجل الموجود
            //            var existing = db.TBArchiveCats.Find(Data.ID);
            //            if (existing != null)
            //            {
            //                string oldTitle = existing.ArchiveTitle;

            //                // إذا تغير العنوان، نعدل اسم المجلد
            //                if (oldTitle != Data.ArchiveTitle)
            //                {
            //                    FileManager.RenameArchiveCategoryFolder(
            //                        existing.UserDep,
            //                        oldTitle,
            //                        Data.ArchiveTitle
            //                    );
            //                }

            //                // تحديث بيانات السجل
            //                db.Entry(existing).CurrentValues.SetValues(Data);
            //                db.SaveChanges();
            //            }
            //        }
            //        return true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "خطأ أثناء الحفظ",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            try
            {
                // استخدام using لضمان إغلاق اتصال قاعدة البيانات
                using (db = new DBEArchieEntity())
                {
                    if (id == 0) // عملية إضافة
                    {
                        // إضافة السجل الجديد
                        db.TBArchiveCat.Add(Data);
                        db.SaveChanges();

                        // إنشاء المجلد المادي بعد الحفظ في قاعدة البيانات
                        FileManager.CreateArchiveCategoryFolder(Data.UserDep, Data.ArchiveTitle);
                    }
                    else // عملية تعديل
                    {
                        // جلب السجل الموجود
                        var existing = db.TBArchiveCat.Find(Data.ID);
                        if (existing != null)
                        {
                            // إذا تغير العنوان، نعدل اسم المجلد
                            if (existing.ArchiveTitle != Data.ArchiveTitle)
                            {
                                FileManager.RenameArchiveCategoryFolder(
                                    existing.UserDep,
                                    existing.ArchiveTitle,
                                    Data.ArchiveTitle
                                );
                            }

                            // تحديث بيانات السجل
                            db.Entry(existing).CurrentValues.SetValues(Data);
                            db.SaveChanges();
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                // عرض رسالة الخطأ مع التفاصيل الداخلية إن وجدت
                MessageBox.Show($"خطأ: {ex.InnerException?.Message ?? ex.Message}");
                return false;
            }
        }
    



private void AddArchiveCat_FormClosed(object sender, FormClosedEventArgs e)
        {
            page.LoadData();
        }
    }


}