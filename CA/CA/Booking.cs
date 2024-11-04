using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    public class Booking
    {
        // Fields for the Booking class
        private int? _bookingNo;
        private DateTime _dateOfBooking;
        private string _slot;
        private int _custNo;
        private int _staffNo;
        // Properties for the Booking class
        public int? BookingNo
        {
            get { return _bookingNo; }
            set { _bookingNo = value; }
        }
        public DateTime DateOfBooking
        {
            get { return _dateOfBooking; }
            set { _dateOfBooking = value; }
        }
        public string Slot
        {
            get { return _slot; }
            set { _slot = value; }
        }
        public int CustNo
        {
            get { return _custNo; }
            set { _custNo = value; }
        }
        public int StaffNo
        {
            get { return _staffNo; }
            set { _staffNo = value; }
        }
        // Default constructor for the Booking class
        public Booking()
        {

        }
        // Overloaded constructor for the Booking class
        public Booking(int? bookingNo, DateTime dateOfBooking, string slot, int custNo, int staffNo)
        {
            BookingNo = bookingNo;
            DateOfBooking = dateOfBooking;
            Slot = slot;
            CustNo = custNo;
            StaffNo = staffNo;
        }
        // This method will use the stored procedure Get_Booking to get all bookings from the Booking table in the database
        public static List<Booking> GetBooking()
        {
            List<Booking> bookings = new List<Booking>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Get_Booking", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int bookingNo = Convert.ToInt32(reader["BookingNo"]);
                DateTime dateOfBooking = Convert.ToDateTime(reader["DateOfBooking"]);
                string slot = reader["Slot"].ToString();
                int custNo = Convert.ToInt32(reader["CustNo"]);
                int staffNo = Convert.ToInt32(reader["StaffNo"]);

                Booking booking = new Booking(bookingNo, dateOfBooking, slot, custNo, staffNo);

                bookings.Add(booking);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return bookings;
        }
        // This method will use the stored procedure Create_Booking to create a new booking in the Booking table in the database
        public void CreateBooking()
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Create_Booking", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@DateOfBooking", DateOfBooking));
            command.Parameters.Add(new SqlParameter("@Slot", Slot));
            command.Parameters.Add(new SqlParameter("@CustNo", CustNo));
            command.Parameters.Add(new SqlParameter("@StaffNo", StaffNo));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}
