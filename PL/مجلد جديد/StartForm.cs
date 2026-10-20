using DevExpress.XtraSplashScreen;
using Electronic_Archive.AddPage;
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

namespace Electronic_Archive.AddPage
{
    public partial class StartForm : SplashScreen
    {
      
        TBUser tbadd;
        private int state;

        public StartForm()
        {
            InitializeComponent();
        
            this.labelCopyright.Text = "Copyright © 1998-" + DateTime.Now.Year.ToString();
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
                if(userid > 0)
                {
                    state = 1;
                }
                else
                {
                    // do not have any user in DB 
                    state = 2;
                }
            
            }
            catch  { state = 3; }
        }

        private async void StartForm_Load(object sender, EventArgs e, AddDep addDep)
        { 
        }

        private async void StartForm_Load(object sender, EventArgs e)
        {
            await Task.Run(() => CheckState());
            switch (state)
            {
                case 1:
                    PL.LoginForm loginForm = new PL.LoginForm();
                    loginForm.Show();
                    Hide();
                    break;
                case 2:
                    // Add Dep and User
                    AddPage.AddDep depPage = new AddPage.AddDep(0,this);
                    depPage.start = 1;
                    
                    depPage.Show();
                    Hide();
                    break;
                case 3:
                    //// Add Dep and User
                    //AddPage.AddDep a = new AddPage.AddDep();
                    //a.start = 1;
                    //a.Show();
                    //Hide();
                    break;

            }
            if (state == 1)
            {

            }


        }
    }
}