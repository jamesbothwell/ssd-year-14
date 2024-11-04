
namespace CA
{
    partial class frmBooking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBooking));
            this.pnlBooking = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblCreateBooking = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tbxCustomer = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbxTime = new System.Windows.Forms.ComboBox();
            this.btnBook = new System.Windows.Forms.Button();
            this.lblStaff = new System.Windows.Forms.Label();
            this.lblStaffMember = new System.Windows.Forms.Label();
            this.pnlBooking.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBooking
            // 
            this.pnlBooking.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlBooking.Controls.Add(this.btnReturn);
            this.pnlBooking.Controls.Add(this.lblCreateBooking);
            this.pnlBooking.Location = new System.Drawing.Point(-47, -4);
            this.pnlBooking.Name = "pnlBooking";
            this.pnlBooking.Size = new System.Drawing.Size(930, 118);
            this.pnlBooking.TabIndex = 18;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReturn.Location = new System.Drawing.Point(59, 16);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 43);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblCreateBooking
            // 
            this.lblCreateBooking.AutoSize = true;
            this.lblCreateBooking.BackColor = System.Drawing.Color.SteelBlue;
            this.lblCreateBooking.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCreateBooking.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCreateBooking.Location = new System.Drawing.Point(301, 39);
            this.lblCreateBooking.Name = "lblCreateBooking";
            this.lblCreateBooking.Size = new System.Drawing.Size(274, 47);
            this.lblCreateBooking.TabIndex = 0;
            this.lblCreateBooking.Text = "Create Booking";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(70, 172);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(59, 15);
            this.lblCustomer.TabIndex = 19;
            this.lblCustomer.Text = "Customer";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(69, 228);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(217, 15);
            this.lblDate.TabIndex = 20;
            this.lblDate.Text = "Please select a date for an appointment ";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(462, 169);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(197, 15);
            this.lblTime.TabIndex = 21;
            this.lblTime.Text = "Please select a time slot for this date";
            // 
            // tbxCustomer
            // 
            this.tbxCustomer.Location = new System.Drawing.Point(169, 166);
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.ReadOnly = true;
            this.tbxCustomer.Size = new System.Drawing.Size(100, 23);
            this.tbxCustomer.TabIndex = 22;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(69, 274);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 23;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // cbxTime
            // 
            this.cbxTime.FormattingEnabled = true;
            this.cbxTime.Location = new System.Drawing.Point(462, 202);
            this.cbxTime.Name = "cbxTime";
            this.cbxTime.Size = new System.Drawing.Size(121, 23);
            this.cbxTime.TabIndex = 24;
            this.cbxTime.SelectedIndexChanged += new System.EventHandler(this.cbxTime_SelectedIndexChanged);
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBook.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBook.Location = new System.Drawing.Point(359, 370);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(107, 45);
            this.btnBook.TabIndex = 25;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(462, 238);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(159, 15);
            this.lblStaff.TabIndex = 26;
            this.lblStaff.Text = "Your member of staff will be:";
            // 
            // lblStaffMember
            // 
            this.lblStaffMember.AutoSize = true;
            this.lblStaffMember.Location = new System.Drawing.Point(462, 280);
            this.lblStaffMember.Name = "lblStaffMember";
            this.lblStaffMember.Size = new System.Drawing.Size(31, 15);
            this.lblStaffMember.TabIndex = 27;
            this.lblStaffMember.Text = "Staff";
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStaffMember);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.cbxTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.tbxCustomer);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.pnlBooking);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Booking";
            this.Load += new System.EventHandler(this.frmBooking_Load);
            this.Shown += new System.EventHandler(this.frmBooking_Shown);
            this.pnlBooking.ResumeLayout(false);
            this.pnlBooking.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBooking;
        private System.Windows.Forms.Label lblCreateBooking;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox tbxCustomer;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cbxTime;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblStaffMember;
    }
}