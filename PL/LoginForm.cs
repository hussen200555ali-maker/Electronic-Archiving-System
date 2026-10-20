using DevExpress.XtraEditors;
using Electronic_Archive.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Electronic_Archive.PL
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        // متغيرات الفئة
        private DBEArchieEntity db; // كائن قاعدة البيانات
        private List<string> DeptNameList; // قائمة أسماء الأقسام
        private TBUser tbadd; // كائن مستخدم مؤقت
        public int id; // معرف المستخدم (0 للإضافة، غير صفر للتعديل)
        public int depid; // معرف القسم
        public Pages.UsersPage page; // صفحة عرض المستخدمين
        private bool state; // حالة العملية (نجاح/فشل)
                            // إضافة Label لعرض قوة كلمة المرور
        private LabelControl lblPasswordStrength;


        public LoginForm()
        {
            InitializeComponent();
        }


        private bool ValidateInputs()
        {
            if (
                string.IsNullOrWhiteSpace(edt_Username.Text) ||
                string.IsNullOrWhiteSpace(edt_Password.Text)
                )
            {
                MessageBox.Show("أكمل الحقول لطفاً", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private async void btn_AddUser_Click(object sender, EventArgs e)
        {
            // التحقق من الحقول المطلوبة
            if (!ValidateInputs())
            {
                return;
            }
            var username = edt_Username.Text;
            var password = edt_Password.Text;

            Loading.Visible = true;
            var result = await Task.Run(() => LoginCheck(username, password));
            Loading.Visible = false;

            if (result == true)
            {  // تحديث بيانات الصفحة الرئيسية إذا كانت موجودة
                if (page != null)
                {
                    page.LoadData();
                }
                // عرض إشعار النجاح
                Main main = new Main();
                // set User Data
                Properties.Settings.Default.UserID = tbadd.ID;

                Properties.Settings.Default.FullName = tbadd.FullName;
                Properties.Settings.Default.UserName = tbadd.UserName;
                Properties.Settings.Default.UserRole = tbadd.UserRole;
                Properties.Settings.Default.UserDep = tbadd.DeptName;
                Properties.Settings.Default.Save();
                if (tbadd.UserRole == "موظف")
                {
                    main.btn_users.Visible = false;
                    main.btn_Dep.Visible = false;
                }
                else if (tbadd.UserRole == "مدير قسم")
                {
                    main.btn_Dep.Visible = false;

                }
                main.Show();

                toastNotificationsManager1.ShowNotification("96b3f4ff-8dbc-4221-b131-4eba588d4ffa");
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                MessageBox.Show("خطأ في معلومات تسجيل الدخول", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // دالة الإضافة أو التعديل
        private bool LoginCheck(string userName, string Password)
        {

            using (db = new DBEArchieEntity())
            {
                try
                {
                    tbadd = db.TBUsers.Where(x => x.UserName == userName && x.Password == Password).FirstOrDefault();
                    if (tbadd != null)
                    {
                        state = true;
                    }
                    else { state = false; }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    state = false;
                }
                return state;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    
    }
}