using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {                       
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            // Take user to frmCustomer on click
            this.Close();
            Form frmCustomer = new frmCustomer();
            frmCustomer.Show();
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            // Take user to frmStock on click
            this.Close();
            Form frmStock = new frmStock();
            frmStock.Show();
        }

        private void btnWeddingList_Click(object sender, EventArgs e)
        {
            // Take user to frmWeddingListPurchase on click 
            this.Close();
            Form frmWeddingListPurchase = new frmWeddingListPurchase();
            frmWeddingListPurchase.Show();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            // Take user to frmViewBookings on click
            this.Close();
            Form frmViewBookings = new frmViewBookings();
            frmViewBookings.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Return user to frmMenu on click
            this.Close();
            Form frmMenu = new frmMenu();
            frmMenu.Show();
        }
    }
}
