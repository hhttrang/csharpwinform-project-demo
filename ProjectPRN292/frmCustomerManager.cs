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
    public partial class frmCustomerManager : Form
    {
        private bool IsStaff;
        private String StaffID;
        private List<Customer> listCustomer;
        private DataTable dtCustomer;
        private bool addNew;
        private bool BindingStatus;
        public frmCustomerManager(bool Staff, String Name)
        {
            InitializeComponent();
            IsStaff = Staff;
            StaffID = Name; 
            LoadData();
            addNew = false;
        }
    private void ShowForm()
        { 
            Form f = null;
            if (IsStaff)
            {
                f = new frmStaffHome(StaffID);
            }
            else
            {
                f = new frmReceptionistHome(StaffID);
            } 
            Application.Run(f);
            this.Close();
        }
        private void BindingData()
        {
            if (!BindingStatus)
            {
                txtCusID.DataBindings.Clear();
                txtFirstname.DataBindings.Clear();
                txtLastname.DataBindings.Clear();
                txtAdress.DataBindings.Clear();
                cbCountry.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtPhone.DataBindings.Clear();
                cbStatus.DataBindings.Clear(); 

                txtCusID.DataBindings.Add("Text", dtCustomer, "CustomerID");
                txtFirstname.DataBindings.Add("Text", dtCustomer, "FirstName");
                txtLastname.DataBindings.Add("Text", dtCustomer, "LastName");
                txtAdress.DataBindings.Add("Text", dtCustomer, "Address");
                cbCountry.DataBindings.Add("Text", dtCustomer, "Country");
                txtEmail.DataBindings.Add("Text", dtCustomer, "Email");
                txtPhone.DataBindings.Add("Text", dtCustomer, "Phone");
                cbStatus.DataBindings.Add("Text", dtCustomer, "Status");
                 
                 
                BindingStatus = true;
            }
        }
        private void LoadData()
        {
            try
            {
                listCustomer = ManagerDAL.ShowCustomerInfo();
                dtCustomer = ManagerDAL.ToDataTable<Customer>(listCustomer);
                BindingData();

                dgvCustomers.DataSource = dtCustomer;
                dgvCustomers.Rows[0].Selected = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCusID.DataBindings.Clear(); 
            txtFirstname.DataBindings.Clear();
            txtLastname.DataBindings.Clear();
            txtAdress.DataBindings.Clear();
            cbCountry.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            cbStatus.DataBindings.Clear();  

            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtAdress.Text = "";
            cbCountry.SelectedIndex = 0;
            txtEmail.Text = "";
            txtPhone.Text = "";
            cbStatus.SelectedIndex = 0;  

            txtCusID.Text = "Auto-Create";
            // txtCusID.ReadOnly = false; 
            cbCountry.SelectedIndex = 0;
            BindingStatus = false;
            addNew = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                if (CheckValid() && !addNew)
                {
                    Customer r = new Customer()
                    {
                        CustomerID = txtCusID.Text,
                        FirstName = txtFirstname.Text,
                        LastName = txtLastname.Text,
                        Address = txtAdress.Text,
                        Country = cbCountry.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        Status = cbStatus.Text
                    };
                    if (ManagerDAL.UpdateCustomer(r))
                    {
                        ManagerDAL.AddNewLog(new Log() { StaffID = StaffID, ActionTime = DateTime.Now, Main = "Update Customer: " + txtCusID.Text });
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindingStatus = false;
            LoadData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(() => ShowForm()));
            t.Start();
            this.Close();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchCustomer.Text.Trim().Equals(""))
            {
                BindingStatus = false;
                LoadData();
            }
            else
            {
                //  DataTable dt = ManagerDAL.FindBook(txtSearch.Text.Trim());
                listCustomer = ManagerDAL.FindCustomer(txtSearchCustomer.Text);
                dtCustomer = ManagerDAL.ToDataTable<Customer>(listCustomer);
                dgvCustomers.DataSource = dtCustomer;
                BindingStatus = false;
                BindingData();
                dgvCustomers.Rows[0].Selected = true;
                //  dgvRecepts.DataSource = dt;
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BindingData();
                if (cbStatus.Text.Equals("Disable"))
                {
                    txtCusID.ReadOnly = true;
                    txtFirstname.ReadOnly = true;
                    txtLastname.ReadOnly = true;
                    txtAdress.ReadOnly = true;
                    cbCountry.Enabled = false;
                    txtEmail.ReadOnly = true;
                    txtPhone.ReadOnly = true;
                    cbStatus.Enabled = false;
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
                }
                addNew = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    Customer re = new Customer()
                    {
                        FirstName = txtFirstname.Text,
                        LastName = txtLastname.Text,
                        Address = txtAdress.Text,
                        Country = cbCountry.SelectedItem.ToString(),
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        RegisTime = DateTime.Now,
                        StaffID = StaffID,
                    };
                    if (ManagerDAL.AddNewCustomer(re))
                    {
                        ManagerDAL.AddNewLog(new Log() { StaffID = StaffID, ActionTime = DateTime.Now, Main = "Add new Customer: " + txtCusID.Text });
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
                    MessageBox.Show("Invalid to Add!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         
    }
}
