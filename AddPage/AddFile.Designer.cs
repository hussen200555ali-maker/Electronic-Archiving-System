namespace Electronic_Archive.AddPage
{
    partial class AddFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFile));
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            this.Loading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edt_details = new System.Windows.Forms.RichTextBox();
            this.edt_Archdate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_reciver = new DevExpress.XtraEditors.TextEdit();
            this.edt_sender = new DevExpress.XtraEditors.TextEdit();
            this.edt_number = new DevExpress.XtraEditors.TextEdit();
            this.edt_Title = new DevExpress.XtraEditors.TextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_selectFiles = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblOperationMode = new DevExpress.XtraEditors.SimpleButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_reciver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_sender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Title.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(474, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "العنوان";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Add);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 803);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 80);
            this.panel2.TabIndex = 3;
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Add.Appearance.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Appearance.Options.UseFont = true;
            this.btn_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.ImageOptions.Image")));
            this.btn_Add.Location = new System.Drawing.Point(369, 14);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Add.Size = new System.Drawing.Size(225, 51);
            this.btn_Add.TabIndex = 8;
            this.btn_Add.Text = "اضافة";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
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
            this.Loading.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Loading.Appearance.Font = new System.Drawing.Font("Cairo", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loading.Appearance.Options.UseBackColor = true;
            this.Loading.Appearance.Options.UseFont = true;
            this.Loading.Caption = "الرجاء الإنتظار";
            this.Loading.Description = "......العملية جارية ";
            this.Loading.Location = new System.Drawing.Point(154, 176);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(201, 66);
            this.Loading.TabIndex = 4;
            this.Loading.Text = "progressPanel1";
            this.Loading.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edt_details);
            this.groupBox1.Controls.Add(this.Loading);
            this.groupBox1.Controls.Add(this.edt_Archdate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.edt_reciver);
            this.groupBox1.Controls.Add(this.edt_sender);
            this.groupBox1.Controls.Add(this.edt_number);
            this.groupBox1.Controls.Add(this.edt_Title);
            this.groupBox1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 589);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "المعلومات الأساسية";
            // 
            // edt_details
            // 
            this.edt_details.Location = new System.Drawing.Point(28, 433);
            this.edt_details.Name = "edt_details";
            this.edt_details.Size = new System.Drawing.Size(379, 124);
            this.edt_details.TabIndex = 6;
            this.edt_details.Text = "";
            // 
            // edt_Archdate
            // 
            this.edt_Archdate.CalendarFont = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Archdate.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Archdate.Location = new System.Drawing.Point(28, 200);
            this.edt_Archdate.Name = "edt_Archdate";
            this.edt_Archdate.Size = new System.Drawing.Size(379, 45);
            this.edt_Archdate.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(458, 481);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 37);
            this.label7.TabIndex = 0;
            this.label7.Text = "التفاصيل";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(433, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 37);
            this.label6.TabIndex = 0;
            this.label6.Text = "الجهة المستقبلة";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(479, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 37);
            this.label8.TabIndex = 0;
            this.label8.Text = "التاريخ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(444, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 37);
            this.label5.TabIndex = 0;
            this.label5.Text = "الجهة المرسلة";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(483, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 37);
            this.label4.TabIndex = 0;
            this.label4.Text = "العدد";
            // 
            // edt_reciver
            // 
            this.edt_reciver.Location = new System.Drawing.Point(28, 349);
            this.edt_reciver.Name = "edt_reciver";
            this.edt_reciver.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_reciver.Properties.Appearance.Options.UseFont = true;
            this.edt_reciver.Size = new System.Drawing.Size(379, 44);
            this.edt_reciver.TabIndex = 5;
            // 
            // edt_sender
            // 
            this.edt_sender.Location = new System.Drawing.Point(28, 275);
            this.edt_sender.Name = "edt_sender";
            this.edt_sender.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_sender.Properties.Appearance.Options.UseFont = true;
            this.edt_sender.Size = new System.Drawing.Size(379, 44);
            this.edt_sender.TabIndex = 4;
            // 
            // edt_number
            // 
            this.edt_number.Location = new System.Drawing.Point(28, 126);
            this.edt_number.Name = "edt_number";
            this.edt_number.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_number.Properties.Appearance.Options.UseFont = true;
            this.edt_number.Size = new System.Drawing.Size(379, 44);
            this.edt_number.TabIndex = 2;
            // 
            // edt_Title
            // 
            this.edt_Title.Location = new System.Drawing.Point(28, 52);
            this.edt_Title.Name = "edt_Title";
            this.edt_Title.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_Title.Properties.Appearance.Options.UseFont = true;
            this.edt_Title.Size = new System.Drawing.Size(379, 44);
            this.edt_Title.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_selectFiles);
            this.groupBox2.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 694);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(599, 103);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اختيار الملفات";
            // 
            // btn_selectFiles
            // 
            this.btn_selectFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_selectFiles.Appearance.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selectFiles.Appearance.Options.UseFont = true;
            this.btn_selectFiles.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_selectFiles.ImageOptions.SvgImage")));
            this.btn_selectFiles.Location = new System.Drawing.Point(28, 40);
            this.btn_selectFiles.Name = "btn_selectFiles";
            this.btn_selectFiles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_selectFiles.Size = new System.Drawing.Size(513, 51);
            this.btn_selectFiles.TabIndex = 7;
            this.btn_selectFiles.Text = "اختار الملفات";
            this.btn_selectFiles.Click += new System.EventHandler(this.btn_selectFiles_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblOperationMode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(623, 80);
            this.panel3.TabIndex = 6;
            // 
            // lblOperationMode
            // 
            this.lblOperationMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOperationMode.Appearance.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationMode.Appearance.Options.UseFont = true;
            this.lblOperationMode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblOperationMode.ImageOptions.Image")));
            this.lblOperationMode.Location = new System.Drawing.Point(12, 15);
            this.lblOperationMode.Name = "lblOperationMode";
            this.lblOperationMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOperationMode.Size = new System.Drawing.Size(582, 51);
            this.lblOperationMode.TabIndex = 12;
            this.lblOperationMode.Visible = false;
            // 
            // AddFile
            // 
            this.ClientSize = new System.Drawing.Size(623, 883);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFile";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافة قسم";
            this.Load += new System.EventHandler(this.AddFile_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_reciver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_sender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_Title.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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
        public DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        private DevExpress.XtraWaitForm.ProgressPanel Loading;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        public DevExpress.XtraEditors.TextEdit edt_reciver;
        public DevExpress.XtraEditors.TextEdit edt_sender;
        public DevExpress.XtraEditors.TextEdit edt_number;
        public DevExpress.XtraEditors.TextEdit edt_Title;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RichTextBox edt_details;
        public System.Windows.Forms.DateTimePicker edt_Archdate;
        public DevExpress.XtraEditors.SimpleButton btn_selectFiles;
        private System.Windows.Forms.Panel panel3;
        public DevExpress.XtraEditors.SimpleButton lblOperationMode;
    }
}