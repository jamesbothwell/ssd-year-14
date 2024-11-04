using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA
{
    public partial class frmWeddingListStock : Form
    {
        // Declare any lists or variables to be used in the script
        private List<Stock> Stocks = new List<Stock>();
        private List<WeddingListStock> WeddingListStocks = new List<WeddingListStock>();
        WeddingList selectedWeddingList = null;
        Customer selectedCustomer = null;
        private int total;
        private int newQuantity;
        private int finalQuantity;
        public frmWeddingListStock()
        {
            InitializeComponent();
        }
        public frmWeddingListStock(WeddingList WeddingListPassedIn, Customer CustomerPassedIn)
        {
            // Assign the customer and  wedding list passed in to variables
            InitializeComponent();
            selectedWeddingList = WeddingListPassedIn;
            selectedCustomer = CustomerPassedIn;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Return user to the frmViewBookings on click
            this.Close();
            Form frmViewBookings = new frmViewBookings();
            frmViewBookings.Show();
        }
        private void frmWeddingList_Load(object sender, EventArgs e)
        {
            // Set tbxCustomer text to name of customer making wedding list
            tbxCustomer.Text = selectedWeddingList.ReferenceName;
            // Clear tbxItemSelected
            tbxItemSelected.Text = "";
        }
        private bool RefreshStock()
        {
            try
            {
                // Get stock from Stock table in database
                List<Stock> updatedStock = Stock.GetStock();
                Stocks = updatedStock;

                // Clear dgvStock
                dgvStock.Rows.Clear();

                // Add stock to dgvStock
                foreach (Stock stock in Stocks)
                {
                    if (stock.Qty != 0)
                    {
                        dgvStock.Rows.Add(stock.StockNo, stock.Desc, stock.Category, stock.SellingPrice, stock.Qty);
                    }
                }

                // Clear selection
                dgvStock.ClearSelection();

                return true;
            }
            catch (SqlException)
            {
                // Error message if Stock table cannot be accessed
                MessageBox.Show("Could not get stock", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void frmWeddingList_Shown(object sender, EventArgs e)
        {
            // Direct user back to frmViewBookings if Stock table cannot be accessed
            if (!RefreshStock())
            {
                this.Close();
                Form frmViewBookings = new frmViewBookings();
                frmViewBookings.Show();
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // Search for stock when user types in tbxSearch
            SearchStock();
        }
        private void SearchStock()
        {
            // Store input in a search string
            string searchString = tbxSearch.Text.Trim().ToLower();

            // Refresh stock
            RefreshStock();

            if (String.IsNullOrWhiteSpace(searchString))
            {
                // Disable btnClear
                btnClear.Enabled = false;
                // Clear selection
                dgvStock.ClearSelection();
            }
            else
            {
                try
                {
                    // Store search results in a list
                    List<Stock> searchResults = Stock.GetStockFromSearch(searchString);

                    // Clear dgvStock
                    dgvStock.Rows.Clear();

                    // Add search results to dgvStock
                    foreach (Stock stock in searchResults)
                    {
                        dgvStock.Rows.Add(stock.StockNo, stock.Desc, stock.Category, stock.SellingPrice, stock.Qty);
                    }

                    // Enable btnClear
                    btnClear.Enabled = true;
                }
                catch (SqlException)
                {
                    return;
                }
            }
        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            // If not stock has been selected break out of method
            if (dgvStock.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                DataGridViewRow selectedRow = dgvStock.SelectedRows[0];
                int stockNo = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());

                for (int i = 0; i < Stocks.Count; i++)
                {
                    if (Stocks[i].StockNo == stockNo)
                    {
                        // Update tbxItemSelected and pbxPreview with details of selected stock
                        tbxItemSelected.Text = Stocks[i].Desc;
                        pbxPreview.ImageLocation = Stocks[i].Image;
                    }
                }
            }
        }
        private Stock SelectedStock
        {
            get
            {
                if (string.IsNullOrEmpty(tbxItemSelected.Text))
                {
                    // Assign selected stock to the Stock object
                    DataGridViewRow selectedRow = dgvStock.SelectedRows[0];
                    int stockNo = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                    return Stocks[stockNo];
                }
                else
                {
                    return null;
                }
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Stock stock in Stocks)
                {
                    if (stock.Desc == tbxItemSelected.Text)
                    {
                        int qty;
                        bool success;

                        try
                        {
                            // Check if quantity is an integer
                            qty = Convert.ToInt32(tbxQuantity.Text);
                            success = true;
                        }
                        catch
                        {
                            // Error message if it is not an integer
                            MessageBox.Show("You must enter a valid quantity");
                            success = false;
                            return;
                        }
                        // Check quantity is greater than 0 and that quantity is less than or equal to the quantity available
                        if (qty <= Convert.ToInt32(stock.Qty) && success == true  && qty > 0)
                        {
                            // Add to cart
                            dgvCart.Rows.Add(stock.StockNo, stock.Desc, stock.SellingPrice, tbxQuantity.Text);
                            // Update total
                            total = total + (Convert.ToInt32(stock.SellingPrice) * Convert.ToInt32(tbxQuantity.Text));

                            foreach (DataGridViewRow row in dgvStock.Rows)
                            {
                                int currentStockNo = Convert.ToInt32(row.Cells[0].Value);

                                if (stock.StockNo == currentStockNo)
                                {
                                    // Update stock quantity
                                    newQuantity = Convert.ToInt32(row.Cells[4].Value) - Convert.ToInt32(tbxQuantity.Text);
                                    row.Cells[4].Value = newQuantity;
 
                                }
                            }
                        }
                        else
                        {
                            // Error message if stock cannot be added to cart
                            MessageBox.Show("Invalid quantity entered");
                        }
                    }
                }
                // Clear selection and text boxes
                dgvStock.ClearSelection();
                tbxItemSelected.Text = String.Empty;
                tbxQuantity.Text = String.Empty;
                // Display new total
                lblTotal.Text = Convert.ToString(total);
            }
            catch (SqlException)
            {
                // Error message if stock could not be added to cart
                MessageBox.Show("Could not add to cart", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCompletePurchase_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCart.Rows.Count == 0)
                {
                    // Error message if there is no stock in the cart
                    MessageBox.Show("You must add stock to the cart before adding to a wedding list");
                }
                else
                {
                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        // Create new WeddingListStock
                        WeddingListStock newWeddingListStock = new WeddingListStock(Convert.ToInt32(selectedWeddingList.OrderNo), Convert.ToInt32(selectedCustomer.CustomerNo), Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(row.Cells[3].Value));
                        newWeddingListStock.CreateWeddingListStock();

                        int currentStockNo = Convert.ToInt32(row.Cells[0].Value);

                        foreach (Stock stock in Stocks)
                        {
                            if (stock.StockNo == currentStockNo)
                            {
                                finalQuantity = Convert.ToInt32(stock.Qty) - Convert.ToInt32(row.Cells[3].Value);

                                int qty = finalQuantity;

                                // Retrieve any errors occured when trying to update stock
                                List<string> errors = Stock.TryConstructStock(stock.Desc, stock.Category, stock.Price, stock.SellingPrice, qty, stock.Image);

                                // Display any errors returned
                                if (errors.Count > 0)
                                {
                                    string s = String.Join("\n", errors);
                                    MessageBox.Show(s);
                                    return;
                                }

                                Stock newStock = new Stock(null, stock.Desc, stock.Category, stock.Price, stock.SellingPrice, qty, stock.Image);



                                try
                                {
                                    // Update stock with new quantity
                                    newStock.UpdateStock((int)stock.StockNo);
                                    RefreshStock();
                                }
                                catch (SqlException ex)
                                {
                                    // Error message if stock cannot be updated
                                    MessageBox.Show("An error has happened when trying to update stock" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                            }
                        }



                    }
                    // Clear selection and reset text boxes, as well as total
                    dgvCart.ClearSelection();
                    dgvCart.Rows.Clear();
                    tbxItemSelected.Text = String.Empty;
                    tbxQuantity.Text = String.Empty;
                    total = 0;
                    lblTotal.Text = "0";
                }
            }
            catch (SqlException)
            {
                // Error message if stock could not be added to wedding list
                MessageBox.Show("Could not add to wedding list", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear tbxSearch
            tbxSearch.Text = String.Empty;
        }

        private void btnMarkAsComplete_Click(object sender, EventArgs e)
        {
            try
            {
                List<WeddingListStock> updatedWeddingListStock = WeddingListStock.GetWeddingListStock();
                WeddingListStocks = updatedWeddingListStock;
                int totalStockInList = 0;

                foreach (WeddingListStock weddingListStock in WeddingListStocks)
                {
                    if (weddingListStock.OrderNo == selectedWeddingList.OrderNo)
                    {
                        totalStockInList++;
                    }
                }

                if (totalStockInList == 0)
                {
                    // Ensure you cannot mark a blank wedding list as complete
                    MessageBox.Show("You must select stock before this wedding list can be marked as complete");
                }
                else
                {
                    // Retreive any errors occured when trying to update Wedding List
                    List<string> errors = WeddingList.TryConstructWeddingList(Convert.ToString(selectedWeddingList.ReferenceName), "Y");

                    // Display any errors returned
                    if (errors.Count > 0)
                    {
                        string s = String.Join("\n", errors);
                        MessageBox.Show(s);
                        return;
                    }

                    // Update wedding list so CompletedYN is Y
                    WeddingList newWeddingList = new WeddingList(null, selectedWeddingList.DateOfOrder, Convert.ToString(selectedWeddingList.ReferenceName), "Y");

                    newWeddingList.UpdateWeddingList((int)selectedWeddingList.OrderNo);

                    // Return user to frmBookings
                    MessageBox.Show("Wedding list successfully marked as complete");
                    this.Close();
                    Form frmViewBookings = new frmViewBookings();
                    frmViewBookings.Show();
                }
            }
            catch (SqlException ex)
            {
                // Error message if wedding list cannot be marked as complete
                MessageBox.Show("An error has happened when trying to mark wedding list as complete" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
