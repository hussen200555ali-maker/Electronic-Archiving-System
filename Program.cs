using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Electronic_Archive
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { // 1. تهيئة إعدادات الواجهة الأساسية
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 2. إعدادات DPI للشاشات عالية الدقة
            //  Application.SetHighDpiMode(HighDpiMode.SystemAware);

            //// 3. ضبط الخط الافتراضي لعناصر DevExpress (إذا كنت تستخدمها)
            //DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Cairo", 9.75F);

            // 4. تهيئة النموذج الرئيسي مع إعدادات الحجم
            var mainForm = new Main();
            mainForm.Size = new Size(1200, 800);
            mainForm.StartPosition = FormStartPosition.CenterScreen;

            // 5. تشغيل النموذج الأولي (StartForm)
            Application.Run(new PL.StartForm());
        }
    }
}
