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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnOfficeRentals_Click(object sender, EventArgs e)
        {
            // Display an error when trying to access Office Rentals
            MessageBox.Show("Office and conference facility rental is currently unavailable");
        }

        private void btnWeddingHire_Click(object sender, EventArgs e)
        {
            // Display an error when trying to access Wedding Hire
            MessageBox.Show("Wedding dresses/bridge/bridesmaids, wedding suits, mother of the bride outfits, available for purchase hire is currently unavailable");
        }

        private void btnDressmakingAlterations_Click(object sender, EventArgs e)
        {
            // Display an error when trying to access Dressmaking Alterations
            MessageBox.Show("Dressmaking and alterations is currently unavailable");
        }

        private void btnCosmeticBeautyServices_Click(object sender, EventArgs e)
        {
            // Display an error when trying to access Cosmetic Beauty Services
            MessageBox.Show("Cosmetics and beauty services is currently unavailable");
        }

        private void btnHouseholdGoods_Click(object sender, EventArgs e)
        {
            // Take user to frmWelcome on click - the Household Goods section of the system
            this.Hide();
            Form frmWelcome = new frmWelcome();
            frmWelcome.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
