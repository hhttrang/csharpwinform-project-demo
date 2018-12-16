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
    public partial class frmBooking : Form
    {
        bool IsStaff;
        String StaffID;
        bool Booked;
        bool Maintain;
        Room CurrentRoom;  
        public frmBooking(bool Staff, bool Booked, bool Maintain, String Name, Room r)
        {
            InitializeComponent();
            IsStaff = Staff;
            StaffID = Name;
            this.Maintain = Maintain;
            CurrentRoom = r;
            this.Booked = Booked; 
        }
        private void ShowForm()
        {
         // MessageBox.Show(StaffID);
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
        //khai so du de phan biet ~.~
        private void ShowForm(String BookId)
        {
           // MessageBox.Show("pick xong roi, ve Room thoi!");
           // MessageBox.Show("thong tin sap toi la: " + IsStaff+","+ Booked+ "," + Maintain + "," + CurrentRoom.RoomNumber + "," + StaffID.Trim() + ","+ BookId);
            //chua update *&@(#*&
            CurrentRoom.Status = "Booked";
            Booked = true;
            frmRoom Room = new frmRoom(IsStaff, Booked, Maintain, CurrentRoom, StaffID.Trim());
            Application.Run(Room);
            this.Close();
        }
       
        private bool CheckCusIdValid(String id)
        {
            List<Customer> list = ManagerDAL.ShowCustomerInfo();
            for (int i = 0; i < list.Count; i++)
            {
                if (id.Equals(list.ElementAt(i).CustomerID.Trim()) && ManagerDAL.checkCustomer(id))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckValid()
        {
            //MessageBox.Show("check valid checkin: "+(DateTime.Parse(txtCheckIn.Text) - DateTime.Now).TotalHours.ToString());
            //MessageBox.Show("check valid checkin & checkout: " + (DateTime.Parse(txtCheckOut.Text) - DateTime.Parse(txtCheckIn.Text)).TotalHours.ToString());
            if ((DateTime.Parse(txtCheckIn.Text) - DateTime.Now).TotalHours < 2) return false; 
            if ((DateTime.Parse(txtCheckOut.Text) - DateTime.Parse(txtCheckIn.Text)).TotalHours < 9) return false;
            if (!CheckCusIdValid(txtCusID.Text)) return false;
            if (txtComment.Text.Length > 100) return false;
            if (!rbBreakYes.Checked && !rbBreakNo.Checked) return false;
            if (!rbNightsNo.Checked && !rbNightsYes.Checked) return false;
           
            return true;
        }
        private Booking AddBooking(DateTime TimeNow)
        {
            String rs = null;
            Booking b = null;
            try
            {
                int nights = 0;
                int breakfirst = 0;
                TimeSpan SubTime = DateTime.Parse(txtCheckOut.Text) - DateTime.Parse(txtCheckIn.Text);
                if (rbBreakYes.Checked) {
                    if (SubTime.TotalHours % 24 != 0)
                    {
                        breakfirst = (int)SubTime.TotalHours / 24 + 1;
                    }
                    else
                    {
                        breakfirst = (int)SubTime.TotalHours / 24;
                    }
                }
                if (rbNightsYes.Checked) {
                    nights = (int)SubTime.TotalHours / 24;
                } 
                Booking booking = new Booking()
                {
                    RoomNumber = CurrentRoom.RoomNumber,
                    CheckIn = DateTime.Parse(txtCheckIn.Text),
                    CheckOut = DateTime.Parse(txtCheckOut.Text),
                    Comment = txtComment.Text,
                    Breakfirst = breakfirst,
                    Nights = nights,
                    BookTime = TimeNow,
                    CustomerID = txtCusID.Text
                };
                rs = ManagerDAL.AddNewBooking(booking);
                if (rs != null)
                {
                    b = new Booking()
                    {
                        BookingID = rs,
                        Breakfirst = breakfirst,
                        Nights = nights
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
            return b;
        }
        private float CalcuDays(DateTime FromDate, DateTime ToDate, int Breakfist, int Nights)
        {
            float fullcost = 0;
            try
            {
                TimeSpan SubTime = ToDate - FromDate;
                float day = 0;

                int nights = (int)SubTime.TotalHours / 24;
               // MessageBox.Show("Sub hours is: " + SubTime.TotalHours.ToString());
                if (SubTime.TotalHours % 24 < 12)
                {
                    day = (float)nights + 0.5f;
                }
                else if (SubTime.TotalHours % 24 >= 12)
                {
                    day = (float)nights + 1;
                }
                else
                {
                    day = (float)nights;
                } 
               // MessageBox.Show("so ngay tinh ra duoc: " + day.ToString());
                fullcost = CurrentRoom.PricePerNight * day + Breakfist * 50000 + Nights + 50000;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return fullcost;
        }
         
        private bool AddPayment(DateTime TimeNow, Booking book)
        {
            bool rs = false;
            try
            { 
                //string was not reconize as a datetime???
                float fullcost = CalcuDays(DateTime.Parse(txtCheckIn.Text), DateTime.Parse(txtCheckOut.Text), book.Breakfirst, book.Nights);
               // MessageBox.Show("Full cost để add được vào payment mới là: " + fullcost);
                Payment pay = new Payment()
                {
                    Amount = fullcost,
                    Cancelled = false,
                    Paid = fullcost * 0.3f,
                    BookingID = book.BookingID,
                    CustomerID = txtCusID.Text
                };
                rs = ManagerDAL.AddNewPayment(pay);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rs;
        }
        private void AddNewBooking()
        {
            try
            {
                DateTime TimeofNow = DateTime.Now;
                Booking rs = AddBooking(TimeofNow);

                if (rs != null)
                {
                    //add bang Payment 
                    if (AddPayment(TimeofNow, rs))
                    {
                        MessageBox.Show("Booking successful!");
                        ManagerDAL.AddNewLog(new Log()
                        {
                            StaffID = StaffID,
                            ActionTime = DateTime.Now,
                            Main = "Booking the room: " + CurrentRoom.RoomNumber.ToString() + " to: " + rs
                        });

                        this.Hide();
                       // MessageBox.Show(rs.BookingID);
                        Thread t = new Thread(new ThreadStart(() => ShowForm(rs.BookingID)));
                        t.Start();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Add Payment Failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Booking failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool AddLastBooking(Booking LastBooking)
        {
            //get last BookingID add them booking_room & + them payment! 
            bool rs1 = ManagerDAL.AddNewRoomBooking(LastBooking.BookingID, CurrentRoom.RoomNumber);
             
            float newCost = CalcuDays(LastBooking.CheckIn, LastBooking.CheckOut, LastBooking.Breakfirst, LastBooking.Nights) + LastBooking.Amount;
            float newPaid = newCost * 0.3f;
            //lay fromDay & toDay cu, lay 2 gia cu de update
            bool rs2 = ManagerDAL.UpdatePaymentCost(LastBooking.BookingID, newCost, newPaid);

            if (rs1 && rs2)
            {
                ManagerDAL.AddNewLog(new Log() { StaffID = StaffID, ActionTime = DateTime.Now,
                    Main = "Booking the room: " + CurrentRoom.RoomNumber.ToString() + "to: " + LastBooking.BookingID});

                return true;
            }
            else return false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            { 
                if (CheckValid())
                {
                    if (cbContinueBooking.Checked)
                    {
                        Booking LastBooking = ManagerDAL.GetLastBooking();
                        if ((LastBooking.BookTime - DateTime.Now).TotalHours < 1)
                        {
                            var confirmResult = MessageBox.Show("Continue to book this room for last booking?", "Confirm booking action",
                                        MessageBoxButtons.YesNo);
                            if (confirmResult == DialogResult.Yes)
                            {
                                if (AddLastBooking(LastBooking))
                                {
                                    MessageBox.Show("Booking continue successful!");
                                }
                                else
                                {
                                    MessageBox.Show("Booking continue failed!");
                                }
                                this.Hide();
                                Thread t = new Thread(new ThreadStart(() => ShowForm()));
                                t.Start();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry, you can't continue to add room to old booking anymore");
                            cbContinueBooking.Checked = false;
                        } 
                    }
                    else
                    {
                        AddNewBooking(); 
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Booking Input!");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(() => ShowForm()));
            t.Start();
            this.Close();
        }

        private void cbContinueBooking_CheckedChanged(object sender, EventArgs e)
        { 
            if (cbContinueBooking.Checked)
            {
                txtCusID.ReadOnly = true;
                txtCheckIn.ReadOnly = true;
                txtCheckOut.ReadOnly = true;
                txtComment.ReadOnly = true;
                rbBreakNo.Enabled = false;
                rbBreakYes.Enabled = false;
                rbNightsYes.Enabled = false;
                rbNightsNo.Enabled = false; 
            }
            else
            {
                txtCusID.ReadOnly = false;
                txtCheckIn.ReadOnly = false;
                txtCheckOut.ReadOnly = false;
                txtComment.ReadOnly = false;
                rbBreakNo.Enabled = true;
                rbBreakYes.Enabled = true;
                rbNightsYes.Enabled = true;
                rbNightsNo.Enabled = true;
            }
        }
    }
}
