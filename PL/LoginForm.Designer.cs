namespace Electronic_Archive.PL

{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.edt_Username = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.edt_Password = new DevExpress.XtraEditors.TextEdit();
            this.Loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.btn_AddUser = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Password.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.Controls.Add(this.pictureEdit1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1151, 622);
            this.panel4.TabIndex = 5;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(67, 98);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(439, 465);
            this.pictureEdit1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(186, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 53);
            this.label4.TabIndex = 0;
            this.label4.Text = "تسجيل الدخول";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(1151, 622);
            this.fluentDesignFormContainer1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(395, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 43);
            this.label5.TabIndex = 0;
            this.label5.Text = "اسم المستخدم";
            // 
            // edt_Username
            // 
            this.edt_Username.Location = new System.Drawing.Point(17, 176);
            this.edt_Username.Name = "edt_Username";
            this.edt_Username.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Username.Properties.Appearance.Options.UseFont = true;
            this.edt_Username.Size = new System.Drawing.Size(372, 56);
            this.edt_Username.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(406, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 43);
            this.label6.TabIndex = 0;
            this.label6.Text = "كلمة المرور";
            // 
            // edt_Password
            // 
            this.edt_Password.Location = new System.Drawing.Point(17, 294);
            this.edt_Password.Name = "edt_Password";
            this.edt_Password.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Password.Properties.Appearance.Options.UseFont = true;
            this.edt_Password.Properties.PasswordChar = '*';
            this.edt_Password.Size = new System.Drawing.Size(372, 56);
            this.edt_Password.TabIndex = 3;
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
            this.Loading.Location = new System.Drawing.Point(106, 272);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(201, 66);
            this.Loading.TabIndex = 4;
            this.Loading.Text = "progressPanel1";
            this.Loading.Visible = false;
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_AddUser.Appearance.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUser.Appearance.Options.UseFont = true;
            this.btn_AddUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddUser.ImageOptions.Image")));
            this.btn_AddUser.Location = new System.Drawing.Point(67, 400);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_AddUser.Size = new System.Drawing.Size(267, 60);
            this.btn_AddUser.TabIndex = 6;
            this.btn_AddUser.Text = "تسجيل الدخول";
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_AddUser);
            this.panel3.Controls.Add(this.Loading);
            this.panel3.Controls.Add(this.edt_Password);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.edt_Username);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(570, 622);
            this.panel3.TabIndex = 7;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 622);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("LoginForm.IconOptions.Image")));
            this.Name = "LoginForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل الدخول";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Password.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private System.Windows.Forms.Panel panel3;
        public DevExpress.XtraEditors.SimpleButton btn_AddUser;
        private DevExpress.XtraWaitForm.ProgressPanel Loading;
        public DevExpress.XtraEditors.TextEdit edt_Password;
        private System.Windows.Forms.Label label6;
        public DevExpress.XtraEditors.TextEdit edt_Username;
        private System.Windows.Forms.Label label5;
    }
}