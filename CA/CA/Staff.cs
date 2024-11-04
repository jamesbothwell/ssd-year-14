using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CA
{
    class Staff
    {
        // Fields for the Staff class
        private int? _staffNo;
        private string _name;
        private string _job;

        // Properties for the Staff class
        public int? StaffNo
        {
            get { return _staffNo; }
            set { _staffNo = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Job
        {
            get { return _job; }
            set { _job = value; }
        }
        // Default constructor for the Staff class
        public Staff()
        {

        }
        // Overloaded constructor for the Staff class
        public Staff(int? staffNo, string name, string job)
        {
            StaffNo = staffNo;
            Name = name;
            Job = job;
        }
        // This method will used the stored procedure Get_Staff to get all staff from the Staff table in the database
        public static List<Staff> GetStaff()
        {
            List<Staff> staff = new List<Staff>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Get_Staff", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int staffNo = Convert.ToInt32(reader["StaffNo"]);
                string name = reader["StaffName"].ToString();
                string job = reader["StaffJob"].ToString();

                Staff staffMember = new Staff(staffNo, name, job);

                staff.Add(staffMember);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return staff;
        }
    }
}
