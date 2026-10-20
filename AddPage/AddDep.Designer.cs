namespace Electronic_Archive.AddPage
{
    partial class AddDep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDep));
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DepName = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.rtxt_details = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_AddDep = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            this.Loading = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DepName.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(234, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 53);
            this.label3.TabIndex = 0;
            this.label3.Text = "اسم القسم";
            // 
            // txt_DepName
            // 
            this.txt_DepName.Location = new System.Drawing.Point(52, 102);
            this.txt_DepName.Name = "txt_DepName";
            this.txt_DepName.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DepName.Properties.Appearance.Options.UseFont = true;
            this.txt_DepName.Size = new System.Drawing.Size(531, 56);
            this.txt_DepName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(248, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 53);
            this.label4.TabIndex = 0;
            this.label4.Text = "التفاصيل";
            // 
            // rtxt_details
            // 
            this.rtxt_details.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_details.Location = new System.Drawing.Point(52, 271);
            this.rtxt_details.Name = "rtxt_details";
            this.rtxt_details.Size = new System.Drawing.Size(531, 144);
            this.rtxt_details.TabIndex = 2;
            this.rtxt_details.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_AddDep);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 441);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 80);
            this.panel2.TabIndex = 3;
            // 
            // btn_AddDep
            // 
            this.btn_AddDep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_AddDep.Appearance.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddDep.Appearance.Options.UseFont = true;
            this.btn_AddDep.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddDep.ImageOptions.Image")));
            this.btn_AddDep.Location = new System.Drawing.Point(369, 14);
            this.btn_AddDep.Name = "btn_AddDep";
            this.btn_AddDep.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_AddDep.Size = new System.Drawing.Size(225, 51);
            this.btn_AddDep.TabIndex = 12;
            this.btn_AddDep.Text = "اضافة";
            this.btn_AddDep.Click += new System.EventHandler(this.btn_AddDep_Click_1);
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
            this.Loading.Location = new System.Drawing.Point(213, 175);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(201, 66);
            this.Loading.TabIndex = 4;
            this.Loading.Text = "progressPanel1";
            this.Loading.Visible = false;
            // 
            // AddDep
            // 
            this.ClientSize = new System.Drawing.Size(623, 521);
            this.Controls.Add(this.Loading);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rtxt_details);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_DepName);
            this.Controls.Add(this.label3);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDep";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافة قسم";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddDep_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.txt_DepName.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Panel panel2;
        public DevExpress.XtraEditors.TextEdit txt_DepName;
        public System.Windows.Forms.RichTextBox rtxt_details;
        public DevExpress.XtraEditors.SimpleButton btn_AddDep;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        private DevExpress.XtraWaitForm.ProgressPanel Loading;
    }
}