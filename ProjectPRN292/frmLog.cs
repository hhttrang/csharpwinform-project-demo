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
    public partial class frmLog : Form
    {
        private bool IsStaff;
        private String ManagerName;
        private List<Log> listLog;
        private DataTable dtLog;

        public frmLog(bool Staff, String Name)
        {
            InitializeComponent();
            IsStaff = Staff;
            ManagerName = Name;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                listLog = ManagerDAL.ShowLog();
                dtLog = ManagerDAL.ToDataTable<Log>(listLog);

                dgvLog.DataSource = dtLog;
                dgvLog.Rows[0].Selected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void ShowForm()
        {
            Form f = new frmStaffHome(ManagerName);  
            Application.Run(f);
            this.Close();
        }
        private void txtSearchLog_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchLog.Text.Trim().Equals(""))
            {
                LoadData();
            }
            else
            {
                //  DataTable dt = ManagerDAL.FindBook(txtSearch.Text.Trim());
                listLog = ManagerDAL.FindLog(txtSearchLog.Text);
                dtLog = ManagerDAL.ToDataTable<Log>(listLog);
                dgvLog.DataSource = dtLog;
                //  dgvRecepts.DataSource = dt;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(() => ShowForm()));
            t.Start();
            this.Close();
        }
    }
}
