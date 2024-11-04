
namespace CA
{
    partial class frmWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWelcome));
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnWeddingLists = new System.Windows.Forms.Button();
            this.pbxWeddingLists = new System.Windows.Forms.PictureBox();
            this.pbxStock = new System.Windows.Forms.PictureBox();
            this.pbxCustomer = new System.Windows.Forms.PictureBox();
            this.lblSelectCategory = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnBookings = new System.Windows.Forms.Button();
            this.pbxBookings = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxWeddingLists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCustomer.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCustomer.Location = new System.Drawing.Point(84, 297);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(112, 53);
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.Text = "Customers";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.SteelBlue;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStock.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStock.Location = new System.Drawing.Point(264, 297);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(112, 53);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnWeddingLists
            // 
            this.btnWeddingLists.BackColor = System.Drawing.Color.SteelBlue;
            this.btnWeddingLists.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnWeddingLists.FlatAppearance.BorderSize = 0;
            this.btnWeddingLists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeddingLists.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWeddingLists.ForeColor = System.Drawing.SystemColors.Control;
            this.btnWeddingLists.Location = new System.Drawing.Point(609, 297);
            this.btnWeddingLists.Name = "btnWeddingLists";
            this.btnWeddingLists.Size = new System.Drawing.Size(112, 53);
            this.btnWeddingLists.TabIndex = 3;
            this.btnWeddingLists.Text = "Purchase from Wedding List";
            this.btnWeddingLists.UseVisualStyleBackColor = false;
            this.btnWeddingLists.Click += new System.EventHandler(this.btnWeddingList_Click);
            // 
            // pbxWeddingLists
            // 
            this.pbxWeddingLists.Image = ((System.Drawing.Image)(resources.GetObject("pbxWeddingLists.Image")));
            this.pbxWeddingLists.Location = new System.Drawing.Point(609, 175);
            this.pbxWeddingLists.Name = "pbxWeddingLists";
            this.pbxWeddingLists.Size = new System.Drawing.Size(112, 112);
            this.pbxWeddingLists.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxWeddingLists.TabIndex = 12;
            this.pbxWeddingLists.TabStop = false;
            // 
            // pbxStock
            // 
            this.pbxStock.Image = ((System.Drawing.Image)(resources.GetObject("pbxStock.Image")));
            this.pbxStock.Location = new System.Drawing.Point(264, 175);
            this.pbxStock.Name = "pbxStock";
            this.pbxStock.Size = new System.Drawing.Size(112, 112);
            this.pbxStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxStock.TabIndex = 11;
            this.pbxStock.TabStop = false;
            // 
            // pbxCustomer
            // 
            this.pbxCustomer.Image = ((System.Drawing.Image)(resources.GetObject("pbxCustomer.Image")));
            this.pbxCustomer.Location = new System.Drawing.Point(84, 175);
            this.pbxCustomer.Name = "pbxCustomer";
            this.pbxCustomer.Size = new System.Drawing.Size(112, 112);
            this.pbxCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCustomer.TabIndex = 10;
            this.pbxCustomer.TabStop = false;
            // 
            // lblSelectCategory
            // 
            this.lblSelectCategory.AutoSize = true;
            this.lblSelectCategory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSelectCategory.Location = new System.Drawing.Point(302, 83);
            this.lblSelectCategory.Name = "lblSelectCategory";
            this.lblSelectCategory.Size = new System.Drawing.Size(216, 15);
            this.lblSelectCategory.TabIndex = 9;
            this.lblSelectCategory.Text = "Please select a catgeory below to begin:";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWelcome.Location = new System.Drawing.Point(334, 29);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(144, 40);
            this.lblWelcome.TabIndex = 8;
            this.lblWelcome.Text = "Welcome";
            // 
            // btnBookings
            // 
            this.btnBookings.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBookings.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBookings.FlatAppearance.BorderSize = 0;
            this.btnBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBookings.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBookings.Location = new System.Drawing.Point(438, 297);
            this.btnBookings.Name = "btnBookings";
            this.btnBookings.Size = new System.Drawing.Size(112, 53);
            this.btnBookings.TabIndex = 13;
            this.btnBookings.Text = "Bookings";
            this.btnBookings.UseVisualStyleBackColor = false;
            this.btnBookings.Click += new System.EventHandler(this.btnBookings_Click);
            // 
            // pbxBookings
            // 
            this.pbxBookings.Image = ((System.Drawing.Image)(resources.GetObject("pbxBookings.Image")));
            this.pbxBookings.Location = new System.Drawing.Point(438, 175);
            this.pbxBookings.Name = "pbxBookings";
            this.pbxBookings.Size = new System.Drawing.Size(112, 112);
            this.pbxBookings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBookings.TabIndex = 14;
            this.pbxBookings.TabStop = false;
            // 
            // btnReturn
            // 
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReturn.Location = new System.Drawing.Point(12, 12);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 43);
            this.btnReturn.TabIndex = 20;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.pbxBookings);
            this.Controls.Add(this.btnBookings);
            this.Controls.Add(this.pbxWeddingLists);
            this.Controls.Add(this.pbxStock);
            this.Controls.Add(this.pbxCustomer);
            this.Controls.Add(this.lblSelectCategory);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnWeddingLists);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnCustomer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Welcome";
            this.Load += new System.EventHandler(this.frmWelcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxWeddingLists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnWeddingLists;
        private System.Windows.Forms.PictureBox pbxWeddingLists;
        private System.Windows.Forms.PictureBox pbxStock;
        private System.Windows.Forms.PictureBox pbxCustomer;
        private System.Windows.Forms.Label lblSelectCategory;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnBookings;
        private System.Windows.Forms.PictureBox pbxBookings;
        private System.Windows.Forms.Button btnReturn;
    }
}