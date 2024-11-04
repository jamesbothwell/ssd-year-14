using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA
{
    public partial class frmStock : Form
    {
        // Declare any lists or variables to be used in the script
        private List<Stock> Stocks = new List<Stock>();
        private bool imageSelected;
        public frmStock()
        {
            InitializeComponent();

            btnClear.Enabled = false;
        }
        // Set the selected item of stock based on cbxStock selected index
        private Stock SelectedStock
        {
            get
            {
                if (cbxStock.SelectedIndex > 0)
                {
                    return Stocks[cbxStock.SelectedIndex - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            // Hide "Out of Order" label
            lblOutOfStock.Visible = false;
        }

        private void btnCreateStock_Click(object sender, EventArgs e)
        {
            // Get input from textboxes
            string desc = tbxDescription.Text.Trim();
            string category = tbxCategory.Text.Trim();
            decimal price;
            decimal sellingPrice;
            int qty;
            
            try
            {
                // Try and convert input in tbxPrice to decimal
                price = Convert.ToDecimal(tbxPrice.Text.Trim());
            }
            catch 
            {
                // Error message if failed
                MessageBox.Show("You must enter a valid price");
                return;
            }
            try
            {
                // Try and convert input in tbxSellingPrice to decimal
                sellingPrice = Convert.ToDecimal(tbxSellingPrice.Text.Trim());
            }
            catch
            {
                // Error message if failed
                MessageBox.Show("You must enter a valid selling price");
                return;
            }
            try
            {
                // Try and convert input in tbxQuantity to int
                qty = Convert.ToInt32(tbxQuantity.Text.Trim());
            }
            catch
            {
                // Error message if failed
                MessageBox.Show("You must enter a valid quantity");
                return;
            }
            if (pbxPreview.ImageLocation == "")
            {
                foreach (Stock stock in Stocks)
                {
                    pbxPreview.ImageLocation = stock.Image;
                }
            }

            // Store any errors encountered when trying to create a new item of stock
            List<string> errors = Stock.TryConstructStock(desc, category, price, sellingPrice, qty, pbxPreview.ImageLocation);

            // Display any errors in a message box
            if (errors.Count > 0)
            {
                string s = String.Join("\n", errors);
                MessageBox.Show(s);
                return;
            }

            // Create new stock object
            Stock newStock = new Stock(null, desc, category, price, sellingPrice, qty, pbxPreview.ImageLocation);

            // If btnCreateUpdate text says "Create" create a new item of stock and refresh stock
            if (btnCreateUpdate.Text == "Create")
            {
                try
                {
                    newStock.CreateStock();
                    RefreshStock();
                }
                catch (SqlException)
                {
                    // Error message if new item of stock cannot be added to the database
                    MessageBox.Show("An error has happened when trying to create stock.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            // Otherwise update the details of an existing item of stock
            else
            {
                try
                {
                    newStock.UpdateStock((int)SelectedStock.StockNo);
                    RefreshStock();
                }
                catch (SqlException ex)
                {
                    // Error message if item of stock cannot be updated in the database
                    MessageBox.Show("An error has happened when trying to update stock." + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            // If no stock is selected break out of method
            if (dgvStock.SelectedRows.Count == 0)
            {
                return;
            }
            // If stock is selected change the selected index of cbxStock to this item of stock
            else
            {
                DataGridViewRow selectedRow = dgvStock.SelectedRows[0];
                int stockNo = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());

                for (int i = 0; i < Stocks.Count; i++)
                {
                    if (Stocks[i].StockNo == stockNo)
                    {
                        cbxStock.SelectedIndex = i + 1;
                    }
                }
            }
        }
        private bool RefreshStock()
        {
            try
            {
                // Get all stock and store in a list
                List<Stock> updatedStock = Stock.GetStock();
                Stocks = updatedStock;

                // Clear all textboxes
                tbxDescription.Text = String.Empty;
                tbxCategory.Text = String.Empty;
                tbxPrice.Text = String.Empty;
                tbxSellingPrice.Text = String.Empty;
                tbxQuantity.Text = String.Empty;
                btnCreateUpdate.Text = "Create";

                // Clear all stock item names in cbxStock and stock in dgvStock
                cbxStock.Items.Clear();
                dgvStock.Rows.Clear();

                cbxStock.Items.Add("{create new}");

                foreach (Stock stock in Stocks)
                {
                    // Add stock description to cbxStock
                    cbxStock.Items.Add(stock.Desc);
                    // Add stock details to dgvStock
                    dgvStock.Rows.Add(stock.StockNo, stock.Desc, stock.Category, stock.Price, stock.SellingPrice, stock.Qty);
                }
                // Set selected index of cbxStock to "{create new}"
                cbxStock.SelectedIndex = 0;
                // Clear selection in dgvStock
                dgvStock.ClearSelection();

                return true;
            }
            catch (SqlException)
            {
                // Error message if database connection to stock table cannot be made
                MessageBox.Show("Could not get stock", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void frmStock_Shown(object sender, EventArgs e)
        {
            // If a successful connection to the Stock table in the database cannot be made return the user to frmWelcome
            if (!RefreshStock())
            {
                this.Close();
                Form frmWelcome = new frmWelcome();
                frmWelcome.Show();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear tbxSearch on click
            tbxSearch.Text = String.Empty;
        }

        private void cbxStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear selection in dgvStock
            dgvStock.ClearSelection();

            // If a selection has been made in cbxStock make sure the same selection is made in dgvStock
            if (SelectedStock != null)
            {
                foreach (DataGridViewRow row in dgvStock.Rows)
                {
                    if (String.Format("{0}", SelectedStock.StockNo) == row.Cells[0].Value.ToString())
                    {
                        row.Selected = true;
                    }
                }
            }
            RefreshFields();
        }
        private void RefreshFields()
        {
            // If an item of stock has been selected set btnCreateUpdate text to "Update"
            if (SelectedStock != null)
            {
                btnCreateUpdate.Text = "Update";

                //Populate all textboxes with stock details
                tbxDescription.Text = SelectedStock.Desc;
                tbxCategory.Text = SelectedStock.Category;
                tbxPrice.Text = Convert.ToString(SelectedStock.Price);
                tbxSellingPrice.Text = Convert.ToString(SelectedStock.SellingPrice);
                tbxQuantity.Text = Convert.ToString(SelectedStock.Qty);
                pbxPreview.ImageLocation = SelectedStock.Image;

                // Hide the "Out of Stock" label
                lblOutOfStock.Visible = false;

                // If an item of stock has a quantity of 0 show the "Out of Stock" label
                if (tbxQuantity.Text == "0")
                {
                    lblOutOfStock.Visible = true;
                }
            }
            // If an item of stock has not been selected clear all textboxes in preparation for new stock to be created
            else
            {
                btnCreateUpdate.Text = "Create";

                imageSelected = false;

                tbxDescription.Text = String.Empty;
                tbxCategory.Text = String.Empty;
                tbxPrice.Text = String.Empty;
                tbxSellingPrice.Text = String.Empty;
                tbxQuantity.Text = String.Empty;
                pbxPreview.Image = null;
            }
        }
        private void SearchStock()
        {
            // Store input in tbxSearch in a search string
            string searchString = tbxSearch.Text.Trim().ToLower();

            // Refresh all stock to make sure the search results are for the most up to date stock
            RefreshStock();

            // If there has been no input disable btnClear and clear stock selection
            if (String.IsNullOrWhiteSpace(searchString))
            {
                btnClear.Enabled = false;
                dgvStock.ClearSelection();
                cbxStock.SelectedIndex = 0;
            }
            // If there has been input search for stock
            else
            {
                try
                {
                    // Store a list of search results
                    List<Stock> searchResults = Stock.GetStockFromSearch(searchString);

                    // Clear dgvStock
                    dgvStock.Rows.Clear();

                    // Add any stock in the search results to dgvStock
                    foreach (Stock stock in searchResults)
                    {
                        dgvStock.Rows.Add(stock.StockNo, stock.Desc, stock.Category, stock.Price, stock.SellingPrice, stock.Qty);
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

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // Search for stock if the user types in tbxSearch
            SearchStock();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Return the user to frmWelcome on click
            this.Close();
            Form frmWelcome = new frmWelcome();
            frmWelcome.Show();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            // Open up the file browser on click so user can add an image for the stock
            ofdStock.ShowDialog();
            pbxPreview.ImageLocation = ofdStock.FileName;

            if (btnCreateUpdate.Text == "Create")
            {
                imageSelected = true;
            }
        }

        
    }
}
