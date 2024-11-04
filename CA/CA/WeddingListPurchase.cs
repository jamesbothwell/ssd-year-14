using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class WeddingListPurchase
    {
        // Fields for the WeddingListPurchase class
        private int _orderNo;
        private int _custNo;
        private int _stockNo;
        private int _qtyRequired;
        private int _qtyOrdered;

        // Properties for the WeddingListPurchase class
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
        public int QtyRequired
        {
            get { return _qtyRequired; }
            set { _qtyRequired = value; }
        }
        public int QtyOrdered
        {
            get { return _qtyOrdered; }
            set { _qtyOrdered = value; }
        }
        // Default constructor for the WeddingListPurchase class
        public WeddingListPurchase()
        {

        }
        // Overloaded constructor for the WeddingListPurchase class
        public WeddingListPurchase(int orderNo, int custNo, int stockNo, int qtyRequired, int qtyOrdered)
        {
            OrderNo = orderNo;
            CustNo = custNo;
            StockNo = stockNo;
            QtyRequired = qtyRequired;
            QtyOrdered = qtyOrdered;
        }
        // List that stores any errors thrown when trying to construct a WeddingListPurchase
        public static List<string> TryConstructWeddingListPurchase(int orderNo, int custNo, int stockNo, int qtyRequired, int qtyOrdered)
        {
            List<string> errors = new List<string>();
            WeddingListPurchase newWeddingListPurchase = new WeddingListPurchase();

            try
            {
                newWeddingListPurchase.OrderNo = orderNo;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newWeddingListPurchase.CustNo = custNo;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newWeddingListPurchase.StockNo = stockNo;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newWeddingListPurchase.QtyRequired = qtyRequired;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newWeddingListPurchase.QtyOrdered = qtyOrdered;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }
        // This method will use the stored procedure Get_WeddingListPurchase to get all wedding list purchases from the WeddingListPurchase table in the database
        public static List<WeddingListPurchase> GetWeddingListPurchase()
        {
            List<WeddingListPurchase> weddingListPurchases = new List<WeddingListPurchase>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Get_WeddingListPurchase", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int orderNo = Convert.ToInt32(reader["OrderNo"]);
                int custNo = Convert.ToInt32(reader["CustNo"]);
                int stockNo = Convert.ToInt32(reader["StockNo"]);
                int qtyRequired = Convert.ToInt32(reader["QtyRequired"]);
                int qtyOrdered = Convert.ToInt32(reader["QtyOrdered"]);

                WeddingListPurchase weddingListPurchase = new WeddingListPurchase(orderNo, custNo, stockNo, qtyRequired, qtyOrdered);

                weddingListPurchases.Add(weddingListPurchase);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return weddingListPurchases;
        }
        // This method will use the stored procedure Create_WeddingListPurchase to create a new wedding list purchase in the WeddingListPurchase table in the database
        public void CreateWeddingListPurchase()
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Create_WeddingListPurchase", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@OrderNo", OrderNo));
            command.Parameters.Add(new SqlParameter("@CustNo", CustNo));
            command.Parameters.Add(new SqlParameter("@StockNo", StockNo));
            command.Parameters.Add(new SqlParameter("@QtyRequired", QtyRequired));
            command.Parameters.Add(new SqlParameter("@QtyOrdered", QtyOrdered));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}