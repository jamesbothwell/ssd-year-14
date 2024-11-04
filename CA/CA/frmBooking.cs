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
using System.Globalization;


namespace CA
{
    public partial class frmBooking : Form
    {
        // Declare any lists or variables to be used in the script
        Customer selectedCustomer = null;
        Staff selectedStaff = null;
        private List<Staff> Staffs = new List<Staff>();
        public frmBooking()
        {
            InitializeComponent();
        }
        public frmBooking(Customer CustomerPassedIn)
        {
            // Assign customer passed in to a variable
            InitializeComponent();
            selectedCustomer = CustomerPassedIn;
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            // Display customer name in tbcCustomer and ensure dtpDate starts from one day after today
            DateTime today = DateTime.Now;
            tbxCustomer.Text = selectedCustomer.Name;
            dtpDate.MinDate = today.AddDays(1);
            
            
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            // Populate cbxTime with availabel slots
            PopulateAvailability(dtpDate.Value);
        }
        private bool RefreshStaff()
        {
            try
            {
                // Get staff from Staff table
                List<Staff> updatedStaff = Staff.GetStaff();
                Staffs = updatedStaff;

                // Switch statement to assign staff to a time slot
                switch (cbxTime.Text)
                {
                      
                    case "09:00 - 10:00":
                        selectedStaff = Staffs[0];
                        lblStaffMember.Text = Convert.ToString(selectedStaff.Name);
                        break;
                    case "10:00 - 11:00":
                        selectedStaff = Staffs[1];
                        lblStaffMember.Text = Convert.ToString(selectedStaff.Name);
                        break;
                    case "11:00 - 12:00":
                        selectedStaff = Staffs[2];
                        lblStaffMember.Text = Convert.ToString(selectedStaff.Name);
                        break;
                    case "12:00 - 13:00":
                        selectedStaff = Staffs[3];
                        lblStaffMember.Text = Convert.ToString(selectedStaff.Name);
                        break;
                    case "13:00 - 14:00":
                        selectedStaff = Staffs[4];
                        lblStaffMember.Text = Convert.ToString(selectedStaff.Name);
                        break;
                    case "14:00 - 15:00":
                        selectedStaff = Staffs[5];
                        lblStaffMember.Text = Convert.ToString(selectedStaff.Name);
                        break;
                    case "15:00 - 16:00":
                        selectedStaff = Staffs[6];
                        lblStaffMember.Text = Convert.ToString(selectedStaff.Name);
                        break;
                    default:
                        // Default if no time slot selected
                        lblStaffMember.Text = "No time selected yet";
                        break;
                }

                return true;
            }
            catch (SqlException)
            {
                // Error message if database connection cannot be made to Staff table
                MessageBox.Show("Could not get staff", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void PopulateAvailability(DateTime date)
        {
            // Clear cbxTime
            cbxTime.Items.Clear();

            // List of available time slots
            List<String> AvailableSlots = new List<String>
            {
                "09:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "12:00 - 13:00", "13:00 - 14:00", "14:00 - 15:00", "15:00 - 16:00",
            };
            DatabaseConnection.OpenConnection();
            SqlCommand command = new SqlCommand("Check_Availability", DatabaseConnection.myConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@SelectedDate", date));

            SqlDataReader reader = command.ExecuteReader();

            // Remove unavailable time slots
            while (reader.Read())
            {
                string slot = reader["Slot"].ToString();
                AvailableSlots.Remove(slot);
            }

            DatabaseConnection.CloseConnection();

            // Add available time slots to cbxTime
            foreach(var slot in AvailableSlots)
            {
                cbxTime.Items.Add(slot);
            }
        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            if (cbxTime.SelectedIndex == -1)
            {

                // Error message if no time slot has been selected
                MessageBox.Show("Booking unsuccessful - please select a time");
            }
            else
            {
                // Store assigned staff number
                int staffNo = Convert.ToInt32(selectedStaff.StaffNo);
                // Store customer number
                int custNo = (int)selectedCustomer.CustomerNo;

                // Create a new booking
                Booking newBooking = new Booking(null, dtpDate.Value, cbxTime.SelectedItem.ToString(), custNo, staffNo);
                newBooking.CreateBooking();

                PopulateAvailability(dtpDate.Value);
                // Tell user booking was successful and disable btnBook
                MessageBox.Show("Booking successful");
                btnBook.Enabled = false;
            }
        }
        private void frmBooking_Shown(object sender, EventArgs e)
        {
            // If Staff table cannot be accessed direct user back to frmCustomer
            if (!RefreshStaff())
            {
                this.Close();
                Form frmCustomer = new frmCustomer();
                frmCustomer.Show();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Return user to frmCustomer on click
            this.Close();
            Form frmCustomer = new frmCustomer();
            frmCustomer.Show();
        }

        private void cbxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assign different staff member when cbxTime selected index changes
            RefreshStaff();
        }
    }
}
