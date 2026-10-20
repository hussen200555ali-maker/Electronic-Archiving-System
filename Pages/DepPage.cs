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


namespace Electronic_Archive.Pages
{
    public partial class DepPage : DevExpress.XtraEditors.XtraUserControl
    {
        int id;
        DBEArchieEntity db;
        public DepPage()
        {
            InitializeComponent();

            // تهيئة مصدر البيانات
            InitializeEntitySource();
            InitializeGrid();

            LoadData(); // تحميل البيانات عند الإنشاء
            }
        private void InitializeEntitySource()
        {
            // ربط الأحداث المطلوبة
            entityInstantFeedbackSource1.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            entityInstantFeedbackSource1.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;

            // تعيين خاصية KeyExpression
            entityInstantFeedbackSource1.KeyExpression = "ID"; // استبدل "ID" بمفتاح جدولك الأساسي
        }

        private void InitializeGrid()
        {
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
        }

        public void LoadData()
        {
            try
            {
              
                entityInstantFeedbackSource1.Refresh();
               
                db = new DBEArchieEntity();
                gridControl1.DataSource = db.TB_Dep.ToList();
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void entityInstantFeedbackSource1_GetQueryable(object sender, GetQueryableEventArgs e)
        {
            // إنشاء سياق البيانات
            var context = new DBEArchieEntity();

            // تعيين مصدر البيانات
            e.QueryableSource = context.TB_Dep; // استبدل TB_Dep باسم جدولك

            // تخزين السياق للتخلص منه لاحقاً
            e.Tag = context;
        }

        private void entityInstantFeedbackSource1_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            // التخلص من سياق البيانات
            var context = e.Tag as DBEArchieEntity;
            context?.Dispose();
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {
           

            var addForm = new AddPage.AddDep(0, this);
            addForm.ShowDialog();
            LoadData();


        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                if (id > 0)
                {
                    var editForm = new AddPage.AddDep(id, this);
                    editForm.ShowDialog();
                    LoadData();
                }
                else
                {
                    XtraMessageBox.Show("الرجاء تحديد قسم للتعديل", "تحذير",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
           
            try
            {
                int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                string depName = Convert.ToString(gridView1.GetFocusedRowCellValue("DepName"));

                if (id > 0)
                {
                    if (XtraMessageBox.Show($"هل أنت متأكد من حذف القسم '{depName}'؟", "تأكيد الحذف",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Loading.Visible = true;
                        using (var db = new DBEArchieEntity())
                        {
                            var department = db.TB_Dep.Find(id);
                            if (department != null)
                            {
                                db.TB_Dep.Remove(department);
                                db.SaveChanges();

                                FileManager.DeleteDepartmentFolder(depName);
                                LoadData();

                                XtraMessageBox.Show("تم حذف القسم بنجاح", "نجاح",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                toastNotificationsManager1.ShowNotification("e2b7a119-df41-4a5e-b21e-362c61bbf399");
                            }
                        }
                        Loading.Visible = false;
                    }
                }
                else
                {
                    XtraMessageBox.Show("الرجاء تحديد قسم للحذف", "تحذير",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في الحذف: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}

