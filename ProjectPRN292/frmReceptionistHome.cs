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
    public partial class frmReceptionistHome : Form
    { 
        static bool IsStaff = false;
         
        ManagerDAL dal = new ManagerDAL();
        DataTable dtRoom;
        List<Room> listRoom;

        String StaffID;

        public frmReceptionistHome(String name)
        {
            InitializeComponent();
            this.StaffID = name;
            lbWelcome.Text = "Welcome, " + ManagerDAL.ShowNameFromId(name);
            LoadData();
        }  

        private void LoadData()
        {
            listRoom = ManagerDAL.ShowRoomInfo();
            dtRoom = ManagerDAL.ToDataTable<Room>(listRoom);
            dtRoom.Columns.Remove("BookingID");
            dgvRooms.DataSource = dtRoom;
        }
        public void ShowForm(int frm)
        {
            Form f = null;
            switch (frm)
            {
                case 1:
                    f = new frmReceptionistManager(IsStaff, StaffID);
                    break;
                case 2:
                    f = new frmHistory(IsStaff, StaffID);
                    break;
                case 3:
                    f = new frmCustomerManager(IsStaff, StaffID);
                    break;
                case 4:
                    f = new frmLogin();
                    break;
            }
            Application.Run(f);
        }
        public void ShowForm(bool IsStaff, bool Booked, bool Maintain, Room r, String StaffID)
        {
            frmRoom room = new frmRoom(IsStaff, Booked, Maintain, r, StaffID);
            Application.Run(room);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(() => ShowForm(4)));
            t.Start();
            this.Close();
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Room r = new Room();
                int index = dgvRooms.CurrentCell.RowIndex;
                for (int z = 0; z < dtRoom.Columns.Count; z++)
                {
                    Console.WriteLine(dtRoom.Rows[index][z].ToString() + " + ");
                    switch (z)
                    {
                        case 0:
                            r.RoomNumber = int.Parse(dtRoom.Rows[index][z].ToString());
                            break;
                        case 1:
                            r.RoomType = dtRoom.Rows[index][z].ToString();
                            break;
                        case 2:
                            r.PricePerNight = int.Parse(dtRoom.Rows[index][z].ToString());
                            break;
                        case 3:
                            r.MaxPerson = int.Parse(dtRoom.Rows[index][z].ToString());
                            break;
                        default:
                            r.Status = dtRoom.Rows[index][z].ToString();
                            break;
                    }
                }
                this.Close();
                this.Hide();
                Thread t = new Thread(new ThreadStart(() => ShowForm(IsStaff, r.Status.Equals("Booked"), r.Status.Equals("Maintain"), r, StaffID)));
                t.Start();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCustomeMana_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(() => ShowForm(3)));
            t.Start();
            this.Close();
        }
           
        private void btnViewHistory_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(() => ShowForm(2)));
            t.Start();
            this.Close();
        }

        private void txtSearchRoom_TextChanged_1(object sender, EventArgs e)
        {
            if (txtSearchRoom.Text.Trim().Equals(""))
            {
                LoadData();
            }
            else
            {
                listRoom = ManagerDAL.FindRoom(txtSearchRoom.Text);
                dtRoom = ManagerDAL.ToDataTable<Room>(listRoom);
                dgvRooms.DataSource = dtRoom;
            }
        }
 
    }
}
