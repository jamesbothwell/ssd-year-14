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
    public class Customer
    {
        // Fields for the Customer class
        private int? _customerNo;
        private string _name;
        private string _address1;
        private string _address2;
        private string _postcode;
        private string _phoneNo;
        private string _email = "";

        // Properties for the Customer class
        public int? CustomerNo
        {
            get { return _customerNo;  }
            set { _customerNo = value;  }
        }
        // Validation for Name
        public string Name
        {
            get { return _name; }
            set 
            {
                // Name cannot be null
                if (value.Length == 0) { throw new FormatException("You must enter a customer name"); }
                // Name cannot be longer than 30 characters
                else if (value.Length > 30) { throw new FormatException("Customer name must be less than 30 characters long"); }
                // Name cannot be less than 3 characters long
                else if (value.Length < 3) { throw new FormatException("Customer name must be equal to or longer than 3 characters"); }
                // Name cannot contain numbers or symbols
                else if (!Regex.IsMatch(value, @"^[a-zA-Z ]+$")) { throw new FormatException("Customer name cannot contain numbers or symbols"); }
                else { _name = value; }
            }
        }
        // Validation for Address Line 1
        public string Address1
        {
            get { return _address1; }
            set 
            {
                // Address Line 1 cannot be null
                if (value.Length == 0) { throw new FormatException("You must enter a first address line"); }
                // Address Line 1 cannot be longer than 50 characters
                else if (value.Length > 50) { throw new FormatException("Customer's first address line must be less than 50 characters long"); }
                // Address Line 1 cannot be less than 3 characters long
                else if (value.Length < 3) { throw new FormatException("Customer's first address line must be equal to or longer than 3 characters"); }
                else { _address1 = value; }
            }
        }
        // Validation for Address Line 2
        public string Address2
        {
            get { return _address2; }
            set
            {
                // Address Line 2 cannot be null
                if (value.Length == 0) { throw new FormatException("You must enter a second address line"); }
                // Address Line 2 cannot be longer than 50 characters
                else if (value.Length > 50) { throw new FormatException("Customer's second address line must be less than 50 characters long"); }
                // Address Line 2 cannot be less than 3 characters long
                else if (value.Length < 3) { throw new FormatException("Customer's second address line must be equal to or longer than 3 characters"); }
                else { _address2 = value; }
            }
        }
        // Validation for Postcode
        public string Postcode
        {
            get { return _postcode; }
            set
            {
                // Postcode cannot be null
                if (value.Length == 0) { throw new FormatException("You must enter a postcode"); }
                // Postcode must be 7 characters long
                else if (value.Length > 7) { throw new FormatException("Customer postcode must be 7 characters long"); }
                else if (value.Length < 7) { throw new FormatException("Customer postcode must be 7 characters long"); }
                else { _postcode = value; }
            }
        }
        // Validation for Phone No
        public string PhoneNo
        {
            get { return _phoneNo; }
            set 
            {
                // Phone No cannot be null
                if (value.Length == 0) { throw new FormatException("You must enter a phone number"); }
                // Phone No must be 11 characters long
                else if (value.Length > 11) { throw new FormatException("Customer phone number must be 11 characters long"); }
                else if (value.Length < 11) { throw new FormatException("Customer phone number must be 11 characters long"); }
                // Phone No cannot contain letters or symbols
                else if (!Regex.IsMatch(value, @"^\d+$")) { throw new FormatException("Customer phone number cannot contain letters or symbols"); }
                else { _phoneNo = value; }
            }
        }
        // Validation for Email
        public string Email
        {
            get { return _email; }
            set 
            {
                // Email cannot be null
                if (value.Length == 0) { throw new FormatException("You must enter an email"); }
                // Email cannot be longer than 30 characters
                else if (value.Length > 30) { throw new FormatException("Customer email must be less than 30 characters long"); }
                // Email cannot be less than 7 characters long
                else if (value.Length < 7) { throw new FormatException("Customer email must be equal to or longer than 7 characters"); }
                // Email must contain an "@" symbol
                else if (!value.Contains("@")) { throw new FormatException("You must enter a valid email"); }
                else { _email = value; }
            }
        }
        // Default constructor for the Customer class
        public Customer()
        {

        }
        // Overloaded constructor for the Customer class
        public Customer( int? customerNo, string name, string address1, string address2, string postcode, string phoneNo, string email)
        {
            CustomerNo = customerNo;
            Name = name;
            Address1 = address1;
            Address2 = address2;
            Postcode = postcode;
            PhoneNo = phoneNo;
            Email = email;
        }
        // List that stores any errors thrown when trying to construct a Customer
        public static List<string> TryConstructCustomer(string name, string address1, string address2, string postcode, string phoneNo, string email)
        {
            List<string> errors = new List<string>();
            Customer newCustomer = new Customer();

            try
            {
                newCustomer.Name = name;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newCustomer.Address1 = address1;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newCustomer.Address2 = address2;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newCustomer.Postcode = postcode;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newCustomer.PhoneNo = phoneNo;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }
            try
            {
                newCustomer.Email = email;
            }
            catch (FormatException ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }
        // This method will use the stored procedure Get_Customers to get all customers from the Customer table in the database
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Get_Customers", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int custNo = Convert.ToInt32(reader["CustNo"]);
                string name = reader["CustName"].ToString();
                string address1 = reader["CustAddress1"].ToString();
                string address2 = reader["CustAddress2"].ToString();
                string postcode = reader["CustPostcode"].ToString();
                string phoneNo = reader["CustPhone"].ToString();
                string email = reader["CustEmail"].ToString();

                Customer customer = new Customer(custNo, name, address1, address2, postcode, phoneNo, email);

                customers.Add(customer);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return customers;
        }
        // This method will use the stored procedure Search_Customers to get all customers from the Customer table in the database that have details similar to the search string passed through
        public static List<Customer> GetCustomersFromSearch(string search)
        {
            List<Customer> customers = new List<Customer>();
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Search_Customers", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@SearchString", search));

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int custNo = Convert.ToInt32(reader["CustNo"]);
                string name = reader["CustName"].ToString();
                string address1 = reader["CustAddress1"].ToString();
                string address2 = reader["CustAddress2"].ToString();
                string postcode = reader["CustPostcode"].ToString();
                string phoneNo = reader["CustPhone"].ToString();
                string email = reader["CustEmail"].ToString();

                Customer customer = new Customer(custNo, name, address1, address2, postcode, phoneNo, email);

                customers.Add(customer);
            }
            reader.Close();

            DatabaseConnection.CloseConnection();
            return customers;
        }
        // This method will use the stored procedure Update_Customer to update the details of an existing customer in the Customer table in the database
        public void UpdateCustomer(int customerNo)
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Update_Customer", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CustNo", customerNo));
            command.Parameters.Add(new SqlParameter("@CustName", Name));
            command.Parameters.Add(new SqlParameter("@CustAddress1", Address1));
            command.Parameters.Add(new SqlParameter("@CustAddress2", Address2));
            command.Parameters.Add(new SqlParameter("@CustPostcode", Postcode));
            command.Parameters.Add(new SqlParameter("@CustPhone", PhoneNo));
            command.Parameters.Add(new SqlParameter("@CustEmail", Email));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
        // This method will use the stored procedure Create_Customer to create a new customer in the Customer table in the database
        public void CreateCustomer()
        {
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Create_Customer", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CustName", Name));
            command.Parameters.Add(new SqlParameter("@CustAddress1", Address1));
            command.Parameters.Add(new SqlParameter("@CustAddress2", Address2));
            command.Parameters.Add(new SqlParameter("@CustPostcode", Postcode));
            command.Parameters.Add(new SqlParameter("@CustPhone", PhoneNo));
            command.Parameters.Add(new SqlParameter("@CustEmail", Email));

            command.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}
