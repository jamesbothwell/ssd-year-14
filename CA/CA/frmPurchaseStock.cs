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
    public partial class frmPurchaseStock : Form
    {
        // Declare any lists or variables to be used in the script
        private List<Stock> Stocks = new List<Stock>();
        CustomerOrder selectedCustomerOrder = null;
        Customer selectedCustomer = null;
        private int total;
        private int newQuantity;
        private int finalQuantity;

        public frmPurchaseStock()
        {
            InitializeComponent();
        }
        public frmPurchaseStock(CustomerOrder CustomerOrderPassedIn, Customer CustomerPassedIn)
        {
            // Assign the customer and  customer order passed in to variables
            InitializeComponent();
            selectedCustomerOrder = CustomerOrderPassedIn;
            selectedCustomer = CustomerPassedIn;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Return user to frmCustomer screen on click
            this.Close();
            Form frmCustomer = new frmCustomer();
            frmCustomer.Show();
        }

        private void frmPurchaseStock_Load(object sender, EventArgs e)
        {
            // Set the text of tbxCustomer to the name of the customer passed in
            tbxCustomer.Text = selectedCustomer.Name;
            // Clear the text of tbxItemSelected
            tbxItemSelected.Text = "";
        }
        private bool RefreshStock()
        {
            try
            {
                // Get the stock from the Stock table in the database
                List<Stock> updatedStock = Stock.GetStock();
                Stocks = updatedStock;

                //Clear dgvStock
                dgvStock.Rows.Clear();

                // Add updated stock to dgvStock
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

        private void frmPurchaseStock_Shown(object sender, EventArgs e)
        {
            // If Stock table cannot be accessed direct user back to frmCustomer
            if (!RefreshStock())
            {
                this.Close();
                Form frmCustomer = new frmCustomer();
                frmCustomer.Show();
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // Search for stock when text changed
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
                // If no search made disable btnClear
                btnClear.Enabled = false;
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
            // If no selection made then break out of method
            if (dgvStock.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                // Get selected row
                DataGridViewRow selectedRow = dgvStock.SelectedRows[0];
                int stockNo = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());

                for (int i = 0; i < Stocks.Count; i++)
                {
                    if (Stocks[i].StockNo == stockNo)
                    {
                        // Update tbxItemSelected and pbxPreview with details of the selected item of stock
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
                // Assign the currently selected item of stock to the Stock object
                if (string.IsNullOrEmpty(tbxItemSelected.Text))
                {
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

                        // Check if quantity enetered is an integer
                        try
                        {
                            qty = Convert.ToInt32(tbxQuantity.Text);
                            success = true;
                        }
                        // If not then display error message
                        catch
                        {
                            MessageBox.Show("You must enter a valid quantity");
                            success = false;
                            return;
                        }
                        // Check that quantity is greater than 0 and it is less than or equal to the quantity available
                        if (qty <= Convert.ToInt32(stock.Qty) && success == true && qty > 0)
                        {
                            dgvCart.Rows.Add(stock.StockNo, stock.Desc, stock.SellingPrice, tbxQuantity.Text);
                            // Update the total
                            total = total + (Convert.ToInt32(stock.SellingPrice) * Convert.ToInt32(tbxQuantity.Text));

                            foreach (DataGridViewRow row in dgvStock.Rows)
                            {
                                int currentStockNo = Convert.ToInt32(row.Cells[0].Value);

                                if (stock.StockNo == currentStockNo)
                                {
                                    newQuantity = Convert.ToInt32(row.Cells[4].Value) - Convert.ToInt32(tbxQuantity.Text);
                                    row.Cells[4].Value = newQuantity;

                                }
                            }
                        }
                        else
                        {
                            // Error message
                            MessageBox.Show("Invalid quantity entered");
                        }
                    }
                }
                // Clear selection and reset text boxes
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
                // Check if user has added stock to cart or not
                if (dgvCart.Rows.Count == 0)
                {
                    // If not display error message
                    MessageBox.Show("You must add stock to the cart before completing a purchase");
                }
                else
                {
                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        // Create new CustomerOrderStock
                        CustomerOrderStock newCustomerOrderStock = new CustomerOrderStock(Convert.ToInt32(selectedCustomerOrder.OrderNo), Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(row.Cells[3].Value));
                        newCustomerOrderStock.CreateCustomerOrderStock();

                        int currentStockNo = Convert.ToInt32(row.Cells[0].Value);

                        foreach (Stock stock in Stocks)
                        {
                            if (stock.StockNo == currentStockNo)
                            {
                                finalQuantity = Convert.ToInt32(stock.Qty) - Convert.ToInt32(row.Cells[3].Value);

                                int qty = finalQuantity;

                                // Get any errors when trying to update stock
                                List<string> errors = Stock.TryConstructStock(stock.Desc, stock.Category, stock.Price, stock.SellingPrice, qty, stock.Image);

                                // Display any errors returned
                                if (errors.Count > 0)
                                {
                                    string s = String.Join("\n", errors);
                                    MessageBox.Show(s);
                                    return;
                                }

                                // Create new stock object
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
                                    MessageBox.Show("An error has happened when trying to update stock." + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // Error message if purchase could not be made
                MessageBox.Show("Could not complete purchase", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear tbxSearch
            tbxSearch.Text = String.Empty;
        }

        private void lblTotalIs_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
