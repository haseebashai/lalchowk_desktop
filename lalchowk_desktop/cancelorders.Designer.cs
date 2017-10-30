namespace Veiled_Kashmir_Admin_Panel
{
    partial class cancelorders
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
            this.ordergridview = new System.Windows.Forms.DataGridView();
            this.apnl = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.oidlbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.amountlbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.shiplbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.namelbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.statuslbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.stocklbl = new System.Windows.Forms.Label();
            this.apbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.formlbl = new System.Windows.Forms.Label();
            this.cpnl = new System.Windows.Forms.Panel();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ordergridview)).BeginInit();
            this.apnl.SuspendLayout();
            this.cpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ordergridview
            // 
            this.ordergridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ordergridview.BackgroundColor = System.Drawing.Color.White;
            this.ordergridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordergridview.Location = new System.Drawing.Point(2, 51);
            this.ordergridview.Name = "ordergridview";
            this.ordergridview.Size = new System.Drawing.Size(1122, 372);
            this.ordergridview.TabIndex = 1;
            this.ordergridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordergridview_CellClick);
            // 
            // apnl
            // 
            this.apnl.Controls.Add(this.label2);
            this.apnl.Controls.Add(this.oidlbl);
            this.apnl.Controls.Add(this.label4);
            this.apnl.Controls.Add(this.amountlbl);
            this.apnl.Controls.Add(this.label8);
            this.apnl.Controls.Add(this.shiplbl);
            this.apnl.Controls.Add(this.label6);
            this.apnl.Controls.Add(this.namelbl);
            this.apnl.Controls.Add(this.label7);
            this.apnl.Controls.Add(this.statuslbl);
            this.apnl.Controls.Add(this.label9);
            this.apnl.Controls.Add(this.stocklbl);
            this.apnl.Controls.Add(this.apbtn);
            this.apnl.Location = new System.Drawing.Point(3, 444);
            this.apnl.Name = "apnl";
            this.apnl.Size = new System.Drawing.Size(949, 158);
            this.apnl.TabIndex = 30;
            this.apnl.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(398, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Count";
            // 
            // oidlbl
            // 
            this.oidlbl.AutoSize = true;
            this.oidlbl.ForeColor = System.Drawing.Color.Black;
            this.oidlbl.Location = new System.Drawing.Point(3, 45);
            this.oidlbl.Name = "oidlbl";
            this.oidlbl.Size = new System.Drawing.Size(23, 13);
            this.oidlbl.TabIndex = 2;
            this.oidlbl.Text = "Oid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(306, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Status";
            // 
            // amountlbl
            // 
            this.amountlbl.AutoSize = true;
            this.amountlbl.ForeColor = System.Drawing.Color.Black;
            this.amountlbl.Location = new System.Drawing.Point(2, 107);
            this.amountlbl.Name = "amountlbl";
            this.amountlbl.Size = new System.Drawing.Size(24, 13);
            this.amountlbl.TabIndex = 4;
            this.amountlbl.Text = "mrp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(182, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Name";
            // 
            // shiplbl
            // 
            this.shiplbl.AutoSize = true;
            this.shiplbl.ForeColor = System.Drawing.Color.Black;
            this.shiplbl.Location = new System.Drawing.Point(91, 107);
            this.shiplbl.Name = "shiplbl";
            this.shiplbl.Size = new System.Drawing.Size(30, 13);
            this.shiplbl.TabIndex = 5;
            this.shiplbl.Text = "price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(91, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Shipping";
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.ForeColor = System.Drawing.Color.Black;
            this.namelbl.Location = new System.Drawing.Point(182, 107);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(33, 13);
            this.namelbl.TabIndex = 6;
            this.namelbl.Text = "name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(2, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Amount";
            // 
            // statuslbl
            // 
            this.statuslbl.AutoSize = true;
            this.statuslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslbl.ForeColor = System.Drawing.Color.Red;
            this.statuslbl.Location = new System.Drawing.Point(306, 107);
            this.statuslbl.Name = "statuslbl";
            this.statuslbl.Size = new System.Drawing.Size(35, 13);
            this.statuslbl.TabIndex = 7;
            this.statuslbl.Text = "status";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(3, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "OrderID";
            // 
            // stocklbl
            // 
            this.stocklbl.AutoSize = true;
            this.stocklbl.ForeColor = System.Drawing.Color.Black;
            this.stocklbl.Location = new System.Drawing.Point(399, 107);
            this.stocklbl.Name = "stocklbl";
            this.stocklbl.Size = new System.Drawing.Size(33, 13);
            this.stocklbl.TabIndex = 9;
            this.stocklbl.Text = "stock";
            // 
            // apbtn
            // 
            this.apbtn.AutoSize = true;
            this.apbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.apbtn.Depth = 0;
            this.apbtn.Location = new System.Drawing.Point(513, 84);
            this.apbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.apbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.apbtn.Name = "apbtn";
            this.apbtn.Primary = false;
            this.apbtn.Size = new System.Drawing.Size(111, 36);
            this.apbtn.TabIndex = 20;
            this.apbtn.Text = "cancel order";
            this.apbtn.UseVisualStyleBackColor = true;
            this.apbtn.Click += new System.EventHandler(this.apbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(479, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Select order from the list";
            // 
            // formlbl
            // 
            this.formlbl.AutoSize = true;
            this.formlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.formlbl.Location = new System.Drawing.Point(0, -2);
            this.formlbl.Name = "formlbl";
            this.formlbl.Size = new System.Drawing.Size(123, 24);
            this.formlbl.TabIndex = 32;
            this.formlbl.Text = "Cancel Order";
            // 
            // cpnl
            // 
            this.cpnl.Controls.Add(this.label1);
            this.cpnl.Controls.Add(this.ordergridview);
            this.cpnl.Controls.Add(this.apnl);
            this.cpnl.Location = new System.Drawing.Point(1, 1);
            this.cpnl.Name = "cpnl";
            this.cpnl.Size = new System.Drawing.Size(1161, 607);
            this.cpnl.TabIndex = 33;
            this.cpnl.Visible = false;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // cancelorders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 610);
            this.Controls.Add(this.cpnl);
            this.Controls.Add(this.formlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cancelorders";
            this.Text = "cancelorders";
            ((System.ComponentModel.ISupportInitialize)(this.ordergridview)).EndInit();
            this.apnl.ResumeLayout(false);
            this.apnl.PerformLayout();
            this.cpnl.ResumeLayout(false);
            this.cpnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ordergridview;
        private System.Windows.Forms.Panel apnl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label oidlbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label amountlbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label shiplbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label statuslbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label stocklbl;
        private MaterialSkin.Controls.MaterialFlatButton apbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label formlbl;
        private System.Windows.Forms.Panel cpnl;
        private System.ComponentModel.BackgroundWorker bgworker;
    }
}