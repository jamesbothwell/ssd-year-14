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
    public partial class frmViewBookings : Form
    {
        // Declare any lists or variables used in the script
        private List<Customer> Customers = new List<Customer>();
        private List<Booking> Bookings = new List<Booking>();
        private List<WeddingList> WeddingLists = new List<WeddingList>();
        bool finished;
        public frmViewBookings()
        {
            InitializeComponent();
        }

        private void frmViewBookings_Load(object sender, EventArgs e)
        {
            dtpDate.MinDate = DateTime.Now;
            tbxCustomer.Text = "";
            btnWeddingList.Text = "Create Wedding List";

            if (dtpDate.Value.Date == DateTime.Today && dgvCustomers.RowCount != 0)
            {
                // If dtpDate date selected is today and at least one customer has made a booking for today show btnWeddingList
                btnWeddingList.Visible = true;
            }
            else
            {
                // Else hide btnWeddingList
                btnWeddingList.Visible = false;
            }
        }
        private Customer SelectedCustomer
        {
            get
            {
                if (!string.IsNullOrEmpty(tbxCustomer.Text))
                {
                    // Assign selected customer
                    DataGridViewRow selectedRow = dgvCustomers.SelectedRows[0];
                    int custNo = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                    return Customers[custNo - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDate.Value.Date == DateTime.Today && dgvCustomers.RowCount != 0)
            {
                // If dtpDate date selected is today and at least one customer has made a booking for today show btnWeddingList
                btnWeddingList.Visible = true;
            }
            else
            {
                // Else hide btnWeddingList
                btnWeddingList.Visible = false;
            }

            // Refresh customers in dgvCustomers
            RefreshCustomers();
            
        }

        private void btnWeddingList_Click(object sender, EventArgs e)
        {
            if (SelectedCustomer != null)
            {
                if (btnWeddingList.Text == "Update Wedding List")
                {
                    foreach (WeddingList weddingList in WeddingLists)
                    {
                        if (weddingList.ReferenceName == SelectedCustomer.Name)
                        {
                            if (weddingList.CompletedYN != "Y")
                            {
                                // If wedding list has not been marked as complete open frmWeddingListStock
                                new frmWeddingListStock(weddingList, SelectedCustomer).Show();
                                this.Hide();
                            }
                            else
                            {
                                // Else tell user this wedding list has been marked as complete
                                MessageBox.Show("This wedding list has been marked as complete");
                            }
                        }
                    }
                }
                else if (btnWeddingList.Text == "Create Wedding List")
                {
                    try
                    {
                        // Check that the customer has made a booking
                        Bookings = Booking.GetBooking();

                        bool alreadyBooked = false;

                        foreach (Booking booking in Bookings)
                        {
                            if (booking.CustNo == SelectedCustomer.CustomerNo)
                            {
                                alreadyBooked = true;
                            }

                        }
                        if (alreadyBooked == true)
                        {
                            string referenceName = tbxCustomer.Text.Trim();
                            string completedYN = "N";

                            // Retreive any errors found when trying to make a new wedding list
                            List<string> errors = WeddingList.TryConstructWeddingList(referenceName, completedYN);

                            // Display any errors found
                            if (errors.Count > 0)
                            {
                                string s = String.Join("\n", errors);
                                MessageBox.Show(s);
                                return;
                            }

                            // Create new wedding list
                            WeddingList newWeddingList = new WeddingList(null, null, referenceName, completedYN);

                            newWeddingList.CreateWeddingList();

                            MessageBox.Show("Wedding List successfully created");

                            dgvCustomers.ClearSelection();
                        }
                        else
                        {
                            // Error message if customer hasn't made a booking
                            MessageBox.Show("A booking must be made for this customer before you can create a wedding list");
                        }
                    }
                    catch (SqlException)
                    {
                        // Error message if new wedding list could not be made
                        MessageBox.Show("An error has happened when trying to create a new Wedding List", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            else
            {
                // Error message if no customer is selected
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
        private bool RefreshCustomers()
        {
            try
            {
                finished = false;
                dgvCustomers.Rows.Clear();

                // Get customers
                List<Customer> updatedCustomers = Customer.GetCustomers();
                Customers = updatedCustomers;

                // SQL Join to select customers who have made a booking
                DatabaseConnection.OpenConnection();
                SqlCommand command = new SqlCommand("Get_Booking_Join", DatabaseConnection.myConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Read in fields and assign them to variables
                    int custNo = Convert.ToInt32(reader["CustNo"]);
                    string custName = Convert.ToString(reader["CustName"]);
                    string custAddress1 = Convert.ToString(reader["CustAddress1"]);
                    string custAddress2 = Convert.ToString(reader["CustAddress2"]);
                    string custPostcode = Convert.ToString(reader["CustPostcode"]);
                    string custPhone = Convert.ToString(reader["CustPhone"]);
                    string custEmail = Convert.ToString(reader["CustEmail"]);
                    int bookingNo = Convert.ToInt32(reader["BookingNo"]);
                    DateTime dateOfBooking = Convert.ToDateTime(reader["DateOfBooking"]);

                    if (dateOfBooking.Date == dtpDate.Value.Date)
                    {
                        // Add customer to dgvCustomers if they have made a booking for today
                        dgvCustomers.Rows.Add(custNo, custName, custAddress1, custAddress2, custPostcode, custPhone, custEmail);

                    }
                }
                reader.Close();
                finished = true;

                // Clear selection and reset tbxCustomer
                dgvCustomers.ClearSelection();
                tbxCustomer.Text = String.Empty;

                return true;
            }
            catch (SqlException)
            {
                // Error message if Customer table cannot be accessed
                MessageBox.Show("Could not get customers", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            // Break out of method if no customer has been selected
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                DataGridViewRow selectedRow = dgvCustomers.SelectedRows[0];
                int custNo = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());

                // Add currently selected customer name to tbxCustomer
                foreach (Customer customer in Customers)
                {
                    if (customer.CustomerNo == custNo)
                    {
                        tbxCustomer.Text = customer.Name;
                    }
                }
            }
            // Set btnWeddingList text to "Create Wedding List"
            btnWeddingList.Text = "Create Wedding List";

            if (finished == true)
            {
                // If SQL Join has finished reading in then get wedding lists
                WeddingLists = WeddingList.GetWeddingList();
            }
            if (SelectedCustomer != null)
            {
                foreach (WeddingList weddingList in WeddingLists)
                {
                    // If customer has already made a wedding list change btnWeddingList text to "Update Wedding List"
                    if (weddingList.ReferenceName == SelectedCustomer.Name)
                    {
                        btnWeddingList.Text = "Update Wedding List";
                    }
                }
            }
        }

        private void frmViewBookings_Shown(object sender, EventArgs e)
        {
            // If Customer table cannot be accessed direct user back to frmWelcome
            if (!RefreshCustomers())
            {
                this.Close();
                Form frmWelcome = new frmWelcome();
                frmWelcome.Show();
            }
        }
    }
}
