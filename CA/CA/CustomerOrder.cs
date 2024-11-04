using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    public class CustomerOrder
    {
        // Fields for the CustomerOrder class
        private int? _orderNo;
        private DateTime? _dateOfOrder;
        private string? _delivery;
        private DateTime? _dateOfDelivery;
        private string? _deliveryYN;
        private int _custNo;

        // Properties for the CustomerOrder class
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
        public string? Delivery
        {
            get { return _delivery; }
            set { _delivery = value; }
        }
        public DateTime? DateOfDelivery
        {
            get { return _dateOfDelivery; }
            set { _dateOfDelivery = value; }
        }
        public string? DeliveryYN
        {
            get { return _deliveryYN; }
            set { _deliveryYN = value; }
        }
        public int CustNo
        {
            get { return _custNo; }
            set { _custNo = value; }
        }
        // Default constructor for the CustomerOrder class
        public CustomerOrder()
        {

        }
        // Overloaded constructor for the CustomerOrder class
        public CustomerOrder(int? orderNo, DateTime? dateOfOrder, string? delivery, DateTime? dateOfDelivery, string? deliveryYN, int custNo)
        {
            OrderNo = orderNo;
            DateOfOrder = dateOfOrder;
            Delivery = delivery;
            DateOfDelivery = dateOfDelivery;
            DeliveryYN = deliveryYN;
            CustNo = custNo;
        }
        // List that stores any errors thrown when trying to construct a CustomerOrder
        public static List<string> TryConstructCustomerOrder(int custNo)
        {
            List<string> errors = new List<string>();
            CustomerOrder newCustomerOrder = new CustomerOrder();

            try
            {
                newCustomerOrder.CustNo = custNo;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            } 

            return errors;
        }
        // This method will use the stored procedure Get_CustomerOrder to get all customer orders from the CustomerOrder table in the database
        public static List<CustomerOrder> GetCustomerOrder()
        {
            List<CustomerOrder> customerOrders = new List<CustomerOrder>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Get_CustomerOrder", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int orderNo = Convert.ToInt32(reader["OrderNo"]);
                DateTime dateOfOrder = Convert.ToDateTime(reader["DateOfOrder"]);
                string delivery = reader["Delivery"].ToString();
                DateTime dateOfDelivery = default;
                if (!Convert.IsDBNull(reader["DateOfDelivery"]))
                {
                     dateOfDelivery = Convert.ToDateTime(reader["DateOfDelivery"]);
                }
                string deliveryYN = reader["DeliveryYN"].ToString();
                int custNo = Convert.ToInt32(reader["CustNo"]);

                CustomerOrder customerOrder = new CustomerOrder(orderNo, dateOfOrder, delivery, dateOfDelivery, deliveryYN, custNo);

                customerOrders.Add(customerOrder);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return customerOrders;
        }
        // This method will use the stored procedure Update_CustomerOrder to update the details of an existing customer order in the CustomerOrder table in the database
        public void UpdateCustomerOrder(int orderNo)
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Update_CustomerOrder", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@OrderNo", orderNo));
            command.Parameters.Add(new SqlParameter("@DateOfOrder", DateOfOrder));
            command.Parameters.Add(new SqlParameter("@Delivery", Delivery));
            command.Parameters.Add(new SqlParameter("@DateOfDelivery", DateOfDelivery));
            command.Parameters.Add(new SqlParameter("@DeliveryYN", DeliveryYN));
            command.Parameters.Add(new SqlParameter("@CustNo", CustNo));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
        // This method will use the stored procedure Create_CustomerOrder to create a new customer order in the CustomerOrder table in the database
        public void CreateCustomerOrder()
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Create_CustomerOrder", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CustNo", CustNo));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}
