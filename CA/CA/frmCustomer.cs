using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CA
{
    public partial class frmCustomer : Form
    {
        // Declare the lists to be used throughout the script
        private List<Customer> Customers = new List<Customer>();
        private List<Booking> Bookings = new List<Booking>();
        private List<WeddingList> WeddingLists = new List<WeddingList>();
        private List<CustomerOrder> CustomerOrders = new List<CustomerOrder>();
        public frmCustomer()
        {
            InitializeComponent();
            btnClear.Enabled = false;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
        }
        private Customer SelectedCustomer
        {
            // Set the selected customer based on the selected index of cbxCustomer
            get
            {
                if (cbxCustomer.SelectedIndex > 0)
                {
                    return Customers[cbxCustomer.SelectedIndex - 1];
                }
                else
                {
                    return null;
                }
            }
        }
        private void frmCustomer_Shown(object sender, EventArgs e)
        {
            // If a successful connection to the Customer table in the database cannot be made the user is directed back to frmWelcome
            if (!RefreshCustomers())
            {
                this.Close();
                Form frmWelcome = new frmWelcome();
                frmWelcome.Show();
            }
        }
        private bool RefreshCustomers()
        {
            try
            {
                // Retrieve the updated customers from the Customer table in the database
                List<Customer> updatedCustomers = Customer.GetCustomers();
                Customers = updatedCustomers;

                // Set all textboxes to empty and btnCreateUpdate to "Create"
                tbxName.Text = String.Empty;
                tbxAddress1.Text = String.Empty;
                tbxAddress2.Text = String.Empty;
                tbxPostcode.Text = String.Empty;
                tbxPhone.Text = String.Empty;
                tbxEmail.Text = String.Empty;
                btnCreateUpdate.Text = "Create";

                // Clear all items in cbxCustomer and dgvCustomers
                cbxCustomer.Items.Clear();
                dgvCustomers.Rows.Clear();

                cbxCustomer.Items.Add("{create new}");

                // Add all customer names to cbxCustomer and all customer details to dgvCustomers
                foreach (Customer customer in Customers)
                {
                    cbxCustomer.Items.Add(customer.Name);
                    dgvCustomers.Rows.Add(customer.CustomerNo, customer.Name, customer.Address1, customer.Address2, customer.Postcode, customer.PhoneNo, customer.Email);
                }

                // Set selected index of cbxCustomer to {create new} and clear selection in dgvCustomers
                cbxCustomer.SelectedIndex = 0;
                dgvCustomers.ClearSelection();

                return true;
            }
            catch (SqlException)
            {
                // Return error message if application cannot establish connection to customer table in database
                MessageBox.Show("Could not get customers", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            // If no rows selected break out of method
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                return;
            }

            // If a customer has been selected update the selected index of cbxCustomer
            else
            {
                DataGridViewRow selectedRow = dgvCustomers.SelectedRows[0];
                int custNo = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());

                for (int i = 0; i < Customers.Count; i++)
                {
                    if (Customers[i].CustomerNo == custNo)
                    {
                        cbxCustomer.SelectedIndex = i + 1;
                    }
                }
            }
        }

        private void cbxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear selection in dgvCustomers
            dgvCustomers.ClearSelection();

            // If there has been a customer selected in cbxCustomer make sure a selection for the same customer is made in dgvCustomers
            if (SelectedCustomer != null)
            {
                foreach (DataGridViewRow row in dgvCustomers.Rows)
                {
                    if (String.Format("{0}", SelectedCustomer.CustomerNo) == row.Cells[0].Value.ToString())
                    {
                        row.Selected = true;
                    }
                }
            }
            // Refresh textboxes with new details
            RefreshFields();


            // Set btnCustomerOrder text to "Create Customer Order"
            btnCustomerOrder.Text = "Create Customer Order";
            CustomerOrders = CustomerOrder.GetCustomerOrder();

            // If customer has already made a customer order set btnCustomeOrder text to "Purchase Stock"
            if (SelectedCustomer != null)
            {
                foreach (CustomerOrder customerOrder in CustomerOrders)
                {
                    if (customerOrder.CustNo == SelectedCustomer.CustomerNo)
                    {
                        btnCustomerOrder.Text = "Purchase Stock";
                    }
                }
            }
        }
        private void RefreshFields()
        {
            // If a customer has been selected update the textboxes text with these customer details
            if (SelectedCustomer != null)
            {
                btnCreateUpdate.Text = "Update";

                tbxName.Text = SelectedCustomer.Name;
                tbxAddress1.Text = SelectedCustomer.Address1;
                tbxAddress2.Text = SelectedCustomer.Address2;
                tbxPostcode.Text = SelectedCustomer.Postcode;
                tbxPhone.Text = SelectedCustomer.PhoneNo;
                tbxEmail.Text = SelectedCustomer.Email;   
            }
            // If a customer has not been selected clear any text in textboxes
            else
            {
                btnCreateUpdate.Text = "Create";

                tbxName.Text = String.Empty;
                tbxAddress1.Text = String.Empty;
                tbxAddress2.Text = String.Empty;
                tbxPostcode.Text = String.Empty;
                tbxPhone.Text = String.Empty;
                tbxEmail.Text = String.Empty;

                btnCreateBooking.Enabled = true;
            }
        }

        private void SearchCustomers()
        {
            // Take the input from tbxSearch
            string searchString = tbxSearch.Text.Trim().ToLower();

            // Make sure all customers in dgvCustomers are up to date
            RefreshCustomers();

            // If tbxSearch does not contain any text disable btnClear
            if (String.IsNullOrWhiteSpace(searchString))
            {
                btnClear.Enabled = false;
                dgvCustomers.ClearSelection();
                cbxCustomer.SelectedIndex = 0;
            }
            else
            {
                try
                {
                    // Store the search results in a list
                    List<Customer> searchResults = Customer.GetCustomersFromSearch(searchString);

                    // Clear all customers in dgvCustomers
                    dgvCustomers.Rows.Clear();

                    // Add any customers returned in the search results to dgvCustomers
                    foreach (Customer customer in searchResults)
                    {
                        dgvCustomers.Rows.Add(customer.CustomerNo, customer.Name, customer.Address1, customer.Address2, customer.Postcode, customer.PhoneNo, customer.Email);
                    }

                    // Enable clear button
                    btnClear.Enabled = true;
                }
                catch (SqlException)
                {
                    return;
                }
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // If text in tbxSearch has changed, search for customers using the input
            SearchCustomers();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear any text in tbxSearch on click
            tbxSearch.Text = String.Empty;
        }

        private void btnCreateUpdate_Click(object sender, EventArgs e)
        {
            // Store all information entered into textboxes
            string name = tbxName.Text.Trim();
            string address1 = tbxAddress1.Text.Trim();
            string address2 = tbxAddress2.Text.Trim();
            string postcode = tbxPostcode.Text.Trim();
            string phoneno = tbxPhone.Text.Trim();
            string email = tbxEmail.Text.Trim();

            // Retreive any errors with the input
            List<string> errors = Customer.TryConstructCustomer(name, address1, address2, postcode, phoneno, email);

            // If there are any errors, display them in a message box
            if (errors.Count > 0)
            {
                string s = String.Join("\n", errors);
                MessageBox.Show(s);
                return;
            }

            // Create a customer object

            Customer newCustomer = new Customer(null, name, address1, address2, postcode, phoneno, email);

            // If btnCreateUpdate text is "Create", create a new customer and refresh all customers
            if (btnCreateUpdate.Text == "Create")
            {
                try
                {
                    newCustomer.CreateCustomer();
                    RefreshCustomers();
                }
                catch (SqlException)
                {
                    // If there is an error when adding the new customer to the database, display an error message
                    MessageBox.Show("An error has happened when trying to create a customer", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // Otherwise, update an existing customer with new details
            else
            {
                try
                {
                    newCustomer.UpdateCustomer((int)SelectedCustomer.CustomerNo);
                    RefreshCustomers();
                }
                catch (SqlException ex)
                {
                    // If there is an error when updating the details of the existing customer to the database, display an error message
                    MessageBox.Show("An error has happened when trying to update a customer" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCreateBooking_Click(object sender, EventArgs e)
        {
            // If a customer is selected, retrieve details about whether that customer has already made a booking or not
            if (SelectedCustomer != null)
            {
                Bookings = Booking.GetBooking();

                bool alreadyBooked = false;

                foreach (Booking booking in Bookings)
                {
                    if (booking.CustNo == SelectedCustomer.CustomerNo)
                    {
                        alreadyBooked = true;
                    }
                    
                }
                // If a customer has already made a booking, display an error message
                if (alreadyBooked == true)
                {
                    MessageBox.Show("You cannot create another booking for this customer", "Booking already created");
                }
                // Otherwise open frmBooking
                else
                {
                    // Pass the selected customer's details to frmBooking
                    new frmBooking(SelectedCustomer).Show();
                    this.Hide();
                }
            }
            else
            {
                // If no customer has been selected, display an error message
                MessageBox.Show("Select a customer first", "No customer selected");
                return;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Return user to frmWelcome on click
            this.Close();
            Form frmWelcome = new frmWelcome();
            frmWelcome.Show();
        }

        

        private void btnPurchaseStock_Click(object sender, EventArgs e)
        {
            // If a customer has been selected, and they have made a customer order, take them to frmPurchaseStock
            if (SelectedCustomer != null)
            {
                if (btnCustomerOrder.Text == "Purchase Stock")
                {
                    foreach (CustomerOrder customerOrder in CustomerOrders)
                    {
                        if (customerOrder.CustNo == SelectedCustomer.CustomerNo)
                        {
                            new frmPurchaseStock(customerOrder, SelectedCustomer).Show();
                            this.Hide();
                        }
                    }
                }
                // If the customer has not made a customer order, create one for them
                else if (btnCustomerOrder.Text == "Create Customer Order")
                {
                    try
                    {
                        // Returns any errors encountered when trying to create a customer order
                        List<string> errors = CustomerOrder.TryConstructCustomerOrder(Convert.ToInt32(SelectedCustomer.CustomerNo));

                        // If any errors are found they are displayed in a message box
                        if (errors.Count > 0)
                        {
                            string s = String.Join("\n", errors);
                            MessageBox.Show(s);
                            return;
                        }

                        // Create a new customer order
                        CustomerOrder newCustomerOrder = new CustomerOrder(null, null, null, null, null, Convert.ToInt32(SelectedCustomer.CustomerNo));

                        newCustomerOrder.CreateCustomerOrder();

                        // Tell user customer order has been successfully created
                        MessageBox.Show("Customer Order successfully created");

                        // Set selected index of cbxCustomer to {create new}
                        cbxCustomer.SelectedIndex = 0;

                    }
                    catch (SqlException)
                    {
                        // If there is an error when adding the customer order to the database, display an error message
                        MessageBox.Show("An error has happened when trying to create a new Customer Order", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            else
            {
                // Tell user to select a customer if they have not done so
                MessageBox.Show("Select a customer first", "No customer selected");
                return;
            }
        }
    }
}
