using System;
using System.IO;

namespace Electronic_Archive.Helpers
{
    /// <summary>
    /// فئة مسؤولة عن إدارة عمليات إنشاء وتعديل وحذف المجلدات الخاصة بالأقسام والسجلات
    /// </summary>
    public static class FileManager
    {

        // المسار الأساسي لمجلد الأرشيف الإلكتروني (يتم إنشاؤه في نفس مكان تنفيذ التطبيق)
        private static readonly string BaseArchivePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "الارشيف الالكتروني");

        #region دوال إدارة مجلدات الأقسام

        /// <summary>
        /// إنشاء مجلد جديد للقسم
        /// </summary>
        /// <param name="folderName">اسم المجلد الجديد</param>
        /// <returns>true إذا تمت العملية بنجاح، false إذا فشلت</returns>
        public static bool CreateDepartmentFolder(string folderName)
        {
            try
            {
                // التأكد من وجود المجلد الرئيسي أولاً
                EnsureBaseDirectoryExists();

                // إنشاء المسار الكامل للمجلد الجديد
                string departmentPath = Path.Combine(BaseArchivePath, folderName);

                // إنشاء المجلد فقط إذا لم يكن موجوداً
                if (!Directory.Exists(departmentPath))
                {
                    Directory.CreateDirectory(departmentPath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // تسجيل الخطأ في ملف السجلات
                LogError(ex);
                return false;
            }
        }

        /// <summary>
        /// إعادة تسمية مجلد قسم موجود
        /// </summary>
        /// <param name="oldName">الاسم الحالي للمجلد</param>
        /// <param name="newName">الاسم الجديد للمجلد</param>
        /// <returns>true إذا تمت العملية بنجاح</returns>
        public static bool RenameDepartmentFolder(string oldName, string newName)
        {
            try
            {
                // تحديد المسارين القديم والجديد
                string oldPath = Path.Combine(BaseArchivePath, oldName);
                string newPath = Path.Combine(BaseArchivePath, newName);

                // التنفيذ فقط إذا كان المجلد القديم موجوداً والجديد غير موجود
                if (Directory.Exists(oldPath) && !Directory.Exists(newPath))
                {
                    Directory.Move(oldPath, newPath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        /// <summary>
        /// حذف مجلد قسم مع محتوياته
        /// </summary>
        /// <param name="folderName">اسم المجلد المراد حذفه</param>
        /// <returns>true إذا تم الحذف بنجاح</returns>
        public static bool DeleteDepartmentFolder(string folderName)
        {
            try
            {
                string folderPath = Path.Combine(BaseArchivePath, folderName);
                if (Directory.Exists(folderPath))
                {
                    // الحذف مع جميع المحتويات الداخلية (recursive)
                    Directory.Delete(folderPath, true);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }
        #endregion

        #region دوال إدارة مجلدات السجلات

        /// <summary>
        /// إنشاء مجلد سجل جديد داخل قسم محدد
        /// </summary>
        /// <param name="departmentName">اسم القسم</param>
        /// <param name="categoryName">اسم السجل/المجلد الجديد</param>
        /// <returns>true إذا تم الإنشاء بنجاح</returns>
        public static bool CreateArchiveCategoryFolder(string departmentName, string categoryName)
        {
            try
            {
                // التأكد من وجود المجلد الرئيسي
                EnsureBaseDirectoryExists();

                // إنشاء المسار الكامل للسجل (القسم/السجل)
                string fullPath = Path.Combine(BaseArchivePath, departmentName, categoryName);

                // الإنشاء فقط إذا لم يكن المجلد موجوداً
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw new Exception($"فشل إنشاء مجلد السجل: {ex.Message}");
            }
        }

        /// <summary>
        /// إعادة تسمية مجلد سجل موجود
        /// </summary>
        /// <param name="departmentName">اسم القسم</param>
        /// <param name="oldCategoryName">الاسم الحالي للسجل</param>
        /// <param name="newCategoryName">الاسم الجديد للسجل</param>
        /// <returns>true إذا نجحت العملية</returns>
        public static bool RenameArchiveCategoryFolder(string departmentName, string oldCategoryName, string newCategoryName)
        {
            try
            {
                // تحديد المسارين القديم والجديد
                string oldPath = Path.Combine(BaseArchivePath, departmentName, oldCategoryName);
                string newPath = Path.Combine(BaseArchivePath, departmentName, newCategoryName);

                // التنفيذ فقط إذا كان المجلد القديم موجوداً
                if (Directory.Exists(oldPath))
                {
                    Directory.Move(oldPath, newPath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw new Exception($"فشل تعديل اسم مجلد السجل: {ex.Message}");
            }
        }

        /// <summary>
        /// حذف مجلد سجل مع محتوياته
        /// </summary>
        /// <param name="departmentName">اسم القسم</param>
        /// <param name="categoryName">اسم السجل المراد حذفه</param>
        /// <returns>true إذا تم الحذف بنجاح</returns>
        public static bool DeleteArchiveCategoryFolder(string departmentName, string categoryName)
        {
            try
            {
                string fullPath = Path.Combine(BaseArchivePath, departmentName, categoryName);

                if (Directory.Exists(fullPath))
                {
                    // الحذف مع جميع المحتويات (recursive)
                    Directory.Delete(fullPath, true);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw new Exception($"فشل حذف مجلد السجل: {ex.Message}");
            }
        }
        #endregion

        #region دوال مساعدة

        /// <summary>
        /// التأكد من وجود المجلد الرئيسي للأرشيف
        /// </summary>
        private static void EnsureBaseDirectoryExists()
        {
            if (!Directory.Exists(BaseArchivePath))
            {
                Directory.CreateDirectory(BaseArchivePath);
            }
        }

        /// <summary>
        /// تسجيل الأخطاء في ملف log
        /// </summary>
        /// <param name="ex">الاستثناء الذي حدث</param>
        private static void LogError(Exception ex)
        {
            try
            {
                EnsureBaseDirectoryExists();
                string logPath = Path.Combine(BaseArchivePath, "error_log.txt");
                // إضافة الخطأ مع تاريخه وتفاصيله
                File.AppendAllText(logPath, $"[{DateTime.Now}] Error: {ex.Message}\n{ex.StackTrace}\n\n");
            }
            catch
            {
                // تجاهل الأخطاء أثناء تسجيل الأخطاء لتجنب التكرار
            }
        }
        #endregion

        /// <summary>
        /// فئة مسؤولة عن إدارة مجلدات الأرشيف الإلكتروني وإنشاء وتعديل وحذف المجلدات الخاصة بالسجلات
        /// </summary>
        public static class FileManager1
        {
            // المسار الأساسي لمجلد الأرشيف الإلكتروني (يتم إنشاؤه في مجلد التطبيق)
            private static readonly string BaseArchivePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "الارشيف الالكتروني");

            #region دوال إدارة مجلدات السجلات

            /// <summary>
            /// إنشاء مجلد جديد للسجل داخل قسم معين
            /// </summary>
            /// <param name="departmentName">اسم القسم</param>
            /// <param name="recordTitle">عنوان السجل/المجلد الجديد</param>
            /// <returns>true إذا تمت العملية بنجاح، false إذا فشلت أو كان المجلد موجوداً</returns>
            /// <exception cref="Exception">يتم رمي استثناء عند حدوث خطأ مع رسالة توضيحية</exception>
            public static bool CreateArchiveCategoryFolder(string departmentName, string recordTitle)
            {
                try
                {
                    // التأكد من وجود المجلد الرئيسي أولاً
                    EnsureBaseDirectoryExists();

                    // إنشاء المسار الكامل للمجلد الجديد (الارشيف الالكتروني/اسم القسم/عنوان السجل)
                    string fullPath = Path.Combine(BaseArchivePath, departmentName, recordTitle);

                    // إنشاء المجلد فقط إذا لم يكن موجوداً
                    if (!Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(fullPath);
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    // تسجيل الخطأ في ملف السجلات
                    LogError(ex);
                    throw new Exception($"فشل إنشاء مجلد السجل: {ex.Message}");
                }
            }

            /// <summary>
            /// إعادة تسمية مجلد سجل موجود داخل قسم معين
            /// </summary>
            /// <param name="departmentName">اسم القسم</param>
            /// <param name="oldTitle">الاسم الحالي للسجل</param>
            /// <param name="newTitle">الاسم الجديد للسجل</param>
            /// <returns>true إذا تمت العملية بنجاح، false إذا فشلت أو لم يكن المجلد موجوداً</returns>
            /// <exception cref="Exception">يتم رمي استثناء عند حدوث خطأ مع رسالة توضيحية</exception>
            public static bool RenameArchiveCategoryFolder(string departmentName, string oldTitle, string newTitle)
            {
                try
                {
                    // تحديد المسار القديم والجديد للمجلد
                    string oldPath = Path.Combine(BaseArchivePath, departmentName, oldTitle);
                    string newPath = Path.Combine(BaseArchivePath, departmentName, newTitle);

                    // إعادة التسمية فقط إذا كان المجلد القديم موجوداً
                    if (Directory.Exists(oldPath))
                    {
                        Directory.Move(oldPath, newPath);
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    throw new Exception($"فشل تعديل اسم مجلد السجل: {ex.Message}");
                }
            }

            /// <summary>
            /// حذف مجلد سجل مع جميع محتوياته
            /// </summary>
            /// <param name="departmentName">اسم القسم</param>
            /// <param name="recordTitle">عنوان السجل المراد حذفه</param>
            /// <returns>true إذا تمت العملية بنجاح، false إذا فشلت أو لم يكن المجلد موجوداً</returns>
            /// <exception cref="Exception">يتم رمي استثناء عند حدوث خطأ مع رسالة توضيحية</exception>
            public static bool DeleteArchiveCategoryFolder(string departmentName, string recordTitle)
            {
                try
                {
                    // تحديد المسار الكامل للمجلد المراد حذفه
                    string fullPath = Path.Combine(BaseArchivePath, departmentName, recordTitle);

                    // الحذف فقط إذا كان المجلد موجوداً
                    if (Directory.Exists(fullPath))
                    {
                        // الحذف مع جميع المحتويات والمجلدات الفرعية (recursive)
                        Directory.Delete(fullPath, true);
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    throw new Exception($"فشل حذف مجلد السجل: {ex.Message}");
                }
            }

            #endregion

            #region دوال مساعدة

            /// <summary>
            /// التأكد من وجود المجلد الرئيسي للأرشيف الإلكتروني
            /// </summary>
            private static void EnsureBaseDirectoryExists()
            {
                if (!Directory.Exists(BaseArchivePath))
                {
                    Directory.CreateDirectory(BaseArchivePath);
                }
            }

            /// <summary>
            /// تسجيل الأخطاء في ملف log داخل مجلد الأرشيف
            /// </summary>
            /// <param name="ex">الاستثناء الذي حدث</param>
            private static void LogError(Exception ex)
            {
                try
                {
                    // التأكد من وجود المجلد الرئيسي أولاً
                    EnsureBaseDirectoryExists();

                    // مسار ملف السجلات
                    string logPath = Path.Combine(BaseArchivePath, "error_log.txt");

                    // نص السجل يحتوي على التاريخ والوقت ورسالة الخطأ وتفاصيله
                    string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error: {ex.Message}\n{ex.StackTrace}\n\n";

                    // إضافة السجل إلى الملف
                    File.AppendAllText(logPath, logMessage);
                }
                catch
                {
                    // تجاهل الأخطاء أثناء تسجيل الأخطاء لتجنب التكرار
                }
            }

            #endregion

            #region دوال إضافية قد تكون مفيدة

            /// <summary>
            /// الحصول على المسار الكامل لمجلد سجل معين
            /// </summary>
            /// <param name="departmentName">اسم القسم</param>
            /// <param name="recordTitle">عنوان السجل</param>
            /// <returns>المسار الكامل للمجلد</returns>
            public static string GetArchiveFolderPath(string departmentName, string recordTitle)
            {
                return Path.Combine(BaseArchivePath, departmentName, recordTitle);
            }

            /// <summary>
            /// التحقق من وجود مجلد سجل معين
            /// </summary>
            /// <param name="departmentName">اسم القسم</param>
            /// <param name="recordTitle">عنوان السجل</param>
            /// <returns>true إذا كان المجلد موجوداً، false إذا لم يكن موجوداً</returns>
            public static bool ArchiveFolderExists(string departmentName, string recordTitle)
            {
                string fullPath = Path.Combine(BaseArchivePath, departmentName, recordTitle);
                return Directory.Exists(fullPath);
            }

            /// <summary>
            /// نسخ ملف إلى مجلد السجل المحدد
            /// </summary>
            /// <param name="departmentName">اسم القسم</param>
            /// <param name="recordTitle">عنوان السجل</param>
            /// <param name="sourceFilePath">مسار الملف المراد نسخه</param>
            /// <returns>true إذا تمت العملية بنجاح</returns>
            public static bool CopyFileToArchiveFolder(string departmentName, string recordTitle, string sourceFilePath)
            {
                try
                {
                    string destFolder = GetArchiveFolderPath(departmentName, recordTitle);
                    string destFilePath = Path.Combine(destFolder, Path.GetFileName(sourceFilePath));

                    // التأكد من وجود مجلد السجل أولاً
                    if (!Directory.Exists(destFolder))
                    {
                        Directory.CreateDirectory(destFolder);
                    }

                    File.Copy(sourceFilePath, destFilePath, true);
                    return true;
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    return false;
                }
            }

            #endregion
        }
    }
}

