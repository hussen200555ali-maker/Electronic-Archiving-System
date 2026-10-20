using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Electronic_Archive.Helpers;
using Electronic_Archive.Pages;
using Electronic_Archive.PL;
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
    public partial class AddDep : DevExpress.XtraEditors.XtraForm
    {
        public int start;
        //private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private readonly DXErrorProvider dxErrorProvider; // تعريف المتغير

        private readonly DBEArchieEntity _dbContext;
        private readonly int _id;
        private readonly DepPage _parentPage;
        private readonly StartForm __parentPage;
        private string _oldDepartmentName;



        // Var Database and Tables
        //DBEArchieEntities db;
        private readonly DBEArchieEntity db; // اتصال بقاعدة البيانات
        TB_Dep tbadd;
        // other var
        public int id;
        public Pages.DepPage page;// الصفحة الرئيسية للأقسام
        public StartForm startForm;
        bool state;
        bool closeForm = false;

        // this for work startForm  
        public AddDep(int id, StartForm parentPage)
        {
            InitializeComponent();

            // تهيئة DXErrorProvider
            dxErrorProvider = new DXErrorProvider();
            dxErrorProvider.ContainerControl = this;

            // إعداد التحقق من الصحة
            txt_DepName.Validating += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt_DepName.Text))
                {
                    dxErrorProvider.SetError(txt_DepName, "يجب إدخال اسم القسم");
                    e.Cancel = true;
                }
                else
                {
                    dxErrorProvider.SetError(txt_DepName, "");
                }
            };
            _id = id;
            __parentPage = parentPage;

            _dbContext = new DBEArchieEntity();

            ConfigureForm();
            LoadDepartmentData();

        }
        public AddDep(int id, DepPage parentPage)
        {
            InitializeComponent();

            // تهيئة DXErrorProvider
            dxErrorProvider = new DXErrorProvider();
            dxErrorProvider.ContainerControl = this;
            if (start != 1) {
                // إعداد التحقق من الصحة
                txt_DepName.Validating += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(txt_DepName.Text))
                    {
                        dxErrorProvider.SetError(txt_DepName, "يجب إدخال اسم القسم");
                        e.Cancel = true;
                    }
                    else
                    {
                        dxErrorProvider.SetError(txt_DepName, "");
                    }
                };
            }
            else
            {
                closeForm = true;
            }
        

        //  db = new DBEArchieEntity(); // إنشاء اتصال جديد
        //dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
        //dxErrorProvider.ContainerControl = this;


        _id = id;
            _parentPage = parentPage;

            _dbContext = new DBEArchieEntity();

            ConfigureForm();
            LoadDepartmentData();

        }

        private void ConfigureForm()
        {
        
            Text = _id == 0 ? "إضافة قسم جديد" : "تعديل القسم";
            btn_AddDep.Text = _id == 0 ? "إضافة" : "حفظ التعديلات";

            // إعداد التحقق من الصحة لاسم القسم
            txt_DepName.Validating += Txt_DepName_Validating;
            // طريقة بديلة للتحقق من الصحة
            txt_DepName.Properties.NullValuePrompt = "أدخل اسم القسم";
            txt_DepName.Properties.NullValuePromptShowForEmptyValue = true;
            txt_DepName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
        }

        // دالة التحقق من صحة اسم القسم
        private void Txt_DepName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (start == 1 && closeForm == true)
        
            {
                DialogResult result = XtraMessageBox.Show($"هل أنت متأكد من أنك تريد إغلاق تثبيت البرنامج؟", "تنبية",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            
            }

            else if(start !=1)
            {

                if (string.IsNullOrWhiteSpace(txt_DepName.Text))
                {
                    dxErrorProvider.SetError(txt_DepName, "يجب إدخال اسم القسم");
                    e.Cancel = true; // منع الاستمرار إذا كان هناك خطأ
                }
                else
                {
                    dxErrorProvider.SetError(txt_DepName, ""); // مسح أي أخطاء سابقة
                }
            }

        }

        private void LoadDepartmentData()
        {
            if (_id <= 0) return;

            try
            {
                var department = _dbContext.TB_Dep.Find(_id);
                if (department != null)
                {
                    txt_DepName.Text = department.DepName;
                    rtxt_details.Text = department.DepDetails;
                    _oldDepartmentName = department.DepName;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //private async void btn_AddDep_Click(object sender, EventArgs e)
        //{

        //    if (string.IsNullOrWhiteSpace(txt_DepName.Text))
        //    {
        //        XtraMessageBox.Show("يجب إدخال اسم القسم", "تحذير",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txt_DepName.Focus();
        //        return;
        //    }


        //    // إعادة تعيين أخطاء التحقق السابقة
        //    dxErrorProvider.ClearErrors();

         

        //    if (!ValidateChildren())
        //    {
        //        XtraMessageBox.Show("يوجد أخطاء في البيانات المدخلة", "تحذير",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        btn_AddDep.Enabled = false;

        //        var department = new TB_Dep
        //        {
        //            ID = _id,
        //            DepName = txt_DepName.Text.Trim(),
        //            DepDetails = rtxt_details.Text.Trim()
        //        };
                
        //        var success = await SaveDepartmentAsync(department);
        //      // Loading
        //        Loading.Visible = true;
        //        if (success)
        //        {
        //            ManageDepartmentFolder(department.DepName);
        //            XtraMessageBox.Show(_id == 0 ? "تمت الإضافة بنجاح" : "تم التعديل بنجاح",
        //                "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            DialogResult = DialogResult.OK;
        //            Close();
        //            toastNotificationsManager1.ShowNotification("e2b7a119-df41-4a5e-b21e-362c61bbf399");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show($"خطأ: {ex.Message}", "خطأ",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        Cursor = Cursors.Default;
        //        btn_AddDep.Enabled = true;
        //    }
        //    Loading.Visible = false;
        //}



        private async Task<bool> SaveDepartmentAsync(TB_Dep department)
        {
            try
            {
                _dbContext.Set<TB_Dep>().AddOrUpdate(department);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في الحفظ: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ManageDepartmentFolder(string newName)
        {
            if (_id == 0) // عملية إضافة
            {
                FileManager.CreateDepartmentFolder(newName);
            }
            else // عملية تعديل
            {
                if (_oldDepartmentName != newName)
                {
                    FileManager.RenameDepartmentFolder(_oldDepartmentName, newName);
                }
            }
        }

        private async void btn_AddDep_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt_DepName.Text))
            {
                XtraMessageBox.Show("يجب إدخال اسم القسم", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DepName.Focus();
                return;
            }


            // إعادة تعيين أخطاء التحقق السابقة
            dxErrorProvider.ClearErrors();



            if (!ValidateChildren())
            {
                XtraMessageBox.Show("يوجد أخطاء في البيانات المدخلة", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                btn_AddDep.Enabled = false;

                var department = new TB_Dep
                {
                    ID = _id,
                    DepName = txt_DepName.Text.Trim(),
                    DepDetails = rtxt_details.Text.Trim()
                };

                var success = await SaveDepartmentAsync(department);
                // Loading
                Loading.Visible = true;
                if (success)
                {
                    ManageDepartmentFolder(department.DepName);
                    XtraMessageBox.Show(_id == 0 ? "تمت الإضافة بنجاح" : "تم التعديل بنجاح",
                        "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    // Add Dep and Userال
                    if (start == 1)
                    {
                        AddPage.AddUser UserPage = new AddPage.AddUser();

                        UserPage.start = 1;
                        start = 0;
                        MessageBox.Show(" مرحباً بك في نظام الإرشيف الإلكتروني مجدداَ، الصفحة القادمة تمكنك من إضافة مستخدم لمباشرة العمل",
                         "بداية العمل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserPage.Show();

                    }

                    this.Close();
                    if (start !=1 && start !=0) {
                        toastNotificationsManager1.ShowNotification("23518c72-8f0c-4a8c-9a8b-a6484ca2c1bd");
                    } }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btn_AddDep.Enabled = true;
            }
            Loading.Visible = false;

        }

        private void AddDep_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm = true;
            if(start == 1)
            {
                Application.Exit();
            }

        }
    }


}