using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPRN292
{ 
    //cancel bi fail kia 
    //ham tim log & history bi sai
    public class Account
    {
        public Account()
        {

        }
        public String StaffID { get; set; }
        public string FirstName { get; set; }
        public bool Type { get; set; }
    }
    public class Room
    {
        public Room()
        {

        }
        public int RoomNumber { get; set; }
        public String RoomType { get; set; }
        public float PricePerNight { get; set; }
        public int MaxPerson { get; set; }
        public String Status { get; set; }
        public String BookingID { get; set; }
    }
    public class Customer
    {
        public Customer()
        {

        }
        public String CustomerID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Country { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public DateTime RegisTime { get; set; }
        public String Status { get; set; }
        public String StaffID { get; set; }
    }
    public class Receptionist
    {
        public Receptionist()
        {

        }
        public String StaffID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Country { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; } 
        public String Status { get; set; }
        public String Username { get; set; }
        public String Password { get; set; } 
    }
   
    public class Booking
    {
        public String BookingID { get; set; }
        //tong tien tra
        public float Amount { get; set; }
        //tien da tra thuc te?
        public float Paid { get; set; }  
        //bang khac
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime BookTime { get; set; }
        public int Breakfirst { get; set; }
        public int Nights { get; set; }
        public String Comment { get; set; }

        public DateTime Paytime { get; set; } 
        public String Invoice { get; set; }
        public bool Cancelled { get; set; }
        public String CustomerID { get; set; }
        //bang khac
        public int RoomNumber { get; set; }
         
    }
    public class Log
    {
        public int ID { get; set; }
        public String StaffID { get; set; }
        public DateTime ActionTime { get; set; }
        public String Main { get; set; } 
    }
    public class Payment
    {
        public string PaymentID { get; set; }
        public float Amount { get; set; }
        public float Paid { get; set; }
        public DateTime Paytime { get; set; }
        public String Invoice { get; set; }
        public bool Cancelled { get; set; }
        public String CustomerID { get; set; }
        public String BookingID { get; set; }
    }
    public class Cancellation
    {
        public int CancelID { get; set; }
        public String BookingID { get; set; }
        public DateTime CancelTime { get; set; }
        public String CustomerID { get; set; }
    }
    public class ManagerDAL
    {
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            if(items != null)
            {
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
            }
            else
            {
                dataTable = null;
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public static string GetConnectionString()
        {
            return "server=.;database=HotelManagement;uid=sa;pwd=123456";
        }
        public Account CheckLogin(String username, String password)
        {
            SqlConnection sqlconn = new SqlConnection(GetConnectionString());
            try
            {
                sqlconn.Open();
                SqlCommand sc = new SqlCommand("select StaffID, FirstName, Type from Staff where Username='" + username + "' and Password='" + password + "'", sqlconn);

                SqlDataReader rd = sc.ExecuteReader();
                if (rd.Read())
                {
                    Account acc = new Account()
                    {
                        StaffID = rd.GetFieldValue<string>(0),
                        FirstName = rd.GetFieldValue<string>(1),
                        Type = rd.GetFieldValue<bool>(2)
                    };
                    return acc;
                }
                else return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                sqlconn.Close();
            }
        }
        public static String ShowNameFromId(String Id)
        {
            String rs = null;
            string strConnection = GetConnectionString();
            List<Receptionist> ReceptionistList = new List<Receptionist>();
            string SQL = "select FirstName from Staff where StaffID = @StaffID";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@StaffID", Id);
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {

                    rs = dr[0].ToString();
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();

            }
            return rs;
        }
        public static List<Room> ShowRoomInfo()
        {
            string strConnection = GetConnectionString();
            List<Room> RoomList = new List<Room>();
            string SQL = "select * from Room";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {

                    Room r = new Room()
                    {
                        RoomNumber = int.Parse(dr[0].ToString()),
                        RoomType = dr[1].ToString(),
                        PricePerNight = float.Parse(dr[2].ToString()),
                        MaxPerson = int.Parse(dr[3].ToString()),
                        Status = dr[4].ToString()
                    };
                    RoomList.Add(r);
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();

            }
            return RoomList;
        }

        public static List<Customer> ShowCustomerInfo()
        {
            string strConnection = GetConnectionString();
            List<Customer> CustomerList = new List<Customer>();
            string SQL = "select * from Customer";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {

                    Customer r = new Customer()
                    {
                        CustomerID = dr[0].ToString(),
                        FirstName = dr[1].ToString(),
                        LastName = dr[2].ToString(),
                        Address = dr[3].ToString(),
                        Country = dr[4].ToString(),
                        Email = dr[5].ToString(),
                        Phone = dr[6].ToString(),
                        RegisTime = DateTime.Parse(dr[7].ToString()),
                        Status = dr[8].ToString(),
                        StaffID = dr[9].ToString()
                    };
                    CustomerList.Add(r);
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();

            }
            return CustomerList;
        }
        public static List<Receptionist> ShowReceptionistInfo()
        {
            string strConnection = GetConnectionString();
            List<Receptionist> ReceptionistList = new List<Receptionist>();
            string SQL = "select StaffID,FirstName,LastName,Address,Country,Email,Phone,Status,Username,Password " +
                "from Staff where Type = 0 and Status = @Status";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Status", "Enable");
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {

                    Receptionist r = new Receptionist()
                    {
                        StaffID = dr[0].ToString(),
                        FirstName = dr[1].ToString(),
                        LastName = dr[2].ToString(),
                        Address = dr[3].ToString(),
                        Country = dr[4].ToString(),
                        Email = dr[5].ToString(),
                        Phone = dr[6].ToString(),
                        Status = dr[7].ToString(),
                        Username = dr[8].ToString(),
                        Password = dr[9].ToString()
                    };
                    ReceptionistList.Add(r);
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();

            }
            return ReceptionistList;
        }
        public static List<Receptionist> ShowStaffIDList()
        {
            string strConnection = GetConnectionString();
            List<Receptionist> ReceptionistList = new List<Receptionist>();
            string SQL = "select StaffID " + "from Staff";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn); 
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {

                    Receptionist r = new Receptionist()
                    {
                        StaffID = dr[0].ToString() 
                    };
                    ReceptionistList.Add(r);
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();

            }
            return ReceptionistList;
        }
        public static List<Booking> ShowBookingHistory()
        {
            string strConnection = GetConnectionString();
            List<Booking> BookingList = new List<Booking>();
            string SQL = "select * from Booking";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {

                    Booking r = new Booking()
                    {
                        BookingID = dr[0].ToString(),
                        CheckIn = DateTime.Parse(dr[1].ToString()),
                        CheckOut = DateTime.Parse(dr[2].ToString()),
                        Breakfirst = int.Parse(dr[3].ToString()),
                        Nights = int.Parse(dr[4].ToString()),
                        Comment = dr[5].ToString(),
                        BookTime = DateTime.Parse(dr[6].ToString()),
                        CustomerID = dr[7].ToString()
                    };
                    BookingList.Add(r);
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();

            }
            GetBookingInfoafter(ref BookingList, null);

            return BookingList;
        }
        private static Booking GetBookingFromID(String id, List<Booking> BookingList)
        {
            for (int i = 0; i < BookingList.Count; i++)
            {
                if (BookingList.ElementAt(i).BookingID.Equals(id))
                {
                    return BookingList.ElementAt(i);
                }
            }
            return null;
        }
         
        //dinh BookingID para
        public static void GetBookingInfoafter(ref List<Booking> BookingList, String BookingID)
        {
            string strConnection = GetConnectionString();
            string SQL = ""; string SQL2 = "";
            if (BookingID == null)
            {
                SQL = "select * from Booking_Room";
                SQL2 = "select BookingID,Amount,Paid,Paytime,Invoice,Cancelled from Payment";
          
            }
            else
            {
                SQL = "select * from Booking_Room where BookingID=@BookingID";
                SQL2 = "select BookingID,Amount,Paid,Paytime,Invoice,Cancelled from Payment where BookingID=@BookingID";
               
            }
          //  MessageBox.Show(BookingID);
           // MessageBox.Show("Câu lệnh h là: " + SQL);
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
             
            if (BookingID != null)
            { 
                cmd.Parameters.AddWithValue("@BookingID", BookingID);
            }
            try
            { 
                if (cnn.State == ConnectionState.Closed)
                { 
                    cnn.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable(); 
                da.Fill(dataTable); 
                foreach (DataRow dr in dataTable.Rows)
                { 
                    //
                    //
                    //
                    //MessageBox.Show("ID đang set la: " + dr[0].ToString());
                    Booking b = GetBookingFromID(dr[0].ToString(), BookingList);
                    //MessageBox.Show("ID đã lấy dc từ booking là: " + b.BookingID);
                  
                    int index = BookingList.IndexOf(b);
                    //MessageBox.Show("Index cua booking vừa rồi là: " + index);
                    BookingList[index].RoomNumber = int.Parse(dr[1].ToString());
                } 
                da.Dispose();

                cnn.Close();
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                } 
                cmd = new SqlCommand(SQL2, cnn);
                if (BookingID != null)
                { 
                    cmd.Parameters.AddWithValue("@BookingID", BookingID);
                }
                da = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                da.Fill(dataTable); 
                foreach (DataRow dr in dataTable.Rows)
                { 
                    //MessageBox.Show("ID2 đang set la: " + dr[0].ToString());
                    Booking b = GetBookingFromID(dr[0].ToString(), BookingList);
                   // MessageBox.Show("ID2 đã lấy dc từ booking là: " + b.BookingID);
                    int index = BookingList.IndexOf(b);
                    //MessageBox.Show("Index2 cua booking vừa rồi là: " + index);
                    BookingList[index].Amount = float.Parse(dr[1].ToString());
                    BookingList[index].Paid = float.Parse(dr[2].ToString());
                    //MessageBox.Show("Paytime của booking2 vừa lấy: " + dr[3].ToString());
                    if (dr[3].ToString().Trim() != "")
                    {
                        BookingList[index].Paytime = DateTime.Parse(dr[3].ToString());
                    } 
                    BookingList[index].Invoice = dr[4].ToString();
                   // MessageBox.Show("boolean cancel của booking2 vừa lấy: " + dr[5].ToString());
                    if(!dr[5].ToString().Equals("true") && !dr[5].ToString().Equals("false"))
                    { 
                        BookingList[index].Cancelled = false;
                       // MessageBox.Show("vô ko hợp lệ");
                    }
                    else
                    {
                        BookingList[index].Cancelled = bool.Parse(dr[5].ToString());
                    }
                }
                da.Dispose();
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        public static String getBookingIDFromRoom(int room)
        {
            string strConnection = GetConnectionString(); 

            string SQL = "SELECT Payment.BookingID from Payment " +
                "inner join Booking_Room on Payment.BookingID = Booking_Room.BookingID " +
                "where RoomNumber = @RoomNumber and Paytime is NULL";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@RoomNumber", room); 
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    return dr[0].ToString();
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();

            }
            return null;
        }
        public static List<Log> ShowLog()
        {
            string strConnection = GetConnectionString();
            List<Log> LogList = new List<Log>();
            string SQL = "select * from Log";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {

                    Log l = new Log()
                    {
                        ID = int.Parse(dr[0].ToString()),
                        StaffID = dr[1].ToString(),
                        ActionTime = DateTime.Parse(dr[2].ToString()),
                        Main = dr[3].ToString()
                    };
                    LogList.Add(l);
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();

            }
            return LogList;
        }
        public static List<int> ShowCancelList()
        {
            string strConnection = GetConnectionString();
            List<int> CancelIdList = new List<int>();
            string SQL = "select CancelID from Cancellation";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    int ID = int.Parse(dr[0].ToString());
                    CancelIdList.Add(ID);
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();

            }
            return CancelIdList;
        }
        public static List<Payment> ShowPayment()
        {
            string strConnection = GetConnectionString();
            List<Payment> PaymentList = new List<Payment>();
            string SQL = "select * from Payment";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {

                    Payment p = new Payment()
                    {
                        PaymentID = dr[0].ToString(),
                        Amount = float.Parse(dr[1].ToString()),
                        Paid = float.Parse(dr[2].ToString()), 
                        Invoice = dr[4].ToString(), 
                        CustomerID = dr[5].ToString(),
                        BookingID = dr[6].ToString()
                    };
                    if (!dr[3].ToString().Trim().Equals(""))
                    {
                        p.Paytime = DateTime.Parse(dr[3].ToString());
                    }
                    if (!dr[3].ToString().Equals("true") && !dr[3].ToString().Equals("false"))
                    {
                        p.Cancelled = false; 
                    }
                    else
                    {
                        p.Cancelled = bool.Parse(dr[3].ToString());
                    }
                    PaymentList.Add(p);
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();

            }
            return PaymentList;
        }
        public static bool checkCustomer(String id)
        { 
            string strConnection = GetConnectionString();
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "select Status from Customer " +
                "where CustomerID=@id";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@id", id); 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            try
            {
                cnn.Open();

                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    if (dr[0].ToString().Equals("Enable"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                da.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }
            finally
            {
                cnn.Close();

            }
            return false;
        }
        public static List<Room> FindRoom(String Room)
        {
            List<Room> listRoom = new List<Room>();
            string strConnection = GetConnectionString();
            string SQL = "select * from Room where Status=@Status";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Status", "Available");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            try
            {
                cnn.Open();

                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    //    MessageBox.Show(dr[0].ToString());
                    if (dr[0].ToString().Contains(Room)) {
                        //    MessageBox.Show("nhan duoc 1 gia tri search ");
                        Room r = new Room()
                        {
                            RoomNumber = int.Parse(dr[0].ToString()),
                            RoomType = dr[1].ToString(),
                            PricePerNight = float.Parse(dr[2].ToString()),
                            MaxPerson = int.Parse(dr[3].ToString()),
                            Status = dr[4].ToString(),
                        };
                        listRoom.Add(r);
                    }
                }
                da.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                cnn.Close(); 
            }
            return listRoom;
        }
        public static List<Customer> FindCustomer(String name)
        {
            List<Customer> listCustomer = new List<Customer>();
            string strConnection = GetConnectionString();
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "select * from Customer " +
                "where FirstName like @FirstName or LastName like @LastName";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@FirstName", "%" + name + "%");
            cmd.Parameters.AddWithValue("@LastName", "%" + name + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            try
            {
                cnn.Open();

                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    Customer r = new Customer()
                    {
                        CustomerID = dr[0].ToString(),
                        FirstName = dr[1].ToString(),
                        LastName = dr[2].ToString(),
                        Address = dr[3].ToString(),
                        Country = dr[4].ToString(),
                        Email = dr[5].ToString(),
                        Phone = dr[6].ToString(),
                        RegisTime = DateTime.Parse(dr[7].ToString()),
                        Status = dr[8].ToString(),
                        StaffID = dr[9].ToString()
                    };
                    listCustomer.Add(r);
                }
                da.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                cnn.Close();

            }
            return listCustomer;
        }
        public static List<Receptionist> FindRecept(String name)
        {
            List<Receptionist> listReceptionist = new List<Receptionist>();
            string strConnection = GetConnectionString();
            string SQL = "select StaffID,FirstName,LastName,Address,Country,Email,Phone,Status,Username,Password from Staff" +
                " where (FirstName like @FirstName or LastName like @LastName)" +
                " and Type = 0 and Status = @Status";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@FirstName", "%" + name + "%");
            cmd.Parameters.AddWithValue("@LastName", "%" + name + "%");
            cmd.Parameters.AddWithValue("@Status", "Enable");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            try
            {
                cnn.Open();

                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    Receptionist r = new Receptionist()
                    {
                        StaffID = dr[0].ToString(),
                        FirstName = dr[1].ToString(),
                        LastName = dr[2].ToString(),
                        Address = dr[3].ToString(),
                        Country = dr[4].ToString(),
                        Email = dr[5].ToString(),
                        Phone = dr[6].ToString(),
                        Status = dr[7].ToString(),
                        Username = dr[8].ToString(),
                        Password = dr[9].ToString()
                    };
                    listReceptionist.Add(r);
                }
                da.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                cnn.Close();

            }
            return listReceptionist;
        }
        public static List<Log> FindLog(String searchvalue)
        {
            List<Log> listLog = new List<Log>();
            string strConnection = GetConnectionString();
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "select * from Log where " +
                " ActionTime like @Value " +
                "or Main like @Value";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Value", "%"+searchvalue+"%"); 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            try
            {
                cnn.Open();

                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    Log r = new Log()
                    {
                        ID = int.Parse(dr[0].ToString()),
                        StaffID = dr[1].ToString(),
                        ActionTime = DateTime.Parse(dr[2].ToString()),
                        Main = dr[3].ToString()
                    };
                    listLog.Add(r);
                }
                da.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                cnn.Close();

            }
            return listLog;
        }
        public static List<Booking> FindHistory(String searchvalue)
        {
            List<Booking> listBooking = new List<Booking>();
            string strConnection = GetConnectionString();
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "select * from Booking where " +
                "CheckIn like @Value " + 
               "or CheckOut like @Value";

            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Value", "%"+searchvalue+ "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            try
            {
                cnn.Open();

                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    Booking b = new Booking()
                    {
                        BookingID = dr[0].ToString(),
                        CheckIn = DateTime.Parse(dr[1].ToString()),
                        CheckOut = DateTime.Parse(dr[2].ToString()),
                        Breakfirst = int.Parse(dr[3].ToString()),
                        Nights = int.Parse(dr[4].ToString()),
                        Comment = dr[5].ToString(),
                        BookTime = DateTime.Parse(dr[6].ToString()),
                        CustomerID = dr[7].ToString()
                    };
                    listBooking.Add(b);
                }
                da.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                cnn.Close();

            }
            if(listBooking.Count > 0)
            {
                for (int i = 0; i < listBooking.Count; i++)
                {
                  //  MessageBox.Show(listBooking.ElementAt(i).BookingID);
                    GetBookingInfoafter(ref listBooking, listBooking.ElementAt(i).BookingID);
                }
            } 
            return listBooking;
        }
        /* public static void FindBookingInfoafter(ref List<Booking> BookingList, String BookingID)
        {
            string strConnection = GetConnectionString();
            string SQL = "select * from Booking_Room where BookingID=@BookingID";
            string SQL2 = "select PaymentID,Amount,Paid,Paytime,Invoice,Cancelled from Payment where BookingID=@BookingID";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@BookingID", BookingID); 
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    Booking b = GetBookingFromID(BookingID, BookingList);
                    int index = BookingList.IndexOf(b);
                    BookingList[index].RoomNumber = int.Parse(dr[1].ToString());
                }
                da.Dispose();

                cmd = new SqlCommand(SQL2, cnn);
                da = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    Booking b = GetBookingFromID(BookingID, BookingList);
                    int index = BookingList.IndexOf(b);
                    BookingList[index].Amount = float.Parse(dr[1].ToString());
                    BookingList[index].Paid = float.Parse(dr[2].ToString());
                    BookingList[index].Paytime = DateTime.Parse(dr[3].ToString());
                    BookingList[index].Invoice = dr[4].ToString();
                    BookingList[index].Cancelled = bool.Parse(dr[5].ToString());
                }
                da.Dispose();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        */


        private static String getNewID(String obj)
        {
            int c = -1;
            String NewId = null;
            switch (obj)
            {
                case "C":
                    List<Customer> listCustomer = ShowCustomerInfo();
                    for (int i = 0; i < listCustomer.Count; i++)
                    {
                        int id = int.Parse(listCustomer.ElementAt(i).CustomerID.Substring(1));
                        if (id > c)
                        {
                            c = id;
                        }
                    }
                    break;
                case "B":
                    List<Booking> listBooking = ShowBookingHistory();
                    for (int i = 0; i < listBooking.Count; i++)
                    {
                        int id = int.Parse(listBooking.ElementAt(i).BookingID.Substring(1));
                        if (id > c)
                        {
                            c = id;
                        }
                    }
                    break;
                case "P":
                    List<Payment> listPayment = ShowPayment();
                    for (int i = 0; i < listPayment.Count; i++)
                    {
                        int id = int.Parse(listPayment.ElementAt(i).PaymentID.Substring(1));
                        if (id > c)
                        {
                            c = id;
                        }
                    }
                    break;
                case "S":
                    List<Receptionist> listReceptionist = ShowStaffIDList();
                    for (int i = 0; i < listReceptionist.Count; i++)
                    {
                        int id = int.Parse(listReceptionist.ElementAt(i).StaffID.Substring(1));
                        if (id > c)
                        {
                            c = id;
                        }
                    }
                    break;
                case "IV":
                    listPayment = ShowPayment();
                    for (int i = 0; i < listPayment.Count; i++)
                    {
                        int id = int.Parse(listPayment.ElementAt(i).Invoice.Substring(2));
                        if (id > c)
                        {
                            c = id;
                        }
                    }
                    break;
            };
            if (c == -1)
            {
                c = 1;
            }
            else
            {
                c++;
            }
            if (c.ToString().Length == 1)
            {
                NewId = obj + "00" + c.ToString();
            }
            else if (c.ToString().Length == 2)
            {
                NewId = obj + "0" + c.ToString();
            }
            else
            {
                NewId = obj + c.ToString();
            }
            return NewId;
        }
        public static Booking GetLastBooking()
        {
            int c = 0;
            List<Booking> listBooking = ShowBookingHistory();
            Booking b = null;
            for (int i = 0; i < listBooking.Count; i++)
            {
                int id = int.Parse(listBooking.ElementAt(i).CustomerID.Substring(1));
                if (id > c)
                {
                    c = id;
                    b = listBooking.ElementAt(i);
                }
            }
            return b;
        }
        private static String GetCusIdinBooking(String BookingId)
        {  
            List<Log> listLog = new List<Log>();
            string strConnection = GetConnectionString();
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "select CustomerID from Booking where BookingID=@BookingID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@BookingID", BookingId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            try
            {
                cnn.Open();

                da.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    return dr[0].ToString();
                }
                da.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                cnn.Close();

            }
            return null;
        }
    
        public static bool AddNewCustomer(Customer cus)
        { 
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            string SQL = "Insert into Customer(CustomerID,FirstName,LastName,Address,Country,Email,Phone,RegisTime,Status,StaffID) " +
                "values(@CustomerID,@FirstName,@LastName,@Address,@Country,@Email,@Phone,@RegisTime,@Status,@StaffID)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@CustomerID", getNewID("C"));
            cmd.Parameters.AddWithValue("@FirstName", cus.FirstName);
            cmd.Parameters.AddWithValue("@LastName", cus.LastName);
            cmd.Parameters.AddWithValue("@Address", cus.Address);
            cmd.Parameters.AddWithValue("@Country", cus.Country);
            cmd.Parameters.AddWithValue("@Email", cus.Email);
            cmd.Parameters.AddWithValue("@Phone", cus.Phone);
            cmd.Parameters.AddWithValue("@RegisTime", cus.RegisTime);
            cmd.Parameters.AddWithValue("@Status", "Enable");
            cmd.Parameters.AddWithValue("@StaffID", cus.StaffID);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
        public static bool AddNewRecept(Receptionist recept)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            string SQL = "Insert into Staff(StaffID,FirstName,LastName,Address,Country,Email,Phone,Type,Status,Username,Password) " +
                "values(@StaffID,@FirstName,@LastName,@Address,@Country,@Email,@Phone,@Type,@Status,@Username,@Password)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@StaffID", getNewID("S"));
            cmd.Parameters.AddWithValue("@FirstName", recept.FirstName);
            cmd.Parameters.AddWithValue("@LastName", recept.LastName);
            cmd.Parameters.AddWithValue("@Address", recept.Address);
            cmd.Parameters.AddWithValue("@Country", recept.Country);
            cmd.Parameters.AddWithValue("@Email", recept.Email);
            cmd.Parameters.AddWithValue("@Phone", recept.Phone);
            cmd.Parameters.AddWithValue("@Type", false);
            cmd.Parameters.AddWithValue("@Status", "Enable");
            cmd.Parameters.AddWithValue("@Username", recept.Username);
            cmd.Parameters.AddWithValue("@Password", recept.Password);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
        public static bool AddNewLog(Log log)
        {
            int id = -1;
            List<Log> logList = ShowLog();
            for (int i = 0; i < logList.Count; i++)
            {
                if (id < logList.ElementAt(i).ID)
                {
                    id = logList.ElementAt(i).ID;
                }
            }
            if (id != -1)
            {
                id++;
            }
            else
            {
                id = 1;
            }
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            string SQL = "Insert into log(ID,StaffID,ActionTime,Main) " +
                "values(@ID,@StaffID,@ActionTime,@Main)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
             
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@StaffID", log.StaffID);
            cmd.Parameters.AddWithValue("@ActionTime", log.ActionTime);
            cmd.Parameters.AddWithValue("@Main", log.Main); 
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public static String AddNewBooking(Booking book)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            string SQL = "Insert into Booking(BookingID,CheckIn,CheckOut,Breakfirst,Nights,Comment,BookTime,CustomerID) " +
                "values(@BookingID,@CheckIn,@CheckOut,@Breakfirst,@Nights,@Comment,@BookTime,@CustomerID)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            String BookingID = getNewID("B");
            cmd.Parameters.AddWithValue("@BookingID", BookingID);
            cmd.Parameters.AddWithValue("@CheckIn", book.CheckIn);
            cmd.Parameters.AddWithValue("@CheckOut", book.CheckOut);
            cmd.Parameters.AddWithValue("@Breakfirst", book.Breakfirst);
            cmd.Parameters.AddWithValue("@Nights", book.Nights);
            cmd.Parameters.AddWithValue("@Comment", book.Comment);
            cmd.Parameters.AddWithValue("@BookTime", book.BookTime);
            cmd.Parameters.AddWithValue("@CustomerID", book.CustomerID); 
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            bool addBookingRoom = AddNewRoomBooking(BookingID, book.RoomNumber);
            if (count > 0 && addBookingRoom)
            {
                UpdateRoomStatus(book.RoomNumber, "Booked");
                return BookingID;
            }
            else return null;
        }
        public static bool AddNewRoomBooking(String bookID, int number)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            string SQL = "Insert into Booking_Room(BookingID,RoomNumber) " +
                "values(@BookingID,@RoomNumber)";
            SqlCommand cmd = new SqlCommand(SQL, cnn); 
            cmd.Parameters.AddWithValue("@BookingID", bookID);
            cmd.Parameters.AddWithValue("@RoomNumber", number); 
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public static bool AddNewPayment(Payment pay)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            string SQL = "Insert into Payment(PaymentID,Amount,Paid,Invoice,Cancelled,CustomerID,BookingID) " +
                "values(@PaymentID,@Amount,@Paid,@Invoice,@Cancelled,@CustomerID,@BookingID)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);  
            String payId = getNewID("P");
            cmd.Parameters.AddWithValue("@PaymentID", payId);
            cmd.Parameters.AddWithValue("@Amount", pay.Amount);
            cmd.Parameters.AddWithValue("@Paid", pay.Paid); 
            //   cmd.Parameters.AddWithValue("@Paytime", pay.Paytime);
            cmd.Parameters.AddWithValue("@Invoice", getNewID("IV"));
            MessageBox.Show("cancel in this pay: " +pay.Cancelled);
            cmd.Parameters.AddWithValue("@Cancelled", pay.Cancelled);
            cmd.Parameters.AddWithValue("@CustomerID", pay.CustomerID);
            cmd.Parameters.AddWithValue("@BookingID", pay.BookingID);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
        public static bool AddNewCancel(Cancellation cancel)
        {
            int id = -1;
            List<int> IDList = ShowCancelList();
            for (int i = 0; i < IDList.Count; i++)
            {
                if (id < IDList.ElementAt(i))
                {
                    id = IDList.ElementAt(i);
                }
            }
            if (id != -1)
            {
                id++;
            }
            else
            {
                id = 1;
            } 
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            } 

            string SQL = "Insert into Cancellation(CancelID,CancelTime,BookingID,CustomerID) " +
                "values(@CancelID,@CancelTime,@BookingID,@CustomerID)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
           // MessageBox.Show("id: " + id);
           // MessageBox.Show("CancelTime: " + cancel.CancelTime);
           // MessageBox.Show("BookingID: " + cancel.BookingID);

          //  MessageBox.Show("CustomerID: " + GetCusIdinBooking(cancel.BookingID));
            cmd.Parameters.AddWithValue("@CancelID", id);
            cmd.Parameters.AddWithValue("@CancelTime", cancel.CancelTime);
            cmd.Parameters.AddWithValue("@BookingID", cancel.BookingID);
            //goi truc tiep ham lay customer id
            cmd.Parameters.AddWithValue("@CustomerID", GetCusIdinBooking(cancel.BookingID));
             
            int count = cmd.ExecuteNonQuery();
            cnn.Close(); 
            return (count > 0);
        }
        public static bool AddNewRoomCancel(int number)
        {
            int id = -1;
            List<int> IDList = ShowCancelList();
            for (int i = 0; i < IDList.Count; i++)
            {
                if (id < IDList.ElementAt(i))
                {
                    id = IDList.ElementAt(i);
                }
            } 
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            } 
            string SQL = "Insert into Room_Cancellation(CancellationCancelID,RoomNumber) " +
                "values(@CancellationCancelID,@RoomNumber)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@CancellationCancelID", id);
            cmd.Parameters.AddWithValue("@RoomNumber", number);
             
            int count = cmd.ExecuteNonQuery();
            cnn.Close();
            return (count > 0);
        }

        public static bool UpdateCustomer(Customer cus)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            string SQL = "Update Customer set FirstName=@FirstName,LastName=@LastName,Address=@Address" +
                ",Country=@Country,Email=@Email,Phone=@Phone,Status=@Status" +
                " where CustomerID=@CustomerID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CustomerID", cus.CustomerID);
            cmd.Parameters.AddWithValue("@FirstName", cus.FirstName);
            cmd.Parameters.AddWithValue("@LastName", cus.LastName);
            cmd.Parameters.AddWithValue("@Address", cus.Address);
            cmd.Parameters.AddWithValue("@Country", cus.Country);
            cmd.Parameters.AddWithValue("@Email", cus.Email);
            cmd.Parameters.AddWithValue("@Phone", cus.Phone); 
            cmd.Parameters.AddWithValue("@Status", cus.Status);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            cnn.Close();
            return (count > 0);
        }
        public static bool UpdateRecept(Receptionist Recept)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            string SQL = "Update Staff set FirstName=@FirstName,LastName=@LastName,Address=@Address" +
                " ,Country=@Country,Email=@Email,Phone=@Phone,Status=@Status,Username=@Username,Password=@Password" +
                " where StaffID=@StaffID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@StaffID", Recept.StaffID);
            cmd.Parameters.AddWithValue("@FirstName", Recept.FirstName);
            cmd.Parameters.AddWithValue("@LastName", Recept.LastName);
            cmd.Parameters.AddWithValue("@Address", Recept.Address);
            cmd.Parameters.AddWithValue("@Country", Recept.Country);
            cmd.Parameters.AddWithValue("@Email", Recept.Email);
            cmd.Parameters.AddWithValue("@Phone", Recept.Phone); 
            cmd.Parameters.AddWithValue("@Status", Recept.Status);
            cmd.Parameters.AddWithValue("@Username", Recept.Username);
            cmd.Parameters.AddWithValue("@Password", Recept.Password);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            cnn.Close();
            return (count > 0);
        }
        public static bool UpdateRoom(Room room)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            string SQL = "Update Room set RoomType=@RoomType,PricePerNight=@PricePerNight,MaxPerson=@MaxPerson,Status=@Status " +
                "where RoomNumber=@RoomNumber";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
            cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
            cmd.Parameters.AddWithValue("@PricePerNight", room.PricePerNight);
            cmd.Parameters.AddWithValue("@MaxPerson", room.MaxPerson);
            cmd.Parameters.AddWithValue("@Status", room.Status);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            cnn.Close();
            return (count > 0);
        }
        public static bool UpdateRoomStatus(int room, String status)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            string SQL = "Update Room set Status=@Status " + 
                "where RoomNumber=@RoomNumber";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RoomNumber", room); 
            cmd.Parameters.AddWithValue("@Status", status);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            cnn.Close();
            return (count > 0);
        }
        public static bool UpdatePaymentCost(String bookingId, float newCost, float newPaid)
        {
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            } 
            String payId = "";
            String SQL = "select PaymentID from Payment where BookingID=@BookingID"; 
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@BookingID", bookingId);
             
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                payId = rd.GetFieldValue<string>(0);
            }

            cnn.Close();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            string SQL2 = "Update Payment set Amount=@Amount,Paid=@Paid " +
                "where PaymentID=@PaymentID";
            cmd = new SqlCommand(SQL2, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Amount", newCost);
            cmd.Parameters.AddWithValue("@Paid", newPaid); 
            cmd.Parameters.AddWithValue("@PaymentID", payId); 
            int count = cmd.ExecuteNonQuery();
            cnn.Close();
            return (count > 0);
        }
        //moi sua
        public static bool UpdatePayment(String bookingId, DateTime ThisTime, bool cancel)
        { 
            SqlConnection cnn = new SqlConnection(GetConnectionString());
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            } 
            String payId = "";
            float oldAmount = 0;
            String SQL = "select PaymentID, Amount from Payment where BookingID=@BookingID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@BookingID", bookingId);

          //  MessageBox.Show("BookingId đưa vào update pay: " + bookingId); 
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                payId = rd.GetFieldValue<string>(0); 
                if (!cancel)
                {
                    oldAmount = (float)rd.GetDouble(1);
                    //oldAmount = rd.GetFieldValue<float>(1); 
                } 
            } 
           // MessageBox.Show("oldAmount: " + oldAmount);
            cnn.Close();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }

            string SQL2 = "";
            if (cancel) {
                SQL2 = "Update Payment set Cancelled=@Cancelled,Paytime=@Paytime " +
                "where PaymentID=@PaymentID"; }
            else
            {
                SQL2 = "Update Payment set Paid=@Paid,Cancelled=@Cancelled,Paytime=@Paytime " +
                "where PaymentID=@PaymentID";
            }
            cmd = new SqlCommand(SQL2, cnn);
            cmd.CommandType = CommandType.Text;
            if (cancel)
            {
                cmd.Parameters.AddWithValue("@Cancelled", true);
               // MessageBox.Show("Vô cancel update cancelled");
            }
            else
            {
                cmd.Parameters.AddWithValue("@Paid", oldAmount);
                cmd.Parameters.AddWithValue("@Cancelled", false);
              //  MessageBox.Show("Vô !cancel update paid");
            } 
            cmd.Parameters.AddWithValue("@Paytime", ThisTime);
            cmd.Parameters.AddWithValue("@PaymentID", payId);
             
            int count = cmd.ExecuteNonQuery();
            cnn.Close();
            return (count > 0);
        }
        

    }
}
