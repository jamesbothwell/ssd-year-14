
namespace CA
{
    partial class frmWeddingListPurchase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeddingListPurchase));
            this.pnlStock = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblWeddingList = new System.Windows.Forms.Label();
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            this.btnOnline = new System.Windows.Forms.Button();
            this.tbxItemSelected = new System.Windows.Forms.TextBox();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.btnCompletePurchase = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.tbxQuantity = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblItemSelected = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cbxBuyingFor = new System.Windows.Forms.ComboBox();
            this.llbWeddingList = new System.Windows.Forms.LinkLabel();
            this.cbxBuyingAs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalIs = new System.Windows.Forms.Label();
            this.lblPoundSign = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlStock
            // 
            this.pnlStock.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlStock.Controls.Add(this.btnReturn);
            this.pnlStock.Controls.Add(this.lblWeddingList);
            this.pnlStock.Location = new System.Drawing.Point(-39, -11);
            this.pnlStock.Name = "pnlStock";
            this.pnlStock.Size = new System.Drawing.Size(891, 110);
            this.pnlStock.TabIndex = 52;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReturn.Location = new System.Drawing.Point(53, 22);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 43);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblWeddingList
            // 
            this.lblWeddingList.AutoSize = true;
            this.lblWeddingList.BackColor = System.Drawing.Color.SteelBlue;
            this.lblWeddingList.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWeddingList.ForeColor = System.Drawing.SystemColors.Control;
            this.lblWeddingList.Location = new System.Drawing.Point(210, 36);
            this.lblWeddingList.Name = "lblWeddingList";
            this.lblWeddingList.Size = new System.Drawing.Size(485, 47);
            this.lblWeddingList.TabIndex = 0;
            this.lblWeddingList.Text = "Purchase from Wedding List";
            // 
            // pbxPreview
            // 
            this.pbxPreview.Location = new System.Drawing.Point(682, 120);
            this.pbxPreview.Name = "pbxPreview";
            this.pbxPreview.Size = new System.Drawing.Size(59, 58);
            this.pbxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPreview.TabIndex = 63;
            this.pbxPreview.TabStop = false;
            // 
            // btnOnline
            // 
            this.btnOnline.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOnline.FlatAppearance.BorderSize = 0;
            this.btnOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnline.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOnline.Location = new System.Drawing.Point(486, 400);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(137, 23);
            this.btnOnline.TabIndex = 61;
            this.btnOnline.Text = "View Online";
            this.btnOnline.UseVisualStyleBackColor = false;
            this.btnOnline.Click += new System.EventHandler(this.btnOnline_Click);
            // 
            // tbxItemSelected
            // 
            this.tbxItemSelected.Location = new System.Drawing.Point(180, 163);
            this.tbxItemSelected.Name = "tbxItemSelected";
            this.tbxItemSelected.ReadOnly = true;
            this.tbxItemSelected.Size = new System.Drawing.Size(100, 23);
            this.tbxItemSelected.TabIndex = 60;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddToCart.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddToCart.FlatAppearance.BorderSize = 0;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddToCart.Location = new System.Drawing.Point(107, 221);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(107, 23);
            this.btnAddToCart.TabIndex = 59;
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AllowUserToResizeColumns = false;
            this.dgvCart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6});
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCart.Location = new System.Drawing.Point(12, 250);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCart.RowTemplate.Height = 25;
            this.dgvCart.Size = new System.Drawing.Size(284, 118);
            this.dgvCart.TabIndex = 58;
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.AllowUserToResizeColumns = false;
            this.dgvStock.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.dgvStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStock.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockNo,
            this.Description,
            this.Category,
            this.Price,
            this.Quantity});
            this.dgvStock.EnableHeadersVisualStyles = false;
            this.dgvStock.GridColor = System.Drawing.SystemColors.Control;
            this.dgvStock.Location = new System.Drawing.Point(305, 184);
            this.dgvStock.MultiSelect = false;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowHeadersVisible = false;
            this.dgvStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStock.RowTemplate.Height = 25;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(483, 210);
            this.dgvStock.TabIndex = 8;
            this.dgvStock.SelectionChanged += new System.EventHandler(this.dgvStock_SelectionChanged);
            // 
            // btnCompletePurchase
            // 
            this.btnCompletePurchase.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCompletePurchase.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCompletePurchase.FlatAppearance.BorderSize = 0;
            this.btnCompletePurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompletePurchase.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCompletePurchase.Location = new System.Drawing.Point(107, 388);
            this.btnCompletePurchase.Name = "btnCompletePurchase";
            this.btnCompletePurchase.Size = new System.Drawing.Size(107, 49);
            this.btnCompletePurchase.TabIndex = 56;
            this.btnCompletePurchase.Text = "Complete Purchase";
            this.btnCompletePurchase.UseVisualStyleBackColor = false;
            this.btnCompletePurchase.Click += new System.EventHandler(this.btnCompletePurchase_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(559, 138);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 55;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.TextChanged += new System.EventHandler(this.btnClear_TextChanged);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(422, 138);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(100, 23);
            this.tbxSearch.TabIndex = 54;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // tbxQuantity
            // 
            this.tbxQuantity.Location = new System.Drawing.Point(180, 192);
            this.tbxQuantity.Name = "tbxQuantity";
            this.tbxQuantity.Size = new System.Drawing.Size(100, 23);
            this.tbxQuantity.TabIndex = 53;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(43, 107);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(62, 15);
            this.lblCustomer.TabIndex = 66;
            this.lblCustomer.Text = "Buying for";
            // 
            // lblItemSelected
            // 
            this.lblItemSelected.AutoSize = true;
            this.lblItemSelected.Location = new System.Drawing.Point(43, 166);
            this.lblItemSelected.Name = "lblItemSelected";
            this.lblItemSelected.Size = new System.Drawing.Size(78, 15);
            this.lblItemSelected.TabIndex = 65;
            this.lblItemSelected.Text = "Item Selected";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(43, 195);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(53, 15);
            this.lblQuantity.TabIndex = 64;
            this.lblQuantity.Text = "Quantity";
            // 
            // cbxBuyingFor
            // 
            this.cbxBuyingFor.FormattingEnabled = true;
            this.cbxBuyingFor.Location = new System.Drawing.Point(180, 105);
            this.cbxBuyingFor.Name = "cbxBuyingFor";
            this.cbxBuyingFor.Size = new System.Drawing.Size(100, 23);
            this.cbxBuyingFor.TabIndex = 67;
            this.cbxBuyingFor.SelectedIndexChanged += new System.EventHandler(this.cbxCustomer_SelectedIndexChanged);
            // 
            // llbWeddingList
            // 
            this.llbWeddingList.AutoSize = true;
            this.llbWeddingList.LinkColor = System.Drawing.Color.SteelBlue;
            this.llbWeddingList.Location = new System.Drawing.Point(403, 426);
            this.llbWeddingList.Name = "llbWeddingList";
            this.llbWeddingList.Size = new System.Drawing.Size(305, 15);
            this.llbWeddingList.TabIndex = 68;
            this.llbWeddingList.TabStop = true;
            this.llbWeddingList.Text = "Click here to see who has bought from this Wedding List";
            this.llbWeddingList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbWeddingList_LinkClicked);
            // 
            // cbxBuyingAs
            // 
            this.cbxBuyingAs.FormattingEnabled = true;
            this.cbxBuyingAs.Location = new System.Drawing.Point(180, 134);
            this.cbxBuyingAs.Name = "cbxBuyingAs";
            this.cbxBuyingAs.Size = new System.Drawing.Size(100, 23);
            this.cbxBuyingAs.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 69;
            this.label1.Text = "Buying as";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(180, 370);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 15);
            this.lblTotal.TabIndex = 72;
            this.lblTotal.Text = "0";
            // 
            // lblTotalIs
            // 
            this.lblTotalIs.AutoSize = true;
            this.lblTotalIs.Location = new System.Drawing.Point(129, 370);
            this.lblTotalIs.Name = "lblTotalIs";
            this.lblTotalIs.Size = new System.Drawing.Size(35, 15);
            this.lblTotalIs.TabIndex = 71;
            this.lblTotalIs.Text = "Total:";
            // 
            // lblPoundSign
            // 
            this.lblPoundSign.AutoSize = true;
            this.lblPoundSign.Location = new System.Drawing.Point(170, 370);
            this.lblPoundSign.Name = "lblPoundSign";
            this.lblPoundSign.Size = new System.Drawing.Size(13, 15);
            this.lblPoundSign.TabIndex = 73;
            this.lblPoundSign.Text = "£";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Stock No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Price (£)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // StockNo
            // 
            this.StockNo.HeaderText = "Stock No";
            this.StockNo.Name = "StockNo";
            this.StockNo.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price (£)";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // frmWeddingListPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPoundSign);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalIs);
            this.Controls.Add(this.cbxBuyingFor);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cbxBuyingAs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llbWeddingList);
            this.Controls.Add(this.lblItemSelected);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.pbxPreview);
            this.Controls.Add(this.btnOnline);
            this.Controls.Add(this.tbxItemSelected);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.btnCompletePurchase);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.tbxQuantity);
            this.Controls.Add(this.pnlStock);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWeddingListPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase from Wedding List";
            this.Load += new System.EventHandler(this.frmWeddingList2_Load);
            this.Shown += new System.EventHandler(this.frmWeddingList2_Shown);
            this.pnlStock.ResumeLayout(false);
            this.pnlStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlStock;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblWeddingList;
        private System.Windows.Forms.PictureBox pbxPreview;
        private System.Windows.Forms.Button btnOnline;
        private System.Windows.Forms.TextBox tbxItemSelected;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Button btnCompletePurchase;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.TextBox tbxQuantity;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblItemSelected;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ComboBox cbxBuyingFor;
        private System.Windows.Forms.LinkLabel llbWeddingList;
        private System.Windows.Forms.ComboBox cbxBuyingAs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalIs;
        private System.Windows.Forms.Label lblPoundSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
    }
}