using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CA
{
    public class Stock
    {
        // Fields for the Stock class
        private int? _stockNo;
        private string _desc;
        private string _category;
        private decimal _price;
        private decimal _sellingPrice;
        private int _qty;
        private string _image;
        // Properties for the Stock class
        public int? StockNo
        {
            get { return _stockNo; }
            set { _stockNo = value; }
        }
        // Validation for Description
        public string Desc
        {
            get { return _desc; }
            set
            {
                // Description cannot be null
                if (value.Length == 0) { throw new FormatException("You must enter a description"); }
                // Description cannot be longer than 50 characters
                else if (value.Length > 50) { throw new FormatException("Stock description must be less than 50 characters long"); }
                // Description cannot be less than 3 characters long
                else if (value.Length < 3) { throw new FormatException("Stock description must be equal to or longer than 3 characters long"); }
                else { _desc = value; }
            }
        }
        // Validation for Category
        public string Category
        {
            get { return _category; }
            set
            {
                // Category cannot be null
                if (value.Length == 0) { throw new FormatException("You must enter a category"); }
                // Category cannot be longer than 50 characters
                else if (value.Length > 50) { throw new FormatException("Stock category must be less than 50 characters long"); }
                // Category cannot be less than 3 characters long
                else if (value.Length < 3) { throw new FormatException("Stock category must be equal to or longer than 3 characters long"); }
                // Category cannot contain numbers or symbols
                else if (!Regex.IsMatch(value, @"^[a-zA-Z ]+$")) { throw new FormatException("Stock category cannot contain numbers or symbols"); }
                else { _category = value; }
            }
        }
        // Validation for Price
        public decimal Price
        {
            get { return _price; }
            set
            {
                // Price cannot be null
                if (value == 0) { throw new FormatException("You must enter a price"); }
                // Price cannot be less than 0
                else if (value < 0) { throw new FormatException("You must enter a valid price"); }
                else { _price = value; }
            }
        }
        // Validation for Selling Price
        public decimal SellingPrice
        {
            get { return _sellingPrice; }
            set
            {
                // Selling Price cannot be null
                if (value == 0) { throw new FormatException("You must enter a selling price"); }
                // Selling Price cannot be less than 0
                else if (value < 0) { throw new FormatException("You must enter a valid selling price"); }
                else { _sellingPrice = value; }
            }
        }
        // Validation for Quantity
        public int Qty
        {
            get { return _qty; }
            set
            {
                // Quantity cannot be less than 0
                if (value < 0) { throw new FormatException("You must enter a valid quantity"); }
                else { _qty = value; }
            }
        }
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        // Default constructor for the Stock class
        public Stock()
        {

        }
        // Overloaded constructor for the Stock class
        public Stock(int? stockNo, string desc, string category, decimal price, decimal sellingPrice, int qty, string image)
        {
            StockNo = stockNo;
            Desc = desc;
            Category = category;
            Price = price;
            SellingPrice = sellingPrice;
            Qty = qty;
            Image = image;
        }
        // List that stores any errors thrown when trying to construct an item of stock
        public static List<string> TryConstructStock(string desc, string category, decimal price, decimal sellingPrice, int qty, string image)
        {
            List<string> errors = new List<string>();
            Stock newStock = new Stock();

            try
            {
                newStock.Desc = desc;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newStock.Category = category;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newStock.Price = price;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newStock.SellingPrice = sellingPrice;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newStock.Qty = qty;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newStock.Image = image;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }
        // This method will use the stored procedure Get_Stock to get all stock from the Stock table in the database
        public static List<Stock> GetStock()
        {
            List<Stock> stockList = new List<Stock>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Get_Stock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int stockNo = Convert.ToInt32(reader["StockNo"]);
                string desc = reader["StockDesc"].ToString();
                string category = reader["StockCategory"].ToString();
                decimal price = Convert.ToDecimal(reader["StockPrice"]);
                decimal sellingPrice = Convert.ToDecimal(reader["StockSellingPrice"]);
                int qty = Convert.ToInt32(reader["StockQty"]);
                string image = reader["StockImage"].ToString();

                Stock stock = new Stock(stockNo, desc, category, price, sellingPrice, qty, image);

                stockList.Add(stock);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return stockList;
        }
        // This method will use the stored procedure Search_Customers to get all stock from the Stock table in the database that have details similar to the search string passed through
        public static List<Stock> GetStockFromSearch(string search)
        {
            List<Stock> stockList = new List<Stock>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Search_Stock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@SearchString", search));

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int stockNo = Convert.ToInt32(reader["StockNo"]);
                string desc = reader["StockDesc"].ToString();
                string category = reader["StockCategory"].ToString();
                decimal price = Convert.ToDecimal(reader["StockPrice"]);
                decimal sellingPrice = Convert.ToDecimal(reader["StockSellingPrice"]);
                int qty = Convert.ToInt32(reader["StockQty"]);
                string image = reader["StockImage"].ToString();

                Stock stock = new Stock(stockNo, desc, category, price, sellingPrice, qty, image);

                stockList.Add(stock);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return stockList;
        }
        // This method will use the stored procedure Update_Stock to update the details of an existing item of stock in the Stock table in the database
        public void UpdateStock(int stockNo)
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Update_Stock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@StockNo", stockNo));
            command.Parameters.Add(new SqlParameter("@StockDesc", Desc));
            command.Parameters.Add(new SqlParameter("@StockCategory", Category));
            command.Parameters.Add(new SqlParameter("@StockPrice", Price));
            command.Parameters.Add(new SqlParameter("@StockSellingPrice", SellingPrice));
            command.Parameters.Add(new SqlParameter("@StockQty", Qty));
            command.Parameters.Add(new SqlParameter("@StockImage", Image));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
        // This method will use the stored procedure Create_Stock to create a new item of stock in the Stock table in the database
        public void CreateStock()
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Create_Stock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@StockDesc", Desc));
            command.Parameters.Add(new SqlParameter("@StockCategory", Category));
            command.Parameters.Add(new SqlParameter("@StockPrice", Price));
            command.Parameters.Add(new SqlParameter("@StockSellingPrice", SellingPrice));
            command.Parameters.Add(new SqlParameter("@StockQty", Qty));
            command.Parameters.Add(new SqlParameter("@StockImage", Image));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
        public void DeleteStock()
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Delete_Stock", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@StockNo", StockNo));
            //command.Parameters.Add(new SqlParameter("@StockDesc", Desc));
            //command.Parameters.Add(new SqlParameter("@StockCategory", Category));
            //command.Parameters.Add(new SqlParameter("@StockPrice", Price));
            //command.Parameters.Add(new SqlParameter("@StockSellingPrice", SellingPrice));
            //command.Parameters.Add(new SqlParameter("@StockQty", Qty));
            //command.Parameters.Add(new SqlParameter("@StockImage", Image));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}
