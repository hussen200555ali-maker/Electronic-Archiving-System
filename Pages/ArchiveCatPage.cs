using DevExpress.Utils.Animation;
using DevExpress.XtraEditors;
using Electronic_Archive.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Linq;
using Electronic_Archive.AddPage;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using System.Runtime.Remoting.Contexts;
using DevExpress.Data.Helpers;


namespace Electronic_Archive.Pages
{
    /// <summary>
    /// الصفحة الرئيسية لإدارة وعرض سجلات الأرشيف
    /// </summary>

    public partial class ArchiveCatPage : DevExpress.XtraEditors.XtraUserControl
    {

        // متغيرات الاتصال بقاعدة البيانات
        private DBEArchieEntity db;
        TBArchiveCat TBACat;

        // متغيرات التحكم
        int id; // معرف السجل المحدد
        private bool state; // حالة العملية
        private string UserRole; // دور المستخدم الحالي
        private string UserDepName; // قسم المستخدم 
        private string UserName; // اسم المستخدم
        private bool isDeleting;

        /// <summary>
        /// Initialize the user control
        /// </summary>

        public ArchiveCatPage()
        {
            InitializeComponent();


            // جلب بيانات المستخدم من الإعدادات
            UserRole = Properties.Settings.Default.UserRole;
            UserDepName = Properties.Settings.Default.UserDep;
            UserName = Properties.Settings.Default.UserName;

            // تهيئة إعدادات العرض
            InitializeViewSettings();

            // تحميل البيانات الأولية
            LoadData();

        }
        /// <summary>
        /// تهيئة إعدادات TileView لعرض أفضل
        /// </summary>
        private void InitializeViewSettings()
        {
            // تعطيل التعديل المباشر في الشبكة
            tileView1.OptionsBehavior.Editable = false;

            // تعطيل المؤثرات البصرية لتحسين الأداء
          //ileView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.Never;

            // تعطيل عرض HTML في المجموعات
        //    tileView1.OptionsView.AllowHtmlDrawGroups = false;

            // ضبط ارتفاع العناصر تلقائياً
       //     tileView1.OptionsView.ItemAutoHeight = true;
        }



        /// <summary>
        /// تحميل بيانات السجلات حسب صلاحيات المستخدم
        /// </summary>
        //public void LoadData()
        //{
        //    // ربط الأحداث لمصدر البيانات
        //    this.entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
        //    this.entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;

        //    // تنشيط تحديث البيانات
        //    this.entityInstantFeedbackSource1.Refresh();
        //}

        ///// <summary>
        ///// حدث جلب البيانات حسب الصلاحيات
        ///// </summary>
        //private void entityInstantFeedbackSource1_GetQueryable(object sender, GetQueryableEventArgs e)
        //{
        //    var context = new DBEArchieEntity(); // إنشاء سياق جديد

        //    // تحديد البيانات المعروضة حسب صلاحيات المستخدم
        //    if (UserRole == "مدير")
        //    {
        //        e.QueryableSource = context.TBArchiveCats; // كل السجلات للمدير
        //    }
        //    else if (UserRole == "مدير قسم")
        //    {
        //        // سجلات القسم الخاص بمدير القسم فقط
        //        e.QueryableSource = context.TBArchiveCats.Where(x => x.UserDep == UserDepName);
        //    }
        //    else if(UserRole == "موظف")
        //    {
        //        var UserID = Properties.Settings.Default.UserID;
        //        // سجلات المستخدم العادي فقط
        //        e.QueryableSource = context.TBArchiveCats.Where(x => x.IDUser == UserID);
        //    }

        //    e.Tag = context; // حفظ السياق للتخلص منه لاحقاً
        //}

        ///// <summary>
        ///// حدث التخلص من اتصال قاعدة البيانات
        ///// </summary>
        //private void entityInstantFeedbackSource1_DismissQueryable(object sender, GetQueryableEventArgs e)
        //{
        //    ((DBEArchieEntity)e.Tag).Dispose(); // التخلص من السياق
        //}


        /// <summary>
        /// تحميل أو إعادة تحميل البيانات من المصدر
        /// </summary>
        public void LoadData()
        {
            // إعادة ربط مصدر البيانات للتأكد من التحديث
            entityInstantFeedbackSource1.GetQueryable -= entityInstantFeedbackSource1_GetQueryable;
            entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;

            // تنشيط تحديث البيانات
            entityInstantFeedbackSource1.Refresh();
            db = new DBEArchieEntity();
            var userId = Properties.Settings.Default.UserID;
            if (UserRole == "مدير")
            {
                // المدير يرى كل السجلات
                gridControl1.DataSource = db.TBArchiveCat.ToList();
            }
            else if (UserRole == "مدير قسم")
            {
                // مدير القسم يرى سجلات قسمه فقط
                gridControl1.DataSource = db.TBArchiveCat.ToList().Where(x => x.UserDep == UserDepName);
            }
            else
            {
                // الموظف العادي يرى سجلاته فقط
                gridControl1.DataSource = db.TBArchiveCat.ToList().Where(x => x.IDUser == userId);
            }

          

            gridControl1.RefreshDataSource();
        }

        /// <summary>
        /// حدث جلب البيانات حسب صلاحيات المستخدم
        /// </summary>
        private void entityInstantFeedbackSource1_GetQueryable(object sender, GetQueryableEventArgs e)
        {
            // إنشاء سياق جديد للبيانات
            var context = new DBEArchieEntity();
            var userId = Properties.Settings.Default.UserID;

            // تحديد البيانات حسب صلاحية المستخدم
            if (UserRole == "مدير")
            {
                // المدير يرى كل السجلات
                e.QueryableSource = context.TBArchiveCat;

            }
            else if (UserRole == "مدير قسم")
            {
                // مدير القسم يرى سجلات قسمه فقط
                e.QueryableSource = context.TBArchiveCat.Where(x => x.UserDep == UserDepName);
            }
            else
            {
                // الموظف العادي يرى سجلاته فقط
                e.QueryableSource = context.TBArchiveCat.Where(x => x.IDUser == userId);
            }

            // حفظ السياق للتخلص منه لاحقاً
            e.Tag = context;
        }

        /// <summary>
        /// حدث التخلص من اتصال قاعدة البيانات
        /// </summary>
        private void entityInstantFeedbackSource1_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            // التخلص من سياق البيانات لتحرير الموارد
            ((DBEArchieEntity)e.Tag).Dispose();
        }

        /// <summary>
        /// حدث النقر على زر الإضافة
        /// </summary>


        private void btn_Add_Click(object sender, EventArgs e)
        {

            // إنشاء نموذج الإضافة
            var addForm = new AddArchiveCat
            {
                btn_AddArchiveCat = { Text = "إضافة" }, // تعيين نص الزر
                id = 0, // 0 يعني عملية إضافة
                page = this // ربط الصفحة الرئيسية
            };

            // عند إغلاق النموذج، يتم تحديث البيانات تلقائياً
            addForm.FormClosed += (s, args) => ForceRefreshData();

            // عرض النموذج
            addForm.Show();


            //// إنشاء نافذة الإضافة
            //var addForm = new AddPage.AddArchiveCat
            //{
            //    btn_AddArchiveCat = { Text = "إضافة" }, // تعيين نص الزر
            //    id = 0, // 0 يعني عملية إضافة
            //    page = this // ربط الصفحة الرئيسية للتحديث
            //};
            //addForm.Show(); // عرض النافذة
        }

        /// <summary>
        /// حدث النقر على زر التعديل
        /// </summary>
        private void btn_edit_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    // جلب معرف السجل المحدد
            //    id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("ID"));

            //    if (id > 0) // إذا كان هناك سجل محدد
            //    {
            //        // إنشاء نافذة التعديل
            //        AddPage.AddArchiveCat add = new AddPage.AddArchiveCat();
            //        add.btn_AddArchiveCat.Text = "تعديل"; // تغيير نص الزر
            //        add.id = id; // تعيين معرف السجل

            //        // تعبئة الحقول ببيانات السجل المحدد
            //        add.txt_TitleCatName.Text = Convert.ToString(tileView1.GetFocusedRowCellValue("ArchiveTitle"));
            //        add.rtxt_details.Text = Convert.ToString(tileView1.GetFocusedRowCellValue("ArchiveDes"));
            //        add.page = this; // ربط الصفحة الرئيسية

            //        add.Show(); // عرض النافذة
            //    }
            //    else
            //    {
            //        MessageBox.Show("لا يوجد بيانات لتعديلها", "تنبية !!",
            //            MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "تنبية !!",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            try
            {
                // جلب ID السجل المحدد
                id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("ID"));

                if (id > 0) // إذا كان هناك سجل محدد
                {
                    // إنشاء نموذج التعديل
                    var editForm = new AddArchiveCat
                    {
                        btn_AddArchiveCat = { Text = "تعديل" }, // تغيير نص الزر
                        id = id, // تعيين ID السجل
                        page = this, // ربط الصفحة الرئيسية

                        // تعبئة الحقول ببيانات السجل المحدد
                        txt_TitleCatName = { Text = tileView1.GetFocusedRowCellValue("ArchiveTitle").ToString() },
                        rtxt_details = { Text = tileView1.GetFocusedRowCellValue("ArchiveDes").ToString() }
                    };

                    // عند إغلاق النموذج، يتم تحديث البيانات تلقائياً
                    editForm.FormClosed += (s, args) => ForceRefreshData();

                    // عرض النموذج
                    editForm.Show();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ: {ex.Message}");
            }

        }


        /// <summary>
        /// دالة التحديث القسري للبيانات
        /// </summary>
        public void ForceRefreshData()
        {
            try
            {
                // بدء عملية التحديث
                tileView1.BeginDataUpdate();

                // إعادة تحميل البيانات من المصدر
                entityInstantFeedbackSource1.Refresh();

                // إعادة رسم العناصر
                tileView1.RefreshData();
            }
            finally
            {
                // إنهاء عملية التحديث
                tileView1.EndDataUpdate();

                // إعادة حساب التخطيط
                tileView1.LayoutChanged();
            }
        }



        /// <summary>
        /// حدث النقر على زر الحذف
        /// </summary>
        private async void btn_delete_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    // جلب بيانات السجل المحدد
            //    int id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("ID"));
            //    string depName = Convert.ToString(tileView1.GetFocusedRowCellValue("UserDep"));
            //    string catName = Convert.ToString(tileView1.GetFocusedRowCellValue("ArchiveTitle"));

            //    if (id > 0) // إذا كان هناك سجل محدد
            //    {
            //        // طلب تأكيد الحذف
            //        if (XtraMessageBox.Show($"هل أنت متأكد من حذف الإضبارة '{catName}'؟", "تأكيد الحذف",
            //            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            Loading.Visible = true; // عرض مؤشر التحميل

            //            // حذف المجلد المادي أولاً
            //            try
            //            {
            //                FileManager.DeleteArchiveCategoryFolder(depName, catName);
            //            }
            //            catch (Exception ex)
            //            {
            //                XtraMessageBox.Show($"فشل حذف المجلد: {ex.Message}", "تحذير",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }

            //            // حذف السجل من قاعدة البيانات
            //            using (var db = new DBEArchieEntity())
            //            {
            //                var ArchiveCategory = db.TBArchiveCats.Find(id);
            //                if (ArchiveCategory != null)
            //                {
            //                    db.TBArchiveCats.Remove(ArchiveCategory);
            //                    db.SaveChanges();

            //                    // تحديث عرض البيانات
            //                    LoadData();

            //                    // عرض إشعار النجاح
            //                    toastNotificationsManager1.ShowNotification("e2b7a119-df41-4a5e-b21e-362c61bbf399");
            //                }
            //            }
            //            Loading.Visible = false; // إخفاء مؤشر التحميل
            //        }
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("الرجاء تحديد الإضبارة للحذف", "تحذير",
            //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show($"خطأ في الحذف: {ex.Message}", "خطأ",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //try
            //{
            //    // جلب بيانات السجل المحدد
            //    int id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("ID"));
            //    string depName = tileView1.GetFocusedRowCellValue("UserDep").ToString();
            //    string catName = tileView1.GetFocusedRowCellValue("ArchiveTitle").ToString();

            //    if (id > 0 && XtraMessageBox.Show($"هل أنت متأكد من حذف '{catName}'؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        // عرض مؤشر التحميل
            //        Loading.Visible = true;

            //        try
            //        {
            //            // حذف المجلد المادي أولاً
            //            FileManager.DeleteArchiveCategoryFolder(depName, catName);

            //            // حذف السجل من قاعدة البيانات
            //            using (var db = new DBEArchieEntity())
            //            {
            //                var item = db.TBArchiveCat.Find(id);
            //                if (item != null)
            //                {
            //                    db.TBArchiveCat.Remove(item);
            //                    db.SaveChanges();

            //                    // تحديث العرض
            //                    ForceRefreshData();
            //                }
            //            }
            //        }
            //        finally
            //        {
            //            // إخفاء مؤشر التحميل
            //            Loading.Visible = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show($"خطأ: {ex.Message}");
            //}


            if (isDeleting) return;

            var rowHandle = tileView1.FocusedRowHandle;
            if (rowHandle < 0) return;

            var id = Convert.ToInt32(tileView1.GetRowCellValue(rowHandle, "ID"));
            var depName = tileView1.GetRowCellValue(rowHandle, "UserDep").ToString();
            var catName = tileView1.GetRowCellValue(rowHandle, "ArchiveTitle").ToString();

            if (XtraMessageBox.Show($"هل أنت متأكد من حذف '{catName}' مع جميع محتوياته؟",
                "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            isDeleting = true;
            Loading.Visible = true;

            try
            {
                var success = await Task.Run(() => DeleteCategoryWithContents(id, depName, catName));

                if (success)
                {
                    LoadData();
                    toastNotificationsManager1.ShowNotification("96b3f4ff-8dbc-4221-b131-4eba588d4ffa");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"حدث خطأ أثناء الحذف: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isDeleting = false;
                Loading.Visible = false;
            }
        }

        private bool DeleteCategoryWithContents(int categoryId, string depName, string catName)
        {
            try
            {
                using (var db = new DBEArchieEntity())
                {
                    // حذف جميع الملفات والسجلات المرتبطة
                    var records = db.TBArchive1.Where(r => r.IDCategory == categoryId).ToList();
                    foreach (var record in records)
                    {
                        var files = db.ArchiveFiles.Where(f => f.IDArchive == record.ID).ToList();
                        foreach (var file in files)
                        {
                            FileHelper.DeleteFile(file.FileName + file.FileExtension);
                            db.ArchiveFiles.Remove(file);
                        }
                        db.TBArchive1.Remove(record);
                    }

                    // حذف الفئة الرئيسية
                    var category = db.TBArchiveCat.Find(categoryId);
                    if (category != null)
                    {
                        db.TBArchiveCat.Remove(category);
                    }

                    db.SaveChanges();

                    // حذف المجلد الفعلي
                    FileManager.DeleteArchiveCategoryFolder(depName, catName);
                    return true;
                }
            }
            catch
            {
                return false;
            }


        }



        /// <summary>
        /// حدث النقر على زر الطباعة
        /// </summary>




        private void btn_Print_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void tileView1_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            try
            {
                PL.ArchiveFilesForm archive = new PL.ArchiveFilesForm();

                id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("ID"));
                archive.lb_id.Text = id.ToString();
                archive.AchiveID = id;
                archive.lb_ArchiveName.Text = tileView1.GetFocusedRowCellValue("ArchiveTitle").ToString();
                archive.lb_Dep.Text = tileView1.GetFocusedRowCellValue("UserDep").ToString();
                archive.Show();

            }
            catch { }
        }
    }
}

