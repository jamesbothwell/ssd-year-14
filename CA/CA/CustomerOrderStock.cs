using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class CustomerOrderStock
    {
        // Fields for the CustomerOrderStock class
        private int _orderNo;
        private int _stockNo;
        private int _qtyOrdered;

        // Properties for the CustomerOrderStock class
        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }
        public int StockNo
        {
            get { return _stockNo; }
            set { _stockNo = value; }
        }
        public int QtyOrdered
        {
            get { return _qtyOrdered; }
            set { _qtyOrdered = value; }
        }
        // Default constructor for the CustomerOrderStock class
        public CustomerOrderStock()
        {

        }
        // Overloaded constructor for the CustomerOrderStock class
        public CustomerOrderStock(int orderNo, int stockNo, int qtyOrdered)
        {
            OrderNo = orderNo;
            StockNo = stockNo;
            QtyOrdered = qtyOrdered;
        }
        // List that stores any errors thrown when trying to construct a CustomerOrderStock
        public static List<string> TryConstructCustomerOrderStock(int orderNo, int stockNo, int qtyOrdered)
        {
            List<string> errors = new List<string>();
            CustomerOrderStock newCustomerOrderStock = new CustomerOrderStock();

            try
            {
                newCustomerOrderStock.OrderNo = orderNo;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newCustomerOrderStock.StockNo = stockNo;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newCustomerOrderStock.QtyOrdered = qtyOrdered;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }
        // This method will use the stored procedure Get_CustomerOrderStock to get all customer order stock from the CustomerOrderStock table in the database
        public static List<CustomerOrderStock> GetCustomerOrderStock()
        {
            List<CustomerOrderStock> customerOrderStocks = new List<CustomerOrderStock>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Get_CustomerOrderStock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int orderNo = Convert.ToInt32(reader["OrderNo"]);
                int stockNo = Convert.ToInt32(reader["StockNo"]);
                int qtyOrdered = Convert.ToInt32(reader["QtyOrdered"]);

                CustomerOrderStock customerOrderStock = new CustomerOrderStock(orderNo, stockNo, qtyOrdered);

                customerOrderStocks.Add(customerOrderStock);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return customerOrderStocks;
        }
        // This method will use the stored procedure Create_CustomerOrderStock to create a new customer order stock in the CustomerOrderStock table in the database
        public void CreateCustomerOrderStock()
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Create_CustomerOrderStock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@OrderNo", OrderNo));
            command.Parameters.Add(new SqlParameter("@StockNo", StockNo));
            command.Parameters.Add(new SqlParameter("@QtyOrdered", QtyOrdered));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
        // This method will use the stored procedure Update_CustomerOrderStock to update the details of an existing customer order stock in the CustomerOrderStock table in the database
        public void UpdateCustomerOrderStock(int orderNo)
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Update_CustomerOrderStock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@OrderNo", OrderNo));
            command.Parameters.Add(new SqlParameter("@StockNo", StockNo));
            command.Parameters.Add(new SqlParameter("@QtyOrdered", QtyOrdered));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}
