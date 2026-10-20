using DevExpress.XtraSplashScreen;
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

namespace Electronic_Archive.PL
{
    public partial class StartForm : SplashScreen
    {

        TBUser tbadd;
        private int state;

        public StartForm()
        {
            InitializeComponent();
            this.labelCopyright.Text = "جميع الحقوق محفوظة © 2025-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
        private void CheckState()
        {
            DBEArchieEntity db;
            try
            {
                db = new DBEArchieEntity();
                var userid = db.TBUsers.Select(x => x.ID).FirstOrDefault();
                //Login in
                if (userid > 0)
                {
                    state = 1;
                }
                else
                {
                    // do not have any user in DB 
                    state = 2;
                }

            }
            catch { state = 3; }
        }

        private async void StartForm_Load(object sender, EventArgs e)
        {
            await Task.Run(() => CheckState());
          
            if(state == 1)
            {
                PL.LoginForm loginForm = new PL.LoginForm();
                loginForm.Show();
                Hide();
            }
            if (state == 2)
            {
                // Add Dep and User
                // start program
                AddPage.AddDep depPage = new AddPage.AddDep(0, this);
                depPage.start = 1;
                MessageBox.Show(" مرحباً بك في نظام الإرشيف الإلكتروني، الصفحة القادمة تمكنك من إضافة قسم لمباشرة العمل",
                          "بداية العمل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                depPage.Show();
                Hide();
            }
            if(state == 3)
            {
                // Set Server Con form Setting
            var rs = MessageBox.Show("اختر 'نعم'لإعادة الإتصال بقاعدة البيانات،'لا' لضبط الإتصال، 'إلغاء الأمر' لإغلق البرنامج",
                         "خطأ إتصال", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (rs == DialogResult.No)
                {
                    PL.SettingForm setting = new PL.SettingForm();
                    setting.start = 1;
                    setting.Show();
                    Hide();
                }
                else if(rs == DialogResult.Cancel) 
                {
                    Application.Exit();
                }
               
            }
        }
    }
}