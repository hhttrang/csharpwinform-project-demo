using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPRN292
{
    public partial class frmReceptionistManager : Form
    {
        private bool IsStaff;
        private String StaffID;
        private List<Receptionist> listRecept;
        private DataTable dtRecept;
        private bool addNew; 
        private bool BindingStatus;
        public frmReceptionistManager(bool Staff, String Name)
        {
            InitializeComponent();
            IsStaff = Staff;
            StaffID = Name;
            LoadData();
            addNew = false; 
        }
        private void LoadData()
        {
            try
            {
                listRecept = ManagerDAL.ShowReceptionistInfo();
                dtRecept = ManagerDAL.ToDataTable<Receptionist>(listRecept);
                BindingData();
                 
                dgvRecepts.DataSource = dtRecept;
                dgvRecepts.Rows[0].Selected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }
        private void BindingData()
        {
            if (!BindingStatus)
            {
                txtReceptID.DataBindings.Clear();
                txtFirstname.DataBindings.Clear();
                txtLastname.DataBindings.Clear();
                txtAdress.DataBindings.Clear();
                cbCountry.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPhone.DataBindings.Clear();
                cbStatus.DataBindings.Clear();
                txtUsername.DataBindings.Clear();
                txtPass.DataBindings.Clear();

                txtReceptID.DataBindings.Add("Text", dtRecept, "StaffID");
                txtFirstname.DataBindings.Add("Text", dtRecept, "FirstName");
                txtLastname.DataBindings.Add("Text", dtRecept, "LastName");
                txtAdress.DataBindings.Add("Text", dtRecept, "Address");
                cbCountry.DataBindings.Add("Text", dtRecept, "Country");
                txtEmail.DataBindings.Add("Text", dtRecept, "Email");
                txtPhone.DataBindings.Add("Text", dtRecept, "Phone");
                cbStatus.DataBindings.Add("Text", dtRecept, "Status");
                txtUsername.DataBindings.Add("Text", dtRecept, "Username");
                txtPass.DataBindings.Add("Text", dtRecept, "Password");
                txtReceptID.ReadOnly = true;

                BindingStatus = true;
            }
        }
        private void ShowForm()
        {  
            Form  f = new frmStaffHome(StaffID);  
            Application.Run(f);
            this.Close();
        }
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BindingData();
                if (cbStatus.Text.Equals("Disable"))
                { 
                    txtFirstname.ReadOnly = true;
                    txtLastname.ReadOnly = true;
                    txtAdress.ReadOnly = true;
                    cbCountry.Enabled = false;
                    txtEmail.ReadOnly = true;
                    txtPhone.ReadOnly = true;
                    cbStatus.Enabled = false;
                    txtUsername.ReadOnly = true;
                    txtPass.ReadOnly = true;
                }
                else
                { 
                    txtFirstname.ReadOnly = false;
                    txtLastname.ReadOnly = false;
                    txtAdress.ReadOnly = false;
                    cbCountry.Enabled = true;
                    txtEmail.ReadOnly = false;
                    txtPhone.ReadOnly = false;
                    cbStatus.Enabled = true;
                    txtUsername.ReadOnly = false;
                    txtPass.ReadOnly = false;
                }
                addNew = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(() => ShowForm()));
            t.Start();
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindingStatus = false;
            LoadData();
        }

        private void txtSearchRecept_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchRecept.Text.Trim().Equals(""))
            {
                BindingStatus = false;
                LoadData();
            }
            else
            {
                //  DataTable dt = ManagerDAL.FindBook(txtSearch.Text.Trim());
                listRecept = ManagerDAL.FindRecept(txtSearchRecept.Text);
                dtRecept = ManagerDAL.ToDataTable<Receptionist>(listRecept);
                dgvRecepts.DataSource = dtRecept;
                BindingStatus = false;
                BindingData();
                dgvRecepts.Rows[0].Selected = true;
                //  dgvRecepts.DataSource = dt;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtReceptID.DataBindings.Clear();
            txtFirstname.DataBindings.Clear();
            txtLastname.DataBindings.Clear();
            txtAdress.DataBindings.Clear();
            cbCountry.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            cbStatus.DataBindings.Clear();
            txtUsername.DataBindings.Clear();
            txtPass.DataBindings.Clear();
            BindingStatus = false;
            txtReceptID.ReadOnly = false;
            txtReceptID.Text = ""; 
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtAdress.Text = "";
            cbCountry.SelectedIndex = 0;

            txtReceptID.Text = "Auto-Create";
            txtEmail.Text = "";
            txtPhone.Text = "";
            cbStatus.SelectedIndex = 0;
            txtUsername.Text = "";
            txtPass.Text = "";
            addNew = true;
        } 
        private bool CheckValid()
        {
            if (Regex.Match(txtFirstname.Text, @"[^a-zA-Z ]{1,}").Success ||
                txtFirstname.Text.Length < 2 ||
                txtFirstname.Text.Length > 50) return false;
            if (Regex.Match(txtLastname.Text, @"[^a-zA-Z ]{1,}").Success ||
                txtLastname.Text.Length < 4 ||
                txtLastname.Text.Length > 50) return false;
            if (Regex.Match(txtAdress.Text, @"[^a-zA-Z0-9, ]{1,}").Success ||
                txtAdress.Text.Length < 5 ||
                txtAdress.Text.Length > 50) return false;
            if (Regex.Match(txtUsername.Text.Trim(), @"[^a-zA-Z0-9]{1,}").Success ||
                txtFirstname.Text.Length < 2 ||
                txtFirstname.Text.Length > 10) return false;
            if (Regex.Match(txtPass.Text.Trim(), @"[^a-zA-Z0-9]{1,}").Success ||
                txtPass.Text.Length < 3 ||
                txtPass.Text.Length > 30) return false;

            if (!Regex.Match(txtEmail.Text,
                @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$").Success ||
                txtEmail.Text.Length < 5 ||
                txtEmail.Text.Length > 60) return false;
            if (Regex.Match(txtPhone.Text, @"[^0-9-]{1,}").Success || txtPhone.Text.Length != 11) return false;
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValid() && addNew)
                {
                    Receptionist re = new Receptionist()
                    {
                        FirstName = txtFirstname.Text,
                        LastName = txtLastname.Text,
                        Address = txtAdress.Text,
                        Country = cbCountry.SelectedItem.ToString(),
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        Username = txtUsername.Text,
                        Password = txtPass.Text
                    };
                    if (ManagerDAL.AddNewRecept(re))
                    {
                        ManagerDAL.AddNewLog(new Log() { StaffID = StaffID, ActionTime = DateTime.Now, Main = "Add new Receptionist: " + txtReceptID.Text });
                        MessageBox.Show("Add successful!");
                        BindingStatus = false;
                        LoadData();
                        addNew = false;
                    }
                    else
                    {
                        MessageBox.Show("Add failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid to Update!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            { 
                if (CheckValid() && !addNew)
                {
                    Receptionist r = new Receptionist()
                    {
                        StaffID = txtReceptID.Text,
                        FirstName = txtFirstname.Text,
                        LastName = txtLastname.Text,
                        Address = txtAdress.Text,
                        Country = cbCountry.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        Password = txtPass.Text,
                        Username = txtUsername.Text,
                        Status = cbStatus.Text
                    };
                    if (ManagerDAL.UpdateRecept(r))
                    {
                        ManagerDAL.AddNewLog(new Log() { StaffID = StaffID, ActionTime = DateTime.Now, Main = "Update Receptionist: " + txtReceptID.Text });
                        BindingStatus = false;
                        LoadData(); 
                        MessageBox.Show("Update successful!");
                    }
                    else
                    {
                        if (cbStatus.SelectedIndex == 1)
                        {
                            cbStatus.SelectedIndex = 0;
                        }
                        MessageBox.Show("Update failed!");
                    } 
                }
                else
                {
                    if (cbStatus.SelectedIndex == 1)
                    {
                        cbStatus.SelectedIndex = 0;
                    }
                    MessageBox.Show("Invalid to Update!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbPass_Click(object sender, EventArgs e)
        {
            if (cbPass.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }
    }
}
