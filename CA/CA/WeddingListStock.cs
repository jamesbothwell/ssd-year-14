using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class WeddingListStock
    {
        // Fields for the WeddingListStock class
        private int _orderNo;
        private int _custNo;
        private int _stockNo;
        private int _qtyOrdered;

        // Properties for the WeddingListStock class
        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }
        public int CustNo
        {
            get { return _custNo; }
            set { _custNo = value; }
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
        // Default constructor for the WeddingListStock class
        public WeddingListStock()
        {

        }
        // Overloaded constructor for the WeddingListStock class
        public WeddingListStock(int orderNo, int custNo, int stockNo, int qtyOrdered)
        {
            OrderNo = orderNo;
            CustNo = custNo;
            StockNo = stockNo;
            QtyOrdered = qtyOrdered;
        }
        // List that stores any errors thrown when trying to construct a WeddingListStock
        public static List<string> TryConstructWeddingListStock(int orderNo, int custNo, int stockNo, int qtyOrdered)
        {
            List<string> errors = new List<string>();
            WeddingListStock newWeddingListStock = new WeddingListStock();

            try
            {
                newWeddingListStock.OrderNo = orderNo;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newWeddingListStock.CustNo = custNo;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newWeddingListStock.StockNo = stockNo;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newWeddingListStock.QtyOrdered = qtyOrdered;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }
        // This method will use the stored procedure Get_WeddingListStock to get all wedding list stock from the WeddingListStock table in the database
        public static List<WeddingListStock> GetWeddingListStock()
        {
            List<WeddingListStock> weddingListStocks = new List<WeddingListStock>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Get_WeddingListStock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int orderNo = Convert.ToInt32(reader["OrderNo"]);
                int custNo = Convert.ToInt32(reader["CustNo"]);
                int stockNo = Convert.ToInt32(reader["StockNo"]);
                int qtyOrdered = Convert.ToInt32(reader["QtyOrdered"]);

                WeddingListStock weddingListStock = new WeddingListStock(orderNo, custNo, stockNo, qtyOrdered);

                weddingListStocks.Add(weddingListStock);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return weddingListStocks;
        }
        // This method will use the stored procedure Create_WeddingListStock to create a new wedding list stock in the WeddingListStock table in the database
        public void CreateWeddingListStock()
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Create_WeddingListStock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@OrderNo", OrderNo));
            command.Parameters.Add(new SqlParameter("@CustNo", CustNo));
            command.Parameters.Add(new SqlParameter("@StockNo", StockNo));
            command.Parameters.Add(new SqlParameter("@QtyOrdered", QtyOrdered));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
        // This method will use the stored procedure Update_WeddingListStock to update the details of an existing wedding list stock item in the WeddingListStock table in the database
        public void UpdateWeddingListStock(int orderNo, int custNo, int stockNo)
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Update_WeddingListStock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@OrderNo", orderNo));
            command.Parameters.Add(new SqlParameter("@CustNo", custNo));
            command.Parameters.Add(new SqlParameter("@StockNo", stockNo));
            command.Parameters.Add(new SqlParameter("@QtyOrdered", QtyOrdered));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
        // This method will use the stored procedure Delete_WeddingListStock to delete a wedding list stock item from the WeddingListStock table in the database
        public void DeleteWeddingListStock()
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Delete_WeddingListStock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@OrderNo", OrderNo));
            command.Parameters.Add(new SqlParameter("@CustNo", CustNo));
            command.Parameters.Add(new SqlParameter("@StockNo", StockNo));
            command.Parameters.Add(new SqlParameter("@QtyOrdered", QtyOrdered));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}
