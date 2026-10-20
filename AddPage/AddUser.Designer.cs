namespace Electronic_Archive.AddPage
{
    partial class AddUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            this.label3 = new System.Windows.Forms.Label();
            this.edt_Fullname = new DevExpress.XtraEditors.TextEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_AddUser = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            this.Loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.edt_role = new System.Windows.Forms.ComboBox();
            this.edt_Dept = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.edt_Password = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.edt_Username = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Fullname.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Username.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(385, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 43);
            this.label3.TabIndex = 0;
            this.label3.Text = "الاسم الكامل";
            // 
            // edt_Fullname
            // 
            this.edt_Fullname.Location = new System.Drawing.Point(28, 62);
            this.edt_Fullname.Name = "edt_Fullname";
            this.edt_Fullname.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Fullname.Properties.Appearance.Options.UseFont = true;
            this.edt_Fullname.Size = new System.Drawing.Size(342, 56);
            this.edt_Fullname.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_AddUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 533);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1069, 80);
            this.panel2.TabIndex = 3;
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_AddUser.Appearance.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUser.Appearance.Options.UseFont = true;
            this.btn_AddUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddUser.ImageOptions.Image")));
            this.btn_AddUser.Location = new System.Drawing.Point(726, 15);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_AddUser.Size = new System.Drawing.Size(225, 51);
            this.btn_AddUser.TabIndex = 6;
            this.btn_AddUser.Text = "اضافة";
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // toastNotificationsManager1
            // 
            this.toastNotificationsManager1.ApplicationId = "23518c72-8f0c-4a8c-9a8b-a6484ca2c1bd";
            this.toastNotificationsManager1.Notifications.AddRange(new DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties[] {
            new DevExpress.XtraBars.ToastNotifications.ToastNotification("e2b7a119-df41-4a5e-b21e-362c61bbf399", ((System.Drawing.Image)(resources.GetObject("toastNotificationsManager1.Notifications"))), "تمت العملية بنجاح", "تمت العملية بنجاح", "تمت العملية بنجاح", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.Text01)});
            // 
            // Loading
            // 
            this.Loading.Appearance.BackColor = System.Drawing.Color.White;
            this.Loading.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Loading.Appearance.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loading.Appearance.Options.UseBackColor = true;
            this.Loading.Appearance.Options.UseFont = true;
            this.Loading.Caption = "الرجاء الإنتظار";
            this.Loading.Description = "......العملية جارية ";
            this.Loading.Location = new System.Drawing.Point(89, 218);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(201, 66);
            this.Loading.TabIndex = 4;
            this.Loading.Text = "progressPanel1";
            this.Loading.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.edt_role);
            this.panel3.Controls.Add(this.edt_Dept);
            this.panel3.Controls.Add(this.Loading);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.edt_Password);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.edt_Username);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.edt_Fullname);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(554, 533);
            this.panel3.TabIndex = 4;
            // 
            // edt_role
            // 
            this.edt_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_role.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_role.FormattingEnabled = true;
            this.edt_role.Items.AddRange(new object[] {
            "مدير",
            "مدير قسم",
            "موظف"});
            this.edt_role.Location = new System.Drawing.Point(28, 421);
            this.edt_role.Name = "edt_role";
            this.edt_role.Size = new System.Drawing.Size(342, 51);
            this.edt_role.TabIndex = 5;
            // 
            // edt_Dept
            // 
            this.edt_Dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_Dept.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Dept.FormattingEnabled = true;
            this.edt_Dept.Location = new System.Drawing.Point(28, 335);
            this.edt_Dept.Name = "edt_Dept";
            this.edt_Dept.Size = new System.Drawing.Size(342, 51);
            this.edt_Dept.TabIndex = 4;
            this.edt_Dept.SelectedIndexChanged += new System.EventHandler(this.edt_Dept_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(407, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 43);
            this.label8.TabIndex = 0;
            this.label8.Text = "الصلاحية";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(414, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 43);
            this.label7.TabIndex = 0;
            this.label7.Text = "القسم";
            // 
            // edt_Password
            // 
            this.edt_Password.Location = new System.Drawing.Point(28, 244);
            this.edt_Password.Name = "edt_Password";
            this.edt_Password.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Password.Properties.Appearance.Options.UseFont = true;
            this.edt_Password.Size = new System.Drawing.Size(342, 56);
            this.edt_Password.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(387, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 43);
            this.label6.TabIndex = 0;
            this.label6.Text = "كلمة المرور";
            // 
            // edt_Username
            // 
            this.edt_Username.Location = new System.Drawing.Point(28, 153);
            this.edt_Username.Name = "edt_Username";
            this.edt_Username.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Username.Properties.Appearance.Options.UseFont = true;
            this.edt_Username.Size = new System.Drawing.Size(342, 56);
            this.edt_Username.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(370, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 43);
            this.label5.TabIndex = 0;
            this.label5.Text = "اسم المستخدم";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.Controls.Add(this.pictureEdit1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(554, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(515, 533);
            this.panel4.TabIndex = 2;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(77, 132);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(341, 279);
            this.pictureEdit1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(136, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 53);
            this.label4.TabIndex = 0;
            this.label4.Text = "اضافة مستخدم";
            // 
            // AddUser
            // 
            this.ClientSize = new System.Drawing.Size(1069, 613);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافة مستخدم";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddUser_FormClosed);
            this.Load += new System.EventHandler(this.AddUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edt_Fullname.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Username.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.SimpleButton simpleButton1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Panel panel2;
        public DevExpress.XtraEditors.TextEdit edt_Fullname;
        public DevExpress.XtraEditors.SimpleButton btn_AddUser;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        private DevExpress.XtraWaitForm.ProgressPanel Loading;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public DevExpress.XtraEditors.TextEdit edt_Password;
        private System.Windows.Forms.Label label6;
        public DevExpress.XtraEditors.TextEdit edt_Username;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox edt_role;
        public System.Windows.Forms.ComboBox edt_Dept;
    }
}