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
    public partial class frmHistory : Form
    {
        private bool IsStaff;
        private String ManagerName;
        private List<Booking> list;
        private DataTable dtHistory;
        public frmHistory(bool Staff, String Name)
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
                list = ManagerDAL.ShowBookingHistory();
                dtHistory = ManagerDAL.ToDataTable<Booking>(list); 

                dgvHistory.DataSource = dtHistory;
                dgvHistory.Rows[0].Selected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void ShowForm()
        {
            Form f = null;
            if (IsStaff)
            {
                f = new frmStaffHome(ManagerName);
            }
            else
            {
                f = new frmReceptionistHome(ManagerName);
            } 
            Application.Run(f);
            this.Close();
        }
        private void txtSearchHistory_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchHistory.Text.Trim().Equals(""))
            {
                LoadData();
            }
            else
            {
                //  DataTable dt = ManagerDAL.FindBook(txtSearch.Text.Trim());
                list = ManagerDAL.FindHistory(txtSearchHistory.Text);
                dtHistory = ManagerDAL.ToDataTable<Booking>(list);
                dgvHistory.DataSource = dtHistory; 
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
