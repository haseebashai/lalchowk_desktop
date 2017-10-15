namespace Veiled_Kashmir_Admin_Panel
{
    partial class approveprice
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
            this.formlbl = new System.Windows.Forms.Label();
            this.reqdataview = new System.Windows.Forms.DataGridView();
            this.pidlbl = new System.Windows.Forms.Label();
            this.pnamelbl = new System.Windows.Forms.Label();
            this.mrplbl = new System.Windows.Forms.Label();
            this.pricelbl = new System.Windows.Forms.Label();
            this.dealerlbl = new System.Windows.Forms.Label();
            this.reqlbl = new System.Windows.Forms.Label();
            this.rslbl = new System.Windows.Forms.Label();
            this.stocklbl = new System.Windows.Forms.Label();
            this.apbtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.apnl = new System.Windows.Forms.Panel();
            this.ubtn = new System.Windows.Forms.Button();
            this.ppnl = new System.Windows.Forms.Panel();
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.reqdataview)).BeginInit();
            this.apnl.SuspendLayout();
            this.ppnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // formlbl
            // 
            this.formlbl.AutoSize = true;
            this.formlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formlbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.formlbl.Location = new System.Drawing.Point(0, -1);
            this.formlbl.Name = "formlbl";
            this.formlbl.Size = new System.Drawing.Size(120, 24);
            this.formlbl.TabIndex = 0;
            this.formlbl.Text = "Review Price";
            // 
            // reqdataview
            // 
            this.reqdataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reqdataview.BackgroundColor = System.Drawing.Color.White;
            this.reqdataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reqdataview.Location = new System.Drawing.Point(6, 36);
            this.reqdataview.Name = "reqdataview";
            this.reqdataview.Size = new System.Drawing.Size(949, 459);
            this.reqdataview.TabIndex = 1;
            this.reqdataview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reqdataview_CellClick);
            // 
            // pidlbl
            // 
            this.pidlbl.AutoSize = true;
            this.pidlbl.ForeColor = System.Drawing.Color.Black;
            this.pidlbl.Location = new System.Drawing.Point(3, 47);
            this.pidlbl.Name = "pidlbl";
            this.pidlbl.Size = new System.Drawing.Size(21, 13);
            this.pidlbl.TabIndex = 2;
            this.pidlbl.Text = "pid";
            // 
            // pnamelbl
            // 
            this.pnamelbl.AutoSize = true;
            this.pnamelbl.ForeColor = System.Drawing.Color.Black;
            this.pnamelbl.Location = new System.Drawing.Point(46, 47);
            this.pnamelbl.Name = "pnamelbl";
            this.pnamelbl.Size = new System.Drawing.Size(48, 13);
            this.pnamelbl.TabIndex = 3;
            this.pnamelbl.Text = "proname";
            // 
            // mrplbl
            // 
            this.mrplbl.AutoSize = true;
            this.mrplbl.ForeColor = System.Drawing.Color.Black;
            this.mrplbl.Location = new System.Drawing.Point(2, 109);
            this.mrplbl.Name = "mrplbl";
            this.mrplbl.Size = new System.Drawing.Size(24, 13);
            this.mrplbl.TabIndex = 4;
            this.mrplbl.Text = "mrp";
            // 
            // pricelbl
            // 
            this.pricelbl.AutoSize = true;
            this.pricelbl.ForeColor = System.Drawing.Color.Black;
            this.pricelbl.Location = new System.Drawing.Point(91, 109);
            this.pricelbl.Name = "pricelbl";
            this.pricelbl.Size = new System.Drawing.Size(30, 13);
            this.pricelbl.TabIndex = 5;
            this.pricelbl.Text = "price";
            // 
            // dealerlbl
            // 
            this.dealerlbl.AutoSize = true;
            this.dealerlbl.ForeColor = System.Drawing.Color.Black;
            this.dealerlbl.Location = new System.Drawing.Point(178, 109);
            this.dealerlbl.Name = "dealerlbl";
            this.dealerlbl.Size = new System.Drawing.Size(36, 13);
            this.dealerlbl.TabIndex = 6;
            this.dealerlbl.Text = "dprice";
            // 
            // reqlbl
            // 
            this.reqlbl.AutoSize = true;
            this.reqlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reqlbl.ForeColor = System.Drawing.Color.Red;
            this.reqlbl.Location = new System.Drawing.Point(279, 109);
            this.reqlbl.Name = "reqlbl";
            this.reqlbl.Size = new System.Drawing.Size(33, 13);
            this.reqlbl.TabIndex = 7;
            this.reqlbl.Text = "rprice";
            // 
            // rslbl
            // 
            this.rslbl.AutoSize = true;
            this.rslbl.ForeColor = System.Drawing.Color.Black;
            this.rslbl.Location = new System.Drawing.Point(399, 109);
            this.rslbl.Name = "rslbl";
            this.rslbl.Size = new System.Drawing.Size(38, 13);
            this.rslbl.TabIndex = 8;
            this.rslbl.Text = "rstatus";
            // 
            // stocklbl
            // 
            this.stocklbl.AutoSize = true;
            this.stocklbl.ForeColor = System.Drawing.Color.Black;
            this.stocklbl.Location = new System.Drawing.Point(525, 109);
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
            this.apbtn.Location = new System.Drawing.Point(640, 86);
            this.apbtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.apbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.apbtn.Name = "apbtn";
            this.apbtn.Primary = false;
            this.apbtn.Size = new System.Drawing.Size(136, 36);
            this.apbtn.TabIndex = 20;
            this.apbtn.Text = "Approve request";
            this.apbtn.UseVisualStyleBackColor = true;
            this.apbtn.Click += new System.EventHandler(this.apbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(525, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(399, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Request Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(279, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Requested Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(178, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Dealer Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(91, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(2, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "MRP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(46, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Product Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(3, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Pid";
            // 
            // apnl
            // 
            this.apnl.Controls.Add(this.label2);
            this.apnl.Controls.Add(this.pidlbl);
            this.apnl.Controls.Add(this.label3);
            this.apnl.Controls.Add(this.pnamelbl);
            this.apnl.Controls.Add(this.label4);
            this.apnl.Controls.Add(this.mrplbl);
            this.apnl.Controls.Add(this.label5);
            this.apnl.Controls.Add(this.pricelbl);
            this.apnl.Controls.Add(this.label6);
            this.apnl.Controls.Add(this.dealerlbl);
            this.apnl.Controls.Add(this.label7);
            this.apnl.Controls.Add(this.reqlbl);
            this.apnl.Controls.Add(this.label8);
            this.apnl.Controls.Add(this.rslbl);
            this.apnl.Controls.Add(this.label9);
            this.apnl.Controls.Add(this.stocklbl);
            this.apnl.Controls.Add(this.apbtn);
            this.apnl.Location = new System.Drawing.Point(6, 512);
            this.apnl.Name = "apnl";
            this.apnl.Size = new System.Drawing.Size(949, 162);
            this.apnl.TabIndex = 29;
            this.apnl.Visible = false;
            // 
            // ubtn
            // 
            this.ubtn.Location = new System.Drawing.Point(961, 210);
            this.ubtn.Name = "ubtn";
            this.ubtn.Size = new System.Drawing.Size(139, 100);
            this.ubtn.TabIndex = 30;
            this.ubtn.Text = "Update";
            this.ubtn.UseVisualStyleBackColor = true;
            this.ubtn.Click += new System.EventHandler(this.ubtn_Click);
            // 
            // ppnl
            // 
            this.ppnl.Controls.Add(this.reqdataview);
            this.ppnl.Controls.Add(this.apnl);
            this.ppnl.Controls.Add(this.ubtn);
            this.ppnl.Location = new System.Drawing.Point(1, 0);
            this.ppnl.Name = "ppnl";
            this.ppnl.Size = new System.Drawing.Size(1162, 710);
            this.ppnl.TabIndex = 72;
            this.ppnl.Visible = false;
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            this.bgworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgworker_RunWorkerCompleted);
            // 
            // approveprice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 722);
            this.Controls.Add(this.ppnl);
            this.Controls.Add(this.formlbl);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "approveprice";
            this.Text = "destinations";
            ((System.ComponentModel.ISupportInitialize)(this.reqdataview)).EndInit();
            this.apnl.ResumeLayout(false);
            this.apnl.PerformLayout();
            this.ppnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formlbl;
        private System.Windows.Forms.DataGridView reqdataview;
        private System.Windows.Forms.Label pidlbl;
        private System.Windows.Forms.Label pnamelbl;
        private System.Windows.Forms.Label mrplbl;
        private System.Windows.Forms.Label pricelbl;
        private System.Windows.Forms.Label dealerlbl;
        private System.Windows.Forms.Label reqlbl;
        private System.Windows.Forms.Label rslbl;
        private System.Windows.Forms.Label stocklbl;
        private MaterialSkin.Controls.MaterialFlatButton apbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel apnl;
        private System.Windows.Forms.Button ubtn;
        private System.Windows.Forms.Panel ppnl;
        private System.ComponentModel.BackgroundWorker bgworker;
    }
}