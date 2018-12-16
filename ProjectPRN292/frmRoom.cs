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
    public partial class frmRoom : Form
    {
        bool IsStaff;
        bool Booked;
        bool Maintain;
        Room CurrentRoom; 
        String StaffID; 
        public frmRoom(bool Staff, bool Booked, bool Maintain, Room r, String Name)
        {
            InitializeComponent(); 
            IsStaff = Staff;
            CurrentRoom = r;
            this.Booked = Booked;
            this.Maintain = Maintain;
            txtBookingId.Text = ManagerDAL.getBookingIDFromRoom(CurrentRoom.RoomNumber);
           /* if(CurrentRoom.BookingID != null)
            {
                txtBookingId.Text = CurrentRoom.BookingID;
            } */
            StaffID = Name;
            SetEnableButtons();
            LoadDataToTexts();

        }
        private void SetEnableButtons()
        { 
            if (Booked)
            {
                btnBooking.Visible = false;
                cbStatus.Enabled = false;
                txtPricePer.ReadOnly = true;
            }
            else
            {
                btnCancelBooking.Visible = false;
                btnPayment.Visible = false;
                cbStatus.Items.Remove("Booked");
            }
            if (Maintain)
            {
                btnBooking.Visible = false; 
            }
        }
        private void LoadDataToTexts()
        {
            txtIDNumber.Text = CurrentRoom.RoomNumber.ToString();
            cbType.SelectedItem = CurrentRoom.RoomType.ToString(); 
            txtMaxPerson.Text = CurrentRoom.MaxPerson.ToString();
            cbStatus.SelectedItem = CurrentRoom.Status.ToString();

            String Fullprice;
            if (CurrentRoom.PricePerNight.ToString().ToString().Contains("E"))
            {
                Fullprice = CurrentRoom.PricePerNight.ToString().ToString().Split('E')[0] + "0000000";
            }
            else
            {
                Fullprice = CurrentRoom.PricePerNight.ToString();
            } 
            txtPricePer.Text = Fullprice;
        } 
        public void ShowForm()
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
        public void ShowBookingForm()
        {
            frmBooking Booking = new frmBooking(IsStaff, Booked, Maintain, StaffID, CurrentRoom);
            Application.Run(Booking);
        }
        private void GoBackToMain()
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(() => ShowForm()));
            t.Start();
            this.Close();
        }
        private bool CheckValid()
        {
            if (float.Parse(txtPricePer.Text) < 100) return false;
            if (Regex.Match(txtPricePer.Text, @"[^0-9]{1,}").Success || txtPricePer.Text.Length !=8) return false;
            if (Regex.Match(txtMaxPerson.Text, @"[^0-9]{1,}").Success || txtMaxPerson.Text.Length != 2) return false;
            return true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckValid())
                {
                    Room r = new Room()
                    {
                        RoomNumber = int.Parse(txtIDNumber.Text),
                        MaxPerson = int.Parse(txtMaxPerson.Text),
                        PricePerNight = float.Parse(txtPricePer.Text),
                        RoomType = cbType.Text,
                        Status = cbStatus.Text
                    };
                    if (ManagerDAL.UpdateRoom(r))
                    {
                        ManagerDAL.AddNewLog(new Log() { StaffID = StaffID, ActionTime = DateTime.Now, Main = "Edit Room: "+CurrentRoom.RoomNumber+" Info" });
                        MessageBox.Show("Update Room successful!");
                    }
                    else
                    {
                        MessageBox.Show("Update Room failed!");
                    }
                    GoBackToMain();
                }
                else
                {
                    MessageBox.Show("Invalid to Update!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void btnBooking_Click(object sender, EventArgs e)
        { 
            this.Hide();
            Thread t = new Thread(new ThreadStart(() => ShowBookingForm()));
            t.Start();
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                //update payment paid, Paytime
                DateTime Now = DateTime.Now;
                bool rs = ManagerDAL.UpdatePayment(txtBookingId.Text.Trim(), Now, false);
                if (rs)
                {
                    ManagerDAL.UpdateRoomStatus(CurrentRoom.RoomNumber, "Available");
                    MessageBox.Show("Done the pay successful!");
                    ManagerDAL.AddNewLog(new Log() { StaffID = StaffID, ActionTime = Now, Main = "Update full payment for: " + txtBookingId.Text });
                    txtBookingId.Clear();
                    GoBackToMain();
                }
                else
                {
                    MessageBox.Show("Done the pay failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            try
            { 
                var confirmResult = MessageBox.Show("Are you sure to cancel this booking?", "Confirm booking cancel",
                                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    DateTime ThisTime = DateTime.Now;
                    Cancellation c = new Cancellation()
                    {
                        CancelTime = ThisTime,
                        BookingID = txtBookingId.Text
                    };
                    bool rs1 = ManagerDAL.AddNewCancel(c);
                    //add room_cancel & update payment cancelled + paytime
                    bool rs2 = ManagerDAL.AddNewRoomCancel(CurrentRoom.RoomNumber);
                    bool rs3 = ManagerDAL.UpdatePayment(txtBookingId.Text, ThisTime, true);
                    if (rs1 && rs2 && rs3)
                    {
                        ManagerDAL.UpdateRoomStatus(CurrentRoom.RoomNumber, "Available");
                        ManagerDAL.AddNewLog(new Log() { StaffID = StaffID, ActionTime = DateTime.Now, Main = "Cancel Booking Id: " + txtBookingId.Text });
                        MessageBox.Show("Cancel process successful!");
                        GoBackToMain();
                    }
                    else
                    {
                        MessageBox.Show("Cancel process failed!");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GoBackToMain();
        }
         
    }
}
