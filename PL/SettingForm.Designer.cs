namespace Electronic_Archive.PL
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pic_logo = new DevExpress.XtraEditors.PictureEdit();
            this.edt_CompanyDes = new System.Windows.Forms.RichTextBox();
            this.edt_Companyname = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ChangeLogo = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save_Gen = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Backup = new DevExpress.XtraEditors.SimpleButton();
            this.Loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.rb_remote = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_conString = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.edt_password = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.edt_username = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.edt_DB = new DevExpress.XtraEditors.TextEdit();
            this.edt_Port = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_serverName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.rb_local = new System.Windows.Forms.RadioButton();
            this.numericChartRangeControlClient1 = new DevExpress.XtraEditors.NumericChartRangeControlClient();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Companyname.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_DB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Port.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_serverName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericChartRangeControlClient1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox1.Controls.Add(this.pic_logo);
            this.groupBox1.Controls.Add(this.edt_CompanyDes);
            this.groupBox1.Controls.Add(this.edt_Companyname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_ChangeLogo);
            this.groupBox1.Controls.Add(this.btn_save_Gen);
            this.groupBox1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(28, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(440, 719);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اعدادات عامة";
            // 
            // pic_logo
            // 
            this.pic_logo.EditValue = ((object)(resources.GetObject("pic_logo.EditValue")));
            this.pic_logo.Location = new System.Drawing.Point(30, 407);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_logo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_logo.Size = new System.Drawing.Size(185, 147);
            this.pic_logo.TabIndex = 6;
            // 
            // edt_CompanyDes
            // 
            this.edt_CompanyDes.Location = new System.Drawing.Point(12, 227);
            this.edt_CompanyDes.Name = "edt_CompanyDes";
            this.edt_CompanyDes.Size = new System.Drawing.Size(399, 160);
            this.edt_CompanyDes.TabIndex = 5;
            this.edt_CompanyDes.Text = "";
            // 
            // edt_Companyname
            // 
            this.edt_Companyname.Location = new System.Drawing.Point(12, 102);
            this.edt_Companyname.Name = "edt_Companyname";
            this.edt_Companyname.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Companyname.Properties.Appearance.Options.UseFont = true;
            this.edt_Companyname.Size = new System.Drawing.Size(398, 44);
            this.edt_Companyname.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "الشعار";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "وصف المؤسسة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "اسم المؤسسة";
            // 
            // btn_ChangeLogo
            // 
            this.btn_ChangeLogo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_ChangeLogo.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangeLogo.Appearance.Options.UseFont = true;
            this.btn_ChangeLogo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ChangeLogo.ImageOptions.Image")));
            this.btn_ChangeLogo.Location = new System.Drawing.Point(234, 480);
            this.btn_ChangeLogo.Name = "btn_ChangeLogo";
            this.btn_ChangeLogo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_ChangeLogo.Size = new System.Drawing.Size(176, 60);
            this.btn_ChangeLogo.TabIndex = 2;
            this.btn_ChangeLogo.Text = "تغيير الشعار";
            this.btn_ChangeLogo.Click += new System.EventHandler(this.btn_ChangeLogo_Click);
            // 
            // btn_save_Gen
            // 
            this.btn_save_Gen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_save_Gen.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_Gen.Appearance.Options.UseFont = true;
            this.btn_save_Gen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save_Gen.ImageOptions.Image")));
            this.btn_save_Gen.Location = new System.Drawing.Point(12, 582);
            this.btn_save_Gen.Name = "btn_save_Gen";
            this.btn_save_Gen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_save_Gen.Size = new System.Drawing.Size(405, 60);
            this.btn_save_Gen.TabIndex = 2;
            this.btn_save_Gen.Text = "حفظ";
            this.btn_save_Gen.Click += new System.EventHandler(this.btn_save_Gen_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(546, 553);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(481, 32);
            this.label9.TabIndex = 3;
            this.label9.Text = "يجب تشغيل البرنامج كمسؤول لتتمكن مناجراء النسخ الإحتياطي";
            // 
            // btn_Backup
            // 
            this.btn_Backup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Backup.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Backup.Appearance.Options.UseFont = true;
            this.btn_Backup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Backup.ImageOptions.Image")));
            this.btn_Backup.Location = new System.Drawing.Point(509, 591);
            this.btn_Backup.Name = "btn_Backup";
            this.btn_Backup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Backup.Size = new System.Drawing.Size(671, 60);
            this.btn_Backup.TabIndex = 2;
            this.btn_Backup.Text = "اخذ نسخة احتياطية";
            this.btn_Backup.Click += new System.EventHandler(this.btn_Backup_Click);
            // 
            // Loading
            // 
            this.Loading.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Loading.Appearance.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loading.Appearance.Options.UseBackColor = true;
            this.Loading.Appearance.Options.UseFont = true;
            this.Loading.Caption = "الرجاء الإنتظار";
            this.Loading.Description = "...... جارية عملية النسخ الإحتياطي .نرجو الإنتظار حتى اكمال العملية";
            this.Loading.Location = new System.Drawing.Point(404, 536);
            this.Loading.Name = "Loading";
            this.Loading.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Loading.Size = new System.Drawing.Size(369, 54);
            this.Loading.TabIndex = 6;
            this.Loading.Text = "progressPanel1";
            this.Loading.Visible = false;
            // 
            // rb_remote
            // 
            this.rb_remote.AutoSize = true;
            this.rb_remote.Location = new System.Drawing.Point(555, 198);
            this.rb_remote.Name = "rb_remote";
            this.rb_remote.Size = new System.Drawing.Size(96, 41);
            this.rb_remote.TabIndex = 5;
            this.rb_remote.Text = "شبكي";
            this.rb_remote.UseVisualStyleBackColor = true;
            this.rb_remote.CheckedChanged += new System.EventHandler(this.rb_remote_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox2.Controls.Add(this.btn_conString);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.rb_local);
            this.groupBox2.Controls.Add(this.rb_remote);
            this.groupBox2.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(485, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(685, 546);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الاتصال الشبكي";
            // 
            // btn_conString
            // 
            this.btn_conString.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_conString.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_conString.Appearance.Options.UseFont = true;
            this.btn_conString.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_conString.ImageOptions.Image")));
            this.btn_conString.Location = new System.Drawing.Point(24, 456);
            this.btn_conString.Name = "btn_conString";
            this.btn_conString.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_conString.Size = new System.Drawing.Size(495, 52);
            this.btn_conString.TabIndex = 5;
            this.btn_conString.Text = "حفظ";
            this.btn_conString.Click += new System.EventHandler(this.btn_conString_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.edt_password);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.edt_username);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.edt_DB);
            this.panel2.Controls.Add(this.edt_Port);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.edt_serverName);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(30, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 381);
            this.panel2.TabIndex = 7;
            // 
            // edt_password
            // 
            this.edt_password.EditValue = "12345";
            this.edt_password.Enabled = false;
            this.edt_password.Location = new System.Drawing.Point(22, 306);
            this.edt_password.Name = "edt_password";
            this.edt_password.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_password.Properties.Appearance.Options.UseFont = true;
            this.edt_password.Properties.PasswordChar = '*';
            this.edt_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_password.Size = new System.Drawing.Size(289, 44);
            this.edt_password.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 37);
            this.label7.TabIndex = 6;
            this.label7.Text = "كلمة المرور";
            // 
            // edt_username
            // 
            this.edt_username.EditValue = "sa";
            this.edt_username.Enabled = false;
            this.edt_username.Location = new System.Drawing.Point(22, 236);
            this.edt_username.Name = "edt_username";
            this.edt_username.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_username.Properties.Appearance.Options.UseFont = true;
            this.edt_username.Properties.PasswordChar = '*';
            this.edt_username.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_username.Size = new System.Drawing.Size(289, 44);
            this.edt_username.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 37);
            this.label5.TabIndex = 7;
            this.label5.Text = "اسم المستخدم";
            // 
            // edt_DB
            // 
            this.edt_DB.EditValue = "DBEArchie";
            this.edt_DB.Enabled = false;
            this.edt_DB.Location = new System.Drawing.Point(22, 96);
            this.edt_DB.Name = "edt_DB";
            this.edt_DB.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_DB.Properties.Appearance.Options.UseFont = true;
            this.edt_DB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_DB.Size = new System.Drawing.Size(289, 44);
            this.edt_DB.TabIndex = 13;
            // 
            // edt_Port
            // 
            this.edt_Port.EditValue = "1433";
            this.edt_Port.Enabled = false;
            this.edt_Port.Location = new System.Drawing.Point(22, 166);
            this.edt_Port.Name = "edt_Port";
            this.edt_Port.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Port.Properties.Appearance.Options.UseFont = true;
            this.edt_Port.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_Port.Size = new System.Drawing.Size(289, 44);
            this.edt_Port.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(335, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 37);
            this.label8.TabIndex = 8;
            this.label8.Text = "قاعدة البيانات";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 37);
            this.label4.TabIndex = 9;
            this.label4.Text = "رقم المنفذ";
            // 
            // edt_serverName
            // 
            this.edt_serverName.EditValue = "DESKTOP-K5U9UAO";
            this.edt_serverName.Location = new System.Drawing.Point(22, 26);
            this.edt_serverName.Name = "edt_serverName";
            this.edt_serverName.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_serverName.Properties.Appearance.Options.UseFont = true;
            this.edt_serverName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.edt_serverName.Size = new System.Drawing.Size(289, 44);
            this.edt_serverName.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 37);
            this.label6.TabIndex = 10;
            this.label6.Text = "اسم السرفر";
            // 
            // rb_local
            // 
            this.rb_local.AutoSize = true;
            this.rb_local.Location = new System.Drawing.Point(556, 119);
            this.rb_local.Name = "rb_local";
            this.rb_local.Size = new System.Drawing.Size(86, 41);
            this.rb_local.TabIndex = 5;
            this.rb_local.Text = "محلي";
            this.rb_local.UseVisualStyleBackColor = true;
            this.rb_local.CheckedChanged += new System.EventHandler(this.rb_remote_CheckedChanged);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 663);
            this.Controls.Add(this.Loading);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Backup);
            this.Controls.Add(this.label9);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الإعدادات";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Companyname.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_DB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Port.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_serverName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericChartRangeControlClient1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.PictureEdit pic_logo;
        private System.Windows.Forms.RichTextBox edt_CompanyDes;
        private DevExpress.XtraEditors.TextEdit edt_Companyname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_save_Gen;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SimpleButton btn_ChangeLogo;
        private DevExpress.XtraEditors.SimpleButton btn_Backup;
        private DevExpress.XtraWaitForm.ProgressPanel Loading;
        private System.Windows.Forms.RadioButton rb_remote;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btn_conString;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit edt_password;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit edt_username;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit edt_DB;
        private DevExpress.XtraEditors.TextEdit edt_Port;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit edt_serverName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.NumericChartRangeControlClient numericChartRangeControlClient1;
        private System.Windows.Forms.RadioButton rb_local;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}