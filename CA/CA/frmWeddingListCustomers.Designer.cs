
namespace CA
{
    partial class frmWeddingListCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeddingListCustomers));
            this.pnlBoughtFromWeddingList = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblBoughtFromWeddingList = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblItemSelected = new System.Windows.Forms.Label();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.pnlBoughtFromWeddingList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoughtFromWeddingList
            // 
            this.pnlBoughtFromWeddingList.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlBoughtFromWeddingList.Controls.Add(this.btnReturn);
            this.pnlBoughtFromWeddingList.Controls.Add(this.lblBoughtFromWeddingList);
            this.pnlBoughtFromWeddingList.Location = new System.Drawing.Point(-261, -21);
            this.pnlBoughtFromWeddingList.Name = "pnlBoughtFromWeddingList";
            this.pnlBoughtFromWeddingList.Size = new System.Drawing.Size(898, 119);
            this.pnlBoughtFromWeddingList.TabIndex = 49;
            this.pnlBoughtFromWeddingList.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStock_Paint);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(53, 22);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // lblBoughtFromWeddingList
            // 
            this.lblBoughtFromWeddingList.AutoSize = true;
            this.lblBoughtFromWeddingList.BackColor = System.Drawing.Color.SteelBlue;
            this.lblBoughtFromWeddingList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBoughtFromWeddingList.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBoughtFromWeddingList.Location = new System.Drawing.Point(283, 36);
            this.lblBoughtFromWeddingList.Name = "lblBoughtFromWeddingList";
            this.lblBoughtFromWeddingList.Size = new System.Drawing.Size(326, 60);
            this.lblBoughtFromWeddingList.TabIndex = 0;
            this.lblBoughtFromWeddingList.Text = "The Following People Have \r\nBought From The Wedding List:";
            this.lblBoughtFromWeddingList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(140, 345);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 49);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnCreateUpdate_Click);
            // 
            // lblItemSelected
            // 
            this.lblItemSelected.AutoSize = true;
            this.lblItemSelected.Location = new System.Drawing.Point(-188, 133);
            this.lblItemSelected.Name = "lblItemSelected";
            this.lblItemSelected.Size = new System.Drawing.Size(78, 15);
            this.lblItemSelected.TabIndex = 50;
            this.lblItemSelected.Text = "Item Selected";
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Location = new System.Drawing.Point(22, 135);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(0, 15);
            this.lblCustomers.TabIndex = 51;
            // 
            // frmWeddingListCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 417);
            this.Controls.Add(this.lblCustomers);
            this.Controls.Add(this.pnlBoughtFromWeddingList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblItemSelected);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWeddingListCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bought from Wedding List";
            this.Load += new System.EventHandler(this.frmBoughtFromWeddingList_Load);
            this.Shown += new System.EventHandler(this.frmWeddingListCustomers_Shown);
            this.pnlBoughtFromWeddingList.ResumeLayout(false);
            this.pnlBoughtFromWeddingList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoughtFromWeddingList;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblBoughtFromWeddingList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblItemSelected;
        private System.Windows.Forms.Label lblCustomers;
    }
}