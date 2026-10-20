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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace Electronic_Archive.AddPage
{
    public partial class AddUser : DevExpress.XtraEditors.XtraForm
    {

        //// قاعدة البيانات والجدول
        //DBEArchieEntity db;
        //private List<string> DeptNameList;
        //TBUser tbadd;
        //// متغيرات أخرى
        //public int id;
        //public int depid; // رقم القسم، لا يمكن أن يكون null لأن نوعه int
        //public Pages.UsersPage page;
        //bool state;

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
        string userDep = Properties.Settings.Default.UserDep;
        string userRole = "موظف";
        string RoleUser = Properties.Settings.Default.UserRole;
        public int start;

        public AddUser()
        {
            InitializeComponent();

            // إنشاء وإعداد Label لعرض قوة كلمة المرور
            lblPasswordStrength = new LabelControl
            {
                Location = new Point(edt_Password.Location.X, edt_Password.Location.Y + edt_Password.Height + 5),
                AutoSizeMode = LabelAutoSizeMode.Vertical,
                Width = edt_Password.Width
            };
            this.Controls.Add(lblPasswordStrength);

            // إعداد حدث تغير كلمة المرور
            edt_Password.EditValueChanged += (s, e) => CheckPasswordStrength();
        }


    


    private bool ValidateInputs()
        { 
            if (RoleUser == "مدير")
            {
                if (string.IsNullOrWhiteSpace(edt_Fullname.Text) ||
                string.IsNullOrWhiteSpace(edt_Username.Text) ||
                string.IsNullOrWhiteSpace(edt_Password.Text) ||
                edt_Dept.SelectedItem == null ||
                edt_role.SelectedItem == null ||
                depid == 0)
                {
                    MessageBox.Show("خطأ إدخال", "أكمل الحقول لطفاً", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else if(RoleUser =="مدير قيم")
            {
                if (string.IsNullOrWhiteSpace(edt_Fullname.Text) ||
                string.IsNullOrWhiteSpace(edt_Username.Text) ||
                string.IsNullOrWhiteSpace(edt_Password.Text) ||
               
                depid == 0)
                {
                    MessageBox.Show("خطأ إدخال", "أكمل الحقول لطفاً", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (edt_Password.Text.Length < 8)
            {
                XtraMessageBox.Show("كلمة المرور يجب أن تحتوي على الأقل على 8 أحرف/أرقام",
                                   "كلمة مرور قصيرة",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CheckPasswordStrength()
        {
            if (string.IsNullOrEmpty(edt_Password.Text))
            {
                lblPasswordStrength.Text = "قوة كلمة المرور: غير محددة";
                lblPasswordStrength.Appearance.ForeColor = Color.Gray;
                return;
            }

            var strength = GetPasswordStrength(edt_Password.Text);
            string advice = GetPasswordAdvice(strength);

            lblPasswordStrength.Text = $"قوة كلمة المرور: {strength} - {advice}";
            lblPasswordStrength.Appearance.ForeColor = GetStrengthColor(strength);
        }

        private string GetPasswordStrength(string password)
        {
            if (password.Length < 8) return "ضعيفة جداً";

            int score = 0;

            // زيادة النقاط بناء على تنوع المحارف
            if (Regex.IsMatch(password, @"[\u0600-\u06FF]")) score++; // أحرف عربية
            if (Regex.IsMatch(password, @"[a-z]")) score++; // أحرف لاتينية صغيرة
            if (Regex.IsMatch(password, @"[A-Z]")) score++; // أحرف لاتينية كبيرة
            if (Regex.IsMatch(password, @"[0-9]")) score++; // أرقام
            if (Regex.IsMatch(password, @"[^a-zA-Z0-9\u0600-\u06FF]")) score++; // رموز خاصة

            // تقييم بناء على النقاط باستخدام if-else بدلاً من switch للتجنب CS8370
            if (score == 1) return "ضعيفة";
            if (score == 2) return "متوسطة";
            if (score == 3) return "جيدة";
            if (score == 4) return "قوية";
            if (score >= 5) return "قوية جداً";
            return "ضعيفة";
        }

        private string GetPasswordAdvice(string strength)
        {
            // استخدام if-else بدلاً من switch pattern
            if (strength == "ضعيفة جداً") return "يجب أن تحتوي على الأقل على 8 أحرف/أرقام";
            if (strength == "ضعيفة") return "أضف أحرفاً كبيرة أو أرقاماً أو رموزاً لزيادة القوة";
            if (strength == "متوسطة") return "جيدة ولكن يمكن تحسينها بإضافة المزيد من التنوع";
            if (strength == "جيدة") return "جيدة جداً، يمكنك جعلها أقوى بإضافة رموز خاصة";
            if (strength == "قوية") return "ممتازة! هذه كلمة مرور آمنة";
            if (strength == "قوية جداً") return "رائعة! هذه كلمة مرور مثالية";
            return "أضف المزيد من التنوع لزيادة الأمان";
        }

        private Color GetStrengthColor(string strength)
        {
            // استخدام if-else بدلاً من switch pattern
            if (strength == "ضعيفة جداً") return Color.Red;
            if (strength == "ضعيفة") return Color.OrangeRed;
            if (strength == "متوسطة") return Color.Orange;
            if (strength == "جيدة") return Color.Green;
            if (strength == "قوية") return Color.DarkGreen;
            if (strength == "قوية جداً") return Color.Blue;
            return Color.Gray;
        }





        private async void btn_AddUser_Click(object sender, EventArgs e)
        {
            // التحقق من الحقول المطلوبة
            if (!ValidateInputs())
            {
                return;
            }
            if (RoleUser == "مدير"|| start ==1)
            {
                // إنشاء كائن المستخدم الجديد أو التعديل على مستخدم موجود
                if (id == 0)
                {
                    tbadd = new TBUser
                    {
                        IDDep = depid,
                        FullName = edt_Fullname.Text,
                        UserName = edt_Username.Text,
                        Password = edt_Password.Text,
                        UserRole = edt_role.SelectedItem.ToString(),
                        DeptName = edt_Dept.SelectedItem.ToString()
                    };
                }
                else
                {
                    tbadd = new TBUser
                    {
                        ID = id,
                        IDDep = depid,
                        FullName = edt_Fullname.Text,
                        UserName = edt_Username.Text,
                        Password = edt_Password.Text,
                        UserRole = edt_role.SelectedItem.ToString(),
                        DeptName = edt_Dept.SelectedItem.ToString()
                    };
                }
            }
            else if(RoleUser =="مدير قسم")
            {
                if (id == 0)
                {
                    tbadd = new TBUser
                    {
                        IDDep = depid,
                        FullName = edt_Fullname.Text,
                        UserName = edt_Username.Text,
                        Password = edt_Password.Text,
                        UserRole = userRole,
                        DeptName = userDep
                    };
                }
                else
                {
                    tbadd = new TBUser
                    {
                        ID = id,
                        IDDep = depid,
                        FullName = edt_Fullname.Text,
                        UserName = edt_Username.Text,
                        Password = edt_Password.Text,
                        UserRole = userRole,
                        DeptName = userDep
                    };
                }
            }
            Loading.Visible = true;
            var result = await Task.Run(() => AddOrEdit(tbadd));
            Loading.Visible = false;

            if (result == true)
            {  // تحديث بيانات الصفحة الرئيسية إذا كانت موجودة
                if (page != null)
                {
                    page.LoadData();
                }
                // عرض إشعار النجاح
                toastNotificationsManager1.ShowNotification("96b3f4ff-8dbc-4221-b131-4eba588d4ffa");
                this.DialogResult = DialogResult.OK;
             if(start ==1)
                {
                    Application.Restart();                }
                this.Close();
            }
            else
            {
               // MessageBox.Show("تأكد من الاتصال في السيرفر لطفاً", "خطأ في الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        // دالة الإضافة أو التعديل
        private bool AddOrEdit(TBUser Data)
        {
            using (db = new DBEArchieEntity())
            {
                try
                {
                    if (id == 0)
                    {
                        if (db.TBUsers.Any(u => u.UserName == Data.UserName))
                        {
                            XtraMessageBox.Show("اسم المستخدم موجود مسبقاً، الرجاء اختيار اسم آخر",
                                             "اسم مستخدم مكرر",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);
                            return false;
                        }
                        db.TBUsers.Add(Data);
                    }
                    else
                    {
                        var currentUser = db.TBUsers.Find(id);
                        if (currentUser == null) return false;

                        if (currentUser.UserName != Data.UserName &&
                            db.TBUsers.Any(u => u.UserName == Data.UserName && u.ID != id))
                        {
                            XtraMessageBox.Show("اسم المستخدم الجديد موجود مسبقاً",
                                             "اسم مستخدم مكرر",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);
                            return false;
                        }

                        currentUser.FullName = Data.FullName;
                        currentUser.UserName = Data.UserName;
                        currentUser.Password = Data.Password;
                        currentUser.UserRole = Data.UserRole;
                        currentUser.IDDep = Data.IDDep;
                        currentUser.DeptName = Data.DeptName;
                    }

                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            //////// استخدام using لضمان التخلص من اتصال قاعدة البيانات بعد الانتهاء
            //////using (db = new DBEArchieEntity())
            //////{
            //////    try
            //////    {
            //////        // حالة الإضافة (id == 0)
            //////        if (id == 0)
            //////        {
            //////            // التحقق من وجود اسم مستخدم مكرر
            //////            if (db.TBUsers.Any(u => u.UserName == Data.UserName))
            //////            {
            //////                MessageBox.Show("اسم المستخدم موجود مسبقاً، الرجاء اختيار اسم آخر",
            //////                              "اسم مستخدم مكرر",
            //////                              MessageBoxButtons.OK,
            //////                              MessageBoxIcon.Warning);
            //////                return false;
            //////            }

            //////            // إضافة المستخدم الجديد
            //////            db.TBUsers.Add(Data);
            //////        }
            //////        // حالة التعديل
            //////        else
            //////        {
            //////            // البحث عن المستخدم الحالي
            //////            var currentUser = db.TBUsers.Find(id);
            //////            if (currentUser == null)
            //////            {
            //////                MessageBox.Show("المستخدم غير موجود",
            //////                              "خطأ",
            //////                              MessageBoxButtons.OK,
            //////                              MessageBoxIcon.Error);
            //////                return false;
            //////            }

            //////            // إذا كان المستخدم يغير اسمه لاسم موجود عند مستخدم آخر
            //////            if (currentUser.UserName != Data.UserName &&
            //////                db.TBUsers.Any(u => u.UserName == Data.UserName && u.ID != id))
            //////            {
            //////                MessageBox.Show("اسم المستخدم الجديد موجود مسبقاً، الرجاء اختيار اسم آخر",
            //////                              "اسم مستخدم مكرر",
            //////                              MessageBoxButtons.OK,
            //////                              MessageBoxIcon.Warning);
            //////                return false;
            //////            }

            //////            // تحديث بيانات المستخدم الحالي
            //////            currentUser.FullName = Data.FullName;
            //////            currentUser.UserName = Data.UserName;
            //////            currentUser.Password = Data.Password;
            //////            currentUser.UserRole = Data.UserRole;
            //////            currentUser.IDDep = Data.IDDep;
            //////            currentUser.DeptName = Data.DeptName;
            //////        }

            //////        // حفظ التغييرات في قاعدة البيانات
            //////        db.SaveChanges();
            //////        return true;
            //////    }
            //////    catch (Exception ex)
            //////    {
            //////        // عرض رسالة الخطأ مع التفاصيل
            //////        MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}",
            //////                      "خطأ",
            //////                      MessageBoxButtons.OK,
            //////                      MessageBoxIcon.Error);
            //////        return false;
            //////    }
            //////}


            //using (db = new DBEArchieEntity())
            //{
            //    try
            //    {
            //        // حالة الإضافة (id == 0)
            //        if (id == 0)
            //        {
            //            // التحقق من وجود اسم مستخدم مكرر
            //            if (db.TBUsers.Any(u => u.UserName == Data.UserName))
            //            {
            //                MessageBox.Show("اسم المستخدم موجود مسبقاً، الرجاء اختيار اسم آخر",
            //                              "اسم مستخدم مكرر",
            //                              MessageBoxButtons.OK,
            //                              MessageBoxIcon.Warning);
            //                return false;
            //            }

            //            db.TBUsers.Add(Data);
            //        }
            //        // حالة التعديل
            //        else
            //        {
            //            var currentUser = db.TBUsers.Find(id);
            //            if (currentUser == null)
            //            {
            //                MessageBox.Show("المستخدم غير موجود",
            //                              "خطأ",
            //                              MessageBoxButtons.OK,
            //                              MessageBoxIcon.Error);
            //                return false;
            //            }

            //            // إذا كان المستخدم يغير اسمه لاسم موجود عند مستخدم آخر
            //            if (currentUser.UserName != Data.UserName &&
            //                db.TBUsers.Any(u => u.UserName == Data.UserName && u.ID != id))
            //            {
            //                MessageBox.Show("اسم المستخدم الجديد موجود مسبقاً، الرجاء اختيار اسم آخر",
            //                              "اسم مستخدم مكرر",
            //                              MessageBoxButtons.OK,
            //                              MessageBoxIcon.Warning);
            //                return false;
            //            }

            //            // تحديث البيانات
            //            currentUser.FullName = Data.FullName;
            //            currentUser.UserName = Data.UserName;
            //            currentUser.Password = Data.Password;
            //            currentUser.UserRole = Data.UserRole;
            //            currentUser.IDDep = Data.IDDep;
            //            currentUser.DeptName = Data.DeptName;
            //        }

            //        db.SaveChanges();
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}",
            //                      "خطأ",
            //                      MessageBoxButtons.OK,
            //                      MessageBoxIcon.Error);
            //        return false;
            //    }
            //}

            //db = new DBEArchieEntity();
            //try
            //{
            //    var existingUser = db.TBUsers.FirstOrDefault(u => u.UserName == Data.UserName );
            //    if (existingUser == null)
            //    {
            //        db.TBUsers.Add(Data);
            //    }
            //    else
            //    {
            //        existingUser.FullName = Data.FullName;
            //        existingUser.Password = Data.Password;
            //        existingUser.UserRole = Data.UserRole;
            //        existingUser.IDDep = Data.IDDep;
            //        existingUser.DeptName = Data.DeptName;
            //        //MessageBox.Show("اسم المستخدم موجود في قاعدة البيانات مسبقاً،\n نرجو اختيار اسم مستخدم أخر", "تنبية !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    }
            //    db.SaveChanges();
            //    state = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "خطأ أثناء الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    state = false;
            //}
            //return state;
        }

        private bool LoadDeptName()
        {
            try
            {
                db = new DBEArchieEntity();
                DeptNameList = db.TB_Dep.Select(x => x.DepName).ToList();
                state = true;
            }
            catch
            {
                state = false;
            }
            return state;
        }

        private bool LoadDeptID(string DepName)
        {
            try
            {
                db = new DBEArchieEntity();
                depid = db.TB_Dep.Where(x => x.DepName == DepName).Select(x => x.ID).FirstOrDefault();
                state = true;
            }
            catch
            {
                state = false;
            }
            return state;
        }

        private async void edt_Dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            Loading.Visible = true;
            var depName = edt_Dept.SelectedItem.ToString();
            var result = await Task.Run(() => LoadDeptID(depName));
            if (!result)
            {
               // MessageBox.Show("خطأ في الاتصال", "تأكد من الاتصال في السيرفر لطفاً", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Loading.Visible = false;
        }

     

        private async void AddUser_Load(object sender, EventArgs e)
        {if (RoleUser == "مدير" || start ==1)
            {

                Loading.Visible = true;
                var result = await Task.Run(() => LoadDeptName());
                Loading.Visible = false;
                if (result)
                {
                    edt_Dept.DataSource = DeptNameList;
                    if (DeptNameList.Count > 0)
                    {
                        edt_Dept.SelectedIndex = 0;
                        await Task.Run(() => LoadDeptID(DeptNameList[0]));
                    }
                }
                else
                {
                    MessageBox.Show("خطأ في الاتصال", "تأكد من الاتصال في السيرفر لطفاً", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        else if(RoleUser =="مدير قسم")
            {edt_role.Items.Clear();
                edt_role.Items.Add(userRole);
                edt_Dept.Items.Clear();
                edt_Dept.Items.Add(userDep);
            }

        }

        private void AddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (start == 1)
            {
                Application.Exit();
            }
        }
    }


}