using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    public class WeddingList
    {
        // Fields for the WeddingList class
        private int? _orderNo;
        private DateTime? _dateOfOrder;
        private string _referenceName;
        private string _completedYN;

        // Properties for the WeddingList class
        public int? OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }
        public DateTime? DateOfOrder
        {
            get { return _dateOfOrder; }
            set { _dateOfOrder = value; }
        }
        public string ReferenceName
        {
            get { return _referenceName; }
            set { _referenceName = value; }
        }
        public string CompletedYN
        {
            get { return _completedYN; }
            set { _completedYN = value; }
        }
        // Default constructor for the WeddingList class
        public WeddingList()
        {

        }
        // Overloaded constructor for the WeddingList class
        public WeddingList(int? orderNo, DateTime? dateOfOrder, string referenceName, string completedYN)
        {
            OrderNo = orderNo;
            DateOfOrder = dateOfOrder;
            ReferenceName = referenceName;
            CompletedYN = completedYN;
        }
        // List that stores any errors thrown when trying to construct a WeddingList
        public static List<string> TryConstructWeddingList(string referenceName, string completedYN)
        {
            List<string> errors = new List<string>();
            WeddingList newWeddingList = new WeddingList();

            try
            {
                newWeddingList.ReferenceName = referenceName;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newWeddingList.CompletedYN = completedYN;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }
        // This method will use the stored procedure Get_WeddingList to get all wedding lists from the WeddingList table in the databaseC
        public static List<WeddingList> GetWeddingList()
        {
            List<WeddingList> weddingLists = new List<WeddingList>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Get_WeddingList", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int orderNo = Convert.ToInt32(reader["OrderNo"]);
                DateTime dateOfOrder = Convert.ToDateTime(reader["DateOfOrder"]);
                string referenceName = reader["ReferenceName"].ToString();
                string completedYN = reader["CompletedYN"].ToString();

                WeddingList weddingList = new WeddingList(orderNo, dateOfOrder, referenceName, completedYN);

                weddingLists.Add(weddingList);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return weddingLists;
        }
        // This method will use the stored procedure Update_WeddingList to update the details of an existing wedding list in the WeddingList table in the database
        public void UpdateWeddingList(int orderNo)
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Update_WeddingList", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@OrderNo", orderNo));
            command.Parameters.Add(new SqlParameter("@DateOfOrder", DateOfOrder));
            command.Parameters.Add(new SqlParameter("@ReferenceName", ReferenceName));
            command.Parameters.Add(new SqlParameter("@CompletedYN", CompletedYN));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
        // This method will use the stored procedure Create_WeddingList to create a new wedding list in the WeddingList table in the database
        public void CreateWeddingList()
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Create_WeddingList", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.Add(new SqlParameter("@OrderNo", OrderNo));
            //command.Parameters.Add(new SqlParameter("@DateOfOrder", DateOfOrder));
            command.Parameters.Add(new SqlParameter("@ReferenceName", ReferenceName));
            command.Parameters.Add(new SqlParameter("@CompletedYN", CompletedYN));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}
