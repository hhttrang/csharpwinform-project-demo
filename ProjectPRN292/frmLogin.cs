using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPRN292
{
    public partial class frmLogin : Form
    {

        private Account managerAcc;

        internal Account ManagerAcc { get => managerAcc; set => managerAcc = value; }

        public frmLogin()
        {
            InitializeComponent();
        } 

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ManagerDAL dal = new ManagerDAL();
                ManagerAcc = dal.CheckLogin(txtUsername.Text, txtPassword.Text);
                if (ManagerAcc != null)
                {
                    this.Hide();
                    Thread t = new Thread(new ThreadStart(ShowForm));

                    t.Start();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       public void ShowForm()
        {
            if (ManagerAcc.Type)
            {
                frmStaffHome f = new frmStaffHome(ManagerAcc.StaffID);
                Application.Run(f);
            }
            else
            {
                frmReceptionistHome f = new frmReceptionistHome(ManagerAcc.StaffID);
                Application.Run(f);
            } 

        }  
    }
}
