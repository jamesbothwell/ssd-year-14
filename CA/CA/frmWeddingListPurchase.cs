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
using System.IO;
using System.Diagnostics;

namespace CA
{
    public partial class frmWeddingListPurchase : Form
    {
        // Declare any lists and variables used in the script
        private List<Customer> Customers = new List<Customer>();
        private List<WeddingListStock> WeddingListStocks = new List<WeddingListStock>();
        private List<WeddingListStock> DeletedWeddingListStocks = new List<WeddingListStock>();
        private List<Stock> Stocks = new List<Stock>();
        private List<WeddingList> WeddingLists = new List<WeddingList>();
        private int currentOrderNo;
        private int currentBuyingForNo;
        private int currentBuyingAsNo;
        private int total;
        private int newQuantity;
        private int finalQuantity;
        private int currentQuantityAvailable;
        public frmWeddingListPurchase()
        {
            InitializeComponent();
        }

        private void cbxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear selection
            dgvStock.ClearSelection();
            dgvStock.Rows.Clear();
            // Remove customer selected in cbxBuyingFor from
            RemoveFromBuying();

            // Display the wedding list in dgvStock for the customer selected in cbxBuyingFor
            if (cbxBuyingFor.SelectedIndex != -1)
            {
                RefreshStock();
            }
            else
            {
                // Error if no customer selected in cbxBuyingFor
                MessageBox.Show("Please select a customer to buy from first", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void RefreshStock()
        {
            try
            {
                // Get WeddingListStock
                List<WeddingListStock> updatedWeddingListStocks = WeddingListStock.GetWeddingListStock();
                WeddingListStocks = updatedWeddingListStocks;

                int selectedOrder = -1;

                // Assign the selected order variable
                foreach (WeddingList weddingList in WeddingLists)
                {
                    if (weddingList.ReferenceName == cbxBuyingFor.Text)
                    {
                        selectedOrder = Convert.ToInt32(weddingList.OrderNo);
                    }
                }

                // SQL Join to select the stock in the currently selected wedding list
                DatabaseConnection.OpenConnection();
                SqlCommand command = new SqlCommand("Get_WeddingListStock_Join", DatabaseConnection.myConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int stockNo = Convert.ToInt32(reader["StockNo"]);
                    string desc = Convert.ToString(reader["StockDesc"]);
                    string category = Convert.ToString(reader["StockCategory"]);
                    string sellingPrice = Convert.ToString(reader["StockSellingPrice"]);
                    string qtyOrdered = Convert.ToString(reader["QtyOrdered"]);
                    int orderNo = Convert.ToInt32(reader["OrderNo"]);

                    foreach (WeddingListStock weddingListStock in WeddingListStocks)
                    {
                        if (weddingListStock.StockNo == stockNo && orderNo == selectedOrder && weddingListStock.OrderNo == selectedOrder)
                        {
                            if (weddingListStock.QtyOrdered != 0)
                            {
                                // If an item of stock in the wedding list has a quantity greater than 0, add this stock to dgvStock
                                dgvStock.Rows.Add(stockNo, desc, category, sellingPrice, qtyOrdered);
                                currentOrderNo = Convert.ToInt32(weddingListStock.OrderNo);
                                currentBuyingForNo = Convert.ToInt32(weddingListStock.CustNo);
                            }
                            else
                            {
                                // Otherwise add the stock to a list of stock to be deleted from the wedding list
                                DeletedWeddingListStocks.Add(weddingListStock);
                            }
                        }
                    }
                }
                reader.Close();

                // Delete any stock in DeletedWeddingListStocks
                foreach (WeddingListStock weddingListStock in DeletedWeddingListStocks)
                {
                    weddingListStock.DeleteWeddingListStock();
                }
                DeletedWeddingListStocks.Clear();

                // Clear selection and reset text boxes
                dgvStock.ClearSelection();
                tbxItemSelected.Text = String.Empty;
                tbxQuantity.Text = String.Empty;
            }
            catch (SqlException)
            {
                // Error message if WeddingListStock  cannot be accessed
                MessageBox.Show("Could not get stock from wedding list", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void SortWeddingListStock()
        {
            // This method takes multiple items of the same stock added at different times to the same wedding list and combines them into one item of stock with an overall quantity

            // Get Stock
            List<Stock> updatedStocks = Stock.GetStock();
            Stocks = updatedStocks;

            // Get WeddingListStock
            List<WeddingListStock> updatedWeddingListStocks = WeddingListStock.GetWeddingListStock();
            WeddingListStocks = updatedWeddingListStocks;

            // Get WeddingLists
            List<WeddingList> updatedWeddingLists = WeddingList.GetWeddingList();
            WeddingLists = updatedWeddingLists;

            int custNo;
            int currentTotal;

            foreach (WeddingList weddingList in WeddingLists)
            {
                // Take an item of stock
                foreach (Stock stock in Stocks)
                {
                    custNo = 0;
                    currentTotal = 0;
                    // Go through all wedding list stock items
                    foreach (WeddingListStock weddingListStock in WeddingListStocks)
                    {
                        if (stock.StockNo == weddingListStock.StockNo && weddingListStock.OrderNo == weddingList.OrderNo)
                        {
                            // Record the overall amount of the same stock in the same wedding list
                            custNo = weddingListStock.CustNo;
                            currentTotal = currentTotal + Convert.ToInt32(weddingListStock.QtyOrdered);

                            try
                            {
                                // Delete the current item stock
                                WeddingListStock oldWeddingListStock = new WeddingListStock(Convert.ToInt32(weddingList.OrderNo), Convert.ToInt32(weddingListStock.CustNo), Convert.ToInt32(stock.StockNo), Convert.ToInt32(weddingListStock.QtyOrdered));
                                oldWeddingListStock.DeleteWeddingListStock();
                            }
                            catch (SqlException)
                            {
                                // Error message if stock cannot be deleted
                                MessageBox.Show("Could not refresh stock", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                        }
                    }
                    if (currentTotal != 0)
                    {
                        try
                        {
                            // If the overall quantity of this stock in the wedding list is greater than 0, add one item of this stock back into the WeddingListStock table with an overall quantity
                            WeddingListStock newWeddingListStock = new WeddingListStock(Convert.ToInt32(weddingList.OrderNo), custNo, Convert.ToInt32(stock.StockNo), currentTotal);
                            newWeddingListStock.CreateWeddingListStock();
                        }
                        catch (SqlException)
                        {
                            // Error message if stock cannot be created
                            MessageBox.Show("Could not refresh stock", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                } 
            }
        }

        private void frmWeddingList2_Load(object sender, EventArgs e)
        {
            try
            {
                // Sort the wedding list stock on load
                SortWeddingListStock();
            }
            catch (SqlException)
            {
                // Error message if wedding list stock cannot be sorted
                MessageBox.Show("Could not refresh stock", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void frmWeddingList2_Shown(object sender, EventArgs e)
        {
            // If cbxBuyingFor cannot be populated direct user back to frmWelcome
            if (!RefreshCustomers())
            {
                this.Close();
                Form frmWelcome = new frmWelcome();
                frmWelcome.Show();
            }
            // If cbxBuyingAs cannot be populated direct user back to frmWelcome
            if (!RefreshBuyingAs())
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
                // Get WeddingListStock
                List<WeddingListStock> updatedWeddingListStocks = WeddingListStock.GetWeddingListStock();
                WeddingListStocks = updatedWeddingListStocks;

                // Clear cbxBuyingFor
                cbxBuyingFor.Items.Clear();

                // get WeddingLists
                List<WeddingList> updatedWeddingLists = WeddingList.GetWeddingList();
                WeddingLists = updatedWeddingLists;

                foreach (WeddingList weddingList in WeddingLists)
                {
                    int noOfItems = 0;
                    foreach (WeddingListStock weddingListStock in WeddingListStocks)
                    {
                        // Record the amount of stock in a wedding list
                        if (weddingListStock.OrderNo == weddingList.OrderNo)
                        {
                            noOfItems++;
                        }
                    }
                    // If there is at least one item in a wedding list and this wedding list has been marked as complete, add the reference name to cbxBuyingFor so customers can purchase stock off this wedding list
                    if (weddingList.CompletedYN == "Y" && noOfItems != 0)
                    {
                        cbxBuyingFor.Items.Add(weddingList.ReferenceName);
                    }
                }

                // Make it so that no customer is selected in cbxBuyingFor
                cbxBuyingFor.SelectedIndex = -1;

                return true;
            }
            catch (SqlException)
            {
                // Error message if cbxBuyingFor could not be populated with wedding list reference names
                MessageBox.Show("Could not get customers", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private bool RefreshBuyingAs()
        {
            try
            {
                // Get Customers
                List<Customer> updatedCustomers = Customer.GetCustomers();
                Customers = updatedCustomers;

                // Clear cbxBuyingAs
                cbxBuyingAs.Items.Clear();

                //Add customer names to cbxBuyingAs
                foreach (Customer customer in Customers)
                {
                        cbxBuyingAs.Items.Add(customer.Name);
                    
                }

                // Make it so that no customer is selected in cbxBuyingAs
                cbxBuyingAs.SelectedIndex = -1;

                return true;
            }
            catch (SqlException)
            {
                // Error message if cbxBuyingAs cannot be populated with customer names
                MessageBox.Show("Could not get customers", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void RemoveFromBuying()
        {
            try
            {
                // Get Customers
                List<Customer> updatedCustomers = Customer.GetCustomers();
                Customers = updatedCustomers;

                // Clear cbxBuyingAs
                cbxBuyingAs.Items.Clear();

                // If the name of the customer whose wedding list is being bought from, hide this customer in cbxBuyingAs
                foreach (Customer customer in Customers)
                {
                    if (cbxBuyingFor.Text != customer.Name)
                    {
                        cbxBuyingAs.Items.Add(customer.Name);
                    }
                }

                cbxBuyingAs.SelectedIndex = 0;

            }
            catch (SqlException)
            {
                // Error message if Customer table cannot be accessed
                MessageBox.Show("Could not get customers", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            // If no stock has been selected break out of the method
            if (dgvStock.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                // Record the current quantity of stock available for this selected item
                DataGridViewRow selectedRow = dgvStock.SelectedRows[0];
                int stockNo = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                currentQuantityAvailable = Convert.ToInt32(selectedRow.Cells[4].Value.ToString());

                for (int i = 0; i < Stocks.Count; i++)
                {
                    if (Stocks[i].StockNo == stockNo)
                    {
                        // Update tbxItemSelected and pbxPreview with details of this selected stock
                        tbxItemSelected.Text = Stocks[i].Desc;
                        pbxPreview.ImageLocation = Stocks[i].Image;

                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear tbxSearch on click
            tbxSearch.Text = String.Empty;
        }

        private void btnClear_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            // Search for stock when a user types in tbxSearch
            SearchStock();
        }
        private void SearchStock()
        {
            // Record the input as a search string
            string searchString = tbxSearch.Text.Trim().ToLower();
            dgvStock.Rows.Clear();
            RefreshStock();

            if (String.IsNullOrWhiteSpace(searchString))
            {
                // Disable btnClear if there is no input
                btnClear.Enabled = false;
                dgvStock.ClearSelection();
            }
            else
            {
                try
                {
                    int selectedOrder = -1;

                    // Assign the selected order variable
                    foreach (WeddingList weddingList in WeddingLists)
                    {
                        if (weddingList.ReferenceName == cbxBuyingFor.Text)
                        {
                            selectedOrder = Convert.ToInt32(weddingList.OrderNo);
                        }
                    }

                    // Store the search results in a list
                    List<Stock> searchResults = Stock.GetStockFromSearch(searchString);

                    // Clear dgvStock
                    dgvStock.Rows.Clear();

                    // Get WeddingListStock
                    List<WeddingListStock> updatedWeddingListStocks = WeddingListStock.GetWeddingListStock();
                    WeddingListStocks = updatedWeddingListStocks;

                    foreach (WeddingListStock weddingListStock in WeddingListStocks)
                    {
                        foreach (Stock stock in searchResults)
                        {
                            // Ensure that the search results displayed are items of stock that are only in the currently selected wedding list
                            if (stock.StockNo == weddingListStock.StockNo && weddingListStock.OrderNo == selectedOrder)
                            {
                                // Add search results to dgvStock
                                dgvStock.Rows.Add(stock.StockNo, stock.Desc, stock.Category, stock.SellingPrice, weddingListStock.QtyOrdered);
                                currentOrderNo = Convert.ToInt32(weddingListStock.OrderNo);
                                currentBuyingForNo = Convert.ToInt32(weddingListStock.CustNo);

                            }
                        }
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
                            // Check that the quantity entered is an integer
                            qty = Convert.ToInt32(tbxQuantity.Text);
                            success = true;
                        }
                        catch
                        {
                            // Error message if the quantity is not an integer
                            MessageBox.Show("You must enter a valid quantity");
                            success = false;
                            return;
                        }
                        // Check that the quantity is greater than 0  and less than or equal to the quantity available
                        if (qty <= currentQuantityAvailable && success == true && qty > 0)
                        {
                            dgvCart.Rows.Add(stock.StockNo, stock.Desc, stock.SellingPrice, tbxQuantity.Text);
                            // Update the total
                            total = total + (Convert.ToInt32(stock.SellingPrice) * Convert.ToInt32(tbxQuantity.Text));

                            foreach (DataGridViewRow row in dgvStock.Rows)
                            {
                                int currentStockNo = Convert.ToInt32(row.Cells[0].Value);

                                if (stock.StockNo == currentStockNo)
                                {
                                    // Update the quantity of that stock available
                                    newQuantity = Convert.ToInt32(row.Cells[4].Value) - Convert.ToInt32(tbxQuantity.Text);
                                    row.Cells[4].Value = newQuantity;

                                }
                            }
                        }
                        else
                        {
                            // Error message if quantity entered is not valid
                            MessageBox.Show("Invalid quantity entered");
                        }
                    }
                }
                // Clear dgvStock and reset text boxes
                dgvStock.ClearSelection();
                tbxItemSelected.Text = String.Empty;
                tbxQuantity.Text = String.Empty;
                // Display new total
                lblTotal.Text = Convert.ToString(total);
            }
            catch (SqlException)
            {
                // Error message if stock cannot be added to the cart
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
                    // Error message if user tries to complete purchase without adding any stock to the cart
                    MessageBox.Show("You must add stock to the cart before completing a purchase");
                }
                else
                {
                    // Get Customers
                    List<Customer> updatedCustomers = Customer.GetCustomers();
                    Customers = updatedCustomers;

                    foreach (Customer customer in Customers)
                    {
                        if (customer.Name == Convert.ToString(cbxBuyingAs.Text))
                        {
                            // Get the customer number for the customer selected in cbxBuyingAs
                            currentBuyingAsNo = Convert.ToInt32(customer.CustomerNo);
                        }
                    }

                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        // Create a new WeddingListPurchase
                        int newQtyRequired = Convert.ToInt32(row.Cells[3].Value);
                        WeddingListPurchase newWeddingListPurchase = new WeddingListPurchase(currentOrderNo, currentBuyingAsNo, Convert.ToInt32(row.Cells[0].Value), newQtyRequired, Convert.ToInt32(row.Cells[3].Value));
                        newWeddingListPurchase.CreateWeddingListPurchase();

                        int currentStockNo = Convert.ToInt32(row.Cells[0].Value);

                        foreach (WeddingListStock weddingListStock in WeddingListStocks)
                        {
                            if (weddingListStock.StockNo == currentStockNo)
                            {
                                finalQuantity = Convert.ToInt32(weddingListStock.QtyOrdered) - Convert.ToInt32(row.Cells[3].Value);

                                // Record the new quantity of stock available
                                int qty = finalQuantity;

                                // Retreive any errors found when trying to update stock
                                List<string> errors = WeddingListStock.TryConstructWeddingListStock(weddingListStock.OrderNo, weddingListStock.CustNo, weddingListStock.StockNo, qty);

                                // Display any errors returned
                                if (errors.Count > 0)
                                {
                                    string s = String.Join("\n", errors);
                                    MessageBox.Show(s);
                                    return;
                                }
                                // Create new WeddingListStock object
                                WeddingListStock newWeddingListStock = new WeddingListStock(weddingListStock.OrderNo, weddingListStock.CustNo, weddingListStock.StockNo, qty);

                                try
                                {
                                    // Update WeddingListStock with new quantity
                                    newWeddingListStock.UpdateWeddingListStock(Convert.ToInt32(weddingListStock.OrderNo), Convert.ToInt32(weddingListStock.CustNo), Convert.ToInt32(weddingListStock.StockNo));
                                    // Clear dgvStock
                                    dgvStock.ClearSelection();
                                    dgvStock.Rows.Clear();

                                    // Refresh stock in dgvStock
                                    RefreshStock();
                                    // Refresh customers in cbxBuyingFor
                                    RefreshCustomers();


                                }
                                catch (SqlException ex)
                                {
                                    // Error message if purchase cannot be completed
                                    MessageBox.Show("An error has happened when trying to complete purchase" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    // Clear dgvCart and reset text boxes and totals
                    dgvCart.ClearSelection();
                    dgvCart.Rows.Clear();
                    tbxItemSelected.Text = String.Empty;
                    tbxQuantity.Text = String.Empty;
                    total = 0;
                    lblTotal.Text = "0";

                    cbxBuyingFor.SelectedIndex = -1;
                    cbxBuyingAs.SelectedIndex = -1;

                    //Tell user purchase was successful
                    MessageBox.Show("Purchase complete");

                    // Refresh the form
                    this.Close();
                    Form frmWeddingListPurchase = new frmWeddingListPurchase();
                    frmWeddingListPurchase.Show();

                }
            }
            catch (SqlException)
            {
                // Error message if a purchase cannot be completed
                MessageBox.Show("Could not complete purchase", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            if (cbxBuyingFor.SelectedIndex == -1)
            {
                // Error message if no customer wedding list has been chosen
                MessageBox.Show("You must select a customer to buy for first");
            }
            else
            {
                // Clear any searches made to ensure it's the whole wedding list displayed
                tbxSearch.Text = String.Empty;

                // Create a html document that includes a table that displays the stock of the currently selected wedding list
                TextWriter writer = new StreamWriter(@"website.txt");
                writer.WriteLine("<!DOCTYPE html>\n<html>\n<head>\n<title>Wedding List</title>\n</head>\n<style> h1 { font-family: sans-serif; } table { border-collapse: collapse; margin: 25px 0; font-size: 0.9em; font-family: sans-serif; min-width: 400px; box-shadow: 0 0 20px rgba(0, 0, 0, 0.15); } \n thead tr { background-color: #4682B4; color: #ffffff; text-align: left; } \n th, td { padding: 12px 15px; } \n tbody tr { border-bottom: 1px solid #dddddd; } \n tbody tr:nth-of-type(even) { background-color: #f3f3f3; } \n tbody tr:last-of-type { border-bottom: 2px solid #4682B4; } \n tbody tr.active-row { font-weight: bold; color: #4682B4; } \n </style>\n<body>\n<h1>Wedding List</h1>\n<table style=\"width: 100 % \">\n<thead>\n<tr>\n<th>Stock No</th>\n<th>Description</th>\n<th>Category</th>\n<th>Price</th>\n<th>Quantity</th>\n</tr>\n</thead>\n<tbody>\n");
                for (int i = 0; i < dgvStock.Rows.Count; i++)
                {
                    writer.WriteLine("<tr>");
                    for (int j = 0; j < dgvStock.Columns.Count; j++)
                    {
                        writer.Write("<td>" + dgvStock.Rows[i].Cells[j].Value.ToString() + "</td>");
                    }
                    writer.WriteLine("</tr>");
                }
                writer.WriteLine("</tbody>\n");
                writer.WriteLine("</table>\n");
                writer.WriteLine("</body>\n");
                writer.WriteLine("</html>");
                writer.Close();

                // Create a temporary HTML file
                string filePath = @"website.txt";
                string html = File.ReadAllText(filePath);
                string tempFile = Path.GetTempFileName() + ".html";
                File.WriteAllText(tempFile, html);

                // Open the default web browser and display the HTML file
                Process.Start(new ProcessStartInfo(tempFile) { UseShellExecute = true });
            }
        }

        private void llbWeddingList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cbxBuyingFor.SelectedIndex == -1)
            {
                // Error message if no customer wedding list has been selected
                MessageBox.Show("You must select a customer to buy for first");
            }
            else
            {
                // Open frmWeddingListCustomers as a pop-up
                Form frmWeddingListCustomers = new frmWeddingListCustomers(currentOrderNo);
                frmWeddingListCustomers.Show();
            }
        }
    }
}
