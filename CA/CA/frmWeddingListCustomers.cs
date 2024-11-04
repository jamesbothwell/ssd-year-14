using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA
{
    public partial class frmWeddingListCustomers : Form
    {
        // Declare any lists and variables to be used in the script
        int currentOrderNo;
        private List<Customer> Customers = new List<Customer>();
        private List<WeddingListPurchase> WeddingListPurchases = new List<WeddingListPurchase>();
        public frmWeddingListCustomers()
        {
            InitializeComponent();
        }
        public frmWeddingListCustomers(int OrderNoPassedIn)
        {
            InitializeComponent();
            currentOrderNo = OrderNoPassedIn;
        }

        private void btnCreateUpdate_Click(object sender, EventArgs e)
        {
            // Close the pop-up
            this.Close();
        }

        private void frmBoughtFromWeddingList_Load(object sender, EventArgs e)
        {
            
        }
        private bool RefreshCustomers()
        {
            try
            {
                // Get WeddingListPurchases
                List<WeddingListPurchase> updatedWeddingListPurchases = WeddingListPurchase.GetWeddingListPurchase();
                WeddingListPurchases = updatedWeddingListPurchases;

                int noOfCustomers = 0;

                // SQL Join to get customer names of customers who have made a purchase from the currently selected wedding list

                DatabaseConnection.OpenConnection();
                SqlCommand command = new SqlCommand("Get_WeddingListPurchase_Join", DatabaseConnection.myConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int custNo = Convert.ToInt32(reader["CustNo"]);
                    string name = Convert.ToString(reader["CustName"]);

                    foreach (WeddingListPurchase weddingListPurchase in WeddingListPurchases)
                    {
                        if (currentOrderNo == weddingListPurchase.OrderNo && weddingListPurchase.CustNo == custNo)
                        {
                            if (!lblCustomers.Text.Contains(name))
                            {
                                // Display the names of any customers who have bought from the currently selected wedding list in lblCustomers
                                lblCustomers.Text = lblCustomers.Text + $"{Convert.ToString(name)}\n";
                                noOfCustomers++;
                            }
                        }
                    }
                }
                reader.Close();

                if (noOfCustomers == 0)
                {
                    // Default message to be displayed in lblCustomers if no customers have bought from the currently selected wedding list
                    lblCustomers.Text = "No customers have bought from this wedding list yet";
                }

                return true;
            }
            catch (SqlException)
            {
                // Error message if a database connection could not be made
                MessageBox.Show("Could not get customers", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void frmWeddingListCustomers_Shown(object sender, EventArgs e)
        {
            // Close the pop-up if the method RefreshCustomers cannot be executed
            if (!RefreshCustomers())
            {
                this.Close();
            }
        }

        private void pnlStock_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
